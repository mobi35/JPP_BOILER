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
        public IActionResult Create(Request request, string serviceType){

            if (request.AvailableDate <= DateTime.Now)
            {
                request.Message = "Please only select future dates.";
                return View("ViewError", request);
            }
            else  if(Workers().Count() == 0){
              request.Message = "Sorry no worker's at the moment. Please wait for the admin to create new workers";
              
                 return View("ViewError",request);
                }
             var userName = HttpContext.Session.GetString("UserName");
              _notifRepo.AddNotification("1 new service request","admin");
               _notifRepo.AddNotification("Please wait for 2-3 Days for inspection.",userName);

              
                foreach(var worker in Workers()){
                   request.AssignedBy = worker.UserName;
                     worker.NumberOfTask += 1;
                    _userRepo.Update(worker);
                    break;
               }
               request.Description = "";
               request.Status = "for viewing";
            request.UserName = userName;
                _requestRepo.Create(request);
            request.Message = "You have successfully requested for a service. Please wait for 2-3 days as the inspector will look at your unit";
              
                 return View("ViewError",request);
        }
      
        public IActionResult ViewError(Request request){
            return View(request);
        }

         [HttpPost]
        public IActionResult CreateFixed(ServiceRequestViewModel requestVM){
            Request req = new Request();
            req =requestVM.Requests;
            req.Message = "Sorry no worker's at the moment. Please wait for the admin to create new workers";
          if(Workers().Count() == 0){
                   return View("ViewError",req);
                }
           var userName = HttpContext.Session.GetString("UserName");
              _notifRepo.AddNotification("1 new service request","admin");
               _notifRepo.AddNotification("Please wait for 2-3 Days for inspection.",userName);
               
            foreach(var worker in Workers()){
                    requestVM.Requests.AssignedBy = worker.UserName;
                    worker.NumberOfTask += 1;
                    _userRepo.Update(worker);
                    break;
            }
               req.Description = "";
                req.Status = "for viewing";
               _requestRepo.Create(requestVM.Requests);
             req.Message = "You have successfully requested for a service. Please wait for 2-3 days as the inspector will look at your unit";
                 return View("ViewError",req);
        }

        public List<User> Workers(){
            List<User> userList = new List<User>();
            var users = _userRepo.GetAll();
            foreach(var user in users){
                if(user.Role == "worker"){
                    userList.Add(user);
                }
            }
            return userList.OrderBy(a => a.NumberOfTask).ToList();
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
        [HttpPost]
         public IActionResult AcceptService(int id, float price){
            var request = _requestRepo.GetIdBy(id);
            request.Status = "accepted";
            request.Price = price;
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
        
        [HttpPost]
         public IActionResult ConfirmViewing(int id, string worker, int priceQuote){
            var getRequest = _requestRepo.FindRequest(a => a.RequestId == id);
            getRequest.Price = priceQuote;
            getRequest.Description += $": Workers : {worker} - PRICE : {priceQuote}";  
            getRequest.Status = "for payment";
            _requestRepo.Update(getRequest);          
             return View("WorkingRequest", GetWorkerList());
         }     

        
        public List<Request> GetWorkerList(){
         var userName = HttpContext.Session.GetString("UserName");
                List<Request> req = new List<Request>();
                 foreach(var each in GetList()){
                     if(userName == each.AssignedBy){
                        req.Add(each);
                     }
                 }
             return req;
        }
        
        public IActionResult FetchData(int id){
                var request = _requestRepo.GetIdBy(id);

                return Content($"{request.Description}");
        }
         public IActionResult WorkingRequest(){
               return View( GetWorkerList());
         }

         public IActionResult PaymentRequest(){
             return View(GetList());
         }

         public IActionResult PaidRequest(){
             return View(GetList());
         }

         public IActionResult PendingRequest(){
             return View(GetList());
         }

         public IActionResult PayRequest(int id , string accountName, string accountNumber){
               var getRequest = _requestRepo.FindRequest(a => a.RequestId == id);
            getRequest.Status = "paid";
            getRequest.IsPaid = true;
            getRequest.AccountName = accountName;
            getRequest.AccountNumber = accountNumber;
            _requestRepo.Update(getRequest);          
             return View("WorkingRequest", GetWorkerList());
         }

        public IActionResult EmployeeService()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var allRequest = _requestRepo.GetAll();
            List<Request> requestList = new List<Request>();
            foreach (var request in allRequest)
            {
                if (request.UserName == userName)
                    requestList.Add(request);
            }
            return View(requestList);
        }

        
    }
}
