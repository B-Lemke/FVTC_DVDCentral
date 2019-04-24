using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BJL.DVDCentral.BL;

namespace BJL.DVDCentral.MVCUI.ViewModels
{
    public class CustomerOrders
    {
        public Customer Customer { get; set; }
        public OrderList OrderList { get; set; }
    }
}