using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public bool Read {get; set;}
        [NotMapped]
        public string Message { get; set; }

    }
}
