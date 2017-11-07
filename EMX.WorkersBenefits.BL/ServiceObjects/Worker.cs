using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMX.WorkersBenefits.DAL.Models;

namespace EMX.WorkersBenefits.BL.ServiceObjects
{
  public class Worker
  {
    public int WorkerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Worker()
    {

    }

    public Worker(worker item)
    {
      this.WorkerId = item.worker_id;
      this.FirstName = item.first_name;
      this.LastName = item.last_name;
    }
    public Worker(int workerId, string firstName, string lastName)
    {
      WorkerId = workerId;
      FirstName = firstName;
      LastName = lastName;
    }
  }
}
