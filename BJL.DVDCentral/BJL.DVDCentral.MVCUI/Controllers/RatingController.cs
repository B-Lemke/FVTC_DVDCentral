using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            RatingList ratings = new RatingList();
            ratings.Load();
            return View(ratings);
        }

        // GET: Rating/Details/5
        public ActionResult Details(int id)
        {
            Rating rating = new Rating { Id = id };
            rating.LoadById();
            return View(rating);
        }

        // GET: Rating/Create
        public ActionResult Create()
        {
            Rating rating = new Rating();
            return View(rating);
        }

        // POST: Rating/Create
        [HttpPost]
        public ActionResult Create(Rating rating)
        {
            try
            {
                // TODO: Add insert logic here
                rating.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(rating);
            }
        }

        // GET: Rating/Edit/5
        public ActionResult Edit(int id)
        {
            Rating rating = new Rating { Id = id };
            rating.LoadById();
            return View(rating);
        }

        // POST: Rating/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Rating rating)
        {
            try
            {
                // TODO: Add update logic here
                rating.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(rating);
            }
        }

        // GET: Rating/Delete/5
        public ActionResult Delete(int id)
        {
            Rating rating = new Rating { Id = id };
            rating.LoadById();
            return View(rating);
        }

        // POST: Rating/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Rating rating)
        {
            try
            {
                // TODO: Add delete logic here
                rating.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(rating);
            }
        }
    }
}
