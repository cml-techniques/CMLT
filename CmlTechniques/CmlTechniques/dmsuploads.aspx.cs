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

namespace CmlTechniques
{
    public partial class dmsuploads : System.Web.UI.Page
    {
        public static DataTable _dtmaster;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                string _type = _prm.Substring(_prm.IndexOf("_P") + 2);
                Load_Master(_type);
                Populate_Latest();
                Populate_History();
                if (_type == "11")
                {
                    if (lblprj.Text == "11784")
                    {
                        lbl_latest.Text = "Latest Progress Tracking Sheet";
                        phead.Text = "Progress Tracking Sheet";
                        lbl_previous.Text = "Previous Months Reports";
                    }
                    else
                    {
                        lbl_latest.Text = "Latest O&M Progress Report";
                        phead.Text = "O&M Progress Report";
                        lbl_previous.Text = "Previous Months Reports";
                    }
                }
                else if (_type == "12")
                {
                    if (lblprj.Text == "11784")
                    {
                        lbl_latest.Text = "Latest O&M Template";
                        phead.Text = "O&M Template";
                        lbl_previous.Text = "Previous O&M Template";
                    }
                    else
                    {
                        lbl_latest.Text = "Latest Training Manual Progress Report";
                        lbl_previous.Text = "Previous Months Reports";
                        phead.Text = "Training Manual Progress Report";
                    }
                }
                else if (_type == "13")
                {
                    if (lblprj.Text == "11784")
                    {
                        lbl_latest.Text = "Latest Documentation PLan";
                        phead.Text = "Documentation PLan";
                        lbl_previous.Text = "Previous Documentation PLan";
                    }
                    else
                    {
                        lbl_latest.Text = "Latest Training Schedule";
                        lbl_previous.Text = "Previous Schedule";
                        phead.Text = "Training Schedule";
                    }
                }
            }
        }
        private void Load_Master(string type)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.folder_id = Convert.ToInt32(type);
            _objcls.project_code = lblprj.Text;
            _dtmaster = _objbll.load_dms_doc_upload(_objcls, _objdb);
        }
        private void Populate_Latest()
        {
            IEnumerable<DataRow> result = from _data in _dtmaster.AsEnumerable()
                         where _data.Field<bool>("status") == true
                         select _data;
            if (result.Any())
            {
                mygrid.DataSource = result.CopyToDataTable<DataRow>();
                mygrid.DataBind();
            }
            
        }
        private void Populate_History()
        {
            IEnumerable<DataRow> result = from _data in _dtmaster.AsEnumerable()
                                          where _data.Field<bool>("status") == false
                                          select _data;
            if (result.Any())
            {
                myhistory.DataSource = result.CopyToDataTable<DataRow>();
                myhistory.DataBind();
            }

        }
        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mygrid.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            string _file = _item.Text;
            string fpath = "https://cmltechniques.com/Documents/" + lblprj.Text + "/" + _file;
            if (e.CommandName == "view")
                Response.Redirect(fpath);
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }

        protected void myhistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
        }

        protected void myhistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = myhistory.Rows[_rowidx];
            TableCell _item = _srow.Cells[1];
            string _file = _item.Text;
            string fpath = "https://cmltechniques.com/Documents/" + lblprj.Text + "/" + _file;
            if (e.CommandName == "view")
                Response.Redirect(fpath);
        }
    }
}
