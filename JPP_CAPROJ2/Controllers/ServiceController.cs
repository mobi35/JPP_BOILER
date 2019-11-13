using JPP_CAPROJ2.Data.Model;

using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IQuotationRepository _quotationRepo;
        private readonly IServiceRepository _serviceRepo;
        private readonly IRequestRepository _requestRepo;

        public ServiceController(IQuotationRepository quotationRepo, IServiceRepository serviceRepo, IRequestRepository requestRepo)
        {
            _quotationRepo = quotationRepo;
            _serviceRepo = serviceRepo;
            _requestRepo = requestRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View(GetList());
        }
        public IActionResult Create()
        {
            
            return View(_quotationRepo.GetAll().ToList());
        }
        [HttpPost]
        public IActionResult Create(Service service)
        {
            service.Message = "";
            if (ModelState.IsValid)
            {
                _serviceRepo.Create(service);
                return View("Services", GetList());
            }
            return View(service);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            var user = _serviceRepo.GetIdBy(id);
            user.Message = "";
            return View(user);
        }
        public IActionResult Update(Service service)
        {

            _serviceRepo.Update(service);
            return View("Services", GetList());
        }


        public List<Service> GetList()
        {
            List<Service> service = new List<Service>();
            var list = _serviceRepo.GetAll();
            foreach (var l in list)
            {
                service.Add(l);
            }
            return service;
        }

        public IActionResult Delete(int id)
        {
           var service = _serviceRepo.GetIdBy(id);
            _serviceRepo.Delete(service);
            return View("Services", GetList());
        }
        
        [HttpGet]
        public IActionResult QuotationService(string id){
            Startup.whatService = id;
            return View();
        }

          public IActionResult QuotationService(){
            return View();
         }

         public IActionResult ClientService(){
             return View(GetList());
         }

         public IActionResult FixedService(){

             return View();
         }

        [HttpGet]
          public IActionResult FixedService(int id){
              var serviceVM = new ServiceRequestViewModel{
                  Services = _serviceRepo.GetIdBy(id)
              };
        
             return View(serviceVM);
         }
        

             
        public IActionResult DeleteQuotation(int id)
        {
            _quotationRepo.Delete(_quotationRepo.GetIdBy(id));
            return View("Create", _quotationRepo.GetAll().ToList());
        }
        [HttpPost]
        public IActionResult CreateQuotation(string title, int price,  string serviceType)
        {
            Quotations quotation = new Quotations();

            quotation.Price = price;
            quotation.QuotationName = title;
            quotation.ServiceName = serviceType;

            _quotationRepo.Create(quotation);
            return View("Create",_quotationRepo.GetAll().ToList());
        }



    }
}
