using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMX.WorkersBenefits.BL.ServiceObjects;
using EMX.WorkersBenefits.DAL.Models;
using log4net;
using static EMX.WorkersBenefits.Shared.Definitions.Enums;

namespace EMX.WorkersBenefits.BL.Business
{
    /// <summary>
    /// Handles all business-logic activities around workers.
    /// also general methods.
    /// </summary>
    public class WorkersBL
    {
        private static readonly ILog m_logger = LogManager.GetLogger(typeof(WorkersBL));

        //Workers Point-Of-View :::
        //WorkerSettingsPage:
        public static Worker GetWorker(int workerId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var dbObj = db.workers
                    .SingleOrDefault(item => item.worker_id == workerId);

                return dbObj?.ToSvc();
            }
        }

        public static void SaveWorker(Worker worker)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        //ContactUsPage:
        public static void SendContactUs(ContactUsSubject subject, string content)
        {
            //throw new NotImplementedException();
        }



        //Company Point-Of-View :::
        /// <summary>
        /// Returns all workers of the given company.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static List<Worker> GetAllWorkers(int companyId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                return db.workers.Where(worker => worker.company_id == companyId).AsEnumerable()
                    .Select(ServiceObjectsExtensions.ToSvc)
                    .ToList();
            }
        }

        public static void CreateWorker(Worker worker)
        {
            try
            {

                using (var db = new WorkersBenefitsDB2())
                {
                    db.workers.Add(worker.ToDB());
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                m_logger.Error(ex);
                throw;
            }
        }

        //public static void SaveWorker(Worker worker)
        //{
        //    try
        //    {
        //        using (var db = new WorkersBenefitsDB2())
        //        {
        //            db.Entry(worker).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        m_logger.Error(ex);
        //        throw;
        //    }
        //}

        public static void DeleteWorker(int workerId)
        {
            using (var db = new WorkersBenefitsDB2())
            {
                var workerToDelete = db.workers.Find(workerId);
                db.workers.Remove(workerToDelete);
                db.SaveChanges();
            }
        }
    }
}
