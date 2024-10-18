using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;


namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["UsersOnline"] = 0;
        }

        public void Session_OnStart()
        {
            Application.Lock();

            HttpContext.Current.Session["Main_KB_Location"] = "No File";
            HttpContext.Current.Session["KB_Location"] = "No File";
            HttpContext.Current.Session["CurrentDecisionModel"] = "";
            HttpContext.Current.Session["CurrentUserEmail"] = "Unknown";
            HttpContext.Current.Session["UserAccountDB"] = @"~\XML_DB\UserAccounts\UserAccounts.xml";
            HttpContext.Current.Session["UID"] = "";
            HttpContext.Current.Session["CurrentUserName"] = "";

            //HttpContext.Current.Response.Redirect("Login.aspx");

            Application.UnLock();
        }

        public void Session_OnEnd()
        {
            Application.Lock();
            Application.UnLock();
        }
    }
}