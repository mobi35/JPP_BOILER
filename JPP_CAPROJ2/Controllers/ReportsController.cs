using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IUserRepository _userRepo;

        public ReportsController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
     
        public IActionResult Index()
        {
            
            return View();
        }

     
      
    }
}
