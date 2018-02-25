using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Net;
using System.IO;
using System.Text;


namespace CmlTechniques
{
    public partial class cmlhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if ((string)Session["uid"] != null)
                userinfo.Text = "Login as : " + (string)Session["uid"] + " , ";
            else
                Response.Redirect("Default.aspx");
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                _tdadmin.Visible = false;
            else
                _tdadmin.Visible = true;


            if (!IsPostBack)
            {
               // Load_ProjectHome();
               // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "getIP();", true);
                //User_Log();                
            }
        }
        //void User_Log()
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _clslog _objcls = new _clslog();
        //    _objcls.uid = (string)Session["uid"];
        //    //string _ipaddr = Request.Form["_ip"].ToString();
        //    _objcls.ipaddr = "default";
        //    _objcls.location = "United Arab Emirates";
        //    _objcls.login = DateTime.Now;           
        //   // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _ipaddr + "');", true);
        //    //_objcls.login = Convert.ToDateTime(_login.Text.ToString());
        //    _objbll.LOG(_objcls);
        //}
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                if (Request.Cookies["group"] != null)
                {
                    Session["group"] = Server.HtmlEncode(Request.Cookies["group"].Value);
                }
            }
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookiePrjCode = new HttpCookie("project");
                _CookiePrjCode.Value = (string)Session["project"];
                _CookiePrjCode.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookiePrjCode);
                HttpCookie _CookiePrjname = new HttpCookie("projectname");
                _CookiePrjname.Value = (string)Session["projectname"];
                _CookiePrjname.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookiePrjname);

            }
            else
                return;
        }
        void Load_ProjectHome()
        {
            //btnDummy.Style.Add("display", "none");
            BLL_Dml _objbll = new BLL_Dml();
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            //myprojectgrid.DataSource = _objbll.load_projecthome(_objcls);
            //myprojectgrid.DataBind();
            //userinfo.Text = "Login as: " + publicCls.publicCls._user + " Time: " + publicCls.publicCls._logintime + " ";
        }

        protected void myprojectgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int _rowidx = Convert.ToInt32(e.CommandArgument);
            //GridViewRow _srow = myprojectgrid.Rows[_rowidx];
            //TableCell _item = _srow.Cells[3];
            //TableCell _item_Name = _srow.Cells[4];
            //Session["project"] = _item.Text;
            //Session["projectname"] = _item_Name.Text;
            //_Create_Cookies();
            //btnDummy_ModalPopupExtender.Show();
        }
        protected void btnCont_Click(object sender, EventArgs e)
        {
            //if (rdbtnDMS.Checked == true)
            //{
            //    Session["module"] = "DMS";
            //    //publicCls.publicCls _obj = new publicCls.publicCls();
            //    //_obj.Load_Tree((string)Session["project"], (string)Session["uid"]);
            //    Response.Redirect("projecthome.aspx");
            //    //Response.TransmitFile("projecthome.aspx");
            //    //Response.Write("<script type='text/javascript'> javascript:window.open('projecthome.aspx');</script>");
            //    //Server.Transfer("projecthome.aspx" );
            //}
            //else if (rdbtnCMS.Checked == true)
            //{
            //    Session["module"] = "CMS";

            //}
            //else if (rdbtnTMS.Checked == true)
            //    Session["module"] = "TMS";

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //            Dim path As String = Server.MapPath(strRequest) 'get file object as FileInfo 
            //Dim file As System.IO.FileInfo = New System.IO.FileInfo(path) '-- if the file exists on the server
            //If file.Exists Then 'set appropriate headers 
            //Response.Clear() 
            //Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
            //Response.AddHeader("Content-Length", file.Length.ToString())
            //Response.ContentType = "application/octet-stream" 
            //Response.WriteFile(file.FullName) 
            //Response.End 'if file does not exist 
            //Else 
            //Response.Write("This file does not exist.") 
            //End If 'nothing in the URL as HTTP GET 
            //string _path = Server.MapPath("dap96.exe");
            //FileInfo _file = new FileInfo(_path);
            ScriptManager.RegisterStartupScript(this, typeof(string), "FileNotFoundWarning", "alert('Not Available!');", true);
            //Response.Clear();
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + _file.Name);
            ////Response.AddHeader("Content-Length", _file.Length.ToString());
            ////Response.ContentType = "application/octet-stream";
            ////Response.WriteFile(_file.FullName);
            //Response.ContentType = "application/exe";
            ////Response.AddHeader("content-disposition", "attachment; filename=download.exe");
            ////FileStream sourceFile = new FileStream(@"F:downloadexample.exe", FileMode.Open);
            //FileStream _source = new FileStream(_file.FullName, FileMode.Open);
            //long FileSize;
            //FileSize = _source.Length;
            //byte[] getContent = new byte[(int)FileSize];
            //_source.Read(getContent, 0, (int)_source.Length);
            //_source.Close();
            //Response.BinaryWrite(getContent);




        }



        private bool DownloadableProduct_Tracking()
        {
            //File Path and File Name
            string filePath = Server.MapPath("~/Documents");
            string _DownloadableProductFileName = "3.03 Drainage.pdf";

            System.IO.FileInfo FileName = new System.IO.FileInfo(filePath + "\\" + _DownloadableProductFileName);
            FileStream myFile = new FileStream(filePath + "\\" + _DownloadableProductFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Reads file as binary values
            BinaryReader _BinaryReader = new BinaryReader(myFile);

            //Ckeck whether user is eligible to download the file
            //Check whether file exists in specified location
                if (FileName.Exists)
                {
                    try
                    {
                        long startBytes = 0;
                        string lastUpdateTiemStamp = File.GetLastWriteTimeUtc(filePath).ToString("r");
                        string _EncodedData = HttpUtility.UrlEncode(_DownloadableProductFileName, Encoding.UTF8) + lastUpdateTiemStamp;

                        Response.Clear();
                        Response.Buffer = false;
                        Response.AddHeader("Accept-Ranges", "bytes");
                        Response.AppendHeader("ETag", "\"" + _EncodedData + "\"");
                        Response.AppendHeader("Last-Modified", lastUpdateTiemStamp);
                        Response.ContentType = "application/octet-stream";
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName.Name);
                        Response.AddHeader("Content-Length", (FileName.Length - startBytes).ToString());
                        Response.AddHeader("Connection", "Keep-Alive");
                        Response.ContentEncoding = Encoding.UTF8;

                        //Send data
                        _BinaryReader.BaseStream.Seek(startBytes, SeekOrigin.Begin);

                        //Dividing the data in 1024 bytes package
                        int maxCount = (int)Math.Ceiling((FileName.Length - startBytes + 0.0) / 1024);

                        //Download in block of 1024 bytes
                        int i;
                        for (i = 0; i < maxCount && Response.IsClientConnected; i++)
                        {
                            Response.BinaryWrite(_BinaryReader.ReadBytes(1024));
                            Response.Flush();
                        }
                        //if blocks transfered not equals total number of blocks
                        if (i < maxCount)
                            return false;
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                    finally
                    {
                        Response.End();
                        _BinaryReader.Close();
                        myFile.Close();
                    }
                }
                else 
                    ScriptManager.RegisterStartupScript(this, typeof(string), "FileNotFoundWarning", "alert('File is not available now!');", true);
                return false;
            }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
//User_Log();
        }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string),"NotEligibleWarning", "alert('Sorry! File is not available for you')", true);
            //}
            //return false;
        

    }
}
 