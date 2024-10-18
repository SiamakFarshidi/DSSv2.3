using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ClassLibrary;

namespace WebApplication1
{
    public partial class DecisionModel1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Type"] != null)
            {
                clsScript_Generator objJS = new clsScript_Generator();
                objJS.Generate_JS_Aspects(Request.QueryString["Type"]);
            }
            else if (Request.QueryString["View"] != null)
            {
                clsKnowledgeBase objKB = new clsKnowledgeBase();
                objKB.Create_New_Case(Request.QueryString["View"].ToString(), "true");
                clsScript_Generator objJS = new clsScript_Generator();
                objJS.Generate_JS_Aspects("Alternatives");
                objKB.deleteTemporaryCases();
            }

        }
    }
}