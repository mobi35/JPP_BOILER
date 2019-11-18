    using JPP_CAPROJ2.Data.Model;

    using JPP_CAPROJ2.Data.Model.Interface;
using JPP_CAPROJ2.Models.ViewModel;
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

            public IActionResult ShowService(int id)
            {
            ServiceAndQuotation serviceAndQuotation = new ServiceAndQuotation
            {

                Service = _serviceRepo.GetIdBy(id),
                Quotation = _quotationRepo.GetAll().Where(a => a.ServiceID == id).ToList()

            };
                return View(serviceAndQuotation);
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
        
            [HttpPost]
            public IActionResult CreateNewQuotation(int id, string name, double price)
            {

            Quotations quote = new Quotations();
            quote.QuotationName = name;
            quote.Price = price;
            quote.ServiceID = id;
            _quotationRepo.Create(quote);

            ServiceAndQuotation serviceAndQuotation = new ServiceAndQuotation
            {

                Service = _serviceRepo.GetIdBy(id),
                Quotation = _quotationRepo.GetAll().Where(a => a.ServiceID == id).ToList()

            };

            return View("ShowService",serviceAndQuotation);
            }
            [HttpGet]
            public IActionResult UpdateQuotation(int id)
            {
            
            return View(_quotationRepo.GetIdBy(id));
            }
            
            [HttpPost]
           public IActionResult UpdateQuotation(Quotations quote) {

            _quotationRepo.Update(quote);
            ServiceAndQuotation serviceAndQuotation = new ServiceAndQuotation
            {

                Service = _serviceRepo.GetIdBy(quote.ServiceID),
                Quotation = _quotationRepo.GetAll().Where(a => a.ServiceID == quote.ServiceID).ToList()

            };
            return View("ShowService", serviceAndQuotation);

               }


           
            public IActionResult DeleteQuotation(int id)
            {
            var get = _quotationRepo.GetIdBy(id);
            _quotationRepo.Delete(get);
            ServiceAndQuotation serviceAndQuotation = new ServiceAndQuotation
            {

                Service = _serviceRepo.GetIdBy(get.ServiceID),
                Quotation = _quotationRepo.GetAll().Where(a => a.ServiceID == get.ServiceID).ToList()

            };
            return View("ShowService", serviceAndQuotation);

        }
        [HttpGet]
            public IActionResult QuotationService(int id){

            RequestService reqServ = new RequestService
            {
                Service = _serviceRepo.GetIdBy(id)
            };
            
                return View(reqServ);
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

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _serviceRepo.Create(service);
            return View("ServiceList",_serviceRepo.GetAll().ToList());
        }
        public IActionResult CreateService()
        {
            return View();
        }

        public IActionResult DeleteService(int id)
        {
            var service = _serviceRepo.GetIdBy(id);
            _serviceRepo.Delete(service);
            return View("ServiceList", _serviceRepo.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            return View(_serviceRepo.GetIdBy(id));
        }
        public IActionResult EditService(Service service)
        {
            _serviceRepo.Update(service);
            return View("ServiceList", _serviceRepo.GetAll().ToList());
        }

        public IActionResult ServiceList()
        {
            return View(_serviceRepo.GetAll().ToList());
        }



        }
    }
