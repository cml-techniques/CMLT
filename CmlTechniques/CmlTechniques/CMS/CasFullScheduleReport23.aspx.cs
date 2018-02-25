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
using BusinessLogic;
using App_Properties;

namespace CmlTechniques.CMS
{
    public partial class CasFullScheduleReport23 : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtresult;
        public static DataTable _summary;
        public bool _exp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv', 'mymaster','HeaderDiv');</script>");
               string _prm = Request.QueryString[0].ToString();

              


                lblprj.Text = _prm;
                Load_Master();
                Load_Details();

                Hide_Details();
                Generate_Summary();
                //Head_Merging();
            }
            //Load_Summary();
            _exp = false; ;
            //lblhead.Text = "hhh";

            //btncollapse_Click(sender, e);
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
        
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 23;
            _objcas.prj_code = lblprj.Text;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            _dtresult = _dtMaster;
            // _dtfilter = _dtresult;
        }
        private void Load_Details()
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
        protected void Load_Summary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            // info1.AddMergedColumns(new int[] { 3, 4 }, "PANEL & CABLE TEST PROGRESS");
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            mygridsumm.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            mygridsumm.DataBind();
        }
        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "sys_name")
            {
                row.BackColor = System.Drawing.Color.FromName("#b1dff6");
                row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
                row.Height = 30;
            }

        }
        private void helper_GroupHeader1(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "F_lvl")
            {
                row.BackColor = System.Drawing.Color.LightGray;
                row.Cells[1].Text = "&nbsp;&nbsp;" + row.Cells[1].Text;
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
        protected void mygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //mygrid.PageIndex = e.NewPageIndex;
            //mygrid.DataBind();
        }
        protected void mygrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            //DataTable dataTable = mygrid.DataSource as DataTable;

            //if (dataTable != null)
            //{
            //    DataView dataView = new DataView(dataTable);
            //    dataView.Sort = "Sys_id" + " " + ConvertSortDirectionToSql(e.SortDirection);

            //    mygrid.DataSource = dataView;
            //    mygrid.DataBind();
            //}
        }
        protected void export_Click(object sender, EventArgs e)
        {
            string html = hdnInnerHtml.Value;
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            Response.Clear();
            Response.AppendHeader("content-disposition", "attachment;filename=FileName.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            this.EnableViewState = false;
            Response.Write("\r\n");
            Response.Write(html);
            Response.End();

        }
        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            //    e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

            //}
            if (e.Row.Cells[0].Text != "") return;
            e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
        }
        protected void mygrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //    e.Row.SetRenderMethodDelegate(RenderHeader);
        }
        decimal _qty = 0;
        decimal _tested1 = 0;
        decimal _tested2 = 0;
        decimal _total = 0;
        decimal _count = 0;
        protected void mygridsumm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
                _qty += Convert.ToDecimal(e.Row.Cells[2].Text);
                _tested1 += Convert.ToDecimal(e.Row.Cells[3].Text);
                _tested2 += Convert.ToDecimal(e.Row.Cells[4].Text);

                e.Row.Cells[4].Text =  e.Row.Cells[4].Text+ '%';
               _count += 1;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Overall";
                e.Row.Cells[2].Text = _qty.ToString();

                e.Row.Cells[3].Text = (Decimal.Round((_tested1 / _count), 0, MidpointRounding.AwayFromZero)).ToString() + '%';
                e.Row.Cells[4].Text = (Decimal.Round((_tested2 / _count), 0, MidpointRounding.AwayFromZero)).ToString() + '%';

            }
        }
        protected void mygridsumm_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //    e.Row.SetRenderMethodDelegate(RenderHeader1);
        }
        protected void print_Click(object sender, EventArgs e)
        {
            //Insert_Summary();
            // string _path = "Cas_Report.aspx?id=2_P" + lblprj.Text + "_B" + drbuilding.SelectedItem.Value + "_F" + drflevel.SelectedItem.Value + "_C" + drcategory.SelectedItem.Value + "_D" + drfed.SelectedItem.Value + "_Z1";
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
        }

        protected void mymaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label _sys_id = (Label)e.Row.FindControl("lbSys_Id");
                DataTable _dtdetails = new DataTable();
                var _details = from _data in _dtresult.AsEnumerable()
                               where _data.Field<int>("Sys_Id") == Convert.ToInt32(_sys_id.Text)
                               select _data;
                _dtdetails = _details.Any() ? _details.CopyToDataTable() : _dtMaster.Clone();
                GridView _mydetails = (GridView)e.Row.FindControl("mydetails");
                _mydetails.DataSource = _dtdetails;
                _mydetails.DataBind();
            }
        }
        private string SeqNo(string No)
        {
            string _nNo = No;
            if (No.Length > 3)
                _nNo = No.Substring(0, 3);
            else
            {
                for (int i = 0; i < (3 - No.Length); i++)
                {
                    _nNo = "0" + _nNo;
                }
            }
            return _nNo;
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
            _exp = true;
        }
        protected void mydetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void mydetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            }
}

        private void Generate_Summary()
        {
            try
            {
                DataTable _dtsummary = new DataTable();
                _dtsummary.Columns.Add("CATE_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Cate_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    int count1 = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        count += 1;
                    }
                    decimal _per1 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count1)*100), 0, MidpointRounding.AwayFromZero);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _p1;
                    _drow[3] = _per1;
                    _dtsummary.Rows.Add(_drow);
                }
                mygridsumm.DataSource = _dtsummary;
                mygridsumm.DataBind();
                _summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }



        protected void btnexpand_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = true;
                _btn.Text = "-";
            }
        }

        protected void btncollapse_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= mymaster.Rows.Count - 1; i++)
            {
                GridView _mydetails = (GridView)mymaster.Rows[i].FindControl("mydetails");
                Button _btn = (Button)mymaster.Rows[i].FindControl("Button1");
                _mydetails.Visible = false;
                _btn.Text = "+";
            }
        }
    }
}

