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
    public partial class dmsdoc_upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lbltype.Text = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_F") - (_prm.IndexOf("_P") + 2));
                lblfolder.Text = _prm.Substring(_prm.IndexOf("_F") + 2);
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            if (IsValidation() == true) return;
            uploadFiles();
        }
        private bool IsValidation()
        {
            if (txtdoc_name.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Document Name');", true);
                return true;
            }
            return false;
        }
        private bool ChekSpecialCharacter(string FileName)
        {
            if (FileName.Contains("&") == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Invalid Document Name! < & sign is not allowed >');", true);
                return true;
            }
            return false;
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsdocument _objcls = new _clsdocument();
            string _dir = lblprj.Text;
            if (Directory.Exists(Server.MapPath("Documents") + "\\" + _dir) == false)
                Directory.CreateDirectory(Server.MapPath("Documents") + "\\" + _dir);
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                if (ChekSpecialCharacter(_fileName) == true) return;
                //FileInfo _Ffile = new FileInfo(Server.MapPath("CMS_DOCS\\" + _dir) + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                //if (_Ffile.Exists == true)
                //    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(Server.MapPath("Documents") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    //hpf.SaveAs("http://www.cmltechniques.com\\CmsDocs\\" + System.IO.Path.GetFileName(hpf.FileName));                          }
                    _objcls.doc_title = txtdoc_name.Text;
                    _objcls.doc_name = _fileName;
                    _objcls.uid = (string)Session["uid"];
                    _objcls.project_code = lblprj.Text;
                    _objcls.folder_id = Convert.ToInt32(lbltype.Text);
                    _objbll.Insert_dmsdoc_upload(_objcls, _objdb);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
                }
            }
            if (chk.Checked == false)
                load_users();
            txtdoc_name.Text = "";
        }
        void load_users()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            string project = _objbll.Get_ProjectName(_objcls, _objdb);
            _clsdocument _objcls1 = new _clsdocument();
            _objcls1.project_code = (string)Session["project"];
            _objcls1.schid = Convert.ToInt32(lblfolder.Text);
            DataTable _dt = _objbll.load_dms_user_email(_objcls1, _objdb);
            var list = from o in _dt.AsEnumerable()
                       select o;

            foreach (var row in list)
            {
                Send_Mail(row[0].ToString(), project);
            }
            //Send_Mail("ssurajpdmsn@gmail.com", project);
            //Send_Mail("callum.king@cmlgroup.ae", project);
        }
        void Send_Mail(string user_id, string project)
        {

            publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "";
            string _sub = "";
            if (lbltype.Text == "11")
            {
                Body = "<div style='width:600px'><p style='margin-bottom:20px'><strong>Ref." + project + " - O&M Progress Report Upload</strong></p><p style='margin-bottom:10px'>This is an automatically generated email to advise you that the Latest O&M Progress Report has been uploaded to CML Techniques web site and is available for review.</p><p style='margin-bottom:50px'>Thank you in anticipation of your co-operation with the review process.</p><p style='margin-bottom:5px'>CML Techniques</p><p style='margin:0'><img src='https://cmltechniques.com/images/logo.jpg' width='100' height='50' /></p><p><a href='https://cmltechniques.com/' target='_blank'>www.cmltechniques.com</a></p></div>";
                _sub = "Ref. " + project + " - O&M Progress Report Upload";
            }
            else if (lbltype.Text == "12")
            {
                Body = "<div style='width:600px'><p style='margin-bottom:20px'><strong>Ref." + project + " - Training Mannual Progress Report Upload</strong></p><p style='margin-bottom:10px'>This is an automatically generated email to advise you that the Latest Training Manual Progress Report has been uploaded to CML Techniques web site and is available for review.</p><p style='margin-bottom:50px'>Thank you in anticipation of your co-operation with the review process.</p><p style='margin-bottom:5px'>CML Techniques</p><p style='margin:0'><img src='https://cmltechniques.com/images/logo.jpg' width='100' height='50' /></p><p><a href='https://cmltechniques.com/' target='_blank'>www.cmltechniques.com</a></p></div>";
                _sub = "Ref. " + project + " - Training Manual Progress Report Upload";
            }
            else if (lbltype.Text == "13")
            {
                Body = "<div style='width:600px'><p style='margin-bottom:20px'><strong>Ref." + project + " - Training Schedule Upload</strong></p><p style='margin-bottom:10px'>This is an automatically generated email to advise you that the Latest Training Schedule has been uploaded to CML Techniques web site and is available for review.</p><p style='margin-bottom:50px'>Thank you in anticipation of your co-operation with the review process.</p><p style='margin-bottom:5px'>CML Techniques</p><p style='margin:0'><img src='https://cmltechniques.com/images/logo.jpg' width='100' height='50' /></p><p><a href='https://cmltechniques.com/' target='_blank'>www.cmltechniques.com</a></p></div>";
                _sub = "Ref. " + project + " - Training Schedule Upload";
            }
            _objcls.Send_Email_Html(user_id, _sub, Body);
        }
    }
}
