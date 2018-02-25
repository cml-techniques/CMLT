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

namespace CmlTechniques
{
    public partial class casintdata : System.Web.UI.Page
    {
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
                        output.Write(string.Format("<th align='center' colspan='{0}'>{1}</th>",
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

                //string _qry = Request.QueryString[0].ToString();
                //Session["sch"] = _qry;
                ////Session["srv"] = _qry.Substring(_qry.IndexOf("_S") + 2);
                //_Create_Cookies();
                //if ((string)Session["sch"] == "10")
                //{
                //    lbnum.Text = "DES.VOL (m" + "&sup3;" + "/s)";
                //}
                //else if ((string)Session["sch"] == "2")
                //    lbnum.Text = "DES.Flow rate(L/S)";
                //else if ((string)Session["sch"] == "3")
                //    lbnum.Text = "DES.VOL (I/s)";
                //else if ((string)Session["sch"] == "4")
                //    lbnum.Text = "NO. OF DEVICES";
                //else if ((string)Session["sch"] == "7")
                //{
                //    lbnum.Text = "";
                //    txtnoof.Enabled = false;
                //}
                //if ((string)Session["sch"] == "10")
                //    lbnum.Text = "No.of Circuits";
                settings();
                load_cas_sys();
                Load_Ini_Data();
                Merging();
                Session["filter"] = "no";
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _qry.Substring(_qry.IndexOf("_S") + 2) + "');", true);
                //GridViewHelper _help = new GridViewHelper(mygrid);
                //_help.RegisterGroup("Sys_name", true, true);
                //_help.ApplyGroupSort();

            }
        }
        protected void settings()
        {
            if ((string)Session["sch"] == "5")
            {
                lbnum.Text = "No.of Circuits";
                lbl1.Text = "PR.POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
            }
            else if ((string)Session["sch"] == "2")
            {
                //lbnum.Text = "";
                //lbnum.Enabled = false;
                lbl1.Text = "PR.POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";
                txtnoof.Enabled = false;
                txtnoof.BackColor = System.Drawing.Color.Gray;
            }
            else if ((string)Session["sch"] == "3")
            {
                lbl1.Text = "PR.POWER TO";
                lbl2.Text = "AREA";
                lbl3.Text = "FED FROM";
                txtnoof.Enabled = false;
                txtnoof.BackColor = System.Drawing.Color.Gray;
            }
            else if ((string)Session["sch"] == "4")
            {
                lbnum.Text = "No.of Circuits";
                lbl1.Text = "PR.POWER TO";
                lbl2.Text = "SUBSTATION";
                lbl3.Text = "FED FROM";              
            }
            else if ((string)Session["sch"] == "6")
            {
                lbnum.Text = "";
                lbl1.Text = "PR.EARTHING TO";
                lbl2.Text = "";
                lbl3.Text = "";
                txtfedfr.Enabled = false;
                txtdesc.Enabled = false;
                txtfedfr.BackColor = System.Drawing.Color.Gray;
                txtdesc.BackColor = System.Drawing.Color.Gray;
                txtnoof.Enabled = false;
                txtnoof.BackColor = System.Drawing.Color.Gray;
            }
            else if ((string)Session["sch"] == "7")
            {
                lbnum.Text = "No. of Emergency Lights";
                lbl1.Text = "";
                lbl3.Text = "";
                txtfedfr.Enabled = false;
                txtpprovideto.Enabled = false;
                txtdesc.Enabled = false;
                txtfedfr.BackColor = System.Drawing.Color.Gray;
                txtpprovideto.BackColor = System.Drawing.Color.Gray;
                txtdesc.BackColor = System.Drawing.Color.Gray;
                lbl2.Text = "";
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"]=="9" || (string)Session["sch"]=="17")
            {
                lbl1.Text = "";
                lbl2.Text = "DESCRIPTION";
                lbl3.Text = "FED FROM";
                txtpprovideto.Enabled = false;
                txtpprovideto.BackColor = System.Drawing.Color.Gray;
                txtnoof.Enabled = false;
                txtnoof.BackColor = System.Drawing.Color.Gray;

            }
            else if ((string)Session["sch"] == "10")
            {
                lbl1.Text = "";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "";
                lbnum.Text = "NO.OF INTERFACES";
                txtpprovideto.Enabled = false;
                txtpprovideto.BackColor = System.Drawing.Color.Gray;
                txtfedfr.Enabled = false;
                txtfedfr.BackColor = System.Drawing.Color.Gray;

            }
            else if ((string)Session["sch"] == "16")
            {
                lbl1.Text = "SYS. CONTROLLED/MONITORED";
                lbl2.Text = "NO.OF DEVICES";
                lbl3.Text = "FED FROM";
                lbnum.Text = "NO.OF INTERFACES";
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
        protected void Load_Ini_Data()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code =(string)Session["project"];
            //info.AddMergedColumns(new int[] { 2,3, 4, 5 }, "Asset Code");
            mygrid.DataSource = _objbll.Load_casMain_Edit(_objcas,_objdb);
            mygrid.DataBind();
            //for (int i = 0; i <= mygrid.Rows.Count - 1; i++)
            //{
            //    mygrid.Rows[i].Cells[0].Text = (i + 1).ToString();
            //}
            GridViewHelper _help = new GridViewHelper(mygrid);
            _help.RegisterGroup("Sys_name", true, true);
            _help.GroupHeader += new GroupEvent(helper_GroupHeader);
            _help.ApplyGroupSort();
        }
        protected void Merging()
        {
            info.AddMergedColumns(new int[] { 2, 3, 4, 5 }, "Asset Code");
        }
        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "Sys_name")
            {
                string _group=row.Cells[0].Text;
                row.BackColor =System.Drawing.Color.LightGray;
                row.Cells[0].Text = "&nbsp;&nbsp;" + _group;
            }
            
        } 
        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "--Package--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Package');", true);
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
            Load_Ini_Data();
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
            _objcas.seq_no =Convert.ToInt32(txtseq.Text);
            _objcas.desc = txtdesc.Text;
            _objcas.loca = txtloca.Text;
            _objcas.p_power_to = txtpprovideto.Text;
            _objcas.fed_from = txtfedfr.Text;
            _objcas.sub_st = txtdesc.Text;
            _objcas.s_c_m = txtdesc.Text;
            _objcas.dev1 = txtnoof.Text;

            if ((string)Session["sch"] == "10" || (string)Session["sch"] == "16")
                _objcas.dev2 = txtdesc.Text;
            else
                _objcas.dev2 = "0";
            _objcas.dev3 = "0";
            _objcas.mode = 1;
            _objcas.cas_id = 0;
            _objbll.Cassheet_Master(_objcas,_objdb);

        }
        protected void add_asset_code(string cate, string zone, string level, string seq)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_clsassetcode _objast = new _clsassetcode();
            //_objast.cate = cate;
            //_objast.b_zone = zone;
            //_objast.f_level = level;
            //_objast.seq_no = seq;
            //_objbll.add_asset_code(_objast);
        }
        protected void load_cas_sys()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            _objcls.sch = Convert.ToInt32((string)Session["sch"]);
            DataTable _dt0=_objbll.Load_cas_sys(_objcls,_objdb);
            DataTable _dt1 = new DataTable();
            _dt1.Columns.Add("_id");
            _dt1.Columns.Add("_name");
            var _List = from o in _dt0.AsEnumerable()
                        where o.Field<string>(3)==(string)Session["project"]
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
            drpackage.DataValueField = "_id" ;
            drpackage.DataBind();
            drpackage.Items.Insert(0,"--Package--");
        }

        protected void drpackage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text != "--Package--") 
                txtcate.Text = drpackage.SelectedItem.Value.Substring(drpackage.SelectedItem.Value.IndexOf("_C")+2);
            //Load_Ini_Data();
            //GridViewHelper _help = new GridViewHelper(mygrid);
            //_help.RegisterGroup("sys_name", true, true);
            //_help.ApplyGroupSort();
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

        protected void mygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            mygrid.PageIndex = e.NewPageIndex;
            mygrid.DataBind();
 
        }

        protected void mygrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = mygrid.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                //dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                dataView.Sort = "Sys_id" + " " + ConvertSortDirectionToSql(e.SortDirection);
                mygrid.DataSource = dataView;
                mygrid.DataBind();
            }
 

        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if ((string)Session["sch"] == "1")
            {
                // e.Row.Cells[11].Visible = true;
                //e.Row.Cells[10].Visible = false;
                //e.Row.Cells[8].Visible = false;
                mygrid.Columns[10].HeaderText = lbnum.Text;
            }
            else if ((string)Session["sch"] == "2")
            {
                //e.Row.Cells[11].Visible = true;
                e.Row.Cells[10].Visible = false;
                mygrid.Columns[9].HeaderText = "Substation";
                e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "3")
            {
                //e.Row.Cells[9].Visible = false;
                mygrid.Columns[9].HeaderText = "Area";
                e.Row.Cells[10].Visible = false;
                //e.Row.Cells[7].Visible = false;
            }
            else if ((string)Session["sch"] == "4")
            {
                mygrid.Columns[10].HeaderText = lbnum.Text;
            }
            else if ((string)Session["sch"] == "6")
            {
                e.Row.Cells[8].Visible = false;
                mygrid.Columns[7].HeaderText = "Provides Earthing to";
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
               
            }
            else if ((string)Session["sch"] == "7")
            {
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[9].Visible = false;
                mygrid.Columns[10].HeaderText = "No. of Emergency Lights";
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17")
            {
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[10].Visible = false;
                mygrid.Columns[9].HeaderText = "Description";
            }
            else if ((string)Session["sch"] == "10" )
            {
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[8].Visible = false;
                mygrid.Columns[9].HeaderText = "No.of Devices";
                mygrid.Columns[10].HeaderText = "No.of Interfaces";
            }
            else if ((string)Session["sch"] == "16")
            {
                mygrid.Columns[7].HeaderText = "Sys. Controlled/Monitored";
                mygrid.Columns[8].HeaderText = "Fed From";
                mygrid.Columns[9].HeaderText = "No.of Points";
                mygrid.Columns[10].HeaderText = "No.of Interfaces";
            }
            
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[12].Visible = false;

            //mygrid.Columns[10].HeaderText = lbnum.Text;
            if (e.Row.Cells[0].Text != "") return;
            e.Row.Cells[0].Text = (e.Row.DataItemIndex+1).ToString();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((string)Session["filter"] == "no")
                Load_Ini_Data();
            else if ((string)Session["filter"] == "yes")
                Filtering();
        }

        protected void mygrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["casid"] = mygrid.Rows[e.RowIndex].Cells[11].Text;
            Session["idx"] = e.RowIndex.ToString();
            arrange_edit();
            btnDummy_ModalPopupExtender.Show();
           // Load_Ini_Data();
        }
        protected void arrange_edit()
        {
            int _idx = Convert.ToInt32((string)Session["idx"]);
            if (mygrid.Rows[_idx].Cells[12].Text.Trim() != "&nbsp;") upreff.Text = mygrid.Rows[_idx].Cells[12].Text;
            if (mygrid.Rows[_idx].Cells[2].Text.Trim() != "&nbsp;") upzone.Text = mygrid.Rows[_idx].Cells[2].Text;
            if (mygrid.Rows[_idx].Cells[3].Text.Trim() != "&nbsp;") upcate.Text = mygrid.Rows[_idx].Cells[3].Text;
            if (mygrid.Rows[_idx].Cells[4].Text.Trim() != "&nbsp;") upfloor.Text = mygrid.Rows[_idx].Cells[4].Text;
            if (mygrid.Rows[_idx].Cells[5].Text.Trim() != "&nbsp;") upseq.Text = mygrid.Rows[_idx].Cells[5].Text;
            if (mygrid.Rows[_idx].Cells[6].Text.Trim() != "&nbsp;") uploc.Text = mygrid.Rows[_idx].Cells[6].Text;
            if (mygrid.Rows[_idx].Cells[7].Text.Trim() != "&nbsp;") uplb1.Text = mygrid.Rows[_idx].Cells[7].Text;
            if (mygrid.Rows[_idx].Cells[9].Text.Trim() != "&nbsp;") uplb2.Text = mygrid.Rows[_idx].Cells[9].Text;
            if (mygrid.Rows[_idx].Cells[8].Text.Trim() != "&nbsp;") uplb3.Text = mygrid.Rows[_idx].Cells[8].Text;
            if (mygrid.Rows[_idx].Cells[10].Text.Trim() != "&nbsp;") uplb4.Text = mygrid.Rows[_idx].Cells[10].Text;
            if ((string)Session["sch"] == "1" || (string)Session["sch"]=="4")
            {
                lb1.Text = lbl1.Text;
                lb2.Text = lbl2.Text;
                lb3.Text = lbl3.Text;
                lb4.Text = lbnum.Text;
            }
            else if ((string)Session["sch"] == "2")
            {
                lb2.Text = lbl2.Text; ; lb3.Text = lbl3.Text;
                lb1.Visible = false; uplb1.Visible = false; lb4.Visible = false; uplb4.Visible = false;

            }
            else if ((string)Session["sch"] == "3")
            {
                lb1.Text = lbl1.Text; ; lb2.Text = lbl2.Text; lb3.Text = lbl3.Text;
               lb4.Visible = false; uplb4.Visible = false;

            }
            else if ((string)Session["sch"] == "3")
            {
                lb1.Text = lbl1.Text; ;
                lb2.Visible = false; uplb2.Visible = false;
                lb3.Visible = false; uplb4.Visible = false;
                lb4.Visible = false; uplb4.Visible = false;

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

        protected void Edit_Inidata()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = (string)Session["project"];
            _objcas.uid = (string)Session["uid"];
            _objcas.sys = 0;
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
            _objcas.mode = 0;
            _objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objbll.Cassheet_Master(_objcas,_objdb);
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Edit_Inidata();
            btnDummy_ModalPopupExtender.Hide();
            
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.c_s_id = 0;
            _objcas.prj_code = (string)Session["project"];
            _objcas.uid = (string)Session["uid"];
            _objcas.sys = 0;
            _objcas.reff = upreff.Text;
            _objcas.b_zone = upzone.Text;
            _objcas.cate = upcate.Text;
            _objcas.f_level = upfloor.Text;
            _objcas.seq_no =Convert.ToInt32(upseq.Text);
            _objcas.desc = txtdesc.Text;
            _objcas.loca = uploc.Text;
            _objcas.p_power_to = txtpprovideto.Text;
            _objcas.fed_from = txtfedfr.Text;
            _objcas.sub_st = txtdesc.Text;
            _objcas.s_c_m = txtdesc.Text;
            _objcas.dev1 = lb4.Text;

            if ((string)Session["srv"] == "13")
                _objcas.dev2 = txtdesc.Text;
            else
                _objcas.dev2 = "0";
            _objcas.dev3 = "0";
            _objcas.mode = 2;
            _objcas.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objbll.Cassheet_Master(_objcas,_objdb);
            btnDummy_ModalPopupExtender.Hide();
            
        }

        protected void mygrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader);
        }

        protected void drfilterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_filter_element();
        }
        protected void load_filter_element()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code =(string)Session["project"];
            _objcas.filter = Convert.ToInt32(drfilterby.SelectedItem.Value);
            //DataTable  _dtable=_objbll.Load_filter_element(_objcas,_objdb);
            drfilter.DataSource = _objbll.Load_filter_element(_objcas,_objdb);
            if (drfilterby.SelectedItem.Value == "0")
            {
                drfilter.DataTextField = "Sys_name";
                drfilter.DataValueField = "Sys_id";
            }
            else if (drfilterby.SelectedItem.Value == "1")
            {
                drfilter.DataTextField = "F_lvl";
                drfilter.DataValueField = "F_lvl";
            }
            drfilter.DataBind();
            //var _result = from o in _dtable.AsEnumerable()
            //              select o;
            //foreach (var row in _result)
            //{
            //    ListItem _lst = new ListItem();
            //    if (drfilterby.SelectedItem.Value == "0")
            //    {
            //        _lst.Text = row[3].ToString();
            //        _lst.Value = row[2].ToString();

            //    }
            //    drfilter.Items.Add(_lst);
            //}

        }
        protected void Filtering()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            _objcas.filter = Convert.ToInt32(drfilterby.SelectedItem.Value);
            _objcas.element = drfilter.SelectedItem.Text;
            //info.AddMergedColumns(new int[] { 2, 3, 4, 5 }, "Asset Code");
            mygrid.DataSource=_objbll.Filtering(_objcas,_objdb);
            mygrid.DataBind();
            //for (int i = 0; i <= mygrid.Rows.Count - 1; i++)
            //{
            //    mygrid.Rows[i].Cells[0].Text = (i + 1).ToString();
            //}
            GridViewHelper _help = new GridViewHelper(mygrid);
            _help.RegisterGroup("Sys_name", true, true);
            _help.GroupHeader += new GroupEvent(helper_GroupHeader);
            _help.ApplyGroupSort();
        }

        protected void btnfilter_Click(object sender, EventArgs e)
        {
            Session["filter"] = "yes";
            Filtering();
        }

       

        protected void btnfcancel_Click(object sender, EventArgs e)
        {
            Session["filter"] = "no";
            Load_Ini_Data();
        }
        
    }
}
