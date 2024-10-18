using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.ExtraPage
{
    public partial class DownloadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string KnowledgeBaseFile = HttpContext.Current.Session["KB_Location"].ToString();

            string filename = KnowledgeBaseFile;
            FileInfo fileInfo = new FileInfo(filename);

            if (fileInfo.Exists)
            {
                filename = "Decision Model -" + DateTime.Now.ToString("ddMMyyyy - HHmmss", System.Globalization.CultureInfo.GetCultureInfo("en-US")) + fileInfo.Extension;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                HttpContext.Current.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.TransmitFile(fileInfo.FullName);
                HttpContext.Current.Response.End();
            }

        }
    }
}