using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMX.WorkersBenefits.MVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return new EmptyResult();
        }

        public ActionResult Test()
        {
            return Content("Hi from ori pc !!!");
        }
    }
}