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
    public class NotificationCountViewComponent : ViewComponent
    {
        private readonly INotificationRepository _notifRepo;
        private readonly IUserRepository _userRepo;

        public NotificationCountViewComponent(INotificationRepository notifRepo, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _notifRepo = notifRepo;
        }

     
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var userName =  HttpContext.Session.GetString("UserName");
            var findNotif = _notifRepo.FindNotification(a => a.Name == userName);
            List<Notification> notifList = new List<Notification>();
            var allNotif = _notifRepo.GetAll();
            foreach(var noti in allNotif){
                notifList.Add(noti);
            }
            return View( notifList );
        }
      

      
    }
}
