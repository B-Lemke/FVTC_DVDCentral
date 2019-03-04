using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.BL;
using System.Linq;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utRating
    {
        [TestMethod]
        public void LoadTest()
        {
            RatingList ratings = new RatingList();

            ratings.Load();

            int expected = 5;
            int actual = ratings.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            //Create a new rating and set properties
            Rating rating = new Rating
            {
                Description = "tst"
            };

            //Insert it
            int result = rating.Insert();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            RatingList ratings = new RatingList();
            ratings.Load();

            //Find the rating with the description testingrating
            Rating rating = ratings.FirstOrDefault(f => f.Description == "tst");

            //Update it and insert it
            rating.Description = "updt";
            int result = rating.Update();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            RatingList ratings = new RatingList();
            ratings.Load();

            //Find the rating with the description testingrating
            Rating rating = ratings.FirstOrDefault(f => f.Description == "updt");

            //Delete it
            int result = rating.Delete();

            Assert.IsTrue(result == 1);
        }

    }
}
