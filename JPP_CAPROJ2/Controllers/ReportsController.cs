using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Controllers
{
    public class ReportsController : Controller
    {
        private IProductRepository _prodRepo;
        private ICartRepository _cartRepo;
        private readonly IHostingEnvironment _hosting;
        private readonly IUserRepository _userRepo;
        private readonly INotificationRepository _notificationRepo;
        private readonly IOrderRepository _orders;
        private ITransactionRepository _transactionRepo;

        public ReportsController(IHostingEnvironment hosting, IUserRepository userRepo, INotificationRepository notificationRepo, IOrderRepository orders, ITransactionRepository transactionRepo, IProductRepository prodRepo, ICartRepository cartRepo)
        {
            _prodRepo = prodRepo;
            _cartRepo = cartRepo;
            _hosting = hosting;
            _userRepo = userRepo;
            _notificationRepo = notificationRepo;
            _orders = orders;
            _transactionRepo = transactionRepo;
        }


        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ReportThis(string name)
        {
            return new ViewAsPdf(name);
        }

        public IActionResult GetThis(string name, DateTime? start, DateTime? end)
        {
           
            string tableDetails = "";
          
            if (name == "User Masterlist")
            {
                var userList = _userRepo.GetAll().ToList();

                tableDetails += $"<table class='table table-striped table-bordered responsive no-wrap' style='width:100%'  id='userList'> " +
                        $" <caption  font-size: 160%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                     {name}   </caption>" +
                       $"<thead>" +
                      $"<tr>" +
                      $"<th>Full Name</th>" +
                      $"<th>UserName</th>" +
                      $"<th>Email</th>" +
                      $"<th>Role</th>" +
                      $"<th>Address</th>" +
                      $"</tr>" +
                     $"</thead>" +
                     $"<tbody>";

                foreach (var user in userList)
                {
                    tableDetails += $"<tr>" +
                        $"<td>{user.FirstName + " " + user.MiddleName + " " + user.LastName}</td>" +
                         $"<td>{user.UserName}</td>" +
                        $"<td>{user.Email}</td>" +
                         $"<td>{user.Role}</td>" +
                         $"<td>{user.Address}</td>" +
                        $"</tr>";
                }
                tableDetails += $"</tbody>" +
                  $"</table>";
               
            }
            else if (name == "Sales Report")
            {
                dynamic salesList = null;
                if (start == null || end == null) {
                    start = DateTime.Now;
                    end = DateTime.Now;
                    salesList = _transactionRepo.GetAll().Where(a => a.PaymentStatus == "Accepted").ToList();
                }else
                {
                    salesList = _transactionRepo.GetAll().Where(a => a.PaymentStatus == "Accepted" && a.DateTimeStamps >= start && a.DateTimeStamps <= end).ToList();
                }

                tableDetails += $"<table class='table table-striped table-bordered responsive no-wrap' style='width:100%'  id='userList'> " +
                                $" <caption  font-size: 90%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                     {name}  {start.Value.Date} - {end.Value.Date} </caption>" +
                       $"<thead>" +
                      $"<tr>" +
                      $"<th>Username</th>" +
                      $"<th>Payment Terms</th>" +
                      $"<th>Total Price</th>" +
                     $"<th>Payment Status</th>" +
                      $"<th>Date</th>" +
                      $"<th>Delivery Date</th>" +
                      $"</tr>" +
                     $"</thead>" +
                     $"<tbody>";

                foreach (var sale in salesList)
                {
                    tableDetails += $"<tr>" +
                        $"<td>{sale.UserName}</td>" +
                         $"<td>{sale.PaymentTerms}</td>" +
                        $"<td>{sale.TotalPrice}</td>" +
                         $"<td>{sale.PaymentStatus}</td>" +
                         $"<td>{sale.DateTimeStamps}</td>" +
                            $"<td>{sale.DeliveryDate}</td>" +
                        $"</tr>";
                }
                tableDetails += $"</tbody>" +
                  $"</table>";

            }
            else if (name == "Products Report")
            {
                dynamic prodList = null;
             
                prodList = _prodRepo.GetAll().ToList();
             

                tableDetails += $"<table class='table table-striped table-bordered responsive no-wrap' style='width:100%'  id='userList'> " +
                        $" <caption  font-size: 160%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp                       {name}</caption>" +
                       $"<thead>" +
                      $"<tr>" +
                   
                      $"<th>Product</th>" +
                      $"<th>Price</th>" +
                       $"<th>Description</th>" +
                        $"<th>Stocks</th>" +
                      $"</tr>" +
                     $"</thead>" +
                     $"<tbody>";

                foreach (var product in prodList)
                {
                    tableDetails += $"<tr>" +
                     
                         $"<td>{product.ProductName}</td>" +
                        $"<td>{product.Price}</td>" +
                         $"<td>{product.Description}</td>" +
                           $"<td>{product.Stocks}</td>" +
                        $"</tr>";
                }
                tableDetails += $"</tbody>" +
                  $"</table>";

            }
            else if (name == "Top Customers")
            {
                List<TopCustomer> topCustomer = new List<TopCustomer>();
                dynamic transactionList = null;
                if(start == null || end == null) {
                    start = DateTime.Now;
                    end = DateTime.Now;
                    transactionList = _transactionRepo.GetAll().ToList();
                }else
                {

                    decimal totalAmount = 0;
                    foreach (var users in _userRepo.GetAll().ToList())
                    {
                        decimal totalSpentEach = 0;
                        int numOfTrans = 0;
                        foreach (var transaction in _transactionRepo.GetAll().Where(a => a.PaymentStatus == "Accepted" && a.DateTimeStamps >= start && a.DateTimeStamps <= end ).ToList())
                        {
                            if (users.UserName == transaction.UserName)
                            {
                                totalSpentEach += (decimal)transaction.TotalPrice;
                                totalAmount += (decimal)transaction.TotalPrice;
                                numOfTrans++;
                            }
                        }
                        topCustomer.Add(new TopCustomer
                        {
                            Spent = totalSpentEach,
                            TotalEarn = totalAmount,
                            FullName = users.FirstName + " " + users.LastName + " " + users.MiddleName,
                            Transactions = numOfTrans
                        }) ;
                    }
                }

                tableDetails += $"<table class='table table-striped table-bordered responsive no-wrap' style='width:100%'  id='userList'> " +
                                 $" <caption  font-size: 90%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                     {name}  {start.Value.Date} - {end.Value.Date} </caption>" +
                       $"<thead>" +
                      $"<tr>" +

                      $"<th>Full Name</th>" +
                      $"<th>Number of transaction</th>" +
                       $"<th>Spent</th>" +
                      $"</tr>" +
                     $"</thead>" +
                     $"<tbody>";
                var customerTop = topCustomer.OrderByDescending(a => a.Spent).ToList();
                foreach (var topCus in customerTop)
                {
                    tableDetails += $"<tr>" +

                         $"<td>{topCus.FullName}</td>" +
                        $"<td>{topCus.Transactions}</td>" +
                         $"<td>{topCus.Spent}</td>" +
                        $"</tr>";
                }
                tableDetails += $"</tbody>" +
                  $"</table>";

            }



            return Content(tableDetails);
        }

    }
}
