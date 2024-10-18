using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.ClassLibrary;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for fileUploader
    /// </summary>
    public class fileUploader : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                string dirFullPath = HttpContext.Current.Server.MapPath("~/Image/Cases/");
                string[] files;
                int numFiles;
                files = System.IO.Directory.GetFiles(dirFullPath);
                numFiles = files.Length;
                numFiles = numFiles + 1;
                string str_image = "";

                foreach (string s in context.Request.Files)
                {
                    HttpPostedFile file = context.Request.Files[s];
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        fileExtension = Path.GetExtension(fileName);
                        str_image = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "_" + numFiles.ToString() + fileExtension;
                        string pathToSave_100 = HttpContext.Current.Server.MapPath("~/Image/Cases/") + str_image;

                        clsKnowledgeBase obj_KB = new clsKnowledgeBase();
                        obj_KB.UpdateImage_Current_Case(str_image);

                        file.SaveAs(pathToSave_100);

                    }
                }
                //  database record update logic here  ()

                context.Response.Write(str_image);
            }
            catch (Exception ac)
            {

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