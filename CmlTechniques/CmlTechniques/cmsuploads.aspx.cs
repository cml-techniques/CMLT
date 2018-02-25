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

namespace CmlTechniques
{
    public partial class cmsuploads : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                _prm = _prm.Replace("<>", "&");
                if (_prm.Substring(0, 1) != "0")
                {
                    Session["Fold_cms"] = _prm.Substring(0, _prm.IndexOf("_P"));
                    Session["P_id_cms"] = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_P") + 2));
                    Session["F_na_cms"] = _prm.Substring(_prm.IndexOf("_N") + 2, _prm.IndexOf("_M") - (_prm.IndexOf("_N") + 2));
                    Session["mod_name"] = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_S") - (_prm.IndexOf("_M") + 2));
                    Session["ser_name"] = _prm.Substring(_prm.IndexOf("_S") + 2, _prm.IndexOf("_PR") - (_prm.IndexOf("_S") + 2));
                    Session["project"] = _prm.Substring(_prm.IndexOf("_PR") + 3);
                }
                else
                {
                    lblmspath.Text = _prm.Substring(1, _prm.IndexOf("_S") - 1);
                    Session["Fold_cms"] = _prm.Substring(1, _prm.IndexOf("_M") - 1);
                    Session["P_id_cms"] = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_M") + 2));
                    string _path = _prm.Substring(_prm.IndexOf("_N") + 2);
                    Session["F_na_cms"] = _path.Substring(0, _path.IndexOf("_P"));
                    Session["mod_name"] = _path.Substring(0, _path.IndexOf(" >"));
                    Session["project"] = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_S") - (_prm.IndexOf("_P") + 2));
                    Session["ser_name"] = _prm.Substring(_prm.IndexOf("_S") + 2);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["Fold_cms"] + "');", true);
                }
                lblpr.Text = (string)Session["project"];
                Session["reff_no"] = (string)Session["Fold_cms"] + "/" + (string)Session["P_id_cms"] + "/" + (string)Session["mod_name"];
                Load_ProjectCompany();
                Load_Module_users();
                tr_issued.Visible = false;
                Setting();
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["mod_name"] + "');", true);
                tr_status.Visible = false;
                
            }
        }
        private void Setting()
        {
            if ((string)Session["mod_name"] == "Minutes")
            {
                Label1.Visible = false; chk_company.Visible = false; 
                tr_response.Visible = false; tr_type.Visible = true;
                lbl_title.Text = "Minutes Uploads";
                tr_status.Visible = false;
            }
            else if ((string)Session["mod_name"] == "Method Statement")
            {
                Label1.Visible = true; chk_company.Visible = true; 
                tr_response.Visible = true; tr_type.Visible = false;
                lbl_title.Text = "Method Statements Uploads"; tr_status.Visible = false;
                if (lblpr.Text == "12761")
                {
                    tr_issued.Visible = true;
                }
            }
            else if ((string)Session["mod_name"] == "Commissioning Plan")
            {
                Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false; tr_type.Visible = false;
                //Load_doc();
                lbl_title.Text = "Commissioning Plan Uploads"; tr_status.Visible = false;
            }
            else if ((string)Session["mod_name"] == "Commissioning Report" ||(string)Session["mod_name"] == "Commissioning Reports")
            {
                Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false; tr_type.Visible = false;
                //Load_doc();
                lbl_title.Text = "Commissioning Report Uploads"; tr_status.Visible = false;
            }
            else if ((string)Session["mod_name"] == "Mechanical Review")
            {
                Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false; tr_type.Visible = false;
                //Load_doc();
                lbl_title.Text = "Mechanical Review Uploads"; tr_status.Visible = false;
            }
            else if ((string)Session["mod_name"] == "Programmes")
            {
                Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false; tr_type.Visible = false; tr_status.Visible = false;
            }
            else
            {
                Label1.Visible = false; chk_company.Visible = false; tr_response.Visible = false; tr_type.Visible = false; tr_status.Visible = false;
            }
            Load_doc();
        }
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
            
            Load_doc();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["M_id_cms"] + "-" + (string)Session["M_na_cms"] + "');", true);
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblpr.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            string _dir = lblpr.Text;
            if (Directory.Exists(Server.MapPath("CMS_DOCS") + "\\" + _dir) == false)
                Directory.CreateDirectory(Server.MapPath("CMS_DOCS") + "\\" + _dir);
            bool _exist = false;
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
                    hpf.SaveAs(Server.MapPath("CMS_DOCS") + "\\" +_dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    //hpf.SaveAs("http://www.cmltechniques.com\\CmsDocs\\" + System.IO.Path.GetFileName(hpf.FileName));                          }
                    _objcls.doc_name = txtdoc_name.Text;
                    _objcls.file_name = System.IO.Path.GetFileName(hpf.FileName);
                    _objcls.module_name = (string)Session["mod_name"];
                    _objcls.uid = (string)Session["uid"];
                    _objcls.project_code = lblpr.Text;
                    _objcls.upload_date = DateTime.Now;
                    _objcls.folder = Convert.ToInt32((string)Session["Fold_cms"]);
                    _objcls.module = Convert.ToInt32((string)Session["P_id_cms"]);
                    _objcls.reff_no = (string)Session["reff_no"];
                    _objcls.srv_id = Convert.ToInt32((string)Session["ser_name"]);
                    if (chk_private.Checked == true)
                        _objcls.Type = "Private";
                    else
                        _objcls.Type = "Public";
                    _objcls.Comment_By = Convert.ToInt32(dr_responseBy.SelectedItem.Value);
                    _objcls.doc_status = dr_status.SelectedItem.Text;
                    if (lblpr.Text == "12761")
                    {
                        _objcls.company = dr_issuedby.SelectedItem.Text;
                        _objbll.Add_CMS_Document1(_objcls, _objdb);
                    }
                    else
                    {
                        _objbll.Add_CMS_Document(_objcls, _objdb);
                    }
                    Set_CommentsBy();
                    _exist = true;
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
                }
            }
            if (chk.Checked == false && _exist == true)
                btnDummy_ModalPopupExtender2.Show();
            txtdoc_name.Text = "";
        }
        private void Set_CommentsBy()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.Doc_Id = 0;
            for(int i=0;i<=chk_company.Items.Count-1;i++)
            {
                if (chk_company.Items[i].Selected == true)
                {
                    _objcls.Comment_By = Convert.ToInt32(chk_company.Items[i].Value);
                    _objbll.CMSDoc_Permission(_objcls, _objdb);
                }
            }
        }
        protected void Send_Email()
        {
            BLL_Dml _oblbll=new BLL_Dml();
            _database _objdb=new _database();
            _objdb.DBName="dbCML";
            _clsuser _objcls=new _clsuser();
            _objcls.project_code = lblpr.Text;
            string ProjectName = _oblbll.Get_ProjectName(_objcls, _objdb);
            DataTable _dtable;
            string Body = "";
            string _Link = "";
            string _lnk = "";
            publicCls.publicCls _obj = new publicCls.publicCls();
            string _sub = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["F_na_cms"] + "/" + txtdoc_name.Text;
            if ((string)Session["mod_name"] == "Minutes" )
            {
                _lnk = lblpr.Text + "M_" + (string)Session["mod_name"] + "F_" + (string)Session["F_na_cms"] + "FI_" + (string)Session["Fold_cms"];
                _lnk = _lnk.Replace(" ", "%");
                _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + _lnk;
                Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["F_na_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Minutes Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
                //_objcls.mode = 4;
                //_dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
                //var _result = from o in _dtable.AsEnumerable()
                //              select o;
                
            }
            else if((string)Session["mod_name"] == "Training")
            {
                _lnk = lblpr.Text + "M_" + (string)Session["mod_name"] + "F_" + (string)Session["F_na_cms"] + "FI_" + (string)Session["Fold_cms"];
                _lnk = _lnk.Replace(" ", "%");
                _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + _lnk;
                Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["F_na_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Training Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
                //_objcls.mode = 8;
                //_dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
                //var _result = from o in _dtable.AsEnumerable()
                //              select o;
                //foreach (var _uid in _result)
                //{
                //    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                //}
            }
            else if ((string)Session["mod_name"] == "Commissioning Plan")
            {
                _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + lblpr.Text + "M_CP";

                Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["F_na_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Commissiong Plan Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
                //_objcls.mode = 2;
                //_dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
                //var _result = from o in _dtable.AsEnumerable()
                //              select o;
                //foreach (var _uid in _result)
                //{
                //    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                //}
            }
            else if ((string)Session["mod_name"] == "Commissioning Reports")
            {
                _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + lblpr.Text + "M_CR";

                Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["F_na_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Commissiong Plan Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
                //_objcls.mode = 2;
                //_dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
                //var _result = from o in _dtable.AsEnumerable()
                //              select o;
                //foreach (var _uid in _result)
                //{
                //    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                //}
            }
            else if ((string)Session["mod_name"] == "Method Statement")
            {
                //_lnk = lblmspath.Text;
                //_lnk = _lnk.Replace(" ", "%");
                //_lnk = _lnk.Replace(">", "_A");
                //_Link = "http://www.cmltechniques.com/UserLogin.aspx?Id=1P_" + _lnk + "M_1";
                //Body = "Ref. " + ProjectName + " > " + (string)Session["F_na_cms"] + " > " + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Method Statements Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmltechniques.com";
                Body = "Ref. " + ProjectName + " > " + (string)Session["F_na_cms"] + " > " + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
                //_objcls.mode = 3;
                //_dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
                //var _result = from o in _dtable.AsEnumerable()
                //              select o;
                //foreach (var _uid in _result)
                //{
                //    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                //}
               // _obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
                //_clsproject _objprj = new _clsproject();
                //for (int i = 0; i <= chk_company.Items.Count - 1; i++)
                //{
                //    if (chk_company.Items[i].Selected == true)
                //    {
                //        _objprj.com_id = Convert.ToInt32(chk_company.Items[i].Value);
                //        DataTable _dt = _oblbll.Load_UsersCompany(_objprj, _objdb);
                //        var _result = from o in _dt.AsEnumerable()
                //                      select o;
                //        foreach (var _uid in _result)
                //        {
                //            //_sub = _uid[0].ToString();
                //            //_obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
                //            _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                //        }
                //    }
                //}
            }
            else if ((string)Session["mod_name"] == "Programmes")
            {
                _lnk = lblpr.Text + "M_" + (string)Session["mod_name"] + "F_" + (string)Session["F_na_cms"] + "FI_" + (string)Session["Fold_cms"];
                _lnk = _lnk.Replace(" ", "%");
                _Link = "https://cmltechniques.com/UserLogin.aspx?Id=1P_" + _lnk;
                Body = "Ref. " + ProjectName + "/" + (string)Session["mod_name"] + "/" + (string)Session["F_na_cms"] + "/" + txtdoc_name.Text + "\n\n" + "This is an automatically generated email to advise you that the " + (string)Session["mod_name"] + "  document noted above has been uploaded to CML Techniques " + ProjectName + " and is available for review." + "\n\n" + "Could you please find time to review the document and make any comments using the document review page of the " + (string)Session["mod_name"] + "." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Programmes Page,upon login to CML Techniques." + "\n\n" + "Document Path : " + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
                //_objcls.mode = 5;
                //_dtable = _oblbll.Load_CMS_Users(_objcls, _objdb);
                //var _result = from o in _dtable.AsEnumerable()
                //              select o;
                //foreach (var _uid in _result)
                //{
                //    _obj.Send_Email(_uid[0].ToString(), _sub, Body);
                //}
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
            _objcls.project_code = lblpr.Text;
            if ((string)Session["mod_name"] == "Minutes")
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
        private void Load_ProjectCompany()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBcml";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblpr.Text;
            dr_responseBy.DataSource = _objbll.Load_PrjCompany(_objcls, _objdb);
            dr_responseBy.DataTextField = "Company";
            dr_responseBy.DataValueField = "Com_id";
            dr_responseBy.DataBind();
            chk_company.DataSource = _objbll.Load_PrjCompany(_objcls, _objdb);
            chk_company.DataTextField = "Company";
            chk_company.DataValueField = "Com_id";
            chk_company.DataBind();
            dr_issuedby.DataSource = _objbll.Load_PrjCompany(_objcls, _objdb);
            dr_issuedby.DataTextField = "Company";
            dr_issuedby.DataValueField = "Com_id";
            dr_issuedby.DataBind();
        }

        protected void chk_private_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_private.Checked == true)
            { Label1.Visible = true; chk_company.Visible = true; }
            else
            { Label1.Visible = false; chk_company.Visible = false; }
        }
        protected void Load_doc()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblpr.Text;
            _clscmsdocument _objcls = new _clscmsdocument();
            _objcls.reff_no = (string)Session["reff_no"];
            _objcls.project_code = lblpr.Text;
            _objcls.status = true;
            mygrid.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            mygrid.DataBind();
            //_objcls.status = false;
            //myhistory.DataSource = _objbll.Load_CMS_Document(_objcls, _objdb);
            //myhistory.DataBind();
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
        }

        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2.Hide();
        }
    }
}
