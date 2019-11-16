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
        private readonly IRequestRepository _requestRepo;
        private readonly IOrderRepository _orders;
        private ITransactionRepository _transactionRepo;

        public ReportsController(IRequestRepository requestRepo ,IHostingEnvironment hosting, IUserRepository userRepo, INotificationRepository notificationRepo, IOrderRepository orders, ITransactionRepository transactionRepo, IProductRepository prodRepo, ICartRepository cartRepo)
        {
            _prodRepo = prodRepo;
            _cartRepo = cartRepo;
            _hosting = hosting;
            _userRepo = userRepo;
            _requestRepo = requestRepo;
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
                int masterListCount = 0;
                foreach (var user in userList)
                {
                    masterListCount++;
                    tableDetails += $"<tr>" +
                        $"<td>{user.FirstName + " " + user.MiddleName + " " + user.LastName}</td>" +
                         $"<td>{user.UserName}</td>" +
                        $"<td>{user.Email}</td>" +
                         $"<td>{user.Role}</td>" +
                         $"<td>{user.Address}</td>" +
                        $"</tr>";
                }
                tableDetails += $" <tr>  <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td>  <td>Total Users</td> <td>{masterListCount}</td>  </tr> </tbody>" +
                  $"</table>";
               
            }
            else if (name == "Sales Report")
            {
                dynamic salesList = null;
                if (start == null || end == null) {
                    start = DateTime.Now;
                    end = DateTime.Now;
                    salesList = _transactionRepo.GetAll().Where(a => a.PaymentStatus == "Completed").ToList();
                }else
                {
                    salesList = _transactionRepo.GetAll().Where(a => a.PaymentStatus == "Completed" && a.DateTimeStamps >= start && a.DateTimeStamps <= end).ToList();
                }

                tableDetails += $"<table class='table table-striped table-bordered responsive no-wrap' style='width:100%'  id='userList'> " +
                                $" <caption  font-size: 90%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                     {name}  {start.Value.Date.ToString("d")} - {end.Value.Date.ToString("d")} </caption>" +
                       $"<thead>" +
                      $"<tr>" +
                         $"<th>Transaction ID</th>" +
                           $"<th>List of orders</th>" +
                      $"<th>Full name</th>" +
                      $"<th>Total Price</th>" +
                    
                      $"<th>Paid On</th>" +
                    
                      $"</tr>" +
                     $"</thead>" +
                     $"<tbody>";
                double salesTotal = 0;
                foreach (var sale in salesList)
                {


                    string tKey = String.Format("{0:D5}", sale.TransactionKey);
                    salesTotal += sale.TotalPrice;
                    tableDetails += $"<tr>" +
                         $"<td>T{tKey}</td><td>";

                    foreach (var x in _orders.GetAll().Where(a => a.TransactionID == sale.TransactionKey).ToList())
                    {
                        tableDetails += $"<p>{x.ProductName } : {x.Price} </p>";
                    }
                    tableDetails +=
                       $"</td><td>{_userRepo.FindUser(a => a.UserName == sale.UserName).FirstName  } {_userRepo.FindUser(a => a.UserName == sale.UserName).MiddleName }  {_userRepo.FindUser(a => a.UserName == sale.UserName).LastName } </td>" +
                      
                        $"<td>{sale.TotalPrice.ToString("N")}</td>" +
                       
                         $"<td>{sale.TransactionCompletion}</td>" +
                        
                        $"</tr>";
                }
                tableDetails += $"" +
                    $"<tr>   <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td>      <td >Total Earned: </td> <td>P{salesTotal.ToString("N")}</td>  </tr>" +
                    $"</tbody>" +
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
                int totalProduct = 0;
                foreach (var product in prodList)
                {
                    totalProduct++;
                    tableDetails += $"<tr>" +
                     
                         $"<td>{product.ProductName}</td>" +
                        $"<td>{product.Price}</td>" +
                         $"<td>{product.Description}</td>" +
                           $"<td>{product.Stocks}</td>" +
                        $"</tr>";
                }
                tableDetails += $" <tr>  <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td>  <td>Total Number of Product : </td> <td> {totalProduct }</td> </tr> </tbody>" +
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
                    foreach (var users in _userRepo.GetAll().Where(a => a.Role == "customer").ToList())
                    {
                        decimal totalSpentEach = 0;
                        int numOfTrans = 0;
                        foreach (var transaction in _transactionRepo.GetAll().Where(a => a.PaymentStatus == "Completed" && a.DateTimeStamps >= start && a.DateTimeStamps <= end ).ToList())
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
                                 $" <caption  font-size: 90%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                     {name}  {start.Value.Date.ToString("d")} - {end.Value.Date.ToString("d")} </caption>" +
                       $"<thead>" +
                      $"<tr>" +

                      $"<th>Full Name</th>" +
                      $"<th>Number of transaction</th>" +
                       $"<th>Spent</th>" +
                      $"</tr>" +
                     $"</thead>" +
                     $"<tbody>";
                var customerTop = topCustomer.OrderByDescending(a => a.Spent).ToList();
                double userSpents = 0;
                foreach (var topCus in customerTop)
                {
                    userSpents += (double)topCus.Spent;
                    tableDetails += $"<tr>" +

                         $"<td>{topCus.FullName}</td>" +
                        $"<td>{topCus.Transactions}</td>" +
                         $"<td>P{topCus.Spent.ToString("N")}</td>" +
                        $"</tr>";
                }
                tableDetails += $"<tr>  <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td>  <td>Total Spents </td>  <td> P{userSpents.ToString("N")} </td>  </tr>  </tbody>" +
                  $"</table>";

            }else if (name == "Lead Report")
            {
                var requestList = _requestRepo.GetAll().ToList();

                if (start != null && end != null)
                    requestList.Where(a => a.DateCompleted >= start && a.DateCompleted <= end).ToList();

                  tableDetails += $"<table class='table table-striped table-bordered responsive no-wrap' style='width:100%'  id='userList'> " +
                                $" <caption  font-size: 90%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                     {name}  {start.Value.Date.ToString("d")} - {end.Value.Date.ToString("d")} </caption>" +
                      $"<thead>" +
                     $"<tr>" +
                     $"<th>Lead Number</th>" +
                     $"<th>Customer Name</th>" +
                      $"<th>Service Requested</th>" +
                       $"<th>Worker Responsible</th>" +
                         $"<th>Inspection Date</th>" +
                           $"<th>Date Completed</th>" +
                             $"<th>Status</th>" +
                     $"</tr>" +
                    $"</thead>" +
                    $"<tbody>";
            
                double requests = 0;
                foreach (var request in requestList)
                {
                    string tKey = String.Format("{0:D5}", request.RequestId);
                    requests++;
                        tableDetails += $"<tr>" +
                         $"<td>R{tKey}</td>" +
                        $"<td>{request.UserName}</td>" +
                         $"<td>{request.Description}</td>" +
                            $"<td>{request.AssignedBy}</td>" +
                                  $"<td>{request.Status}</td>" +
                                   $"<td>P{request.AvailableDate}</td>" +
                              $"<td>{request.DateCompleted}</td>" +

                        $"</tr>";
                }
                tableDetails += $"<tr> <td> &nbsp</td>  <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td> <td> &nbsp</td>  <td>Total Request </td>  <td> {requests} </td>  </tr>  </tbody>" +
                  $"</table>";

            }
            else if (name == "Profitable Service")
            {
                var orderedProducts = _orders.GetAll().Where(a => a.ProductID == 0).GroupBy(a => a.ProductName)
                    .Select(l => new { 
                        Key = l.Key,
                        Product = l.FirstOrDefault().ProductName,
                        Sum = l.Sum(a => a.Price)
                    }).OrderByDescending(a => a.Sum)
                    .ToList();

          

                    tableDetails += $"<table class='table table-striped table-bordered responsive no-wrap' style='width:100%'  id='userList'> " +
                            $" <caption  font-size: 90%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                     {name}  {start.Value.Date.ToString("d")} - {end.Value.Date.ToString("d")} </caption>" +
                  $"<thead>" +
                 $"<tr>" +
                  $"<th>Rank</th>" +
                 $"<th>Product</th>" +
                 $"<th>Total</th>" +
                 
                 $"</tr>" +
                $"</thead>" +
                $"<tbody>";
                int rank = 0;
                double totalOrdered = 0;
                foreach (var order in orderedProducts)
                {
                    rank++;
                    totalOrdered += order.Sum;
                            tableDetails += $"<tr>" +
                          $"<td>{rank}</td>" +
                                $"<td>{order.Product}</td>" +
                               $"<td>P{order.Sum.ToString("N")}</td>" +
                               $"</tr>";
                           
                }
                tableDetails += $"<tr>  <td> &nbsp</td>  <td>Total Earned </td>  <td> P{totalOrdered.ToString("N")} </td>  </tr>  </tbody>" +
                  $"</table>";
            }
            else if (name == "Project Progress")
            {

                var projectProgress = _transactionRepo.GetAll().ToList();

                if (start != null && end != null)
                    projectProgress.Where(a => a.DateTimeStamps >= start && a.DateTimeStamps <= end).ToList();

                    tableDetails += $"<table class='table table-striped table-bordered responsive no-wrap' style='width:100%'  id='userList'> " +
                         $" <caption  font-size: 90%;'> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp                     {name}  {start.Value.Date.ToString("d")} - {end.Value.Date.ToString("d")} </caption>" +
               $"<thead>" +
              $"<tr>" +
               $"<th>Transaction Key</th>" +
              $"<th>Payment Status</th>" +
              $"<th>UserName</th>" +
                 $"<th>Description</th>" +
                $"<th>Price</th>" +
              $"</tr>" +
             $"</thead>" +
             $"<tbody>";
             
                double totalPrice = 0;
                foreach (var project in projectProgress)
                {
                    string tKey = String.Format("{0:D5}", project.TransactionKey);
                    totalPrice += project.TotalPrice;
                    tableDetails += $"<tr>" +
                          
                    $"<td>P{tKey}</td>" +
                       $"<td>{project.PaymentStatus}</td>" +
                            $"<td>{project.UserName}</td>";

                    if (project.ServiceType == null)
                    {
                        tableDetails += "<td>"+ project.ServiceType + "</td>";
                    }else
                    {
                        tableDetails += "<td>Products Ordered</td>";
                    }
                    tableDetails +=
                      $"<td>P{project.TotalPrice}</td>" +
                       $"</tr>";

                }
                tableDetails += $"<tr>  <td> &nbsp</td>   <td> &nbsp</td> <td> &nbsp</td>  <td>Total Earned </td>  <td> P{totalPrice.ToString("N")} </td>  </tr>  </tbody>" +
                  $"</table>";

            }



            return Content(tableDetails);
        }

    }
}
