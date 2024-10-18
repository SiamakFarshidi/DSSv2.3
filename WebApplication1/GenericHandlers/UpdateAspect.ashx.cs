using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Xml;
using WebApplication1.ClassLibrary;

namespace WebApplication1.GenericHandlers
{
    public class clsUpdateAspect
    {
        public string TreeLevel { get; set; }
        public string ID { get; set; }
        public string Title { get; set; }
        public string DataType { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public string Order { get; set; }
        public string UpperLevel { get; set; }
        public string Keywords { get; set; }
    }
    public class UpdateAspect : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsUpdateAspect));
                    clsUpdateAspect objAspect = (clsUpdateAspect)deserializer.ReadObject(ms);

                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    clsScript_Generator obj_JS = new clsScript_Generator();

                    obj_KB.UpdateAspect(objAspect.ID, objAspect.Title, objAspect.DataType, objAspect.Description, objAspect.Level, objAspect.Order, objAspect.UpperLevel, objAspect.Keywords);
                    obj_JS.Generate_JS_Aspects(objAspect.TreeLevel);
                    context.Response.Write(objAspect.ID);
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