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
    public class DashboardController : Controller
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly INotificationRepository _notifRepo;
        private readonly IUserRepository _userRepo;
    private readonly IRequestRepository _requestRepo;
        public DashboardController(ITransactionRepository transactionRepo, INotificationRepository notifRepo, IUserRepository userRepo, IRequestRepository requestRepo)
        {
            _userRepo = userRepo;
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



            DashboardViewModel dashVM = new DashboardViewModel
            {
                IncomePerMonth = listOfIncomePerMonth,
                IncomePerWeek = listOfIncomePerWeek,
                IncomeToday = totalIncomeToday,
                NewTransactions = newTransactions
            };
            return View(dashVM);
        }

         
    }
}
