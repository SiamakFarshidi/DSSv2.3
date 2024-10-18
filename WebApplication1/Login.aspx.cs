using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WebApplication1.ClassLibrary;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["Main_KB_Location"] = "No File";
            HttpContext.Current.Session["KB_Location"] = "No File";
            HttpContext.Current.Session["CurrentDecisionModel"] = "";
            HttpContext.Current.Session["CurrentUserEmail"] = "Unknown";
            HttpContext.Current.Session["UID"] = "";
            HttpContext.Current.Session["CurrentUserName"] = "";

            clsKnowledgeBase obj_KB = new clsKnowledgeBase();

            if (Request.QueryString["login_social_network"] != null)
            {
                XmlNode user = null;

                if (Request.QueryString["Email"] != null)
                    user = obj_KB.getUserByEmail(Request.QueryString["Email"].ToString());

                if (user == null) // Register the user
                {
                    try
                    {
                        obj_KB.createNewProfile(Request.QueryString["Name"].ToString(), "", "", "", "", Request.QueryString["Email"].ToString(), "false", clsKnowledgeBase.CreateString(20));
                    }
                    catch
                    { }
                }

                clsScript_Generator objSG = new clsScript_Generator();
                
                 Session["CurrentUserEmail"] = Request.QueryString["Email"].ToString();
                HttpContext.Current.Session["CurrentUserName"] = objSG.LimitOnWordBoundary(Request.QueryString["Name"].ToString(),20);

                user = obj_KB.getUserByEmail(Session["CurrentUserEmail"].ToString());

                HttpContext.Current.Session["UID"] = user.Attributes[9].Value;
                Response.Redirect("Default.aspx");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool SendMail(string toAddress, string subject, string msg)
        {
            bool succeedSent = false;

            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("dss.utrechtuniversity@gmail.com");
                message.To.Add(toAddress);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = msg;

                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new System.Net.NetworkCredential("dss.utrechtuniversity@gmail.com", "Utrecht1234$#@!4321AFAS1");
                    smtp.Timeout = 20000;
                }
                smtp.Send(message);

                succeedSent = true;
            }
            catch (Exception e)
            {

            }

            return succeedSent;
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}