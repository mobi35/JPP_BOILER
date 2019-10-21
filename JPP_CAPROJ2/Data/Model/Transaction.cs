using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class Transaction
    {
        [Key]
        public int TransactionKey { get; set; }

        public string BankAccount { get; set; }

        public string BankName { get; set; }

        public string PaymentTerms { get; set; }

        public string PaymentStatus { get; set; }
    }
}
