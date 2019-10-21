using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model.Interface
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Transaction FindTransaction(Func<Transaction, bool> predicate);
    }
}
