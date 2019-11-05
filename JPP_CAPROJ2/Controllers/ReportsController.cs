using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
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
        private readonly IUserRepository _userRepo;

        public ReportsController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
     

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ReportThis(string name)
        {
            return new ViewAsPdf(name);
        }

        public IActionResult GetThis(string name)
        {
            string reportString = $"<h1>{name}" + 
                $"</h1>" +
                $"<table id='userList'>" +
                $"<thead>" +
                $"<tr>" +
                $"<th>Heads</th>" +
                $"<th>Down</th>" +
                $"</tr>" +
                $"</thead>" +

                 $"<tbody>" +
                $"<tr>" +
               
                $"<td>" +
                $"Boo</td>" +
                $"<td>Rat" +
                $"</td>" +
                $"</tr>" +
                $"</tbody>" +
                $"</table>" +
                $"";

            return Content(reportString);
        }

    }
}
