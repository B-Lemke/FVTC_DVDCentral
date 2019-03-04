using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.BL;
using System.Linq;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void LoadTest()
        {
            GenreList genres = new GenreList();

            genres.Load();

            int expected = 10;
            int actual = genres.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            //Create a new genre and set properties
            Genre genre = new Genre
            {
                Description = "TestingGenre"
            };

            //Insert it
            int result = genre.Insert();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            GenreList genres = new GenreList();
            genres.Load();

            //Find the genre with the description testinggenre
            Genre genre = genres.FirstOrDefault(f => f.Description == "TestingGenre");

            //Update it and insert it
            genre.Description = "UpdatedGenre";
            int result = genre.Update();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            GenreList genres = new GenreList();
            genres.Load();

            //Find the genre with the description testinggenre
            Genre genre = genres.FirstOrDefault(f => f.Description == "UpdatedGenre");

            //Delete it
            int result = genre.Delete();

            Assert.IsTrue(result == 1);
        }

    }
}
