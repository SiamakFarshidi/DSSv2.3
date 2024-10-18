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
    public class clsNewAlternative
    {
        public string title { get; set; }
        public string description { get; set; }
        public string Corporation { get; set; }
    }
    public class NewAlternative : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsNewAlternative));
                    clsNewAlternative objNewAlternative = (clsNewAlternative)deserializer.ReadObject(ms);

                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    clsScript_Generator obj_JS = new clsScript_Generator();

                    obj_KB.Add_New_Aspect(objNewAlternative.title, "Description", objNewAlternative.description, "Alternative", objNewAlternative.Corporation, objNewAlternative.Corporation, "NULL");
                    obj_JS.Generate_JS_Aspects("Alternatives");
                    context.Response.Write(objNewAlternative.title);
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