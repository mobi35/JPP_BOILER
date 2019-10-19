using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JPP_CAPROJ2.Models;
using JPP_CAPROJ2.Data.Model.Interface;
using JPP_CAPROJ2.Data.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace JPP_CAPROJ2.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _prodRepo;

        private IHostingEnvironment _hostingEnvironment;
        public ProductController(IProductRepository prodRepo, IHostingEnvironment hostingEnvironment)
        {
            _prodRepo = prodRepo;
            _hostingEnvironment = hostingEnvironment;
        }

     
        public IActionResult Index()
        {
            var product = _prodRepo.GetAll();
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_prodRepo.FindProduct(a => a.ProductKey == id));
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            var uniqueName = "";

            try { 
            if (product.img1.FileName != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img1.CopyTo(new FileStream(filePath, FileMode.Create));
                product.Image = uniqueName;
            }
            }catch(Exception e)
            {

            }
            try { 
            if (product.img2.FileName != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img2.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img2.CopyTo(new FileStream(filePath, FileMode.Create));
                product.OtherImage1 = uniqueName;
            }
            }
            catch (Exception e)
            {

            }

            try { 
            if (product.img3.FileName != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img3.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img3.CopyTo(new FileStream(filePath, FileMode.Create));
                product.OtherImage2 = uniqueName;
            }
            }catch(Exception e)
            {

            }

            try { 

            if (product.img4.FileName != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img4.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img4.CopyTo(new FileStream(filePath, FileMode.Create));
                product.OtherImage3 = uniqueName;
            }
            }catch(Exception e)
            {

            }

            try { 
            if (product.img5.FileName != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img5.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img5.CopyTo(new FileStream(filePath, FileMode.Create));
                product.OtherImage4 = uniqueName;
            }
            }catch(Exception e)
            {

            }
            _prodRepo.Update(product);
            return View("Index", _prodRepo.GetAll());
        }

        public IActionResult Delete(int id)
        {
            var product = _prodRepo.GetIdBy(id);
            _prodRepo.Delete(product);
            return View("Index", _prodRepo.GetAll());
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var uniqueName = "";
       
            if(product.img1 != null) { 
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img1.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img1.CopyTo(new FileStream(filePath, FileMode.Create));
                product.Image = uniqueName;
            }
          
            if (product.img2 != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img2.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img2.CopyTo(new FileStream(filePath, FileMode.Create));
                product.OtherImage1 = uniqueName;
            }
          
            if (product.img3 != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img3.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img3.CopyTo(new FileStream(filePath, FileMode.Create));
                product.OtherImage2 = uniqueName;
            }
        
            if (product.img4 != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img4.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img4.CopyTo(new FileStream(filePath, FileMode.Create));
                product.OtherImage3 = uniqueName;
            }
      

            if (product.img5 != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                uniqueName = Guid.NewGuid().ToString() + "_" + product.img5.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                product.img5.CopyTo(new FileStream(filePath, FileMode.Create));
                product.OtherImage4 = uniqueName;
            }

            _prodRepo.Create(product);
            return View("Index", _prodRepo.GetAll());
        }

        public IActionResult Create()
        {
            Product product = new Product();
            product.Message = "";
            return View(product);
        }

        public IActionResult Shop()
        {

            return View(_prodRepo.GetAll());
        }

        [HttpGet]
        public IActionResult ProductView(int id)
        {
            return View(_prodRepo.FindProduct(a => a.ProductKey == id));
        }
    }
}
