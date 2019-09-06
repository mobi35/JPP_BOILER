using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User FindUser(Func<User, bool> predicate);
    }
}
