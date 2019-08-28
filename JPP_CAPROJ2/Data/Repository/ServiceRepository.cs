using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly JPPDbContext _context;

        public ServiceRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

        public Service FindService(Func<Service, bool> predicate)
        {
            return _context.Services
                  .FirstOrDefault(predicate);
        }
    }
}
