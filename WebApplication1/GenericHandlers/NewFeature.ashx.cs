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
    public class clsNewFeature
    {
        public string title { get; set; }
        public string description { get; set; }
        public string Keywords { get; set; }
        public string datatype { get; set; }
        public string MemberOf { get; set; }
        public string UICategory { get; set; }
    }

    public class NewFeature : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsNewFeature));
                    clsNewFeature objNewFeature = (clsNewFeature)deserializer.ReadObject(ms);

                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    clsScript_Generator obj_JS = new clsScript_Generator();

                    obj_KB.Add_New_Aspect(objNewFeature.title, objNewFeature.datatype, objNewFeature.description, "Feature", objNewFeature.UICategory, objNewFeature.MemberOf, objNewFeature.Keywords);
                    obj_JS.Generate_JS_Aspects("Features");
                    context.Response.Write(objNewFeature.title);
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