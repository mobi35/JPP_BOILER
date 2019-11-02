using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using JPP_CAPROJ2.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Controllers
{
    public class TransactionCountViewComponent : ViewComponent
    {
  
        private readonly ITransactionRepository _transactionRepo;

        public TransactionCountViewComponent(ITransactionRepository transactionRepo)
        {

            _transactionRepo = transactionRepo;
        }

     
      
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var transactionCount = _transactionRepo.GetAll().Where(a => a.isRead == false);
            return View((int)transactionCount.Count()) ;
        }
      

      
    }
}
