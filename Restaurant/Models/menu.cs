using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class menu

    {
        [Key]
        public int MenuId { get; set; }
        [Required]
        [StringLength(50)]
        public string FoodName { get; set; }


        [DataType(DataType.Currency)]
        public int FoodPrice { get; set; }
       public int Totalprice {  get; set; }
       public int quantity { get; set; }

        [StringLength(500)]
        public string FoodDescription { get; set; }
    }
}