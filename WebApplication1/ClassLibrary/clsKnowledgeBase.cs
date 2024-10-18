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
    public class clsCase
    {
        public string title;
        public string explanation;
        public string imageFileName;
        public string decisionModel;
        public string KBfilename;
        public string email;
        public string UID;
    }

    public class clsFeatures
    {
        public string ID;
        public string Title;
        public string DataType;
        public string Description;
        public string Req;
        public string Order;
        public string UpperLevel;
        public string Criterion;
        public string Keywords;
        public int SupportedAlternatives;
    }


    public class clsKnowledgeBase
    {
        private int FeasibleSolutionsThreshold = 10;


        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string Get_Profile_Path()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["UID"] != null)
            {
                return HttpContext.Current.Server.MapPath(@"~\XML_DB\Profiles\" + HttpContext.Current.Session["UID"] + @"\");
            }
           
            return "NULL";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string Get_Local_KB()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["KB_Location"].ToString() != "No File")
            {
                return HttpContext.Current.Session["KB_Location"].ToString();
            }
            return "NULL";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string Get_Standard_KB(string DecisionModel)
        {
            string sourceFile = "";
            string sourcePath = HttpContext.Current.Server.MapPath((@"~\XML_DB\\KB"));

            if (HttpContext.Current.Session != null && HttpContext.Current.Session["Main_KB_Location"] != null)
            {
                if (DecisionModel == "DBMSMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "DBMS_KB.xml");
                else if (DecisionModel == "CSPMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "CSP_KB.xml");
                else if (DecisionModel == "AFAS_Generator")
                    sourceFile = System.IO.Path.Combine(sourcePath, "AFAS_Generator.xml");
                else if (DecisionModel == "BPMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "Blockchain_KB.xml");
                else if (DecisionModel == "SWAPMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "SWAP_KB.xml");
                else if (DecisionModel == "PLMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "PL_KB.xml");
                else if (DecisionModel == "MDDMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "MDD_KB.xml");
                else if (DecisionModel == "BPMLMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "BPML_KB.xml");
                else if (DecisionModel == "DAOMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "DAO_KB.xml");
                else if (DecisionModel == "QAMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "QA_KB.xml");
                else if (DecisionModel == "NEWMODEL")
                    sourceFile = System.IO.Path.Combine(sourcePath, "NewDecisionModel.xml");

                return sourceFile;
            }
            return "NULL";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string Get_User_Accounts_File()
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserAccountDB"] != null)
            {
                return HttpContext.Current.Server.MapPath(HttpContext.Current.Session["UserAccountDB"].ToString());
            }
            return "NULL";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string GetInitialCaseTitle(string DecisionModel)
        {
            string title = "";
            if (DecisionModel == "DBMSMODEL")
                title = "Database Technology Selection";
            else if (DecisionModel == "CSPMODEL")
                title = "Cloud Service Provider Selection";
            else if (DecisionModel == "AFAS_GENERATOR_MODEL")
                title = "";
            else if (DecisionModel == "BPMODEL")
                title = "Blockchain Platform Selection";
            else if (DecisionModel == "SWAPMODEL")
                title = "Software Architecture Pattern Selection";
            else if (DecisionModel == "PLMODEL")
                title = "Programming Language Selection";
            else if (DecisionModel == "MDDMODEL")
                title = "MDD Platform Selection";
            else if (DecisionModel == "BPMLMODEL")
                title = "BPML Platform Selection";
            else if (DecisionModel == "DAOMODEL")
                title = "DAO Platform Selection";
            else if (DecisionModel == "QAMODEL")
                title = "Quality Assessment Model Selection";


            

            return title;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool Create_New_Case(string DecisionModel, string temporary)
        {
            try
            {
                HttpContext.Current.Session["CurrentDecisionModel"] = DecisionModel;
                string sourceFile = Get_Standard_KB(DecisionModel);
                string targetPath = Get_Profile_Path();
                string fileName = CreateString(8) + ".xml";

                string imgFileName = "DM_Default.png";

                string destFile = System.IO.Path.Combine(targetPath, fileName);

                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                System.IO.File.Copy(sourceFile, destFile, true);

                HttpContext.Current.Session["Main_KB_Location"] = sourceFile;

                HttpContext.Current.Session["KB_Location"] = destFile;
                AssignKB2UserAccount(GetInitialCaseTitle(DecisionModel), "", fileName, "false", "Novice", "Requirement gathering and analysis", imgFileName, temporary);

                return true;
            }
            catch
            {
                return false;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool UserLogin(string email, string password)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode user in root)
                if (user.Attributes[5].Value == email && user.Attributes[7].Value == password)
                {
                    HttpContext.Current.Session["CurrentUserEmail"] = email;
                    HttpContext.Current.Session["UID"] = user.Attributes[9].Value;
                    return true;
                }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool createNewProfile(string Name, string Company, string Address, string Zip, string phone, string email, string Confidentity, string password)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Get_User_Accounts_File());

                XmlNode newUser, root = doc.FirstChild;

                newUser = doc.CreateElement("user");

                XmlAttribute AttributeName = doc.CreateAttribute("Name");
                AttributeName.Value = Name;

                XmlAttribute AttributeCompany = doc.CreateAttribute("Company");
                AttributeCompany.Value = Company;

                XmlAttribute AttributeAddress = doc.CreateAttribute("Address");
                AttributeAddress.Value = Address;

                XmlAttribute AttributeZip = doc.CreateAttribute("Zip");
                AttributeZip.Value = Zip;

                XmlAttribute AttributePhone = doc.CreateAttribute("Phone");
                AttributePhone.Value = phone;

                XmlAttribute AttributeEmail = doc.CreateAttribute("Email");
                AttributeEmail.Value = email;

                XmlAttribute AttributeConfidentity = doc.CreateAttribute("Confidentity");
                AttributeConfidentity.Value = Confidentity;

                XmlAttribute AttributePassword = doc.CreateAttribute("Password");
                AttributePassword.Value = password;

                XmlAttribute AttributeActivated = doc.CreateAttribute("Activated");
                AttributeActivated.Value = "false";

                XmlAttribute AttributeUID = doc.CreateAttribute("UID");
                AttributeUID.Value = CreateString(20);


                newUser.Attributes.Append(AttributeName);
                newUser.Attributes.Append(AttributeCompany);
                newUser.Attributes.Append(AttributeAddress);
                newUser.Attributes.Append(AttributeZip);
                newUser.Attributes.Append(AttributePhone);
                newUser.Attributes.Append(AttributeEmail);
                newUser.Attributes.Append(AttributeConfidentity);
                newUser.Attributes.Append(AttributePassword);
                newUser.Attributes.Append(AttributeActivated);
                newUser.Attributes.Append(AttributeUID);

                root.AppendChild(newUser);

                doc.Save(Get_User_Accounts_File());

                return true;
            }
            catch
            {
                return false;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public XmlNode getUserByEmail(string email)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;

            foreach (XmlNode user in root)
                if (user.Attributes[5].Value == email)
                    return user;
            return null;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool AssignKB2UserAccount(string title, string explanation, string fileName, string privacy, string SDLC_Phase, string Proficiency, string ImageFileName, string Temporary)
        {
            bool appendSucessfully = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode user in root)
                if (user.Attributes[5].Value == HttpContext.Current.Session["CurrentUserEmail"].ToString())
                {
                    try
                    {
                        XmlNode Link;
                        XmlAttribute AttributeTitle = doc.CreateAttribute("title");
                        AttributeTitle.Value = title;
                        XmlAttribute AttributeExplanation = doc.CreateAttribute("explanation");
                        AttributeExplanation.Value = explanation;
                        XmlAttribute AttributeFileName = doc.CreateAttribute("filename");
                        AttributeFileName.Value = fileName;
                        XmlAttribute AttributeCreationDate = doc.CreateAttribute("created");
                        AttributeCreationDate.Value = DateTime.Now.ToString();
                        XmlAttribute AttributeLastAccessDate = doc.CreateAttribute("lastAccess");
                        AttributeLastAccessDate.Value = DateTime.Now.ToString();
                        XmlAttribute AttributePrivacy = doc.CreateAttribute("privacy");
                        AttributePrivacy.Value = privacy;
                        XmlAttribute AttributeGoal = doc.CreateAttribute("Goal");
                        AttributeGoal.Value = HttpContext.Current.Session["CurrentDecisionModel"].ToString();

                        XmlAttribute AttributeSDLC_Phase = doc.CreateAttribute("SDLC_Phase");
                        AttributeSDLC_Phase.Value = SDLC_Phase;
                        XmlAttribute AttributeProficiency = doc.CreateAttribute("Proficiency");
                        AttributeProficiency.Value = Proficiency;

                        XmlAttribute AttributeImage = doc.CreateAttribute("ImageFileName");
                        AttributeImage.Value = ImageFileName;

                        XmlAttribute OpenTemporary = doc.CreateAttribute("OpenTemporary");
                        OpenTemporary.Value = Temporary;


                        Link = doc.CreateElement("dilemma");
                        Link.Attributes.Append(AttributeTitle);
                        Link.Attributes.Append(AttributeExplanation);
                        Link.Attributes.Append(AttributeFileName);
                        Link.Attributes.Append(AttributeCreationDate);
                        Link.Attributes.Append(AttributeLastAccessDate);
                        Link.Attributes.Append(AttributePrivacy);
                        Link.Attributes.Append(AttributeGoal);
                        Link.Attributes.Append(AttributeSDLC_Phase);
                        Link.Attributes.Append(AttributeProficiency);
                        Link.Attributes.Append(AttributeImage);
                        Link.Attributes.Append(OpenTemporary);

                        user.AppendChild(Link);
                        doc.Save(HttpContext.Current.Server.MapPath(HttpContext.Current.Session["UserAccountDB"].ToString()));
                        appendSucessfully = true;
                    }
                    catch { }
                    break;
                }
            return appendSucessfully;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool Update_Current_Case(string title, string explanation)
        {
            bool updateSuccessfully = false;
            string filename = Get_Local_KB().Substring(Get_Local_KB().LastIndexOf("\\") + 1);
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode user in root)
                if (user.Attributes[5].Value == HttpContext.Current.Session["CurrentUserEmail"].ToString())
                {
                    foreach (XmlNode dilemma in user.ChildNodes)
                        if (dilemma.Attributes[2].Value == filename)
                        {
                            try
                            {
                                dilemma.Attributes[0].Value = title;
                                dilemma.Attributes[1].Value = explanation;
                                doc.Save(Get_User_Accounts_File());
                                Update_Domain(title, explanation);
                                updateSuccessfully = true;
                            }
                            catch
                            { }
                            break;
                        }
                    break;
                }
            return updateSuccessfully;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public XmlNode Add_New_Aspect(string title, string datatype, string description, string level, string order, string UpperLevel, string Keywords)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;

            XmlNode newNode = doc.CreateElement("node");
            XmlAttribute AttributeTitle = doc.CreateAttribute("Title");
            AttributeTitle.Value = title;
            XmlAttribute AttributeDataType = doc.CreateAttribute("DataType");
            AttributeDataType.Value = datatype;
            XmlAttribute AttributeDescription = doc.CreateAttribute("Description");
            AttributeDescription.Value = description;
            XmlAttribute AttributeLevel = doc.CreateAttribute("Level");
            AttributeLevel.Value = level;
            XmlAttribute AttributeID = doc.CreateAttribute("ID");
            AttributeID.Value = getUniqueID();
            XmlAttribute AttributeReq = doc.CreateAttribute("Req");
            AttributeReq.Value = "N";
            XmlAttribute AttributeOrder = doc.CreateAttribute("Order");
            AttributeOrder.Value = order;
            XmlAttribute AttributeUpperLevel = doc.CreateAttribute("UpperLevel");
            AttributeUpperLevel.Value = UpperLevel;
            XmlAttribute AttributeCriterion = doc.CreateAttribute("Criterion");
            AttributeCriterion.Value = "None";
            XmlAttribute AttributeKeywords = doc.CreateAttribute("Keywords");
            AttributeKeywords.Value = Keywords;

            newNode.Attributes.Append(AttributeID);
            newNode.Attributes.Append(AttributeTitle);
            newNode.Attributes.Append(AttributeDataType);
            newNode.Attributes.Append(AttributeLevel);
            newNode.Attributes.Append(AttributeDescription);
            newNode.Attributes.Append(AttributeReq);
            newNode.Attributes.Append(AttributeOrder);
            newNode.Attributes.Append(AttributeUpperLevel);
            newNode.Attributes.Append(AttributeCriterion);
            newNode.Attributes.Append(AttributeKeywords);

            root.AppendChild(newNode);
            try
            {
                doc.Save(Get_Local_KB());
            }
            catch { }
            return newNode;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string getUniqueID()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_User_Accounts_File());

            string ID = DateTime.UtcNow.Ticks.ToString();

            while (getNodeById(ID, doc) != null)
            {
                ID = DateTime.UtcNow.Ticks.ToString();
            }

            return ID;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool Update_Domain(string domainTitle, string domainDescription)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;

            foreach (XmlNode node in root)
            {
                if (node.Attributes[3].Value == "Domain")
                {
                    node.Attributes[1].Value = domainTitle;
                    node.Attributes[4].Value = domainDescription;
                    break;
                }
            }
            try
            {
                doc.Save(Get_Local_KB());
                return true;
            }
            catch { }

            return false;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool CreateLink(string id, string Parent)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());

            XmlNode node = getNodeById(id, doc);

            XmlNode Link;
            XmlAttribute AttributeParent = doc.CreateAttribute("Parent");
            AttributeParent.Value = Parent;
            XmlAttribute AttributeValue = doc.CreateAttribute("Value");
            AttributeValue.Value = "1";
            XmlAttribute AttributeActive = doc.CreateAttribute("Active");
            AttributeActive.Value = "T";
            Link = doc.CreateElement("link");
            Link.Attributes.Append(AttributeParent);
            Link.Attributes.Append(AttributeValue);
            Link.Attributes.Append(AttributeActive);
            node.AppendChild(Link);
            try
            {
                doc.Save(Get_Local_KB());

                return true;
            }
            catch { return false; }
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool CreateLink(XmlDocument doc, XmlNode node, string Parent)
        {

            XmlNode Link;
            XmlAttribute AttributeParent = doc.CreateAttribute("Parent");
            AttributeParent.Value = Parent;
            XmlAttribute AttributeValue = doc.CreateAttribute("Value");
            AttributeValue.Value = "1";
            XmlAttribute AttributeActive = doc.CreateAttribute("Active");
            AttributeActive.Value = "T";
            Link = doc.CreateElement("link");
            Link.Attributes.Append(AttributeParent);
            Link.Attributes.Append(AttributeValue);
            Link.Attributes.Append(AttributeActive);
            node.AppendChild(Link);
            try
            {
                doc.Save(Get_Local_KB());

                return true;
            }
            catch { return false; }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void UpdateLinkValue(string id, string parent, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());

            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[0].Value == id)
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                        if (node.ChildNodes[i].Name == "link" && node.ChildNodes[i].Attributes[0].Value == parent)
                        {
                            node.ChildNodes[i].Attributes[1].Value = value;
                            break;
                        }
                    break;
                }
            try
            {
                doc.Save(Get_Local_KB());
            }
            catch { }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public bool UpdateLink(string id, string parent, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode node = getNodeById(id, doc);

            if (bool.Parse(value))
                return CreateLink(doc, node, parent);
            else
                return DeleteLink(doc, node, parent);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool UpdateImage_Current_Case(string ImageFileName)
        {
            bool updateSuccessfully = false;

            string KBLocation = Get_Local_KB();
            string filename = KBLocation.Substring(KBLocation.LastIndexOf("\\") + 1);

            XmlDocument doc = new XmlDocument();
            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode user in root)
                if (user.Attributes[5].Value == HttpContext.Current.Session["CurrentUserEmail"].ToString())
                {
                    foreach (XmlNode dilemma in user.ChildNodes)
                        if (dilemma.Attributes[2].Value == filename)
                        {
                            try
                            {
                                string currentImage = dilemma.Attributes[9].Value;
                                dilemma.Attributes[9].Value = ImageFileName;
                                doc.Save(Get_User_Accounts_File());

                                if (currentImage != "DM_Default.png" && File.Exists(HttpContext.Current.Server.MapPath(@"~\Image\Cases\" + currentImage)))
                                    File.Delete(HttpContext.Current.Server.MapPath(@"~\Image\Cases\" + currentImage));

                                updateSuccessfully = true;
                            }
                            catch
                            { }
                            break;
                        }
                    break;
                }
            return updateSuccessfully;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool DeleteCaseByFilename(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;

            try
            {
                foreach (XmlNode user in root)
                    if (user.Attributes[5].Value == HttpContext.Current.Session["CurrentUserEmail"].ToString())
                    {
                        foreach (XmlNode dilemma in user.ChildNodes)
                            if (dilemma.Attributes[2].Value == filename)
                            {
                                user.RemoveChild(dilemma);
                                doc.Save(Get_User_Accounts_File());

                                if (File.Exists(Get_Profile_Path() + filename))
                                    File.Delete(Get_Profile_Path() + filename);

                                HttpContext.Current.Session["KB_Location"] = HttpContext.Current.Session["Main_KB_Location"] = "No File";

                                break;
                            }
                        break;
                    }
            }
            catch
            {
                return false;
            }
            return true;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void UpdateAspect(string id, string title, string datatype, string description, string level, string order, string UpperLevel, string Keywords)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;

            foreach (XmlNode node in root)
            {
                if (node.Attributes[0].Value == id)
                {
                    node.Attributes[1].Value = title;
                    node.Attributes[2].Value = datatype;
                    node.Attributes[3].Value = level;
                    node.Attributes[4].Value = description;
                    node.Attributes[6].Value = order;
                    node.Attributes[7].Value = UpperLevel;
                    node.Attributes[9].Value = Keywords;
                    break;
                }
            }
            try
            {
                doc.Save(Get_Local_KB());
            }
            catch { }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool DeleteAspect(string AspectID)
        {
            try
            {
                DeleteNode(AspectID);
                MakeConsistent();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void DeleteNode(string id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;

            foreach (XmlNode node in root)
                if (node.Attributes[0].Value == id)
                {
                    doc.FirstChild.RemoveChild(node);
                    break;
                }
            try
            {
                doc.Save(Get_Local_KB());
            }
            catch { }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void MakeConsistent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;

            foreach (XmlNode node in root)
            {
                for (int i = 0; i < node.ChildNodes.Count; i++)
                    if ((node.ChildNodes[i].Name == "link" || (node.ChildNodes[i].Name == "alternative")) && (getNodeById(node.ChildNodes[i].Attributes[0].Value, doc) == null))
                        DeleteLink(doc, node, node.ChildNodes[i].Attributes[0].Value);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool DeleteLink(XmlDocument doc, XmlNode node, string Parent)
        {
            try
            {
                XmlNode root = doc.FirstChild;

                foreach (XmlNode child in node.ChildNodes)
                    if (child.Attributes[0].Value == Parent)
                        node.RemoveChild(child);

                doc.Save(Get_Local_KB());

                return true;
            }
            catch { return false; }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public clsCase OpenCase(string userEmail, string CaseFilename)
        {
            bool found = false;
            clsCase objCase = new clsCase();
            XmlDocument doc = new XmlDocument();

            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode user in root)
                if (user.Attributes[5].Value == userEmail)
                {
                    foreach (XmlNode dilemma in user.ChildNodes)
                        if (dilemma.Attributes[2].Value == CaseFilename)
                        {
                            objCase.title = dilemma.Attributes[0].Value;
                            objCase.explanation = dilemma.Attributes[1].Value;
                            objCase.decisionModel = dilemma.Attributes[6].Value;
                            objCase.imageFileName = dilemma.Attributes[9].Value;
                            found = true;
                            break;
                        }
                    break;
                }

            if (!found)
                return null;

            return objCase;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public clsCase getByCaseFilename(string CaseFilename)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode user in root)
            {
                foreach (XmlNode dilemma in user.ChildNodes)
                    if (dilemma.Attributes[2].Value == CaseFilename)
                    {
                        clsCase objCase = new clsCase();

                        objCase.email = user.Attributes[5].Value;
                        objCase.UID = user.Attributes[9].Value;
                        objCase.title = dilemma.Attributes[0].Value;
                        objCase.explanation = dilemma.Attributes[1].Value;
                        objCase.decisionModel = dilemma.Attributes[6].Value;
                        objCase.imageFileName = dilemma.Attributes[9].Value;
                        objCase.KBfilename = dilemma.Attributes[2].Value;
                        return objCase;
                    }
            }
            return null;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool deleteTemporaryCases()
        {
            clsCase objCase = new clsCase();
            XmlDocument doc = new XmlDocument();

            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;

            foreach (XmlNode user in root)
                if (user.Attributes[5].Value == HttpContext.Current.Session["CurrentUserEmail"].ToString())
                    foreach (XmlNode dilemma in user.ChildNodes)
                        if (dilemma.Attributes[10].Value == "true")
                        {
                            DeleteCaseByFilename(dilemma.Attributes[2].Value);

                            return true;
                        }

            return false;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public clsCase[] GetAllDecisionModels(string userEmail)
        {
            LinkedList<clsCase> lstCase = new LinkedList<clsCase>();
            XmlDocument doc = new XmlDocument();

            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode user in root)
                if (user.Attributes[5].Value == userEmail)
                {
                    foreach (XmlNode dilemma in user.ChildNodes)
                    {
                        if (dilemma.Attributes[10].Value == "false")
                        {
                            clsCase objCase = new clsCase();

                            objCase.title = dilemma.Attributes[0].Value;
                            objCase.explanation = dilemma.Attributes[1].Value;
                            objCase.decisionModel = dilemma.Attributes[6].Value;
                            objCase.imageFileName = dilemma.Attributes[9].Value;
                            objCase.KBfilename = dilemma.Attributes[2].Value;
                            lstCase.AddFirst(objCase);
                        }
                    }
                    break;
                }

            return lstCase.ToArray();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public bool createTemporaryAccessToViewDecisionModel(string OpenDecisionModel)
        {

            deleteTemporaryCases();

            clsCase objCase = getByCaseFilename(OpenDecisionModel);

            string email = HttpContext.Current.Session["CurrentUserEmail"].ToString();
            string fileLocation = OpenDecisionModel;

            string sourceFile = HttpContext.Current.Server.MapPath(@"~\XML_DB\Profiles\" + objCase.UID + @"\" + fileLocation);
            string destFile = HttpContext.Current.Server.MapPath(@"~\XML_DB\Profiles\" + HttpContext.Current.Session["UID"] + @"\" + fileLocation);
            string targetPath = @"~\XML_DB\Profiles\" + HttpContext.Current.Session["UID"] + @"\";

            if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(targetPath)))
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath(targetPath));

            System.IO.File.Copy(sourceFile, destFile, true);
            HttpContext.Current.Session["KB_Location"] = HttpContext.Current.Server.MapPath(@"~\XML_DB\Profiles\" + HttpContext.Current.Session["UID"] + @"\" + OpenDecisionModel);

            AssignKB2UserAccount(objCase.title, objCase.explanation, objCase.KBfilename, "", "", "", objCase.imageFileName, "true");

            return false;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public clsCase[] GetAllOtherDecisionModels(string userEmail)
        {
            LinkedList<clsCase> lstCase = new LinkedList<clsCase>();
            XmlDocument doc = new XmlDocument();

            doc.Load(Get_User_Accounts_File());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode user in root)
                if (user.Attributes[5].Value != userEmail)
                {
                    foreach (XmlNode dilemma in user.ChildNodes)
                        if (dilemma.Attributes[5].Value == "false" && dilemma.Attributes[10].Value == "false")
                        {
                            clsCase objCase = new clsCase();

                            objCase.title = dilemma.Attributes[0].Value;
                            objCase.explanation = dilemma.Attributes[1].Value;
                            objCase.decisionModel = dilemma.Attributes[6].Value;
                            objCase.imageFileName = dilemma.Attributes[9].Value;
                            objCase.KBfilename = dilemma.Attributes[2].Value;
                            lstCase.AddFirst(objCase);
                        }
                    break;
                }

            return lstCase.ToArray();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string AddValidUploadedFile(string filename)
        {
            clsCase objNewCase = new clsCase();
            string filePath = Get_Profile_Path() + filename;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode root = doc.FirstChild;
                foreach (XmlNode node in root)
                    if (node.Attributes[3].Value == "Domain")
                    {
                        objNewCase.title = node.Attributes[1].Value;
                        objNewCase.explanation = node.Attributes[4].Value;
                        objNewCase.imageFileName = "DM_Default.png";
                        objNewCase.KBfilename = filename;
                        objNewCase.decisionModel = node.Attributes[5].Value;

                        AssignKB2UserAccount(objNewCase.title, objNewCase.explanation, objNewCase.KBfilename, "", "", "", objNewCase.imageFileName, "false");
                    }
                return objNewCase.title;
            }
            catch
            {
                return "NULL";
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        static Random rd = new Random();
        public static string CreateString(int stringLength)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789_";
            char[] chars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            string randomString = new string(chars);

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();

            return (id + "_" + randomString + "_" + DateTime.Now.ToString("ddMMyyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US")));
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool isConnected(XmlNode node, string parent)
        {
            foreach (XmlNode child in node.ChildNodes)
                if ((child.Name == "link") && (child.Attributes[0].Value == parent))
                    return true;

            return false;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private int GetSupportedAlternatives(string ParentFeatureID) //Expensive process
        {
            int count = 0;
            XmlDocument doc = new XmlDocument();

            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[3].Value == "Alternative" && isConnected(node, ParentFeatureID))
                    count++;

            return count;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public clsFeatures[] GetAllMainFeatures()
        {
            LinkedList<clsFeatures> lstFeatures = new LinkedList<clsFeatures>();

            XmlDocument doc = new XmlDocument();

            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[3].Value == "Feature" && node.Attributes[7].Value == "NULL")
                {
                    clsFeatures objFeature = new clsFeatures();
                    objFeature.ID = node.Attributes[0].Value;
                    objFeature.Title = node.Attributes[1].Value.Replace("'", "&quot;").Replace("\"", "");
                    objFeature.DataType = node.Attributes[2].Value;
                    objFeature.Description = node.Attributes[4].Value.Replace("'", "&quot;").Replace("\"", ""); ;
                    objFeature.Req = node.Attributes[5].Value;
                    objFeature.Order = node.Attributes[6].Value;
                    objFeature.UpperLevel = node.Attributes[7].Value;
                    objFeature.Criterion = GetCriterionTextualValue(node.Attributes[8].Value);
                    objFeature.Keywords = node.Attributes[9].Value;
                    objFeature.SupportedAlternatives = GetSupportedAlternatives(objFeature.ID); //Expensive process

                    lstFeatures.AddFirst(objFeature);
                }

            return lstFeatures.ToArray();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public clsFeatures[] GetAllSubFeatures(clsFeatures MainFeature)
        {
            LinkedList<clsFeatures> lstFeatures = new LinkedList<clsFeatures>();

            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[3].Value == "Feature" && node.Attributes[7].Value == MainFeature.Title)
                {
                    clsFeatures objFeature = new clsFeatures();
                    objFeature.ID = node.Attributes[0].Value;
                    objFeature.Title = node.Attributes[1].Value.Replace("'", "&quot;").Replace("\"", ""); ;
                    objFeature.DataType = node.Attributes[2].Value;
                    objFeature.Description = node.Attributes[4].Value.Replace("'", "&quot;").Replace("\"", ""); ;
                    objFeature.Req = node.Attributes[5].Value;
                    objFeature.Order = node.Attributes[6].Value;
                    objFeature.UpperLevel = node.Attributes[7].Value;
                    objFeature.Criterion = GetCriterionTextualValue(node.Attributes[8].Value);
                    objFeature.Keywords = node.Attributes[9].Value;
                    objFeature.SupportedAlternatives = GetSupportedAlternatives(objFeature.ID); //Expensive process

                    lstFeatures.AddFirst(objFeature);
                }

            return lstFeatures.ToArray();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public clsFeatures[] GetFeaturesByGroup(string FeatureGroup)
        {
            LinkedList<clsFeatures> lstFeatures = new LinkedList<clsFeatures>();
            XmlDocument doc = new XmlDocument();

            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[3].Value == "Feature" && node.Attributes[7].Value == "NULL" && node.Attributes[6].Value == FeatureGroup)
                {
                    clsFeatures objFeature = new clsFeatures();
                    objFeature.ID = node.Attributes[0].Value;
                    objFeature.Title = node.Attributes[1].Value.Replace("'", "&quot;").Replace("\"", "");
                    objFeature.DataType = node.Attributes[2].Value;
                    objFeature.Description = node.Attributes[4].Value.Replace("'", "&quot;").Replace("\"", ""); ;
                    objFeature.Req = node.Attributes[5].Value;
                    objFeature.Order = node.Attributes[6].Value;
                    objFeature.UpperLevel = node.Attributes[7].Value;
                    objFeature.Criterion = GetCriterionTextualValue(node.Attributes[8].Value);
                    objFeature.Keywords = node.Attributes[9].Value;
                    objFeature.SupportedAlternatives = GetSupportedAlternatives(objFeature.ID); //Expensive process

                    lstFeatures.AddFirst(objFeature);
                }

            return lstFeatures.ToArray();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string[] GetAllGroups()
        {
            LinkedList<string> lstFeatureGroups = new LinkedList<string>();
            XmlDocument doc = new XmlDocument();

            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[3].Value == "Feature" && node.Attributes[7].Value == "NULL" && !lstFeatureGroups.Contains(node.Attributes[6].Value))
                    lstFeatureGroups.AddFirst(node.Attributes[6].Value);

            return lstFeatureGroups.ToArray();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool UpdateFeatureRequirements_MoSCoW(string ID, string Req)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            try
            {
                foreach (XmlNode node in root)
                {
                    if (node.Attributes[0].Value == ID)
                    {
                        node.Attributes[5].Value = Req;
                        break;
                    }
                }
                doc.Save(Get_Local_KB());
                return true;
            }
            catch { }

            return false;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string GetCriterionValue(string Val)
        {
            string value = "";
            switch (Val)
            {
                case "High":
                    return "1.0";
                case "Average":
                    return "0.5";
                case "Low":
                    return "0.01";
                case "None":
                    return "None";
            }

            return value;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool UpdateFeatureRequirements_Criterion(string ID, string Val)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            try
            {
                foreach (XmlNode node in root)
                {
                    if (node.Attributes[0].Value == ID)
                    {
                        node.Attributes[8].Value = Val;//GetCriterionValue(Val);
                        break;
                    }
                }
                doc.Save(Get_Local_KB());
                return true;
            }
            catch { }

            return false;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void sortRequirements(List<XmlNode> lstRequirements)
        {
            if (lstRequirements.Count() > 0)
                for (int i = 0; i < lstRequirements.Count(); i++)
                    for (int j = 1; j < lstRequirements.Count(); j++)
                        if (getPriority(lstRequirements[j].Attributes[5].Value) > getPriority(lstRequirements[j - 1].Attributes[5].Value))
                        {
                            XmlNode temp = lstRequirements[j];
                            lstRequirements[j] = lstRequirements[j - 1];
                            lstRequirements[j - 1] = temp;
                        }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public List<XmlNode> getNumericFeatures()
        {
            List<XmlNode> lstNumFeatures = new List<XmlNode>();

            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;

            foreach (XmlNode node in root)
                if (node.Attributes[3].Value == "Feature" && node.Attributes[2].Value == "Numeric")
                    lstNumFeatures.Add(node);

            return lstNumFeatures;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string[] getSolutionDescription(string SolutionTitle)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            string[] strDesc = null;
            XmlNode node = getNodeByTitle(SolutionTitle, doc, "Alternative");

            if (node.Attributes[4].Value == "Hybrid Solution")
            {
                string[] subSolutions = getHybridSolutionTitles(SolutionTitle);
                List<string> lstDesc = new List<string>();

                for (int i = 0; i < subSolutions.Length; i++)
                {
                    node = getNodeByTitle(subSolutions[i], doc, "Alternative");
                    lstDesc.Add(node.Attributes[4].Value);
                }

                strDesc = lstDesc.ToArray();
            }
            else
            {
                strDesc = new string[1];
                strDesc[0] = node.Attributes[4].Value;
            }
            return strDesc;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public List<XmlNode> getSubSolutions(XmlNode[] FeasibleSolutions)
        {
            List<XmlNode> lstSubSolutions = new List<XmlNode>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());

            for (int i = 0; i < FeasibleSolutions.Length; i++)
                if (FeasibleSolutions[i].Attributes[4].Value == "Hybrid Solution")
                {
                    string[] subSolutions = getHybridSolutionTitles(FeasibleSolutions[i].Attributes[1].Value);
                    for (int j = 0; j < subSolutions.Length; j++)
                    {
                        XmlNode node = getNodeByTitle(subSolutions[j], doc, "Alternative");

                        if (!lstSubSolutions.Contains(node))
                            lstSubSolutions.Add(node);
                    }
                }

            return lstSubSolutions;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string[] getHybridSolutionTitles(string SolutionTitle)
        {
            string[] strSolutionTitles;
            if (SolutionTitle.IndexOf("HS:{") == 0)
                strSolutionTitles = SolutionTitle.Substring(4, SolutionTitle.Length - 5).Split(',');
            else
            {
                strSolutionTitles = new string[1];
                strSolutionTitles[0] = SolutionTitle;
            }

            return strSolutionTitles;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void sortStringArray(string[] str)
        {
            for (int i = 0; i < str.Length; i++)
                for (int j = 1; j < str.Length; j++)
                    if (String.Compare(str[j], str[j - 1]) > 0)
                    {
                        string temp = str[j];
                        str[j] = str[j - 1];
                        str[j - 1] = temp;
                    }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool isEqualTitles(string[] title1, string[] title2)
        {
            if (title1.Length != title2.Length)
                return false;

            sortStringArray(title1);
            sortStringArray(title2);

            for (int i = 0; i < title1.Length; i++)
                if (title1[i] != title2[i])
                    return false;

            return true;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool isUniqueSolution(string SolutionTitle, List<XmlNode> lstFeasibleSolutions)
        {
            string[] strSolutionTitle = getHybridSolutionTitles(SolutionTitle);
            for (int i = 0; i < lstFeasibleSolutions.Count(); i++)
                if (isEqualTitles(strSolutionTitle, getHybridSolutionTitles(lstFeasibleSolutions[i].Attributes[1].Value)))
                    return false;
            return true;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private List<XmlNode> get_HardConstraints(List<XmlNode> Requirements)
        {
            for(int i=0;i<Requirements.Count;i++)
                if(!(Requirements[i].Attributes[5].Value=="M" || Requirements[i].Attributes[5].Value == "W"))
                    Requirements.RemoveAt(i);
            return Requirements;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool generateUniqueHybridSolution(List<XmlNode> lstFeasibleSolutions, List<XmlNode> lstAlternatives, List<XmlNode> lstRequirements_Original)
        {
            int maxCombinations = lstAlternatives.Count();

            bool feasibleUniqueSolution = false;

            int cnt_iter = 0;
            string SolutionTitle = "HS:{";
            List<XmlNode> Requirements = get_HardConstraints(lstRequirements_Original.GetRange(0, lstRequirements_Original.Count));


            while (!feasibleUniqueSolution)
            {
                for (int alt = 0; alt < lstAlternatives.Count(); alt++)
                    if (SolutionTitle.IndexOf(lstAlternatives[alt].Attributes[1].Value) < 0)
                    {
                        for (int req = 0; req < Requirements.Count(); req++)
                        {
                            string PotentialTitle = SolutionTitle + "}";

                            if (SolutionTitle.IndexOf(lstAlternatives[alt].Attributes[1].Value) < 0)
                                PotentialTitle = SolutionTitle.Length > 4 ?
                                        (SolutionTitle + "," + lstAlternatives[alt].Attributes[1].Value + "}") :
                                        (SolutionTitle + lstAlternatives[alt].Attributes[1].Value + "}");

                            if (
                                    isConnected(lstAlternatives[alt], Requirements[req].Attributes[0].Value) &&
                                    isUniqueSolution(PotentialTitle, lstFeasibleSolutions)
                                )
                            {
                                SolutionTitle = PotentialTitle.Substring(0, PotentialTitle.Length - 1);
                                Requirements.RemoveAt(req);
                                req = 0;
                            }
                        }

                        if (Requirements.Count() == 0)
                        {
                            feasibleUniqueSolution = true;
                            break;
                        }
                    }

                if (SolutionTitle.Split(',').Length > maxCombinations)
                    return false;

                if (++cnt_iter > lstAlternatives.Count() && lstAlternatives.Count() > 0)
                {
                    cnt_iter = 0;
                    lstAlternatives.RemoveAt(0);
                    SolutionTitle = "HS:{";
                    Requirements = get_HardConstraints(lstRequirements_Original.GetRange(0, lstRequirements_Original.Count));
                }

                if (lstAlternatives.Count() == 0)
                    return false;

            }

            if (Requirements.Count() == 0)
            {
                SolutionTitle = SolutionTitle + "}";
                XmlNode HybridSolution = addNewHybridSolution(SolutionTitle);
                lstFeasibleSolutions.Add(HybridSolution);
                return true;
            }
            return false;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private XmlNode addNewHybridSolution(string SolutionTitle)
        {
            XmlDocument doc = new XmlDocument();

            List<XmlNode> lstSubSolutions = new List<XmlNode>();

            XmlNode hybridSolutionNode;
            string[] strSolutionTitle = getHybridSolutionTitles(SolutionTitle);

            XmlNode HybridSolution = Add_New_Aspect(SolutionTitle, "Description", "Hybrid Solution", "Alternative", "NULL", "NULL", "NULL");

            for (int i = 0; i < strSolutionTitle.Length; i++)
            {
                doc.Load(Get_Local_KB());

                hybridSolutionNode = getNodeByTitle(strSolutionTitle[i], doc, "Alternative");
                lstSubSolutions.Add(hybridSolutionNode);
                HybridSolution = getNodeByTitle(SolutionTitle, doc, "Alternative");

                for (int features = 0; features < hybridSolutionNode.ChildNodes.Count; features++)
                {
                    if (hybridSolutionNode.ChildNodes[features].Name == "link" &&
                        !isConnected(HybridSolution, hybridSolutionNode.ChildNodes[features].Attributes[0].Value)
                      )
                        CreateLink(HybridSolution.Attributes[0].Value, hybridSolutionNode.ChildNodes[features].Attributes[0].Value);
                }
            }

            UpdateNumbericFeatures(HybridSolution, lstSubSolutions);

            doc.Load(Get_Local_KB());
            return getNodeByTitle(SolutionTitle, doc, "Alternative");
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void UpdateNumbericFeatures(XmlNode HybridSolution, List<XmlNode> lstSubSolutions)
        {
            List<XmlNode> lstNumericFeatures = getNumericFeatures();

            for (int i = 0; i < lstNumericFeatures.Count(); i++)
            {
                double minVal = double.MaxValue;
                double val = 0;
                for (int j = 0; j < lstSubSolutions.Count(); j++)
                {
                    val = double.Parse(FeatureAlternativeValue(lstSubSolutions[j], lstNumericFeatures[i]));
                    if (val < minVal)
                        minVal = val;
                }
                UpdateLinkValue(HybridSolution.Attributes[0].Value, lstNumericFeatures[i].Attributes[0].Value, minVal.ToString());
            }

        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void RemoveHybridSolutions()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[3].Value == "Alternative" && node.Attributes[4].Value == "Hybrid Solution")
                    DeleteNode(node.Attributes[0].Value);
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void MakeDecision(ref XmlNode Domain, ref XmlNode[] Requirements, ref XmlNode[] FeasibleSolutions, ref double[] SolutionScores, ref XmlNode[] InfeasibleSolutions, ref XmlNode[] Characteristics, ref XmlNode[] SubCharacteristics)
        {
            List<XmlNode> lstFeatures = new List<XmlNode>();
            List<XmlNode> lstAlternatives = new List<XmlNode>(); ;
            List<XmlNode> lstRequirements = new List<XmlNode>();
            List<XmlNode> CharacteristicsT = new List<XmlNode>();
            List<XmlNode> SubCharacteristicsT = new List<XmlNode>();

            List<XmlNode> lstFeasibleSolutions;
            Dictionary<string, double> lstWeights;
            List<double> lstScores = new List<double>();

            RemoveHybridSolutions();

            GetAllNodeTypes(ref Domain, ref lstFeatures, ref lstAlternatives, ref lstRequirements, ref CharacteristicsT, ref SubCharacteristicsT);

            sortRequirements(lstRequirements);

            lstWeights = calculateGlobalWeights_MoSCoW(lstRequirements); // Gain features' weights

            lstFeasibleSolutions = getFeasibleSolutions(lstRequirements, lstAlternatives); // Get feasible solutions

            if (lstFeasibleSolutions.Count() == 0)
                while (lstFeasibleSolutions.Count() < FeasibleSolutionsThreshold &&
                    generateUniqueHybridSolution(lstFeasibleSolutions, lstAlternatives, lstRequirements)) ;

            lstScores = scoreCalculation(lstWeights, lstRequirements, lstFeasibleSolutions);
            SortScores(lstFeasibleSolutions, lstScores, "DESC");

            Requirements = lstRequirements.ToArray();
            FeasibleSolutions = lstFeasibleSolutions.ToArray();
            SolutionScores = lstScores.ToArray();
            InfeasibleSolutions = GetInfeasibleSolutions(FeasibleSolutions, lstAlternatives.ToArray());
            Characteristics = CharacteristicsT.ToArray();
            SubCharacteristics = SubCharacteristicsT.ToArray();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private XmlNode[] GetInfeasibleSolutions(XmlNode[] lstFeasibleSolutions, XmlNode[] lstAlternatives)
        {
            List<XmlNode> InfeasibleSolutions = new List<XmlNode>();

            for (int i = 0; i < lstAlternatives.Length; i++)
                if (!lstFeasibleSolutions.Contains(lstAlternatives[i]))
                    InfeasibleSolutions.Add(lstAlternatives[i]);

            return InfeasibleSolutions.ToArray();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private List<XmlNode> getFeasibleSolutions(List<XmlNode> ReqFeature, List<XmlNode> Alternative)
        {
            List<XmlNode> FeasibleSolutions = new List<XmlNode>();
            List<double> AlternativeRank = new List<double>();

            bool feasible = true;
            for (int i = 0; i < Alternative.Count; i++)
            {
                feasible = true;
                AlternativeRank.Add(0);
                for (int j = 0; j < ReqFeature.Count; j++)
                    if ((ReqFeature[j].Attributes[5].Value == "M" || ReqFeature[j].Attributes[5].Value == "W") && !isLinked(ReqFeature[j], Alternative[i]))
                    {
                        feasible = false;
                        break;
                    }
                    else
                        AlternativeRank[i]++;

                if (feasible)
                    FeasibleSolutions.Add(Alternative[i]);

                if (FeasibleSolutions.Count() >= FeasibleSolutionsThreshold)
                    return FeasibleSolutions;
            }

            SortScores(Alternative, AlternativeRank, "DESC");

            return FeasibleSolutions;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void SortScores(List<XmlNode> lstFeasibleSolutions, List<double> lstScores, string type)
        {
            if (type == "DESC")
            {
                for (int i = 0; i < lstScores.Count; i++)
                    for (int j = 1; j < lstScores.Count; j++)
                        if (lstScores[j] > lstScores[j - 1])
                        {
                            double score_temp = lstScores[j];
                            XmlNode node_temp = lstFeasibleSolutions[j];

                            lstScores[j] = lstScores[j - 1];
                            lstScores[j - 1] = score_temp;

                            lstFeasibleSolutions[j] = lstFeasibleSolutions[j - 1];
                            lstFeasibleSolutions[j - 1] = node_temp;
                        }
            }
            else if (type == "ASC")
            {
                for (int i = 0; i < lstScores.Count; i++)
                    for (int j = 1; j < lstScores.Count; j++)
                        if (lstScores[j] < lstScores[j - 1])
                        {
                            double score_temp = lstScores[j];
                            XmlNode node_temp = lstFeasibleSolutions[j];

                            lstScores[j] = lstScores[j - 1];
                            lstScores[j - 1] = score_temp;

                            lstFeasibleSolutions[j] = lstFeasibleSolutions[j - 1];
                            lstFeasibleSolutions[j - 1] = node_temp;
                        }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string GetCriterionTextualValue(string val)
        {
            string textualVal = val;
            if (val != "None")
            {
                double dbval = double.Parse(val);
                if (dbval < 0.3)
                    textualVal = "Low";
                else if (dbval >= 0.3 && dbval < 0.7)
                    textualVal = "Average";
                else
                    textualVal = "High";
            }

            return textualVal;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private Dictionary<string, double> calculateGlobalWeights_MoSCoW(List<XmlNode> lstRequirements)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());

            List<XmlNode> lstSubCharacteristics = new List<XmlNode>();
            List<XmlNode> lstCharacteristics = new List<XmlNode>();
            List<XmlNode> lstDomain = new List<XmlNode>();

            Dictionary<string, double> lstWeights = new Dictionary<string, double>();

            double SumWeights1 = 0;
            double SumWeights2 = 0;

            double Agg_weight_CouldHaveFeatures = 0;
            double Agg_weight_ShouldHaveFeatures = 0;

            for (int i = 0; i < lstRequirements.Count; i++) // MoSCoW Requirements
                if (lstRequirements[i].Attributes[5].Value == "C")
                    Agg_weight_CouldHaveFeatures += getScoreMoSCoW(lstRequirements[i].Attributes[5].Value);
                else if (lstRequirements[i].Attributes[5].Value == "S")
                    Agg_weight_ShouldHaveFeatures += getScoreMoSCoW(lstRequirements[i].Attributes[5].Value);

            for (int i = 0; i < lstRequirements.Count; i++) // MoSCoW Requirements
            {
                double score = 0;
                if (lstRequirements[i].Attributes[5].Value == "C")
                    score = (getScoreMoSCoW(lstRequirements[i].Attributes[5].Value) / Agg_weight_CouldHaveFeatures) * (getScoreMoSCoW("S"));
                else if (lstRequirements[i].Attributes[5].Value == "S")
                    score = (getScoreMoSCoW(lstRequirements[i].Attributes[5].Value) / Agg_weight_ShouldHaveFeatures) * (getScoreMoSCoW("M"));
                else
                    score = getScoreMoSCoW(lstRequirements[i].Attributes[5].Value);
                lstWeights.Add(lstRequirements[i].Attributes[0].Value, score);
                lstWeights[lstRequirements[i].Attributes[0].Value] = score;
                SumWeights1 += score;
            }

            for (int i = 0; i < lstRequirements.Count; i++) // Features Normalization
            {
                lstWeights[lstRequirements[i].Attributes[0].Value] = lstWeights[lstRequirements[i].Attributes[0].Value] / SumWeights1;
                for (int j = 0; j < lstRequirements[i].ChildNodes.Count; j++)
                    if (lstRequirements[i].ChildNodes[j].Name == "link" && lstRequirements[i].ChildNodes[j].Attributes[2].Value == "T")
                    {
                        XmlNode node = getNodeById(lstRequirements[i].ChildNodes[j].Attributes[0].Value, doc);
                        if (!lstSubCharacteristics.Contains(node))
                        {
                            lstWeights.Add(node.Attributes[0].Value, 0);
                            lstSubCharacteristics.Add(node);
                        }
                        {
                            lstWeights[node.Attributes[0].Value] += lstWeights[lstRequirements[i].Attributes[0].Value];
                            SumWeights2 += lstWeights[lstRequirements[i].Attributes[0].Value];
                        }
                    }
            }

            SumWeights1 = 0;

            for (int i = 0; i < lstSubCharacteristics.Count; i++) // Subcharacteristics Normalization
            {
                lstWeights[lstSubCharacteristics[i].Attributes[0].Value] = lstWeights[lstSubCharacteristics[i].Attributes[0].Value] / SumWeights2;
                for (int j = 0; j < lstSubCharacteristics[i].ChildNodes.Count; j++)
                    if (lstSubCharacteristics[i].ChildNodes[j].Name == "link" && lstSubCharacteristics[i].ChildNodes[j].Attributes[2].Value == "T")
                    {
                        XmlNode node = getNodeById(lstSubCharacteristics[i].ChildNodes[j].Attributes[0].Value, doc);
                        if (!lstCharacteristics.Contains(node))
                        {
                            lstWeights.Add(node.Attributes[0].Value, 0);
                            lstCharacteristics.Add(node);
                        }
                        lstWeights[node.Attributes[0].Value] += lstWeights[lstSubCharacteristics[i].Attributes[0].Value];
                        SumWeights1 += lstWeights[lstSubCharacteristics[i].Attributes[0].Value];
                    }
            }

            for (int i = 0; i < lstCharacteristics.Count; i++) // Characteristics Normalization
            {
                lstWeights[lstCharacteristics[i].Attributes[0].Value] = lstWeights[lstCharacteristics[i].Attributes[0].Value] / SumWeights1;
                for (int j = 0; j < lstCharacteristics[i].ChildNodes.Count; j++)
                    if (lstCharacteristics[i].ChildNodes[j].Name == "link" && lstCharacteristics[i].ChildNodes[j].Attributes[2].Value == "T")
                    {

                        XmlNode node = getNodeById(lstCharacteristics[i].ChildNodes[j].Attributes[0].Value, doc);
                        if (!lstDomain.Contains(node))
                        {
                            lstWeights.Add(node.Attributes[0].Value, 0);
                            lstDomain.Add(node);
                        }
                        lstWeights[node.Attributes[0].Value] += lstWeights[lstCharacteristics[i].Attributes[0].Value];
                    }
            }

            UpdateKBweights(lstWeights, doc);

            return lstWeights;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private double getFeatureImpactFactor(XmlNode Feature, XmlDocument doc)
        {
            if (Feature.Attributes[5].Value == "M" || Feature.Attributes[5].Value == "W")
                return 1;
            double F_weight = 0, S_weight = 0, C_weight = 0, Branch_Weight = 1, TotalWeights = 0;
            for (int f = 0; f < Feature.ChildNodes.Count; f++)
                if (Feature.ChildNodes[f].Name == "link" && Feature.ChildNodes[f].Attributes[2].Value == "T")
                {
                    F_weight = double.Parse(Feature.ChildNodes[f].Attributes[1].Value);
                    XmlNode SubCharacteristic = getNodeById(Feature.ChildNodes[f].Attributes[0].Value, doc);

                    for (int s = 0; s < SubCharacteristic.ChildNodes.Count; s++)
                        if (SubCharacteristic.ChildNodes[s].Name == "link" && SubCharacteristic.ChildNodes[s].Attributes[2].Value == "T")
                        {
                            S_weight = double.Parse(SubCharacteristic.ChildNodes[s].Attributes[1].Value);
                            XmlNode Characteristic = getNodeById(SubCharacteristic.ChildNodes[s].Attributes[0].Value, doc);

                            for (int h = 0; h < Characteristic.ChildNodes.Count; h++)
                                if (Characteristic.ChildNodes[h].Name == "link" && Characteristic.ChildNodes[h].Attributes[2].Value == "T")
                                {
                                    C_weight = double.Parse(Characteristic.ChildNodes[h].Attributes[1].Value);

                                    Branch_Weight = S_weight * C_weight;
                                    TotalWeights += Branch_Weight;
                                }
                        }
                }
            return TotalWeights;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private List<double> scoreCalculation(Dictionary<string, double> lstWeights, List<XmlNode> lstRequirements, List<XmlNode> lstFeasibleSolutions)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());

            double TotalPossibleScore = 0;
            double[] weights;
            List<double> lstScores = new List<double>();

            double weight_CouldHaveFeatures = 0;
            double weight_ShouldHaveFeatures = 0;

            weights = new double[lstRequirements.Count];

            for (int i = 0; i < lstRequirements.Count; i++)
            {
                weights[i] = setInRange(getScoreMoSCoW(lstRequirements[i].Attributes[5].Value) + getFeatureImpactFactor(lstRequirements[i], doc), lstRequirements[i].Attributes[5].Value);

                if (lstRequirements[i].Attributes[5].Value == "C")
                    weight_CouldHaveFeatures += weights[i];
                else if (lstRequirements[i].Attributes[5].Value == "S")
                    weight_ShouldHaveFeatures += weights[i];

            }

            double Sum_C = 0, Sum_S = 0;

            for (int i = 0; i < lstRequirements.Count; i++)
            {
                if (lstRequirements[i].Attributes[5].Value == "C" || lstRequirements[i].Attributes[5].Value == "S")
                {
                    if (lstRequirements[i].Attributes[5].Value == "C")
                    {
                        weights[i] = setInRange((weights[i] / weight_CouldHaveFeatures), lstRequirements[i].Attributes[5].Value);
                        Sum_C += weights[i];
                    }
                    else if (lstRequirements[i].Attributes[5].Value == "S")
                    {
                        weights[i] = setInRange((weights[i] / weight_ShouldHaveFeatures), lstRequirements[i].Attributes[5].Value);
                        Sum_S += weights[i];
                    }
                    TotalPossibleScore += weights[i];
                }

                lstWeights[lstRequirements[i].Attributes[0].Value] = weights[i];
            }

            UpdateKBweights(lstWeights, doc);

            for (int i = 0; i < lstFeasibleSolutions.Count; i++)
            {
                double Score = getTechnologyScore(lstFeasibleSolutions[i], lstRequirements, weights, doc);
                lstScores.Add(TotalPossibleScore > 0 ? (double)(Score / TotalPossibleScore) : 0);
            }

            return lstScores;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private double setInRange(double weight, string priority)
        {
            switch (priority)
            {
                case "M":
                    weight = getScoreMoSCoW("M");
                    break;
                case "S":
                    weight = ((weight - getScoreMoSCoW("S")) * (getScoreMoSCoW("M") - getScoreMoSCoW("S"))) + getScoreMoSCoW("S");
                    break;
                case "C":
                    weight = ((weight - getScoreMoSCoW("C")) * (getScoreMoSCoW("S") - getScoreMoSCoW("C"))) + getScoreMoSCoW("C");
                    break;
                case "W":
                    weight = getScoreMoSCoW("W");
                    break;
            }
            return weight;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private double getTechnologyScore(XmlNode Alternative, List<XmlNode> ReqFeature, double[] weights, XmlDocument doc)
        {
            double score = 0;
            for (int i = 0; i < ReqFeature.Count; i++)
                if ((ReqFeature[i].Attributes[5].Value == "C" || ReqFeature[i].Attributes[5].Value == "S") && isLinked(ReqFeature[i], Alternative))
                    score += weights[i];
            return score;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void UpdateKBweights(Dictionary<string, double> lstWeights, XmlDocument doc)
        {
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (lstWeights.ContainsKey(node.Attributes[0].Value))
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                        if (node.ChildNodes[i].Name == "link")
                        {
                            node.ChildNodes[i].Attributes[1].Value = lstWeights[node.Attributes[0].Value].ToString();
                        }
                }
            try
            {
                doc.Save(Get_Local_KB());
            }
            catch { }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string FeatureAlternativeValue(XmlNode RequiredAlternative, XmlNode RequiredFeature)
        {
            for (int i = 0; i < RequiredAlternative.ChildNodes.Count; i++)
                if (RequiredAlternative.ChildNodes[i].Name == "link" && RequiredAlternative.ChildNodes[i].Attributes[0].Value == RequiredFeature.Attributes[0].Value)
                    return RequiredAlternative.ChildNodes[i].Attributes[1].Value;

            return "0";
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool isLinked(XmlNode ReqFeature, XmlNode Alternative)
        {
            bool feasible = true;
            if (ReqFeature.Attributes[5].Value == "M" || ReqFeature.Attributes[5].Value == "S" || ReqFeature.Attributes[5].Value == "C")
            {
                if ((ReqFeature.Attributes[2].Value == "Boolean") || (ReqFeature.Attributes[2].Value == "Collection"))
                {
                    if (!isConnected(Alternative, ReqFeature.Attributes[0].Value))
                        feasible = false;
                }
                else if (ReqFeature.Attributes[2].Value == "Monetary")
                {
                    if (isConnected(Alternative, ReqFeature.Attributes[0].Value) && ReqFeature.Attributes[8].Value != "None")
                    {
                        string value = FeatureAlternativeValue(Alternative, ReqFeature);

                        if ((double.Parse(value) > double.Parse(ReqFeature.Attributes[8].Value)))
                            feasible = false;
                    }
                    else
                        feasible = false;
                }
                else if (ReqFeature.Attributes[2].Value == "Numeric")
                {
                    if (isConnected(Alternative, ReqFeature.Attributes[0].Value) && ReqFeature.Attributes[8].Value != "None")
                    {
                        string value = FeatureAlternativeValue(Alternative, ReqFeature);

                        if ((double.Parse(value) < double.Parse(ReqFeature.Attributes[8].Value)))
                            feasible = false;
                    }
                    else
                        feasible = false;
                }
                else if (ReqFeature.Attributes[2].Value == "Description")
                {
                    if (isConnected(Alternative, ReqFeature.Attributes[0].Value))
                    {
                        string value = FeatureAlternativeValue(Alternative, ReqFeature);

                        if (value != ReqFeature.Attributes[8].Value)
                            feasible = false;
                    }
                    else
                        feasible = false;
                }
            }
            else if (ReqFeature.Attributes[5].Value == "W")
            {
                if ((ReqFeature.Attributes[2].Value == "Boolean") || (ReqFeature.Attributes[2].Value == "Collection"))
                {
                    if (isConnected(Alternative, ReqFeature.Attributes[0].Value))
                        feasible = false;
                }
                else if (ReqFeature.Attributes[2].Value == "Monetary")
                {
                    if (isConnected(Alternative, ReqFeature.Attributes[0].Value) && ReqFeature.Attributes[8].Value != "None")
                    {
                        string value = FeatureAlternativeValue(Alternative, ReqFeature);

                        if ((double.Parse(value) < double.Parse(ReqFeature.Attributes[8].Value)))
                            feasible = false;
                    }
                    else
                        feasible = false;
                }
                else if (ReqFeature.Attributes[2].Value == "Numeric")
                {
                    if (isConnected(Alternative, ReqFeature.Attributes[0].Value) && ReqFeature.Attributes[8].Value != "None")
                    {
                        string value = FeatureAlternativeValue(Alternative, ReqFeature);

                        if ((double.Parse(value) > double.Parse(ReqFeature.Attributes[8].Value)))
                            feasible = false;
                    }
                    else
                        feasible = false;
                }
                else if (ReqFeature.Attributes[2].Value == "Description")
                {
                    if (isConnected(Alternative, ReqFeature.Attributes[0].Value))
                    {
                        string value = FeatureAlternativeValue(Alternative, ReqFeature);

                        if (value == ReqFeature.Attributes[8].Value)
                            feasible = false;
                    }
                    else
                        feasible = false;
                }
            }

            return feasible;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private XmlNode getNodeById(string id, XmlDocument doc)
        {
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[0].Value == id)
                    return node;
            return null;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private double getScoreMoSCoW(string Type) // M > S > C > W
        {
            double impactFactor = 0;
            switch (Type)
            {
                case "M":
                    impactFactor = 1.0;
                    break;
                case "S":
                    impactFactor = 0.01;
                    break;
                case "C":
                    impactFactor = 0.001;
                    break;
                case "W":
                    impactFactor = 0.0001;
                    break;
            }
            return impactFactor;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private double getPriority(string Type)
        {
            double impactPriority = 0;
            switch (Type)
            {
                case "M":
                    impactPriority = 1.0;
                    break;
                case "S":
                    impactPriority = 0.5;
                    break;
                case "C":
                    impactPriority = 0.1;
                    break;
                case "W":
                    impactPriority = 1.0;
                    break;
            }
            return impactPriority;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void GetAllNodeTypes(ref XmlNode Domain, ref List<XmlNode> Features, ref List<XmlNode> Alternatives, ref List<XmlNode> Requirements, ref List<XmlNode> Characteristics, ref List<XmlNode> SubCharacteristics)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
            {
                if (node.Attributes[3].Value == "Alternative")
                    Alternatives.Add(node);
                else if (node.Attributes[3].Value == "Feature")
                {
                    Features.Add(node);

                    if (node.Attributes[5].Value != "N")
                        Requirements.Add(node);
                }
                else if (node.Attributes[3].Value == "Characteristic")
                    Characteristics.Add(node);
                else if (node.Attributes[3].Value == "Subcharacteristic")
                    SubCharacteristics.Add(node);
                else if (node.Attributes[3].Value == "Domain")
                    Domain = node;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public string GetSupportability(string AlternativeID)
        {
            string supportability = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());

            List<XmlNode> lstFeatures = new List<XmlNode>();
            List<XmlNode> lstAlternatives = new List<XmlNode>(); ;
            List<XmlNode> lstRequirements = new List<XmlNode>();
            List<XmlNode> Characteristics = new List<XmlNode>();
            List<XmlNode> SubCharacteristics = new List<XmlNode>();
            XmlNode Domain = null;

            XmlNode Alternative = getNodeById(AlternativeID, doc);

            GetAllNodeTypes(ref Domain, ref lstFeatures, ref lstAlternatives, ref lstRequirements, ref Characteristics, ref SubCharacteristics);

            // @"[{""ID"":1,""SP"":1},{""ID"":2,""SP"":0},{""ID"":3,""SP"":1}, {""ID"":4,""SP"":1},{""ID"":5,""SP"":1}];";
            for (int i = 0; i < lstRequirements.Count; i++)
                supportability += lstRequirements[i].Attributes[0].Value + "," + (isConnected(Alternative, lstRequirements[i].Attributes[0].Value) ? "true;" : "false;");

            return supportability;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public XmlNode SearchNodeArrayByID(XmlNode[] node, string ID)
        {
            for (int i = 0; i < node.Length; i++)
                if (node[i].Attributes[0].Value == ID)
                    return node[i];
            return null;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Dictionary<string, double> GetQualityImpacts(XmlNode[] Requirements, XmlNode[] Characteristics, XmlNode[] Subcharacteristics)
        {
            Dictionary<string, double> lstQualityImpacts = new Dictionary<string, double>();
            Dictionary<string, double> lstQualityImpactsRatio = new Dictionary<string, double>();

            int sum = 0;

            for (int req = 0; req < Requirements.Length; req++)
                for (int child = 0; child < Requirements[req].ChildNodes.Count; child++)
                    if (Requirements[req].ChildNodes[child].Name == "link" && Requirements[req].ChildNodes[child].Attributes[2].Value == "T")
                    {
                        XmlNode SubchNode = SearchNodeArrayByID(Subcharacteristics, Requirements[req].ChildNodes[child].Attributes[0].Value);
                        for (int SubCh = 0; SubCh < SubchNode.ChildNodes.Count; SubCh++)
                        {
                            XmlNode ChNode = SearchNodeArrayByID(Characteristics, SubchNode.ChildNodes[SubCh].Attributes[0].Value);

                            if (!lstQualityImpacts.ContainsKey(ChNode.Attributes[1].Value))
                                lstQualityImpacts.Add(ChNode.Attributes[1].Value, 1);
                            else
                                lstQualityImpacts[ChNode.Attributes[1].Value]++;

                            sum++;
                        }
                    }

            foreach (string key in lstQualityImpacts.Keys)
                lstQualityImpactsRatio.Add(key, lstQualityImpacts[key] / sum);

            return lstQualityImpactsRatio;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Dictionary<string, double> GetQualityImpacts_SubChar(XmlNode[] Requirements, XmlNode[] Characteristics, XmlNode[] Subcharacteristics)
        {
            Dictionary<string, double> lstQualityImpacts = new Dictionary<string, double>();
            Dictionary<string, double> lstQualityImpactsRatio = new Dictionary<string, double>();

            int sum = 0;

            for (int req = 0; req < Requirements.Length; req++)
                for (int child = 0; child < Requirements[req].ChildNodes.Count; child++)
                    if (Requirements[req].ChildNodes[child].Name == "link" && Requirements[req].ChildNodes[child].Attributes[2].Value == "T")
                    {
                        XmlNode SubchNode = SearchNodeArrayByID(Subcharacteristics, Requirements[req].ChildNodes[child].Attributes[0].Value);

                        if (!lstQualityImpacts.ContainsKey(SubchNode.Attributes[1].Value))
                            lstQualityImpacts.Add(SubchNode.Attributes[1].Value, 1);
                        else
                            lstQualityImpacts[SubchNode.Attributes[1].Value]++;

                        sum++;
                    }

            foreach (string key in lstQualityImpacts.Keys)
                lstQualityImpactsRatio.Add(key, lstQualityImpacts[key] / sum);

            return lstQualityImpactsRatio;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private XmlNode getNodeByTitle(string id, XmlDocument doc, string level)
        {
            XmlNode root = doc.FirstChild;
            foreach (XmlNode node in root)
                if (node.Attributes[3].Value == level && node.Attributes[1].Value == id)
                    return node;
            return null;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool UploadMappingFile(HttpContext context)
        {
            string validFileIdentifier = "", str_Newfilename = "";

            context.Response.ContentType = "text/plain";
            try
            {
                string dirFullPath = HttpContext.Current.Server.MapPath("~/XML_DB/Mappings_CSV/");
                string[] files;
                int numFiles;
                files = System.IO.Directory.GetFiles(dirFullPath);
                numFiles = files.Length;
                numFiles = numFiles + 1;

                foreach (string s in context.Request.Files)
                {
                    HttpPostedFile file = context.Request.Files[s];
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;

                    if (!string.IsNullOrEmpty(fileName) && fileExtension == "application/vnd.ms-excel")
                    {
                        fileExtension = Path.GetExtension(fileName);
                        str_Newfilename = DateTime.UtcNow.Ticks.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "_" + numFiles.ToString() + fileExtension;
                        string pathToSave_100 = HttpContext.Current.Server.MapPath("~/XML_DB/Mappings_CSV/") + str_Newfilename;

                        clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                        file.SaveAs(pathToSave_100);

                        StreamReader reader = new StreamReader(pathToSave_100);
                        string[] line = reader.ReadLine().Split(',');
                        reader.Close();


                        if (line[0] != "[Grouping]" && line[0] != "[SF]" && line[0] != "[FA]" && line[0] != validFileIdentifier && line[0] != "[MoSCoW]" && line[0] != validFileIdentifier && line[0] != "[DataType]")
                        {
                            File.Delete(pathToSave_100);
                            return false;
                        }
                        else if (line[0] == "[Grouping]")
                            validFileIdentifier = "[Grouping]";
                        else if (line[0] == "[DataType]")
                            validFileIdentifier = "[DataType]";
                        else if (line[0] == "[MoSCoW]")
                            validFileIdentifier = "[MoSCoW]";
                        else if (line[0] == "[SF]")
                            validFileIdentifier = "[SF]";
                        else if (line[0] == "[FA]")
                            validFileIdentifier = "[FA]";

                        fileProcessor(pathToSave_100, validFileIdentifier);
                    }
                    return false;
                }
            }
            catch { return false; }

            return true;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private string[] getColumnValues(string line)
        {
            LinkedList<string> cols = new LinkedList<string>();


            string strCol = "";

            bool SkipComma = false;

            for (int i = 0; i < line.Length; i++)
            {
                Char Ch = line[i];

                if (Ch != ',' && Ch != '"' && !SkipComma)
                {
                    strCol = strCol + Ch;

                    if ((i + 1) == line.Length)
                    {
                        cols.AddLast(strCol);
                        strCol = "";
                    }
                    continue;
                }
                else if (SkipComma && Ch != '"')
                {
                    strCol = strCol + Ch;
                    continue;
                }
                else if (SkipComma && Ch == '"')
                {

                    if (((i + 1) == line.Length) || ((i + 1) < line.Length && line[i + 1] == ','))
                    {
                        cols.AddLast(strCol);
                        strCol = "";
                        SkipComma = false;
                        continue;
                    }
                    else
                    {
                        strCol = strCol + Ch;
                        continue;
                    }
                }
                else if (Ch == '"')
                {
                    SkipComma = true;
                    continue;
                }
                else if (Ch == ',')
                {
                    cols.AddLast(strCol);
                    strCol = "";
                    continue;
                }
            }

            return cols.ToArray();
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void fileProcessor(string FilePath, string validFileIdentifier)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Get_Local_KB());
            XmlNode root = doc.FirstChild;
            root = doc.FirstChild;
            StreamReader reader = new StreamReader(FilePath);

            if (validFileIdentifier == "[Grouping]")
            {
                string[] line = getColumnValues(reader.ReadLine());

                while (!reader.EndOfStream)
                {
                    line = getColumnValues(reader.ReadLine());
                    XmlNode node = getNodeByTitle(line[0], doc, "Feature");
                    if (node == null)
                        node = Add_New_Aspect(line[0], "Boolean", "(----------New Feature--------)", "Feature", "NULL", "NULL", "NULL");
                    node.Attributes[6].Value = line[1];
                    node.Attributes[7].Value = line[2];

                    try
                    {
                        doc.Save(Get_Local_KB());
                    }
                    catch { }
                }
            }
            else if (validFileIdentifier == "[MoSCoW]")
            {
                string[] line = getColumnValues(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    line = getColumnValues(reader.ReadLine());
                    XmlNode node = getNodeByTitle(line[0], doc, "Feature");
                    if (node == null)
                        node = Add_New_Aspect(line[0], "Boolean", "(----------New Feature--------)", "Feature", "NULL", "NULL", "NULL");
                    node.Attributes[5].Value = line[1];
                }

                try
                {
                    doc.Save(Get_Local_KB());
                }
                catch { }

            }
            else if (validFileIdentifier == "[DataType]")
            {
                string[] line = getColumnValues(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    line = getColumnValues(reader.ReadLine());
                    XmlNode node = getNodeByTitle(line[0], doc, "Feature");
                    if (node == null)
                        node = Add_New_Aspect(line[0], "Boolean", "(----------New Feature--------)", "Feature", "NULL", "NULL", "NULL");
                    node.Attributes[2].Value = line[1];
                }

                try
                {
                    doc.Save(Get_Local_KB());
                }
                catch { }

            }

            else if (validFileIdentifier == "[SF]")
            {
                List<XmlNode> UpperLevel = new List<XmlNode>();

                string[] line = getColumnValues(reader.ReadLine());

                //string[] line = reader.ReadLine().Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    XmlNode node = getNodeByTitle(line[i], doc, "Subcharacteristic");
                    if (node == null)
                        node = getNodeByTitle(line[i], doc, "Characteristic");

                    if (node == null && line[i] != "[SF]" && line[i] != "[Description]")
                        node = Add_New_Aspect(line[i], "Numeric", "(----------New Subcharacteristic--------)", "Subcharacteristic", "NULL", "NULL", "NULL");
                    UpperLevel.Add(node);
                }

                while (!reader.EndOfStream)
                {
                    line = getColumnValues(reader.ReadLine());

                    XmlNode node = getNodeByTitle(line[0], doc, "Feature");
                    if (node == null)
                        node = Add_New_Aspect(line[0], "Boolean", line[line.Length - 1], "Feature", "NULL", "NULL", "NULL");
                    for (int i = 1; i < line.Length - 1; i++)
                        if (line[i] != "0" && !isConnected(node, UpperLevel[i].Attributes[0].Value))
                            CreateLink(node.Attributes[0].Value, UpperLevel[i].Attributes[0].Value);
                }

            }
            else if (validFileIdentifier == "[FA]")
            {
                List<XmlNode> UpperLevel = new List<XmlNode>();
                string[] line = getColumnValues(reader.ReadLine());
                for (int i = 0; i < line.Length; i++)
                {
                    XmlNode node = getNodeByTitle(line[i], doc, "Alternative");
                    if (node == null && line[i] != "[FA]")
                        node = Add_New_Aspect(line[i], "Description", "(----------New Alternative--------)", "Alternative", "NULL", "NULL", "NULL");
                    UpperLevel.Add(node);
                }

                while (!reader.EndOfStream)
                {
                    line = getColumnValues(reader.ReadLine());
                    XmlNode node = getNodeByTitle(line[0], doc, "Feature");
                    if (node == null && line[0] != "[URL]" && line[0] != "[Vendor]")
                        node = Add_New_Aspect(line[0], "Boolean", "(----------New Feature--------)", "Feature", "NULL", "NULL", "NULL");

                    for (int i = 1; i < line.Length; i++)
                        if (line[i] != "0")
                        {
                            if (line[0] == "[URL]")
                                UpdateAspect(UpperLevel[i].Attributes[0].Value, UpperLevel[i].Attributes[1].Value, UpperLevel[i].Attributes[2].Value, line[i], UpperLevel[i].Attributes[3].Value, UpperLevel[i].Attributes[6].Value, UpperLevel[i].Attributes[7].Value, UpperLevel[i].Attributes[9].Value);
                            else if (line[0] == "[Vendor]")
                                UpdateAspect(UpperLevel[i].Attributes[0].Value, UpperLevel[i].Attributes[1].Value, UpperLevel[i].Attributes[2].Value, UpperLevel[i].Attributes[4].Value, UpperLevel[i].Attributes[3].Value, line[i], UpperLevel[i].Attributes[7].Value, UpperLevel[i].Attributes[9].Value);
                            else
                            {
                                if (!isConnected(UpperLevel[i], node.Attributes[0].Value))
                                    CreateLink(UpperLevel[i].Attributes[0].Value, node.Attributes[0].Value);

                                if (line[i] != "1")
                                    UpdateLinkValue(UpperLevel[i].Attributes[0].Value, node.Attributes[0].Value, line[i]);
                            }
                        }
                }
            }
            reader.Close();
        }

    }
}