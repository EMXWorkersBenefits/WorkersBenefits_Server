using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMX.WorkersBenefits.ASPCore.API.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
