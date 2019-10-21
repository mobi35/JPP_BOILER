using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Repository
{
    public class TransactionRepository : Repository<Transaction >, ITransactionRepository
    {
        private readonly JPPDbContext _context;

        public TransactionRepository(JPPDbContext context) : base(context)
        {
            _context = context;
        }

        public Transaction FindTransaction(Func<Transaction, bool> predicate)
        {
            return _context.Transactions
                  .FirstOrDefault(predicate);
        }
    }
}
