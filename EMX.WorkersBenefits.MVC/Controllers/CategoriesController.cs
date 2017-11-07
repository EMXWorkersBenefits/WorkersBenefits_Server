using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EMX.WorkersBenefits.BL.ServiceObjects;

namespace EMX.WorkersBenefits.MVC.Controllers
{
  public class CategoriesController : Controller
  {
    // GET: Index.
    public ActionResult Index()
    {
      return View();
    }

    // GET: Details.
    public ActionResult Details(int id)
    {
      return View(new Category(1, "מכשירים חשמליים", "מכשירים חשמליים", "", "", 1));
    }

  }
}