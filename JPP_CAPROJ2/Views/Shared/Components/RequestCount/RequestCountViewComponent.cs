using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using JPP_CAPROJ2.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Controllers
{
    public class RequestCountViewComponent : ViewComponent
    {
  
        private readonly IRequestRepository _requestRepo;

        public RequestCountViewComponent(IRequestRepository requestRepo)
        {

            _requestRepo = requestRepo;
        }

     
      
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var serviceCount = _requestRepo.GetAll().Where(a => a.isRead == false);
            return View((int)serviceCount.Count()) ;
        }
      

      
    }
}
