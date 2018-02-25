using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class mech_ahu_vav : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get_CasInfo();
            }
        }
        private void Get_CasInfo()
        {
            string _query = Request.QueryString[0].ToString();
            BLL_Dml _objbll = new BLL_Dml();
            _clscassheet _objcls = new _clscassheet();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.cas_id = Convert.ToInt32(_query);
            DataTable _dt = _objbll.Get_casinfo(_objcls, _objdb);
            var result = from o in _dt.AsEnumerable()
                         select o;
            foreach (var row in result)
            {
                lblprj.Text = (string)Session["projectname"];
                lblsys.Text = row[6].ToString();
                lblreff.Text = row[0].ToString();
                lblcode.Text = row[1].ToString() + row[2].ToString() + row[3].ToString() + row[4].ToString();
            }

        }
        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void cmdadd_Click(object sender, EventArgs e)
        {

        }
        private void Add_CRS()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsCRS _objcrs = new _clsCRS();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcrs.pkg_cate_id = 1;
            _objcrs.sys_id = 1;
            _objcrs.eng_reff = lblreff.Text;
            _objcrs.asset_code = lblcode.Text;
        }

      
    }
}
