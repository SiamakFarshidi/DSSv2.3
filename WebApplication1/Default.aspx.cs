using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ClassLibrary;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RecentDecisionModels.Value = Generate_JS_HTML_ListOfRecentDecisionModels();
            ViewDecisionModels.Value = Generate_JS_HTML_ListOfViewableDecisionModels();
        }


        public string Generate_JS_HTML_ListOfRecentDecisionModels()
        {
            string data = "";
            string email = HttpContext.Current.Session["CurrentUserEmail"].ToString();
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            clsCase[] objCase = obj_KB.GetAllDecisionModels(email);

            //if (objCase.Length == 0)
            //    data = @"<script>$(""#StandardDecisionModelsList"").toggle(500);</script>";

            for (int i = 0; i < objCase.Length; i++)
            {
                data += @"
                        <div class=""col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col"" id=""" + objCase[i].KBfilename + @""">
                            <div class=""tm-bg-primary-dark tm-block"" style=""text-align: center;"">

                                <div style=""width: 100%; text-align: right;"">
                                    <a onclick=""DeleteCase('" + objCase[i].KBfilename + @"'); return false; "" href=""#"">
                                        <img src=""Image/Delete_icon.png"" alt=""Delete"" style=""width: 30px; height: 40px; padding: 0px; margin-bottom: 20px; margin-top: -20px; margin-right: -20px;"" />
                                    </a>
                                </div>
                                <div onclick=""$('#cover').show();window.location = 'CaseDefinition.aspx?OpenDecisionModel=" + objCase[i].KBfilename + "&PageCaption=" + GetPageTitle(objCase[i].decisionModel) + @"'"">
                                    <h2 class=""tm-block-title"" style=""height:30px;"">" + objCase[i].title + @"</h2>
                                    <div class=""tm-avatar-container"" style=""text-align: center;"">
                                        <a href=""CaseDefinition.aspx?OpenDecisionModel=" + objCase[i].KBfilename + "&PageCaption=" + GetPageTitle(objCase[i].decisionModel) + @""" class=""tm-avatar-delete-link"">
                                            <img src=""Image/Open_icon.png"" style=""width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;"" />
                                        </a>
                                        <div class=""DMInstanceImage"">
                                            <img
                                                src=""Image/Cases/" + objCase[i].imageFileName + @"""
                                                alt=""Avatar""
                                                class=""tm-avatar img-fluid mb-4"" style=""width: 100px; height: 100px;"" />
                                        </div>
                                        <div class=""DMInstanceIcon"">" + GetDecisionModelIcon(objCase[i].decisionModel) + @"</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        ";
            }
            return data;
        }

        public string Generate_JS_HTML_ListOfViewableDecisionModels()
        {
            string data = "";
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            clsCase[] objCase = obj_KB.GetAllOtherDecisionModels(HttpContext.Current.Session["CurrentUserEmail"].ToString());

            //if (objCase.Length == 0)
            //    data = @"<script>$(""#StandardDecisionModelsList"").toggle(500);</script>";

            for (int i = 0; i < objCase.Length; i++)
            {
                data += @"
                        <div onclick=""$('#cover').show();window.location = 'CaseDefinition.aspx?ViewDecisionModel=" + objCase[i].KBfilename + "&PageCaption=" + GetPageTitle(objCase[i].decisionModel) + @"'""
                            class=""col-sm-12 col-md-12 col-lg-3 col-xl-3 tm-block-col"" id=""" + objCase[i].KBfilename + @""">
                            <div class=""tm-bg-primary-dark tm-block"" style=""text-align: center;"">
                                <h2 class=""tm-block-title"" style=""height:30px;"">" + objCase[i].title + @"</h2>
                                <div class=""tm-avatar-container"" style=""text-align: center;"">
                                    <a href=""CaseDefinition.aspx?ViewDecisionModel=" + objCase[i].KBfilename + "&PageCaption=" + GetPageTitle(objCase[i].decisionModel) + @""" class=""tm-avatar-delete-link"">
                                        <img src=""Image/View_icon.png"" style=""width: 60px; height: 60px; padding: 0px; margin: -22px; margin-top: -23px;"" />
                                    </a>
                                    <div class=""DMInstanceImage"">
                                        <img
                                            src=""Image/Cases/" + objCase[i].imageFileName + @"""
                                            alt=""Avatar""
                                            class=""tm-avatar img-fluid mb-4"" style=""width: 100px; height: 100px;"" />
                                    </div>
                                    <div class=""DMInstanceIcon"">" + GetDecisionModelIcon(objCase[i].decisionModel) + @"</div>
                                </div>
                            </div>
                        </div>";
            }
            return data;
        }

        public string GetDecisionModelIcon(string DecisionModel)
        {
            string icon = "";
            if (DecisionModel == "DBMSMODEL")
                icon = @"<i class=""fas fa-database""></i>";
            else if (DecisionModel == "CSPMODEL")
                icon = @"<i class=""fas fa-cloud""></i>";
            else if (DecisionModel == "AFAS_Generator")
                icon = @"<i class=""fas fa-database""></i>";
            else if (DecisionModel == "BPMODEL")
                icon = @"<i class=""fas fa-cubes""></i>";
            else if (DecisionModel == "SWAPMODEL")
                icon = @"<i class=""fas fa-puzzle-piece""></i>";
            else if (DecisionModel == "PLMODEL")
                icon = @"<i class=""fas fa-code""></i>";
            else if (DecisionModel == "MDDMODEL")
                icon = @"<i class=""fab fa-codepen""></i>";
            else if (DecisionModel == "BPMLMODEL")
                icon = @"<i class=""fab fa-linode""></i>";
            else if (DecisionModel == "DAOMODEL")
                icon = @"<i class=""fab fa-gavel""></i>";
            else if (DecisionModel == "QAMODEL")
                icon = @"<i class=""fas fa-certificate""></i>";
            else if (DecisionModel == "NEWMODEL")
                icon = @"<i class=""fas fa-cogs""></i>";

            return icon;
        }
        public string GetPageTitle(string DecisionModel)
        {
            string title = "";
            if (DecisionModel == "DBMSMODEL")
                title = @"Database Technology Selection";
            else if (DecisionModel == "CSPMODEL")
                title = @"Cloud Service Provider Selection";
            else if (DecisionModel == "AFAS_Generator")
                title = @"AFAS Generator";
            else if (DecisionModel == "BPMODEL")
                title = @"Blockchain Platform Selection";
            else if (DecisionModel == "SWAPMODEL")
                title = @"Software Architecture Pattern Selection";
            else if (DecisionModel == "PLMODEL")
                title = @"Programming Language Selection";
            else if (DecisionModel == "MDDMODEL")
                title = @"Model-Driven Development Platform Selection";
            else if (DecisionModel == "BPMLMODEL")
                title = @"Business Process Modeling Language Selection";
            else if (DecisionModel == "QAMODEL")
                title = @"Quality Assessment Model Selection";
            else if (DecisionModel == "DAOMODEL")
                title = @"Decentralized Autonomous Organization Platform Selection";





            return title;
        }


    }
}