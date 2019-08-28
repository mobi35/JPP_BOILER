using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        private readonly JPPDbContext _context;

        public RequestRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

        public Request FindRequest(Func<Request, bool> predicate)
        {
            return _context.Requests
                  .FirstOrDefault(predicate);
        }
    }
}
