using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.IO;
namespace CmlTechniques
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            uploadFiles();
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            string _dir = (string)Session["project"];
            if (Directory.Exists(Server.MapPath("CMS_DOCS") + "\\" + _dir) == false)
                Directory.CreateDirectory(Server.MapPath("CMS_DOCS") + "\\" + _dir);
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                //FileInfo _Ffile = new FileInfo(Server.MapPath("CMS_DOCS\\" + _dir) + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                //if (_Ffile.Exists == true)
                //    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(Server.MapPath("CMS_DOCS") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    //hpf.SaveAs("http://www.cmldubai.com\\CmsDocs\\" + System.IO.Path.GetFileName(hpf.FileName));                          }
                    _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
                    _objcls.ts_filed = DateTime.Now.ToString().Substring(0, 10);
                    _objcls.testsheet = System.IO.Path.GetFileName(hpf.FileName);
                    _objbll.Upload_TestSheet(_objcls, _objdb);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.close();", true);
                }

            }

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

        }
    }
}

