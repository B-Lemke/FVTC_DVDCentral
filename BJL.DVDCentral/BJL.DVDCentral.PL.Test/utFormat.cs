using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.PL;
using System.Linq;

namespace BJL.DVDCentral.PL.Test
{
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void Load()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                var formats = dc.tblFormats;

                int expected = 3;
                int actual = formats.Count();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Insert()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                //Create a format
                tblFormat format = new tblFormat
                {
                    Id = -99,
                    Description = "TestFormat"
                };

                //Insert the row
                dc.tblFormats.Add(format);

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
                tblFormat format = dc.tblFormats.FirstOrDefault(f => f.Id == -99);
                format.Description = "TestingUpdate";

                //Save changed property
                dc.SaveChanges();

                tblFormat updatedFormat = dc.tblFormats.FirstOrDefault(f => f.Description == "TestingUpdate");
                Assert.AreEqual(format.Id, updatedFormat.Id);
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblFormat format = dc.tblFormats.FirstOrDefault(f => f.Id == -99);
                dc.tblFormats.Remove(format);
                int rowsEffected = dc.SaveChanges();

                Assert.IsTrue(rowsEffected == 1);
            }
        }
    }
}
