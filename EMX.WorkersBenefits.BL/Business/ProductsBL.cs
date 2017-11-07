using System.Collections.Generic;
using System.Linq;
using EMX.WorkersBenefits.BL.ServiceObjects;
using EMX.WorkersBenefits.DAL.Models;

namespace EMX.WorkersBenefits.BL.Business
{
    /// <summary>
    /// Handles all activities around products, catergories and orders (not including vouchers).
    /// </summary>
    public static class ProductsBL
    {
        //MainPage:
        public static FeaturedProductsList GetFeaturedProducts()
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var items = db.products.Take(10).AsEnumerable()
                    .Select(ServiceObjectsExtensions.ToSvc)
                    .OrderBy(item => item.Precedence).ToList();
                return new FeaturedProductsList(items);    //todo. add random
            }
        }

        /// <summary>
        /// Applies a search and returns the search results.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static ProductsSearchResults Search(string criteria)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var items = db.products.Take(10).AsEnumerable()
                    .Where(item => item.title.Contains(criteria)).AsEnumerable()
                    .Select(ServiceObjectsExtensions.ToSvc)
                    .OrderBy(item => item.Precedence).ToList();
                return new ProductsSearchResults(items);    //todo. add random
            }
        }

        /// <summary>
        /// Returns all categories in the systems.
        /// sequence is returned in the order of precedence.
        /// </summary>
        /// <returns></returns>
        public static List<Category> GetAllCategories()
        {
            using (var db = new WorkersBenefitsDB2())
            {
                return db.categories
                    .Select(ServiceObjectsExtensions.ToSvc)
                    .OrderBy(item => item.Precedence)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns the most featured product in the given category.
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetFeaturedProduct(int categoryId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                return db.products
                    .Where(item => item.category_id == categoryId).AsEnumerable()
                    .Select(ServiceObjectsExtensions.ToSvc).ToList();
            }
        }


        //CategoryPage:

        public static Category GetCategory(int categoryId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var dbObj = db.categories
                    .SingleOrDefault(item => item.category_id == categoryId);

                return dbObj?.ToSvc();
            }
        }

        /// <summary>
        /// Returns all products in the specified category.
        /// sequence is returned in the view precedence.
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProductsInCategory(int categoryId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                return db.products
                    .Where(item => item.category_id == categoryId).AsEnumerable()
                    .Select(ServiceObjectsExtensions.ToSvc).ToList();
            }
        }

        public static Product GetProduct(int productId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var dbObj = db.products
                    .SingleOrDefault(item => item.product_id == productId);

                return dbObj?.ToSvc();
            }
        }

        //Orders Page:
        /// <summary>
        /// Returns all orders associated with the given workerId.
        /// </summary>
        /// <param name="workerId"></param>
        /// <returns></returns>
        public static List<Order> GetOrders(int workerId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                return db.orders.Where(item => item.worker_id == workerId)
                    .AsEnumerable()
                    .Select(ServiceObjectsExtensions.ToSvc)
                    .ToList();
            }
        }

        public static Order GetOrder(int orderId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var dbObj = db.orders
                    .SingleOrDefault(item => item.order_id == orderId);

                return dbObj?.ToSvc();
            }
        }








        /// <summary>
        /// Returns all products in the systems.
        /// sequence is returned in the order of precedence.
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProducts()
        {
            using (var db = new WorkersBenefitsDB2())
            {
                return db.products
                    .Select(ServiceObjectsExtensions.ToSvc)
                    .OrderBy(item => item.Precedence)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns the most featured product in the system.
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetFeaturedProduct()
        {
            using (var db = new WorkersBenefitsDB2())
            {
                return db.products.Select(ServiceObjectsExtensions.ToSvc).ToList();
            }
        }

        public static FeaturedProductsList GetFeaturedProducts(int categoryId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var items = db.products.Take(10).AsEnumerable()
                    .Where(item => item.category_id == categoryId).AsEnumerable()
                    .Select(ServiceObjectsExtensions.ToSvc)
                    .OrderBy(item => item.Precedence).ToList();
                return new FeaturedProductsList(items);    //todo. add random
            }
        }

        /// <summary>
        /// Search suggestions list.
        /// </summary>
        /// <returns></returns>
        public static object GetSuggestionsList()
        {
            return null;
        }

        public static void SubmitOrder(Order order)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                db.orders.Add(order.ToDB());
            }
        }
    }
}
