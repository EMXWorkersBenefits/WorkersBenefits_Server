using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMX.WorkersBenefits.MVC.Startup))]
namespace EMX.WorkersBenefits.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
