using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Restaurant.Models
{
    public class cart
    {
        [Key]
        public int CartItemId { get; set; }

        

        [ForeignKey("Menu")]
        public int MenuId { get; set; }

        public int Quantity { get; set; }

        // Navigation properties
       
        public virtual menu Menu { get; set; }
    }
}