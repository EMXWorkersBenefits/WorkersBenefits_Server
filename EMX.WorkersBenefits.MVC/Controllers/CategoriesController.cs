using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EMX.WorkersBenefits.BL.Business;
using EMX.WorkersBenefits.BL.ServiceObjects;
using Newtonsoft.Json;

namespace EMX.WorkersBenefits.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Index.
        public ActionResult Index()
        {
            return View();
        }

        // API GET: GetFeaturedCategories.
        /// <summary>
        /// Returns the featured categories, ordered by precedence.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFeaturedCategories()
        {
            FeaturedCategoriesList featuredList = ProductsBL.GetFeaturedCategories();
            return Content(JsonConvert.SerializeObject(featuredList));
        }

        // API GET: GetFeaturedCategoriesFull.
        /// <summary>
        /// Returns the featured categories and their corresponding featured products, ordered by precedence.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFeaturedCategoriesFull()
        {
            FeaturedCategoriesList featuredList = ProductsBL.GetFeaturedCategories(true);
            return Content(JsonConvert.SerializeObject(featuredList));
        }

        // API GET: GetCategory.
        public ActionResult GetCategory(int id)
        {
            return Json(ProductsBL.GetCategory(id), JsonRequestBehavior.AllowGet);
        }


        // GET: Details.
        public ActionResult Details(int id)
        {
            return View(ProductsBL.GetCategory(id));
        }

    }
}