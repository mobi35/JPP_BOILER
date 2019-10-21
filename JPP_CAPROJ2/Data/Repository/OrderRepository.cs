using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class OrderRepository : Repository<OrderedProducts>, IOrderRepository
    {
        private readonly JPPDbContext _context;

        public OrderRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

  

        public OrderedProducts FindOrders(Func<OrderedProducts, bool> predicate)
        {
            return _context.Orders
                    .FirstOrDefault(predicate);
        }
    }
}
