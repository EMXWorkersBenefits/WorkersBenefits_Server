using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMX.WorkersBenefits.BL.Business;
using EMX.WorkersBenefits.MVC.Helpers;

namespace EMX.WorkersBenefits.MVC.Controllers
{
    /// <summary>
    /// Acts as the facad'e for all vouchers activities
    /// </summary>
    public class VouchersController : Controller
    {
        // GET: Voucher
        /// <summary>
        /// Returns all worker's vouchers.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int worker_Id = UserStateManager.Instance.WorkerId;
            var all = VouchersBL.GetAll(worker_Id);
            return View(all);
        }


        // GET: Details.
        public ActionResult Details(int id)
        {
            var item = VouchersBL.GetVoucher(id);
            return View(item);
        }
    }
}
