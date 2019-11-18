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
        private readonly IOrderRepository _orderedRepository;
        private readonly ITransactionRepository _transactionRepo;
        private readonly INotificationRepository _notifRepo;
        private readonly IUserRepository _userRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IRequestRepository _requestRepo;
        private readonly IQuotationRepository _quotation;
        public RequestController( IQuotationRepository quotation, IServiceRepository serviceRepo, IOrderRepository orderedRepository, ITransactionRepository transactionRepo,  INotificationRepository notifRepo, IUserRepository userRepo, IRequestRepository requestRepo)
        {
            _userRepo = userRepo;
            _orderedRepository = orderedRepository;
            _transactionRepo = transactionRepo;
            _quotation = quotation;
            _serviceRepo = serviceRepo;
            _notifRepo = notifRepo;
            _requestRepo = requestRepo;
        }

        public IActionResult GetQuotation(int service)
        {
            var quote = _quotation.GetAll().Where(a => a.ServiceID == service).ToList();
            string quotationStyle = "";
            int number = 0;
            quotationStyle += $"<input type = 'hidden' id='numberOfQuotation' name = 'numberOfQuotation' value = '{quote.Count()}' /> ";
            foreach (var q in quote)
            {
                number++;
                quotationStyle += $"" +
                  
                    $" <input type = 'hidden' id = 'l{number}' name='l{number}' value='{q.QuotationName}' />  <input  type = 'checkbox' id='q{number}' value='{q.Price}' name = 'q{number}' > {q.QuotationName}  <br> " +
                  
                    $"";
            }
            return Content(quotationStyle);
        }

        [HttpPost]
        public IActionResult Create(Request request, string serviceType, int serviceId)
        {

            if (request.AvailableDate <= DateTime.Now)
            {
                request.Message = "Please only select future dates.";
                return View("ViewError", request);
            }
            else  if(Workers().Count() == 0){
              request.Message = "Sorry no worker's at the moment. Please wait for the admin to create new workers";
              
                 return View("ViewError",request);
                }
            TimeSpan? dateRemainingDeliver = request.AvailableDate - DateTime.Now;
             var userName = HttpContext.Session.GetString("UserName");
              _notifRepo.AddNotification("1 new service request","admin");
               _notifRepo.AddNotification($"Please wait for {(int)dateRemainingDeliver.Value.TotalDays} day/s for inspection.",userName);
                foreach(var worker in Workers()){
                   request.AssignedBy = worker.UserName;
                     worker.NumberOfTask += 1;
                    _userRepo.Update(worker);
                    break;
               }

            request.Address = _userRepo.FindUser(a => a.UserName == userName).Address;
            request.Requirements = request.Description;
               request.Description = serviceType;
               request.Status = "for inspection";
            request.Price = _serviceRepo.GetIdBy(serviceId).Price;
            request.ServiceId = serviceId;
            request.UserName = userName;
            _requestRepo.Create(request);

            Transaction serviceTransaction = new Transaction();
          
            serviceTransaction.BankAccount = "COD";
            serviceTransaction.PaymentStatus = "Pending";
            serviceTransaction.UserName = userName;


            serviceTransaction.PaymentTerms = "Service";

            serviceTransaction.DateTimeStamps = DateTime.Now;
            serviceTransaction.ServiceType = serviceType;
            serviceTransaction.ServiceID = serviceId;
            serviceTransaction.RequestId = _requestRepo.GetAll().LastOrDefault().RequestId;
            serviceTransaction.TotalPrice = _serviceRepo.GetIdBy(serviceId).Price;
            _transactionRepo.Create(serviceTransaction);
           
            request.Message = $"You have successfully requested for a service. Please wait {(int)dateRemainingDeliver.Value.TotalDays} day/s as the inspector will look at your unit";
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
                req.Status = "for inspection";
               _requestRepo.Create(requestVM.Requests);
             req.Message = "You have successfully requested for a service. Please wait for 2-3 days as the inspector will look at your unit";
                 return View("ViewError",req);
        }

        public IActionResult FuckService()
        {
            double totalAmount = 0;
            string stringszz = "";


            OrderedProducts defaultOrder = new OrderedProducts();
            double mainPrice = Double.Parse(Request.Form["etoUngPriceDati"].ToString());
            
            defaultOrder.Price = mainPrice;
            totalAmount += mainPrice;
            defaultOrder.ProductName = Request.Form["description"].ToString();
            defaultOrder.Quantity = 1;
            defaultOrder.DateOrdered = DateTime.Now;
            int serviceId = Int32.Parse(Request.Form["sid"].ToString());
            int reqId = Int32.Parse(Request.Form["id"].ToString());
            defaultOrder.TransactionID = _transactionRepo.FindTransaction(a => a.RequestId == reqId).TransactionKey;
            _orderedRepository.Create(defaultOrder);


            for (int i = 1; i <= Int32.Parse( Request.Form["numberOfQuotation"].ToString() ) ; i++)
            {
                string serachable = "q" + i;
                if (Request.Form.Keys.Any(k => k == serachable))
                {

                OrderedProducts orp = new OrderedProducts();
                 double singlePrice =   Double.Parse(Request.Form["q" + i].ToString());
                 orp.Price = singlePrice;
                 totalAmount += singlePrice;
                orp.ProductName = Request.Form["l" + i].ToString();
                orp.Quantity = 1;
                orp.DateOrdered = DateTime.Now;
                int service = Int32.Parse(Request.Form["sid"].ToString());
                orp.TransactionID = _transactionRepo.FindTransaction(a => a.RequestId == reqId).TransactionKey;
                _orderedRepository.Create(orp);
                }
                //  stringszz += $" {Request.Form["sid"]} :  {Request.Form["l" + i]}  {Request.Form["q" + i]}  <br>";
            }


            var request = _requestRepo.GetIdBy(Int32.Parse(Request.Form["id"].ToString()));
            request.Status = "accepted";
            request.Price = (float)totalAmount;
            var trans = _transactionRepo.GetIdBy(defaultOrder.TransactionID);
            trans.PaymentStatus = "On-going";
            trans.TotalPrice = totalAmount;
            trans.ImageString = null;
            _transactionRepo.Update(trans);
            _requestRepo.Update(request);

            return Content("total" + totalAmount);
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

        [HttpPost]
        public IActionResult ChangeWorker(int id, string name)
        {
            if (name != null) { 
            var request = _requestRepo.GetIdBy(id);
            request.AssignedBy = name;
            var user = _userRepo.FindUser(a => a.UserName == name);
            user.NumberOfTask -= 1;
            _userRepo.Update(user);
            _requestRepo.Update(request);
            }
            return View("List", AdminList());
        }

        [HttpGet]
        public IActionResult CompleteService(int id)
        {
           var service = _requestRepo.GetIdBy(id);
            service.Status = "Completed";
       
            var last = 1;
            try
            {
                last = _transactionRepo.GetAll().LastOrDefault().TransactionKey;
                last++;
            }
            catch (Exception e)
            {

            }

            OrderedProducts orderedProd = new OrderedProducts();

            orderedProd.Price = service.Price;
            orderedProd.ProductName = service.Description + " service";
            orderedProd.Quantity = 1;
            orderedProd.TransactionID = last;
            _orderedRepository.Create(orderedProd);
         
            _requestRepo.Update(service);

            _notifRepo.AddNotification($"Your service has already been completed. Thank you for choosing us.", service.UserName);
            return View("ServiceCompleted");
        }

        

     
        [HttpGet]
        public IActionResult RejectQuotation(int id)
        {
           var user =  _requestRepo.GetIdBy(id);
            user.Status = "rejected";
            _notifRepo.AddNotification($"Your request for viewing has been rejected. ", user.UserName);
            return View("List",GetList());
        }
        public IActionResult ServiceCompleted()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CanceledService(int id)
        {
            var service = _requestRepo.GetIdBy(id);
            service.Status = "Canceled";
            _notifRepo.AddNotification($"Your service has already canceled. ", service.UserName);
            return View("List",GetList());
        }

        [HttpGet]
        public IActionResult CustomerCancelService(int id)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var service = _requestRepo.GetIdBy(id);
            service.Status = "Canceled";
            _notifRepo.AddNotification($"You cancelled your request", service.UserName);
           
            var allRequest = _requestRepo.GetAll();
            List<Request> requestList = new List<Request>();
            foreach (var request in allRequest)
            {
                if (request.UserName == userName)
                    requestList.Add(request);
            }
            return View("EmployeeService", requestList);
        }

        public IActionResult List(){
            var role = HttpContext.Session.GetString("Role");
           
            if (role == "employee")
            {
                return View(AdminList());
            }
            else { 
            return View(GetList());
            }
        }

        public IActionResult Billing(){
            return View(GetList());
        }

        public List<Request> GetList(){
            var userName = HttpContext.Session.GetString("UserName");
            List<Request> req = new List<Request>();
            var allReq = _requestRepo.GetAll().AsQueryable().ToList();

            foreach(var eachReq in allReq){
                if (eachReq.AssignedBy == userName) { 
                eachReq.isRead = true;
                _requestRepo.Update(eachReq);
                req.Add(eachReq);
                }
            }
            return req;
            
        }

        public List<Request> AdminList()
        {
          
            var allReq = _requestRepo.GetAll().AsQueryable().ToList();
          
            return allReq;

        }



        [HttpPost]
         public IActionResult AcceptService(int id, float price,double c1, double c2, double c3, double c4, double c5, double c6, double c7, double c8, double c9, string description, double prodPrice)
        {
            double totalAmount = price;

            OrderedProducts defaultOrder = new OrderedProducts();
            defaultOrder.Price = price;
            defaultOrder.ProductName = description;
            defaultOrder.Quantity = 1;
            defaultOrder.DateOrdered = DateTime.Now;
            defaultOrder.TransactionID = _transactionRepo.FindTransaction(a => a.ServiceID == id).TransactionKey;
            _orderedRepository.Create(defaultOrder);

           

            if (c9 != 0)
            {
               
            }



           
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
