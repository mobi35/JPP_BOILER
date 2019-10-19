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
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notifRepo;
        private readonly IUserRepository _userRepo;

        public NotificationController(INotificationRepository notifRepo, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _notifRepo = notifRepo;
        }

        public IActionResult Notifications(){
            return View();
        }

        [HttpGet]
        public IActionResult ClearNotification()
        {
            var userName = HttpContext.Session.GetString("UserName");
       
           var notifs = _notifRepo.GetAll();
            foreach (var n in notifs)
            {
                if (n.Name == userName)
                {
                    n.Read = true;
                    _notifRepo.Update(n);
                }
            }
            return Content("baknit");
        }
    }
}
