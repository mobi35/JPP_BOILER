using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JPP_CAPROJ2.Data.Model
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int ServiceId { get; set; }

        public string UserName {get; set;}
    
        [NotMapped]
         public IFormFile Image {get; set;}
         public string ImageName {get; set;}

         public string Address { get; set; }

        [NotMapped]
         public IFormFile RequirementsFile {get; set;}
        [Column(TypeName = "nvarchar(255)")]
        public string Requirements { get; set; }
      
        public string Description { get; set; }
        public DateTime AvailableDate { get; set; }
        public float Price {get; set;}
        
        public string Status {get; set;}

        public bool IsPaid {get; set;}
        public string AccountName {get; set;}
        public string AccountNumber {get; set;}
        [NotMapped]
        public string Message { get; set; }

        public string AssignedBy {get; set;}

        public bool isRead { get; set; }

    }
}
