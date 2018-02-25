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
using Telerik.Web.UI;

namespace CmlTechniques.CMS
{
    public partial class PDFUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();

                if (_prm != "0")
                {

                    //lblTreepath.Text = _prm.Substring(_prm.IndexOf("_V") + 2);
                    lblFold_cms.Text = _prm.Substring(0, _prm.IndexOf("_M"));
                    lblM_id_cms.Text = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_M") + 2));
                    lblM_na_cms.Text = _prm.Substring(_prm.IndexOf("_N") + 2, _prm.IndexOf("_P") - _prm.IndexOf("_N") - 2);
                    lblprj.Text = (string)Session["project"];
                    string _path = (string)lblM_na_cms.Text;
                    if (_path.Contains("Method Statement"))
                    {
                        lblmod.Text = _path.Substring(0, _path.IndexOf(" >"));
                        lbldiv.Text = Request.QueryString[1].ToString();
                        Session["mod_name"] = lblmod.Text;
                        Session["Fold_cms"] = lbldiv.Text;
                    }
                    else if (_path == "Commissioning Plan" || _path == "Commissioning Reports" || _path == "Commissioning Report")
                    {
                        Session["mod_name"] = _path;
                        Session["Fold_cms"] = lblFold_cms.Text;
                    }
                    //Jenevieve
                    else if (_path.Contains("Minutes") || _path.Contains("Programmes"))
                    {
                        lblmod.Text = _path.Substring(0, _path.IndexOf(" >"));
                        Session["mod_name"] = lblmod.Text;
                        Session["Fold_cms"] = lblFold_cms.Text;
                        Session["F_na_cms"] = _prm.Substring(_prm.IndexOf(" >") + 3, _prm.IndexOf("_P") - (_prm.IndexOf(" >") + 3));//_path.Substring(_path.IndexOf(">"),_path.Length);
                    }
                    lblreff_no.Text = lblFold_cms.Text + "/" + lblM_id_cms.Text + "/" + (string)Session["mod_name"];
                    //phead.Text = lblM_na_cms.Text.Replace("^", "&");
                    //lblfpath.Text = _path.Replace(">", "#");                                                    

                    package.Text = "Upload Document";

                    prj.Text = Get_ProjectName();

                    if (lblmod.Text == "Method Statement" && lblprj.Text == "HMIM")
                    {
                        ViewState["ServiceID"] = _prm.Substring(_prm.IndexOf("_V4/1") + 6);
                    }

                    Load_ProjectCompany();
                    Load_Module_users();
                    Setting();

                }

            }
        }
        private void Setting()
        {

            //if ((string)Session["mod_name"] == "Commissioning Plan")
            //{
            //    Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false;
            //    tr_type.Visible = false;
            //    //Load_doc();
            //    //lbl_title.Text = "Commissioning Plan Uploads"; 
            //    tr_status.Visible = false;
            //    phead.Text = "Upload - Commissioning Plan";
            //}
            //else if ((string)Session["mod_name"] == "Commissioning Report" || (string)Session["mod_name"] == "Commissioning Reports")
            //{
            //    Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false;
            //    tr_type.Visible = false;
            //    //Load_doc();
            //    //lbl_title.Text = "Commissioning Report Uploads"; 
            //    tr_status.Visible = false;
            //    phead.Text = "Upload - Commissioning Reports";
            //}
            //else if ((string)Session["mod_name"] == "Programmes")
            //{
            //    Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false;
            //    tr_type.Visible = false;
            //    tr_status.Visible = false;
            //    phead.Text = "Upload - Programmes";
            //}
            //else if ((string)Session["mod_name"] == "Method Statement")
            //{
            //    Label1.Visible = true; chk_company.Visible = true;
            //    tr_response.Visible = true;
            //    tr_type.Visible = false;
            //    //tr_type.Visible = false;
            //    //lbl_title.Text = "Method Statements Uploads"; 
            //    tr_status.Visible = false;
            //    phead.Text = "Upload - Method Statement";

            //}
            //else if ((string)Session["mod_name"] == "Minutes")
            //{
            //    Label1.Visible = false; chk_company.Visible = false;
            //    tr_response.Visible = false; tr_type.Visible = true;
            //    //lbl_title.Text = "Minutes Uploads";
            //    tr_status.Visible = false;
            //    phead.Text = "Upload - Minutes";
            //}
            //Jenevieve - 18/01/2018 - start
            //else
            if ((string)Session["mod_name"] == "DRP")
            {
                Label1.Visible = false; chk_company.Visible = false;
                tr_response.Visible = false; tr_type.Visible = true;
                //lbl_title.Text = "Minutes Uploads";
                tr_status.Visible = false;
                phead.Text = "Upload - CML Documents, Reports and Presentations";
            }
            else if ((string)Session["mod_name"] == "SPR")
            {
                Label1.Visible = false; chk_company.Visible = false;
                tr_response.Visible = false; tr_type.Visible = true;
                //lbl_title.Text = "Minutes Uploads";
                tr_status.Visible = false;
                phead.Text = "Upload - CML site progress reports";
            }
            else if ((string)Session["mod_name"] == "SWR")
            {
                Label1.Visible = false; chk_company.Visible = false;
                tr_response.Visible = false; tr_type.Visible = true;
                //lbl_title.Text = "Minutes Uploads";
                tr_status.Visible = false;
                phead.Text = "Upload - Site Witnessing Reports";
            }
            //Jenevieve - 18/01/2018 - end

            //else
            //{
            //    Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false; //tr_type.Visible = false; 
            //   tr_status.Visible = false;
            //}
            //Load_doc();
        }
        private string Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            return _objbll.Get_ProjectName(_objcls, _objdb);
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            string _dir = lblprj.Text;
            bool _exist = false;

            
            if (Directory.Exists(Directory.GetParent(Server.MapPath("\\")) + "\\" + "CMS_DOCS" + "\\" + _dir) == false)
            Directory.CreateDirectory(Directory.GetParent(Server.MapPath("\\")) + "\\" + "CMS_DOCS" + "\\" + _dir);
            //if (Directory.Exists(Server.MapPath("CMS_DOCS") + "\\" + _dir) == false)
            //    Directory.CreateDirectory(Server.MapPath("CMS_DOCS") + "\\" + _dir);
            //for (int i = 0; i < hfc.Count; i++)
            //{
            //    HttpPostedFile hpf = hfc[i];
            //    string _fileName = System.IO.Path.GetFileName(hpf.FileName);
            //    if (ChekSpecialCharacter(_fileName) == true) return;
            //    //FileInfo _Ffile = new FileInfo(Server.MapPath("CMS_DOCS\\" + _dir) + "\\" + System.IO.Path.GetFileName(hpf.FileName));
            //    //if (_Ffile.Exists == true)
            //    //    _Ffile.Delete();
            //    if (hpf.ContentLength > 0)
            //    {
            //        hpf.SaveAs(Server.MapPath("CMS_DOCS") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
            //        //hpf.SaveAs("http://www.cmltechniques.com\\CmsDocs\\" + System.IO.Path.GetFileName(hpf.FileName));                          }
            //        _objcls.doc_name = txtdoc_name.Text;
            //        _objcls.file_name = System.IO.Path.GetFileName(hpf.FileName);
            //        _objcls.module_name = (string)Session["mod_name"];
            //        _objcls.uid = (string)Session["uid"];
            //        _objcls.project_code = lblprj.Text;
            //        _objcls.upload_date = DateTime.Now;
            //        _objcls.folder = Convert.ToInt32(Session["Fold_cms"]);//Convert.ToInt32(lbldiv.Text);
            //        _objcls.module = Convert.ToInt32(lblM_id_cms.Text);
            //        _objcls.reff_no = lblreff_no.Text;
            //        //_objcls.srv_id = Convert.ToInt32((string)Session["ser_name"]);
            //        _objcls.srv_id = Convert.ToInt32(ViewState["ServiceID"]);
            //        _objcls.Type = "Public";
            //        _objcls.Comment_By = Convert.ToInt32(dr_responseBy.SelectedItem.Value);
            //        _objcls.doc_status = dr_status.SelectedItem.Text;

            //        _objbll.Add_CMS_Document(_objcls, _objdb);
            //        //Set_CommentsBy();
            //        _exist = true;
            //        //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
            //    }
            //}
            foreach (UploadedFile file in RadAsyncUpload1.UploadedFiles)
            {
                if (ChekSpecialCharacter(file.FileName) == true) return;
                file.SaveAs(Directory.GetParent(Server.MapPath("\\")) + "\\" + "CMS_DOCS" + "\\" + _dir + "\\" + System.IO.Path.GetFileName(file.FileName));

                _objcls.doc_name = txtdoc_name.Text;
                _objcls.file_name = System.IO.Path.GetFileName(file.FileName);
                _objcls.module_name = (string)Session["mod_name"];
                _objcls.uid = (string)Session["uid"];
                _objcls.project_code = lblprj.Text;
                _objcls.upload_date = DateTime.Now;
                _objcls.folder = Convert.ToInt32(Session["Fold_cms"]);//Convert.ToInt32(lbldiv.Text);
                _objcls.module = Convert.ToInt32(lblM_id_cms.Text);
                _objcls.reff_no = lblreff_no.Text;
                //_objcls.srv_id = Convert.ToInt32((string)Session["ser_name"]);
                _objcls.srv_id = Convert.ToInt32(ViewState["ServiceID"]);
                _objcls.Type = "Public";
                _objcls.Comment_By = Convert.ToInt32(dr_responseBy.SelectedItem.Value);
                _objcls.doc_status = dr_status.SelectedItem.Text;

                _objbll.Add_CMS_Document(_objcls, _objdb);
                //Set_CommentsBy();
                _exist = true;
            }
            //if (chk.Checked == false)
            //    Send_Email();
            if (chk.Checked == false && _exist == true)
                btnDummy_ModalPopupExtender2.Show();
            txtdoc_name.Text = "";
        }
        //private void Set_CommentsBy()
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();
        //    // _objdb.DBName = "DB_" + (string)Session["project"];
        //    _objdb.DBName = "DB_" + lblprj.Text;
        //    _clscmsdocument _objcls = new _clscmsdocument();
        //    _objcls.Doc_Id = 0;
        //    for (int i = 0; i <= chk_company.Items.Count - 1; i++)
        //    {
        //        if (chk_company.Items[i].Selected == true)
        //        {
        //            _objcls.Comment_By = Convert.ToInt32(chk_company.Items[i].Value);
        //            _objbll.CMSDoc_Permission(_objcls, _objdb);
        //        }
        //    }
        //}
        protected void btnupload_Click(object sender, EventArgs e)
        {
            uploadFiles();
            if (chk.Checked)
            {
                //if ((string)Session["mod_name"] == "Commissioning Plan" || (string)Session["mod_name"] == "Commissioning Report" || (string)Session["mod_name"] == "Commissioning Reports")
                //    Response.Redirect("CMS/cmsdoclist.aspx?" + Request.QueryString.ToString());
                //else if ((string)Session["mod_name"] == "Method Statement")
                //    Response.Redirect("CMS/methodstatements1.aspx?" + Request.QueryString.ToString());
                //else if ((string)Session["mod_name"] == "Minutes")
                //    Response.Redirect("cmsminutes.aspx?" + Request.QueryString.ToString());
                //else if ((string)Session["mod_name"] == "Programmes")
                //    Response.Redirect("cmsprogrammes.aspx?" + Request.QueryString.ToString());
                //else if ((string)Session["mod_name"] == "Programmes")
                //    Response.Redirect("cmsprogrammes.aspx?" + Request.QueryString.ToString());
                //Jenevieve - 18/01/2018 - start
                //else 
             
                    Response.Redirect("Documents.aspx?" + Request.QueryString.ToString());
               
                //Jenevieve - 18/01/2018 - end
            }



        }
        private void Load_ProjectCompany()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBcml";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            dr_responseBy.DataSource = _objbll.Load_PrjCompany(_objcls, _objdb);
            dr_responseBy.DataTextField = "Company";
            dr_responseBy.DataValueField = "Com_id";
            dr_responseBy.DataBind();
            chk_company.DataSource = _objbll.Load_PrjCompany(_objcls, _objdb);
            chk_company.DataTextField = "Company";
            chk_company.DataValueField = "Com_id";
            chk_company.DataBind();
        }
        protected void Send_Email()
        {
            BLL_Dml _oblbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            string ProjectName = _oblbll.Get_ProjectName(_objcls, _objdb);
            // DataTable _dtable;
            string Body = "";
            string _Link = "";
            string _lnk = "";
            publicCls.publicCls _obj = new publicCls.publicCls();
            string _sub = "";

            //if ((string)Session["mod_name"] == "Method Statement")
            //{
            //    //_lnk = lblmspath.Text;
            //    //_lnk = _lnk.Replace(" ", "%");
            //    //_lnk = _lnk.Replace(">", "_A");
            //    //_Link = "http://www.cmltechniques.com/UserLogin.aspx?Id=1P_" + _lnk + "M_1";
            //    //Body = "Ref. " + ProjectName + " > " + (string)Session["F_na_cms"] + " > " + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Method Statements Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmltechniques.com";
            //    Body = "Ref. " + ProjectName + " > " + lblM_na_cms.Text + " > " + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            //    _objcls.mode = 3;
            //    //_dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
            //    //var _result = from o in _dtable.AsEnumerable()
            //    //              select o;
            //    //foreach (var _uid in _result)
            //    //{
            //    //    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
            //    //}

            //}
            //else if ((string)Session["mod_name"] == "Commissioning Plan")
            //{
            //    _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + lblprj.Text + "M_CP";
            //    Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["Fold_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Commissiong Plan Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            //}
            //else if ((string)Session["mod_name"] == "Commissioning Reports")
            //{
            //    _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + lblprj.Text + "M_CR";
            //    Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["Fold_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Commissiong Plan Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            //}
            //else if ((string)Session["mod_name"] == "Minutes")
            //{
            //    _lnk = lblprj.Text + "M_" + (string)Session["mod_name"] + "F_" + (string)Session["F_na_cms"] + "FI_" + (string)Session["Fold_cms"];
            //    _lnk = _lnk.Replace(" ", "%");
            //    _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + _lnk;
            //    Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["F_na_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Minutes Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            //}
            //else if ((string)Session["mod_name"] == "Programmes")
            //{
            //    _lnk = lblprj.Text + "M_" + (string)Session["mod_name"] + "F_" + (string)Session["F_na_cms"] + "FI_" + (string)Session["Fold_cms"];
            //    _lnk = _lnk.Replace(" ", "%");
            //    _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + _lnk;
            //    Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["F_na_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Programmes Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            //}
            //else 
            if ((string)Session["mod_name"] == "DRP" || (string)Session["mod_name"] == "SPR" || (string)Session["mod_name"] == "SWR")
            {
                _lnk = lblprj.Text + "M_" + (string)Session["mod_name"] + "F_" + (string)Session["F_na_cms"] + "FI_" + (string)Session["Fold_cms"];
                _lnk = _lnk.Replace(" ", "%");
                string mainFolder = lblM_na_cms.Text.Substring(0, lblM_na_cms.Text.IndexOf(" >"));
                string subFolder = lblM_na_cms.Text.Substring(lblM_na_cms.Text.IndexOf(">") + 2);
                _sub = "Ref. " + ProjectName + "/" + mainFolder + "/" + subFolder + "/" + txtdoc_name.Text;
                _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + _lnk;
                Body = "Ref. " + ProjectName + "/" + mainFolder + "/" + subFolder + "/"+ txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + mainFolder + " document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Minutes Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            }
            foreach (ListItem _lst in chkprjusers.Items)
            {
                if (_lst.Selected == true)
                {
                    string _email = _lst.Text;
                    _obj.Send_Email(_email, _sub, Body);
                }
            }

        }
        private void Load_Module_users()
        {
            BLL_Dml _oblbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            if ((string)Session["mod_name"] == "Minutes" || (string)Session["mod_name"] == "DRP" || (string)Session["mod_name"] == "SPR" || (string)Session["mod_name"] == "SWR")
                _objcls.mode = 4;
            else if ((string)Session["mod_name"] == "Training")
                _objcls.mode = 8;
            else if ((string)Session["mod_name"] == "Commissioning Plan" || (string)Session["mod_name"] == "Commissioning Reports")
                _objcls.mode = 2;
            else if ((string)Session["mod_name"] == "Method Statement")
                _objcls.mode = 3;
            else if ((string)Session["mod_name"] == "Programmes")
                _objcls.mode = 5;
            DataTable _dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
            chkprjusers.DataSource = _dtable;
            chkprjusers.DataTextField = "uid";
            chkprjusers.DataValueField = "uid";
            chkprjusers.DataBind();
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
        protected void chkall_CheckedChanged(object sender, EventArgs e)
        {
            if (chkall.Checked == true)
            {
                foreach (ListItem _lst in chkprjusers.Items)
                {
                    _lst.Selected = true;
                }
            }
            else
            {
                foreach (ListItem _lst in chkprjusers.Items)
                {
                    _lst.Selected = false;
                }
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Send_Email();

            btnDummy_ModalPopupExtender2.Hide();
            //if ((string)Session["mod_name"] == "Method Statement")
            //    Response.Redirect("CMS/methodstatements1.aspx?" + Request.QueryString.ToString());
            //else if ((string)Session["mod_name"] == "Commissioning Plan" || (string)Session["mod_name"] == "Commissioning Report" || (string)Session["mod_name"] == "Commissioning Reports")
            //    Response.Redirect("CMS/cmsdoclist.aspx?" + Request.QueryString.ToString());
            //else if ((string)Session["mod_name"] == "Minutes")
            //    Response.Redirect("cmsminutes.aspx?" + Request.QueryString.ToString());
            //else if ((string)Session["mod_name"] == "Programmes")
            //    Response.Redirect("cmsprogrammes.aspx?" + Request.QueryString.ToString());
            //else 
          
                Response.Redirect("Documents.aspx?" + Request.QueryString.ToString());
         
        }
        protected void chk_private_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_private.Checked == true)
            { Label1.Visible = true; chk_company.Visible = true; }
            else
            { Label1.Visible = false; chk_company.Visible = false; }
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2.Hide();
            //if ((string)Session["mod_name"] == "Method Statement")
            //    Response.Redirect("CMS/methodstatements1.aspx?" + Request.QueryString.ToString());
            //else if ((string)Session["mod_name"] == "Commissioning Plan" || (string)Session["mod_name"] == "Commissioning Report" || (string)Session["mod_name"] == "Commissioning Reports")
            //    Response.Redirect("CMS/cmsdoclist.aspx?" + Request.QueryString.ToString());
            //else if ((string)Session["mod_name"] == "Minutes")
            //    Response.Redirect("cmsminutes.aspx?" + Request.QueryString.ToString());
            //else if ((string)Session["mod_name"] == "Programmes")
            //    Response.Redirect("cmsprogrammes.aspx?" + Request.QueryString.ToString());
          
                Response.Redirect("Documents.aspx?" + Request.QueryString.ToString());
           
        }
    }
}
