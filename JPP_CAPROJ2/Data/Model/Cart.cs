using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class Cart
    {
        [Key]
        public int CartKey { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public string UserName { get; set; }
    }
}
