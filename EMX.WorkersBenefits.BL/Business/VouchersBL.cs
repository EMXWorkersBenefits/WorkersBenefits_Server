using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMX.WorkersBenefits.BL.ServiceObjects;
using EMX.WorkersBenefits.DAL.Models;

namespace EMX.WorkersBenefits.BL.Business
{
    /// <summary>
    /// Handles all business-logic activities around vouchers.
    /// </summary>
    public static class VouchersBL
    {
        /// <summary>
        /// Returns all vouchers of the given worker.
        /// </summary>
        public static List<Voucher> GetAll(int workerId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                return db.voucher_grants.Where(item => item.worker_id == workerId)
                    .Select(voucherGrant => voucherGrant.voucher)
                    .AsEnumerable()
                    .Select(ServiceObjectsExtensions.ToSvc)
                    .ToList();
            }
        }

        public static Voucher GetVoucher(int voucherId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var dbObj = db.vouchers
                    .SingleOrDefault(item => item.voucher_id == voucherId);

                return dbObj?.ToSvc();
            }
        }

        public static void CommitVoucherRequest()
        {
            
        }
    }
}
