using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly JPPDbContext _context;

        public ProductRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

        public Product FindProduct(Func<Product, bool> predicate)
        {
                return _context.Products
                  .FirstOrDefault(predicate);
        }
    }
}
