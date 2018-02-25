using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;


namespace CmlTechniques
{
    public partial class welcome : System.Web.UI.Page
    {
        public string _str = "";
        public static DataTable _dtmaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
               

                Load_ProjectHome();
                //Load_Packages("14211");
                //_str = "hai";
                //CAS.Class1._OBJ_DATA_CAS.Selecting += new EventHandler(ObjectDataSource1_Selecting);
                //CAS.Class1._OBJ_DATA_CAS.Selecting += new ObjectDataSourceSelectingEventHandler(_OBJ_DATA_CAS_Selecting);

            }
        }

        void _OBJ_DATA_CAS_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

            throw new NotImplementedException();
        }
        private void Populate_ObjectDataSource()
        {
            if ((string)Session["project"] == "CCAD")
            {
                Class1._OBJ_DATA_CAS = new ObjectDataSource();
                Class1._OBJ_DATA_CAS.TypeName = "CmlTechniques.CAS.CasDataTableAdapters.Load_Cassheet_dataTableAdapter";
                Class1._OBJ_DATA_CAS.SelectMethod = "GetData";
                Class1._OBJ_DATA_CAS.SelectParameters.Add(new Parameter("prj_code", TypeCode.String, (string)Session["project"]));
            }
            else if ((string)Session["project"] == "ASAO")
            {
                Class1._OBJ_DATA_CAS1 = new ObjectDataSource();
                Class1._OBJ_DATA_CAS1.TypeName = "CmlTechniques.CAS.CasDataTableAdapters.Load_Cassheet_dataTableAdapter";
                Class1._OBJ_DATA_CAS1.SelectMethod = "GetData";
                Class1._OBJ_DATA_CAS1.SelectParameters.Add(new Parameter("prj_code", TypeCode.String, (string)Session["project"]));
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
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Your Session has been Expired! Please Login Again');", true);
                    return;
                }
                if (Request.Cookies["access"] != null)
                {
                    Session["access"] = Server.HtmlEncode(Request.Cookies["access"].Value);
                }
            }
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookiePrjCode = new HttpCookie("project");
                _CookiePrjCode.Value = (string)Session["project"];
                _CookiePrjCode.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_CookiePrjCode);
                HttpCookie _CookiePrjname = new HttpCookie("projectname");
                _CookiePrjname.Value = (string)Session["projectname"];
                _CookiePrjname.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_CookiePrjname);
                HttpCookie _Cookieaccess = new HttpCookie("access");
                _Cookieaccess.Value = (string)Session["access"];
                _Cookieaccess.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(_Cookieaccess);

            }
            else
                return;
        }
        void Load_ProjectHome()
        {
           
            //btnDummy.Style.Add("display", "none");
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            myprojectgrid.DataSource = _objbll.load_projecthome(_objcls, _objdb);
            myprojectgrid.DataBind();
            //userinfo.Text = "Login as: " + publicCls.publicCls._user + " Time: " + publicCls.publicCls._logintime + " ";
        }

        protected void myprojectgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = myprojectgrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[3];
            TableCell _item_Name = _srow.Cells[4];
            TableCell _item_access = _srow.Cells[2];
            Session["project"] = _item.Text;
            Session["projectname"] = _item_Name.Text.Replace("&amp", "*");
            Session["access"] = _item_access.Text;
            Session["dms"] = _srow.Cells[5].Text;
            Session["cms"] = _srow.Cells[6].Text;
            Session["tms"] = _srow.Cells[7].Text;
            Session["sns"] = _srow.Cells[8].Text;
            Session["tis"] = _srow.Cells[9].Text;
            _Create_Cookies();
            //if (_item.Text != "14211")
            //{
            if(_item_Name.Text.Length>=36)
                mhead.Text = _item_Name.Text.Substring(0,36) + ".. - Available Modules";
            else
                mhead.Text = _item_Name.Text + " -   Available Modules";
            set_module();
            btnDummy_ModalPopupExtender.Show();
            //}
            //else
            //{
            //    //ModalPopupExtender1.Show();
            //    Load_Packages(_item.Text);
            //    rd_facility.Enabled = false;
            //    btnenter.Enabled = false;
            //    string script = "function f(){$find(\"" + RadWindow1.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "key", script, true);
            //}


        }
        protected void set_module()
        {
            if ((string)Session["dms"] == "True") { btndms.Enabled = true; btndms.Style.Add("background", "url('images/dms_icon.png')"); }
            else { btndms.Enabled = false; btndms.Style.Add("background", "url('images/dms_icond.png')"); }
            if ((string)Session["cms"] == "True") { btncms.Enabled = true; btncms.Style.Add("background", "url('images/cms_icon.png')"); }
            else { btncms.Enabled = false; btncms.Style.Add("background", "url('images/cms_icond.png')"); }
            if ((string)Session["tms"] == "True") { btnams.Enabled = true; btnams.Style.Add("background", "url('images/ams_icon.png')"); }
            else { btnams.Enabled = false; btnams.Style.Add("background", "url('images/ams_icond.png')"); }
            if ((string)Session["sns"] == "True") { btnsns.Enabled = true; btnsns.Style.Add("background", "url('images/sns_icon.png')"); }
            else { btnsns.Enabled = false; btnsns.Style.Add("background", "url('images/sns_icond.png')"); }
            if ((string)Session["tis"] == "True") { btn_tis.Enabled = true; btn_tis.Style.Add("background", "url('images/tis_icon.png')"); }
            else { btn_tis.Enabled = false; btn_tis.Style.Add("background", "url('images/tis_icond.png')"); }
        }
        protected void btnCont_Click(object sender, EventArgs e)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsuser _objcls = new _clsuser();
            //_objcls.uid = (string)Session["uid"];
            //if (rdbtnDMS.Checked == true)
            //{
            //    Session["module"] = "DMS";
            //    //publicCls.publicCls _obj = new publicCls.publicCls();
            //    //_obj.Load_Tree((string)Session["project"], (string)Session["uid"]);
            //    //Response.Redirect("projecthome.aspx");
            //    _objcls.mode = 1;
            //    if (_objbll.Module_Access(_objcls, _objdb) == true)
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call(1,'" + (string)Session["project"] + "');", true);
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Access Denied');", true);
            //    }
            //    //Response.TransmitFile("projecthome.aspx");
            //    //Response.Write("<script type='text/javascript'> javascript:window.open('projecthome.aspx');</script>");
            //    //Server.Transfer("projecthome.aspx" );
            //}
            //else if (rdbtnCMS.Checked == true)
            //{
            //    Session["module"] = "CMS";
            //    _objcls.mode = 2;
            //    //if ((string)Session["access"] == "Admin")
            //    //{
            //    if (_objbll.Module_Access(_objcls, _objdb) == true)
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call(2,'" + (string)Session["project"] + "');", true);
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Access Denied');", true);
            //    }
            //    //}
            //    //else
            //    //    ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Not Available!');", true);
            //}
            //else if (rdbtnTMS.Checked == true)
            //{
            //    Session["module"] = "AMS";
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "", "parent.call(4,'" + (string)Session["project"] + "');", true);
            //}
            //else if (rdbtnSNS.Checked == true)
            //{
            //    Session["module"] = "SNS";
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call(3);", true);
            //}

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Dim path As String = Server.MapPath(strRequest) 'get file object as FileInfo 
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

        protected void myprojectgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;
        }



        //private bool DownloadableProduct_Tracking()
        //{
        //    //File Path and File Name
        //    string filePath = Server.MapPath("~/Documents");
        //    string _DownloadableProductFileName = "3.03 Drainage.pdf";

        //    System.IO.FileInfo FileName = new System.IO.FileInfo(filePath + "\\" + _DownloadableProductFileName);
        //    FileStream myFile = new FileStream(filePath + "\\" + _DownloadableProductFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        //    //Reads file as binary values
        //    BinaryReader _BinaryReader = new BinaryReader(myFile);

        //    //Ckeck whether user is eligible to download the file
        //    //Check whether file exists in specified location
        //    if (FileName.Exists)
        //    {
        //        try
        //        {
        //            long startBytes = 0;
        //            string lastUpdateTiemStamp = File.GetLastWriteTimeUtc(filePath).ToString("r");
        //            string _EncodedData = HttpUtility.UrlEncode(_DownloadableProductFileName, Encoding.UTF8) + lastUpdateTiemStamp;

        //            Response.Clear();
        //            Response.Buffer = false;
        //            Response.AddHeader("Accept-Ranges", "bytes");
        //            Response.AppendHeader("ETag", "\"" + _EncodedData + "\"");
        //            Response.AppendHeader("Last-Modified", lastUpdateTiemStamp);
        //            Response.ContentType = "application/octet-stream";
        //            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName.Name);
        //            Response.AddHeader("Content-Length", (FileName.Length - startBytes).ToString());
        //            Response.AddHeader("Connection", "Keep-Alive");
        //            Response.ContentEncoding = Encoding.UTF8;

        //            //Send data
        //            _BinaryReader.BaseStream.Seek(startBytes, SeekOrigin.Begin);

        //            //Dividing the data in 1024 bytes package
        //            int maxCount = (int)Math.Ceiling((FileName.Length - startBytes + 0.0) / 1024);

        //            //Download in block of 1024 bytes
        //            int i;
        //            for (i = 0; i < maxCount && Response.IsClientConnected; i++)
        //            {
        //                Response.BinaryWrite(_BinaryReader.ReadBytes(1024));
        //                Response.Flush();
        //            }
        //            //if blocks transfered not equals total number of blocks
        //            if (i < maxCount)
        //                return false;
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //        finally
        //        {
        //            Response.End();
        //            _BinaryReader.Close();
        //            myFile.Close();
        //        }
        //    }
        //    else
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "FileNotFoundWarning", "alert('File is not available now!');", true);
        //    return false;
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(string),"NotEligibleWarning", "alert('Sorry! File is not available for you')", true);
        //}
        //return false;
        void _download()
        {
            string path = Server.MapPath("Downloads/Adobe Reader 9.zip");
            System.IO.FileInfo _finfo = new System.IO.FileInfo(path);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + _finfo.Name);
            Response.AddHeader("Content-Length", _finfo.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(_finfo.FullName);
            Response.End();
        }

        protected void dwnpdf_Click(object sender, ImageClickEventArgs e)
        {
            _download();

        }

        protected void rdbtnDMS_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbtnDMS.Checked == true)
            //{
            //    rdbtnCMS.Checked = false;
            //    rdbtnTMS.Checked = false;
            //    rdbtnSNS.Checked = false;
            //}
        }

        protected void rdbtnCMS_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbtnCMS.Checked == true)
            //{
            //    rdbtnDMS.Checked = false;
            //    rdbtnTMS.Checked = false;
            //    rdbtnSNS.Checked = false;
            //}
        }

        protected void rdbtnTMS_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbtnTMS.Checked == true)
            //{
            //    rdbtnDMS.Checked = false;
            //    rdbtnCMS.Checked = false;
            //    rdbtnSNS.Checked = false;
            //}
        }
        protected void rdbtnSNS_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbtnSNS.Checked == true)
            //{
            //    rdbtnDMS.Checked = false;
            //    rdbtnCMS.Checked = false;
            //    rdbtnTMS.Checked = false;
            //}
        }





        protected void btncms_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            Session["module"] = "CMS";
            _objcls.mode = 2;
            if (_objbll.Module_Access(_objcls, _objdb) == true)
            {
                if ((string)Session["project"] == "CCAD")
                    Populate_ObjectDataSource();
                if ((string)Session["project"] == "14211" || (string)Session["project"] == "HMIM" || (string)Session["project"] == "HMHS")
                {
                    string _redirect = "CMS/CMS2.aspx?auh=" + (string)Session["uid"] + "&prj=" + (string)Session["project"] + "&mod=0";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.location.replace('" + _redirect + "');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call(2,'" + (string)Session["project"] + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Access Denied');", true);
            }
        }

        protected void btndms_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            Session["module"] = "DMS";
            _objcls.mode = 1;
            if (_objbll.Module_Access(_objcls, _objdb) == true)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call(1,'" + (string)Session["project"] + "');", true);
                btnDummy_ModalPopupExtender2.Show();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Access Denied');", true);
            }
        }

        protected void btnams_Click(object sender, EventArgs e)
        {
            Session["module"] = "AMS";
            ScriptManager.RegisterStartupScript(this, typeof(string), "", "parent.call(4,'" + (string)Session["project"] + "');", true);
        }

        protected void btnsns_Click(object sender, EventArgs e)
        {
            Session["module"] = "SNS";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call(3);", true);
        }

        protected void btn_tis_Click(object sender, EventArgs e)
        {
            Session["module"] = "TIS";
            ScriptManager.RegisterStartupScript(this, typeof(string), "", "parent.call(5,'" + (string)Session["project"] + "');", true);
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        private void Load_Packages(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + _prj;
            DataTable _dtpkg = _objbll.Load_fclty_Package(_objdb);
            rd_package.DataSource = _dtpkg;
            rd_package.DataTextField = "PKG_NAME";
            rd_package.DataValueField = "PKG_ID";
            rd_package.DataBind();
            _dtmaster = _objbll.Load_Facility(_objdb);
        }

        protected void rd_package_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            Load_Facility(Convert.ToInt32(rd_package.SelectedValue));
        }
        protected void rd_facility_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            btnenter.Enabled = true;
        }
        private void Load_Facility(int _pkg_id)
        {
            var _result = _dtmaster.Select("PKG_ID =" + _pkg_id);
            DataTable _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtmaster.Clone();
            rd_facility.Enabled = true;
            rd_facility.Items.Clear();
            rd_facility.DataSource = _dtresult;
            rd_facility.DataTextField = "FCLTY";
            rd_facility.DataValueField = "FCLTY_ID";
            rd_facility.DataBind();
        }
        protected void btnenter_Click(object sender, EventArgs e)
        {
            string _id = rd_facility.SelectedValue;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = (string)Session["uid"];
            Session["module"] = "CMS";
            _objcls.mode = 2;
            if (_objbll.Module_Access(_objcls, _objdb) == true)
            {
                //if ((string)Session["project"] == "ASAO" || (string)Session["project"] == "Trial" || (string)Session["project"] == "CCAD")
                //    Populate_ObjectDataSource();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call(2,'" + (string)Session["project"] + "');", true);
                string _redirect = "CMS/CMS2.aspx?auh=" + (string)Session["uid"] + "&prj=" + (string)Session["project"] + "&pkg=" + rd_package.SelectedItem.Text + "&fac=" + rd_facility.SelectedItem.Text;
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.location.replace('" + _redirect + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Access Denied');", true);
            }

        }
        protected void btnok_Click(object sender, EventArgs e)  
        {
            btnDummy_ModalPopupExtender2.Hide();
        }
        protected void btnNewDMS_Click(object sender, EventArgs e)  
        {
            btnDummy_ModalPopupExtender2.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('https://dms.cmltechniques.com');", true);

         }
       
       
    }
}
