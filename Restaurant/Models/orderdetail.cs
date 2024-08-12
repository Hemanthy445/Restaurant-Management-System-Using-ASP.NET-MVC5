using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Restaurant.Models

{
    /* public class orderdetail
     {
         [Key]
         public int OrderDetailId { get; set; }
         [Required]
         [ForeignKey("Order")]
         public int OrderId { get; set; }
         [Required]
         [ForeignKey("Menu")]
         public int MenuId { get; set; }
         [Required]
         [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
         public int Quantity { get; set; }
         [Required]
         [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
         public int Price { get; set; }
         // Navigation properties
         public virtual order Order { get; set; }
         public virtual Menu Menu { get; set; }
     }*/
    public class orderdetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Menu")]
        public int MenuId { get; set; }

        public int Quantity { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        //ublic int Foodprice { get; set; }
        public int TotalPrice { get; set; }

        // Navigation properties
        public virtual order Order { get; set; }
        public virtual menu Menu { get; set; }

    }
}