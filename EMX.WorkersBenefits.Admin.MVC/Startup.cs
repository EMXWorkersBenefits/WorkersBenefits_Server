using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMX.WorkersBenefits.Admin.MVC.Startup))]
namespace EMX.WorkersBenefits.Admin.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
