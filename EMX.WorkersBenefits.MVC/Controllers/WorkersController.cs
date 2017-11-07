using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using EMX.WorkersBenefits.BL.Business;
using EMX.WorkersBenefits.BL.ServiceObjects;

namespace EMX.WorkersBenefits.MVC.Controllers
{
    public class WorkersController : Controller
    {

        //Worker Point-Of-View::
        //WorkerSettingsPage:
        public ActionResult Edit(int workerId)
        {
            var worker = WorkersBL.GetWorker(workerId);
            return View(worker);
        }

        /// <summary>
        /// Saves the given moderated worker info.
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Worker worker)
        {
            if (ModelState.IsValid)
            {
                WorkersBL.SaveWorker(worker);
                return RedirectToAction("Index");
            }
            //ViewBag.company_id = new SelectList(db.companies, "company_id", "name", worker.company_id);
            //ViewBag.identity_user_id = new SelectList(db.users, "Id", "Email", worker.identity_user_id);
            return View(worker);
        }



        //Company Point-Of-View::
        // GET: Worker
        public ActionResult Index()
        {
            return new EmptyResult();
        }








        public JsonResult Details(int workerId)
        {
            var worker = WorkersBL.GetWorker(workerId);
            return Json(worker, JsonRequestBehavior.AllowGet);
        }


    }
}
