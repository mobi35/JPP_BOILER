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

            DashboardViewModel dashVM = new DashboardViewModel
            {
                IncomePerMonth = listOfIncomePerMonth
            };
            return View(dashVM);
        }

         
    }
}
