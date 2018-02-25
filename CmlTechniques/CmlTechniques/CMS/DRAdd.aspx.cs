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
    public partial class DRAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                if (_prm.Substring(0, 1) == "1")
                {
                    lblid.Text = _prm.Substring(_prm.IndexOf("_T") + 2);
                    lblprj.Text = _prm.Substring(1, _prm.IndexOf("_T") - 1);
                    Setting(1);
                }
                else
                {
                    lblprj.Text = _prm.Substring(1);
                    Setting(0);
                    lblid.Text = "0";
                }
                comment_basket _objbasket = new comment_basket();
                _objbasket.clear();
            }
        }
        private void Setting(int type)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprj.Text;
            string ProjectName = _objbll.Get_ProjectName(_objcls, _objdb);
            lbltitle.Text = ProjectName + " - Document Review Creation";
            if (type == 0)
            {
                lblpackage.Text = (string)Session["service"];
                lblsubject.Text = (string)Session["doc"];
                lblrecordby.Text = (string)Session["uid"];
                lblsubmitted.Text = (string)Session["issued"];
                lblissuedto.Text = lblsubmitted.Text;

            }
            else
            {
                Load_DocReview_Info();
                Session["service"] = lblpackage.Text;
                Session["doc"] = lblsubject.Text;
            }
        }
        private void Load_DocReview_Info()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            DataTable _dt = _objbll.Load_Document_Review_INFO(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                lblpackage.Text = _drow["service"].ToString();
                lblrecordby.Text = _drow["userid"].ToString();
                lbldrno.Text = _drow["dr_no"].ToString();
                lblsubmitted.Text = _drow["issued"].ToString();
                lbldrno.Text = _drow["dr_no"].ToString();
                lblsubject.Text = _drow["dr_reviewed"].ToString();
                lblsrvid.Text = _drow["srv_id"].ToString();
                lblissuedto.Text = _drow["issued_to"].ToString();
            }

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
                if (Request.Cookies["issued"] != null)
                {
                    Session["issued"] = Server.HtmlEncode(Request.Cookies["issued"].Value);
                }
                if (Request.Cookies["group"] != null)
                {
                    Session["group"] = Server.HtmlEncode(Request.Cookies["group"].Value);
                }
                if (Request.Cookies["service"] != null)
                {
                    Session["service"] = Server.HtmlEncode(Request.Cookies["service"].Value);
                }

            }
        }
        protected void btnaddtr_Click(object sender, EventArgs e)
        {
            Add_ToTemp();
            Load_DRTemp();
            txtdetails.Text = String.Empty;
            txtdesc.Text = String.Empty;
        }

        protected void myschedule_basket_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void myschedule_basket_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (mydetails.Items.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('No Comments added, please add Comments to your DR before submitting');", true);
                return;
            }
            load_users();
            btnDummy_ModalPopupExtender.Show();
        }
        protected void load_users()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            _objcls.mode = 2;
            chkuser.DataSource = _objbll.Load_CMS_Users(_objcls, _objdb);
            chkuser.DataTextField = "uid";
            chkuser.DataValueField = "uid";
            chkuser.DataBind();
        }
        private void Add_ToTemp()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.details = txtdetails.Text;
            _objcls.descr = txtdesc.Text;
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_reviewed = lblsubject.Text;
            _objcls.service = lblpackage.Text;
            _objbll.Insert_DRTemp(_objcls, _objdb);
            add_Photo();
        }
        protected void add_Photo()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsSO _objcls=new _clsSO();
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                FileInfo _Ffile = new FileInfo(Server.MapPath("..\\DRIMG") + "\\" + lblprj.Text + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                if (_Ffile.Exists == true)
                    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    hpf.SaveAs(Server.MapPath("..\\DRIMG") + "\\" + lblprj.Text + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    _objcls.photo = "../DRIMG/" + lblprj.Text + "/" + System.IO.Path.GetFileName(hpf.FileName);
                    //_objbll.SO_Photo(_objcls, _objdb);
                    _objbll.DR_Photo(_objcls, _objdb);
                }
            }
        }
        private void Load_DRTemp()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_reviewed = lblsubject.Text;
            _objcls.service = lblpackage.Text;
            mydetails.DataSource = _objbll.Load_DRTemp(_objcls, _objdb);
            mydetails.DataBind();
        }
        protected void btnexit_Click(object sender, EventArgs e)
        {

        }
        protected void mydetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = Convert.ToInt32(_id.Text);
            GridView _myphoto = (GridView)e.Item.FindControl("myphoto");
            _myphoto.DataSource = _objbll.Load_DR_Photo_Temp(_objcls, _objdb);
            _myphoto.DataBind();
            int ent1 = 0;
            int count = 1;
            TextBox txt = (TextBox)e.Item.FindControl("detailsLabel");
            foreach (Char chr in txt.Text)
            {
                if (chr.ToString() == "\n")
                    ent1 += 1;
            }
            if (txt.Text.Length >= 80)
                count = (txt.Text.Length / 80);

            count += ent1;
            //txt.Height = Unit.Pixel(count * 30);
            //txt1.Height = Unit.Pixel(count1 * 30);
            txt.Rows = count + 1;
            int ent2 = 0;
            int count1 = 1;
            TextBox txt1 = (TextBox)e.Item.FindControl("descrlabel");
            foreach (Char chr in txt1.Text)
            {
                if (chr.ToString() == "\n")
                    ent2 += 1;
            }
            if (txt1.Text.Length >= 80)
                count1 = (txt1.Text.Length / 80);

            count1 += ent2;
            //txt.Height = Unit.Pixel(count * 30);
            //txt1.Height = Unit.Pixel(count1 * 30);
            txt1.Rows = count1 + 1;
        }
        protected void mydetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clsdocreview _objcls = new _clsdocreview();
                _objcls.dr_id = Convert.ToInt32(_id.Text);
                _objbll.Remove_DR_Details_Basket(_objcls, _objdb);
                Load_DRTemp();
            }
        }
        protected void mydetails_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Insert_Doc_review_log()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_reviewed = lblsubject.Text;
            _objcls.issued_date = DateTime.Now;
            _objcls.issued_to = lblissuedto.Text;
            _objcls.dr_status = true;//open
            _objcls.project_code = lblprj.Text;
            _objcls.uid = lblrecordby.Text;
            _objcls.mode = 1;
            _objcls.service = lblpackage.Text;
            _objcls.Notes = txtnote.Text;
            lbldrno.Text = _objbll.Document_Review_Log(_objcls, _objdb);
            Update_DR_Details();
        }
        private void Update_DR_Details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_no = lbldrno.Text;
            _objcls.service = lblpackage.Text;
            _objcls.details = lblsubject.Text;
            _objcls.uid = lblrecordby.Text;
            _objbll.Update_DR_Details(_objcls, _objdb);
        }
        protected void Insert_Doc_review_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = 0;
            _objcls.response = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_itm_id = 0;
            _objcls.mode = 1;
            for (int i = 0; i <= mydetails.Items.Count - 1; i++)
            {
                TextBox _details = (TextBox)mydetails.Items[i].FindControl("txtdetails");
                TextBox _desc = (TextBox)mydetails.Items[i].FindControl("txtdesc");
                _objcls.details = _details.Text;
                _objcls.desc = _desc.Text;
                _objbll.Document_Review_Details(_objcls, _objdb);
            }
        }
        protected void btnCont_Click(object sender, EventArgs e)
        {
            if (lblid.Text == "0")
            {
                Insert_Doc_review_log();
                //Insert_Doc_review_details();
            }
            else
            {
                Update_DR_Details();
            }
            //Delete_DrTemp();
            Send_Mail();
            btnDummy_ModalPopupExtender.Hide();
            Response.Redirect("cmsdocreview.aspx?PRJ=" + lblprj.Text);
        }
        void Send_Mail()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprj.Text;
            string ProjectName = _objbll.Get_ProjectName(_objcls, _objdb);
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls1 = new _clscmsdocument();
            _objcls1.doc_name = "Document Review";

            int _period = _objbll.Get_ReviewPeriod(_objcls1, _objdb);
            publicCls.publicCls _obj = new publicCls.publicCls();
            string _Link = "https://cmltechniques.com/Default.aspx?Id=1P_" + (string)Session["project"] + "M_DR";
            string Body = "";
            Body = "Ref. " + ProjectName + "/" + (string)Session["service"] + "/" + lbldrno.Text + "/" + (string)Session["doc"] + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next " + _period + " days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Document Review Page,upon login to CML Techniques." + "\n\n" + "Document Link :" + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            string _sub = "Document Review - Ref. " + ProjectName + "/" + (string)Session["service"] + "/" + lbldrno.Text + "/" + (string)Session["doc"];
            _obj.Send_Email(lblissuedto.Text, _sub, Body);
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            Body = "Ref. " + ProjectName + "/" + (string)Session["service"] + "/" + lbldrno.Text + "/" + (string)Session["doc"] + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to " + lblissuedto.Text + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Document Review Page,upon login to CML Techniques." + "\n\n" + "Document Link :" + _Link + "\n\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            for (int i = 0; i <= chkuser.Items.Count - 1; i++)
            {
                if (chkuser.Items[i].Selected == true)
                    _obj.Send_Email(chkuser.Items[i].Text, _sub, Body);
            }
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        }
        protected void Add_Doc_review_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.dr_id = Convert.ToInt32(lblid.Text);
            _objcls.response = "";
            _objcls.issued_date = DateTime.Now;
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_itm_id = 0;
            _objcls.mode = 3;
            for (int i = 0; i <= mydetails.Items.Count - 1; i++)
            {
                TextBox _details = (TextBox)mydetails.Items[i].FindControl("txtdetails");
                TextBox _desc = (TextBox)mydetails.Items[i].FindControl("txtdesc");
                _objcls.details = _details.Text;
                _objcls.desc = _desc.Text;
                _objbll.Document_Review_Details(_objcls, _objdb);
            }
        }
        private void Delete_DrTemp()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsdocreview _objcls = new _clsdocreview();
            _objcls.uid = lblrecordby.Text;
            _objcls.dr_reviewed = lblsubject.Text;
            _objcls.service = lblpackage.Text;
            _objbll.Delete_DRTemp(_objcls, _objdb);
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {

        }
    }
}
