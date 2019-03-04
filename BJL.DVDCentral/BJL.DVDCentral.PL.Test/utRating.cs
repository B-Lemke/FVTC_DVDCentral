using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.PL;
using System.Linq;

namespace BJL.DVDCentral.PL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void Load()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                var ratings = dc.tblRatings;

                int expected = 5;
                int actual = ratings.Count();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Insert()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                //Create a rating
                tblRating rating = new tblRating
                {
                    Id = -99,
                    Description = "Test"
                };

                //Insert the row
                dc.tblRatings.Add(rating);

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
                tblRating rating = dc.tblRatings.FirstOrDefault(r => r.Id == -99);
                rating.Description = "Updt";

                //Save changed property
                dc.SaveChanges();

                tblRating updatedRating = dc.tblRatings.FirstOrDefault(r => r.Description == "Updt");
                Assert.AreEqual(rating.Id, updatedRating.Id);
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblRating rating = dc.tblRatings.FirstOrDefault(r => r.Id == -99);
                dc.tblRatings.Remove(rating);
                int rowsEffected = dc.SaveChanges();

                Assert.IsTrue(rowsEffected == 1);
            }
        }
    }
}
