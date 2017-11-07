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
        public int? Precedence { get; set; }

        public Category()
        {
            
        }


        public Category(category dbCategory)   //from db object to service object.
        {
            this.CategoryId = dbCategory.category_id;
            this.Name = dbCategory. name;
            this.Title = dbCategory.title;
            this.Image = dbCategory.image;
            this.Precedence = dbCategory.precedence;
        }

        public Category(int categoryId, string name, string title, string image, string visualName, int? precedence)
        {
            CategoryId = categoryId;
            Name = name;
            Title = title;
            Image = image;
            Precedence = precedence;
        }
    }
}
