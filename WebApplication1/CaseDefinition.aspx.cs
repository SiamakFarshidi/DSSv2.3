using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ClassLibrary;


namespace WebApplication1
{
    public partial class DecisionModel : System.Web.UI.Page
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                clsScript_Generator objJS = new clsScript_Generator();

                if (Request.QueryString["CreateNewDecisionModel"] != null)
                {
                    CreateNewCase();
                }
                else if (Request.QueryString["OpenDecisionModel"] != null && Request.QueryString["OpenDecisionModel"] != "NULL")
                {
                    objJS.Generate_JS_CaseDefinition(Request.QueryString["OpenDecisionModel"].ToString());
                }
                else if (Request.QueryString["ViewDecisionModel"] != null)
                {
                    objJS.Generate_JS_OpenForViewCaseDefinition(Request.QueryString["ViewDecisionModel"].ToString());
                    objJS.Generate_JS_FeatureRequirements();
                }

                if (Request.QueryString["OpenDecisionModel"] != null)
                    objJS.Generate_JS_FeatureRequirements();

                objJS.MakeDecision();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CreateNewCase()
        {
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            obj_KB.Create_New_Case(Request.QueryString["CreateNewDecisionModel"].ToString(), "false");
            string filename = obj_KB.Get_Local_KB().Substring(obj_KB.Get_Local_KB().LastIndexOf("\\") + 1);

            if (Request.QueryString["CreateNewDecisionModel"].ToString() == "NEWMODEL")
                obj_KB.Update_Current_Case("A decision model for an MCDM problem", "This is a decision for an MCDM problem that addresses...");

            Response.Redirect("~/CaseDefinition.aspx?OpenDecisionModel=" + filename + "&PageCaption=" + Request.QueryString["PageCaption"].ToString());
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}