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
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            _download();
        }
        void _download()
        {
            string path = Server.MapPath("Software/VB6.zip");
            System.IO.FileInfo _finfo = new System.IO.FileInfo(path);
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + _finfo.Name);
            Response.AddHeader("Content-Length", _finfo.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(_finfo.FullName);
            Response.End();
        }
    }
}
