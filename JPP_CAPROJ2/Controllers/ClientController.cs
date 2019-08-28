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
    public class ClientController : Controller
    {
        private readonly IUserRepository _userRepo;

        public ClientController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
          var userName =  HttpContext.Session.GetString("UserName");
           var userFound = _userRepo.FindUser(a => a.UserName == userName);
           return View(userFound);
        }
        public IActionResult Delete()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var userFound = _userRepo.FindUser(a => a.UserName == userName);
            _userRepo.Delete(userFound);
          return RedirectToAction("Logout", "Login");
        }

        public IActionResult Update(User user)
        {
            user.Message = "";
            if (ModelState.IsValid)
            {
                if (user.ConfirmPassword != user.Password)
                {
                    user.Message = "Password Doesn't Match";
                    return View("Update", user);
                }
                _userRepo.Update(user);
                return View("Index");
            }

            return View(user);
          

        }
    }
}
