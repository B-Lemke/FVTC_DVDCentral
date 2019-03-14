using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJL.DVDCentral.PL;

namespace BJL.DVDCentral.BL
{
    public class Customer
    {
        //Properties
        public int Id { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string City { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public int UserId { get; set; }
        public string ZIP { get; set; }

        public void LoadById()
        {

            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Make sure that the ID is set and valid
                    if (this.Id >= 0)
                    {
                        tblCustomer customer = dc.tblCustomers.FirstOrDefault(c => c.Id == this.Id);

                        //Make sure that a customer was retrieved
                        if (customer != null)
                        {
                            //Set the properties on this customer
                            this.FirstName = customer.FirstName;
                            this.LastName = customer.LastName;
                            this.Address = customer.Address;
                            this.City = customer.City;
                            this.Phone = customer.Phone;
                            this.State = customer.State;
                            this.UserId = customer.UserId;
                            this.ZIP = customer.ZIP;

                        }
                        else
                        {
                            throw new Exception("No customer to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Customer Id not Valid");
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

                    tblCustomer customer = new tblCustomer
                    {
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        Address = this.Address,
                        City = this.City,
                        Phone = this.Phone,
                        State = this.State,
                        UserId = this.UserId,
                        ZIP = this.ZIP,
                        Id = dc.tblCustomers.Any() ? dc.tblCustomers.Max(c => c.Id) + 1 : 1

                    };
                    this.Id = customer.Id;
                    dc.tblCustomers.Add(customer);

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
                        tblCustomer customer = dc.tblCustomers.FirstOrDefault(c => c.Id == this.Id);

                        //Make sure that a customer was retrieved
                        if (customer != null)
                        {
                            //Update the proterties on the customer
                            customer.FirstName = this.FirstName;
                            customer.LastName = this.LastName;
                            customer.Address = this.Address;
                            customer.City = this.City;
                            customer.Phone = this.Phone;
                            customer.State = this.State;
                            customer.UserId = this.UserId;
                            customer.ZIP = this.ZIP;
                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No customer to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Customer Id not Valid");
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
                        tblCustomer customer = dc.tblCustomers.FirstOrDefault(c => c.Id == this.Id);

                        //Make sure that a customer was retrieved
                        if (customer != null)
                        {
                            //Update the proterties on the customer
                            dc.tblCustomers.Remove(customer);

                            //return the number of rows effected
                            return dc.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("No customer to load with this Id");
                        }
                    }
                    else
                    {
                        throw new Exception("Customer Id not Valid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

    public class CustomerList : List<Customer>
    {
        public void Load()
        {
            try
            {
                using (DVDEntities dc = new DVDEntities())
                {
                    //Get the genrs from the database
                    var customers = dc.tblCustomers;

                    //For each customer
                    foreach (tblCustomer c in customers)
                    {
                        //Make a new customer and set its properties
                        Customer customer = new Customer
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Address = c.Address,
                            City = c.City,
                            Phone = c.Phone,
                            State = c.State,
                            UserId = c.UserId,
                            ZIP = c.ZIP
                        };

                        //Add it to the customer list
                        this.Add(customer);
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
