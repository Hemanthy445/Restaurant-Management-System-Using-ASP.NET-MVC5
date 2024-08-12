using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int TotalPrice { get; set; } // Assuming TotalPrice is an int
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }
}