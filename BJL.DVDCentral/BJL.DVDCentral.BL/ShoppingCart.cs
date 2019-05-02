using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BJL.DVDCentral.BL
{
    public class ShoppingCart
    {
        public int CustomerId { get; set; }
        public MovieList Items { get; set; }
        public int TotalCount
        {
            get { return Items.Count; }
        }

        public double TotalCost
        {
            get
            {
                decimal total = 0;
                Items.ForEach(m => total += m.Cost);
                return (double)total;
            }
        }

        public double Tax
        {
            get
            {
                return TotalCost * 0.05;
            }
        }

        public double PostTaxTotal
        {
            get
            {
                return TotalCost + Tax;
            }
        }

        public ShoppingCart()
        {
            Items = new MovieList();
        }



        public void CheckOut(int userId)
        {
            try
            {
                if (Items.Count > 0)
                {
                    //Create the order
                    Order order = new Order();
                    order.OrderDate = DateTime.Now;
                    order.ShipDate = DateTime.Now.AddDays(5);
                    order.UserId = userId;
                    order.CustomerId = CustomerId;
                    order.PaymentReceipt = "";

                    order.Insert();

                    //Add an order item for each movie
                    foreach (Movie movie in Items)
                    {
                        OrderItem orderItem = new OrderItem();
                        orderItem.MovieId = movie.Id;
                        orderItem.OrderId = order.Id;
                        orderItem.Quantity = 1;

                        orderItem.Insert();
                    }

                    this.Items = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Add(Movie movie)
        {
            Items.Add(movie);
        }

        public void Remove(Movie movie)
        {
            Items.Remove(movie);
        }

    }
}
