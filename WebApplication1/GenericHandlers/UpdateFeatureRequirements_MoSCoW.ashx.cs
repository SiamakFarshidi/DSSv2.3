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
    /// <summary>
    /// Summary description for UpdateFeatureRequirements_MoSCoW
    /// </summary>
    public class UpdateFeatureRequirements_MoSCoW : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {
        public class clsMoSCoW
        {
            public string ID { get; set; }
            public string Req { get; set; }
        }
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsMoSCoW));
                    clsMoSCoW objMoSCoW = (clsMoSCoW)deserializer.ReadObject(ms);
                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    obj_KB.UpdateFeatureRequirements_MoSCoW(objMoSCoW.ID, objMoSCoW.Req);

                    context.Response.Write(objMoSCoW.ID);
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