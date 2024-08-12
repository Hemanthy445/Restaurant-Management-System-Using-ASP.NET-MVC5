using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.ViewModel
{
    public class OrderDetailViewModel
    {
        //public int OrderDetailId { get; set; }
        public int MenuId { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}