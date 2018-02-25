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
    public partial class cxissue_master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((string)Session["uid"] == null)
                {
                    Response.Redirect("../session.htm");
                }
                else
                {
                    string _query = Request.QueryString[0].ToString();
                    lblprj.Text = _query;
                    //myframe1.Attributes.Add("src", "CXIssuesLog.aspx?id=" + lblprj.Text);
                    myframe1.Attributes.Add("src", "GridSample.aspx?id=" + lblprj.Text);
                }
            }
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            myframe1.Attributes.Add("src", "GridSample.aspx?id=" + lblprj.Text);
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            myframe1.Attributes.Add("src", "CX_Issue_Log_Summary.aspx?id=1");
        }

        protected void btnsum_Click(object sender, EventArgs e)
        {
            myframe1.Attributes.Add("src", "CX_RO_Summary.aspx");
        }
    }
}
