using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Data.Model
{
    public class ServiceRequestViewModel
    {
      public Service Services {get; set;}
      public Request Requests {get; set;}

    }
}
