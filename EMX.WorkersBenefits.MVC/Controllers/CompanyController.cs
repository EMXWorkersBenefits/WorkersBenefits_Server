using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMX.WorkersBenefits.BL.Business;

namespace EMX.WorkersBenefits.MVC.Controllers
{
  /// <summary>
  /// Home controller for company side.
  /// </summary>
  public class CompanyController : Controller
  {
    // GET: Company
    public ActionResult Index(int id)
    {
      var allWorkers = WorkersBL.GetAllWorkers(id);
      return View(allWorkers);
    }

    public ActionResult Create()
    {
      return new EmptyResult();
    }

    public ActionResult Edit()
    {
      return new EmptyResult();
    }

    public ActionResult Details()
    {
      return new EmptyResult();
    }

    public ActionResult Delete()
    {
      return new EmptyResult();
    }
  }
}
