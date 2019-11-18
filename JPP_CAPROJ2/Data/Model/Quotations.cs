using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class Quotations
    {
        [Key]
        public int QuotationPK { get; set; }

        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string QuotationName { get; set; }
        public double Price { get; set; }

    }
}
