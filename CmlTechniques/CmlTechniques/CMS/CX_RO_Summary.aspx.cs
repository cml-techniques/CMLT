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
using System.Collections.Generic;

namespace CmlTechniques.CMS
{
    public partial class CX_RO_Summary : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Generate_Summary();
                Head_Merging();
            }
        }
        private void Head_Merging()
        {
            info.AddMergedColumns(new int[] { 7,8,9,10,11 }, "Responsibility");
        }
        private void Generate_Summary()
        {
            DataTable _dtoutput = new DataTable();
            _dtoutput.Columns.Add("building", typeof(string));
            _dtoutput.Columns.Add("tissued",typeof(string));
            _dtoutput.Columns.Add("topen",typeof(string));
            _dtoutput.Columns.Add("res1",typeof(string));
            _dtoutput.Columns.Add("res2",typeof(string));
            _dtoutput.Columns.Add("res3",typeof(string));
            _dtoutput.Columns.Add("res4",typeof(string));
            _dtoutput.Columns.Add("res5",typeof(string));
            _dtoutput.Columns.Add("close", typeof(string));
            _dtoutput.Columns.Add("open", typeof(string));
            _dtoutput.Columns.Add("comment", typeof(string));
            _dtoutput.Columns.Add("id", typeof(string));
            var _dv = (DataView)ObjectDataSource1.Select();
            DataTable _dtemp = _dv.ToTable();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_CCAD";
            DataTable _dtbld = _objbll.Load_CX_Buildings(_objdb);
            //var distinctRows = (from DataRow dRow in _dtemp.Rows
            //                    select new { col1 = dRow["Location"] }).Distinct();
            var distinctRows = from _bldg in _dtbld.AsEnumerable()
                               select _bldg;
            foreach (var row in distinctRows)
            {
                //if (row.col1.ToString() != "N/A" && row.col1.ToString() != "")
                //{
                int _total_issued = 0;
                int _total_closed = 0;
                int _res1 = 0;
                int _res2 = 0;
                int _res3 = 0;
                int _res4 = 0;
                int _res5 = 0;
                var _result = from _data in _dtemp.AsEnumerable()
                              where _data.Field<string>("Location") == row["cx_bldg_name"].ToString()
                              select _data;
                foreach (var _row in _result)
                {
                    _total_issued += 1;
                    if (_row["r_status"].ToString() == "OPEN")
                    {
                        _total_closed += 1;
                        if (_row["responsible"].ToString().Contains("AECOM") == true)
                            _res2 += 1;
                        else if (_row["responsible"].ToString().Contains("JCI") == true)
                            _res1 += 1;
                        else if (_row["responsible"].ToString().Contains("CML") == true)
                            _res3 += 1;
                        else if (_row["responsible"].ToString().Contains("CCAD") == true)
                            _res4 += 5;
                        else
                            _res4 += 1;
                    }
                }
                if (_total_issued != 0)
                {
                    DataRow _drow = _dtoutput.NewRow();
                    _drow[0] = row["cx_bldg_name"].ToString();
                    _drow[1] = _total_issued.ToString();
                    _drow[2] = _total_closed.ToString();
                    _drow[3] = _res1.ToString();
                    _drow[4] = _res2.ToString();
                    _drow[5] = _res3.ToString();
                    _drow[6] = _res4.ToString();
                    _drow[7] = _res5.ToString();
                    _drow[8] = row["hi_p_closed"].ToString();
                    _drow[9] = row["hi_p_open"].ToString();
                    _drow[10] = row["comments"].ToString();
                    _drow[11] = row["cx_bldg_id"].ToString();
                    _dtoutput.Rows.Add(_drow);
                }
                //}
            }
            mygrid.DataSource=_dtoutput;
            mygrid.DataBind();
        }
        int _issues = 0;
        int _open = 0;
        int _res1_sum = 0;
        int _res2_sum = 0;
        int _res3_sum = 0;
        int _res4_sum = 0;
        int _res5_sum = 0;
        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[13].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                _issues += Convert.ToInt32(e.Row.Cells[3].Text);
                _open += Convert.ToInt32(e.Row.Cells[4].Text);
                _res1_sum += Convert.ToInt32(e.Row.Cells[7].Text);
                _res2_sum += Convert.ToInt32(e.Row.Cells[8].Text);
                _res3_sum += Convert.ToInt32(e.Row.Cells[9].Text);
                _res4_sum += Convert.ToInt32(e.Row.Cells[10].Text);
                _res5_sum += Convert.ToInt32(e.Row.Cells[11].Text);
                e.Row.Cells[2].Text = "0";
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[3].Text = _issues.ToString();
                e.Row.Cells[4].Text = _open.ToString();
                e.Row.Cells[7].Text = _res1_sum.ToString();
                e.Row.Cells[8].Text = _res2_sum.ToString();
                e.Row.Cells[9].Text = _res3_sum.ToString();
                e.Row.Cells[10].Text = _res4_sum.ToString();
                e.Row.Cells[11].Text = _res5_sum.ToString();
            }
        }

        protected void mygrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader);
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
            //mygrid.HeaderStyle.AddAttributesToRender(output);
            //start the second row
            output.RenderBeginTag("tr");

            //render the second row (only the merged columns)
            for (int i = 0; i < info.MergedColumns.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[info.MergedColumns[i]];
                cell.RenderControl(output);
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_CCAD";
            _clscassheet _objcls = new _clscassheet();
            _objcls.caction = txt_closed.Text;
            _objcls.faction = txt_open.Text;
            _objcls.rstatus = txt_comments.Text;
            foreach (GridViewRow _drows in mygrid.Rows)
            {
                CheckBox _chk = (CheckBox)_drows.FindControl("chkselect");
                if (_chk.Checked == true)
                {
                    _objcls.c_s_id = Convert.ToInt32(_drows.Cells[13].Text);
                    _objbll.update_cx_summary(_objcls, _objdb);
                }
            }
            ObjectDataSource1.Select();
            Generate_Summary();
            btnDummy_ModalPopupExtender1.Hide();
            
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= mygrid.Rows.Count - 1; i++)
            {
                CheckBox checkbox = (CheckBox)mygrid.Rows[i].FindControl("chkselect");
                if (checkbox.Checked == true)
                {
                    count += 1;
                }

            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count>= 1)
            {
                btnDummy_ModalPopupExtender1.Show();

            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
        }
        private bool DateValidation(string dateString)
        {
            DateTime dateValue;
            string[] format = new string[] { "dd/MM/yyyy" };
            if (DateTime.TryParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dateValue))
                return true;
            else
                return false;

        }
        protected void btnview_Click(object sender, EventArgs e)
        {
            if (DateValidation(txt_date.Text) == false) return;
            int _total=0;
            foreach (GridViewRow _drow in mygrid.Rows)
            {
                int _issues=Get_IssuesRaised(_drow.Cells[1].Text);
                _drow.Cells[2].Text =_issues.ToString();
                _total+=_issues;
            }
            mygrid.FooterRow.Cells[2].Text = _total.ToString();
        }
        private int Get_IssuesRaised(string _bldg_name)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_CCAD";
            _clscassheet _objcls = new _clscassheet();
            _objcls.loca = _bldg_name;
            _objcls.dt_rep = txt_date.Text;
            return _objbll.Get_Cx_IssuesRaised(_objcls, _objdb);
        }
        private void Insert_Report()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _objbll.Clear_CX_SO_Summary_rpt(_objdb);
            _clscassheet _objcls = new _clscassheet();
            foreach (GridViewRow _drow in mygrid.Rows)
            {
                _objcls.loca = _drow.Cells[1].Text;
                _objcls.iss_raised = Convert.ToInt16(_drow.Cells[2].Text);
                _objcls.iss_period = txt_date.Text;
                _objcls.iss_total = Convert.ToInt32(_drow.Cells[3].Text);
                _objcls.iss_open = Convert.ToInt32(_drow.Cells[4].Text);
                if (_drow.Cells[5].Text != "&nbsp;")
                    _objcls.hi_p_close = _drow.Cells[5].Text;
                else
                    _objcls.hi_p_close = "";
                if (_drow.Cells[6].Text != "&nbsp;")
                    _objcls.hi_p_open = _drow.Cells[6].Text.Trim();
                else
                    _objcls.hi_p_open = "";
                _objcls.resp1 = Convert.ToInt32(_drow.Cells[7].Text);
                _objcls.resp2 = Convert.ToInt32(_drow.Cells[8].Text);
                _objcls.resp3 = Convert.ToInt32(_drow.Cells[9].Text);
                _objcls.resp4 = Convert.ToInt32(_drow.Cells[10].Text);
                _objcls.resp5 = Convert.ToInt32(_drow.Cells[11].Text);
                if (_drow.Cells[12].Text != "&nbsp;")
                    _objcls.comm = _drow.Cells[12].Text.Trim();
                else
                    _objcls.comm = "";
                _objbll.Insert_CX_RO_Summary_rpt(_objcls, _objdb);

            }
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            Insert_Report();
            Response.Redirect("CX_Issue_Log_Summary.aspx?id=3");
        }
    }
}
