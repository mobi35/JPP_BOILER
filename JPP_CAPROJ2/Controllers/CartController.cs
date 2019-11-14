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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace JPP_CAPROJ2.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _prodRepo;
        private ICartRepository _cartRepo;
        private readonly IRequestRepository _requestRepo;
        private readonly IHostingEnvironment _hosting;
        private readonly IUserRepository _userRepo;
        private readonly INotificationRepository _notificationRepo;
        private readonly IOrderRepository _orders;
        private ITransactionRepository _transactionRepo;
        public CartController(IHostingEnvironment hosting, IUserRepository userRepo,  INotificationRepository notificationRepo, IOrderRepository orders, ITransactionRepository transactionRepo, IProductRepository prodRepo, ICartRepository cartRepo, IRequestRepository requestRepo)
        {
            _prodRepo = prodRepo;
            _cartRepo = cartRepo;
            _requestRepo = requestRepo;
            _hosting = hosting;
            _userRepo = userRepo;
            _notificationRepo = notificationRepo;
            _orders = orders;
            _transactionRepo = transactionRepo;
        }

     
        public IActionResult Index()
        {
          
            return View();
        }

        public IActionResult NoStocks()
        {

            return View();
        }
        
        [HttpPost]
        public IActionResult AddToCart(int id, int qty)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var checkCart = _cartRepo.FindCart(a => a.ProductID == id);

            var product = _prodRepo.GetIdBy(id);
            if (qty > product.Stocks)
            {
                return View("NoStocks");
            }
            else if (checkCart != null)
            {
                checkCart.Quantity++;
                _cartRepo.Update(checkCart);
            }else { 
            Cart cart = new Cart();
            cart.ProductID = id;
            cart.Quantity = qty;
            cart.UserName = userName;
            _cartRepo.Create(cart);
            }
            return RedirectToAction("Shop","Product");
        }
        string uniqueName = null;

        public IActionResult AddDepositSlip(int id, IFormFile imageFile)
        {
            var transactionRepo = _transactionRepo.GetIdBy(id);
            string uploadsFolder = Path.Combine(_hosting.WebRootPath, "Images");
            uniqueName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueName);
            imageFile.CopyTo(new FileStream(filePath, FileMode.Create));
            transactionRepo.ImageString = uniqueName;
            _transactionRepo.Update(transactionRepo);
            _notificationRepo.AddNotification($"{transactionRepo.UserName} has added a deposit slip. Please check transaction.", transactionRepo.UserName);
            return View("MyOrders", MyClientOrdersVM());
        }

        public IActionResult DoneDelivery(int id)
        {
            var delivery = _transactionRepo.GetIdBy(id);
            delivery.DeliveryStatus = "Delivered";
            _transactionRepo.Update(delivery);
            return View("ProductOrders", MyOrdersVM());
        }

        public IActionResult UpdateCart(Cart cart)
        {
            _cartRepo.Update(cart);
            return View();
        }
        
        public IActionResult AdminAcceptDelivery(int id)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var delivery = _transactionRepo.GetIdBy(id);
            delivery.DeliveryStatus = "Completed";
            delivery.WhoCanModify = userName;
            _transactionRepo.Update(delivery);
            return View("ProductOrders", MyOrdersVM());
        }

        public IActionResult AdminRejectDelivery(int id)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var delivery = _transactionRepo.GetIdBy(id);
            delivery.DeliveryDate = null;
            delivery.WhoCanModify = userName;
            _transactionRepo.Update(delivery);
            return View("ProductOrders", MyOrdersVM());
        }

        public IActionResult AcceptDelivery(int id)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var delivery = _transactionRepo.GetIdBy(id);
            delivery.DeliveryStatus = "Completed";
            delivery.WhoCanModify = userName;
            _transactionRepo.Update(delivery);
            return View("MyOrders", MyClientOrdersVM());
        }

        public IActionResult RejectDelivery(int id)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var delivery = _transactionRepo.GetIdBy(id);
            delivery.DeliveryDate = null;
            delivery.WhoCanModify = userName;
            _transactionRepo.Update(delivery);
            return View("MyOrders", MyClientOrdersVM());
        }
        [HttpPost]
        public IActionResult CustomerPreferredDate(int id, DateTime? dateTime)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var transaction = _transactionRepo.GetIdBy(id);
            transaction.DeliveryDate = dateTime;
            transaction.WhoCanModify = userName;
            _transactionRepo.Update(transaction);
            return View("MyOrders", MyClientOrdersVM());
        }

        [HttpPost]
        public IActionResult SetDeliveryDate(int id, DateTime? dateTime)
        {
            var userName = HttpContext.Session.GetString("UserName");
            var transaction = _transactionRepo.GetIdBy(id);
            transaction.DeliveryDate = dateTime;
            transaction.WhoCanModify = userName;
            _transactionRepo.Update(transaction);

            return View("ProductOrders", MyOrdersVM());
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
            foreach (var cart in _cartRepo.GetAll().AsQueryable().ToList())
            {
                foreach (var product in _prodRepo.GetAll().AsQueryable().ToList())
                {
                    if (cart.ProductID == product.ProductKey)
                        productCartVM.Add(new ProductCartViewModel { Product = product, Cart = cart });

                }
            }
            return View(productCartVM);
        }
       

        public IActionResult GetProductsInProjects(int id)
        {

            string htmlThing = "<table class='table'><thead> <tr><th> Item </th>   <th> Price</th>   <th>Qty</th> </tr> <tbody> ";
            double totalPrice = 0;
            foreach (var list in _orders.GetAll().Where(a => a.TransactionID == id).ToList())
            {
                totalPrice += list.Price;
                htmlThing += $"<tr>  <td> { list.ProductName  } </td>   <td>{ list.Price.ToString("N") }</td>   <td> {list.Quantity }</td>   </tr>";
            }
           
            htmlThing += $"<tr><td>Total</td> <td > P {totalPrice.ToString("N")} </td> </tr> </tbody> </table>";
            return Content(htmlThing);
        }

      

        public IActionResult Projects()
        {
            return View(_transactionRepo.GetAll().ToList());
        }
        public IActionResult AcceptCOD(int id)
        {
            var trans = _transactionRepo.GetIdBy(id);
            foreach (var order in _orders.GetAll().ToList())
            {
                var product = _prodRepo.GetIdBy(order.ProductID);
                if (trans.TransactionKey == order.TransactionID)
                {
                    product.Stocks -= order.Quantity;
                    _prodRepo.Update(product);
                }
            }
            var transaction = _transactionRepo.GetIdBy(id);
            transaction.PaymentStatus = "Completed";
            transaction.DeliveryStatus = "Completed";
            transaction.DeliveryDate = DateTime.Now;
           
            _transactionRepo.Update(transaction);
            return View("ProductOrders", MyOrdersVM());
        }


        [HttpPost]
        public IActionResult Checkout( string bankAccount, string bankNumer, string paytype)
        {
            var userName = HttpContext.Session.GetString("UserName");
            Transaction transaction = new Transaction();
            transaction.BankName = bankAccount;
            transaction.BankAccount = bankNumer;
            transaction.PaymentStatus = "pending";
            transaction.DateTimeStamps = DateTime.Now;

            double totalPrice = 0;
            var productList = new List<ProductCartViewModel>();
         
            foreach (var c in _cartRepo.GetAll().AsQueryable().ToList())
            {
                foreach (var p in _prodRepo.GetAll().AsQueryable().ToList()) {  
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
             last = _transactionRepo.GetAll().LastOrDefault().TransactionKey;
                last++;
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
                   Price = prod.Product.Price,
                   TransactionID = last
                });
                }
            }
            string successMessage = "";
            if (paytype == "bank")
            {
                successMessage = "Please upload the Bank Deposit Slip within 15 days.If you fail to do so, your order will be cancelled." ;
               transaction.PaymentTerms = "Bank Account";
            }else
            {
                successMessage = "Your order will take 5 - 7 days to deliver..";
                transaction.PaymentTerms = "Cash on delivery";
            }
            transaction.TotalPrice = totalPrice;
            transaction.UserName = userName;
            transaction.DateTimeStamps = DateTime.Now;
            
            _transactionRepo.Create(transaction);
            
           var cart = _cartRepo.GetAll().AsQueryable().ToList();
            _notificationRepo.AddNotification($"1 new product order from {transaction.UserName}", transaction.UserName);
            foreach (var c in cart)
            {

                if (c.UserName == userName)
                    _cartRepo.Delete(c);
            }
            
            return View("CheckoutSuccess", successMessage);
        }
       
       public IActionResult RemoveItemCart(int id)
        {
            _cartRepo.Delete(_cartRepo.GetIdBy(id));
            return RedirectToAction("Cart", "Cart");
        }
        [HttpGet]
        public IActionResult CheckoutSuccess(string successMessage)
        {
            return View(successMessage);
        }

        public IActionResult Cart()
        {
            
            List<ProductCartViewModel> productCartVM = new List<ProductCartViewModel>();
          
            foreach (var cart in _cartRepo.GetAll().AsQueryable().ToList())
            {
                foreach (var product in _prodRepo.GetAll().AsQueryable().ToList())
                {
                    if(cart.ProductID == product.ProductKey)
                    productCartVM.Add(new ProductCartViewModel { Product = product, Cart = cart });
                
                }
            }
            if (productCartVM.ToList().Count() == 0)
            {
                return View("NoItemsInCart");
            }
            return View(productCartVM);
        }

        public IActionResult NoItemsInCart()
        {
            return View();
        }


        public IActionResult MyOrders()
        {
            return View(MyClientOrdersVM());
        }

       

        public IActionResult AcceptPayment(int id)
        {
           var trans = _transactionRepo.GetIdBy(id);
            foreach (var order in _orders.GetAll().ToList())
            {
                var product = _prodRepo.GetIdBy(order.ProductID);
                if (trans.TransactionKey == order.TransactionID && trans.ServiceID == 0)
                {
                    product.Stocks -= order.Quantity;
                    _prodRepo.Update(product);
                }
            }
           
            trans.PaymentStatus = "Completed";
            trans.DeliveryStatus = "Pending";
            trans.TransactionCompletion = DateTime.Now;
            _transactionRepo.Update(trans);
          var service = _requestRepo.GetIdBy(trans.ServiceID);
            if (service != null)
            {
                service.Status = "Paid";
                service.ServiceId = trans.TransactionKey;
                _requestRepo.Update(service);
            }


            _notificationRepo.AddNotification("You're Transaction has been accepted.", trans.UserName);
            return View("ProductOrders", MyOrdersVM());
        }

        public IActionResult RejectPayment(int id)
        {
            var trans = _transactionRepo.GetIdBy(id);
            trans.PaymentStatus = "Rejected";
            _transactionRepo.Update(trans);
            _notificationRepo.AddNotification("You're Transaction is rejected. Please choose a valid bank account", trans.UserName);
            return View("ProductOrders", MyOrdersVM());

        }
        public IActionResult ProductOrders()
        {
            return View(MyOrdersVM());
         
        }


        public IActionResult AcceptService(int id)
        {
            var trans = _transactionRepo.GetIdBy(id);
            trans.PaymentStatus = "Accepted by customer";
            _transactionRepo.Update(trans);

            _requestRepo.GetIdBy(trans.ServiceID).Status = "Accepted by customer";
            //  _notificationRepo.AddNotification("You're Transaction is rejected. Please choose a valid bank account", trans.UserName);
            return View("MyOrders", MyClientOrdersVM());
        }

        public IActionResult RejectService(int id)
        {
            var trans = _transactionRepo.GetIdBy(id);
            trans.PaymentStatus = "Rejected by customer";
            _transactionRepo.Update(trans);

            _requestRepo.GetIdBy(trans.ServiceID).Status = "Rejected by customer";
            //  _notificationRepo.AddNotification("You're Transaction is rejected. Please choose a valid bank account", trans.UserName);
            return View("MyOrders", MyClientOrdersVM());
        }

        public List<MyOrdersViewModel> MyOrdersVM()
        {

            var transaction = _transactionRepo.GetAll().AsQueryable().ToList();
            var orders = _orders.GetAll().AsQueryable().ToList();
            List<MyOrdersViewModel> myOrdersVM = new List<MyOrdersViewModel>();
            foreach (var trans in transaction)
            {
                trans.isRead = true;
                _transactionRepo.Update(trans);
                List<OrderedProducts> listProd = new List<OrderedProducts>();
                foreach (var order in orders)
                {
                    if (order.TransactionID == trans.TransactionKey)
                        listProd.Add(order);

                }
                myOrdersVM.Add(new MyOrdersViewModel
                {
                    Transactions = trans,
                    Orders = listProd
                });

            }

            return myOrdersVM;
        }


        public List<MyOrdersViewModel> MyClientOrdersVM()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var transaction = _transactionRepo.GetAll().AsQueryable().ToList();
            var orders = _orders.GetAll().AsQueryable().ToList();
            List<MyOrdersViewModel> myOrdersVM = new List<MyOrdersViewModel>();
            foreach (var trans in transaction)
            {
                if(trans.UserName == userName) { 
                List<OrderedProducts> listProd = new List<OrderedProducts>();
                foreach (var order in orders)
                {
                    if (order.TransactionID == trans.TransactionKey)
                        listProd.Add(order);

                }
                myOrdersVM.Add(new MyOrdersViewModel
                {
                    Transactions = trans,
                    Orders = listProd
                });
                }
            }

            return myOrdersVM;
        }

        public IActionResult Invoice(int id)
        {
            MyOrdersViewModel myOrdersVM = new MyOrdersViewModel
            {
                Transactions = _transactionRepo.GetIdBy(id),
                Orders = _orders.GetAll().Where(a => a.TransactionID == id).ToList(),
                User = _userRepo.FindUser(a => a.UserName == _transactionRepo.GetIdBy(id).UserName)

            };

            return View(myOrdersVM);
        }
    }
}
