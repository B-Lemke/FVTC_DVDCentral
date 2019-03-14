using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.PL;
using System.Linq;

namespace BJL.DVDCentral.PL.Test
{
    [TestClass]
    public class utCustomer
    {
        [TestMethod]
        public void Load()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                var customers = dc.tblCustomers;

                int expected = 3;
                int actual = customers.Count();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Insert()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                //Create a customer
                tblCustomer customer = new tblCustomer
                {
                    Id = -99,
                    FirstName = "Test",
                    Address = "999 Test Ave",
                    LastName = "Test",
                    City = "Test",
                    Phone = "(920)555-5555",
                    State = "WI",
                    UserId = -99,
                    ZIP = "54934"
                
                };

                //Insert the row
                dc.tblCustomers.Add(customer);

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
                tblCustomer customer = dc.tblCustomers.FirstOrDefault(c => c.Id == -99);
                customer.FirstName = "TestingUpdate";

                //Save changed property
                dc.SaveChanges();

                tblCustomer updatedCustomer = dc.tblCustomers.FirstOrDefault(c => c.FirstName == "TestingUpdate");
                Assert.AreEqual(customer.Id, updatedCustomer.Id);
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblCustomer customer = dc.tblCustomers.FirstOrDefault(c => c.Id == -99);
                dc.tblCustomers.Remove(customer);
                int rowsEffected = dc.SaveChanges();

                Assert.IsTrue(rowsEffected == 1);
            }
        }
    }
}
