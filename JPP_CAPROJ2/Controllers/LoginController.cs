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
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepo;

        public LoginController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("UserName", "");
            Startup.IsSessionAvailable = false;
            return View("Index");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Register()
        {
            var user = new User();
            user.Message = "";
            return View(user);
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            user.Message = "";
            if (ModelState.IsValid)
            {
                if (user.ConfirmPassword != user.Password)
                {
                    user.Message = "Password Doesn't Match";
                    return View("Register", user);
                }
                _userRepo.Create(user);
                return View("Success");
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var search = _userRepo.GetAll();
            bool matched = false;
            var loginUser = new User();
            foreach (var usr in search)
            {
                if(user.UserName == usr.UserName && user.Password == usr.Password)
                {
                    loginUser = usr;
                    matched = true;
                    break;
                }else
                {
                    matched = false;
                }
            }

            if (matched)
            {
                HttpContext.Session.SetString("UserName", loginUser.UserName);
                HttpContext.Session.SetString("Role", loginUser.Role);
                Startup.IsSessionAvailable = true;
                if(loginUser.Role == "employee") { 
                return RedirectToAction("Index","Dashboard");
                }else if (loginUser.Role == "worker"){
                 return RedirectToAction("List","Request");
                }
                
                else
                {
                    return RedirectToAction("Index", "Client");
                }
            }
            else
            {
                return View("Index");
            }

         
        
        }
    }
}
