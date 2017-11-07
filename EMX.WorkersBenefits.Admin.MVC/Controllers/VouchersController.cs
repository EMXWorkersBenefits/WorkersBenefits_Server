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
    public class VouchersController : Controller
    {
        private WorkersBenefitsDB2 db = new WorkersBenefitsDB2();

        // GET: Vouchers
        public async Task<ActionResult> Index()
        {
            return View(await db.vouchers.ToListAsync());
        }

        // GET: Vouchers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voucher voucher = await db.vouchers.FindAsync(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // GET: Vouchers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "voucher_id,image,valid_start_date,valid_end_date,description,active,last_updated")] voucher voucher)
        {
            if (ModelState.IsValid)
            {
                db.vouchers.Add(voucher);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(voucher);
        }

        // GET: Vouchers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voucher voucher = await db.vouchers.FindAsync(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // POST: Vouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "voucher_id,image,valid_start_date,valid_end_date,description,active,last_updated")] voucher voucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voucher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(voucher);
        }

        // GET: Vouchers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voucher voucher = await db.vouchers.FindAsync(id);
            if (voucher == null)
            {
                return HttpNotFound();
            }
            return View(voucher);
        }

        // POST: Vouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            voucher voucher = await db.vouchers.FindAsync(id);
            db.vouchers.Remove(voucher);
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
