using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJL.DVDCentral.PL;

namespace BJL.DVDCentral.BL
{
    public class OrderItem
    {
        //Properties
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }


        public void LoadById()
        {

            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblOrderItem orderItem = dc.tblOrderItems.FirstOrDefault(oi => oi.Id == this.Id);

                        //Make sure that a orderItem was retrieved
                        if (orderItem != null)
                        {
                            //Set the properties on this orderItem
                            this.MovieId = orderItem.MovieId;
                            this.OrderId = orderItem.OrderId;
                            this.Quantity = orderItem.Quantity;

                        }
                        else
                        {
                            throw new Exception("No orderItem to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("OrderItem Id not Valid");
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

                    tblOrderItem orderItem = new tblOrderItem
                    {
                        OrderId = this.OrderId,
                        MovieId = this.MovieId,
                        Quantity = this.Quantity,
                        Id = dc.tblOrderItems.Any() ? dc.tblOrderItems.Max(oi => oi.Id) + 1 : 1

                    };
                    this.Id = orderItem.Id;
                    dc.tblOrderItems.Add(orderItem);

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
                        tblOrderItem orderItem = dc.tblOrderItems.FirstOrDefault(oi => oi.Id == this.Id);

                        //Make sure that a orderItem was retrieved
                        if (orderItem != null)
                        {
                            //Update the proterties on the orderItem
                            orderItem.MovieId = this.MovieId;
                            orderItem.OrderId = this.OrderId;
                            orderItem.Quantity = this.Quantity;


                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No orderItem to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("OrderItem Id not Valid");
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
                        tblOrderItem orderItem = dc.tblOrderItems.FirstOrDefault(oi => oi.Id == this.Id);

                        //Make sure that a orderItem was retrieved
                        if (orderItem != null)
                        {
                            //Update the proterties on the orderItem
                            dc.tblOrderItems.Remove(orderItem);

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No orderItem to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("OrderItem Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class OrderItemList : List<OrderItem>
    {
        public void LoadByOrderId(int OrderId)
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Get the genrs from the database
                    var orderItems = dc.tblOrderItems.Where(oi => oi.OrderId == OrderId);

                    //For each orderItem
                    foreach (tblOrderItem oi in orderItems)
                    {
                        //Make a new orderItem and set its properties
                        OrderItem orderItem = new OrderItem
                        {
                            Id = oi.Id,
                            MovieId = oi.MovieId,
                            Quantity = oi.Quantity,
                            OrderId = oi.OrderId
                        };

                        //Add it to the orderItem list
                        this.Add(orderItem);
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
