using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using WebApplication1.ClassLibrary;

namespace WebApplication1.GenericHandlers
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    public class clsLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Login : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string jsonString = String.Empty;
            HttpContext.Current.Request.InputStream.Position = 0;
            using (System.IO.StreamReader inputStream =
            new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
            {
                jsonString = inputStream.ReadToEnd();


                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
                {
                    // Deserialization from JSON  

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsLogin));
                    clsLogin objLogin = (clsLogin)deserializer.ReadObject(ms);

                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    if (obj_KB.UserLogin(objLogin.Email, objLogin.Password))
                    {
                        clsScript_Generator objSG = new clsScript_Generator();
                        HttpContext.Current.Session["CurrentUserName"] = objSG.LimitOnWordBoundary(obj_KB.getUserByEmail(objLogin.Email).Attributes[0].Value,20);


                        context.Response.Write("succeed");
                    }
                    else
                        context.Response.Write("The email or password is invalid!");
                }
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}