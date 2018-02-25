using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques
{
    public partial class cassheetentry : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        [Serializable]
        private class minfo_
        {
            // indexes of merged columns
            public List<int> MergedColumns = new List<int>();
            // key-value pairs: key = the first column index, value = number of the merged columns
            public Hashtable StartColumns = new Hashtable();
            // key-value pairs: key = the first column index, value = common title of the merged columns 
            public Hashtable Titles = new Hashtable();

            //parameters: the merged columns indexes, common title of the merged columns 
            public void AddMergedColumns(int[] columnsIndexes, string title)
            {
                MergedColumns.AddRange(columnsIndexes);
                StartColumns.Add(columnsIndexes[0], columnsIndexes.Length);
                Titles.Add(columnsIndexes[0], title);
            }
        }
        private minfo_ info
        {
            get
            {
                if (ViewState["info"] == null)
                    ViewState["info"] = new minfo_();
                return (minfo_)ViewState["info"];
            }
        }
        private void RenderHeader(HtmlTextWriter output, Control container)
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[i];
                //stretch non merged columns for two rows
                if (!info.MergedColumns.Contains(i))
                {
                    cell.Attributes["rowspan"] = "2";
                    cell.RenderControl(output);
                }
                else //render merged columns common title
                    if (info.StartColumns.Contains(i))
                    {
                        output.Write(string.Format("<th align='center' style='font-weight:normal' colspan='{0}'>{1}</th>",
                                 info.StartColumns[i], info.Titles[i]));
                    }
            }

            //close the first row	
            output.RenderEndTag();
            //set attributes for the second row
            mygrid.HeaderStyle.AddAttributesToRender(output);
            //start the second row
            output.RenderBeginTag("tr");

            //render the second row (only the merged columns)
            for (int i = 0; i < info.MergedColumns.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[info.MergedColumns[i]];
                cell.RenderControl(output);
              
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                settings();
                load_cas_sys();
                Load_Master();
                Load_Ini_Data();
                Merging();
                Load_Filtering_Elements();
                //Grouping();
                Session["filter"] = "no";
                Session["zone"] = "";
                Session["flvl"] = "";
                Session["cat"] = "";
                Session["fed"] = "";
            }
        }
        private void Grouping()
        {
            //GridGroupByExpression expression = new GridGroupByExpression();
            //GridGroupByField gridGroupByField = new GridGroupByField();
            //gridGroupByField = new GridGroupByField();
            //gridGroupByField.FieldName = "Sys_id";
            //gridGroupByField.HeaderText = "Sys_name";
            //gridGroupByField.HeaderValueSeparator = " for current group: ";
            //gridGroupByField.FormatString = "<strong>{0}</strong>";
            //expression.SelectFields.Add(gridGroupByField);
            //gridGroupByField = new GridGroupByField();
            //gridGroupByField.FieldName = "Sys_id";
            //expression.GroupByFields.Add(gridGroupByField);
            //mygrid.MasterTableView.GroupByExpressions.Add(expression);
            
        }
        protected void settings()
        {
            if ((string)Session["sch"] == "5" || (string)Session["sch"]=="1")
            {
                lbnum.Text = "No.of Circuits";
                lbl1.Text = "PR.POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                lblhead.Text = "CAS E5 Electrical Services. LV Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "2")
            {
                //lbnum.Text = "";
                //lbnum.Enabled = false;
                lbl1.Text = "PR.POWER TO";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                txtdesc.Visible = false;
                txtnoof.Visible = false;
                lblhead.Text = "CAS E1 Electrical Services. HV-MV Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "3")
            {
                lbl1.Text = "PR.POWER TO";
                lbl2.Text = "AREA";
                lbl3.Text = "FED FROM";
                txtnoof.Visible = false;
                lblhead.Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "4")
            {
                lbnum.Text = "No.of Circuits";
                lbl1.Text = "PR.POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                lblhead.Text = "CAS Electrical Services. Generator Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "6")
            {
                lbnum.Text = "";
                lbl1.Text = "PR.EARTHING TO";
                lbl2.Text = "";
                lbl3.Text = "";
                txtfedfr.Visible = false;
                txtdesc.Visible = false;
                txtnoof.Visible = false;
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS E3 Electrical Services. Earthing & Lightning Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "7")
            {
                lbnum.Text = "No. of Emergency Lights";
                lbl1.Text = "";
                lbl3.Text = "";
                txtfedfr.Visible = false;
                txtpprovideto.Visible = false;
                txtdesc.Visible = false;
                lbl2.Text = "";
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS Electrical Services. Emergency Lightning Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Visible = false;
                txtnoof.Visible = false;
                if((string)Session["sch"] == "8")
                    lblhead.Text = "CAS2 Mechanical Commissioning Activity Schedule";
                else if ((string)Session["sch"] == "9")
                    lblhead.Text = "";
                else if ((string)Session["sch"] == "17")
                    lblhead.Text = "CAS PH1 Public Health Services Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "10")
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                txtpprovideto.Visible = false;
                txtfedfr.Visible = false;
                lblhead.Text = "";
                drfed.Style.Add("display", "none");
            }
            else if ((string)Session["sch"] == "11")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "";
                lbloc.Text = "AREA SERVED FOR LC";
                lbnum.Text = "NO.OF CIRCUITS";
                txtdesc.Visible = false;
                txtpprovideto.Visible = false;
                txtfedfr.Visible = false;
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS 9 ELV - Lighting Control Commissioning Activity Schedule";

            }
            else if ((string)Session["sch"] == "12")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "CONNECTED FROM";
                lbnum.Text = "NO.OF POINTS";
                txtdesc.Visible = false;
                txtpprovideto.Visible = false;
                lblhead.Text = "CAS 11 ELV - Structured Cabling Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "13")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "";
                lbloc.Text = "SYS. MONITORED";
                lbnum.Text = "NO.OF POINTS";
                txtdesc.Visible = false;
                txtpprovideto.Visible = false;
                txtfedfr.Visible = false;
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS 8 ELV - CCTV Commissioning Activity Schedule";

            }
            else if ((string)Session["sch"] == "16")
            {
                lbl1.Text = "SYS.CONTROLLED/ MONITORED";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF INTERFACES";
                lblhead.Text = "CAS ELV - Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "18")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "";
                lbnum.Text = "Quantity";
                txtpprovideto.Visible = false;
                txtfedfr.Visible = false;
                //txtnoof.Enabled = false;
                //txtnoof.BackColor = System.Drawing.Color.Gray;
                lblhead.Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "19")
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "FED FROM";
                lbnum.Text = "";
                txtpprovideto.Visible = false;
                txtdesc.Visible = false;
                txtnoof.Visible = false;
                lblhead.Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule";
            }
            else if ((string)Session["sch"] == "20")
            {
                lbl1.Text = "SYS.CONTROLLED/ MONITORED";
                lbl2.Text = "NO.OF 240V CIRCUITS";
                lbl3.Text = "";
                lbnum.Text = "NO.OF POINTS";
                txtfedfr.Visible = false;
                drfed.Style.Add("display", "none");
                lblhead.Text = "CAS ELV 2 - BMS Commissioning Activity Schedule";
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
                if (Request.Cookies["sch"] != null)
                {
                    Session["sch"] = Server.HtmlEncode(Request.Cookies["sch"].Value);
                }
                if (Request.Cookies["srv"] != null)
                {
                    Session["srv"] = Server.HtmlEncode(Request.Cookies["srv"].Value);
                }
            }
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookieSch = new HttpCookie("sch");
                _CookieSch.Value = (string)Session["sch"];
                _CookieSch.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSch);
                HttpCookie _CookieSrv = new HttpCookie("srv");
                _CookieSrv.Value = (string)Session["srv"];
                _CookieSrv.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSrv);

            }
            else
                return;
        }

        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
        }
        private void Load_Filtering_Elements()
        {
            var _bzone = (from DataRow dRow in _dtMaster.Rows
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
            var _fedf = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["F_from"]
                         select new { col1 = dRow["F_from"] }).Distinct();
            foreach (var row in _fedf)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drfed.Items.Add(_itm);
            }
            drfed.DataBind();
            var _cate = (from DataRow dRow in _dtMaster.Rows
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
            var _flvl = (from DataRow dRow in _dtMaster.Rows
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
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
        }
        protected void Load_Ini_Data()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.sch = Convert.ToInt32((string)Session["sch"]);
            //_objcas.prj_code = (string)Session["project"];
            //mygrid.DataSource = _objbll.Load_casMain_Edit(_objcas, _objdb);
            //mygrid.DataBind();
            mygrid.DataSource = _dtMaster;
            mygrid.DataBind();
            GridViewHelper _help = new GridViewHelper(mygrid);
            _help.RegisterGroup("Sys_name", true, true);
            _help.GroupHeader += new GroupEvent(helper_GroupHeader);
            _help.ApplyGroupSort();
           
        }
        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "Sys_name")
            {
                row.BackColor = System.Drawing.Color.FromName("#b1dff6");
                //row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
                row.Height = 30;
                Button lb = new Button();
                lb.CommandArgument = row.Cells[0].Text; 
                lb.CommandName = "NumClick"; 
                lb.Text = row.Cells[0].Text;
                lb.OnClientClick = "javascript:alert('yes');";
                row.Cells[0].Controls.Add((Control)lb); 
            }

        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }
        protected void Merging()
        {
            //info.AddMergedColumns(new int[] { mygrid.MasterTableView.Columns[2].OrderIndex, mygrid.MasterTableView.Columns[3].OrderIndex, mygrid.MasterTableView.Columns[4].OrderIndex, mygrid.MasterTableView.Columns[5].OrderIndex }, "Asset Code");
        }
        protected void add_initial_data()
        {
            //if (IsNullvalidation() == true) return;
            string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            _objcas.uid = (string)Session["uid"];
            _objcas.sys = Convert.ToInt32(_sys);
            _objcas.reff = txtengref.Text;
            _objcas.b_zone = txtzone.Text;
            _objcas.cate = txtcate.Text;
            _objcas.f_level = txtlevel.Text;
            _objcas.seq_no = Convert.ToInt32(txtseq.Text);
            _objcas.desc = txtdesc.Text;
            _objcas.loca = txtloca.Text;
            _objcas.p_power_to = txtpprovideto.Text;
            _objcas.fed_from = txtfedfr.Text;
            _objcas.sub_st = txtdesc.Text;
            _objcas.s_c_m = txtdesc.Text;
            _objcas.dev1 = txtnoof.Text;

            if ((string)Session["sch"] == "10" || (string)Session["sch"] == "16" || (string)Session["sch"] == "20")
                _objcas.dev2 = txtdesc.Text;
            else
                _objcas.dev2 = "0";
            _objcas.dev3 = "0";
            _objcas.mode = 1;
            _objcas.cas_id = 0;
            _objbll.Cassheet_Master(_objcas, _objdb);

        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32((string)Session["sch"]);
            DataTable _dt0 = _objbll.Load_cas_sys(_objcls, _objdb);
            DataTable _dt1 = new DataTable();
            _dt1.Columns.Add("_id");
            _dt1.Columns.Add("_name");
            var _List = from o in _dt0.AsEnumerable()
                        where o.Field<string>(3) == (string)Session["project"]
                        select o;

            foreach (var row in _List)
            {
                DataRow _myrow = _dt1.NewRow();
                _myrow[0] = row[0].ToString() + "_C" + row[2].ToString();
                _myrow[1] = row[1].ToString();
                _dt1.Rows.Add(_myrow);
            }
            drpackage.DataSource = _dt1;
            drpackage.DataTextField = "_name";
            drpackage.DataValueField = "_id";
            drpackage.DataBind();
            drpackage.Items.Insert(0, "--Package--");
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "--Package--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Package');", true);
                Load_Ini_Data();
                return;
            }
            string _sys = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            if (txtnoof.Text.Length <= 0) txtnoof.Text = "0";
            int no = 0;
            string dev_vol = "";
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "2" || (string)Session["sch"] == "3")
                dev_vol = txtnoof.Text;
            else
                no = Convert.ToInt32(txtnoof.Text);
            add_initial_data();
            //add_asset_code(txtcate.Text, txtzone.Text, txtlevel.Text, txtseq.Text);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Data Svaed!');", true);
            Load_Master();
            Load_Ini_Data();
        }

        protected void btnfilter_Click(object sender, EventArgs e)
        {

        }

        protected void btnfcancel_Click(object sender, EventArgs e)
        {

        }

        //protected void mygrid_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
        //{
        //    if (e.Item.ItemType == GridItemType.Header)
        //        e.Item.SetRenderMethodDelegate(RenderHeader);

           
        //    if (e.Item is GridDataItem)
        //    {

        //        GridDataItem item = (GridDataItem)e.Item;

        //        Label lbl = (Label)item.FindControl("itm");
        //        lbl.Text = (item.ItemIndex + 1).ToString();
        //        //lbl.Attributes.Add("Text",(item.ItemIndex + 1).ToString());
        //        //chkbox.Attributes.Add("onclick", "chkclick('" + item.ItemIndex + "');"); // passing item index
        //       //Load_Filtering_Elements();

        //    }
        //    //mygrid.Columns[10].HeaderText = "No.";
        //    //mygrid.MasterTableView.Columns[10].HeaderText = "yes";
        //}

        protected void drpackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text != "--Package--")
            {
                txtcate.Text = drpackage.SelectedItem.Value.Substring(drpackage.SelectedItem.Value.IndexOf("_C") + 2);
                Get_SeqNo();                
            }
            Load_Ini_Data();
        }
        private void Get_SeqNo()
        {
            string Sys_Id = drpackage.SelectedItem.Value.Substring(0, drpackage.SelectedItem.Value.IndexOf("_C"));
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.sys = Convert.ToInt32(Sys_Id);
            txtseq.Text = _objbll.Get_Seq(_objcls, _objdb).ToString();
        }
        protected void drfilterby_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


       

        protected void mygrid_DataBound(object sender, EventArgs e)
        {

        }
        public static DataTable _dtfilter;
        private void Filtering(string _el1,string _el2,string _el3,string _el4 )
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            _dtfilter = _dtMaster;
            DataTable _dtresult = new DataTable();
            _dtresult.Columns.Add("e_b_ref", typeof(string));
            _dtresult.Columns.Add("B_Z", typeof(string));
            _dtresult.Columns.Add("Cat", typeof(string));
            _dtresult.Columns.Add("F_lvl", typeof(string));
            _dtresult.Columns.Add("Sq_No", typeof(string));
            _dtresult.Columns.Add("Loc", typeof(string));
            _dtresult.Columns.Add("P_P_to", typeof(string));
            _dtresult.Columns.Add("F_from", typeof(string));
            _dtresult.Columns.Add("Substation", typeof(string));
            _dtresult.Columns.Add("devices1", typeof(string));
            _dtresult.Columns.Add("C_id", typeof(int));
            _dtresult.Columns.Add("Sys_name", typeof(string));
            _dtresult.Columns.Add("Sys_id", typeof(int));
            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            }
            else if(_el1!= "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat")==_el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl")==_el3                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4
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
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _dtresult.Rows.Add(_row);
            }
            mygrid.DataSource = _dtresult;
            mygrid.DataBind();
            GridViewHelper _help = new GridViewHelper(mygrid);
            _help.RegisterGroup("Sys_name", true, true);
            _help.GroupHeader += new GroupEvent(helper_GroupHeader);
            _help.ApplyGroupSort();

        }
        protected void drbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["zone"] = drbuilding.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text);
        }
        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text);
        }
        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text);
        }
        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text);
        }

        protected void mygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            mygrid.PageIndex = e.NewPageIndex;
            mygrid.DataBind();
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Load_Ini_Data();           
            
        }

        protected void mygrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //string _data = mygrid.Rows[e.RowIndex].Cells[2].Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _data + "');", true);
            Session["casid"] = mygrid.Rows[e.RowIndex].Cells[12].Text;
            Session["Sys"] = mygrid.Rows[e.RowIndex].Cells[13].Text;
            Session["idx"] = e.RowIndex.ToString();
            arrange_edit();
            btnDummy_ModalPopupExtender.Show();

        }


        protected void mygrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = mygrid.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                //dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                dataView.Sort = "Sys_id,Seq_no" + " " + ConvertSortDirectionToSql(e.SortDirection);
                mygrid.DataSource = dataView;
                mygrid.DataBind();
            }
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[12].Visible = false;
            e.Row.Cells[13].Visible = false;
            //e.Row.Cells[0].Enabled = false;
            //if (e.Row.Cells[1].Text != "") return;
            //if (e.Row.Cells[0].Text != "")
            //    e.Row.Cells[0].Text = "hai" + e.Row.Cells[0].Text;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[4].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[7].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[8].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[9].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

            }
            if (txtnoof.Visible == false)
                e.Row.Cells[11].Text = "";

        }
        protected void arrange_edit()
        {
            int _idx = Convert.ToInt32((string)Session["idx"]);
            if (mygrid.Rows[_idx].Cells[2].Text.Trim() != "&nbsp;") upreff.Text = mygrid.Rows[_idx].Cells[2].Text;
            if (mygrid.Rows[_idx].Cells[3].Text.Trim() != "&nbsp;") upzone.Text = mygrid.Rows[_idx].Cells[3].Text;
            if (mygrid.Rows[_idx].Cells[4].Text.Trim() != "&nbsp;") upcate.Text = mygrid.Rows[_idx].Cells[4].Text;
            if (mygrid.Rows[_idx].Cells[5].Text.Trim() != "&nbsp;") upfloor.Text = mygrid.Rows[_idx].Cells[5].Text;
            if (mygrid.Rows[_idx].Cells[6].Text.Trim() != "&nbsp;") upseq.Text = mygrid.Rows[_idx].Cells[6].Text;
            if (mygrid.Rows[_idx].Cells[7].Text.Trim() != "&nbsp;") uploc.Text = mygrid.Rows[_idx].Cells[7].Text;
            if (mygrid.Rows[_idx].Cells[8].Text.Trim() != "&nbsp;") uplb1.Text = mygrid.Rows[_idx].Cells[8].Text;
            if (mygrid.Rows[_idx].Cells[10].Text.Trim() != "&nbsp;") uplb2.Text = mygrid.Rows[_idx].Cells[10].Text;
            if (mygrid.Rows[_idx].Cells[9].Text.Trim() != "&nbsp;") uplb3.Text = mygrid.Rows[_idx].Cells[9].Text;
            if (mygrid.Rows[_idx].Cells[11].Text.Trim() != "&nbsp;") uplb4.Text = mygrid.Rows[_idx].Cells[11].Text;
            upreff.Text = upreff.Text.Replace("&amp;", "&"); upzone.Text = upzone.Text.Replace("&amp;", "&"); upfloor.Text = upfloor.Text.Replace("&amp;", "&"); uploc.Text = uploc.Text.Replace("&amp;", "&"); uplb1.Text = uplb1.Text.Replace("&amp;", "&"); uplb2.Text = uplb2.Text.Replace("&amp;", "&"); uplb3.Text = uplb3.Text.Replace("&amp;", "&"); uplb4.Text = uplb4.Text.Replace("&amp;", "&");
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            {
                lb1.Text = lbl1.Text;
                lb2.Text = lbl2.Text;
                lb3.Text = lbl3.Text;
                lb4.Text = lbnum.Text;
            }
            else if ((string)Session["sch"] == "2")
            {
                lb1.Text = lbl1.Text;
                lb3.Text = lbl3.Text;
                uplb4.Visible = false;
                uplb2.Visible = false;

            }
            else if ((string)Session["sch"] == "3")
            {
                lb1.Text = lbl1.Text;
                lb2.Text = lbl2.Text; 
                lb3.Text = lbl3.Text;
                lb4.Visible = false; uplb4.Visible = false;

            }
            else if ((string)Session["sch"] == "4")
            {
                lb1.Text = lbl1.Text;
                lb2.Text = lbl2.Text;
                lb3.Text = lbl3.Text;
                lb4.Text = lbnum.Text;

            }
            else if ((string)Session["sch"] == "6")
            {
                lb1.Text = lbl1.Text;
                uplb2.Visible = false; uplb3.Visible = false;
                uplb4.Visible = false;

            }
            else if ((string)Session["sch"] == "7")
            {
                lb4.Text = lbnum.Text;
                lb1.Visible = false; uplb1.Visible = false; lb2.Visible = false; uplb2.Visible = false; lb3.Visible = false; uplb3.Visible = false;

            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17")
            {
                lb2.Text = lbl2.Text;
                lb3.Text = lbl3.Text;
                lb1.Visible = false; uplb1.Visible = false; lb4.Visible = false; uplb4.Visible = false;
            }
            else if ((string)Session["sch"] == "10")
            {
                lb4.Text = lbnum.Text;
                lb2.Text = "No.of Devices";
                lb1.Visible = false; uplb1.Visible = false; lb3.Visible = false; uplb3.Visible = false;

            }
            else if ((string)Session["sch"] == "16")
            {
                lb4.Text = lbnum.Text;
                lb2.Text = "No.of Devices";
                lb1.Visible = false; uplb1.Visible = false; lb3.Visible = false; uplb3.Visible = false;

            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Edit_Inidata(0);
            Load_Master();
            Load_Ini_Data();
            btnDummy_ModalPopupExtender.Hide();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Edit_Inidata(2);
            Load_Master();
            Load_Ini_Data();
            btnDummy_ModalPopupExtender.Hide();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
            Load_Ini_Data();
        }
        private void Edit_Inidata(int _mode)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = (string)Session["project"];
            _objcas.uid = (string)Session["uid"];
            _objcas.sys = Convert.ToInt32((string)Session["Sys"]);
            _objcas.reff = upreff.Text;
            _objcas.b_zone = upzone.Text;
            _objcas.cate = upcate.Text;
            _objcas.f_level = upfloor.Text;
            _objcas.seq_no =Convert.ToInt32(upseq.Text);
            _objcas.desc = txtdesc.Text;
            _objcas.loca = uploc.Text;
            _objcas.p_power_to = uplb1.Text;
            _objcas.fed_from = uplb3.Text;
            _objcas.sub_st = uplb2.Text;
            _objcas.s_c_m = txtdesc.Text;
            _objcas.dev1 = uplb4.Text;

            if ((string)Session["srv"] == "13")
                _objcas.dev2 = txtdesc.Text;
            else
                _objcas.dev2 = "0";
            _objcas.dev3 = "0";
            _objcas.mode = _mode;
            _objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objbll.Cassheet_Master(_objcas, _objdb);
        }
     

    }
}
