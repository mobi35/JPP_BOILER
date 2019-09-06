using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        public DateTime Sent { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }

    }
}
