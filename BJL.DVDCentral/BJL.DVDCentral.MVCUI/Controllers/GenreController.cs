using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            GenreList genres = new GenreList();
            genres.Load();
            return View(genres);
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            Genre genre = new Genre { Id = id };
            genre.LoadById();
            return View(genre);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            Genre genre = new Genre();
            return View(genre);
        }

        // POST: Genre/Create
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            try
            {
                // TODO: Add insert logic here
                genre.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genre);
            }
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            Genre genre = new Genre { Id = id };
            genre.LoadById();
            return View(genre);
        }

        // POST: Genre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Genre genre)
        {
            try
            {
                // TODO: Add update logic here
                genre.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genre);
            }
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            Genre genre = new Genre { Id = id };
            genre.LoadById();
            return View(genre);
        }

        // POST: Genre/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Genre genre)
        {
            try
            {
                // TODO: Add delete logic here
                genre.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
               
                return View(genre);
            }
        }



        //Sidebar
        [ChildActionOnly]
        public ActionResult Sidebar()
        {
            GenreList genres = new GenreList();
            genres.Load();
            return PartialView(genres);
        }
    }
}
