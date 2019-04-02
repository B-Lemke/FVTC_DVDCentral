using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.BL;
using System.Linq;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrder
    {
        [TestMethod]
        public void LoadTest()
        {
            OrderList orders = new OrderList();

            orders.Load();

            int expected = 3;
            int actual = orders.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoadCustIdTest()
        {
            OrderList orders = new OrderList();

            orders.LoadByCustId(2);

            int expected = 1;
            int actual = orders.Count;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void InsertTest()
        {
            //Create a new order and set properties
            Order order = new Order
            {
                CustomerId = 1,
                OrderDate = DateTime.Now,
                PaymentReceipt = "test",
                ShipDate = DateTime.Now.AddDays(1),
                UserId = 1
            };

            //Insert it
            int result = order.Insert();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void UpdateTest()
        {
            OrderList orders = new OrderList();
            orders.Load();

            //Find the order with the description testingorder
            Order order = orders.FirstOrDefault(f => f.PaymentReceipt == "test");

            //Update it and insert it
            order.PaymentReceipt = "updtTest";
            int result = order.Update();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            OrderList orders = new OrderList();
            orders.Load();

            //Find the order with the description testingorder
            Order order = orders.FirstOrDefault(f => f.PaymentReceipt == "updtTest");

            //Delete it
            int result = order.Delete();

            Assert.IsTrue(result == 1);
        }
    }
}
