using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.PL;
using System.Linq;

namespace BJL.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void Load()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                var orderItems = dc.tblOrderItems;

                int expected = 7;
                int actual = orderItems.Count();

                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void Insert()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                //Create a orderItem
                tblOrderItem orderItem = new tblOrderItem
                {
                    Id = -99,
                    MovieId = 1,
                    OrderId = 1,
                    Quantity = -99
                };

                //Insert the row
                dc.tblOrderItems.Add(orderItem);

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
                tblOrderItem orderItem = dc.tblOrderItems.FirstOrDefault(oi => oi.Id == -99);
                orderItem.Quantity = -98;

                //Save changed property
                dc.SaveChanges();

                tblOrderItem updatedOrderItem = dc.tblOrderItems.FirstOrDefault(oi => oi.Quantity == -98);
                Assert.AreEqual(orderItem.Id, updatedOrderItem.Id);
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblOrderItem orderItem = dc.tblOrderItems.FirstOrDefault(oi => oi.Id == -99);
                dc.tblOrderItems.Remove(orderItem);
                int rowsEffected = dc.SaveChanges();

                Assert.IsTrue(rowsEffected == 1);
            }
        }
    }
}
