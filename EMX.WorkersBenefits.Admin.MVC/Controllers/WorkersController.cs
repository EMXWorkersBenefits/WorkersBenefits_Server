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
    public class WorkersController : Controller
    {
        private WorkersBenefitsDB2 db = new WorkersBenefitsDB2();

        // GET: Workers
        public async Task<ActionResult> Index()
        {
            var workers = db.workers.Include(w => w.company).Include(w => w.user);
            return View(await workers.ToListAsync());
        }

        // GET: Workers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            worker worker = await db.workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            ViewBag.company_id = new SelectList(db.companies, "company_id", "name");
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "worker_id,identity_user_id,company_id,worker_number,id_number,first_name,last_name,email,phone_number,active,last_update")] worker worker)
        {
            if (ModelState.IsValid)
            {
                db.workers.Add(worker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.company_id = new SelectList(db.companies, "company_id", "name", worker.company_id);
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", worker.identity_user_id);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            worker worker = await db.workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.company_id = new SelectList(db.companies, "company_id", "name", worker.company_id);
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", worker.identity_user_id);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "worker_id,identity_user_id,company_id,worker_number,id_number,first_name,last_name,email,phone_number,active,last_update")] worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.company_id = new SelectList(db.companies, "company_id", "name", worker.company_id);
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", worker.identity_user_id);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            worker worker = await db.workers.FindAsync(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            worker worker = await db.workers.FindAsync(id);
            db.workers.Remove(worker);
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
