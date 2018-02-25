using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Collections;
using System.IO;

namespace CmlTechniques.CMS
{
    public partial class tcdocumentation : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _query = Request.QueryString[0].ToString();
                Session["sch"] = _query.Substring(0, _query.IndexOf("_P"));
                //Session["project"] = _query.Substring(_query.IndexOf("_P") + 2);
                //lblprj.Text = _query.Substring(0, _query.IndexOf("_P"));
                if (_query.Contains("_D") == true)
                {
                    Session["project"] = _query.Substring(_query.IndexOf("_P") + 2, _query.IndexOf("_D") - (_query.IndexOf("_P") + 2));
                    lbldiv.Text = _query.Substring(_query.IndexOf("_D") + 2);

                }
                else
                {
                    Session["project"] = _query.Substring(_query.IndexOf("_P") + 2);
                    lbldiv.Text = "0";
                }
                lblprj.Text = (string)Session["project"];
                
                Load_Master();
                Load_InitialData();
                Load_Filtering_Elements();
                Hide_Details();
                Session["filter"] = "no";
                Session["zone"] = "";
                Session["flvl"] = "";
                Session["cat"] = "";
                Session["fed"] = "";
                Session["loc"] = "";
                settings();

                if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
                {
                    Get_ProjectName();
                    package.Text = Session["TCHeading"].ToString();
                 
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }
            }
        }
        private void Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            prj.Text = _objbll.Get_ProjectName(_objcls, _objdb);
        }
        protected void settings()
        {
            if ((string)Session["sch"] == "5" || (string)Session["sch"] == "1")
            {
                lblhead.Text = "CAS E4 Electrical Services. LV Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "2")
            {
                lblhead.Text = "CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "3")
            {
                lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "4")
            {
                lblhead.Text = "CAS E5 Electrical Services. Generator Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "6")
            {
                lblhead.Text = "CAS E3 Electrical Services. Earthing & Lightning Protection Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "7")
            {
                lblhead.Text = "CAS E6 Electrical Services. Emergency Lighting Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "17")
            {
                if ((string)Session["sch"] == "8")
                    lblhead.Text = "CAS M1 Mechanical Services Commissioning Activity Schedule";
                else if ((string)Session["sch"] == "17")
                    lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "9")
            {
                lblhead.Text = "CAS M3 Fusible Link Fire Dampers & MSFD Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "10")
            {
                lblhead.Text = "CAS ELV1 Fire Alarm & Voice Evacuation Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "11")
            {
                lblhead.Text = "CAS ELV5 Lighting Control System Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "12")
            {
                lblhead.Text = "CAS ELV6 Structured Cabling Network Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "13")
            {
                lblhead.Text = "CAS ELV3 Closed Circuit Television Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "14")
            {
                lblhead.Text = "CAS ELV8 Audio-Visual Intercom Commissioning Activity Schedule";

            }
            else if ((string)Session["sch"] == "15")
            {
                lblhead.Text = "CAS ELV7 Guest Room Management System Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "16")
            {
                lblhead.Text = "CAS ELV - Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "18")
            {
                lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "19")
            {
                lblhead.Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "20")
            {
                lblhead.Text = "CAS ELV2 Building Management System Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "21")
            {
                lblhead.Text = "CAS M2 Flushing Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "22")
            {
                lblhead.Text = "CAS ELV4 Access Control System Commissioning Activity Schedule";
            }

        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];

            if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS" ||lblprj.Text == "14211")
                _objcas.sys = Convert.ToInt32(lbldiv.Text);
            else
                _objcas.sys = 0;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            if (lblprj.Text == "11736" || lblprj.Text == "Traini")
            {
                if (lbldiv.Text == "1")
                {
                    var _result = _dtMaster.Select("b_z ='PMCW' OR b_z ='PMPW' OR b_z ='PMVW'");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "2")
                {
                    var _result = _dtMaster.Select("b_z LIKE 'PMMB%' OR b_z='PMMV' OR b_z='PMST' OR b_z='PPP3' OR b_z='PPP4' OR b_z='PMMU' OR b_z='PMDW' ");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "3")
                {
                    var _result = _dtMaster.Select("b_z ='PSEC' OR b_z='PMWT' OR b_z='PSWB' OR b_z='PSGC' OR b_z='Energy Centre' OR b_z='PSGS'");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "4")
                    _dtresult = null;

            }
            else
                _dtresult = _dtMaster;
        }
        private void Load_InitialData()
        {
            DataTable _dtable = new DataTable();
            _dtable.Columns.Add("sys_id", typeof(string));
            _dtable.Columns.Add("sys_name", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"] }).Distinct();
            foreach (var row in distinctRows)
            {
                DataRow _row = _dtable.NewRow();
                _row[0] = row.col1.ToString();
                _row[1] = row.col2.ToString();
                _dtable.Rows.Add(_row);
            }
            mymaster.DataSource = _dtable;
            mymaster.DataBind();
        }
        private void Load_Filtering_Elements()
        {
            var _bzone = (from DataRow dRow in _dtresult.Rows
                          orderby dRow["B_Z"]
                          select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in _bzone)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drbuilding.Items.Add(_itm);
            }
            drbuilding.DataBind();
            var _cate = (from DataRow dRow in _dtresult.Rows
                         orderby dRow["Cat"]
                         select new { col1 = dRow["Cat"] }).Distinct();
            foreach (var row in _cate)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drcategory.Items.Add(_itm);
            }
            drcategory.DataBind();
            var _flvl = (from DataRow dRow in _dtresult.Rows
                         orderby dRow["F_lvl"]
                         select new { col1 = dRow["F_lvl"] }).Distinct();
            foreach (var row in _flvl)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drflevel.Items.Add(_itm);
            }
            drflevel.DataBind();
            var _loc = (from DataRow dRow in _dtresult.Rows
                        orderby dRow["Loc"]
                        select new { col1 = dRow["Loc"] }).Distinct();
            foreach (var row in _loc)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drloc.Items.Add(_itm);
            }
            drloc.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drloc.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drloc.SelectedValue = (string)Session["loc"];
        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                //if (Request.Cookies["project"] != null)
                //{
                //    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                //}
                //if (Request.Cookies["sch"] != null)
                //{
                //    Session["sch"] = Server.HtmlEncode(Request.Cookies["sch"].Value);
                //}
                if (Request.Cookies["srv"] != null)
                {
                    Session["srv"] = Server.HtmlEncode(Request.Cookies["srv"].Value);
                }

            }
        }
        private void Hide_Details()
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + index.ToString() + "');", true);
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            Button _btn = (Button)gvRow.FindControl("Button1");
            if (_btn.Text == "+")
            {
                _mydetails.Visible = true;
                _btn.Text = "-";
            }
            else if (_btn.Text == "-")
            {
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            GridView _mydetails = (GridView)gvRow.FindControl("mydetails");
            int _idx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = _mydetails.Rows[_idx];
            // _mydetails.Rows[_idx].Style.Add("background-color", "yellow");
            //int index = gvRow.RowIndex;
            TableCell _item1 = _srow.Cells[9];
            TableCell _item2 = _srow.Cells[10];
            TableCell _item3 = _srow.Cells[11];
            // TableCell _item3 = _srow.Cells[2];
            //string _file = _item.Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _file + "');", true);
            if (e.CommandName == "Upload")
            {
                Session["casid"] = _item1.Text;
                Session["Sys"] = _item2.Text;
                Session["idx"] = _idx.ToString();
                Session["FileName"] = _item3.Text;
                //lblfname.Text = "";
                //btndelete.Visible = false;
                //if (!string.IsNullOrEmpty(_item3.Text) && _item3.Text != "&nbsp;")
                //{
                //    lblfname.Text = "Existing File : " + _item3.Text;
                //    btndelete.Visible = true;
                //}

              btnDummy_ModalPopupExtender.Show();

                

                  
            }
            else if (e.CommandName == "testsheet")
            {
                string _path = "https://cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + _item3.Text;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _path.Replace("&amp;", "&") + "','','left=200,top=50,width=1024,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=1');", true);
            }
            else if (e.CommandName == "delete1")
            {
                lblid.Text = _item1.Text;
                ModalPopupExtender1.Show();
                
            }
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[10].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
            {
                e.Row.Cells[0].Enabled = false;
                //e.Row.Cells[9].Visible = false;
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton _imgbtn = (ImageButton)e.Row.Cells[8].FindControl("btnbutton");
                    _imgbtn.Visible = false;
                }
            }
            else
            {
                if (e.Row.Cells[11].Text == "" || e.Row.Cells[11].Text == "&nbsp;")
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        ImageButton _imgbtn = (ImageButton)e.Row.Cells[8].FindControl("btnbutton");
                        _imgbtn.Visible = false;
                    }
                }
               
            }
        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            uploadFiles();
            //FileUpload();
        }
        private void FileUpload()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcls = new _clscassheet();
            //string _dir = (string)Session["project"];
            //if (Directory.Exists(Server.MapPath("CMS_DOCS") + "\\" + _dir) == false)
            //    Directory.CreateDirectory(Server.MapPath("CMS_DOCS") + "\\" + _dir);

            //if (FileUpload1.HasFile)
            //{

            //    FileUpload1.SaveAs(Server.MapPath("CMS_DOCS") + "\\" + _dir + "\\" + FileUpload1.FileName);
            //    _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            //    _objcls.ts_filed = DateTime.Now.ToString().Substring(0, 10);
            //    _objcls.testsheet = System.IO.Path.GetFileName(FileUpload1.FileName);
            //    _objbll.Upload_TestSheet(_objcls, _objdb);
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Test sheet Uploaded!');", true);
            //    btnDummy_ModalPopupExtender.Hide();
            //    Load_Ini_Data();
            //}
            //else
            //{
            //}


        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            string _dir = (string)Session["project"];
            if (Directory.Exists(Server.MapPath("CMS_DOCS") + "\\" + _dir) == false)
                Directory.CreateDirectory(Server.MapPath("CMS_DOCS") + "\\" + _dir);


            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                //FileInfo _Ffile = new FileInfo(Server.MapPath("CMS_DOCS\\" + _dir) + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                //if (_Ffile.Exists == true)
                //    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(Server.MapPath("CMS_DOCS") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    //hpf.SaveAs("http://www.cmltechniques.com\\CmsDocs\\" + System.IO.Path.GetFileName(hpf.FileName));                          }
                    _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
                    _objcls.ts_filed = DateTime.Now.ToString().Substring(0, 10);
                    _objcls.testsheet = System.IO.Path.GetFileName(hpf.FileName);
                    _objbll.Upload_TestSheet(_objcls, _objdb);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Test sheet Uploaded!');", true);
                    btnDummy_ModalPopupExtender.Hide();
                    Load_Master();
                    Load_InitialData();
                }

            }

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }

        

        protected void drbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["zone"] = drbuilding.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text,"All", drloc.SelectedItem.Text);
        }

        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, "All", drloc.SelectedItem.Text);
        }

        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text,"All", drloc.SelectedItem.Text);
        }

        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text,"All", drloc.SelectedItem.Text);
        }

        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button _btn = (Button)e.Row.FindControl("btnupload");
                if (lblprj.Text != "123")
                    _btn.Visible = false;
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                DataTable _dtdetails = new DataTable();
                _dtdetails.Columns.Add("e_b_ref", typeof(string));
                _dtdetails.Columns.Add("B_Z", typeof(string));
                _dtdetails.Columns.Add("Cat", typeof(string));
                _dtdetails.Columns.Add("F_lvl", typeof(string));
                _dtdetails.Columns.Add("Seq_No", typeof(string));
                _dtdetails.Columns.Add("Loc", typeof(string));
                _dtdetails.Columns.Add("testsheet", typeof(string));
                _dtdetails.Columns.Add("C_id", typeof(int));
                _dtdetails.Columns.Add("Sys_name", typeof(string));
                _dtdetails.Columns.Add("Sys_id", typeof(int));
                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                               select _data;
                foreach (var row in _details)
                {
                    DataRow _row = _dtdetails.NewRow();
                    _row[0] = row["e_b_ref"].ToString();
                    _row[1] = row["B_Z"].ToString();
                    _row[2] = row["Cat"].ToString();
                    _row[3] = row["F_lvl"].ToString();
                    _row[4] = row["Seq_No"].ToString();
                    _row[5] = row["Loc"].ToString();
                    _row[6] = row["testsheet"].ToString();
                    _row[7] = row["C_id"].ToString();
                    _row[8] = row["Sys_name"].ToString();
                    _row[9] = row["Sys_id"].ToString();
                    _dtdetails.Rows.Add(_row);
                }
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
            }

        }
        private void Filtering(string _el1, string _el2, string _el3, string _el4, string _el5)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            if (_el5 == "") _el5 = "All";
            Load_Master();
            DataTable _dtfilter = _dtresult;
            _dtresult = new DataTable();
            _dtresult.Columns.Add("e_b_ref", typeof(string));
            _dtresult.Columns.Add("B_Z", typeof(string));
            _dtresult.Columns.Add("Cat", typeof(string));
            _dtresult.Columns.Add("F_lvl", typeof(string));
            _dtresult.Columns.Add("Seq_No", typeof(string));
            _dtresult.Columns.Add("Loc", typeof(string));
            _dtresult.Columns.Add("testsheet", typeof(string));
            _dtresult.Columns.Add("C_id", typeof(int));     
            _dtresult.Columns.Add("Sys_name", typeof(string));
            _dtresult.Columns.Add("Sys_id", typeof(int));
            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("Loc") == _el5
                          select o;
            }
            foreach (var row in _filter)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = row["Seq_No"].ToString();
                _row[5] = row["Loc"].ToString();
                _row[6] = row["testsheet"].ToString();
                _row[7] = row["C_id"].ToString();
                _row[8] = row["Sys_name"].ToString();
                _row[9] = row["Sys_id"].ToString();
                _dtresult.Rows.Add(_row);
            }
            //m.DataSource = _dtresult;
            //mygrid.DataBind();
            Load_InitialData();

        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            Delete_doc();
        }
        protected void Delete_doc()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            _objcls.cas_id = Convert.ToInt32(lblid.Text);
            _objbll.Delete_TestSheet(_objcls, _objdb);
            Load_Master();
            Load_InitialData();
            ModalPopupExtender1.Hide();
            
        }
        
        private void Remove_FolderFiles()
        {
            //string _path = "http://www.cmltechniques.com/CMS_DOCS/" + (string)Session["project"] + "/" + (string)Session["FileName"];
            string _path = Server.MapPath("~/CMS_DOCS/" + (string)Session["project"] + "/" + (string)Session["FileName"]);
            File.Delete(_path);

        }


        protected void mymaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName=="Multiupload")
            {
                
             Session["casid"] = e.CommandArgument.ToString();
              Response.Redirect("tcuploadmulti.aspx?" + Request.QueryString.ToString());

            }
           

        }
        
    }
}
