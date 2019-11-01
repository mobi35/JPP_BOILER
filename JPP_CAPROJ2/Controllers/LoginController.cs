using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using JPP_CAPROJ2.Utilities;
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
            return View("Index", new User { });
        }
        public IActionResult Index()
        {
            return View(new User { });
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

        public string base64Decode2(string sData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(sData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
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

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(User user)
        {
            Email email = new Email();

            string randomCharEx = Guid.NewGuid().ToString("n").Substring(0, 10);
            string EmailMessage = "Please click this link to recover your account " +
                "https://localhost:44358/Login/RecoverChangePassword?id=" + randomCharEx +
                "  .Your Email is " + user.Email;
            email.EmailSend(EmailMessage, user.Email);
            HttpContext.Session.SetString("SecurityCode", randomCharEx);
            HttpContext.Session.SetString("Email", user.Email);
            return Content($"Hi {user.Email}! Please check your email to recover your account");
            
        }

        [HttpPost]
        public IActionResult RecoverChangePassword(User userAccount)
        {
     
                if (userAccount.Password == userAccount.ConfirmPassword)
                {
               var email = HttpContext.Session.GetString("Email");

                var user = _userRepo.FindUser(a => a.Email == email);
                user.Password = userAccount.Password;
                _userRepo.Update(user);
                return View("Index",new User { Message = "Password successfully changed." });
                }
            
            userAccount.Message = "Password Don't Match";
            return View(userAccount);
        }

        [HttpGet]
        public IActionResult RecoverChangePassword(string id)
        {
            var securityCode = HttpContext.Session.GetString("SecurityCode");
            if (securityCode != id)
            {
                return Content("Wrong ID");
            }

            return View(new User { });
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
                  Email email = new Email();

            string randomCharEx = Guid.NewGuid().ToString("n").Substring(0, 10);
            string EmailMessage = "Please click this link to recover your account " +
                "https://localhost:44358/Login/ActivateAccount?id=" + randomCharEx +
                "  .Your Email is " + user.Email;
            email.EmailSend(EmailMessage, user.Email);
            HttpContext.Session.SetString("SecurityCode", randomCharEx);
            HttpContext.Session.SetString("UserName", user.UserName);
                user.Password = base64Encode(user.Password);
                user.Status = "Pending";
                _userRepo.Create(user);
                return View("Success");
            }

            return View(user);
        }

        public IActionResult ActivateAccount(string id)
        {
            var secCode = HttpContext.Session.GetString("SecurityCode");
          var userName =  HttpContext.Session.GetString("UserName");
            if (secCode == id)
            {
                var user = _userRepo.FindUser(a => a.UserName == userName);
                user.Status = "Activated";
                _userRepo.Update(user);
                return View("Index", new User { Message = "Your account has been activated." });
            }
            else
            {
                return View("Index", new User { Message = "Wrong Code. Please try again" });
            }
           
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var search = _userRepo.GetAll();
            bool matched = false;
            var loginUser = new User();
            foreach (var usr in search)
            {
                if(user.UserName == usr.UserName && user.Password == base64Decode2(usr.Password))
                {
                    loginUser = usr;
                    matched = true;
                    break;
                }else
                {
                    matched = false;
                }
            }

          

            if (matched && loginUser.Status == "Activated")
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
            else if(matched && loginUser.Status != "Activated")
            {
                return View("Index", new User { Message = "Your account has been locked." });
            }else
            {
                return View("Index", new User { Message = "Wrong Information" });
            }

         
        
        }
    }
}
