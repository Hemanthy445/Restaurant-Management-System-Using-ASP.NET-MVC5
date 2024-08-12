using Microsoft.AspNet.Identity;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AdminIndex", "Admin");
            }
            else
            {
                List<menu> menuItems = _context.Menu.ToList();

                // Pass the menu items to the view.
                return View(menuItems);
               
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Authorize(Roles = "User")]
        public ActionResult Buy()
        {
            var userId = User.Identity.GetUserId();
            var basketItems = Basket.Foods;
            var order = new order { UserId = userId, OrderDetails = new List<orderdetail>() };
            if (Basket.Foods.Count > 0)
            {

                foreach (var item in basketItems)
                {
                    var orderDetail = new orderdetail
                    {
                        MenuId = item.MenuId,
                        Quantity = item.quantity,
                        TotalPrice = item.FoodPrice,
                        OrderDate = DateTime.Now,
                    };
                    order.TotalPrice += item.Totalprice;
                    order.OrderDetails.Add(orderDetail);
                }

                // Save order to database
                _context.Order.Add(order);
                _context.SaveChanges();
                Basket.DeleteAll();

                // Redirect to the Order action to display the order details
                return RedirectToAction("Confirmation");
            }
            else
            {
               return RedirectToAction("Index");
            }
        }
        [Authorize(Roles = "User")]
        public ActionResult Confirmation()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public ActionResult Order()
        {
            var userId = User.Identity.GetUserId();
            var orders = _context.Order.Where(o => o.UserId == userId).ToList();
            return View(orders); 
        }

        /*public ActionResult Buy()
        {
            int orderId = 0;
            if (Basket.Foods.Count > 0)
            {
                user nus = new user();
                nus.Username = "NewUser";
                _context.User.Add(nus);
                _context.SaveChanges();
                var userId = User.Identity.GetUserId(); ;
                order od = new order();

                od.UserId = userId;
                foreach (var item in Basket.Foods)
                {
                    orderdetail ods = new orderdetail();
                    ods.OrderId = orderId;
                    ods.MenuId = item.MenuId;
                    ods.OrderDate = DateTime.Now;
                    ods.Quantity = item.quantity;
                    ods.Foodprice = item.FoodPrice;
                    ods.TotalPrice = item.Totalprice;
                    _context.OrderDetail.Add(ods);
                    _context.SaveChanges();
                }
            }

            return View("About");
        }*/
    }
}