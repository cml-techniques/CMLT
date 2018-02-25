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

namespace CmlTechniques
{
    public partial class GridScroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Load_data();
        }
        private void Load_data()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_BCC1";
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = 1;
            _objcas.prj_code = "BCC1";
            mygrid.DataSource = _objbll.Load_casMain_Edit(_objcas, _objdb);
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
                row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
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

        protected void mygrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = mygrid.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                mygrid.DataSource = dataView;
                mygrid.DataBind();
            }
        }
    }
}
