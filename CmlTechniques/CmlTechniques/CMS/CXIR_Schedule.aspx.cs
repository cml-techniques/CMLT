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
    public partial class CXIR_Schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "CreateGridHeader", "<script>CreateGridHeader('DataDiv', 'GridView1','HeaderDiv');</script>");
                lblprj.Text = Request.QueryString[0].ToString();
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("CXIR_Master.aspx?id=0_P" + lblprj.Text );
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
                    Session["cxirid"] = GridView1.Rows[i].Cells[25].Text;
                }

            }
            if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');", true);
            else if (count > 1) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('You can select only one Row at a time to Edit');", true);
            else if (count == 1)
            {
                Response.Redirect("CXIR_Master.aspx?id=" + (string)Session["cxirid"] + "_P" + lblprj.Text);

            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            string _path = "CX_Issue_Log_Summary.aspx?id=4";
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.open('" + _path + "');", true);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[25].Visible = false;
        }
    }
}
