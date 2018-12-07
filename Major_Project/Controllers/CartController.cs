using Major_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Major_Project.Controllers
{
    public class CartController : Controller
    {
        Major_ProjectEntities db = new Major_ProjectEntities();

        CartViewModel cart = new CartViewModel() { SelectedProducts = new List<item>() };


        // GET: Cart
        public ActionResult Index()
        {
            return View(Session["Cart"] as CartViewModel);
        }

        public ActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Session["cart"] == null)
            {
                Session["cart"] = cart;
            }
            else
            {
                cart = (CartViewModel)Session["cart"];
            }

            item selectedProduct = db.items.Find(id);

            if (selectedProduct == null)
            {
                return HttpNotFound();
            }

            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            //Redirect to Products/Details/id incase product already exists
            if (cart.SelectedProducts.Any(m => m.item_id == selectedProduct.item_id))
            {
                var ResultMessage = "Product already exists in a cart.";
                return RedirectToAction("Index", "Analysis", new { id = id, message = ResultMessage });
            }
            else
            {
                cart.SelectedProducts.Add(selectedProduct);
                cart.TotalPrice += selectedProduct.item_price;

                return View(cart);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index");
            }
            cart = Session["Cart"] as CartViewModel;
            item selectedItem = cart.SelectedProducts.FirstOrDefault(i => i.item_id == id);

            if (selectedItem == null)
            {
                return HttpNotFound();
            }
            else
            {
                cart.SelectedProducts.Remove(selectedItem);
                return RedirectToAction("Index");
            }

        }
    }
}