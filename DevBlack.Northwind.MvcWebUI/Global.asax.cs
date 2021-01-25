using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DevBlack.Core.CrossCutingConcerns.Security.Web;
using DevBlack.Core.Utilities.Mvc.İnfrastructure;
using DevBlack.Northwind.Business.DependencyResolves.Ninject;

namespace DevBlack.Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new ProductModule()));
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie==null)
                {
                    return;
                }

                var enTicked = authCookie.Value;
                if (String.IsNullOrEmpty(enTicked))
                {
                    return;
                    
                }

                var ticked = FormsAuthentication.Decrypt(enTicked);
                var securityUtilities= new SecurityUtilities();
                var identity = securityUtilities.FormsAuthTickedIdentity(ticked);
                var principle=new GenericPrincipal(identity,identity.Roles);
                HttpContext.Current.User = principle;
                Thread.CurrentPrincipal = principle;


            }
            catch (Exception)
            {
             
            }
        }
    }
}
