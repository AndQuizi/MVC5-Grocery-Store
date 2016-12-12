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
using PagedList;

namespace GroceryStore.Controllers
{
    public class StoreController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Store
        public ViewResult Index(int? foodGroup, int? vendor, string currentFilter, string searchString, int? page)
        {
            ViewBag.Title = "Store";

            // Allow for paging and search filter
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var foods = db.Foods.Include(f => f.FoodGroup).Include(f => f.Vendor);

            // Add searcg string to query
            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(f => f.FoodGroup.Name.Contains(searchString) || f.Vendor.Name.Contains(searchString) || f.Name.Contains(searchString));
            }

            // Add vendor to query
            if (vendor != null)
            {
                foods = foods.Where(f => f.VendorID == vendor);
                var fVendor = (from g in db.Vendors select g).Where(f => f.VendorID == vendor).Single();
                ViewBag.Title += " - " + fVendor.Name;
                ViewBag.Selection += fVendor.Name;
            }

            // Add food group to query
            if (foodGroup != null)
            {
                foods = foods.Where(f => f.FoodGroupID == foodGroup);

                var fGroup = (from g in db.FoodGroups select g).Where(f => f.FoodGroupID == foodGroup).Single();
                ViewBag.Title += " - " + fGroup.Name;
                ViewBag.Selection += (vendor != null ? " - " : " ") + fGroup.Name;
            }
            else
            {
                ViewBag.Selection += (vendor != null ? " - " : " ") + "All Items";
            }
       
          
            foods = foods.OrderBy(f => f.FoodGroup.Name);

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(foods.ToPagedList(pageNumber, pageSize));
        }

        // GET: Store/Details/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [ChildActionOnly]
        public ActionResult FoodGroupMenu()
        {
            var foods = db.FoodGroups.ToList();
            return PartialView(foods);
        }

        [ChildActionOnly]
        public ActionResult VendorMenu()
        {
            var vendors = db.Vendors.ToList();
            return PartialView(vendors);
        }

    }
}
