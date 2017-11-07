using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMX.WorkersBenefits.DAL.Models;

namespace EMX.WorkersBenefits.BL.ServiceObjects
{
    public static class ServiceObjectsExtensions
    {
        public static Product ToSvc(this product item)
        {
            return new Product(item);
        }
        public static Worker ToSvc(this worker item)
        {
            return new Worker(item);
        }
        public static worker ToDB(this Worker item)
        {
            return new worker() { };   //todo fill object
        }
        public static Category ToSvc(this category item)
        {
            return new Category(item);
        }

        public static Voucher ToSvc(this voucher item)
        {
            return new Voucher(item);
        }
        public static Order ToSvc(this order item)
        {
            return new Order(item);
        }
        public static order ToDB(this Order item)
        {
            return new order() { };   //todo fill object
        }
        public static Company ToSvc(this company item)
        {
            return new Company(item);
        }
    }
}
