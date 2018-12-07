using Major_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Major_Project.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            ViewBag.UsersCount = context.Users.Count();
            var UsersList = context.Users.ToList();



            return View(UsersList);
        }
    }
}