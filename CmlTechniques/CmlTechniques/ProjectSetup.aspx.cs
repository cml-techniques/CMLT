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
using System.IO;

namespace CmlTechniques
{
    public partial class ProjectSetup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Load_Project();
        }
        private void Load_Project()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            drproject.DataSource = _objbll.load_project(_objdb);
            drproject.DataTextField = "prj_name";
            drproject.DataValueField = "prj_code";
            drproject.DataBind();
            drproject.Items.Insert(0, "--Select Project--");
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsproject _objcls = new _clsproject();
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                FileInfo _Ffile = new FileInfo(Server.MapPath("images") + "\\" + drproject.SelectedItem.Value + "logo.jpg");
                if (_Ffile.Exists == true)
                    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(Server.MapPath("images") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    FileInfo _info1 = new FileInfo(Server.MapPath("images") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    if (_info1.Exists == true)
                    {
                        _info1.MoveTo(Server.MapPath("images") + "\\" + drproject.SelectedItem.Value + "logo.jpg");
                    }
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
                }
            }
            string _path = "images/" + drproject.SelectedItem.Value + "logo.jpg";
            FileStream fs = new FileStream(Server.MapPath(_path), FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] _image = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            _objcls.prjcode = drproject.SelectedItem.Value;
            _objcls.logo = _image;
            _objbll.Update_PrjLogo(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Completed!');", true);
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            uploadFiles();
        }
    }
}
