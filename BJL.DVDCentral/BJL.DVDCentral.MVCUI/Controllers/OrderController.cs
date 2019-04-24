using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            OrderList ol = new OrderList();
            ol.Load();
            return View(ol);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            Order order = new Order { Id = id };
            order.LoadById();
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            Order order = new Order();
            return View(order);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                // TODO: Add insert logic here
                order.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(order);
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            Order order = new Order { Id = id };
            order.LoadById();
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                // TODO: Add update logic here
                order.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(order);
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            Order order = new Order { Id = id };
            order.LoadById();
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                // TODO: Add delete logic here
                order.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(order);
            }
        }
    }
}
