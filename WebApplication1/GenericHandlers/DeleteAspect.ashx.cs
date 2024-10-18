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
    public class clsAspectId
    {
        public string id { get; set; }
        public string level { get; set; }
    }

    public class DeleteAspect : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsAspectId));
                    clsAspectId objAspect = (clsAspectId)deserializer.ReadObject(ms);

                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    clsScript_Generator obj_JS = new clsScript_Generator();

                    obj_KB.DeleteAspect(objAspect.id);
                    obj_JS.Generate_JS_Aspects(objAspect.level);
                    context.Response.Write(objAspect.id);
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