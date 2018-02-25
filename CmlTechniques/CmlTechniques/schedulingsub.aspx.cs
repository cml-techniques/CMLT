using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace CmlTechniques
{
    public partial class schedulingsub : System.Web.UI.Page
    {
        public static DataTable _dtable;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                Get_details();
                Panel1.Visible = false;
                schedule_basket _obj = new schedule_basket();
                _obj.clear();
                Load_Schedule();
                Get_Schedule();
            }
        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["projectname"] != null)
                {
                    Session["projectname"] = Server.HtmlEncode(Request.Cookies["projectname"].Value);
                }
                if (Request.Cookies["fid"] != null)
                {
                    Session["fid"] = Server.HtmlEncode(Request.Cookies["fid"].Value);
                }
                if (Request.Cookies["pack"] != null)
                {
                    Session["pack"] = Server.HtmlEncode(Request.Cookies["pack"].Value);
                }
                if (Request.Cookies["serv"] != null)
                {
                    Session["serv"] = Server.HtmlEncode(Request.Cookies["serv"].Value);
                }
                if (Request.Cookies["type"] != null)
                {
                    Session["type"] = Server.HtmlEncode(Request.Cookies["type"].Value);
                }
                
            }
        }
        private void Get_details()
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + Request.QueryString[0].ToString() + "');", true);

            if (Request.QueryString[0].ToString() != "0")
            {
                string _str = Request.QueryString[0].ToString();
                Session["fid"] = _str.Substring(0, _str.IndexOf("_P"));
                Session["pack"] = _str.Substring(_str.IndexOf("_P") + 2, _str.IndexOf("_S") - (_str.IndexOf("_P") + 2));
                string _fol = _str.Substring(_str.IndexOf("_N") + 2, _str.IndexOf("_T") - (_str.IndexOf("_N") + 2));
                Session["folder"] = _fol.Replace("<>", "&");
                Session["serv"] = _str.Substring(_str.IndexOf("_S") + 2, _str.IndexOf("_N") - (_str.IndexOf("_S") + 2));
                Session["type"] = _str.Substring(_str.IndexOf("_T") + 2,1);
                txtfolder.Text = (string)Session["folder"];
                if (_str.IndexOf("_D") > 0)
                {
                    Session["dtype"] = _str.Substring(_str.IndexOf("_D") + 2);
                }
                else
                    Session["dtype"] = (string)Session["fid"];
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["serv"] + "');", true);
                getentry((string)Session["type"]);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Folder!');", true);

            }
            _CreateCookie();
        }
        void getentry(string _select)
        {
            if (_select == "1")
            {
                manufctr.Visible = true;
                drpmanufacture.Visible = true;
                cmdnew.Visible = true;
                manufctr.Text = "Contractor";
                lbtitle.Visible = false;
                title.Visible = false;
                load_contractor();
            }
            else if (_select == "2")
            {
                manufctr.Visible = true;
                drpmanufacture.Visible = true;
                cmdnew.Visible = true;
                manufctr.Text = "Manufacture";
                lbtitle.Visible = false;
                title.Visible = false;
                load_manufacturer();
            }
            else if (_select == "3")
            {
                manufctr.Visible = false;
                drpmanufacture.Visible = false;
                cmdnew.Visible = false;
                lbtitle.Visible = true;
                title.Visible = true;
                lbtitle.Text = "Drawing Title";
            }
            else if (_select == "4")
            {
                manufctr.Visible = false;
                drpmanufacture.Visible = false;
                cmdnew.Visible = false;
                lbtitle.Visible = true;
                title.Visible = true;
                lbtitle.Text = "Document Title";
            }
            else
            {
                manufctr.Visible = true;
                drpmanufacture.Visible = true;
                cmdnew.Visible = true;
                manufctr.Text = "Manufacture";
                lbtitle.Visible = false;
                title.Visible = false;
                load_manufacturer();
            }
        }
        private void _CreateCookie()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _Ckifid = new HttpCookie("fid");
                _Ckifid.Value = (string)Session["fid"];
                _Ckifid.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckifid);
                HttpCookie _Ckipack = new HttpCookie("pack");
                _Ckipack.Value = (string)Session["pack"];
                _Ckipack.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckipack);
                HttpCookie _Ckifol = new HttpCookie("folder");
                _Ckifol.Value = (string)Session["folder"];
                _Ckifol.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckifol);
                HttpCookie _Ckiserv = new HttpCookie("serv");
                _Ckiserv.Value = (string)Session["serv"];
                _Ckiserv.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckiserv);
                HttpCookie _Ckitype = new HttpCookie("type");
                _Ckitype.Value = (string)Session["type"];
                _Ckitype.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckitype);  
            }
            else
                return;
        }
        protected void cmdnew_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            cmdnew.Enabled = false;
        }

        protected void cmdadd_Click(object sender, EventArgs e)
        {
            if (txtnewmanufacturer.Text == "") return;
            BLL_Dml _objbal = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsmanufacture _objcls = new _clsmanufacture();
            _objcls.project_code = (string)Session["project"];
            _objcls.man_name = txtnewmanufacturer.Text;
            string _type = (string)Session["type"];
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ _type +"');", true);
            if (_type  == "2")
            {
                _objbal.Create_Manufacture(_objcls,_objdb);
                load_manufacturer();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Created New Manufacturer!');", true);
            }
            else if (_type == "1")
            {
                _objbal.Create_Contractor(_objcls, _objdb);
                load_contractor();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Created New Contractor!');", true);
            }
            else
            {
                _objbal.Create_Manufacture(_objcls, _objdb);
                load_manufacturer();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Created New Manufacturer!');", true);
            }
            Panel1.Visible = false;
            txtnewmanufacturer.Text = "";
            cmdnew.Enabled = true;
        }

        protected void cmdaddtobasket_Click(object sender, EventArgs e)
        {
            if (IsNullValidation() == true) return;
            string _string = "";
            string _type = (string)Session["type"];
            if (_type  == "1")
            {
                _string = drpmanufacture.SelectedItem.Text;
            }
            else if (_type == "2")
            {
                _string = drpmanufacture.SelectedItem.Text;
            }
            else if (_type == "3")
            {
                _string = title.Text;
            }
            else if (_type == "4")
            {
                _string = title.Text;
            }
            else
            {
                _string = drpmanufacture.SelectedItem.Text;
            }
            schedule_basket _objbasket = new schedule_basket();
            _objbasket.Insert((string)Session["serv"], (string)Session["pack"], (string)Session["dtype"], _string, txtdocument.Text, txtfolder.Text, (string)Session["fid"]);
            myschedule_basket.DataBind();
            //Load_myschedule_basket();
        }
        private void Load_myschedule_basket()
        {
            schedule_basket _objbasket = new schedule_basket();
            IEnumerable<DataRow> _result = from _data in _objbasket.GetData().AsEnumerable()
                          where _data.Field<string>("User_Id") == (string)Session["uid"]
                          select _data;
            myschedule_basket.DataSource = _result.CopyToDataTable<DataRow>();
            myschedule_basket.DataBind();

        }
        private bool IsNullValidation()
        {
            if (txtfolder.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Select Folder Name!');", true);
                return true;
            }
            else if (txtdocument.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Enter File Name!');", true);
                return true;
            }
            else if ((string)Session["type"] == "1")
            {
                if (drpmanufacture.SelectedItem.Text == "-- Select Contractor Name --")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Select Contractor Name!');", true);
                    return true;
                }
                else return false;
            }
            else if ((string)Session["type"] == "2")
            {
                if (drpmanufacture.SelectedItem.Text == "-- Select Manufacturer Name --")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Select Manufacturer Name!');", true);
                    return true;
                }
                else return false;
            }
            else if ((string)Session["type"] == "3" || (string)Session["type"] == "4")
            {
                if (title.Text.Length <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Enter Drawing Title!');", true);
                    return true;
                }
                else return false;
            }            
            else return false;

        }



        protected void Save_Click(object sender, EventArgs e)
        {
            if (myschedule_basket.Rows.Count <= 0) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.project_code = (string)Session["project"];
            // Label1.Text = (string)Session["project"];
            for (int idx = 0; idx < myschedule_basket.Rows.Count; idx++)
            {
                //Label1.Text = myschedule_basket.Rows.Count.ToString();
                _objcls.service_code = Convert.ToInt32(myschedule_basket.Rows[idx].Cells[6].Text);
                _objcls.doctype_code = Convert.ToInt32(myschedule_basket.Rows[idx].Cells[7].Text);
                _objcls.folder_id = Convert.ToInt32(myschedule_basket.Rows[idx].Cells[2].Text);
                _objcls.package_code = Convert.ToInt32(myschedule_basket.Rows[idx].Cells[3].Text);
                _objcls.doc_title = myschedule_basket.Rows[idx].Cells[4].Text;
                _objcls.doc_name = myschedule_basket.Rows[idx].Cells[5].Text;
                _objcls.uploaded_date = DateTime.Now;
                _objcls.uid = (string)Session["uid"];
                _objcls.possition = _objbll.get_schedule_possition(_objcls, _objdb) + 1;
                try
                {
                    _objbll.Create_Schedule(_objcls,_objdb);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    Label1.Text = ex.Message.ToString();
                }

                //Response.Write(myschedule_basket.Rows[idx].Cells[1].Text);
            }
            //Label1.Text = "Schedule Created...";
            ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Schedule Created!');", true);

            Clear();
        }
        void Clear()
        {
            txtfolder.Text = "";
            //drpmanufacture.Text = "-- Select Manufacturer Name --";
            txtdocument.Text = "";
            schedule_basket _obj = new schedule_basket();
            _obj.clear();
            myschedule_basket.DataBind();
        }
        void load_manufacturer()
        {
            drpmanufacture.Items.Clear();
            BLL_Dml _objbal = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            drpmanufacture.DataSource = _objbal.load_manufacturer(_objcls,_objdb);
            drpmanufacture.DataTextField = "Manufacture_name";
            drpmanufacture.DataValueField = "Manufacture_code";
            drpmanufacture.DataBind();
            drpmanufacture.Items.Insert(0, "-- Select Manufacturer Name --");
        }
        void load_contractor()
        {
            drpmanufacture.Items.Clear();
            BLL_Dml _objbal = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            drpmanufacture.DataSource = _objbal.load_Contractor(_objcls,_objdb);
            drpmanufacture.DataTextField = "con_name";
            drpmanufacture.DataValueField = "con_code";
            drpmanufacture.DataBind();
            drpmanufacture.Items.Insert(0, "-- Select Contractor Name --");
        }
        protected void myschedule_basket_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void myschedule_basket_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void myschedule_basket_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            uploadFile();
            Insert_to_DB();
            //GridView1.DataSource = Read_File();
            //GridView1.DataBind();
            
        }
        private void uploadFile()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    FileInfo _info = new FileInfo(Server.MapPath("Schedule") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    if (_info.Exists == true) _info.Delete();
                    hpf.SaveAs(Server.MapPath("Schedule") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    Session["xls"] = System.IO.Path.GetFileName(hpf.FileName);
                }
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
            }
        }
        private DataSet Read_File()
        {
            DataSet ds = new DataSet();
            FileInfo _info = new FileInfo(Server.MapPath("Schedule") + "\\" + (string)Session["xls"]);
            if (_info.Exists == false) return ds;
            string filelocation = _info.FullName;
            OleDbCommand excelCommand = new OleDbCommand(); OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter();
            string excelConnStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filelocation + "; Extended Properties ='Excel 8.0;HDR=Yes;IMEX=1'";
            OleDbConnection excelConn = new OleDbConnection(excelConnStr);
            excelConn.Open();
            DataTable dtPatterns = new DataTable(); excelCommand = new OleDbCommand("SELECT `TITLE` as TITLE,`NAME` as NAME FROM [DATA$]", excelConn);
            excelDataAdapter.SelectCommand = excelCommand;
            excelDataAdapter.Fill(dtPatterns);
            dtPatterns.TableName = "DATA";
            ds.Tables.Add(dtPatterns);
            return ds;

        }
        private void Insert_to_DB()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.project_code = (string)Session["project"];
            DataSet _dset = Read_File();
            _objcls.service_code = Convert.ToInt32((string)Session["serv"]);
            _objcls.doctype_code = Convert.ToInt32((string)Session["dtype"]);
            _objcls.folder_id = Convert.ToInt32((string)Session["fid"]);
            _objcls.package_code = Convert.ToInt32((string)Session["dtype"]);
            _objcls.uploaded_date = DateTime.Now;
            _objcls.uid = (string)Session["uid"];
            int _idx = _objbll.get_schedule_possition(_objcls, _objdb) + 1;
            foreach (DataRow  row in _dset.Tables[0].Rows)
            {
                _objcls.doc_title = row[0].ToString();
                _objcls.doc_name = row[1].ToString();
                _objcls.possition = _idx;
                _objbll.Create_Schedule(_objcls, _objdb);
                _idx += 1;
            }
            ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Schedule Uploaded!');", true);

        }
        private void Load_Schedule()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            _dtable = _objbll.load_schedule(_objcls, _objdb);
        }
        private void Get_Schedule()
        {
            string _folder = (string)Session["fid"];
            DataTable _dtable1 = new DataTable();
            _dtable1.Columns.Add("Folder");
            _dtable1.Columns.Add("manufacture");
            _dtable1.Columns.Add("doc_name");
            _dtable1.Columns.Add("Folder_id");
            _dtable1.Columns.Add("id");
            _dtable1.Columns.Add("srv");
            var _List = from o in _dtable.AsEnumerable()
                        where o.Field<int>(5) == Convert.ToInt32(_folder)
                        select o;
            try
            {
                foreach (var row in _List)
                {
                    DataRow _myrow = _dtable1.NewRow();
                    _myrow[0] = row[6].ToString();
                    _myrow[1] = row[2].ToString();
                    _myrow[2] = row[3].ToString();
                    _myrow[3] = row[5].ToString();
                    _myrow[4] = row[0].ToString();
                    _myrow[5] = row[7].ToString();
                    _dtable1.Rows.Add(_myrow);
                }
                myschedule.DataSource = _dtable1;
                myschedule.DataBind();
            }
            catch (Exception ex)
            {
                //Label1.Text = ex.ToString();
            }

        }

        protected void myschedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[4].Visible = false;
        }
        private void Delete_Schedule()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsdocument _objcls = new _clsdocument();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _objcls.schid = Convert.ToInt32((string)Session["id"]);
            _objbll.Delete_Schedule(_objcls,_objdb);
        }

        protected void myschedule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = myschedule.Rows[_rowidx];
            TableCell _item = _srow.Cells[4];
            Session["id"] = _item.Text;
            Delete_Schedule();
            Load_Schedule();
            Get_Schedule();
        }
    }
}
