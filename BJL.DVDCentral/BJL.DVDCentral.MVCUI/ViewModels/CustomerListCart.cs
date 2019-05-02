using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.ViewModels
{
    public class CustomerListCart
    {
        public ShoppingCart ShoppingCart { get; set; }
        public CustomerList CustomerList { get; set; }

        [DisplayName("Customer")]
        public int CustomerId {get;set;}
    }
}