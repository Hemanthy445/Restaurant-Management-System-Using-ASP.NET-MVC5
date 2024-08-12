using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurant.Models;


namespace Restaurant.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            int total = 0;
           //    int RestaurantId = 0;
            if (Basket.Foods.Count > 0)
            {
                total = Basket.Foods.Sum(x => x.Totalprice);

            }
           // ViewBag.RestaurantId = RestaurantId;
            ViewBag.total = "Total price of your basket" + total + " TL";
            return View();
        }

        [HttpPost]
        public void BasketAdd(int id)
        {
            
            menu menuitem = db.Menu.FirstOrDefault(x => x.MenuId == id);  
            bool Foodexist = false;
            foreach (var item in Basket.Foods)
            {
                if (item.MenuId == id)
                {
                    Foodexist = true;
                    item.Totalprice += item.FoodPrice;
                    item.quantity++;
                }
            }

            bool basketbag = false;
            if (Basket.Foods.Count >= 0)
            {
                basketbag = true;
            }
            if (Foodexist == false)
            {
                if (basketbag == true)
                {
                    menuitem.Totalprice += menuitem.FoodPrice;
                    menuitem.quantity++;
                    Basket.AddFood(menuitem);
                }
            }
            
        }
        [HttpPost]
        public void Increase(int id)
        {
            foreach (var item in Basket.Foods)
            {
                if (item.MenuId == id)
                {
                    item.Totalprice += item.FoodPrice;
                    item.quantity++;
                }
            }
        }

        [HttpPost]
        public void Decrease(int id)
        {
            foreach (var item in Basket.Foods)
            {
                if (item.MenuId == id)
                {
                  if (item.quantity > 1)
                    {
                        item.quantity--;
                        item.Totalprice -= item.FoodPrice;
                    }
                }
            }
        }

        [HttpPost]
        public void Delete(int id)
        {
            menu deleteFood = new menu();
            foreach (var item in Basket.Foods)
            {
                if (item.MenuId == id)
                {
                    deleteFood = item;
                }
            }
            Basket.DeleteFood(deleteFood);
        }

        [HttpPost]
        public void DeleteAll()
        {
            Basket.DeleteAll();
        }


















        /*   // GET: Cart
           public ActionResult Index()
           {
               return View(db.Menu.ToList());
           }

           // GET: Cart/Details/5
           public ActionResult Details(int? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               menu menu = db.Menu.Find(id);
               if (menu == null)
               {
                   return HttpNotFound();
               }
               return View(menu);
           }

           // GET: Cart/Create
           public ActionResult Create()
           {
               return View();
           }

           // POST: Cart/Create
           // To protect from overposting attacks, enable the specific properties you want to bind to, for 
           // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
           [HttpPost]
           [ValidateAntiForgeryToken]
           public ActionResult Create([Bind(Include = "MenuId,FoodName,FoodPrice,FoodDescription")] menu menu)
           {
               if (ModelState.IsValid)
               {
                   db.Menu.Add(menu);
                   db.SaveChanges();
                   return RedirectToAction("Index");
               }

               return View(menu);
           }

           // GET: Cart/Edit/5
           public ActionResult Edit(int? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               menu menu = db.Menu.Find(id);
               if (menu == null)
               {
                   return HttpNotFound();
               }
               return View(menu);
           }

           // POST: Cart/Edit/5
           // To protect from overposting attacks, enable the specific properties you want to bind to, for 
           // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
           [HttpPost]
           [ValidateAntiForgeryToken]
           public ActionResult Edit([Bind(Include = "MenuId,FoodName,FoodPrice,FoodDescription")] menu menu)
           {
               if (ModelState.IsValid)
               {
                   db.Entry(menu).State = EntityState.Modified;
                   db.SaveChanges();
                   return RedirectToAction("Index");
               }
               return View(menu);
           }

           // GET: Cart/Delete/5
           public ActionResult Delete(int? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               menu menu = db.Menu.Find(id);
               if (menu == null)
               {
                   return HttpNotFound();
               }
               return View(menu);
           }

           // POST: Cart/Delete/5
           [HttpPost, ActionName("Delete")]
           [ValidateAntiForgeryToken]
           public ActionResult DeleteConfirmed(int id)
           {
               menu menu = db.Menu.Find(id);
               db.Menu.Remove(menu);
               db.SaveChanges();
               return RedirectToAction("Index");
           }

           protected override void Dispose(bool disposing)
           {
               if (disposing)
               {
                   db.Dispose();
               }
               base.Dispose(disposing);
           }
       }
        */
    }
}
