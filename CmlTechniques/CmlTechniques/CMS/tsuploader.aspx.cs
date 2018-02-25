using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.IO;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class tsuploader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            uploadFiles();
            //string _dir = (string)Session["project"];
            //if (Directory.Exists(Server.MapPath("CMS_DOCS") + "\\" + _dir) == false)
            //    Directory.CreateDirectory(Server.MapPath("CMS_DOCS") + "\\" + _dir);
            //if (FileUpload1.HasFile)
            //{

            //    FileUpload1.SaveAs(Server.MapPath("CMS_DOCS") + "\\"  + FileUpload1.FileName);
            //    //_objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            //    //_objcls.ts_filed = DateTime.Now.ToString().Substring(0, 10);
            //    //_objcls.testsheet = System.IO.Path.GetFileName(FileUpload1.FileName);
            //    //_objbll.Upload_TestSheet(_objcls, _objdb);
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Test sheet Uploaded!');", true);
            //    //btnDummy_ModalPopupExtender.Hide();
            //    //Load_Ini_Data();
            //}
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscmsdocument _objcls = new _clscmsdocument();
            //string _dir = (string)Session["project"];
            //if (Directory.Exists(Server.MapPath("CMS_DOCS") + "\\" + _dir) == false)
            //    Directory.CreateDirectory(Server.MapPath("CMS_DOCS") + "\\" + _dir);
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                //FileInfo _Ffile = new FileInfo(Server.MapPath("CMS_DOCS\\" + _dir) + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                //if (_Ffile.Exists == true)
                //    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(Server.MapPath("CMS_DOCS") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    //hpf.SaveAs("http://www.cmldubai.com\\CmsDocs\\" + System.IO.Path.GetFileName(hpf.FileName));                          }
                    //_objcls.doc_name = txtdoc_name.Text;
                    //_objcls.file_name = System.IO.Path.GetFileName(hpf.FileName);
                    //_objcls.module_name = (string)Session["mod_name"];
                    //_objcls.uid = (string)Session["uid"];
                    //_objcls.project_code = (string)Session["project"];
                    //_objcls.upload_date = DateTime.Now;
                    //_objcls.folder = Convert.ToInt32((string)Session["Fold_cms"]);
                    //_objcls.module = Convert.ToInt32((string)Session["P_id_cms"]);
                    //_objcls.reff_no = (string)Session["reff_no"];
                    //_objbll.Add_CMS_Document(_objcls, _objdb);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
                }

            }
            //Send_Email();
            //txtdoc_name.Text = "";
        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            if (AsyncFileUpload1.HasFile)
            {
                string strPath = MapPath("~/CMS_DOCS/") + Path.GetFileName(e.filename);
                AsyncFileUpload1.SaveAs(strPath);
            }

        }
    }
}
