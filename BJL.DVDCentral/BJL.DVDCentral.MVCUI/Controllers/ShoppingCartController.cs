using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;
using BJL.DVDCentral.MVCUI.ViewModels;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;

        // GET: ShoppingCart
        public ActionResult Index()
        {
            GetShoppingCart();
            return View(cart);
        }

        private void GetShoppingCart()
        {
            if (Session["cart"] == null)
            {
                cart = new ShoppingCart();
                SaveCart();
            }
            else
            {
                cart = (ShoppingCart)Session["cart"];
            }
        }

        public ActionResult RemoveFromCart(int id)
        {
            GetShoppingCart();

            Movie movie = cart.Items.FirstOrDefault(m => m.Id == id);

            if (movie != null)
            {
                cart.Remove(movie);
            }

            SaveCart();
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(int id)
        {
            GetShoppingCart();
            Movie movie = new Movie { Id = id };
            movie.LoadById();

            cart.Add(movie);

            SaveCart();

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult CommitToBuy()
        {
            CustomerListCart clc = new CustomerListCart();
            clc.ShoppingCart = new ShoppingCart();
            clc.CustomerList = new CustomerList();
            clc.CustomerList.Load();

            GetShoppingCart();
            clc.ShoppingCart = cart;

            return View(clc);
        }

        private void SaveCart()
        {
            Session["cart"] = cart;
        }

        [HttpPost]
        public ActionResult CommitToBuy(CustomerListCart clc)
        {
            try
            {
                GetShoppingCart();
                clc.ShoppingCart = cart;

                clc.ShoppingCart.CustomerId = clc.CustomerId;

                User currentUser = (User)Session["user"];
                clc.ShoppingCart.CheckOut(currentUser.Id);

                Session["cart"] = null;

                return RedirectToAction("OrderPlaced");
            }
            catch (Exception ex)
            {
                return View(clc);
            }
        }

        public ActionResult OrderPlaced()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CartDisplayWidget()
        {
            GetShoppingCart();
            return PartialView(cart);
        }

    }
}