using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using JPP_CAPROJ2.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Controllers
{
    public class RateNumber
    {

    }
    public class DashboardController : Controller
    {
        private readonly IFeedbackRepository _feedRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _prodRepo;
        private readonly ITransactionRepository _transactionRepo;
        private readonly INotificationRepository _notifRepo;
        private readonly IUserRepository _userRepo;
    private readonly IRequestRepository _requestRepo;
        public DashboardController(IFeedbackRepository feedRepo, IOrderRepository orderRepo, IProductRepository prodRepo, ITransactionRepository transactionRepo, INotificationRepository notifRepo, IUserRepository userRepo, IRequestRepository requestRepo)
        {
            _userRepo = userRepo;
            _feedRepo = feedRepo;
            _orderRepo = orderRepo;
            _prodRepo = prodRepo;
            _transactionRepo = transactionRepo;
            _notifRepo = notifRepo;
            _requestRepo = requestRepo;
        }
        
        public IActionResult Index(){
           
            List<double> listOfIncomePerMonth = new List<double>();
            for(int i = 1; i <= 12; i++) {
                double totalValue = 0;
            foreach (var transaction in _transactionRepo.GetAll())
            {
                    if (transaction.DateTimeStamps.Value.Month == i && transaction.PaymentStatus == "Accepted")
                    {

                        totalValue += transaction.TotalPrice;

                    }
            }
                listOfIncomePerMonth.Add(totalValue);

            }

         


            ///////// INCOME PER WEEk
            ///


            List<double> listOfIncomePerWeek = new List<double>();

            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            // If we started on Sunday, we should actually have gone *back*
            // 6 days instead of forward 1...
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
            }
            var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();

            foreach (var weekDates in dates)
            {
                double weekValues = 0;
                foreach (var transaction in _transactionRepo.GetAll())
                {
                    if (transaction.DateTimeStamps.Value.Date == weekDates.Date && transaction.PaymentStatus == "Accepted")
                    {
                        weekValues += transaction.TotalPrice;
                    }

                }
                listOfIncomePerWeek.Add(weekValues);
            }

            //// INCOME TODAY HEHE
            ///


            double totalIncomeToday = 0;
            foreach (var transaction in _transactionRepo.GetAll())
            {
                if (transaction.DateTimeStamps.Value.Date == DateTime.Now.Date && transaction.PaymentStatus == "Accepted")
                {
                    totalIncomeToday += transaction.TotalPrice;
                }

            }



            //// NEW TRANSACTIONS 5
            ///

            var newTransactions = _transactionRepo.GetAll().OrderByDescending(a => a.TransactionKey).Take(5).ToList();



          
            var topCustomer = new TopCustomerModel();
            List < TopCustomerModel > topCustomerList = new List<TopCustomerModel>();

            foreach (var user in _userRepo.GetAll().ToList()) { 
            decimal dec = 0;
            string label = "";
            foreach (var transRepo in _transactionRepo.GetAll().ToList())
            {

             if(user.UserName == transRepo.UserName && transRepo.PaymentStatus == "Accepted")
                    {
                        dec += (decimal)transRepo.TotalPrice;
                    }  
            }
                label = user.UserName;
                topCustomerList.Add(new TopCustomerModel
                {
                    Spents = dec,
                    UserName = label
                });
            }
            var listLabel = new List<string>();
            var listData = new List<decimal>();
            foreach (var tops in topCustomerList.OrderByDescending(a => a.Spents).Take(5).ToList() )
            {
                listLabel.Add(tops.UserName);
                listData.Add(tops.Spents);
            }

            var newList = new ListOfTopCustomerModel();

            newList.Spents = listData;
            newList.UserName = listLabel;
            var listOfOrders = _transactionRepo.GetAll().Where(a => a.PaymentStatus == "Accepted").ToList();


         
            List<TopProductModel> listOfProd = new List<TopProductModel>();

            foreach(var prod in _prodRepo.GetAll().ToList())
            {
                int sold = 0;
                foreach (var ordered in _orderRepo.GetAll().ToList())
                {
                   
                    if(prod.ProductName == ordered.ProductName && _transactionRepo.FindTransaction(a => a.TransactionKey == ordered.TransactionID).PaymentStatus == "Accepted")
                    {
                        sold++;
                    }
                }
                listOfProd.Add(new TopProductModel
                {
                    Bought = sold,
                    Product = prod.ProductName
                });
            }
            List<int> bought = new List<int>();
            List<string> product = new List<string>();

            foreach (var c in listOfProd)
            {
                bought.Add(c.Bought);
                product.Add(c.Product);
            }

            ListOfTopProductModel topProd = new ListOfTopProductModel
            {
                Bought = bought,
                Product = product
            };

            ListOfFeedbackModel listOfFeed = new ListOfFeedbackModel();
            List<int> f1 = new List<int>();
            List<int> f2 = new List<int>();
            List<int> f3 = new List<int>();
            List<int> f4 = new List<int>();
            List<int> f5 = new List<int>();

            int if1 = 0, if2 = 0, if3 = 0, if4 = 0, if5 = 0;
            foreach (var feed in _feedRepo.GetAll().ToList())
            {
                if (feed.Rate == 1)
                {
                    if1++;
                  
                }
                else if (feed.Rate == 2)
                {
                    if2++;
                }
                else if (feed.Rate == 3)
                {
                    if3++;
                }
                else if (feed.Rate == 4)
                {
                    if4++;
                }
                else if (feed.Rate == 5)
                {
                    if5++;
                }

            }
            listOfFeed.Title = new List<string> { "Very Bad", "Bad", "Neutral", "Good", "Very Good" };
            listOfFeed.Votes = new List<int> { if1, if2, if3, if4, if5 };
            DashboardViewModel dashVM = new DashboardViewModel
            {
                ListOfFeedbackModel = listOfFeed,
                ListOfTopProductModels = topProd,
                ListOfTopCustomerModels = newList,
                IncomePerMonth = listOfIncomePerMonth,
                IncomePerWeek = listOfIncomePerWeek,
                IncomeToday = totalIncomeToday,
                NewTransactions = newTransactions,
                ListOfUsers = _userRepo.GetAll().Where(a => a.Role == "worker").OrderByDescending(a => a.NumberOfTask).ToList()
            };


            //LIST OF USERS

            

            return View(dashVM);




            

        }

         
    }
}
