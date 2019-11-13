using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class QuotationRepository : Repository<Quotations>, IQuotationRepository
    {
        private readonly JPPDbContext _context;

        public QuotationRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }


        public Quotations FindQuotation(Func<Quotations, bool> predicate)
        {
            return _context.Quotations
                  .FirstOrDefault(predicate);
        }
    }
}
