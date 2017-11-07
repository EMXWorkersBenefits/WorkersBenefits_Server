using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMX.WorkersBenefits.BL.ServiceObjects
{
    public class FeaturedProductsList : ProductsSearchResults
    {
        public FeaturedProductsList(List<Product> data)
            : base(data, 10)
        {
        }
    }

    public class ProductsSearchResults : Dictionary<int, Product>       //Dictionary. Key: precedence (1-based), Value: product; up to 10 items.
    {
        public ProductsSearchResults(List<Product> data)
        {
            foreach (var item in data)
            {
                this.Add(item.Precedence, item);
            }
        }
        protected ProductsSearchResults(List<Product> data, int maxItems)
        {
            if (data.Count > maxItems)
            {
                throw new Exception("more than 10 products in featured list");
            }

            foreach (var item in data)
            {
                this.Add(item.Precedence, item);
            }
        }
    }
}
