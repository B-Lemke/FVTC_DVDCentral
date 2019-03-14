using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.BL;
using System.Linq;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void LoadTest()
        {
            CustomerList customers = new CustomerList();

            customers.Load();

            int expected = 3;
            int actual = customers.Count;
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            //Create a new customer and set properties
            Customer customer = new Customer
            {
                FirstName = "Test",
                LastName = "Test",
                Address = "Test",
                City = "Test",
                Phone = "Test",
                State = "TE",
                UserId = 1,
                ZIP = "Test"
            };

            //Insert it
            int result = customer.Insert();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            CustomerList customers = new CustomerList();
            customers.Load();

            //Find the customer with the description testingcustomer
            Customer customer = customers.FirstOrDefault(c => c.FirstName == "Test");

            //Update it and insert it
            customer.LastName = "UpdatedCustomer";
            int result = customer.Update();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            CustomerList customers = new CustomerList();
            customers.Load();

            //Find the customer with the description testingcustomer
            Customer customer = customers.FirstOrDefault(c => c.FirstName == "Test");

            //Delete it
            int result = customer.Delete();

            Assert.IsTrue(result == 1);
        }


    }
}
