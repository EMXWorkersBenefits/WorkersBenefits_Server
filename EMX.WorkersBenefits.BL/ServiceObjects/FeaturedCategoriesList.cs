using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMX.WorkersBenefits.BL.ServiceObjects
{
    public class FeaturedCategoriesList : CategoriesSearchResults
    {
        public FeaturedCategoriesList(List<Category> data)
            : base(data, 5)
        {
        }
    }

    public class CategoriesSearchResults : Dictionary<int, Category>       //Dictionary. Key: precedence (1-based), Value: category;
    {
        public CategoriesSearchResults(List<Category> data)
        {
            int newPrecedence = 1;
            foreach (var item in data)
            {
                item.Precedence = newPrecedence;
                this.Add(newPrecedence++, item);
            }
        }
        protected CategoriesSearchResults(List<Category> data, int maxItems)
        {
            if (data.Count > maxItems)
            {
                throw new Exception($"more than {maxItems} categories in featured list");
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
