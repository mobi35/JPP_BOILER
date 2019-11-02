using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class Product 
    {
        [Key]
        public int ProductKey { get; set; }
        public string ProductName { get; set; }
        [NotMapped]
        public IFormFile img1 { get; set; }
        [NotMapped]
        public IFormFile img2 { get; set; }
        [NotMapped]
        public IFormFile img3 { get; set; }
        [NotMapped]
        public IFormFile img4 { get; set; }
        [NotMapped]
        public IFormFile img5 { get; set; }
        public string Image { get; set; }
        public string OtherImage1 { get; set; }
        public string OtherImage2 { get; set; }
        public string OtherImage3 { get; set; }
        public string OtherImage4 { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }

        public bool isRead { get; set; }
    }
}
