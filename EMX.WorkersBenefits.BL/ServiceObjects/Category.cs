using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMX.WorkersBenefits.DAL.Models;

namespace EMX.WorkersBenefits.BL.ServiceObjects
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Precedence { get; set; }   //precedence; 1 if null in db.
        public List<Product> Products { get; set; }   //optional: products.

        public Category()
        {
            Products=new List<Product>();
        }


        public Category(category dbCategory)   //from db object to service object.
        {
            this.CategoryId = dbCategory.category_id;
            this.Name = dbCategory.name;
            this.Title = dbCategory.title;
            this.Image = dbCategory.image;
            this.Precedence = dbCategory.precedence.GetValueOrDefault(1);
            Products = new List<Product>();
        }

        public Category(int categoryId, string name, string title, string image, string visualName, int precedence)
        {
            CategoryId = categoryId;
            Name = name;
            Title = title;
            Image = image;
            Precedence = precedence;
            Products = new List<Product>();
        }
    }
}
