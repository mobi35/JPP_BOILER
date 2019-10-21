using JPP_CAPROJ2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Models.ViewModel
{
    public class MyOrdersViewModel
    {
        public List<OrderedProducts> Orders { get; set; }

        public Transaction Transactions { get; set; }
    }
}
