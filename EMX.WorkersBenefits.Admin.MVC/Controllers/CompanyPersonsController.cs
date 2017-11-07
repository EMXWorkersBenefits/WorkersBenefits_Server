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
    public class CompanyPersonsController : Controller
    {
        private WorkersBenefitsDB2 db = new WorkersBenefitsDB2();

        // GET: CompanyPersons
        public async Task<ActionResult> Index()
        {
            var company_persons = db.company_persons.Include(c => c.company).Include(c => c.user);
            return View(await company_persons.ToListAsync());
        }

        // GET: CompanyPersons/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_persons company_persons = await db.company_persons.FindAsync(id);
            if (company_persons == null)
            {
                return HttpNotFound();
            }
            return View(company_persons);
        }

        // GET: CompanyPersons/Create
        public ActionResult Create()
        {
            ViewBag.company_id = new SelectList(db.companies, "company_id", "name");
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email");
            return View();
        }

        // POST: CompanyPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "company_person_id,identity_user_id,company_id,first_name,last_name,email,phone_number,active,last_update")] company_persons company_persons)
        {
            if (ModelState.IsValid)
            {
                db.company_persons.Add(company_persons);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.company_id = new SelectList(db.companies, "company_id", "name", company_persons.company_id);
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", company_persons.identity_user_id);
            return View(company_persons);
        }

        // GET: CompanyPersons/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_persons company_persons = await db.company_persons.FindAsync(id);
            if (company_persons == null)
            {
                return HttpNotFound();
            }
            ViewBag.company_id = new SelectList(db.companies, "company_id", "name", company_persons.company_id);
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", company_persons.identity_user_id);
            return View(company_persons);
        }

        // POST: CompanyPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "company_person_id,identity_user_id,company_id,first_name,last_name,email,phone_number,active,last_update")] company_persons company_persons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_persons).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.company_id = new SelectList(db.companies, "company_id", "name", company_persons.company_id);
            ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", company_persons.identity_user_id);
            return View(company_persons);
        }

        // GET: CompanyPersons/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            company_persons company_persons = await db.company_persons.FindAsync(id);
            if (company_persons == null)
            {
                return HttpNotFound();
            }
            return View(company_persons);
        }

        // POST: CompanyPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            company_persons company_persons = await db.company_persons.FindAsync(id);
            db.company_persons.Remove(company_persons);
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
