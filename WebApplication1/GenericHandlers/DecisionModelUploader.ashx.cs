using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.ClassLibrary;


namespace WebApplication1.GenericHandlers
{
    /// <summary>
    /// Summary description for DecisionModelUploader
    /// </summary>
    public class DecisionModelUploader : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                clsKnowledgeBase obj_KB = new clsKnowledgeBase();

                string dirFullPath = obj_KB.Get_Profile_Path();
                string[] files;
                int numFiles;
                files = System.IO.Directory.GetFiles(dirFullPath);
                numFiles = files.Length;
                numFiles = numFiles + 1;
                string str_file = "";
                string title = "";
                foreach (string s in context.Request.Files)
                {
                    HttpPostedFile file = context.Request.Files[s];
                    string fileName = file.FileName;
                    string fileExtension = file.ContentType;

                    if (!string.IsNullOrEmpty(fileName))
                    {
                        fileExtension = Path.GetExtension(fileName);

                        str_file = clsKnowledgeBase.CreateString(8) + "_Uploaded_" + numFiles.ToString() + fileExtension;
                        string pathToSave_100 = dirFullPath + str_file;
                        file.SaveAs(pathToSave_100);
                        title = obj_KB.AddValidUploadedFile(str_file);
                        if (title == "NULL")
                            File.Delete(pathToSave_100);
                    }
                }
                //  database record update logic here  ()

                context.Response.Write(str_file + ";" + title);
            }
            catch
            {
                context.Response.Write("NULL");
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