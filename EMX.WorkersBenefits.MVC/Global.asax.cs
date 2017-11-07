using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EMX.WorkersBenefits.MVC.Controllers;
using log4net;

namespace EMX.WorkersBenefits.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static readonly ILog m_logger = LogManager.GetLogger(typeof(MvcApplication));

        //Application::
        protected void Application_Start()
        {
            //Debugger.Launch();
            //log4net:
            log4net.Config.XmlConfigurator.Configure();
            //Mvc:
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //other:
            AutoMapperConfig.Config();
            NinjectConfig.Config();
            CacheConfig.Config();
        }

        protected void Application_End()
        {

        }

        protected void Application_Error()
        {
        }



        //Session::
        /// <summary>
        /// Note: Only relevant to In_Proc Session management.
        /// </summary>
        protected void Session_Start()
        {
            m_logger.Info("Session_start:::");
        }

        protected void Session_End()
        {
            m_logger.Info("Session_end:::");
        }



    }
}
