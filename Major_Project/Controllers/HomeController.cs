using Major_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Major_Project.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index(int? id)
        {
            int min, max;


            var a = new List<item>();
            Major_ProjectEntities db = new Major_ProjectEntities();
            if (id == null)
            {
               a = (from m in db.items select m).ToList();
            }
            else
            {
                ViewBag.current = id;
                max = (int)id * 24;
                min = max - 25;
                a = (from m in db.items where m.item_id < max && m.item_id > min select m).ToList();
            }
            return View(a);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index()
        //{

        //    Major_ProjectEntities db = new Major_ProjectEntities();

        //    return View(db.items.ToList());
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}