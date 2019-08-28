using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        private readonly JPPDbContext _context;

        public NotificationRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddNotification(string Message, string Name)
        {
            Notification notif = new Notification();
            notif.Description = Message;
            notif.Name = Name;
            notif.StartDate = DateTime.Now;
            _context.Notifications.Add(notif);
            Save();
        }

        public Notification FindNotification(Func<Notification, bool> predicate)
        {
            return _context.Notifications
                  .FirstOrDefault(predicate);
        }

       
    }
}
