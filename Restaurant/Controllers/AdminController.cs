using Restaurant.Models;
using Restaurant.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Restaurant.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Admin
       
        public ActionResult AdminIndex()
        {
            List<menu> menuItems = _context.Menu.ToList();

            // Pass the menu items to the view.
            return View(menuItems);
        }



        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            menu m= _context.Menu.Find(id);
            _context.Menu.Remove(m);
            _context.SaveChanges();
            return RedirectToAction("AdminIndex");
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add( menu mu)
        {
            if (ModelState.IsValid)
            {
                _context.Menu.Add(mu);
                _context.SaveChanges();
                return RedirectToAction("AdminIndex");
            }

            return View(mu);
        }
        public ActionResult EditMenu(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            menu m = _context.Menu.Find(id);
            if(m == null)
            {
                return HttpNotFound();
            }

            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuId,FoodName,FoodPrice,Totalprice,quantity,FoodDescription")] menu m) {
            if (ModelState.IsValid)
            {
                var x = _context.Menu.Find(m.MenuId);
                x.FoodName = m.FoodName;
                x.FoodPrice = m.FoodPrice;
                x.Totalprice = m.Totalprice;
                x.quantity= m.quantity;
                x.FoodDescription = m.FoodDescription;

                _context.SaveChanges();
                return RedirectToAction("AdminIndex");
   
            }

                return RedirectToAction("EditMenu");
        }


        public ActionResult Order()
        {
            var orders = _context.Order.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                TotalPrice = o.TotalPrice,
                OrderDetails = o.OrderDetails.Select(od => new OrderDetailViewModel
                {
                    MenuId = od.MenuId,
                    FoodName = od.Menu.FoodName,
                    Quantity = od.Quantity,
                    TotalPrice= od.TotalPrice,
                    OrderDate = od.OrderDate
                }).ToList()
            }).ToList();

            return View(orders);
        }

    }
}