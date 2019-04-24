using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BJL.DVDCentral.BL;
using BJL.DVDCentral.MVCUI.ViewModels;

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

        public ActionResult LoadByGenre(int id)
        {
            MovieList movies = new MovieList();
            movies.LoadByGenreId(id);

            Genre genre = new Genre { Id = id };
            genre.LoadById();

            ViewBag.Message = "Movies with the genre " + genre.Description;

            return View("Index", movies);

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
            MovieGenresDirectorsRatingsFormats movieVM = new MovieGenresDirectorsRatingsFormats();

            movieVM.Movie = new Movie { Id = id };
            movieVM.Movie.LoadById();

            movieVM.DirectorList = new DirectorList();
            movieVM.DirectorList.Load();

            movieVM.FormatList = new FormatList();
            movieVM.FormatList.Load();

            movieVM.GenreList = new GenreList();
            movieVM.GenreList.Load();

            movieVM.RatingList = new RatingList();
            movieVM.RatingList.Load();



            IEnumerable<int> existingGenreIds = new List<int>();
            //Select a list of one field
            existingGenreIds = movieVM.Movie.Genres.Select(g => g.Id);
            movieVM.GenreIds = existingGenreIds;

            //Put all values in session
            Session["genreids"] = existingGenreIds;



            return View(movieVM);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieGenresDirectorsRatingsFormats movieVM)
        {
            try
            {
                IEnumerable<int> oldGenreIds = new List<int>();
                if (Session["genreids"] != null)
                {
                    oldGenreIds = (IEnumerable<int>)Session["genreids"];
                }

                IEnumerable<int> newGenreIds = new List<int>();
                if (movieVM.GenreIds != null)
                {
                    newGenreIds = movieVM.GenreIds;
                }


                //Identify the deletes
                IEnumerable<int> deletes = oldGenreIds.Except(newGenreIds);

                //Identify the adds
                IEnumerable<int> adds = newGenreIds.Except(oldGenreIds);

                deletes.ToList().ForEach(d => MovieGenre.Delete(id, d));
                adds.ToList().ForEach(a => MovieGenre.Add(id, a));

                movieVM.Movie.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(movieVM);
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
