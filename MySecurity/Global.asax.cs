using Autofac;
using Autofac.Integration.Mvc;
using MySecurity.Controllers;
using MySecurity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace MySecurity
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            //TODO: Move this into its own Config
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<FormsAuthenticationProvider>().As<IAuthenticationProvider>().InstancePerHttpRequest();
            builder.RegisterModule(new AutofacWebTypesModule()); //this registers the Http abstractions (e.g. - HttpContextBase, etc) http://code.google.com/p/autofac/wiki/Mvc3Integration



            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

        }


    }
}