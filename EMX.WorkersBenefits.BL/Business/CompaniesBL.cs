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
    /// Handles all business-logic activities around companies, company persons etc.
    /// </summary>
    public class CompaniesBL
    {
        public static Company GetCompany(int company_id)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var dbObj = db.companies
                    .SingleOrDefault(item => item.company_id == company_id);

                return dbObj?.ToSvc();
            }
        }



    }
}
