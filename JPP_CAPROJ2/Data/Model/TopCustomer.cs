using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class TopCustomer
    {
        public string FullName { get; set; }

        public decimal Spent { get; set; }

        public int Transactions { get; set; }

        public decimal TotalEarn { get; set; }

    }
}
