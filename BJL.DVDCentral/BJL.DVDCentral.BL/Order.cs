using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJL.DVDCentral.PL;

namespace BJL.DVDCentral.BL
{
    public class Order
    {
        //Properties
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string PaymentReceipt { get; set; }
        public int UserId { get; set; }
        public int CustomerId { get; set; }

        public void LoadById()
        {

            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblOrder order = dc.tblOrders.FirstOrDefault(o => o.Id == this.Id);

                        //Make sure that a order was retrieved
                        if (order != null)
                        {
                            //Set the properties on this order
                            this.CustomerId = order.CustomerId;
                            this.UserId = order.UserId;
                            this.OrderDate = order.OrderDate;
                            this.ShipDate = order.ShipDate;
                            this.PaymentReceipt = order.PaymentReceipt;

                        }
                        else
                        {
                            throw new Exception("No order to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Order Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Insert()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {

                    tblOrder order = new tblOrder
                    {
                        PaymentReceipt = this.PaymentReceipt,
                        ShipDate = this.ShipDate,
                        OrderDate =  this.OrderDate,
                        CustomerId = this.CustomerId,
                        UserId = this.UserId,
                        Id = dc.tblOrders.Any() ? dc.tblOrders.Max(o => o.Id) + 1 : 1

                    };
                    this.Id = order.Id;
                    dc.tblOrders.Add(order);

                    //Return the rows effected
                    return dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int Update()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblOrder order = dc.tblOrders.FirstOrDefault(o => o.Id == this.Id);

                        //Make sure that a order was retrieved
                        if (order != null)
                        {
                            //Update the proterties on the order
                            order.PaymentReceipt = this.PaymentReceipt;
                            order.ShipDate = this.ShipDate;
                            order.OrderDate = this.OrderDate;
                            order.CustomerId = this.CustomerId;
                            order.UserId = this.UserId;
                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No order to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Order Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblOrder order = dc.tblOrders.FirstOrDefault(o => o.Id == this.Id);

                        //Make sure that a order was retrieved
                        if (order != null)
                        {
                            //Update the proterties on the order
                            dc.tblOrders.Remove(order);

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No order to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Order Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class OrderList : List<Order>
    {
        public void Load()
        {
            try
            {
                LoadByCustId(null);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void LoadByCustId(int? custId)
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {

                    
                    //Get the orders

                    var orders = dc.tblOrders.Where(o => o.CustomerId == custId || custId == null);
               

                    //For each order
                    foreach (tblOrder o in orders)
                    {
                        //Make a new order and set its properties
                        Order order = new Order
                        {
                            Id = o.Id,
                            PaymentReceipt = o.PaymentReceipt,
                            ShipDate = o.ShipDate,
                            OrderDate = o.OrderDate,
                            CustomerId = o.CustomerId,
                            UserId = o.UserId,
                        };

                        //Add it to the order list
                        this.Add(order);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
