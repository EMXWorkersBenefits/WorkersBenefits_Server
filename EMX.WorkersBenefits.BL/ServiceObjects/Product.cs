using EMX.WorkersBenefits.DAL.Models;

namespace EMX.WorkersBenefits.BL.ServiceObjects
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Product_UID { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Precedence { get; set; }   //precedence in category; 1 if null in db.
        public string Description { get; set; }
        public string Popup { get; set; }
        public int GlobalPrecedence { get; set; }   //global precedence; 1 if null in db.

        public Product()
        {

        }
        public Product(product item)   //from db object to service object.
        {
            this.ProductId = item.product_id;
            this.Product_UID = item.product_uid;
            this.CategoryId = item.category_id;
            this.Image = item.image;
            this.Title = item.title;
            this.Price = item.final_price;
            this.Precedence = item.precedence.GetValueOrDefault(1);
            this.Description = item.description;
            this.Popup = item.popup;
        }

        public Product(int productId, string productUid, int categoryId, string image, string title, decimal price, int? precedence, string description, string popup)
        {
            ProductId = productId;
            Product_UID = productUid;
            CategoryId = categoryId;
            Image = image;
            Title = title;
            Price = price;
            Precedence = precedence.GetValueOrDefault(1);
            Description = description;
            Popup = popup;
        }
    }
}
