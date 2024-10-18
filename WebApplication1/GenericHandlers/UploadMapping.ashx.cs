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
    /// Summary description for UploadMapping
    /// </summary>
    public class UploadMapping : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            clsKnowledgeBase obj_KB = new clsKnowledgeBase();
            obj_KB.UploadMappingFile(context);
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