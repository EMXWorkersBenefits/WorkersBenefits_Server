using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMX.WorkersBenefits.BL.Business;
using EMX.WorkersBenefits.BL.ServiceObjects;
using EMX.WorkersBenefits.MVC.Helpers;

namespace EMX.WorkersBenefits.MVC.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            int workerId = UserStateManager.Instance.WorkerId;
            return View(ProductsBL.GetOrders(workerId));
        }

        /// <summary>
        /// Submits an order.
        /// </summary>
        /// <returns></returns>
        public ActionResult Submit(Order order)
        {
            ProductsBL.SubmitOrder(order);
            return View(order);
        }
    }
}