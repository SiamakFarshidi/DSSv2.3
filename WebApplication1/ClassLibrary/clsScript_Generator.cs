using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1.ClassLibrary
{
    public class clsScript_Generator
    {
        int currentColor = 0;
        public string GetColor()
        {
            string[] colors ={"#3CB371","#1E90FF","#FF6347","#EE82EE","#808000","#800000",
                              "#008B8B","#DC143C","#4B0082","#00BFFF","#2E8B57","#2F4F4F","#FF4500",
                              "#BDB76B","#8B0000","#BC8F8F","#00008B","#BA55D3","#6A5ACD","#D2691E","#191970"};
            currentColor = currentColor % colors.Length;
            return colors[currentColor++];
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool SaveFile(string filename, string content)
        {
            try
            {
                clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                string targetPath = obj_KB.Get_Profile_Path() + @"\JS";

                if (!System.IO.Directory.Exists(targetPath))
                    System.IO.Directory.CreateDirectory(targetPath);

                string destFile = System.IO.Path.Combine(targetPath, filename);

                File.WriteAllText(destFile, content);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_Report(XmlNode[] FeasibleSolutions)
        {
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();

            string data = @"
            var FeasibleSolutions= ""<table class='tbl_FR'> <tr><th>Feasible Solution</th><th>Explanation</th></tr>";
            string[] lstDesc = null;
            for (int i = 0; i < FeasibleSolutions.Length; i++)
            {
                lstDesc = obj_KB.getSolutionDescription(FeasibleSolutions[i].Attributes[1].Value);
                data += @"<tr> <td>" + FeasibleSolutions[i].Attributes[1].Value + @" </td> <td>" + (lstDesc.Length > 1 ? "<b>Hybrid Solution:</b> <br/><br/>" : "");
                for (int j = 0; j < lstDesc.Length; j++)
                    data += (j + 1) + " - " + lstDesc[j] + "<br/>";
                data += @"</td></tr>";
            }

            data += @"</table>"";";

            List<XmlNode> lstNumericFeatures = obj_KB.getNumericFeatures();
            List<XmlNode> lstSubSolutions = obj_KB.getSubSolutions(FeasibleSolutions);

            for (int i = 0; i < FeasibleSolutions.Length; i++)
                lstSubSolutions.Add(FeasibleSolutions[i]);

            data += @"var NumbericFeaturesComparison=""<table class='tbl_FR'> <tr><td></td>";
            for (int i = 0; i < lstNumericFeatures.Count(); i++)
                data += "<td class='rotate' width=38 style='width:29pt'><div><span><div><span>" + lstNumericFeatures[i].Attributes[1].Value + "</span></div></td>";
            data += "</tr>";
            for (int i = 0; i < lstSubSolutions.Count(); i++)
            {
                data += "<tr> <td>" + lstSubSolutions[i].Attributes[1].Value + @" </td>";
                for (int j = 0; j < lstNumericFeatures.Count(); j++)
                {
                    string score = obj_KB.FeatureAlternativeValue(lstSubSolutions[i], lstNumericFeatures[j]);
                    string color = "";
                    if (score != "")
                    {
                        double dblScore = double.Parse(score);
                        if (dblScore == 0)
                        {
                            color = "255,255,255";
                            score = "?";
                        }
                        else if (dblScore > 0 && dblScore <= 0.29)
                        {
                            color = "220,20,60";
                            score = "L";

                        }
                        else if (dblScore > 0.29 && dblScore <= 0.42)
                        {
                            color = "255,127,80";
                            score = "L<sup>+</sup>";

                        }
                        else if (dblScore > 0.42 && dblScore <= 0.57)
                        {
                            color = "255,215,00";
                            score = "M";
                        }
                        else if (dblScore > 0.57 && dblScore <= 0.71)
                        {
                            color = "173,255,47";
                            score = "M<sup>+</sup>";

                        }
                        else if (dblScore > 0.71 && dblScore <= 1.0)
                        {
                            color = "60,179,113";
                            score = "H";

                        }
                    }
                    data += "<td style='text-align:center;width=25pt;border: 3px solid rgb(0,0,0);background-color:rgb(" + color + ")'> <span style='font-size:12px;'>" + score + "</span></td>";
                }
                data += "</tr>";


            }

            data += @"</table>"";";

            SaveFile("GeneratedReport.js", data);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_FeatureRequirements()
        {
            string strFeatureRequirements = "var FeatureRequirement_datatable = [ ";
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            string[] FeatureGroups = obj_KB.GetAllGroups();

            for (int g = 0; g < FeatureGroups.Length; g++)
            {
                clsFeatures[] objFeatures = obj_KB.GetFeaturesByGroup(FeatureGroups[g]);

                string strFeatureList = "";
                for (int i = 0; i < objFeatures.Length; i++)
                {
                    clsFeatures[] objSubFeatures = obj_KB.GetAllSubFeatures(objFeatures[i]);
                    string strSubFeatures = ", _children: [";

                    if (objSubFeatures != null && objSubFeatures.Length > 0)
                    {

                        for (int j = 0; j < objSubFeatures.Length; j++)
                            strSubFeatures += @"{" +
                                                @"id: " + objSubFeatures[j].ID + @"," +
                                                @"FeatureID:""" + objSubFeatures[j].ID + @"""," +
                                                @"Feature: """ + objSubFeatures[j].Title + @""", " +
                                                @"MoSCoW: """ + GetMoSCoWText(objSubFeatures[j].Req) + @""", " +
                                                @"Description: """ + objSubFeatures[j].Description + @""", " +
                                                @"FeatureDataType: """ + objSubFeatures[j].DataType + @""", " +
                                                @"FeatureCategory: """ + objSubFeatures[j].Order + @""", " +
                                                @"FeatureParent: """ + objSubFeatures[j].UpperLevel + @""", " +
                                                @"FeatureSupportedAlternatives: """ + objSubFeatures[j].SupportedAlternatives + @""", " +
                                                @"FeatureCriterionValue: """ + ((objSubFeatures[j].DataType == "Numeric" || objSubFeatures[j].DataType == "Monetary") ? objSubFeatures[j].Criterion : "") + @""" },";
                    }
                    strSubFeatures += @"]";

                    strFeatureList += @"{" +
                                                 @"id: " + objFeatures[i].ID + @"," +
                                                 @"FeatureID:""" + objFeatures[i].ID + @"""," +
                                                 @"Feature: """ + objFeatures[i].Title + @""", " +
                                                 @"MoSCoW: """ + GetMoSCoWText(objFeatures[i].Req) + @""", " +
                                                 @"Description: """ + objFeatures[i].Description + @""", " +
                                                 @"FeatureDataType: """ + objFeatures[i].DataType + @""", " +
                                                 @"FeatureCategory: """ + objFeatures[i].Order + @""", " +
                                                 @"FeatureParent: """ + objFeatures[i].UpperLevel + @""", " +
                                                 @"FeatureSupportedAlternatives: """ + objFeatures[i].SupportedAlternatives + @""", " +
                                                 @"FeatureCriterionValue: """ + ((objFeatures[i].DataType == "Numeric" || objFeatures[i].DataType == "Monetary") ? objFeatures[i].Criterion : "") + @"""" +
                                                 ((objSubFeatures != null && objSubFeatures.Length > 0) ? strSubFeatures : "") + @"},";
                }

                strFeatureRequirements += @"{" +
                                                @"id: " + (g + 1) + @", " +
                                                @"FeatureID:""""," +
                                                @"Feature: """ + FeatureGroups[g] + @""", " +
                                                @"MoSCoW: """", " +
                                                @"Description: """", " +
                                                @"FeatureDataType: ""Category"", " +
                                                @"FeatureCategory: """", " +
                                                @"FeatureParent: """", " +
                                                @"FeatureSupportedAlternatives: """", " +
                                                @"FeatureCriterionValue: """", " +
                                                @"_children: [" + strFeatureList + @"] },";
            }
            strFeatureRequirements += @"]; DuplicateDataset=JSON.parse((JSON.stringify(FeatureRequirement_datatable)));";

            Regex.Replace(strFeatureRequirements, @"\s+", "");
            SaveFile("FeatureRequirements.js", strFeatureRequirements);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string GetMoSCoWText(string Req)
        {
            string MoSCoW = "";
            if (Req == "M")
                MoSCoW = "Must-Have";
            else if (Req == "S")
                MoSCoW = "Should-Have";
            else if (Req == "C")
                MoSCoW = "Could-Have";
            else if (Req == "W")
                MoSCoW = "Won't-Have";
            return MoSCoW;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_CaseDefinition(string OpenDecisionModel)
        {
            string data = "";

            clsCase objCase = new clsCase();

            HttpContext.Current.Session["KB_Location"] = HttpContext.Current.Server.MapPath(@"~\XML_DB\Profiles\" + HttpContext.Current.Session["UID"] + @"\" + OpenDecisionModel);

            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            string email = HttpContext.Current.Session["CurrentUserEmail"].ToString();
            string fileLocation = OpenDecisionModel;
            objCase = (clsCase)obj_KB.OpenCase(email, fileLocation);

            data = @"
                            var CurrentDecisionModel=""" + objCase.decisionModel + @""";
                            document.getElementById(""txttitle"").value = """ + objCase.title + @""";
                            document.getElementById(""txtdescription"").innerText =""" + objCase.explanation + @""";
                            $(""#myUploadedImg"").attr(""src"", ""Image/Cases/" + objCase.imageFileName + @""");
                        ";

            SaveFile("CaseDefinition.js", data);

        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_OpenForViewCaseDefinition(string OpenDecisionModel)
        {
            string data = "";

            clsCase objCase = new clsCase();
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();

            obj_KB.createTemporaryAccessToViewDecisionModel(OpenDecisionModel);

            string email = HttpContext.Current.Session["CurrentUserEmail"].ToString();
            string fileLocation = OpenDecisionModel;

            objCase = (clsCase)obj_KB.OpenCase(email, fileLocation);

            data = @"
                            var CurrentDecisionModel=""" + objCase.decisionModel + @""";
                            document.getElementById(""txttitle"").value = """ + objCase.title + @""";
                            document.getElementById(""txtdescription"").innerText =""" + objCase.explanation + @""";
                            $(""#myUploadedImg"").attr(""src"", ""Image/Cases/" + objCase.imageFileName + @""");
                        ";

            SaveFile("CaseDefinition.js", data);

        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_DecisionStructure(XmlNode Domain, XmlNode[] Requirements, XmlNode[] FeasibleSolutions, XmlNode[] Characteristics, XmlNode[] SubCharacteristics)
        {
            string links = @"var DecisionStructureLinks = [";
            string nodes = @" var DecisionStructureNodes = [";

            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            List<XmlNode> lstChar = new List<XmlNode>();
            List<XmlNode> lstSubChar = new List<XmlNode>();

            bool blnReq = true;

            if (Requirements.Length > 0)
            {
                for (int req = 0; req < Requirements.Length; req++)
                {
                    string color = "";

                    switch (Requirements[req].Attributes[5].Value)
                    {
                        case "M":
                            color = "#7D3C98";
                            break;
                        case "S":
                            color = "#58D68D";
                            break;
                        case "C":
                            color = "#EB984E";
                            break;
                        case "W":
                            color = "#A93226";
                            break;
                    }

                    nodes += @"{ ""key"":""" + Requirements[req].Attributes[0].Value + @""", ""text"":""" + LimitOnWordBoundary(Requirements[req].Attributes[1].Value, 37) + @""", ""fill"": '" + color + @"' },";
                    for (int FS = 0; FS < FeasibleSolutions.Length; FS++)
                    {
                        if (blnReq)
                            nodes += @"{ ""key"":""" + FeasibleSolutions[FS].Attributes[0].Value + @""", ""text"":""" + LimitOnWordBoundary(FeasibleSolutions[FS].Attributes[1].Value, 37) + @""", ""fill"": '#34495E' },";

                        if (obj_KB.isLinked(Requirements[req], FeasibleSolutions[FS]))
                            links += @"{ ""from"": '" + Requirements[req].Attributes[0].Value + @"',""to"": '" + FeasibleSolutions[FS].Attributes[0].Value + @"'},";
                    }
                    blnReq = false;
                }

                for (int SC = 0; SC < SubCharacteristics.Length; SC++)
                    for (int req = 0; req < Requirements.Length; req++)
                        if (obj_KB.isConnected(Requirements[req], SubCharacteristics[SC].Attributes[0].Value))
                        {
                            if (!lstSubChar.Contains(SubCharacteristics[SC]))
                            {
                                lstSubChar.Add(SubCharacteristics[SC]);
                                nodes += @"{ ""key"":""" + SubCharacteristics[SC].Attributes[0].Value + @""", ""text"":""" + LimitOnWordBoundary(SubCharacteristics[SC].Attributes[1].Value, 37) + @""", ""fill"": '#2980B9' },";
                            }
                            links += @"{ ""from"": '" + SubCharacteristics[SC].Attributes[0].Value + @"',""to"": '" + Requirements[req].Attributes[0].Value + @"'},";
                        }


                for (int SC = 0; SC < lstSubChar.Count; SC++)
                    for (int CH = 0; CH < Characteristics.Length; CH++)
                        if (obj_KB.isConnected(lstSubChar[SC], Characteristics[CH].Attributes[0].Value))
                        {
                            if (!lstChar.Contains(Characteristics[CH]))
                            {
                                lstChar.Add(Characteristics[CH]);
                                nodes += @"{ ""key"":""" + Characteristics[CH].Attributes[0].Value + @""", ""text"":""" + LimitOnWordBoundary(Characteristics[CH].Attributes[1].Value, 37) + @""", ""fill"": '#17A589' },";
                            }
                            links += @"{ ""from"": '" + Characteristics[CH].Attributes[0].Value + @"',""to"": '" + lstSubChar[SC].Attributes[0].Value + @"'},";
                        }

                nodes += @"{ ""key"":""" + Domain.Attributes[0].Value + @""", ""text"":""" + LimitOnWordBoundary(Domain.Attributes[1].Value, 37) + @""", ""fill"": '#D4AC0D' },";

                for (int CH = 0; CH < lstChar.Count; CH++)
                    links += @"{ ""from"": '" + Domain.Attributes[0].Value + @"',""to"": '" + lstChar[CH].Attributes[0].Value + @"'},";

                nodes = nodes.Substring(0, nodes.Length - 1) + "];";
                links = links.Substring(0, links.Length - 1) + "];  autoComplete();";
            }
            else
            {
                nodes += "];";
                links += "];autoComplete();";
            }

            SaveFile("DecisionStructure.js", (nodes + links));

        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_PieChartData(XmlNode[] Requirements, XmlNode[] Characteristics, XmlNode[] SubCharacteristics)
        {
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            Dictionary<string, double> lstQualityImpacts = obj_KB.GetQualityImpacts(Requirements, Characteristics, SubCharacteristics);

            string QualityAttributesRatio = @"QualityAttributesRatio = [['Quality Attributes', 'Impacts'],";

            foreach (string key in lstQualityImpacts.Keys)
                QualityAttributesRatio += "['" + LimitOnWordBoundary(key, 30) + "', " + Math.Round(lstQualityImpacts[key] * 100) + "],";

            QualityAttributesRatio = QualityAttributesRatio.Substring(0, QualityAttributesRatio.Length - 1) + "];";

            SaveFile("PieChartData.js", QualityAttributesRatio);

        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Random r = new Random();
        public string getRandomColor()
        {
            return "rgba(" + r.Next(255) + ", " + r.Next(255) + ", " + r.Next(255) + ", " + r.Next(255) + ")";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_BarGraphData(XmlNode[] FeasibleSolutions, double[] SolutionScores, int threshold)
        {
            string FeasibleSolutionsScores = @" FeasibleSolutionsScores = [ [""Solution"", ""Score (%)"", { role: ""style"" }],";

            for (int i = 0; i < FeasibleSolutions.Length && i < threshold; i++)
                FeasibleSolutionsScores += @"[""" + FeasibleSolutions[i].Attributes[1].Value + @"""," + Math.Floor(SolutionScores[i] * 100) + @", """ + GetColor() + @"""],";

            FeasibleSolutionsScores = FeasibleSolutionsScores.Substring(0, FeasibleSolutionsScores.Length - 1) + "];";
            SaveFile("BarGraphData.js", FeasibleSolutionsScores);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_ListOfInfeasibleSolutions(XmlNode[] InfeasibleSolutions)
        {
            string strListOfInfeasibleSolutions = @"
                        //Value= ID of the infeasible solution
                        var ListOfInfeasibleSolutions = [";
            for (int i = 0; i < InfeasibleSolutions.Length; i++)
                strListOfInfeasibleSolutions += @"{label: """ + InfeasibleSolutions[i].Attributes[1].Value + @""", value: """ + InfeasibleSolutions[i].Attributes[0].Value + @""" },";
            strListOfInfeasibleSolutions += @"]; autoComplete();";
            SaveFile("ListOfInfeasibleSolutions.js", strListOfInfeasibleSolutions);

        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public int MakeDecision()
        {
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            XmlNode[] Requirements = null;
            XmlNode[] FeasibleSolutions = null;
            double[] SolutionScores = null;
            XmlNode[] InfeasibleSolutions = null;
            XmlNode[] Characteristics = null;
            XmlNode[] SubCharacteristics = null;
            XmlNode Domain = null;

            obj_KB.MakeDecision(ref Domain, ref Requirements, ref FeasibleSolutions, ref SolutionScores, ref InfeasibleSolutions, ref Characteristics, ref SubCharacteristics);

            Generate_JS_DecisionMatrix(Requirements, FeasibleSolutions, SolutionScores, InfeasibleSolutions);
            Generate_JS_ListOfInfeasibleSolutions(InfeasibleSolutions);
            Generate_JS_BarGraphData(FeasibleSolutions, SolutionScores, 10);
            Generate_JS_PieChartData(Requirements, Characteristics, SubCharacteristics);
            Generate_JS_DecisionStructure(Domain, Requirements, FeasibleSolutions, Characteristics, SubCharacteristics);
            Generate_JS_Report(FeasibleSolutions);

            return FeasibleSolutions.Length;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_DecisionMatrix(XmlNode[] Requirements, XmlNode[] FeasibleSolutions, double[] SolutionScores, XmlNode[] InfeasibleSolutions)
        {
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            string DecisionMatrix_Columns = @"var DecisionMatrix_Columns = [" +
                                        @"{ title: ""FeatureID"", field: ""FeatureID"", sorter: ""string"", width: 259, visible: false }," +
                                        @"{ title: ""Feature Requirement"", field: ""Feature"", sorter: ""string"", width: 349, headerFilter: ""input"" }," +
                                        @"{ title: ""MoSCoW"", field: ""MoSCoW"", sorter: ""string"", editor: ""select"", width: 100, headerFilter: true, headerFilterParams: { values: { """": ""All"", ""Must-Have"": ""Must-Have"", ""Should-Have"": ""Should-Have"", ""Could-Have"": ""Could-Have"", ""Won't-Have"": ""Won't-Have"" } } },";
            string DecisionMatrix_datatable = @"var DecisionMatrix_datatable = [";

            string[] strFA = new string[Requirements.Length];

            if (FeasibleSolutions.Length > 0)
            {
                for (int FS = 0; FS < FeasibleSolutions.Length; FS++)
                {
                    DecisionMatrix_Columns += @"{ title: """ + LimitOnWordBoundary(FeasibleSolutions[FS].Attributes[1].Value, 15) + @""", field: ""A" + FS + @""", align: ""center"", formatter: ""tickCross"", headerSort: true, headerVertical: true, headerTooltip:""" + FeasibleSolutions[FS].Attributes[1].Value + @""" }, ";
                    for (int req = 0; req < Requirements.Length; req++)
                    {
                        strFA[req] += "A" + FS + @":" + (obj_KB.isConnected(FeasibleSolutions[FS], Requirements[req].Attributes[0].Value) ? "true" : "false") + @",";
                    }
                }

                for (int req = 0; req < Requirements.Length; req++)
                {
                    strFA[req] = strFA[req].Substring(0, strFA[req].Length - 1);
                    DecisionMatrix_datatable += @"{ id: " + (req + 1) + @",FeatureID:""" + Requirements[req].Attributes[0].Value + @""", Feature: """ + Requirements[req].Attributes[1].Value + @""", MoSCoW: """ + GetMoSCoWText(Requirements[req].Attributes[5].Value) + @"""," + strFA[req] + @" },";
                }
            }

            DecisionMatrix_Columns += "];";
            DecisionMatrix_datatable += @"];             
            table_decision_matrix.clearData();
            table_decision_matrix.setColumns(DecisionMatrix_Columns);
            table_decision_matrix.setData(DecisionMatrix_datatable); ";

            string strDecisionMatrix = DecisionMatrix_Columns + DecisionMatrix_datatable;
            SaveFile("DecisionMatrix.js", strDecisionMatrix);

        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void Generate_JS_Aspects(string level)
        {
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            List<XmlNode> lstFeatures = new List<XmlNode>();
            List<XmlNode> lstAlternatives = new List<XmlNode>(); ;
            List<XmlNode> lstRequirements = new List<XmlNode>();
            List<XmlNode> Characteristics = new List<XmlNode>();
            List<XmlNode> SubCharacteristics = new List<XmlNode>();
            XmlNode Domain = null;
            obj_KB.GetAllNodeTypes(ref Domain, ref lstFeatures, ref lstAlternatives, ref lstRequirements, ref Characteristics, ref SubCharacteristics);

            string
                Aspects_datatable = @" Aspects_datatable = [ ",
                Aspects_columns = @"var Aspects_columns = [ ",
                Mapping_datatable = @"Mapping_datatable = [ ",
                Mapping_columns = @"var Mapping_columns = [ ",
                Icons = @"var DeleteIcon = function (cell, formatterParams) { return ""<i class='fas fa-trash-alt'></i>"";};" +
                        @"var UpdateIcone = function(cell, formatterParams) { return ""<i class='fas fa-sync-alt'></i>"";};";

            if (level == "Qualities")
            {
                Aspects_columns += @" { title: ""AspectID"", field: ""AspectID"", sorter: ""string"", width: 200, visible: false }," +
                                   @" { title: ""Quality Attribute"", field: ""QualityAttribute"", sorter: ""string"", width: 225, headerFilter: ""input"", editor: ""input"" }," +
                                   @" { title: ""Description"", field: ""Description"", sorter: ""string"", width: 600, headerFilter: ""input"", editor: ""input"" }," +
                                   @" {" +
                                        @"title: ""Level"", field: ""Level"", sorter: ""string"", editor: ""select"", width: 120, headerFilter: true," +
                                        @"headerFilterParams: { values: { """": ""All"", ""Characteristic"": ""Characteristic"", ""Subcharacteristic"": ""Subcharacteristic"" } }," +
                                        @"editorParams: { values: { ""Characteristic"": ""Characteristic"", ""Subcharacteristic"": ""Subcharacteristic"" } }" +
                                   @"}," +
                                   @" { formatter: UpdateIcone, width: 30, align: ""center"", tooltip: ""Update"", 
                                            cellClick:function(e, cell){
                                                var row = cell.getRow();
                                                UpdateAspect(row.getData(), ""Qualities"");
                                            }
                                      }," +
                                   @" { formatter: DeleteIcon, width: 30, align: ""center"", tooltip: ""Delete"", 
                                            cellClick:function(e, cell){
                                                var row = cell.getRow();
                                                DeleteAspect(row.getData().AspectID, ""Qualities"");
                                            }
                                   },";

                Mapping_columns += @"{ title: ""AspectID"", field: ""AspectID"", sorter: ""string"", width: 200, visible: false }," +
                                   @"{ title: ""Quality Attribute"", field: ""QualityAttribute"", sorter: ""string"", width: 225, headerFilter: ""input"", editor: ""input"" }," +
                                   @"{ title: """ + LimitOnWordBoundary(Domain.Attributes[1].Value, 15) +
                                   @""", field: """ + Domain.Attributes[1].Value +
                                   @""", align: ""center"", editor: true,                                             
                                   cellEdited:function(cell){
                                        var row = cell.getRow();
                                        var column=cell.getColumn();
                                        UpdateLinks(row.getData().AspectID, """ + Domain.Attributes[0].Value + @""", cell.getValue());
                                    }, 
                                    formatter: ""tickCross"", headerSort: true, headerVertical: true, headerTooltip:""" +
                                   Domain.Attributes[1].Value + @""" },";

                for (int i = 0; i < Characteristics.Count; i++)
                {
                    Aspects_datatable += @"{AspectID:""" + Characteristics[i].Attributes[0].Value +
                                         @""" ,QualityAttribute:""" + Characteristics[i].Attributes[1].Value +
                                         @""" ,Description:""" + Characteristics[i].Attributes[4].Value +
                                         @""" ,Level:""" + Characteristics[i].Attributes[3].Value + @"""},";

                    Mapping_columns += @"{ title: """ + LimitOnWordBoundary(Characteristics[i].Attributes[1].Value, 15) +
                                       @""", field: """ + Characteristics[i].Attributes[1].Value +
                                       @""", align: ""center"", editor: true, formatter: ""tickCross"", headerSort: true, headerVertical: true, 
                                       cellEdited:function(cell){
                                                var row = cell.getRow();
                                                var column=cell.getColumn();
                                                UpdateLinks(row.getData().AspectID ,""" + Characteristics[i].Attributes[0].Value + @""", cell.getValue());
                                       }, 
                                       headerTooltip:""" +
                                       Characteristics[i].Attributes[1].Value + @""" },";

                    Mapping_datatable += @"{ id: " + (i + 1) +
                                         @",AspectID:""" + Characteristics[i].Attributes[0].Value +
                                         @""", QualityAttribute: """ + Characteristics[i].Attributes[1].Value +
                                         @""", """ + Domain.Attributes[1].Value +
                                         @""":" + (obj_KB.isConnected(Characteristics[i], Domain.Attributes[0].Value) ? "true" : "false") + @",";

                    for (int j = 0; j < Characteristics.Count; j++)
                        Mapping_datatable += @"""" + Characteristics[i].Attributes[1].Value + @""":" + (obj_KB.isConnected(Characteristics[i], Characteristics[j].Attributes[0].Value) ? "true" : "false") + @",";

                    Mapping_datatable = Mapping_datatable.Substring(0, Mapping_datatable.Length - 1) + "},";
                }
                for (int i = 0; i < SubCharacteristics.Count; i++)
                {
                    Aspects_datatable += @"{ AspectID:""" + SubCharacteristics[i].Attributes[0].Value +
                                         @""" ,QualityAttribute:""" + SubCharacteristics[i].Attributes[1].Value +
                                         @""" ,Description:""" + SubCharacteristics[i].Attributes[4].Value +
                                         @""" ,Level:""" + SubCharacteristics[i].Attributes[3].Value + @"""},";

                    Mapping_datatable += @"{ id: " + (i + 1) +
                                         @",AspectID:""" + SubCharacteristics[i].Attributes[0].Value +
                                         @""", QualityAttribute: """ + SubCharacteristics[i].Attributes[1].Value +
                                         @""", """ + Domain.Attributes[1].Value +
                                         @""":" + (obj_KB.isConnected(SubCharacteristics[i], Domain.Attributes[0].Value) ? "true" : "false") + @",";

                    for (int j = 0; j < Characteristics.Count; j++)
                        Mapping_datatable += @"""" + Characteristics[j].Attributes[1].Value + @""":" + (obj_KB.isConnected(SubCharacteristics[i], Characteristics[j].Attributes[0].Value) ? "true" : "false") + @",";

                    Mapping_datatable = Mapping_datatable.Substring(0, Mapping_datatable.Length - 1) + "},";
                }
            }
            else if (level == "Features")
            {
                string[] strArrGroups = obj_KB.GetAllGroups();
                string UICategory = @"{";

                for (int i = 0; i < strArrGroups.Length; i++)
                    UICategory += @" """ + strArrGroups[i] + @""":""" + strArrGroups[i] + @""" ,";
                UICategory = UICategory.Substring(0, UICategory.Length - 1) + "}";

                string MemberOf = @"{""NULL"":""NULL"",";
                clsFeatures[] objMainFeatures = obj_KB.GetAllMainFeatures();
                for (int i = 0; i < objMainFeatures.Length; i++)
                    MemberOf += @" """ + objMainFeatures[i].Title + @""":""" + objMainFeatures[i].Title + @""" ,";
                MemberOf = MemberOf.Substring(0, MemberOf.Length - 1) + "}";

                Aspects_columns += @" { title: ""AspectID"", field: ""AspectID"", sorter: ""string"", width: 200, visible: false }," +
                   @" { title: ""Feature"", field: ""Feature"", sorter: ""string"", width: 200, headerFilter: ""input"", editor: ""input"" }," +
                   @" {" +
                       @"title: ""Data Type"", field: ""DataType"", sorter: ""string"", editor: ""select"", width: 100, headerFilter: true," +
                       @"headerFilterParams: { values:{""Boolean"":""Boolean"",""Numeric"":""Numeric"",""Monetary"":""Monetary"", ""Description"":""Description"" } }," +
                       @"editorParams: { values: {""Boolean"":""Boolean"",""Numeric"":""Numeric"",""Monetary"":""Monetary"", ""Description"":""Description"" } }" +
                   @"}," +
                   @" {" +
                       @"title: ""Member Of"", field: ""MemberOf"", sorter: ""string"", editor: ""select"", width: 150, headerFilter: true," +
                       @"headerFilterParams: { values: " + MemberOf + " }," +
                       @"editorParams: { values: " + MemberOf + " }" +
                   @"}," +
                   @" {" +
                       @"title: ""UI Category"", field: ""UICategory"", sorter: ""string"", editor: ""select"", width: 150, headerFilter: true," +
                       @"headerFilterParams: { values: " + UICategory + " }," +
                       @"editorParams: { values: " + UICategory + " }" +
                   @"}," +
                   @" { title: ""Keywords"", field: ""Keywords"", sorter: ""string"", width: 150, headerFilter: ""input"", editor: ""input"" }," +
                   @" { title: ""Description"", field: ""Description"", sorter: ""string"", width: 200, headerFilter: ""input"", editor: ""input"" }," +
                   @" { formatter: UpdateIcone, width: 30, align: ""center"", tooltip: ""Update"", 
                                            cellClick:function(e, cell){
                                                var row = cell.getRow();
                                                UpdateAspect(row.getData(), ""Features"");
                                            }
                      }," +
                   @" { formatter: DeleteIcon, width: 30, align: ""center"", tooltip: ""Delete"", 
                                            cellClick:function(e, cell){
                                                var row = cell.getRow();
                                                DeleteAspect(row.getData().AspectID, ""Features"");
                                            }
                      },";

                Mapping_columns += @" { title: ""AspectID"", field: ""AspectID"", sorter: ""string"", width: 200, visible: false }," +
                                   @" { title: ""Feature"", field: ""Feature"", sorter: ""string"", width: 200, headerFilter: ""input"", editor: ""input""},";

                for (int i = 0; i < lstFeatures.Count; i++)
                {
                    Aspects_datatable += @"{" +
                        @"AspectID:""" + lstFeatures[i].Attributes[0].Value + @"""," +
                        @"Feature:""" + lstFeatures[i].Attributes[1].Value.Replace("'", "&quot;").Replace("\"", "") + @"""," +
                        @"DataType:""" + lstFeatures[i].Attributes[2].Value.Replace("'", "&quot;").Replace("\"", "") + @"""," +
                        @"MemberOf:""" + lstFeatures[i].Attributes[7].Value.Replace("'", "&quot;").Replace("\"", "") + @"""," +
                        @"UICategory:""" + lstFeatures[i].Attributes[6].Value.Replace("'", "&quot;").Replace("\"", "") + @"""," +
                        @"Keywords:""" + lstFeatures[i].Attributes[9].Value.Replace("'", "&quot;").Replace("\"", "") + @"""," +
                        @"Description:""" + lstFeatures[i].Attributes[4].Value.Replace("'", "&quot;").Replace("\"", "") + @"""},";

                    Mapping_datatable += @"{ id: " + (i + 1) +
                                         @", AspectID:""" + lstFeatures[i].Attributes[0].Value +
                                         @""", Feature: """ + lstFeatures[i].Attributes[1].Value +
                                         @""", ";

                    for (int j = 0; j < SubCharacteristics.Count; j++)
                        Mapping_datatable += @"""" + SubCharacteristics[j].Attributes[1].Value + @""":" + (obj_KB.isConnected(lstFeatures[i], SubCharacteristics[j].Attributes[0].Value) ? "true" : "false") + @",";

                    Mapping_datatable = Mapping_datatable.Substring(0, Mapping_datatable.Length - 1) + "},";

                }
                for (int i = 0; i < SubCharacteristics.Count; i++)
                {
                    Mapping_columns += @"{ title: """ + LimitOnWordBoundary(SubCharacteristics[i].Attributes[1].Value, 15) +
                                       @""", field: """ + SubCharacteristics[i].Attributes[1].Value +
                                       @""", align: ""center"", editor: true, formatter: ""tickCross"",                         
                                            headerSort: true, headerVertical: true, 
                                            cellEdited:function(cell){
                                                var row = cell.getRow();
                                                var column=cell.getColumn();
                                                UpdateLinks(row.getData().AspectID ,""" + SubCharacteristics[i].Attributes[0].Value + @""", cell.getValue());
                                            },
                                            headerTooltip:""" +
                                       SubCharacteristics[i].Attributes[1].Value + @""" },";
                }
            }
            else if (level == "Alternatives")
            {
                Aspects_columns += @" { title: ""AspectID"", field: ""AspectID"", sorter: ""string"", width: 200, visible: false }," +
                   @" { title: ""Alternative"", field: ""Alternative"", sorter: ""string"", width: 225, headerFilter: ""input"", editor: ""input"" }," +
                   @" { title: ""Description"", field: ""Description"", sorter: ""string"", width: 520, headerFilter: ""input"", editor: ""input"" }," +
                   @" { title: ""Corporation"", field: ""Corporation"", sorter: ""string"", width: 200, headerFilter: ""input"", editor: ""input"" }," +
                   @" { formatter: UpdateIcone, width: 30, align: ""center"", tooltip: ""Update"", field: ""Update"", 
                                            cellClick:function(e, cell){
                                                var row = cell.getRow();
                                                UpdateAspect(row.getData(), ""Alternatives"");
                                            }
                   }," +
                   @" { formatter: DeleteIcon, width: 30, align: ""center"", tooltip: ""Delete"", field: ""Delete"", 
                                            cellClick:function(e, cell){
                                                var row = cell.getRow();
                                                DeleteAspect(row.getData().AspectID, ""Alternatives"");
                                            }
                       },";

                Mapping_columns += @" { title: ""AspectID"", field: ""AspectID"", sorter: ""string"", width: 200, visible: false }," +
                                   @" { title: ""Alternative"", field: ""Alternative"", sorter: ""string"", width: 225, headerFilter: ""input"", editor: ""input"" },";

                for (int i = 0; i < lstAlternatives.Count; i++)
                {
                    Aspects_datatable += @"{" +
                                            @"AspectID:""" + lstAlternatives[i].Attributes[0].Value + @"""," +
                                            @"Alternative:""" + lstAlternatives[i].Attributes[1].Value.Replace("'", "&quot;").Replace("\"", "") + @"""," +
                                            @"Corporation:""" + lstAlternatives[i].Attributes[6].Value.Replace("'", "&quot;").Replace("\"", "") + @"""," +
                                            @"Description:""" + lstAlternatives[i].Attributes[4].Value.Replace("'", "&quot;").Replace("\"", "") + @"""},";


                    Mapping_datatable += @"{ id: " + (i + 1) +
                                         @",AspectID:""" + lstAlternatives[i].Attributes[0].Value +
                                         @""", Alternative: """ + lstAlternatives[i].Attributes[1].Value +
                                         @""", ";


                    for (int j = 0; j < lstFeatures.Count; j++)
                        Mapping_datatable += @"""" + lstFeatures[j].Attributes[1].Value + @""":" + (obj_KB.isConnected(lstAlternatives[i], lstFeatures[j].Attributes[0].Value) ? "true" : "false") + @",";

                    Mapping_datatable = Mapping_datatable.Substring(0, Mapping_datatable.Length - 1) + "},";
                }


                for (int i = 0; i < lstFeatures.Count; i++)
                {
                    Mapping_columns += @"{ title: """ + LimitOnWordBoundary(lstFeatures[i].Attributes[1].Value, 15) +
                   @""", field: """ + lstFeatures[i].Attributes[1].Value +
                   @""", align: ""center"", editor: true, formatter: ""tickCross"", headerSort: true, headerVertical: true, 
                    cellEdited:function(cell){
                        var row = cell.getRow();
                        var column=cell.getColumn();
                        UpdateLinks(row.getData().AspectID ,""" + lstFeatures[i].Attributes[0].Value + @""", cell.getValue());
                    },
                    headerTooltip:""" +
                   lstFeatures[i].Attributes[1].Value + @""" },";
                }
            }

            Aspects_columns = Aspects_columns.Substring(0, Aspects_columns.Length - 1) + "];";
            Aspects_datatable = Aspects_datatable.Substring(0, Aspects_datatable.Length - 1) + "];";
            Mapping_datatable = Mapping_datatable.Substring(0, Mapping_datatable.Length - 1) + "];";
            Mapping_columns = Mapping_columns.Substring(0, Mapping_columns.Length - 1) + "];";

            string Aspects = Icons + Aspects_columns + Aspects_datatable + Mapping_columns + Mapping_datatable + "Table_Aspects.setData(Aspects_datatable);Table_Mapping.setData(Mapping_datatable); ";
            SaveFile("Aspects.js", Aspects);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string LimitOnWordBoundary(string str, int count)
        {
            if (str.Length <= count - 3)
                return str;
            else
            {
                int lastspace = str.Substring(0, count - 3).LastIndexOf(' ');
                if (lastspace > 0 && lastspace > count - 20)
                {
                    // limits the backward search to a max of 20 chars
                    return str.Substring(0, lastspace) + "...";
                }
                else
                {
                    // No space in the last 20 chars, so get all the string minus 3
                    return str.Substring(0, count - 3) + "...";
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}