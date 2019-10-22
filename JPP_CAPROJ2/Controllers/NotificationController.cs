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

        public IActionResult AdminNotification()
        {
            return View(_notifRepo.GetAll());
        }

        public IActionResult ClientNotification()
        {
            var userName = HttpContext.Session.GetString("UserName");
            List<Notification> notifications = new List<Notification>();
            foreach (var notif in _notifRepo.GetAll())
            {
                if (notif.Name == userName)
                    notifications.Add(notif);

            }
            return View(notifications);
        }

    }
}
