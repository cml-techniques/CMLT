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
    public partial class load : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            //Label1.Text = Request.QueryString[0].ToString();
            if (!IsPostBack)
            {
                Load_document();
                
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
        private void GetSummary(int _id)
        {
            int _uploaded = 0;
            int _pending = 0;
            int _scheduled = 0;
            int _cms_sch = 0;
            int _cms_upl = 0;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocument _objcls = new _clsdocument();
            _objcls.folder_id = _id;
            _clsuser _objcls1=new _clsuser();
             _objdb.DBName = "DBCML";
             _objcls1.project_code = lblprj.Text;
            if (_objbll.Check_CMS(_objcls1, _objdb) == true)
            {
                _objdb.DBName = "DB_" + lblprj.Text;
                _cms_sch = _objbll.Get_CMS_TC_Scheduled(_objcls, _objdb);
                _cms_upl = _objbll.Get_CMS_TC_Upladed(_objcls, _objdb);
            }
            _uploaded = mydocgrid.Rows.Count;
            _pending = mygriddr.Rows.Count;
            _scheduled = _uploaded + _pending + _cms_sch - _cms_upl;
           // _uploaded = _uploaded + _cms_upl;
            lbl_upload.Text = _uploaded.ToString();
            lbl_schedule.Text = _scheduled.ToString();
            decimal _percentage=0; 
            if(_scheduled!=0)
                _percentage = decimal.Round((Convert.ToDecimal(_uploaded) / Convert.ToDecimal(_scheduled)) * 100,0);
            lbl_percentage.Text = _percentage.ToString() + "%";
        }
        private void Load_document()
        {
            myframe.Visible = false;
            string _value = Request.QueryString[0].ToString();
            _value = _value.Replace("<>", "&");
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _value + "');", true);
            string _path = _value.Substring(_value.IndexOf("_P") + 2, _value.IndexOf("_B") - (_value.IndexOf("_P") + 3));
            _path = _path.Replace("@", " > ");
            _path = _path.Replace("*", " > ");
            Session["parent"] = _value.Substring(_value.Length - 1);
            Session["type"] = _value.Substring(_value.Length - 3, 1);
            Session["folder"] = _value.Substring(_value.IndexOf("*") + 1, _value.IndexOf("_B") - _value.IndexOf("*") - 2);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["parent"] + "');", true);
            lblprj.Text = _value.Substring(0, _value.IndexOf("_R"));
            int _id = Convert.ToInt32(_value.Substring(_value.IndexOf("_R") + 2, _value.IndexOf("_P") - (_value.IndexOf("_R") + 2)));
            //int _id = Convert.ToInt32(Request.QueryString[0].ToString());
            Label1.Text = _path;
            bool _enable = true;
            publicCls.publicCls _obj = new publicCls.publicCls();
            _obj.Load_Documents();
            mydocgrid.Visible = true;
            publicCls.publicCls._doctype = "0";
            DataTable _dtable2 = new DataTable();
            _dtable2.Columns.Add("doc_name");
            _dtable2.Columns.Add("doc_title");
            _dtable2.Columns.Add("uploaded_date");
            _dtable2.Columns.Add("file_size");
            _dtable2.Columns.Add("type");
            //_dtable1.Columns.Add("STATUS");
            var Result1 = from o in publicCls.publicCls._dtdocuments.AsEnumerable()
                          where o.Field<int>(0) == _id && o.Field<bool>(1) == _enable
                          select o;
            foreach (var row in Result1)
            {
                DataRow _myrow = _dtable2.NewRow();
                _myrow[0] = row[4].ToString();
                DateTime _date = Convert.ToDateTime(row[6].ToString());
                _myrow[1] = row[3].ToString();
                _myrow[2] = string.Format("{0:dd/MM/yyyy}", _date);
                _myrow[3] = row[7].ToString();
                _myrow[4] = "0";
                _dtable2.Rows.Add(_myrow);
            }
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _objcls.prj_code = lblprj.Text;
            _objcls.srv = _id;
            DataTable _dt = _objbll.Load_DMS_TCDOC_SYS(_objcls, _objdb);
            _objdb.DBName = "DB_" + lblprj.Text;
            foreach (DataRow _drow in _dt.Rows)
            {
                _objcls.sys = Convert.ToInt32(_drow[0].ToString());
                DataTable _dt1 = _objbll.Load_DMS_TCDOC(_objcls, _objdb);
                foreach (DataRow _drow1 in _dt1.Rows)
                {
                    DataRow _myrow = _dtable2.NewRow();
                    _myrow[0] = _drow1[0].ToString();
                    _myrow[1] = _drow1[2].ToString();
                    _myrow[2] = _drow1[1].ToString();
                    _myrow[3] = "";
                    _myrow[4] = "1";
                    _dtable2.Rows.Add(_myrow);
                }
            }
            //if ((string)Session["type"] == "3")
            //{
            //    mydocgrid.Visible = false;
            //    mygriddr.Visible = true;
            //    mygriddr.DataSource = _dtable2;
            //    mygriddr.DataBind();

            //}
            //else
            //{
                //mygriddr.Visible = false;
                mydocgrid.Visible = true;
                mydocgrid.DataSource = _dtable2;
                mydocgrid.DataBind();

            //}
            Load_ScheduleList(_id, lblprj.Text);
            GetSummary(_id);
        }
        private void Load_CMS_Testsheets(int _folder)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DBCML";
            //_clscassheet _objcls = new _clscassheet();
            //_objcls.prj_code = (string)Session["project"];
            //_objcls.srv = _folder;
            //DataTable _dt = _objbll.Load_DMS_TCDOC_SYS(_objcls, _objdb);
            //foreach (DataRow _drow in _dt.Rows)
            //{
            //    DataRow _myrow = _dtable2.NewRow();
            //    _myrow[0] = row[4].ToString();
            //    DateTime _date = Convert.ToDateTime(row[6].ToString());
            //    _myrow[1] = row[3].ToString();
            //    _myrow[2] = string.Format("{0:dd/MM/yyyy}", _date);
            //    _myrow[3] = row[7].ToString();
            //    _dtable2.Rows.Add(_myrow);
            //}
        }
        private void Load_ScheduleList(int folder_id,string project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.project_code = project;
            _objcls.folder_id = folder_id;
            mygriddr.DataSource = _objbll.Load_ScheduleList(_objcls, _objdb);
            mygriddr.DataBind();
        }
        protected void mydocgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            mydiv.Visible = false;
            myframe.Visible = true;
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mydocgrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[0];
            TableCell _type = _srow.Cells[6];
            string _file = _item.Text;
            Session["file"] = _item.Text;
            string _prm = _type.Text;
            _Create_Cookies();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent._view('"+ _prm +"');", true);
            //if((string)Session["parent"]=="A")
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.call();", true);
            //else
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent._view();", true);
                //myframe.Attributes.Add("src", "viewdocument.aspx");
           
            //Response.Redirect("viewdocument.aspx");
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _Cookiefile = new HttpCookie("file");
                _Cookiefile.Value = (string)Session["file"];
                _Cookiefile.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookiefile);
            }
            else
                return;
        }
        protected void mydocgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[6].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image img = (Image)e.Row.Cells[2].FindControl("Image1");
                string _file = e.Row.Cells[0].Text;
                string _ext = "pdf";
                if (_file.Length > 3)
                    _ext = _file.Substring(_file.Length - 3);
                if (_ext == "dwf")
                {
                    img.ImageUrl = "Images/dwf_icon.gif";
                }
                else if (_ext == "dwg")
                {
                    img.ImageUrl = "Images/dwg_icon.png";
                }
                else
                {
                    img.ImageUrl = "Images/pdf_logo_15x15.gif";

                }
            }
        }

        protected void mygriddr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            mydiv.Visible = false;
            myframe.Visible = true;
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygriddr.Rows[_rowidx];
            TableCell _item = _srow.Cells[0];
            string _file = _item.Text;
            Session["file"] = _item.Text;
            _Create_Cookies();
            if (e.CommandName == "download")
            {
                _download();
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent._view();", true);
        
        }
        private void _download()
        {
            string _path =Server.MapPath("Documents") + "\\" + (string)Session["file"];
            System.IO.FileInfo _finfo = new System.IO.FileInfo(_path);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + _finfo.Name);
            Response.AddHeader("Content-Length", _finfo.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(_finfo.FullName);
            Response.End();
        }
        protected void mydocgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void mydocgrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if ((string)Session["type"] == "2")
                    e.Row.Cells[1].Text = "MANUFACTURER INFORMATION";
                else if ((string)Session["type"] == "4")
                    e.Row.Cells[1].Text = "TESTING COMMISSIONING DATA";
                else if ((string)Session["type"] == "3")
                    e.Row.Cells[1].Text = "RECORD DRAWINGS";
            }
        }

        protected void mygriddr_RowCreated(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                if ((string)Session["type"] == "2")
                    e.Row.Cells[0].Text = "MANUFACTURER INFORMATION";
                else if ((string)Session["type"] == "4")
                    e.Row.Cells[0].Text = "TESTING COMMISSIONING DATA";
                else if ((string)Session["type"] == "3")
                    e.Row.Cells[0].Text = "RECORD DRAWINGS";
            }

            
        }

        protected void mygriddr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image img = (Image)e.Row.Cells[1].FindControl("Image1");
                string _file = e.Row.Cells[2].Text;
                string _ext="pdf";
                if(_file.Length>3)
                     _ext = _file.Substring(_file.Length - 3);
                if (_ext == "dwf")
                {
                    img.ImageUrl = "Images/dwf_icon.gif";
                }
                else if (_ext == "dwg")
                {
                    img.ImageUrl = "Images/dwg_icon.png";
                }
                else
                {
                    img.ImageUrl = "Images/pdf_logo_15x15.gif";

                }
            }
        }

       

    }
}
