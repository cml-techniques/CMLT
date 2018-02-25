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

namespace CmlTechniques
{
    public partial class DMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string PName = "";
                if (Request.UrlReferrer != null)
                {
                    PName = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                }

                if (PName == "")
                {
                    Response.Redirect("https://cmltechniques.com");
                }
                string _prm = Request.QueryString[0].ToString();
                tree.Attributes.Add("src", "dmstree.aspx?PRJ=" + _prm);
                head.Attributes.Add("src", "head.aspx?id=DMS&prj=" + _prm);
            }
        }
    }
}
