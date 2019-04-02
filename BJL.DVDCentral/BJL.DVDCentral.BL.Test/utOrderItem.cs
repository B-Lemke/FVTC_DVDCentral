using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BJL.DVDCentral.BL;
using System.Linq;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utOrderItem
    {
        [TestMethod]
        public void LoadTest()
        {
            OrderItemList orderItems = new OrderItemList();

            orderItems.LoadByOrderId(1);

            int expected = 3;
            int actual = orderItems.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertTest()
        {
            //Create a new order and set properties
            OrderItem orderItem = new OrderItem
            {
                OrderId = -99,
                MovieId = -99,
                Quantity = -99
            };

            //Insert it
            int result = orderItem.Insert();

            Assert.IsTrue(result == 1);
        }


        [TestMethod]
        public void UpdateTest()
        {
            OrderItemList orderItems = new OrderItemList();
            orderItems.LoadByOrderId(-99);

            //Find the order with the description testingorder
            OrderItem orderItem = orderItems.FirstOrDefault(o => o.Quantity == -99);

            //Update it and insert it
            orderItem.Quantity = -98;
            int result = orderItem.Update();

            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            OrderItemList orderItems = new OrderItemList();
            orderItems.LoadByOrderId(-99);

            //Find the order with the description testingorder
            OrderItem orderItem = orderItems.FirstOrDefault(f => f.Quantity == -98);

            //Delete it
            int result = orderItem.Delete();

            Assert.IsTrue(result == 1);
        }
    }
}
