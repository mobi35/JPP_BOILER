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
    public class DashboardController : Controller
    {
        private readonly INotificationRepository _notifRepo;
        private readonly IUserRepository _userRepo;
private readonly IRequestRepository _requestRepo;
        public DashboardController(INotificationRepository notifRepo, IUserRepository userRepo, IRequestRepository requestRepo)
        {
            _userRepo = userRepo;
            _notifRepo = notifRepo;
            _requestRepo = requestRepo;
        }
        
        [HttpPost]
        public IActionResult Create(Request request){
            _requestRepo.Create(request);
            return RedirectToAction("Create","Service");
        }

        public IActionResult List(){
                
            return View(GetList());
        }

        public List<Request> GetList(){
            List<Request> req = new List<Request>();
            var allReq = _requestRepo.GetAll();

            foreach(var eachReq in allReq){
                req.Add(eachReq);
            }
            return req;
            
        }      
    }
}
