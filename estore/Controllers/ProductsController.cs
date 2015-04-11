using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using estore.Models;

namespace estore.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        //public ActionResult Index()
        //{
        //    var products = db.Products.Include(p => p.Category);
        //    return View(products);
        //}

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {

            List<Category> categories = new List<Category>();
            return View();
        }

        public ViewResult Index(string sortOrder, string searchString)
        {
            
        ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Title Asc" : "";
        ViewBag.AgeSortParm = sortOrder == "Age" ? " desc" : "Age";
        var products = from p in db.Products
        select p;
        switch (sortOrder)
        {
            case "Title Asc":
            products= products.OrderByDescending(p => p.Title);
            break;
           case "Price":
            products = products.OrderBy(p => p.Price);
            break;
           case "Category":
            products = products.OrderByDescending(p => p.Category);
            break;
           case "Manufacturer":
            products = products.OrderByDescending(p => p.Manufacturer);
            break;
            default:
            products = products.OrderBy(p => p.Title);
                break;
   }
            if (!String.IsNullOrEmpty(searchString))
            {
            
            var titlematches = products.Where(p => p.Title.ToUpper().Contains(searchString.ToUpper()));
            var manufacturermatches = products.Where(p => p.Manufacturer.ToUpper().Contains(searchString.ToUpper()));
            List<Product> resultset = new List<Product>();
            resultset.AddRange(titlematches);
            foreach(var item in manufacturermatches)
                if (!resultset.Contains(item))
                    resultset.Add(item);
            
            return View(resultset);
            }

            return View(products.ToList());
}



        // POST: Products/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Manufacturer,Title,Price,imageRef,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Manufacturer,Title,Price,imageRef,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
}
