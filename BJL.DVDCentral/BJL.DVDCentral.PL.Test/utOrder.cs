using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.PL;
using System.Linq;

namespace BJL.DVDCentral.PL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void Load()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                var orders = dc.tblOrders;

                int expected = 3;
                int actual = orders.Count();

                Assert.AreEqual(expected, actual);
            }
        }


        [TestMethod]
        public void Insert()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                //Create a order
                tblOrder order = new tblOrder
                {
                    Id = -99,
                    OrderDate = DateTime.Now,
                    PaymentReceipt = "test",
                    ShipDate = DateTime.Now.AddDays(1),
                    UserId = 1,
                    CustomerId = 1
                };

                //Insert the row
                dc.tblOrders.Add(order);

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
                tblOrder order = dc.tblOrders.FirstOrDefault(o => o.Id == -99);
                order.PaymentReceipt = "UpdateOrder";

                //Save changed property
                dc.SaveChanges();

                tblOrder updatedOrder = dc.tblOrders.FirstOrDefault(o => o.PaymentReceipt == "UpdateOrder");
                Assert.AreEqual(order.Id, updatedOrder.Id);
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (DVDEntities dc = new DVDEntities())
            {
                tblOrder order = dc.tblOrders.FirstOrDefault(o => o.Id == -99);
                dc.tblOrders.Remove(order);
                int rowsEffected = dc.SaveChanges();

                Assert.IsTrue(rowsEffected == 1);
            }
        }
    }
}
