using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EMX.WorkersBenefits.Shared.Definitions.Enums;

namespace EMX.WorkersBenefits.MVC.Models
{
    public class ContactUsViewModel
    {
        public ContactUsSubject Subject { get; set; }
        public string Content { get; set; }
    }
}