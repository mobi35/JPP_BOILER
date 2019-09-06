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
    public class RequestController : Controller
    {
        private readonly INotificationRepository _notifRepo;
        private readonly IUserRepository _userRepo;
private readonly IRequestRepository _requestRepo;
        public RequestController(INotificationRepository notifRepo, IUserRepository userRepo, IRequestRepository requestRepo)
        {
            _userRepo = userRepo;
            _notifRepo = notifRepo;
            _requestRepo = requestRepo;
        }
        
        [HttpPost]
        public IActionResult Create(Request request){
        
             var userName = HttpContext.Session.GetString("UserName");
              _notifRepo.AddNotification("1 new service request","admin");
               _notifRepo.AddNotification("Please wait for 2-3 Days for inspection.",userName);

                foreach(var worker in Workers()){
                   request.AssignedBy = worker.UserName;
                    break;
            }
                _requestRepo.Create(request);
            return RedirectToAction("ClientService","Service");
        }


         [HttpPost]
        public IActionResult CreateFixed(ServiceRequestViewModel requestVM){
         
           var userName = HttpContext.Session.GetString("UserName");
              _notifRepo.AddNotification("1 new service request","admin");
               _notifRepo.AddNotification("Please wait for 2-3 Days for inspection.",userName);
            foreach(var worker in Workers()){
                    requestVM.Requests.AssignedBy = worker.UserName;
                    break;
            }
               _requestRepo.Create(requestVM.Requests);
            return RedirectToAction("ClientService","Service");
        }

        public List<User> Workers(){
            List<User> userList = new List<User>();
            var users = _userRepo.GetAll();
            foreach(var user in users){
                if(user.Role == "worker"){
                    userList.Add(user);
                }
            }
            return userList.OrderByDescending(a => a.NumberOfTask).ToList();
        }

        public IActionResult List(){

            return View(GetList());
        }

        public IActionResult Billing(){
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
        [HttpGet]
         public IActionResult AcceptService(int id){
            var request = _requestRepo.GetIdBy(id);
            request.Status = "accepted";
             _requestRepo.Update(request);  
            return RedirectToAction("List","Request");
         }
    [HttpGet]
          public IActionResult RejectService(int id){
              var request = _requestRepo.GetIdBy(id);
            request.Status = "rejected";
             _requestRepo.Update(request);
             return RedirectToAction("List","Request");
         }    

          [HttpGet]
          public IActionResult PaidService(int id){
              var request = _requestRepo.GetIdBy(id);
              request.Status = "paid";
             _requestRepo.Update(request);
             return RedirectToAction("List","Request");
         }     

         public IActionResult WorkingRequest(){

             return View(GetList());
         }
    }
}
