using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JPP_CAPROJ2.Models;
using JPP_CAPROJ2.Data.Model.Interface;
using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Models.ViewModel;
using Microsoft.AspNetCore.Http;

namespace JPP_CAPROJ2.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _prodRepo;
        private ICartRepository _cartRepo;
        public CartController(IProductRepository prodRepo, ICartRepository cartRepo)
        {
            _prodRepo = prodRepo;
            _cartRepo = cartRepo;
        }

     
        public IActionResult Index()
        {
          
            return View();
        }

        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var checkCart = _cartRepo.FindCart(a => a.ProductID == id);
            if (checkCart != null)
            {
                checkCart.Quantity++;
                _cartRepo.Update(checkCart);
            }else { 
            Cart cart = new Cart();
            cart.ProductID = id;
            cart.Quantity = 1;
            cart.UserName = userName;
            _cartRepo.Create(cart);
            }
            return RedirectToAction("Shop","Product");
        }

        public IActionResult UpdateCart(Cart cart)
        {
            _cartRepo.Update(cart);
            return View();
        }

    

        public IActionResult Delete(int id)
        {
            var product = _prodRepo.GetIdBy(id);
            _prodRepo.Delete(product);
            return View("Index", _prodRepo.GetAll());
        }

      

        public IActionResult Cart()
        {
            List<ProductCartViewModel> productCartVM = new List<ProductCartViewModel>();

            foreach (var cart in _cartRepo.GetAll())
            {
                foreach (var product in _prodRepo.GetAll())
                {
                    if(cart.ProductID == product.ProductKey)
                    productCartVM.Add(new ProductCartViewModel { Product = product, Cart = cart });
                
                }
            }

            
            return View(productCartVM);
        }
    }
}
