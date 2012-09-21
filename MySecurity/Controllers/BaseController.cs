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
            this.AuthenticationProvider.Authorize();
            base.OnAuthorization(filterContext);
        }

    }
}
