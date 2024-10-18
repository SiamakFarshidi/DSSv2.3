using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (
                !HttpContext.Current.Request.Url.ToString().Contains("DecisionModel?View=") &&
                !HttpContext.Current.Request.Url.ToString().Contains("Login") &&
                (
                    HttpContext.Current.Session["CurrentUserEmail"].ToString() == "Unknown" ||
                    HttpContext.Current.Session == null ||
                    HttpContext.Current.Session["UID"] == null
                ))
                Response.Redirect("Login.aspx");
        }
    }
}