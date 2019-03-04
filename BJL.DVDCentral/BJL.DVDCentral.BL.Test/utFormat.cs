using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.BL;
using System.Linq;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utFormat
    {
        [TestMethod]
        public void LoadTest()
        {
            FormatList formats = new FormatList();

            formats.Load();

            int expected = 3;
            int actual = formats.Count;
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            //Create a new format and set properties
            Format format = new Format
            {
                Description = "TestingFormat"
            };

            //Insert it
            int result = format.Insert();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            FormatList formats = new FormatList();
            formats.Load();

            //Find the format with the description testingformat
            Format format = formats.FirstOrDefault(f => f.Description == "TestingFormat");

            //Update it and insert it
            format.Description = "UpdatedFormat";
            int result = format.Update();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            FormatList formats = new FormatList();
            formats.Load();

            //Find the format with the description testingformat
            Format format = formats.FirstOrDefault(f => f.Description == "UpdatedFormat");

            //Delete it
            int result = format.Delete();

            Assert.IsTrue(result == 1);
        }


    }
}
