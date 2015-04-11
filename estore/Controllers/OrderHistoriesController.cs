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
    public class OrderHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderHistories
        public ActionResult Index()
        {
            return View(db.OrderHistories.ToList());
        }

        // GET: OrderHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderHistory orderHistory = db.OrderHistories.Find(id);
            if (orderHistory == null)
            {
                return HttpNotFound();
            }
            return View(orderHistory);
        }

        // GET: OrderHistories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,date")] OrderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                db.OrderHistories.Add(orderHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderHistory);
        }

        // GET: OrderHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderHistory orderHistory = db.OrderHistories.Find(id);
            if (orderHistory == null)
            {
                return HttpNotFound();
            }
            return View(orderHistory);
        }

        // POST: OrderHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,date")] OrderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderHistory);
        }

        // GET: OrderHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderHistory orderHistory = db.OrderHistories.Find(id);
            if (orderHistory == null)
            {
                return HttpNotFound();
            }
            return View(orderHistory);
        }

        // POST: OrderHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderHistory orderHistory = db.OrderHistories.Find(id);
            db.OrderHistories.Remove(orderHistory);
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
