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
    public class CartCountViewComponent : ViewComponent
    {
        private readonly ICartRepository _cartRepo;
        private readonly IProductRepository _productRepo;

        public CartCountViewComponent(ICartRepository cartRepo, IProductRepository productRepo)
        {
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }

     
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName =  HttpContext.Session.GetString("UserName");
         //   var findNotif = _notifRepo.FindNotification(a => a.Name == userName);
            List<ProductCartViewModel> productCartVM = new List<ProductCartViewModel>();
            var allCart = _cartRepo.GetAll();
            var allProduct = _productRepo.GetAll();
            foreach(var cart in allCart)
            {
                foreach (var product in allProduct)
                {
                    if (cart.UserName == userName && product.ProductKey == cart.ProductID)
                    {
                        productCartVM.Add(new ProductCartViewModel
                        {
                            Product = product,
                             Cart = cart
                        });

                    }
                
                }
            }
            return View(productCartVM);
        }
      

      
    }
}
