using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMX.WorkersBenefits.MVC.Controllers
{
  /// <inheritdoc />
  /// <summary>
  /// Handles all payments, my cart actions.
  /// </summary>
  public class PaymentsController : Controller
  {
    // GET: Index.
    public ActionResult Index()
    {
      return View("_MyCart");
    }
  }
}