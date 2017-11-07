using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMX.WorkersBenefits.BL.Business;
using EMX.WorkersBenefits.BL.ServiceObjects;
using log4net;
using Newtonsoft.Json;

namespace EMX.WorkersBenefits.MVC.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Handles all products requests, including category information (without vouchers)
    /// Note: for views: only serves products requests.
    /// </summary>
    public class ProductsController : Controller
    {
        private static readonly ILog m_logger = LogManager.GetLogger(typeof(ProductsController));

        // GET: Index.
        public ActionResult Index()
        {
            return new EmptyResult();
        }

        // GET: Details.
        public ActionResult Details(int id)
        {
            var product = ProductsBL.GetProduct(id);
            return View(product);
        }

        // GET: GetAllProducts.
        /// <summary>
        /// Returns all products in all categories.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllProducts()
        {
            var allProducts = ProductsBL.GetAllProducts();
            return Json(allProducts, JsonRequestBehavior.AllowGet);
        }


        // GET: GetAllProductsInCategory.
        /// <summary>
        /// Returns all products in the given category, ordered by precedence.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllProductsInCategory(int categoryId)
        {
            var allProducts = ProductsBL.GetAllProductsInCategory(categoryId);
            return Json(allProducts, JsonRequestBehavior.AllowGet);
        }


        // GET: GetFeaturedProducts.
        /// <summary>
        /// Returns the featured products, ordered by precedence.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFeaturedProducts()
        {
            FeaturedProductsList featuredList = ProductsBL.GetFeaturedProducts();
            return Content(JsonConvert.SerializeObject(featuredList));
        }

        /// <summary>
        /// Returns all categories
        /// </summary>
        public ActionResult GetAllCategories() => Json(ProductsBL.GetAllCatergories());

        /// <summary>
        /// Returns the suggestions list for the search panel.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSuggestionsList() => Json(ProductsBL.GetSuggestionsList());

        /// <summary>
        /// Applies a search and returns the search results.
        /// </summary>
        /// <returns></returns>
        public ActionResult Search(string search)
        {
            try
            {
                var results = ProductsBL.Search(search);
                return Content(JsonConvert.SerializeObject(results));
            }
            catch (Exception ex)
            {
                m_logger.Error(ex);
                throw;
            }
        }

    }
}
