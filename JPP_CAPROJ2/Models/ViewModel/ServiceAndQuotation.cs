using JPP_CAPROJ2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Models.ViewModel
{
    public class ServiceAndQuotation
    {
        public Service Service { get; set; }

        public List<Quotations> Quotation { get; set; }

    }
}
