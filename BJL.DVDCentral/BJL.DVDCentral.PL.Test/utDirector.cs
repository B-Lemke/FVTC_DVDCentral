using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.PL;
using System.Linq;


namespace BJL.DVDCentral.PL.Test
{
    [TestClass]
    public class utDirector
    {
        [TestMethod]
        public void Load()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                var directors = dc.tblDirectors;

                int expected = 3;
                int actual = directors.Count();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Insert()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                //Create a director
                tblDirector director = new tblDirector {
                    Id = -99,
                    FirstName = "TestDirector",
                    LastName = "TestDirector"
                };

                //Insert the row
                dc.tblDirectors.Add(director);

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
                tblDirector director = dc.tblDirectors.FirstOrDefault(d => d.Id == -99);
                director.LastName = "TestingUpdate";

                //Save changed property
                dc.SaveChanges();

                tblDirector updatedDirector = dc.tblDirectors.FirstOrDefault(d => d.LastName == "TestingUpdate");
                Assert.AreEqual(director.Id, updatedDirector.Id);
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblDirector director = dc.tblDirectors.FirstOrDefault(d => d.Id == -99);
                dc.tblDirectors.Remove(director);
                int rowsEffected = dc.SaveChanges();

                Assert.IsTrue(rowsEffected == 1);
            }
        }
    }
}
