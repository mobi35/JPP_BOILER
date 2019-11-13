using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IHostingEnvironment _hosting;
        private readonly IUserRepository _userRepo;
        private readonly INotificationRepository _notifRepo;
        public AccountController(IHostingEnvironment hosting, IUserRepository userRepo, INotificationRepository notifRepo)
        {
            _hosting = hosting;
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
        public string base64Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Encode" + e.Message);
            }
        }


        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Message = "";
            if (ModelState.IsValid) {
                var getEmail = _userRepo.FindUser(a => a.Email == user.Email);
                var getUser = _userRepo.FindUser(a => a.UserName == user.UserName);
                if (getEmail != null)
                {
                    user.Message = "Email already exists";
                    return View("Create", user);
                }

                if (getUser != null)
                {
                    user.Message = "Username already exists";
                    return View("Create", user);
                }

                if (user.ConfirmPassword != user.Password)
                {
                    user.Message = "Password Doesn't Match";
                    return View("Create",user);
                }


                user.Status = "Activated";
                user.Password = base64Encode(user.Password);
                _userRepo.Create(user);

                _notifRepo.AddNotification("Welcome to JBoiler. You can update your account on the left",user.UserName);
                return View("List", GetList());
            }

            return View(user);

        }
        public IActionResult List()
        {
            
                var newRepo = _userRepo.GetAll().AsQueryable().ToList();
                foreach (var s in newRepo)
                {
                    s.isRead = true;
                    _userRepo.Update(s);
                }
          

            return View(GetList());
        }

     
        public IActionResult Message(User user)
        {
            return View(user);
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
            user.Password = base64Encode(user.Password);
            _userRepo.Update(user);
            return View("List", GetList());
        }

        public List<User> GetList()
        {
            List<User> user = new List<User>();
            var list = _userRepo.GetAll().AsQueryable().ToList();
            foreach (var l in list)
            {
               // l.isRead = true;
               // _userRepo.Update(l);
                user.Add(l);
            }
          
            return user;
        }


        [HttpGet]
        public IActionResult Update()
        {
            var userName = HttpContext.Session.GetString("UserName");
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
                user.Password = base64Encode(user.Password);
                _userRepo.Update(user);
                var userName = HttpContext.Session.GetString("UserName");
                var userFound = _userRepo.FindUser(a => a.UserName == userName);
                userFound.Message = "You have successfully updated your account";
                return View("Update", userFound);
            }

            return View(user);

        }

     

        public IActionResult Delete(int id)
        {
            var user = _userRepo.GetIdBy(id);
            _userRepo.Delete(user);
            return View("List", GetList());
        }

      
    }
}
