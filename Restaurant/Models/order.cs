using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;

namespace Restaurant.Models
{

    /*public class order
    {
        public order()
        {
            this.OrderDetails = new HashSet<orderdetail>();
        }
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Total price must be a positive number")]
        public int TotalPrice { get; set; }
        // Other necessary properties like OrderDate, etc.
        public virtual ICollection<orderdetail> OrderDetails { get; set; }
    }*/
    public class order
    {
        public order()
        {
            this.OrderDetails = new HashSet<orderdetail>();
        }
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string UserId { get; set; }
        public int TotalPrice { get; set; }
        /*[ForeignKey("User")]
        public string UserId { get; set; }*/
        //blic virtual user User { get; set; }



        public int TotalAmount { get; set; }

        // You can add properties for order status, payment details, etc.

        // Navigation property for order details
        public virtual ICollection<orderdetail> OrderDetails { get; set; }

    }
}