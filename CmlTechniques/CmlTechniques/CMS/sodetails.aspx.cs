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
using System.Web.UI.HtmlControls;

namespace CmlTechniques.CMS
{
    public partial class sodetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prj = Request.QueryString["PRJ"].ToString();
                string _id = Request.QueryString["id"].ToString();
                lblid.Text = _id;
                lblprjcode.Text = _prj;
                if (lblprjcode.Text == "HMIM" || lblprjcode.Text == "HMHS")
                {
                    Load_SO_Admin_Response();
                    Get_ProjectName();
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                }
                Load_SO_Info(Convert.ToInt32(lblid.Text));
                load_so_details(Convert.ToInt32(lblid.Text));
                
                //if ((string)Session["uid"] != (string)Session["created"])
                //{
                //    btn.Visible = false;
                //    btnreissue.Visible = false;
                //}
                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP" && (string)Session["uid"].ToString().ToLower() != lbluid.Text.ToLower())
                {
                    btnedit.Enabled = false;
                    btndelete.Enabled = false;
                    btn.Visible = false;
                    btnreissue.Enabled = false;
                }
                if (lblprjcode.Text == "11736" || lblprjcode.Text == "HMIM" || lblprjcode.Text == "HMHS")
                {
                    //if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                    //{
                    //    if (lblPermission.Text != "1")
                    //        trcml.Visible = false;
                    //}
                    trstatus.Visible = true;
                }
                else
                {
                    //trcml.Visible = false;
                    trstatus.Visible = false;
                }
                if (lblprjcode.Text == "HMIM" || lblprjcode.Text == "AZC")
                {
                    tdBuildingLabel.Visible = true;
                    tdBuildingText.Visible = true;
                }
                else
                {
                    tdBuildingLabel.Visible = false;
                    tdBuildingText.Visible = false;
                }
                //settings();
               // prjlogo.Src = "../images/" + _prj + "logo.jpg";
            }
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
        private void Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprjcode.Text;
            prj.Text = _objbll.Get_ProjectName(_objcls, _objdb);
        }
        protected void Load_SO_Admin_Response()
        {
            lblPermission.Text = "0";
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();

            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.uid = Session["uid"].ToString();
            _objcls.project_code = lblprjcode.Text;


            if (_objbll.Load_SO_Admin_Response(_objcls, _objdb).Rows.Count > 0) lblPermission.Text = "1";

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

            }
        }
        protected void settings()
        {
            //if ((string)Session["access"] != "Admin")
            //    data.Visible = false;
        }
        protected void btnaddtr_Click(object sender, EventArgs e)
        {
            //load_users();
            //btnDummy_ModalPopupExtender.Show();            
           // add_details();
            //load_so_details();
        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            string _prm = "Reports.aspx?id=so0" + lblid.Text + "&idx=0&prj=" + lblprjcode.Text;
            ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=210,top=100,width=1110,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
        private void Load_SO_Info(int so_id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = so_id;
            DataTable _dt = _objbll.Load_SO_Info(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                lbpkg.Text = _drow["package"].ToString();
                lbcreated.Text = _drow["uid"].ToString();
                lbno.Text = _drow["so_no"].ToString();
                lbissued.Text = _drow["issued_to"].ToString();
                lbdoc.Text = _drow["subject"].ToString();
                lblsono.Text = _drow["so_no"].ToString();
                lbluid.Text = _drow["uid"].ToString();
                lblissued.Text = _drow["issued_to"].ToString();
                lbBuilding.Text = _drow["building"].ToString();
            }

        }
        protected void load_so_details(int so_id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = so_id;
            mydetails.DataSource = _objbll.Load_SO_Details(_objcls,_objdb);
            mydetails.DataBind();
            get_itmno();
        }
        protected void load_users()
        {
            chkuser.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprjcode.Text;
            DataTable _dtable = _objbll.Load_CMS_Users(_objcls,_objdb);
            var _result = from o in _dtable.AsEnumerable()
                          where o.Field<string>(0) != lblissued.Text
                          select o;
            foreach (var row in _result)
            {
                ListItem lst = new ListItem();
                lst.Text = row[0].ToString();
                lst.Value = row[0].ToString();
                chkuser.Items.Add(lst);
            }           

        }
        protected void mydetails_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            mydetails.EditIndex = -1;
            load_so_details(Convert.ToInt32(lblid.Text));
        }

        protected void mydetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                //Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
                //TextBox _resp = (TextBox)e.Item.FindControl("responseTextBox");
                //BLL_Dml _objbll = new BLL_Dml();
                //_database _objdb = new _database();
                //_objdb.DBName = "DB_" + lblprjcode.Text;
                //_clsSO _objcls = new _clsSO();
                //_objcls.so_itm_id = Convert.ToInt32(_id.Text);
                //_objcls.response = _resp.Text;
                //_objbll.Update_SO_Resp(_objcls, _objdb);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);
            }
            else if (e.CommandName == "Edit")
            {
                TextBox _response = (TextBox)e.Item.FindControl("txtResponse");
                txtresp.Text = _response.Text;
                Label _soItemID = (Label)e.Item.FindControl("so_itm_idLabel");                
                lblsoitmid.Text = _soItemID.Text;
                btnDummy_ModalPopupExtender1.Show();
            }
            else if (e.CommandName == "Comment")
            {
                TextBox _comment = (TextBox)e.Item.FindControl("txt_cmlcomment");
                txt_cmlresp.Text = _comment.Text;
                Label _soItemID = (Label)e.Item.FindControl("so_itm_idLabel");
                lblsoitmid.Text = _soItemID.Text;
                ModalPopupExtender1_cmt.Show();
            }
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + lblprjcode.Text;
            //_clsdocreview _objcls = new _clsdocreview();
            //_objcls.dr_id = 0;
            //_objcls.details = "";
            //_objcls.desc = "";
            //_objcls.response = txtresp.Text.Replace("\n", "<br />");
            //_objcls.issued_date = DateTime.Now;
            //_objcls.uid = "";
            //_objcls.dr_itm_id = Convert.ToInt32((string)Session["id"]);
            //_objcls.mode = 0;
            //_objbll.Document_Review_Details(_objcls, _objdb);
            //load_doc_review_details(Convert.ToInt32(lblid.Text));
            //Send_Mail();
            //btnDummy_ModalPopupExtender1.Hide();

            
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_itm_id = Convert.ToInt32(lblsoitmid.Text);
            _objcls.response = txtresp.Text;
            //.Replace("\n", "<br />");
            _objbll.Update_SO_Resp(_objcls, _objdb);
            load_so_details(Convert.ToInt32(lblid.Text));
            btnDummy_ModalPopupExtender1.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender1.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void mydetails_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            //mydetails.EditIndex = e.NewEditIndex;
            //load_so_details(Convert.ToInt32(lblid.Text));
        }

        protected void mydetails_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            //mydetails.EditIndex = -1;
            //load_so_details(Convert.ToInt32(lblid.Text));
        }

        protected void mydetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = Convert.ToInt32(_id.Text);
            GridView _myphoto = (GridView)e.Item.FindControl("myphoto");
            _myphoto.DataSource = _objbll.Load_SO_Photo(_objcls, _objdb);
            _myphoto.DataBind();
            Button _edit = (Button)e.Item.FindControl("EditButton");
            Button _comment = (Button)e.Item.FindControl("CommetButton");
            if ((string)Session["uid"].ToString().ToLower() != lbissued.Text.ToLower())
                _edit.Visible = false;
            if (lblprjcode.Text == "11736" || lblprjcode.Text == "HMIM" || lblprjcode.Text == "HMHS")
            {
                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                {
                    _comment.Visible = false;
                }

            }
            else
                _comment.Visible = false;
            if (lblPermission.Text == "1")
            {
                _edit.Visible = true;
            }
            //int ent1 = 0;
            //int count = 1;
            //TextBox txt = (TextBox)e.Item.FindControl("detailsLabel");
            //foreach (Char chr in txt.Text)
            //{
            //    if (chr.ToString() == "\n")
            //        ent1 += 1;
            //}
            //if (txt.Text.Length >= 35)
            //    count = (txt.Text.Length / 35);

            //count += ent1;
            //txt.Height = Unit.Pixel(count * 30);
            //txt1.Height = Unit.Pixel(count1 * 30);
            //txt.Rows = count + 1;
            //ent1 = 0;
            //count = 1;
            //TextBox txtRes = (TextBox)e.Item.FindControl("txtResponse");
            //foreach (Char chr in txtRes.Text)
            //{
            //    if (chr.ToString() == "\n")
            //        ent1 += 1;
            //}
            //if (txtRes.Text.Length >= 35)
            //    count = (txt.Text.Length / 35);
            //count += ent1;
            //txtRes.Rows = count + 1;

            //ent1 = 0;
            //count = 1;
            //TextBox txtcom = (TextBox)e.Item.FindControl("txt_cmlcomment");
            //foreach (Char chr in txtcom.Text)
            //{
            //    if (chr.ToString() == "\n")
            //        ent1 += 1;
            //}
            //if (txtcom.Text.Length >= 17)
            //    count = (txt.Text.Length / 17);
            //count += ent1;
            //txtcom.Rows = count + 1;
            //int countRes = txtRes.Text.Length - txtRes.Text.Replace("\n", "").Length + 1;
            //txtRes.Rows = (txtRes.Text.Length / 35) + countRes + 1;

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                HtmlTableCell _td1 = (HtmlTableCell)e.Item.FindControl("td1");
                HtmlTableCell _td2 = (HtmlTableCell)e.Item.FindControl("td2");
                if (_td1 != null && _td2 != null && lblprjcode.Text != "11736")
                {
                    if (lblprjcode.Text != "HMIM")
                    {
                        _td1.Visible = false;
                        _td2.Visible = false;
                    }
                    else
                    {
                        _td2.Visible = false;
                    }

                }
                
            }
            HtmlTableCell _th1 = (HtmlTableCell)mydetails.FindControl("th1");
            HtmlTableCell _th2 = (HtmlTableCell)mydetails.FindControl("th2");
            if (_th1 != null && _th2 != null && lblprjcode.Text != "11736")
            {
                if (lblprjcode.Text != "HMIM")
                {
                    _th1.Visible = false;
                    _th2.Visible = false;
                }
                else
                {
                    _th2.Visible = false;
                }
            }
            
        }
        protected void get_itmno()
        {
            
            for (int i = 0; i < mydetails.Items.Count; i++)
            {
                Label _slno = (Label)mydetails.Items[i].FindControl("slno");
                _slno.Text = (i + 1).ToString();
            }
        }
        protected void btnCont_Click(object sender, EventArgs e)
        {
            //add_details();
            //btnDummy_ModalPopupExtender.Hide();
            //load_so_details();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //string _prm = "soadd.aspx?id=1" + lblprjcode.Text + "_T" + lblid.Text;
            Session["issued"] = lblissued.Text;
            string _prm = "soadd.aspx?" + Request.QueryString.ToString();
            Response.Redirect(_prm);
        }

        protected void btnreissue_Click(object sender, EventArgs e)
        {
            loadusers();
            btnDummy_ModalPopupExtender2.Show();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
        void Send_ReMail()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprjcode.Text;
            string ProjectName = _objbll.Get_ProjectName(_objcls, _objdb);
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clscmsdocument _objcls1 = new _clscmsdocument();
            _objcls1.doc_name = "Site Observation";
            int _period = _objbll.Get_ReviewPeriod(_objcls1, _objdb);
            publicCls.publicCls _obj = new publicCls.publicCls();
            string _Link = "https://cmltechniques.com/Default.aspx?Id=1P_" + lblprjcode.Text + "M_SO";
            string Body = "";
            Body = "Ref. " + ProjectName + "/" + lbpkg.Text + "/" + lblsono.Text + "/" + lbdoc.Text + "\n\n" + "This is an automatically generated email to advise you that the above document has been issued to you." + "\n\n" + "Could you please find time to review the documents  and make comments within the next " + _period + " days" + "\n\n" + "If you review and have no comments on the document, please confirm with 'No comments' in the Response Column." + "\n\n\n" + "Using the link below will direct to the " + ProjectName + " Site Observation Page,upon login to CML Techniques." + "\n\n" + "Document Link :" + _Link + "\n\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";

            string _sub = "Site Observation - Ref. " + ProjectName + "/" + lbpkg.Text + "/" + lblsono.Text + "/" + lbdoc.Text;
            _objdb.DBName = "DBCML";
            _objcls.uid = drissuedto.SelectedItem.Text;
            _objcls.project_code = lblprjcode.Text;
            if (_objbll.GetEmailNotify(_objcls, _objdb) == true)
                _obj.Send_Email(drissuedto.SelectedItem.Text, _sub, Body);
            //_objcls.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);

        }
        protected void loadusers()
        {
            drissuedto.Items.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprjcode.Text;
            _objcls.mode = 6;
            drissuedto.DataSource = _objbll.Load_CMS_Users(_objcls, _objdb);
            drissuedto.DataTextField = "uid";
            drissuedto.DataValueField = "uid";
            drissuedto.DataBind();
            drissuedto.Items.Insert(0, "--Select User--");

        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("SOLog.aspx?" + Request.QueryString.ToString());

        }
        protected void btncancel1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender2.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (drissuedto.SelectedItem.Text == "--Select User--") return;
            Update_SOIssue();
            Send_ReMail();
            btnDummy_ModalPopupExtender2.Hide();
            Response.Redirect("SOLog.aspx?" + Request.QueryString.ToString());
        }
        private void Update_SOIssue()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsSO _objcls = new _clsSO();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.so_id = Convert.ToInt32(lblid.Text);
            _objcls.issued_to = drissuedto.SelectedItem.Text;
            _objcls.issued_date = DateTime.Now;
            _objbll.Update_SOIssueTo(_objcls, _objdb);
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i <= mydetails.Items.Count - 1; i++)
            {
                CheckBox checkbox = (CheckBox)mydetails.Items[i].FindControl("chkselect");
                if (checkbox.Checked == true)
                {
                    count += 1;
                    Label _itmid = (Label)mydetails.Items[i].FindControl("so_itm_idLabel");
                    lblsoitmid.Text = _itmid.Text;
                }

            }
            if (count == 0) { ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');CallAutoSize();", true); }
            else if (count > 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select One Row');CallAutoSize();", true);
            }
            else if (count == 1)
            {
                txt_doc.Text = lbdoc.Text;
                Load_So_Items();
                btnDummy_ModalPopupExtender3.Show();
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            }
            
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Delete_So();
            Response.Redirect("SOLog.aspx?" + Request.QueryString.ToString());
        }

        protected void btnupdateso_Click(object sender, EventArgs e)
        {
            Edit_So();
            load_so_details(Convert.ToInt32(lblid.Text));
            btnDummy_ModalPopupExtender3.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
        private void Load_So_Items()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsSO _objcls = new _clsSO();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.so_itm_id = Convert.ToInt32(lblsoitmid.Text);
            DataTable _dt = _objbll.Load_SO_Items(_objcls, _objdb);
            foreach (DataRow _drow in _dt.Rows)
            {
                txt_descr.Text = _drow["details"].ToString();
                //txt_cmlcommt.Text = _drow["cmlresp"].ToString();
                if (_drow["status"].ToString() == "0")
                    drstatus.Items.FindByValue("2").Selected = true;
            }
            chkReplacePhoto.Checked = false;

            _objcls.so_id = Convert.ToInt32(lblsoitmid.Text);
            dtSOphotos.DataSource = _objbll.Load_SO_Photo(_objcls, _objdb);
            dtSOphotos.DataBind();
        }

        protected void btndelete_itm_Click(object sender, EventArgs e)
        {
            Delete_So_Item();
            load_so_details(Convert.ToInt32(lblid.Text));
            btnDummy_ModalPopupExtender3.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }

        protected void btncancel_edit_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender3.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
        private void Edit_So()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsSO _objcls = new _clsSO();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.so_id = Convert.ToInt32(lblid.Text);
            _objcls.so_itm_id = Convert.ToInt32(lblsoitmid.Text);
            _objcls.doc_name = txt_doc.Text;
            _objcls.details = txt_descr.Text;
            _objcls.comments = "";
            bool _status = true;
            if (drstatus.SelectedValue == "2")
                _status = false;
            _objcls.status = _status;
            _objcls.mode = 1;


            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                string _fileName = System.IO.Path.GetFileName(hpf.FileName);
                FileInfo _Ffile = new FileInfo(Server.MapPath("..\\SOIMG") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                if (_Ffile.Exists == true)
                    _Ffile.Delete();
                if (hpf.ContentLength > 0)
                {
                    Guid _uniqueFileName = Guid.NewGuid();
                    hpf.SaveAs(Server.MapPath("..\\SOIMG") + "\\" + _uniqueFileName.ToString());
                    _objcls.photo += "../SOIMG/" + _uniqueFileName.ToString() + "*";

                    // hpf.SaveAs(Server.MapPath("..\\SOIMG") + "\\" + DateTime.Now.GetDateTimeFormats().GetValue(5) + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second+ "(" + i + ")");
                    //_objcls.photo += "../SOIMG/" + DateTime.Now.GetDateTimeFormats().GetValue(5) + "_" + DateTime.Now.Hour + DateTime.Now.Minute + "(" + i + ")"+"*";

                    //_objbll.SO_Photo(_objcls, _objdb);
                    //_objbll.Add_SO_Photo_Basket(_objcls, _objdb);
                }
            }

            if (!chkReplacePhoto.Checked)
            {
                foreach (DataListItem item in dtSOphotos.Items)
                {
                    _objcls.photo += ((Label)item.FindControl("lblPhoto")).Text + "*";
                }
            }

            _objbll.Edit_SO(_objcls, _objdb);
        }
        private void Delete_So_Item()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsSO _objcls = new _clsSO();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.so_id = Convert.ToInt32(lblid.Text);
            _objcls.so_itm_id = Convert.ToInt32(lblsoitmid.Text);
            _objcls.doc_name = "";
            _objcls.details = "";
            _objcls.comments = "";
            _objcls.mode = 3;
            _objbll.Edit_SO(_objcls, _objdb);
        }
        private void Delete_So()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsSO _objcls = new _clsSO();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.so_id = Convert.ToInt32(lblid.Text);
            _objcls.so_itm_id = 0;
            _objcls.doc_name = "";
            _objcls.details = "";
            _objcls.comments = "";
            _objcls.mode = 2;
            _objbll.Edit_SO(_objcls, _objdb);
        }
        protected void dtSOphotos_DeleteCommand(Object sender, DataListCommandEventArgs e)
        {
            LinkButton _photo = ((LinkButton)e.Item.FindControl("lnkDeleteImage"));
            string _photoID = _photo.Attributes["PhotoID"].ToString();

            DataTable dt = new DataTable();
            dt.Columns.Add("PhotoID", typeof(int));
            dt.Columns.Add("photo", typeof(string));
            foreach (DataListItem item in dtSOphotos.Items)
            {
                int id = int.Parse(((LinkButton)item.FindControl("lnkDeleteImage")).Attributes["PhotoID"]);
                string photo = ((Label)item.FindControl("lblPhoto")).Text;
                dt.Rows.Add(id, photo);
            }

            DataView PhotoView = new DataView(dt);
            PhotoView.Sort = "PhotoID";
            PhotoView.RowFilter = "PhotoID='" + _photoID + "'";
            if (PhotoView.Count > 0)
            {
                PhotoView.Delete(0);
            }
            PhotoView.RowFilter = "";
            dtSOphotos.EditItemIndex = -1;
            dtSOphotos.DataSource = PhotoView;
            dtSOphotos.DataBind();
        }

        protected void dtSOphotos_ItemDataBound(Object sender, DataListItemEventArgs e)
        {
            LinkButton _btnPhoto = (LinkButton)e.Item.FindControl("lnkDeleteImage");
            _btnPhoto.Attributes.Add("PhotoID", dtSOphotos.DataKeys[e.Item.ItemIndex].ToString());
        }
        protected void btnupdate_cmt_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_itm_id = Convert.ToInt32(lblsoitmid.Text);
            _objcls.response = txt_cmlresp.Text;
            _objbll.Update_SO_CMLResp(_objcls, _objdb);
            load_so_details(Convert.ToInt32(lblid.Text));
            ModalPopupExtender1_cmt.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
        protected void btncancel_cmt_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1_cmt.Hide();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
        }
    }
}
