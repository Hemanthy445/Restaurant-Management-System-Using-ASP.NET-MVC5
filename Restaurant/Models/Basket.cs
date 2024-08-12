using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Restaurant.Models;

namespace Restaurant.Models
{
    
    public static class Basket
    {
        static List<menu> basket = null;

        static Basket()
        {
            basket = new List<menu>();
        }
        public static List<menu> Foods
        {
            get
            {
                return basket;
            }
        }
       
        public static void AddFood(menu entity)
        {
            basket.Add(entity);
        }

        public static void DeleteFood(menu entity)
        {
            basket.Remove(entity);
        }

        public static void DeleteAll()
        {
            basket.Clear();
        }

    }
}