using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Major_Project.Models;
using Microsoft.AspNet.Identity;

namespace Major_Project.Controllers
{
    public class OrdersController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {

            return View();
        }

        //GET: Orders/CheckOut
        [HttpGet]
        [Authorize]
        public ActionResult Checkout()
        {

            Order orders = new Order();

            var userId = User.Identity.GetUserId();

            Session["UserId"] = userId;

            var temp_userId = Session["UserId"] as string;

            ViewBag.UserId = Session["UserId"] as string;
           
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                //  var CurrentUser = UserManager.FindById(userId);

                ApplicationUser CurrentUser = db.Users.FirstOrDefault(i => i.Id == userId);

                //Session["CurrentUser"] = CurrentUser.Name;

                if (userId == null)
                {
                    return RedirectToAction("AddToCart", "Cart");
                }

                ViewBag.CurrentUsername = Session["CurrentUser"] as string;

            }

            if (Session["Cart"] != null)
            {
                ViewBag.Cart = (CartViewModel)Session["Cart"];
            }
            else
            {
                ViewBag.ResultMessage = "Cart is empty";
            }

            return View(orders);
        }

        //POST: Orders/CheckOut
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout([Bind(Include = "UserId,Address1,Address2,OrderDateTime,Town,Country,PostalCode,TotalPrice")] Order order)
        {

            if (ModelState.IsValid)
            {
                //using (Major_ProjectEntities db_temp = new Major_ProjectEntities())
                //{


                //    foreach (var selectedProducts in ((CartViewModel)Session["Cart"]).SelectedProducts)
                //    {
                //        db_temp.Products.Attach(selectedProducts);
                //        db_temp.Orders.Add(order);
                //        db_temp.Orders.Attach(order);

                //        order.Products.Add(selectedProducts);
                //        db_temp.SaveChanges();
                //    }
                }
            

            return View();
        }


        // GET: Orders/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// GET: Orders/Create
        //public ActionResult Create()
        //{
        //    ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName");
        //    return View();
        //}

        //// POST: Orders/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OrderID,UserID,TotalPrice,OrderShipped,OrderDateTime,Address1,Address2,Town,Country,PostalCode")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Orders.Add(order);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", order.UserID);
        //    return View(order);
        //}

        //// GET: Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", order.UserID);
        //    return View(order);
        //}

        //// POST: Orders/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "OrderID,UserID,TotalPrice,OrderShipped,OrderDateTime,Address1,Address2,Town,Country,PostalCode")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UserID = new SelectList(db.Users, "Id", "FirstName", order.UserID);
        //    return View(order);
        //}

        //// GET: Orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    db.Orders.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
