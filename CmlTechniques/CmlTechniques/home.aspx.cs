using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CmlTechniques
{
    public partial class home : System.Web.UI.Page
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
                Session["Treepath"] = "";
            }
        }
    }
}
