using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class Transaction
    {
        [Key]
        public int TransactionKey { get; set; }

        public string ServiceType { get; set; }

        public string BankAccount { get; set; }

        public string BankName { get; set; }

        public string PaymentTerms { get; set; }

        public string PaymentStatus { get; set; }

        public string ListOfProductsId { get; set; }

        public double TotalPrice { get; set; }

        public string UserName { get; set; }

        public DateTime? DateTimeStamps { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string ImageString { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public bool isRead { get; set; }

        public string DeliveryStatus { get; set; }

        public string WhoCanModify { get; set; }
    }
}
