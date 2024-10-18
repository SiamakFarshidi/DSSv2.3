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
    /// Summary description for UpdateCase
    /// </summary>
    /// 
    public class clsCase
    {
        public string title { get; set; }
        public string explanation { get; set; }
    }

    public class UpdateCase : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsCase));
                    clsCase objCase = (clsCase)deserializer.ReadObject(ms);

                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    obj_KB.Update_Current_Case(objCase.title, objCase.explanation);
                    context.Response.Write(objCase.title);
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