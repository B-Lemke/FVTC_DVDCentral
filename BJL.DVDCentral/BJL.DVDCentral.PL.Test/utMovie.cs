using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.PL;
using System.Linq;

namespace BJL.DVDCentral.PL.Test
{
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void Load()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                var movies = dc.tblMovies;

                int expected = 3;
                int actual = movies.Count();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Insert()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                //Create a movie
                tblMovie movie = new tblMovie
                {
                    Id = -99,
                    Title = "TestMovie",
                    Cost = -99.99m,
                    Quantity = -10,
                    Description = "A test movie",
                    FormatId = -99,
                    DirectorId = -99,
                    ImagePath = "TextMovieImg",
                    RatingId = -99
                
                };

                //Insert the row
                dc.tblMovies.Add(movie);

                //Commit the changes
                int rowsInserted = dc.SaveChanges();

                //Make sure that one row was inserted
                Assert.IsTrue(rowsInserted == 1);
            }
        }

        [TestMethod]
        public void Update()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblMovie movie = dc.tblMovies.FirstOrDefault(m => m.Id == -99);
                movie.Title = "TestingUpdate";

                //Save changed property
                dc.SaveChanges();

                tblMovie updatedMovie = dc.tblMovies.FirstOrDefault(m => m.Title == "TestingUpdate");
                Assert.AreEqual(movie.Id, updatedMovie.Id);
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblMovie movie = dc.tblMovies.FirstOrDefault(m => m.Id == -99);
                dc.tblMovies.Remove(movie);
                int rowsEffected = dc.SaveChanges();

                Assert.IsTrue(rowsEffected == 1);
            }
        }
    }
}
