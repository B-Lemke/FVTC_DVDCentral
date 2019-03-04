using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.BL;
using System.Linq;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utDirector
    {
        [TestMethod]
        public void LoadTest()
        {
            DirectorList directors = new DirectorList();

            directors.Load();

            int expected = 3;
            int actual = directors.Count;
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            //Create a new director and set properties
            Director director = new Director
            {
                FirstName = "Test",
                LastName = "Name"
            };

            //Insert it
            int result = director.Insert();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            DirectorList directors = new DirectorList();
            directors.Load();

            //Find the director with the description testingdirector
            Director director = directors.FirstOrDefault(f => f.FirstName == "Test");

            //Update it and insert it
            director.LastName = "Updated";
            int result = director.Update();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            DirectorList directors = new DirectorList();
            directors.Load();

            //Find the director with the description testingdirector
            Director director = directors.FirstOrDefault(f => f.FirstName == "Test");

            //Delete it
            int result = director.Delete();

            Assert.IsTrue(result == 1);
        }


    }
}
