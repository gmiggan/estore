using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using estore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace estore.Controllers
{
    public class CreditCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreditCards
        public ActionResult Index()
        {
            return View(db.CreditCards.ToList());
        }

        // GET: CreditCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            return View(creditCard);
        }

        // GET: CreditCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cardNumber,expiryMonth,expiryYear,type")] CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                CreditCard credCard = null;
                if (creditCard.type == "AmericanExpress")
                    credCard = new AmericanExpressCard(creditCard.cardNumber, creditCard.expiryMonth, creditCard.expiryYear);
                else if (creditCard.type == "MasterCard")
                    credCard = new MasterCard(creditCard.cardNumber, creditCard.expiryMonth, creditCard.expiryYear);
                else if (creditCard.type == "Visa")
                    credCard = new VisaCard(creditCard.cardNumber, creditCard.expiryMonth, creditCard.expiryYear);

                credCard.user = db.Users.Find(User.Identity.GetUserId());
                if (credCard.validate())
                {
                    db.CreditCards.Add(credCard);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                List<Product> products = (List<Product>) Session["cart"];
                foreach(var item in products)
                {
                    OrderHistory hist = new OrderHistory();
                    hist.date = new DateTime();
                    hist.user = db.Users.Find(User.Identity.GetUserId());
                    hist.product = item;
                    db.OrderHistories.Add(hist);
                    db.SaveChanges();
                }

            }
            return View("Create");
        }

        // GET: CreditCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            return View(creditCard);
        }

        // POST: CreditCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cardNumber,expiryMonth,expiryYear")] CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creditCard);
        }

        // GET: CreditCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCard creditCard = db.CreditCards.Find(id);
            if (creditCard == null)
            {
                return HttpNotFound();
            }
            return View(creditCard);
        }

        // POST: CreditCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCard creditCard = db.CreditCards.Find(id);
            db.CreditCards.Remove(creditCard);
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
