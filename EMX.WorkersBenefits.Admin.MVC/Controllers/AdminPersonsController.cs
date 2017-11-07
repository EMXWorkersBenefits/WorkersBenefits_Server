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
    public class AdminPersonsController : Controller
    {
        private WorkersBenefitsDB2 db = new WorkersBenefitsDB2();

        // GET: AdminPersons
        public async Task<ActionResult> Index()
        {
            var admin_persons = db.admin_persons.Include(a => a.user);
            return View(await admin_persons.ToListAsync());
        }

        // GET: AdminPersons/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_persons admin_persons = await db.admin_persons.FindAsync(id);
            if (admin_persons == null)
            {
                return HttpNotFound();
            }
            return View(admin_persons);
        }

        // GET: AdminPersons/Create
        public ActionResult Create()
        {
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email");
            return View();
        }

        // POST: AdminPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "admin_person_id,identity_user_id,first_name,last_name,email,phone_number,active,last_update")] admin_persons admin_persons)
        {
            if (ModelState.IsValid)
            {
                db.admin_persons.Add(admin_persons);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", admin_persons.identity_user_id);
            return View(admin_persons);
        }

        // GET: AdminPersons/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_persons admin_persons = await db.admin_persons.FindAsync(id);
            if (admin_persons == null)
            {
                return HttpNotFound();
            }
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", admin_persons.identity_user_id);
            return View(admin_persons);
        }

        // POST: AdminPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "admin_person_id,identity_user_id,first_name,last_name,email,phone_number,active,last_update")] admin_persons admin_persons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin_persons).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", admin_persons.identity_user_id);
            return View(admin_persons);
        }

        // GET: AdminPersons/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_persons admin_persons = await db.admin_persons.FindAsync(id);
            if (admin_persons == null)
            {
                return HttpNotFound();
            }
            return View(admin_persons);
        }

        // POST: AdminPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            admin_persons admin_persons = await db.admin_persons.FindAsync(id);
            db.admin_persons.Remove(admin_persons);
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
