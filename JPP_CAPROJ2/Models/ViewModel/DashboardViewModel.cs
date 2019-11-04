using JPP_CAPROJ2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Models.ViewModel
{
    public class DashboardViewModel
    {
        public List<double> IncomePerMonth { get; set; }

        public List<double> IncomePerWeek { get; set; }
     
        public double IncomeToday { get; set; }

        public List<Transaction> NewTransactions { get; set; }

       public ListOfTopCustomerModel ListOfTopCustomerModels { get; set; }

       public ListOfTopProductModel ListOfTopProductModels { get; set; }

        public ListOfFeedbackModel ListOfFeedbackModel { get; set; }

    }
}
