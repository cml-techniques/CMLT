using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.IO;

namespace CmlTechniques
{
    public partial class viewdocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();

                //string _path = (string)Session["file"];
                //string _script = "<script language=javascript>javascript:openPDF('" + _path + "');</script>";
                //Response.Write("javascript:openPDF('Documents/1.01 Chilled Water and Cooling Services.pdf')");
                //if ((string)Session["file"] == null)
                //    Session["file"] = Request.QueryString[0].ToString();
                ////-------------------------------------------------------------------------
                ////string path = Server.MapPath("Documents\\") + (string)Session["file"];
                ////string path ="/Documents/" + (string)Session["file"];
                ////string path = Server.MapPath("Documents\\") + "MIST-1A-STS-L1-LB-PCHW-001 (1).dwf";
                ////WebClient client = new WebClient();
                ////Byte[] buffer = client.DownloadData(path);

                ////if (buffer != null)
                ////{
                ////    Response.ContentType = "application/pdf";
                ////    //Response.ContentType = "application/dwf";
                ////    Response.AddHeader("content-length", buffer.Length.ToString());
                ////    Response.BinaryWrite(buffer);
                ////}
                ////                Or   
                //////Set the appropriate ContentType.

                ////Response.ContentType = "Application/pdf";
                ////Get the physical path to the file.   
                ////-------------------------------------------------------------------------------------
                //String FilePath = Server.MapPath("Documents\\") + (string)Session["file"];
                string file = (string)Session["file"].ToString().Replace(" ", "%20");
               // string file = _prm.Substring(0, _prm.IndexOf("_T"));
                string _type = _prm;
                string FilePath="";
                //if((string)Session["module"] == "CMS")
                //    //FilePath = Server.MapPath("CmsDocs\\") + (string)Session["file"];
                //    FilePath = "http://www.cmltechniques.com/CmsDocs/" + file;
                //else
                if (_type == "0")
                    FilePath = "https://cmltechniques.com/Documents/" + file;
                else
                    FilePath = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + file;
                //String FilePath = Server.MapPath("Documents\\") + Request.QueryString[0].ToString();
                //string FilePath = Server.MapPath("Documents\\") + "MIST-1A-STS-UC-CHW-001.dwf" ;
                string ext = FilePath.Substring(FilePath.Length - 3);
                if (ext == "pdf")
                {
                    //Response.ContentType = "Application/pdf";
                    //Response.WriteFile(FilePath);
                    //Response.End();
                    myframe.Attributes.Add("src", FilePath);
                }
                else if(ext=="dwf")
                {
                    FilePath = Server.MapPath("Documents\\") + (string)Session["file"];
                    Response.ContentType = "Application/x-dwf";
                    Response.WriteFile(FilePath);
                    Response.End();
                }
                //Write the file directly to the HTTP output stream.   
                 
                //myframe.Attributes.Add("src", path);
            }

        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
            }
        }
    }
}
