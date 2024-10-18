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
    public class clsInfeasibleSolution
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    public class UpdateInfeasibleList : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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

                    DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(clsInfeasibleSolution));
                    clsInfeasibleSolution objInfeasibleSolution = (clsInfeasibleSolution)deserializer.ReadObject(ms);
                    clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                    context.Response.Write(obj_KB.GetSupportability(objInfeasibleSolution.ID));
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