using JPP_CAPROJ2.Data.Model;
using JPP_CAPROJ2.Data.Model.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPP_CAPROJ2.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedRepo;
        private readonly IUserRepository _userRepo;

        public FeedbackController(IFeedbackRepository feedRepo, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _feedRepo = feedRepo;
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Feedback feedback)
        {
            var userName = HttpContext.Session.GetString("UserName");
           var foundUser = _userRepo.FindUser(a => a.UserName == userName);
            feedback.Name = foundUser.FirstName + ", " + foundUser.LastName + " "+ foundUser.MiddleName;
            feedback.Email = foundUser.Email;
            feedback.Sent = DateTime.Now;
            _feedRepo.Create(feedback);
            return RedirectToAction("Index", "Client");
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var feed =_feedRepo.GetIdBy(id);
            _feedRepo.Delete(feed);
            return View("Feedbacks",GetList());
        }
        public IActionResult Feedbacks()
        {
            return View(GetList());
        }

        public List<Feedback> GetList()
        {
            List<Feedback> feedBacks = new List<Feedback>();
            var list = _feedRepo.GetAll();
            foreach(var l in list)
            {
                feedBacks.Add(l);
            }
            return feedBacks;
        }
    }
}
