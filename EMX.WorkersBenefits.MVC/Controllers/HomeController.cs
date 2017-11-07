using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMX.WorkersBenefits.BL.Business;
using EMX.WorkersBenefits.BL.ServiceObjects;
using EMX.WorkersBenefits.MVC.Models;

namespace EMX.WorkersBenefits.MVC.Controllers
{
    /// <summary>
    /// Home controller for worker and company sides.
    /// </summary>
    public class HomeController : Controller
    {

        //Workers Point-Of-View:::
        //MainPage:

        public ActionResult Index()
        {
            string clientMode = System.Configuration.ConfigurationManager.AppSettings["ClientMode"].ToString();
            bool isMVC = clientMode.ToLower() == "MVC".ToLower();

            if (isMVC)
            {
                return View("IndexMVC");
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Returns the current worker's company logo.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public string GetCompanyLogo(int companyId)
        {
            Company company = CompaniesBL.GetCompany(companyId);
            return company.Logo;
        }

        /// <summary>
        /// Returns the categories list (for the main menu)
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCategories()
        {
            return Json(ProductsBL.GetAllCatergories());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "צור קשר :";

            return View();
        }

        public ActionResult Contact(ContactUsViewModel data)
        {
            ViewBag.Message = "צור קשר :";
            WorkersBL.SendContactUs(data.Subject, data.Content);
            return View();
        }


        //Company Point-of-view:::
        [ActionName("Index")]
        public ActionResult CompanyIndex()
        {
            string clientMode = System.Configuration.ConfigurationManager.AppSettings["ClientMode"].ToString();
            bool isMVC = clientMode.ToLower() == "MVC".ToLower();

            if (isMVC)
            {
                return View("IndexMVC");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Test()
        {
            return View("");
        }

    }
}
