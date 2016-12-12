using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroceryStore.DAL;
using GroceryStore.Models;
using Microsoft.AspNet.Identity;

namespace GroceryStore.Controllers
{
    public class ManagerController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Manager

        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Index()
        {
            var foods = db.Foods.Include(f => f.FoodGroup).Include(f => f.Vendor);
            return View(await foods.ToListAsync());
        }

        // GET: Manager/Details/5
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = await db.Foods.FindAsync(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Manager/Create
        [Authorize(Roles = "Manager")]
        public ActionResult Create()
        {
            ViewBag.FoodGroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name");
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "Name");
            return View();
        }

        // POST: Manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Create([Bind(Include = "FoodID,VendorID,FoodGroupID,Name,Price,Description,Weight,ExpiryDate,Stock")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FoodGroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.FoodGroupID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "Name", food.VendorID);
            return View(food);
        }

        // GET: Manager/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = await db.Foods.FindAsync(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodGroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.FoodGroupID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "Name", food.VendorID);
            return View(food);
        }

        // POST: Manager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Edit([Bind(Include = "FoodID,VendorID,FoodGroupID,Name,Price,Description,Weight,ExpiryDate,Stock")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FoodGroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.FoodGroupID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "Name", food.VendorID);
            return View(food);
        }

        // GET: Manager/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = await db.Foods.FindAsync(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Food food = await db.Foods.FindAsync(id);
            db.Foods.Remove(food);
            await db.SaveChangesAsync();
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
}
