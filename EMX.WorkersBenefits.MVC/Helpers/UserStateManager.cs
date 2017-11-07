using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMX.WorkersBenefits.BL.ServiceObjects;
using EMX.WorkersBenefits.Shared.Definitions;

namespace EMX.WorkersBenefits.MVC.Helpers
{
    /// <summary>
    /// Handles all actions around the user state management (MyBasket, etc.)
    /// </summary>
    public static class UserStateManager
    {
        public static Enums.UserType UserType { get; set; }
        public static int Identity_UserId { get; set; }
        public static int WorkerId { get; set; }
        public static MyBasket Basket { get; set; }

        static UserStateManager()
        {
            Basket = new MyBasket();
        }

    }

    public class MyBasket
    {
        public Dictionary<int, MyBasketItem> Items { get; set; }   //Dictionary. K: productId, V:basket item
        public decimal Total { get { return Items.Values.Sum(item => item.TotalPrice); } }


        public MyBasket()
        {
            this.Items = new Dictionary<int, MyBasketItem>();
        }

        /// <summary>
        /// Clears the basket
        /// </summary>
        public void Clear()
        {
            this.Items.Clear();
        }

    }

    public class MyBasketItem
    {
        public Product Product { get; set; }
        /// <summary>
        /// final price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// amount of items
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// total price (price * count)
        /// </summary>
        public decimal TotalPrice { get; set; }

        public MyBasketItem()
        {

        }

        public MyBasketItem(Product product, decimal price, int amount, decimal totalPrice)
        {
            Product = product;
            Price = price;
            Count = amount;
            TotalPrice = totalPrice;
        }

        public void PromoteCount()
        {
            Count++;
        }

        public void DemoteCount()
        {
            Count--;
        }
    }
}