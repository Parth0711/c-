using MotorCycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotorCycle.Controllers
{
    
    public class HomeController : Controller
    {

        //Home controller
        private ApplicationDbContext db = new ApplicationDbContext();
        //Index page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            //about page
            ViewBag.Message = "This website is about motorcycle inventory.";

            return View();
        }

        public ActionResult Contact()
        {

            //contact page
            ViewBag.Message = "Contact me at";

            return View();
        }

        public ActionResult MotorBikeSearch(string q)
        {
            var Motorbikes = GetMotorbikes(q);
            return PartialView(Motorbikes);
        }
        private List<MotorBike> GetMotorbikes(string searchString)
        {
            return db.MotorBikes.Where(a => a.MotorName.Contains(searchString)).ToList();
        }
    }
}