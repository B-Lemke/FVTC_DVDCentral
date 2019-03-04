using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.PL;
using System.Linq;

namespace BJL.DVDCentral.PL.Test
{
    [TestClass]
    public class utGenre
    {
        [TestMethod]
        public void Load()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                var genres = dc.tblGenres;

                int expected = 10;
                int actual = genres.Count();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Insert()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                //Create a genre
                tblGenre genre = new tblGenre
                {
                    Id = -99,
                    Description = "TestGenre"
                };

                //Insert the row
                dc.tblGenres.Add(genre);

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
                tblGenre genre = dc.tblGenres.FirstOrDefault(g => g.Id == -99);
                genre.Description = "UpdateGenre";

                //Save changed property
                dc.SaveChanges();

                tblGenre updatedGenre = dc.tblGenres.FirstOrDefault(g => g.Description == "UpdateGenre");
                Assert.AreEqual(genre.Id, updatedGenre.Id);
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblGenre genre = dc.tblGenres.FirstOrDefault(g => g.Id == -99);
                dc.tblGenres.Remove(genre);
                int rowsEffected = dc.SaveChanges();

                Assert.IsTrue(rowsEffected == 1);
            }
        }
    }
}
