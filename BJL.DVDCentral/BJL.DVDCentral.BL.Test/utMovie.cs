using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.BL;
using System.Linq;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utMovie
    {
        [TestMethod]
        public void LoadTest()
        {
            MovieList movies = new MovieList();

            movies.Load();

            int expected = 4;
            int actual = movies.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            //Create a new movie and set properties
            Movie movie = new Movie
            {
                Title = "TestMovie",
                Cost = -99.99m,
                Description = "TestMovieDesription",
                DirectorId = 1,
                FormatId = 1,
                ImagePath = "TestMoviePath.jpg",
                Quantity = -99,
                RatingId = 1,
            };

            //Insert it
            int result = movie.Insert();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            MovieList movies = new MovieList();
            movies.Load();

            //Find the movie with the description testingmovie
            Movie movie = movies.FirstOrDefault(m => m.Quantity == -99);

            //Update it and insert it
            movie.Description = "UpdatedMovie";
            int result = movie.Update();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            MovieList movies = new MovieList();
            movies.Load();

            //Find the movie with the description testingmovie
            Movie movie = movies.FirstOrDefault(m => m.Quantity == -99);

            //Delete it
            int result = movie.Delete();

            Assert.IsTrue(result == 1);
        }

    }
}
