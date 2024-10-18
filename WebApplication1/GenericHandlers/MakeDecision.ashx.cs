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
    /// Summary description for MakeDecision
    /// </summary>
    public class MakeDecision : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            clsScript_Generator obj_JS = new clsScript_Generator();
            context.Response.Write(obj_JS.MakeDecision());
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