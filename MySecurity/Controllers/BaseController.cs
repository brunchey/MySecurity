using MySecurity.Models;
using MySecurity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MySecurity.Controllers
{
    public class BaseController : Controller
    {
        public IAuthenticationProvider AuthenticationProvider { get; set; }



        protected override void OnAuthorization(AuthorizationContext filterContext)
        {

            //if (filterContext.HttpContext.User != null)
            //{
            //    if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //    {
            //        if (filterContext.HttpContext.User.Identity is FormsIdentity)
            //        {

            //            FormsIdentity id =
            //                        (FormsIdentity)filterContext.HttpContext.User.Identity;
            //            FormsAuthenticationTicket ticket = id.Ticket;

            //            // Get the stored user-data, in this case, our roles
            //            string userData = ticket.UserData;
            //            string[] roles = userData.Split(',');
            //            ISitePrincipal principle = new SitePrincipal(ticket.Name, roles);
            //            Thread.CurrentPrincipal = principle as IPrincipal;
            //            filterContext.HttpContext.User = principle as IPrincipal;
                        
            //        }
            //    }
            //}
            this.AuthenticationProvider.Authorize();

            base.OnAuthorization(filterContext);
        }

    }
}
