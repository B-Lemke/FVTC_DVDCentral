using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class DirectorController : Controller
    {
        // GET: Director
        public ActionResult Index()
        {
            DirectorList directors = new DirectorList();
            directors.Load();
            return View(directors);
        }

        // GET: Director/Details/5
        public ActionResult Details(int id)
        {
            Director director = new Director { Id = id };
            director.LoadById();
            return View(director);
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            Director director = new Director();
            return View(director);
        }

        // POST: Director/Create
        [HttpPost]
        public ActionResult Create(Director director)
        {
            try
            {
                // TODO: Add insert logic here
                director.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(director);
            }
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int id)
        {
            Director director = new Director { Id = id };
            director.LoadById();
            return View(director);
        }

        // POST: Director/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Director director)
        {
            try
            {
                // TODO: Add update logic here
                director.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(director);
            }
        }

        // GET: Director/Delete/5
        public ActionResult Delete(int id)
        {
            Director director = new Director { Id = id };
            director.LoadById();
            return View(director);
        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Director director)
        {
            try
            {
                // TODO: Add delete logic here
                director.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(director);
            }
        }
    }
}
