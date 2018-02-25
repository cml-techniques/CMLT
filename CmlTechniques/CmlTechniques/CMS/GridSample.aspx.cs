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

namespace CmlTechniques.CMS
{
    public partial class GridSample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv', 'GridView1','HeaderDiv');</script>");
                Load_FilterElements();
                Session["sdoc"] = "-show all-";
                Session["base"] = "-show all-";
                Session["type"] = "-show all-";
                Session["loc"] = "-show all-";
                Session["drep"] = "-show all-";
                Session["impact"] = "-show all-";
                Session["prob"] = "-show all-";
                Session["time"] = "-show all-";
                Session["srep"] = "-show all-";
                Session["rstat"] = "-show all-";
                Session["f1"] = "false";
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[23].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[1].Text = (e.Row.RowIndex + 1).ToString();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("CXIssues_Basic.aspx?id=0");
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string _path = "CX_Issue_Log_Summary.aspx?id=2";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
        }
        private void Load_FilterElements()
        {
            chkloc.Items.Clear();
            chkstatus.Items.Clear();
            chksdoc.Items.Clear();
            chkbase.Items.Clear();
            chk_type.Items.Clear();
            var _dv = (DataView)ObjectDataSource1.Select();
            DataTable _dtemp = _dv.ToTable();
            var _sdoc = (from DataRow dRow in _dtemp.Rows
                          orderby dRow["source_doc"]
                          select new { col1 = dRow["source_doc"] }).Distinct();
            foreach (var row in _sdoc)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                //drsdoc.Items.Add(_itm);
                chksdoc.Items.Add(_itm);
            }
          // drsdoc.DataBind();
           chksdoc.DataBind();
           chksdoc.Items.Insert(0, "All");
            var _base = (from DataRow dRow in _dtemp.Rows
                         orderby dRow["Discipline"]
                         select new { col1 = dRow["Discipline"] }).Distinct();
            foreach (var row in _base)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                chkbase.Items.Add(_itm);
            }
            chkbase.DataBind();
            chkbase.Items.Insert(0, "All");
            var _type = (from DataRow dRow in _dtemp.Rows
                         orderby dRow["issue_type"]
                         select new { col1 = dRow["issue_type"] }).Distinct();
            foreach (var row in _type)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                //drtype.Items.Add(_itm);
                chk_type.Items.Add(_itm);
            }
            //drtype.DataBind();
            chk_type.DataBind();
            chk_type.Items.Insert(0, "All");
            var _loc = (from DataRow dRow in _dtemp.Rows
                        orderby dRow["location"]
                        select new { col1 = dRow["location"] }).Distinct();
            foreach (var row in _loc)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
               chkloc.Items.Add(_itm);
            }
            chkloc.DataBind();
            chkloc.Items.Insert(0, "All");
            //var _drep = (from DataRow dRow in _dtemp.Rows
            //             orderby dRow["date_rep"]
            //             select new { col1 = dRow["date_rep"] }).Distinct();
            //foreach (var row in _drep)
            //{
            //    ListItem _itm = new ListItem();
            //    _itm.Text = row.col1.ToString();
            //    _itm.Value = row.col1.ToString();
            //    drdrep.Items.Add(_itm);
            //}
            //drdrep.DataBind();
            //var _impact = (from DataRow dRow in _dtemp.Rows
            //               orderby dRow["impact"]
            //               select new { col1 = dRow["impact"] }).Distinct();
            //foreach (var row in _impact)
            //{
            //    ListItem _itm = new ListItem();
            //    _itm.Text = row.col1.ToString();
            //    _itm.Value = row.col1.ToString();
            //    drimpact.Items.Add(_itm);
            //}
            //drimpact.DataBind();
            //var _prob = (from DataRow dRow in _dtemp.Rows
            //             orderby dRow["probability"]
            //             select new { col1 = dRow["probability"] }).Distinct();
            //foreach (var row in _prob)
            //{
            //    ListItem _itm = new ListItem();
            //    _itm.Text = row.col1.ToString();
            //    _itm.Value = row.col1.ToString();
            //    drprob.Items.Add(_itm);
            //}
            //drprob.DataBind();
            //var _tline = (from DataRow dRow in _dtemp.Rows
            //            orderby dRow["timeline"]
            //            select new { col1 = dRow["timeline"] }).Distinct();
            //foreach (var row in _tline)
            //{
            //    ListItem _itm = new ListItem();
            //    _itm.Text = row.col1.ToString();
            //    _itm.Value = row.col1.ToString();
            //    drtime.Items.Add(_itm);
            //}
            //drtime.DataBind();
            //var _srep = (from DataRow dRow in _dtemp.Rows
            //             orderby dRow["resp_status"]
            //             select new { col1 = dRow["resp_status"] }).Distinct();
            //foreach (var row in _srep)
            //{
            //    ListItem _itm = new ListItem();
            //    _itm.Text = row.col1.ToString();
            //    _itm.Value = row.col1.ToString();
            //    drsrep.Items.Add(_itm);
            //}
            //drsrep.DataBind();
            var _rstat = (from DataRow dRow in _dtemp.Rows
                         orderby dRow["r_status"]
                         select new { col1 = dRow["r_status"] }).Distinct();
            foreach (var row in _rstat)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                chkstatus.Items.Add(_itm);
            }
            chkstatus.DataBind();
            chkstatus.Items.Insert(0, "All");
        }
       

        protected void btnedit_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox checkbox = (CheckBox)GridView1.Rows[i].FindControl("chk");
                if (checkbox.Checked == true)
                {
                    count += 1;
                    Session["cxid"] = GridView1.Rows[i].Cells[23].Text;
                }

            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count > 1) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
            else if (count == 1)
            {
                Response.Redirect("CxIssues_Basic.aspx?id=" + (string)Session["cxid"]);

            }
        }
        protected void btnapply_Click(object sender, EventArgs e)
        {
            MultiFilter();
        }
        protected void btnapply1_Click(object sender, EventArgs e)
        {
            MultiFilter1();
        }
        protected void btnapply2_Click(object sender, EventArgs e)
        {
            MultiFilter2();
        }
        protected void btnapply3_Click(object sender, EventArgs e)
        {
            MultiFilter3();
        }
        protected void btnapply4_Click(object sender, EventArgs e)
        {
            MultiFilter4();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
           // popup1.Cancel();
           // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
        }
        protected void btncancel1_Click(object sender, EventArgs e)
        {
            // popup1.Cancel();
            // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //if ((string)Session["f1"] == "false")
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>Reposition();</script>");
            //    Button1_ModalPopupExtender.Show();
            //    Session["f1"] = "true";
            //}
            //else
            //{
            //    Button1_ModalPopupExtender.Hide();
            //    Session["f1"] = "false";
            //}
            
        }
        private void MultiFilter()
        {
            var sbFilter = new System.Text.StringBuilder(500);
            ObjectDataSource1.FilterExpression = null;
            int _count = 0;
            foreach (ListItem _lst in chksdoc.Items)
            {
                if (_lst.Selected == true)
                {
                    if (_lst.Text == "All")
                    {
                        lblfilter_query.Text = "";
                        ObjectDataSource1.FilterExpression = null;
                        GridView1.DataBind();
                        Load_FilterElements();
                        return;
                    }
                    else
                    {
                        if (lblfilter_query.Text.Length <= 0)
                        {
                            if (_count == 0)
                                sbFilter.Append("(source_doc ='" + _lst.Text + "'");
                            else
                                sbFilter.Append(" OR source_doc ='" + _lst.Text + "'");
                        }
                        else
                        {
                            if (_count == 0)
                                sbFilter.Append(" AND (source_doc ='" + _lst.Text + "'");
                            else
                                sbFilter.Append(" OR source_doc ='" + _lst.Text + "'");
                        }
                        _count += 1;
                    }
                }
            }
            if (sbFilter.ToString().IndexOf("(") >= 0)
                sbFilter.Append(")");
            lblfilter_query.Text = lblfilter_query.Text + sbFilter;
            ObjectDataSource1.FilterExpression = lblfilter_query.Text;
            GridView1.DataBind();
            Load_FilterElements();
        }
        private void MultiFilter1()
        {
            var sbFilter = new System.Text.StringBuilder(500);
            ObjectDataSource1.FilterExpression = null;
            int _count = 0;
            foreach (ListItem _lst in chkbase.Items)
            {
                if (_lst.Selected == true)
                {
                    if (_lst.Text == "All")
                    {
                        lblfilter_query.Text = "";
                        ObjectDataSource1.FilterExpression = null;
                        GridView1.DataBind();
                        Load_FilterElements();
                        return;
                    }
                    else
                    {
                        if (lblfilter_query.Text.Length <= 0)
                        {
                            if (_count == 0)
                                sbFilter.Append("(Discipline ='" + _lst.Text + "'");
                            else
                                sbFilter.Append(" OR Discipline ='" + _lst.Text + "'");
                        }
                        else
                        {
                            if (_count == 0)
                                sbFilter.Append(" AND (Discipline ='" + _lst.Text + "'");
                            else
                                sbFilter.Append(" OR Discipline ='" + _lst.Text + "'");
                        }
                        _count += 1;
                    }
                }
            }
            if (sbFilter.ToString().IndexOf("(") >= 0)
                sbFilter.Append(")");
            lblfilter_query.Text = lblfilter_query.Text + sbFilter;

            ObjectDataSource1.FilterExpression = lblfilter_query.Text;
            GridView1.DataBind();
            Load_FilterElements();
        }
        private void MultiFilter2()
        {
            var sbFilter = new System.Text.StringBuilder(500);
            ObjectDataSource1.FilterExpression = null;
            int _count = 0;
            foreach (ListItem _lst in chk_type.Items)
            {
                if (_lst.Selected == true)
                {
                    if (_lst.Text == "All")
                    {
                        lblfilter_query.Text = "";
                        ObjectDataSource1.FilterExpression = null;
                        GridView1.DataBind();
                        Load_FilterElements();
                        return;
                    }
                    else
                    {
                        if (lblfilter_query.Text.Length <= 0)
                        {
                            if (_count == 0)
                                sbFilter.Append("(issue_type ='" + _lst.Text + "'");
                            else
                                sbFilter.Append(" OR issue_type ='" + _lst.Text + "'");
                        }
                        else
                        {
                            if (_count == 0)
                                sbFilter.Append(" AND (issue_type ='" + _lst.Text + "'");
                            else
                                sbFilter.Append(" OR issue_type ='" + _lst.Text + "'");
                        }
                        _count += 1;
                    }
                }
            }
            if (sbFilter.ToString().IndexOf("(") >= 0)
                sbFilter.Append(")");
            lblfilter_query.Text = lblfilter_query.Text + sbFilter;

            ObjectDataSource1.FilterExpression = lblfilter_query.Text;
            GridView1.DataBind();
            Load_FilterElements();
        }
        private void MultiFilter3()
        {
            var sbFilter = new System.Text.StringBuilder(500);
            ObjectDataSource1.FilterExpression = null;
            int _count = 0;
            foreach (ListItem _lst in chkloc.Items)
            {
                if (_lst.Selected == true)
                {
                    if (_lst.Text == "All")
                    {
                        lblfilter_query.Text = "";
                        ObjectDataSource1.FilterExpression = null;
                        GridView1.DataBind();
                        Load_FilterElements();
                        return;
                    }
                    else
                    {
                       
                            if (lblfilter_query.Text.Length <= 0)
                            {
                                if (_count == 0)
                                    sbFilter.Append("(location ='" + _lst.Text + "'");
                                else
                                    sbFilter.Append(" OR location ='" + _lst.Text + "'");
                            }
                            else
                            {
                                //if (lblfilter_query.Text.IndexOf("location ='" + _lst.Text + "'") < 0)
                                //{
                                    if (_count == 0)
                                        sbFilter.Append(" AND (location ='" + _lst.Text + "'");
                                    else
                                        sbFilter.Append(" OR location ='" + _lst.Text + "'");
                                //}
                            }
                            _count += 1;
                      
                    }
                }
            }
            if (sbFilter.ToString().IndexOf("(") >= 0)
                sbFilter.Append(")");
            lblfilter_query.Text = lblfilter_query.Text + sbFilter;

            ObjectDataSource1.FilterExpression = lblfilter_query.Text;
            GridView1.DataBind();
            Load_FilterElements();
        }
        private void MultiFilter4()
        {
            var sbFilter = new System.Text.StringBuilder(500);
            ObjectDataSource1.FilterExpression = null;
            int _count = 0;
            foreach (ListItem _lst in chkstatus.Items)
            {
                if (_lst.Selected == true)
                {
                    if (_lst.Text == "All")
                    {
                        lblfilter_query.Text = "";
                        ObjectDataSource1.FilterExpression = null;
                        GridView1.DataBind();
                        Load_FilterElements();
                        return;
                    }
                    else
                    {

                        if (lblfilter_query.Text.Length <= 0)
                        {
                            if (_count == 0)
                                sbFilter.Append("(r_status ='" + _lst.Text + "'");
                            else
                                sbFilter.Append(" OR r_status ='" + _lst.Text + "'");
                        }
                        else
                        {
                            //if (lblfilter_query.Text.IndexOf("location ='" + _lst.Text + "'") < 0)
                            //{
                            if (_count == 0)
                                sbFilter.Append(" AND (r_status ='" + _lst.Text + "'");
                            else
                                sbFilter.Append(" OR r_status ='" + _lst.Text + "'");
                            //}
                        }
                        _count += 1;

                    }
                }
            }
            if (sbFilter.ToString().IndexOf("(") >= 0)
                sbFilter.Append(")");
            lblfilter_query.Text = lblfilter_query.Text + sbFilter;

            ObjectDataSource1.FilterExpression = lblfilter_query.Text;
            GridView1.DataBind();
            Load_FilterElements();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
        }

    }
}
