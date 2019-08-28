using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly JPPDbContext _context;

        public UserRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

        public User FindUser(Func<User, bool> predicate)
        {
            return _context.Users
                  .FirstOrDefault(predicate);
        }
    }
}
