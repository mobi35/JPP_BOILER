using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model.Interface
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Notification FindNotification(Func<Notification, bool> predicate);

        void AddNotification(string Message, string Name);
    }
}
