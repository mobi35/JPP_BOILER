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
    public class UserCountViewComponent : ViewComponent
    {
  
        private readonly IUserRepository _userRepo;

        public UserCountViewComponent(IUserRepository userRepo)
        {

            _userRepo = userRepo;
        }

     
      
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var userCount = _userRepo.GetAll().Where(a => a.isRead == false);
            return View((int)userCount.Count()) ;
        }
      

      
    }
}
