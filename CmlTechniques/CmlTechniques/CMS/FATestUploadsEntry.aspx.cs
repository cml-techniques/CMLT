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

namespace CmlTechniques.CMS
{
    public partial class FATestUploadsEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                lblid.Text = Request.QueryString["id"].ToString();
                lblmod.Text = Request.QueryString["mod"].ToString();
                Get_Title();
                tr_status.Visible = false;
            }
        }
        private void Get_Title()
        {
            if (lblmod.Text == "FAT")
            {
                if (lblprj.Text == "MOE") lbltitle.Text = "Document Uploads";
                else
                {
                    lbltitle.Text = "Factory Acceptance Test Uploads";

                    if (!String.IsNullOrEmpty(Request.QueryString["Head"]))
                    {
                        lbltitle.Text = lbltitle.Text + " - " + Request.QueryString["Head"].ToString();
                    }
                }
            }
            else if (lblmod.Text == "MRPT")
            {

                 lbltitle.Text = "Monthly Report Uploads";
            }
        }
        //private void Setting()
        //{
        //        if ((string)Session["mod_name"] == "Method Statement")
        //    {
        //        Label1.Visible = true; chk_company.Visible = true;
        //        tr_response.Visible = true; tr_type.Visible = false;
        //        lbl_title.Text = "Method Statements Uploads"; tr_status.Visible = false;
        //    }

        //    else
        //    {
        //        Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false; tr_type.Visible = false; tr_status.Visible = false;
        //    }
        //    Load_doc();
        //}
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["projectname"] != null)
                {
                    Session["projectname"] = Server.HtmlEncode(Request.Cookies["projectname"].Value);
                }
            }
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
        protected void btnupload_Click(object sender, EventArgs e)
        {
            uploadFiles();
            //Load_doc();
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            string _dir = lblprj.Text;
            if (Directory.Exists(Server.MapPath("../CMS_DOCS") + "\\" + _dir) == false)
                Directory.CreateDirectory(Server.MapPath("../CMS_DOCS") + "\\" + _dir);
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
                    hpf.SaveAs(Server.MapPath("../CMS_DOCS") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    //hpf.SaveAs("http://www.cmltechniques.com\\CmsDocs\\" + System.IO.Path.GetFileName(hpf.FileName));                          }
                    _objcls.doc_name = txtdoc_name.Text;
                    _objcls.file_name = System.IO.Path.GetFileName(hpf.FileName);
                    _objcls.module_name = lblmod.Text;
                    _objcls.uid = (string)Session["uid"];
                    _objcls.project_code = lblprj.Text;
                    _objcls.upload_date = DateTime.Now;
                    _objcls.folder = 0;
                    _objcls.module = 0;
                    _objcls.reff_no = lblmod.Text + "/" + lblid.Text;
                    _objcls.srv_id = Convert.ToInt32((string)Session["ser_name"]);
                    _objcls.Type = "Public";
                    _objcls.Comment_By = 0;
                    _objcls.doc_status = dr_status.SelectedItem.Text;
                    _objbll.Add_CMS_Document(_objcls, _objdb);
                    //Set_CommentsBy();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);

                }
            }
            //if (chk.Checked == false)
               // Send_Email();
            txtdoc_name.Text = "";


            if (lblprj.Text == "MOE")
            {
                Response.Redirect("FATestUploadsList1.aspx?" + Request.QueryString.ToString());
            }
            else if (lblprj.Text == "HMIM")
            {
                Response.Redirect("MonthlyReport.aspx?" + Request.QueryString.ToString());
            }
            else
                Response.Redirect("FATestUploadsList.aspx?" + Request.QueryString.ToString());

           
        }
        
        protected void Send_Email()
        {
            BLL_Dml _oblbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            string ProjectName = _oblbll.Get_ProjectName(_objcls, _objdb);
            DataTable _dtable;
            string Body = "";
            string _Link = "";
            string _lnk = "";
            publicCls.publicCls _obj = new publicCls.publicCls();
            string _sub = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" +  txtdoc_name.Text;
                Body = "Ref. " + ProjectName + " > " + (string)Session["F_na_cms"] + " > " + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
                _objcls.mode = 3;
                _dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
                var _result = from o in _dtable.AsEnumerable()
                              select o;
                foreach (var _uid in _result)
                {
                    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                }
            }

        
        //protected void Load_doc()
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();
        //    _objdb.DBName = "DB_" + lblprj.Text;
        //    _clscmsdocument _objcls = new _clscmsdocument();
        //    _objcls.reff_no = lblmod.Text + "/" + lblid.Text;
        //    _objcls.project_code = lblprj.Text;
        //    _objcls.status = true;
        //    mygrid.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
        //    mygrid.DataBind();
        //}
    }
}
