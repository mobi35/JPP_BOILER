using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JPP_CAPROJ2.Models;
using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;

namespace JPP_CAPROJ2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _prodRep;
        private readonly ITransactionRepository _transactionRepo;

        public HomeController(IProductRepository prodRep, ITransactionRepository transactionRepo)
        {
            _prodRep = prodRep;
           _transactionRepo = transactionRepo;
        }
        public IActionResult Index()
        {

            var listOfTransaction = _transactionRepo.GetAll().AsQueryable().ToList();

            foreach (var list in listOfTransaction)
            {
                if (list.PaymentStatus == "pending" && DateTime.Now > list.DateTimeStamps.Value.AddDays(15).Date  )
                {
                    list.PaymentStatus = "Rejected";
                    _transactionRepo.Update(list);
                }
            }

            return View(GetProducts());
        }

        public IEnumerable<Product> GetProducts()
        {
           return _prodRep.GetAll().Take(9);
        }

        public IActionResult Privacy()
        {
            return View();
        }

 public IActionResult About()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
