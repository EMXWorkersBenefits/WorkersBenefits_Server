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

    public class ProductsSearchResults : Dictionary<int, Product>       //Dictionary. Key: precedence (1-based), Value: product;
    {
        public ProductsSearchResults(List<Product> data)
        {
            int newPrecedence = 1;
            foreach (var item in data)
            {
                item.Precedence = newPrecedence;
                this.Add(newPrecedence++, item);
            }
        }
        protected ProductsSearchResults(List<Product> data, int maxItems)
        {
            if (data.Count > maxItems)
            {
                throw new Exception($"more than {maxItems} products in featured list");
            }

            int newPrecedence = 1;
            foreach (var item in data)
            {
                item.Precedence = newPrecedence;
                this.Add(newPrecedence++, item);
            }
        }
    }
}
