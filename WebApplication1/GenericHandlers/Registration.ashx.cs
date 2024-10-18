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
    /// Summary description for Registration
    /// </summary>
    /// 

    public class clsRegistration
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Registration : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsRegistration));
                    clsRegistration objRegistration = (clsRegistration)deserializer.ReadObject(ms);

                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    if (obj_KB.createNewProfile(objRegistration.Name, "", "", "", "", objRegistration.Email, "false", objRegistration.Password))
                    {
                        context.Response.Write("succeed");
                    }
                    else
                        context.Response.Write("failed");
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