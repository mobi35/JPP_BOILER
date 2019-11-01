using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string FullName { get; set; }
        [Required]
        [Column(TypeName = "varchar(7)")]
        public string Gender { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; }
        [Required]
        
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Role { get; set; }

       public string Address { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public string IsAgree { get; set; }

        [NotMapped]
        
        public string Message { get; set; }

        public int NumberOfTask { get; set;}

        public string Status { get; set; }

    }
}
