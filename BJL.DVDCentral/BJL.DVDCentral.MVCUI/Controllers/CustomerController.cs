using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerList customers = new CustomerList();
            customers.Load();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = new Customer { Id = id };
            customer.LoadById();
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                customer.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = new Customer { Id = id };
            customer.LoadById();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                customer.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer = new Customer { Id = id };
            customer.LoadById();
            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                customer.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(customer);
            }
        }
    }
}
