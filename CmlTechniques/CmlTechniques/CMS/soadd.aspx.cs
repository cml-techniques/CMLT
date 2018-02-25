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
    public partial class soadd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _id = Request.QueryString["id"].ToString();
                if (_id != "0")
                {
                    lblid.Text = Request.QueryString["id"].ToString();
                    lblprj.Text = Request.QueryString["PRJ"].ToString();
                    Setting(1);
                }
                else
                {
                    lblprj.Text = Request.QueryString["PRJ"].ToString();
                    Setting(0);
                    lblid.Text = "0";
                }
                comment_basket _objbasket = new comment_basket();
                _objbasket.clear();
                if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                {
                    Get_ProjectName();
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }

                trBuilding.Visible = (lblprj.Text == "123" || lblprj.Text == "HMIM" || lblprj.Text == "AZC" || lblprj.Text == "HMHS" || lblprj.Text == "demo") ? true : false;
            }
        }
        private void Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            prj.Text = _objbll.Get_ProjectName(_objcls, _objdb);
        }
        private void Setting(int type)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprj.Text;
            string ProjectName = _objbll.Get_ProjectName(_objcls, _objdb);
            //lbltitle.Text = ProjectName + " - Document Review Creation";
            if (type == 0)
            {
                lblpackage.Text = (string)Session["service"];
                lblsubject.Text = (string)Session["doc"];
                lblrecordby.Text = (string)Session["uid"];
                lblsubmitted.Text = (string)Session["issued"];
                if (trBuilding.Visible && Request.QueryString["build"] != null && Request.QueryString["buildid"] != null)
                {
                    lblbuilding.Text = Request.QueryString["build"].ToString();
                    lblbuilding.Attributes.Add("buildid", Request.QueryString["buildid"].ToString());
                }
            }
            else
            {
                Load_SO_Info();
                Session["service"] = lblpackage.Text;
                Session["doc"] = lblsubject.Text;
            }
        }
        private void Load_SO_Info()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32(lblid.Text);
            DataTable _dt = _objbll.Load_SO_Info(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                lblpackage.Text = _drow["package"].ToString();
                lblrecordby.Text = _drow["uid"].ToString();
                lblsono.Text = _drow["so_no"].ToString();
                lblsubmitted.Text = _drow["issued_to"].ToString();
                lblsubject.Text = _drow["subject"].ToString();

                if (lblprj.Text == "123" || lblprj.Text == "HMIM" || lblprj.Text == "AZC" || lblprj.Text == "HMHS" || lblprj.Text == "demo")
                {
                    lblbuilding.Text = _drow["building"].ToString();
                    lblbuilding.Attributes.Add("buildid", _drow["build_id"].ToString());
                }
                //lbluid.Text = _drow["uid"].ToString();
                //lblissued.Text = _drow["issued_to"].ToString();
            }

        }
        protected void btnaddtr_Click(object sender, EventArgs e)
        {
            if (IsNullValidation() == true) return;
            add_details();
            load_so_details();
            txtdetails.Text = String.Empty;
        }
        private void insert_so()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsSO _objcls = new _clsSO();
            _objcls.package = (string)Session["service"];
            _objcls.doc_name = (string)Session["doc"];
            _objcls.so_date = DateTime.Now;
            _objcls.issued_to = (string)Session["issued"];
            _objcls.issued_date = DateTime.Now;
            _objcls.remarks = "";
            _objcls.project_code = (string)Session["project"];
            _objcls.uid = (string)Session["uid"];
            _objcls.mode = 1;
            _objcls.so_id = 0;
            if (trBuilding.Visible && lblbuilding.Attributes["buildid"] != null)
                _objcls.so_building = (Request.QueryString["buildid"] != null) ? Convert.ToInt32(Request.QueryString["buildid"].ToString()) : Convert.ToInt32(lblbuilding.Attributes["buildid"].ToString());
            string _sono = _objbll.SO_Dir(_objcls, _objdb);
            Session["sono"] = _sono;
        }
        protected void add_details()
        {
            HttpFileCollection hfc = Request.Files;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            //if(lblsono.Text=="")
            //    lblsono.Text = _objbll.Get_TempSONo(_objdb);
            _clsSO _objcls = new _clsSO();
            _objcls.details = txtdetails.Text;
            _objcls.so_no = lblsono.Text;
            _objcls.package = (string)Session["service"];
            _objcls.doc_name = (string)Session["doc"];
            _objcls.uid = (string)Session["uid"];
            _objcls.project_code = lblprj.Text;
            if (trBuilding.Visible && lblbuilding.Attributes["buildid"] != null)
                _objcls.so_building = (Request.QueryString["buildid"] != null) ? (Convert.ToInt32(Request.QueryString["buildid"].ToString())) : Convert.ToInt32(lblbuilding.Attributes["buildid"].ToString());
            _objbll.Add_SO_Details_Basket(_objcls, _objdb);
            string[] itm = new string[3];
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                //string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                //FileInfo _Ffile = new FileInfo(Server.MapPath("..\\SOIMG") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                //if (_Ffile.Exists == true)
                //    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {

                    //    hpf.SaveAs(Server.MapPath("..\\SOIMG") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                    //    _objcls.photo = "../SOIMG/" + System.IO.Path.GetFileName(hpf.FileName);
                    //   //_objbll.SO_Photo(_objcls, _objdb);
                    //    _objbll.Add_SO_Photo_Basket(_objcls, _objdb);


                    Guid _uniqueFileName = Guid.NewGuid();
                    string extension = Path.GetExtension(hpf.FileName);
                    string path = Server.MapPath("..\\SOIMG") + "\\" + _uniqueFileName.ToString() + extension;
                    hpf.SaveAs(path);
                    _objcls.photo = "../SOIMG/" + _uniqueFileName.ToString() + extension;
                    _objbll.Add_SO_Photo_Basket(_objcls, _objdb);

                }
            }
        }
        private bool IsNullValidation()
        {
            if (txtdetails.Text.Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Site Observation Details');", true);
                return true;
            }
            return false;
        }
        protected void load_so_details()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_no = lblsono.Text;
            _objcls.project_code = lblprj.Text;
            _objcls.package = (string)Session["service"];

            if (trBuilding.Visible && lblbuilding.Attributes["buildid"] != null)
                _objcls.so_building = (Request.QueryString["buildid"] != null) ? (Convert.ToInt32(Request.QueryString["buildid"].ToString())) : Convert.ToInt32(lblbuilding.Attributes["buildid"].ToString());

            _objcls.doc_name = (string)Session["doc"];
            _objcls.uid = (string)Session["uid"];
            mydetails.DataSource = _objbll.Load_SO_Basket(_objcls, _objdb);
            mydetails.DataBind();
            for (int i = 0; i < mydetails.Items.Count; i++)
            {
                Label _slno = (Label)mydetails.Items[i].FindControl("slno");
                _slno.Text = (i + 1).ToString();
            }
        }
        protected void mydetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32(_id.Text);
            GridView _myphoto = (GridView)e.Item.FindControl("myphoto");
            _myphoto.DataSource = _objbll.Load_SO_Photo_Basket(_objcls, _objdb);
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
        }
        protected void mydetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + (string)Session["project"];
                _clsSO _objcls = new _clsSO();
                _objcls.so_id = Convert.ToInt32(_id.Text);
                _objbll.Remove_SO_Details_Basket(_objcls, _objdb);
                load_so_details();
            }
        }
        protected void mydetails_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (mydetails.Items.Count <= 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('No Comments added, please add Comments to your SO before submitting');", true);
                return;
            }
            if (lblid.Text == "0")
            {
                insert_so();
            }
            Submit();
            load_users();
            btnDummy_ModalPopupExtender.Show();

            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);
        }
        protected void load_users()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            _objcls.mode = 6;
            chkuser.DataSource = _objbll.Load_CMS_Users_Email(_objcls, _objdb);
            chkuser.DataTextField = "uid";
            chkuser.DataValueField = "uid";
            chkuser.DataBind();
        }
        private void Submit()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32(Request.QueryString[0].ToString()); ;
            if (lblid.Text == "0")
                _objcls.so_no = (string)Session["sono"];
            else
                _objcls.so_no = lblsono.Text;
            _objcls.project_code = lblprj.Text;
            _objcls.so_date = DateTime.Now;
            _objcls.remarks = lblsono.Text;
            _objcls.package = (string)Session["service"];
            _objcls.doc_name = (string)Session["doc"];
            _objcls.uid = (string)Session["uid"];
            _objbll.Update_SO_Details(_objcls, _objdb);
            //Send_Mail();
            //load_so_details();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Site Observation Details Submitted');", true);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);
        }
        void Send_Mail()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscmsdocument _objcls1 = new _clscmsdocument();
            _objcls1.doc_name = "Site Observation";
            int _period = _objbll.Get_ReviewPeriod(_objcls1, _objdb);
            publicCls.publicCls _objcls = new publicCls.publicCls();
            string _Link = "https://cmltechniques.com/Default.aspx?Id=1P_" + lblprj.Text + "M_SO";
            string Body = "";
            Body = "Ref. " + (string)Session["projectname"] + "/" + (string)Session["service"] + "/" + (string)Session["sono"] + "/" + (string)Session["doc"] + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next " + _period + " days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n\n" + "Document Link :" + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            string _sub = "Site Observation - Ref. " + (string)Session["projectname"] + "/" + (string)Session["service"] + "/" + (string)Session["sono"] + "/" + (string)Session["doc"];
            _clsuser _clsusr = new _clsuser();
            _objdb.DBName = "DBCML";
            _clsusr.uid = (string)Session["issued"];
            _clsusr.project_code = lblprj.Text;
            if (_objbll.GetEmailNotify(_clsusr, _objdb) == true)
                _objcls.Send_Email((string)Session["issued"], _sub, Body);
            // _objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            Body = "Ref. " + (string)Session["projectname"] + "/" + (string)Session["service"] + "/" + (string)Session["sono"] + "/" + (string)Session["doc"] + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to " + (string)Session["issued"] + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "Document Link :" + _Link + "\n\n\n" + "https://cmltechniques.com";

            for (int i = 0; i <= chkuser.Items.Count - 1; i++)
            {
                if (chkuser.Items[i].Selected == true)
                    _objcls.Send_Email(chkuser.Items[i].Text, _sub, Body);
            }
            // _objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        }

        protected void btnCont_Click(object sender, EventArgs e)
        {
            //insert_so();
            //Submit();
            Send_Mail();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Site Observation Details Submitted');", true);
            //btnDummy_ModalPopupExtender.Hide();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);

            if (lblsono.Text != null && lblsono.Text != string.Empty)
            {
                if (lblprj.Text == "123" || lblprj.Text == "Traini" || lblprj.Text == "demo" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text == "MOE" || lblprj.Text == "11784" || lblprj.Text == "AZC" || lblprj.Text == "NCP")
                {
                    Response.Redirect("sodetails_new.aspx?" + Request.QueryString.ToString());
                }
                else
                    Response.Redirect("sodetails.aspx?" + Request.QueryString.ToString());
            }
            else
            {
                Response.Redirect("SOLog.aspx?" + Request.QueryString.ToString());
            }

        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (lblsono.Text != null && lblsono.Text != string.Empty)
            {
                //if (lblprj.Text == "123" || lblprj.Text == "Traini" || lblprj.Text == "demo")
                //{
                //    Response.Redirect("sodetails_new.aspx?" + Request.QueryString.ToString());
                //}
                //else
                //    Response.Redirect("sodetails.aspx?" + Request.QueryString.ToString());


                if (lblprj.Text == "123" || lblprj.Text == "Traini" || lblprj.Text == "demo" || lblprj.Text == "HMIM" || lblprj.Text == "HMHS" || lblprj.Text == "MOE" || lblprj.Text == "11784" || lblprj.Text == "AZC" || lblprj.Text == "NCP")
                    Response.Redirect("sodetails_new.aspx?" + Request.QueryString.ToString());
                else
                {
                    Response.Redirect("sodetails.aspx?" + Request.QueryString.ToString());
                }
            }
            else
            {
                Response.Redirect("SOLog.aspx?" + Request.QueryString.ToString());
            }

        }
    }
}
