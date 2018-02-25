<%@ WebHandler Language="C#" Class="Uploader" %>

using System;
using System.Web;
using System.IO;
//using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class Uploader : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        try
            {
                context.Response.ContentType = "text/plain";
                string projectCode = context.Request.QueryString["prj"].ToString();
               

                if (context.Request.QueryString["prj"].ToString() != "")
                {

                    string dirFullPath = HttpContext.Current.Server.MapPath("..//CMS_DOCS//") + projectCode + "\\CableLog";

                    if (Directory.Exists(dirFullPath) == false)
                        Directory.CreateDirectory(dirFullPath);

                    if ((context.Request.QueryString["prj"].ToString() != ""))
                    {               
                        
                        HttpPostedFile file = context.Request.Files[0];
                        string fileName = file.FileName;
                        string fileExtension = file.ContentType;
                        fileExtension = Path.GetExtension(fileName);
                       
                        string pathToSave = dirFullPath + "\\" + fileName;
                        if (File.Exists(pathToSave))
                        {
                            context.Response.Write("fail");
                        }
                        else
                        {
                            file.SaveAs(pathToSave);
                            context.Response.Write("success");
                        }                           
                        
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("ERROR: " + ex.Message);
            }
    }

    public bool IsReusable {
        get {
            return false;
        }


    }



}