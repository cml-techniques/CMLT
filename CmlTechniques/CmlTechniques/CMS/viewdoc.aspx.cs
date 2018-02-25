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

namespace CmlTechniques.CMS
{
    public partial class viewdoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                lblid.Text = Request.QueryString["doc"].ToString();

                string file = "https://cmltechniques.com/CMS_DOCS/" + lblprj.Text + "/";

                if (Request.QueryString["mod"] != null && Request.QueryString["mod"].ToString() == "CableLog")
                {
                    lblinfo.Text = HttpUtility.HtmlDecode(Get_Document());
                    file = file + "CableLog" + "/" + lblinfo.Text;
                }
                else
                {
                    lblinfo.Text = Get_file();
                    file = file + Uri.EscapeDataString(lblinfo.Text);
                }
                
               
                myframe.Attributes.Add("src", file);
            }
        }
        private string Get_file()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "db_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.Doc_Id = Convert.ToInt32(lblid.Text);
            return _objbll.Get_file(_objcls, _objdb);
        }

        private string Get_Document()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "db_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.Doc_Id = Convert.ToInt32(lblid.Text);
            return _objbll.Get_Document("GetCableLogFileName",_objcls, _objdb);
        }
    }
}
