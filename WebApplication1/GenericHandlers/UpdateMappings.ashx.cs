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
    public class clsUpdateMapping
    {
        public string AspectID { get; set; }
        public string ParentID { get; set; }
        public string newValue { get; set; }
    }
    public class UpdateMappings : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsUpdateMapping));
                    clsUpdateMapping objMapping = (clsUpdateMapping)deserializer.ReadObject(ms);
                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();

                    bool result = obj_KB.UpdateLink(objMapping.AspectID, objMapping.ParentID, objMapping.newValue);
                    context.Response.Write(result);
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