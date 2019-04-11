using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            MovieList movies = new MovieList();
            movies.Load();
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = new Movie { Id = id };
            movie.LoadById();
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            Movie movie = new Movie();
            return View(movie);
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                movie.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(movie);
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movie = new Movie { Id = id };
            movie.LoadById();
            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                movie.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(movie);
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = new Movie { Id = id };
            movie.LoadById();
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                // TODO: Add delete logic here
                movie.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(movie);
            }
        }
    }
}
