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
    public partial class soadd1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblmode.Text = _prm.Substring(0, _prm.IndexOf("_P"));
                lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                load_services(lblprj.Text);
                if (lblmode.Text == "0")
                {
                    trdoc.Visible = false;
                    trnew.Visible = false;
                    lbltitle.Text = "Commissioning Snags - Upload";
                }
                else
                    Load_SOUversion_Details();
                
                //if (_prm.Substring(0, 1) == "1")
                //{
                //    lblid.Text = _prm.Substring(_prm.IndexOf("_T") + 2);
                //    lblprj.Text = _prm.Substring(1, _prm.IndexOf("_T") - 1);
                //    Setting(1);
                //}
                //else
                //{
                //    lblprj.Text = _prm.Substring(1);
                //    Setting(0);
                //    lblid.Text = "0";
                //}

            }
        }
        private void Setting(int type)
        {
            
        }
        protected void btnaddtr_Click(object sender, EventArgs e)
        {
            if (drpackage.SelectedItem.Text == "-- Select Service --") return;
            if (lblmode.Text != "0")
            {
                if (chknew.Checked == false)
                {
                    Update_soDetails();
                }
                else
                    uploadFiles();
            }
            else
                uploadFiles();
            Response.Redirect("SiteObservation.aspx?PRJ=" + lblprj.Text);
        }
        protected void load_services(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Project;
            drpackage.DataSource = _objbll.Load_Cas_service(_objdb);
            drpackage.DataTextField = "PRJ_SER_NAME";
            drpackage.DataValueField = "SYS_SER_ID";
            drpackage.DataBind();
            drpackage.Items.Insert(0, "-- Select Service --");
        }
        private void Load_SOUversion_Details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsSO _objcls = new _clsSO();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.so_id = Convert.ToInt32(lblmode.Text);
            DataTable _dt = _objbll.Load_SOUversion_Details(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                drpackage.Items.FindByText(_drow["srv_name"].ToString()).Selected = true;
                txt_subj.Text = _drow["subject"].ToString();
                txt_date.Text = _drow["issue_date"].ToString();
                txt_created.Text = _drow["issued_by"].ToString();
                txt_issuedto.Text = _drow["issued_to"].ToString();
                txt_cmts.Text = _drow["comments"].ToString();
                txt_clear.Text = _drow["response"].ToString();
                drstatus.Items.FindByText(_drow["so_status"].ToString()).Selected = true;
                txt_details.Text = _drow["details"].ToString();
                txt_cdate.Text = _drow["compl_date"].ToString();
                txt_docname.Text = _drow["doc_name"].ToString();
                lbltitle.Text = "Commissioning Snag [" + _drow["so_no"].ToString() + "] - Edit";
            }
        }
        private void Update_soDetails()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsSO _objcls = new _clsSO();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.so_id = Convert.ToInt32(lblmode.Text);
            _objcls.srv_id = Convert.ToInt32(drpackage.SelectedItem.Value);
            _objcls.sub = txt_subj.Text;
            _objcls.idate = txt_date.Text;
            _objcls.issued_by = txt_created.Text;
            _objcls.issued_to = txt_issuedto.Text;
            _objcls.doc_name = txt_docname.Text;
            _objcls.uid = (string)Session["uid"];
            _objcls.comments = txt_cmts.Text;
            _objcls.response = txt_clear.Text;
            if (drstatus.SelectedItem.Text == "OPEN")
                _objcls.status = true;
            else
                _objcls.status = false;
            _objcls.details = txt_details.Text;
            _objcls.cdate = txt_cdate.Text;
            _objcls.mode = 2;
            _objbll.Insert_SO_Uversion(_objcls, _objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
        }
        private void uploadFiles()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsSO _objcls = new _clsSO();
            string _dir = lblprj.Text;
            if (Directory.Exists(Server.MapPath("..\\CMS_DOCS") + "\\" + _dir) == false)
                Directory.CreateDirectory(Server.MapPath("..\\CMS_DOCS") + "\\" + _dir);
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                //FileInfo _Ffile = new FileInfo(Server.MapPath("CMS_DOCS\\" + _dir) + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                //if (_Ffile.Exists == true)
                //    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(Server.MapPath("..\\CMS_DOCS") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    //hpf.SaveAs("http://www.cmldubai.com\\CmsDocs\\" + System.IO.Path.GetFileName(hpf.FileName));                          }
                    _objcls.so_id = 0;
                    _objcls.srv_id = Convert.ToInt32(drpackage.SelectedItem.Value);
                    _objcls.sub = txt_subj.Text;
                    _objcls.idate = txt_date.Text;
                    _objcls.issued_by = txt_created.Text;
                    _objcls.issued_to = txt_issuedto.Text;
                    _objcls.doc_name = System.IO.Path.GetFileName(hpf.FileName);
                    _objcls.uid = (string)Session["uid"];
                    _objcls.comments = txt_cmts.Text;
                    _objcls.response = txt_clear.Text;
                    if(drstatus.SelectedItem.Text=="OPEN")
                        _objcls.status = true;
                    else
                        _objcls.status = false;
                    _objcls.details = txt_details.Text;
                    _objcls.cdate = txt_cdate.Text;
                    if (lblmode.Text == "0")
                        _objcls.mode = 1;
                    else
                    {
                        _objcls.mode = 2;
                        _objcls.so_id = Convert.ToInt32(lblmode.Text);
                    }
                    _objbll.Insert_SO_Uversion(_objcls, _objdb);                    
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
                }
            }
        }
    }
}
