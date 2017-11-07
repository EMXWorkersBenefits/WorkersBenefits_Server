using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMX.WorkersBenefits.DAL.Models;

namespace EMX.WorkersBenefits.Admin.MVC.Controllers
{
    public class OrdersController : Controller
    {
        private WorkersBenefitsDB2 db = new WorkersBenefitsDB2();

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            var orders = db.orders.Include(o => o.worker);
            return View(await orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = await db.orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            //ViewBag.order_item_type_id = new SelectList(db.order_item_types, "id", "name");
            ViewBag.worker_id = new SelectList(db.workers, "worker_id", "identity_user_id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "order_id,order_uid,worker_id,order_item_type_id,credit_card_auth_id,charge_amount,order_date,comments")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.order_item_type_id = new SelectList(db.order_item_types, "id", "name", order.order_item_type_id);
            ViewBag.worker_id = new SelectList(db.workers, "worker_id", "identity_user_id", order.worker_id);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = await db.orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            //ViewBag.order_item_type_id = new SelectList(db.order_item_types, "id", "name", order.order_item_type_id);
            ViewBag.worker_id = new SelectList(db.workers, "worker_id", "identity_user_id", order.worker_id);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "order_id,order_uid,worker_id,order_item_type_id,credit_card_auth_id,charge_amount,order_date,comments")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.order_item_type_id = new SelectList(db.order_item_types, "id", "name", order.order_item_type_id);
            ViewBag.worker_id = new SelectList(db.workers, "worker_id", "identity_user_id", order.worker_id);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = await db.orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            order order = await db.orders.FindAsync(id);
            db.orders.Remove(order);
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
