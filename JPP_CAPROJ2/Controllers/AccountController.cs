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
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepo;
  private readonly INotificationRepository _notifRepo;
        public AccountController(IUserRepository userRepo, INotificationRepository notifRepo)
        {
            _userRepo = userRepo;
            _notifRepo = notifRepo;
        }
        [Route("/Account/Index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            
            var user = new User();
            user.Message = "";
            return View(user);
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Message = "";
            if (ModelState.IsValid) {
                if (user.ConfirmPassword != user.Password)
                {
                    user.Message = "Password Doesn't Match";
                    return View("Create",user);
                }
                _userRepo.Create(user);

                _notifRepo.AddNotification("Welcome to JBoiler. You can update your account on the left",user.UserName);
                return View("List", GetList());
            }

            return View(user);

        }
        public IActionResult List()
        {
           
            return View(GetList());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var user = _userRepo.GetIdBy(id);
            user.Message = "";
            return View(user);
        }
        public IActionResult Edit(User user)
        {

            _userRepo.Update(user);
            return View("List", GetList());
        }

        public List<User> GetList()
        {
            List<User> user = new List<User>();
            var list = _userRepo.GetAll();
            foreach (var l in list)
            {
                user.Add(l);
            }
            return user;
        }
        public IActionResult Delete(int id)
        {
            var user = _userRepo.GetIdBy(id);
            _userRepo.Delete(user);
            return View("List", GetList());
        }

      
    }
}
