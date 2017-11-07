using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMX.WorkersBenefits.BL.Managers;
using EMX.WorkersBenefits.BL.ServiceObjects;
using EMX.WorkersBenefits.Shared.Definitions;

namespace EMX.WorkersBenefits.MVC.Helpers
{
    /// <summary>
    /// Handles all actions around the user state management (MyBasket, etc.)
    /// Note: This is session-scoped.
    /// </summary>
    public class UserStateManager : IUserStateManager
    {

        #region SingleTon

        private static UserStateManager _instance;

        public static UserStateManager Instance
        {
            get
            {

                if (_instance == null)
                {
                    _instance = new UserStateManager();
                }
                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// The logged in user type: worker, company person, admin person.
        /// </summary>
        public Enums.UserType UserType { get; set; }
        /// <summary>
        /// Holds the identity user id; applies to all user types.
        /// </summary>
        public int Identity_UserId { get; set; }
        /// <summary>
        /// only applies for worker.
        /// -1 for none.
        /// </summary>
        public int WorkerId { get; set; }
        /// <summary>
        /// only applies for company person.
        /// -1 for none.
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// only applies for company person.
        /// -1 for none.
        /// </summary>
        public int CompanyPersonId { get; set; }
        /// <summary>
        /// only applies for worker.
        /// </summary>
        public MyBasket Basket { get; set; }

        private UserStateManager()
        {
            Basket = new MyBasket();
            WorkerId = -1;
            CompanyId = -1;
            CompanyPersonId = -1;
        }

        public void SetSessionValue(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public object GetSessionValue(string key)
        {
            object obj = HttpContext.Current.Session[key];
            return obj;
        }

        public string GetSessionValueAsString(string key)
        {
            return GetSessionValue(key)?.ToString();
        }

        #region IUserStateManager implementation
        string IUserStateManager.Get(string key)
        {
            return GetSessionValueAsString(key);
        }

        void IUserStateManager.Set(string key, string value)
        {
            SetSessionValue(key, value);
        }
        #endregion
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