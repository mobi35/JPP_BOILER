﻿using System;
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
        private readonly IOrderRepository _orders;
        private ITransactionRepository _transactionRepo;
        public CartController(IOrderRepository orders, ITransactionRepository transactionRepo, IProductRepository prodRepo, ICartRepository cartRepo)
        {
            _prodRepo = prodRepo;
            _cartRepo = cartRepo;
            _orders = orders;
            _transactionRepo = transactionRepo;
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


        public IActionResult Checkout()
        {
            List<ProductCartViewModel> productCartVM = new List<ProductCartViewModel>();

            foreach (var cart in _cartRepo.GetAll())
            {
                foreach (var product in _prodRepo.GetAll())
                {
                    if (cart.ProductID == product.ProductKey)
                        productCartVM.Add(new ProductCartViewModel { Product = product, Cart = cart });

                }
            }
            return View(productCartVM);
        }

        [HttpPost]
        public IActionResult Checkout( string bankAccount, string bankNumer)
        {
            var userName = HttpContext.Session.GetString("UserName");
            Transaction transaction = new Transaction();
            transaction.BankName = bankAccount;
            transaction.BankAccount = bankNumer;
            transaction.PaymentStatus = "pending";
          
            double totalPrice = 0;

            var productList = new List<ProductCartViewModel>();

         
            foreach (var c in _cartRepo.GetAll())
            {
                foreach (var p in _prodRepo.GetAll()) {  
                if (c.UserName == userName && c.ProductID == p.ProductKey)
                {
                        productList.Add(new ProductCartViewModel
                        {
                            Product = p,
                            Cart = c
                        });
                }
                }
            }

            var last = 1;
            try { 
             last = _transactionRepo.GetAll().LastOrDefault().TransactionKey++;
            }
            catch (Exception   e)
            {

            }



            foreach (var prod in productList)
            {
                if(prod.Cart.UserName == userName) { 
                totalPrice += prod.Product.Price * prod.Cart.Quantity;
                _orders.Create(new OrderedProducts
                {
                   ProductID = prod.Product.ProductKey,
                   ProductName = prod.Product.ProductName,
                   Quantity = prod.Cart.Quantity,
                   TransactionID = last
                });
                }
            }
            transaction.TotalPrice = totalPrice;
            transaction.UserName = userName;
            _transactionRepo.Create(transaction);
            
           var cart = _cartRepo.GetAll();
            foreach (var c in cart)
            {

                if (c.UserName == userName)
                    _cartRepo.Delete(c);
            }
            return RedirectToAction("CheckoutSuccess");
        }

        public IActionResult CheckoutSuccess()
        {
            return View();
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


        public IActionResult MyOrders()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var transaction = _transactionRepo.GetAll();
            var orders = _orders.GetAll();
            List<MyOrdersViewModel> myOrdersVM = new List<MyOrdersViewModel>();
            foreach (var trans in transaction)
            {
                if(trans.UserName == userName) { 
                List<OrderedProducts> listProd = new List<OrderedProducts>();
                foreach (var order in orders)
                {
                    if(order.TransactionID == trans.TransactionKey)
                        listProd.Add(order); 

                }
                myOrdersVM.Add(new MyOrdersViewModel
                {
                    Transactions = trans,
                    Orders = listProd
                });
                }
            }
            
            return View(myOrdersVM);
        }
    }
}
