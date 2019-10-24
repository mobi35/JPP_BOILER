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

        public HomeController(IProductRepository prodRep)
        {
            _prodRep = prodRep;
        }
        public IActionResult Index()
        {
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
