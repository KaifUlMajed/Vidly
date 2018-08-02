using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using Vidly.App_Start;


namespace Vidly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Initializing the AutoMapper module to be used.
            Mapper.Initialize(conf => conf.AddProfile<MappingProfile>());
            // Initializing the Web API module to be used.
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Initializing other things done by MVC.
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
