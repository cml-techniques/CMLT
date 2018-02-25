using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using htmlCtrls = System.Web.UI.HtmlControls;
using BusinessLogic;
using App_Properties;
using System.IO;
using System.Data;
using Telerik.Web.UI;
//using Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.HtmlControls;

namespace CmlTechniques.CMS
{
    public partial class sodetails_new : System.Web.UI.Page
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
                lblNewProject.Text = (lblprjcode.Text == "HMIM" || lblprjcode.Text == "HMHS" || lblprjcode.Text == "AZC" || lblprjcode.Text == "123" || lblprjcode.Text == "demo") ? "1" : "0";

                if (lblprjcode.Text == "HMIM" || lblprjcode.Text == "HMHS")
                {
                    Load_SO_Admin_Response();
                    Get_ProjectName();
                }
                else
                {
                    dvfixedhead.Visible = false;
                    dvfixedcontent.Style.Add("Top", "0px");
                    dvSODetailListing.Style.Add("Top", "158px");
                }

                Load_SO_Info(Convert.ToInt32(lblid.Text));
                load_so_details(Convert.ToInt32(lblid.Text));

                SetControlVisibility();
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

            }
        }
        protected void settings()
        {
            //if ((string)Session["access"] != "Admin")
            //    data.Visible = false;
        }
        protected void btnaddtr_Click(object sender, EventArgs e)
        {
            load_users();
            //btnDummy_ModalPopupExtender.Show();
            string script = "function f(){$find(\"" + RadWindow_AddSO.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            //add_details();
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
                lbdoc.Text = (_drow["subject"].ToString()).Replace("\n" , " <br /> ");
                lblsono.Text = _drow["so_no"].ToString();
                lbluid.Text = _drow["uid"].ToString();
                lblissued.Text = _drow["issued_to"].ToString();
                if (lblNewProject.Text == "1")
                {
                    lblBuilding.Text = _drow["building"].ToString();
                    lblBuilding.Attributes.Add("buildid", _drow["build_id"].ToString());
                }
            }
        }

        protected void load_so_details(int so_id)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_id = so_id;
            mydetails.DataSource = _objbll.Load_SO_Details(_objcls, _objdb);
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
            DataTable _dtable = _objbll.Load_CMS_Users(_objcls, _objdb);
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
                Label _id = (Label)e.Item.FindControl("so_itm_idLabel");
                TextBox _resp = (TextBox)e.Item.FindControl("responseTextBox");
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprjcode.Text;
                _clsSO _objcls = new _clsSO();
                _objcls.so_itm_id = Convert.ToInt32(_id.Text);
                _objcls.response = _resp.Text;
                _objbll.Update_SO_Resp(_objcls, _objdb);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "window.close();", true);
            }
            else if (e.CommandName == "Edit1")
            {
                Label _response = (Label)e.Item.FindControl("lblSOResponse");
                Label _comment = (Label)e.Item.FindControl("lblCMLComment");
                txtresp.Text = _response.Text.Replace(" <br />", "\n");
                lblComment.Text = _comment.Text;
                Label _soItemID = (Label)e.Item.FindControl("so_itm_idLabel");
                Label _serialno = (Label)e.Item.FindControl("slno");
                lblsoitmid.Text = _soItemID.Text;
                lblResponseTitle.Text = lblsono.Text + @" / Item " + _serialno.Text + " Response Issue";
           

                string script = "function f(){$find(\"" + RadWindow_Response.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            }
            else if (e.CommandName == "Comment")
            {
                Label _comment = (Label)e.Item.FindControl("lblCMLComment");
                Label _response = (Label)e.Item.FindControl("lblSOResponse");

                txt_cmlresp.Text = _comment.Text.Replace(" <br />", "\n"); ;
                lblResponse.Text = _response.Text;
                Label _soItemID = (Label)e.Item.FindControl("so_itm_idLabel");
                Label _serialno = (Label)e.Item.FindControl("slno");
                lblsoitmid.Text = _soItemID.Text;
                lblCommentTitle.Text = lblsono.Text + @" / Item " + _serialno.Text + " CML Comment";
                string script = "function f(){$find(\"" + RadWindow_Comment.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _clsSO _objcls = new _clsSO();
            _objcls.so_itm_id = Convert.ToInt32(lblsoitmid.Text);
            _objcls.response = txtresp.Text;
            //.Replace("\n", "<br />");
            _objbll.Update_SO_Resp(_objcls, _objdb);
            load_so_details(Convert.ToInt32(lblid.Text));
            //tnDummy_ModalPopupExtender1.Hide();
            string script = "function f(){$find(\"" + RadWindow_Response.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnCancelEdit_Click(object sender, EventArgs e)
        {
            //btnDummy_ModalPopupExtender1.Hide();
            string script = "function f(){$find(\"" + RadWindow_Response.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
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


            Label _details = (Label)e.Item.FindControl("lblDetails");
            _details.Text = (_details.Text.ToString()).Replace("\n", " <br /> ");
            Label _commentText = (Label)e.Item.FindControl("lblCMLComment");
            _commentText.Text = (_commentText.Text.ToString()).Replace("\n", " <br /> ");
            Label _responseText = (Label)e.Item.FindControl("lblSOResponse");
            _responseText.Text = (_responseText.Text.ToString()).Replace("\n", " <br /> ");

            ListView _sophoto = (ListView)e.Item.FindControl("lvPhoto");
            _sophoto.DataSource = _objbll.Load_SO_Photo(_objcls, _objdb);
            _sophoto.DataBind();

            Button _edit = (Button)e.Item.FindControl("EditButton");
            Button _comment = (Button)e.Item.FindControl("CommetButton");

            if (lblprjcode.Text == "11736" || lblprjcode.Text == "HMIM" || lblprjcode.Text == "HMHS" || lblprjcode.Text == "123" || lblprjcode.Text == "demo")
            {
                if ((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP")
                {
                    _comment.Visible = false;
                }

            }
            else
                _comment.Visible = false;

            if ((string)Session["uid"].ToString().ToLower() != lbissued.Text.ToLower())
                _edit.Visible = false;
            if (lblPermission.Text == "1")
            {
                _edit.Visible = true;
            }
            HtmlTableCell _th3 = (HtmlTableCell)mydetails.FindControl("th3");
            _th3.Visible = (_edit.Visible || _comment.Visible) ? true : false;
            Th33.Visible = _th3.Visible;

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HtmlTableCell _td1 = (HtmlTableCell)e.Item.FindControl("td1");
                HtmlTableCell _td2 = (HtmlTableCell)e.Item.FindControl("tdStatus");
                HtmlTableCell _th1 = (HtmlTableCell)mydetails.FindControl("th1");
                HtmlTableCell _th2 = (HtmlTableCell)mydetails.FindControl("th2");
                HtmlTableCell _td3 = (HtmlTableCell)e.Item.FindControl("tdButton");

                _td3.Visible = _th3.Visible;

                if (lblprjcode.Text != "11736" && lblprjcode.Text != "HMIM" && lblprjcode.Text != "HMHS" && lblprjcode.Text != "123" && lblprjcode.Text != "demo")
                {
                    _td1.Visible = false;
                    if (lblprjcode.Text != "MOE")
                    {
                        //Show status column for MOE
                        _td2.Visible = false;
                        Th22.Visible = false;
                        _th2.Visible = false;
                    }
                    _th1.Visible = false;
                   
                    Th11.Visible = false;                    
                    trViewCMLComment.Visible = false;
                    trViewCMLCommentLabel.Visible = false;
                    RadWindow_Response.Style.Add("height", "300px");
                }
                else
                {
                   
                    if (_th3.Visible)
                    {
                        HtmlTableCell _tdPhoto = (HtmlTableCell)e.Item.FindControl("tdPhoto");
                        ListView _lvPhoto = (ListView)_tdPhoto.FindControl("lvPhoto");
                        if (_lvPhoto.Controls.Count > 0)
                        {
                            for (int k = 0; k < _lvPhoto.Controls[0].Controls.Count; k++)
                            {
                                for (int i = 0; i < _lvPhoto.Controls[0].Controls[k].Controls.Count; i++)
                                {
                                    HtmlTable _tbl = (HtmlTable)_lvPhoto.Controls[0].Controls[k].Controls[i].FindControl("tblPhoto");
                                    _tbl.Style.Add("Width", "100%");
                                }
                            }
                        }
                    }
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
            //btnDummy_ModalPopupExtender.Hide();
            string script = "function f(){$find(\"" + RadWindow_AddSO.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //string _prm = "soadd.aspx?id=1" + lblprjcode.Text + "_T" + lblid.Text;
           
            string _prm = "soadd.aspx?" + Request.QueryString.ToString();
            Response.Redirect(_prm);
        }

        protected void btnreissue_Click(object sender, EventArgs e)
        {
            loadusers();
            //btnDummy_ModalPopupExtender2.Show();
            string script = "function f(){$find(\"" + RadWindow_SOReissue.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
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
            //btnDummy_ModalPopupExtender2.Hide();
            string script = "function f(){$find(\"" + RadWindow_SOReissue.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (drissuedto.SelectedItem.Text == "--Select User--") return;
            Update_SOIssue();
            Send_ReMail();
            //btnDummy_ModalPopupExtender2.Hide();
            string script = "function f(){$find(\"" + RadWindow_SOReissue.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
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
            //int count = 0;
            //string serialNo = string.Empty;
            //for (int i = 0; i <= mydetails.Items.Count - 1; i++)
            //{
            //    CheckBox checkbox = (CheckBox)mydetails.Items[i].FindControl("chkselect");
            //    if (checkbox.Checked == true)
            //    {
            //        count += 1;
            //        Label _itmid = (Label)mydetails.Items[i].FindControl("so_itm_idLabel");
            //        lblsoitmid.Text = _itmid.Text;
            //        serialNo = ((Label)mydetails.Items[i].FindControl("slno")).Text; ;
            //    }

            //}
            //if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');CallAutoSize();", true);
            //else if (count > 1)
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select One Row');CallAutoSize();", true);
            //else if (count == 1)
            //{
            //    txt_doc.Text = lbdoc.Text;
            //    Load_So_Items();
            //    string script = "function f(){$find(\"" + RadWindow_SOEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);$find(\"" + RadWindow_SOEdit.ClientID + "\").set_title('" + lblsono.Text + " > Item " + serialNo + " > Comment Edit'); ";
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            //}
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
            string script = "function f(){$find(\"" + RadWindow_SOEdit.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

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
                txt_descr.Text = Server.HtmlDecode(_drow["details"].ToString());
                //txt_cmlcommt.Text = _drow["cmlresp"].ToString();
                if (_drow["status"].ToString() == "0")
                    drstatus.Items.FindByValue("2").Selected = true;
            }
            chkReplacePhoto.Checked = false;

            //_objcls.so_id = Convert.ToInt32(lblsoitmid.Text);
            // lvSOPhotoList.DataSource = _objbll.Load_SO_Photo(_objcls, _objdb);
            //lvSOPhotoList.DataBind();
        }

        protected void btndelete_itm_Click(object sender, EventArgs e)
        {
            Delete_So_Item();
            load_so_details(Convert.ToInt32(lblid.Text));
            //btnDummy_ModalPopupExtender3.Hide();
            string script = "function f(){$find(\"" + RadWindow_SOEdit.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btncancel_edit_Click(object sender, EventArgs e)
        {
            //btnDummy_ModalPopupExtender3.Hide();
            string script = "function f(){$find(\"" + RadWindow_SOEdit.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

        }
        private void Edit_So()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsSO _objcls = new _clsSO();
            _objdb.DBName = "DB_" + lblprjcode.Text;
            _objcls.so_id = Convert.ToInt32(lblid.Text);
            _objcls.so_itm_id = Convert.ToInt32(lblsoitmid.Text);
            _objcls.doc_name = lblSubjectText.Text;
            _objcls.details = txt_descr.Text;
            _objcls.comments = "";
            bool _status = true;
            if (drstatus.SelectedValue == "2")
                _status = false;
            _objcls.status = _status;
            _objcls.mode = 1;

            foreach (UploadedFile file in asyncSOImageUpload.UploadedFiles)
            {
                Guid _uniqueFileName = Guid.NewGuid();
                string path = Server.MapPath("..\\SOIMG") + "\\" + _uniqueFileName.ToString() + file.GetExtension();
                file.SaveAs(path);
                _objcls.photo += "../SOIMG/" + _uniqueFileName.ToString() + file.GetExtension() + "*";

            }

            if (!chkReplacePhoto.Checked)
            {
                foreach (ListViewDataItem item in lvPhotoList.Items)
                {
                    _objcls.photo += ((ImageButton)item.FindControl("imgEdit")).ImageUrl + "*";
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

        protected void lvPhotoList_DeleteCommand(Object sender, ListViewDeleteEventArgs e)
        {
            string _photoID = ((Label)lvPhotoList.Items[e.ItemIndex].FindControl("lblPhotoID")).Text;

            DataTable dt = new DataTable();
            dt.Columns.Add("PhotoID", typeof(int));
            dt.Columns.Add("photo", typeof(string));
            foreach (ListViewDataItem item in lvPhotoList.Items)
            {
                int id = int.Parse(((Label)item.FindControl("lblPhotoID")).Text);
                
                string photo = ((ImageButton)item.FindControl("imgEdit")).ImageUrl;
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
            lvPhotoList.EditIndex = -1; ;
            lvPhotoList.DataSource = PhotoView;
            lvPhotoList.DataBind();
        }

        protected void lvSOPhotoList_ItemDataBound(Object sender, RadListViewItemEventArgs e)
        {
            LinkButton _btnPhoto = (LinkButton)e.Item.FindControl("lnkDeleteImage");
            (e.Item as RadListViewDataItem).GetDataKeyValue("PhotoID").ToString();
            _btnPhoto.Attributes.Add("PhotoID", (e.Item as RadListViewDataItem).GetDataKeyValue("PhotoID").ToString());
            if (e.Item is RadListViewItem)
            {
                RadListViewDataItem item = e.Item as RadListViewDataItem;
                object _dataItem = ((System.Data.DataRowView)(((RadListViewDataItem)e.Item).DataItem)).Row["photo"].ToString();
                string _photoFilePath = Convert.ToString(_dataItem);
                RadBinaryImage _imgPhoto = (RadBinaryImage)e.Item.FindControl("RadBinaryImage1");
                byte[] _photo = new byte[0] { };
                if (File.Exists(Server.MapPath(_photoFilePath)))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath(_photoFilePath));
                    using (var memoryStream = new MemoryStream())
                    {
                        image.Save(memoryStream, ImageFormat.Png);
                        _photo = memoryStream.ToArray();
                    }
                }
                _imgPhoto.DataValue = _photo;
            }
        }

        public static bool DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(HttpContext.Current.Server.MapPath(filePath)))
                {
                    File.Delete(HttpContext.Current.Server.MapPath(filePath));
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
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
            string script = "function f(){$find(\"" + RadWindow_Comment.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        protected void btncancel_cmt_Click(object sender, EventArgs e)
        {
            string script = "function f(){$find(\"" + RadWindow_Comment.ClientID + "\").close(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void rcbAction_OnSelectedIndexChanged(object sender, EventArgs e)
       {
            if(rcbAction.SelectedValue == "4")
            {
                
                string _prm = "Reports.aspx?id=so0" + lblid.Text + "&idx=0&prj=" + lblprjcode.Text;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Message", "window.open('" + _prm + "','','left=210,top=100,width=1110,height=600,menubar=1,toolbar=1,scrollbars=1,status=0,resizable=0');", true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            }
            else if (rcbAction.SelectedValue == "2")
            {                
              if (confirm.Value == "yes")
                {
                    Delete_So();
                    Response.Redirect("SOLog.aspx?" + Request.QueryString.ToString());
                }
            }
            else if(rcbAction.SelectedValue == "0")
            {
                Session["issued"] = lbissued.Text;
                string _prm = "soadd.aspx?" + Request.QueryString.ToString();
                Response.Redirect(_prm);
            }
            else if (rcbAction.SelectedValue == "3")
            {
                loadusers();
                string script = "function f(){$find(\"" + RadWindow_SOReissue.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
            }    
            else
            {
                int count = 0;
                string serialNo = string.Empty;
                ListView _photoList = new ListView();
                for (int i = 0; i <= mydetails.Items.Count - 1; i++)
                {
                    CheckBox checkbox = (CheckBox)mydetails.Items[i].FindControl("chkselect");
                    if (checkbox.Checked == true)
                    {
                        count += 1;
                        Label _itmid = (Label)mydetails.Items[i].FindControl("so_itm_idLabel");
                        lblsoitmid.Text = _itmid.Text;
                        serialNo = ((Label)mydetails.Items[i].FindControl("slno")).Text; ;
                        _photoList = (ListView)mydetails.Items[i].FindControl("lvPhoto");
                    }

                }
                if (count == 0) ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Row');CallAutoSize();", true);
                else if (count > 1)
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select One Row');CallAutoSize();", true);
                else if (count == 1)
                {                    
                    if(rcbAction.SelectedValue == "1")
                    {
                        lblSubjectText.Text = lbdoc.Text;
                        Load_So_Items();
                        
                        DataTable dt = new DataTable();
                        dt.Columns.Add("photo");
                        dt.Columns.Add("PhotoID");
                       
                        for (int i = 0; i < _photoList.Items.Count; i++)
                        {
                            ImageButton _imgbtn = (ImageButton)_photoList.Items[i].Controls[1].FindControl("ImageButton2");
                            DataRow dr = dt.NewRow();
                            dr["photo"] = _imgbtn.ImageUrl.ToString();
                            Label _lblID = (Label)_photoList.Items[i].Controls[1].FindControl("lblPhotID");
                            dr["PhotoID"] = _lblID.Text;
                            dt.Rows.Add(dr);
                        }
                        lvPhotoList.DataSource = dt;
                        lvPhotoList.DataBind();

                        string script = "function f(){$find(\"" + RadWindow_SOEdit.ClientID + "\").show(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);$find(\"" + RadWindow_SOEdit.ClientID + "\").set_title('" + lblsono.Text + " > Item " + serialNo + " > Comment Edit'); ";
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "CallAutoSize();", true);
                    }          
                }
            }

            rcbAction.ClearSelection();
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

        private void Get_ProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprjcode.Text;
            prj.Text = _objbll.Get_ProjectName(_objcls, _objdb);
        }

        private void SetControlVisibility()
        {
            if (!((string)Session["group"] != "ADMIN GROUP" && (string)Session["group"] != "SYS.ADMIN GROUP" && (string)Session["uid"].ToString().ToLower() != lbluid.Text.ToLower()))
            {               
                RadComboBoxItem itemAdd = new RadComboBoxItem();
                itemAdd.Text = "Add Item";
                itemAdd.Value = "0";
                rcbAction.Items.Add(itemAdd);

                RadComboBoxItem itemEdit = new RadComboBoxItem();
                itemEdit.Text = "Edit Item";
                itemEdit.Value = "1";
                rcbAction.Items.Add(itemEdit);

                RadComboBoxItem itemDelete = new RadComboBoxItem();
                itemDelete.Text = "Delete SO";
                itemDelete.Value = "2";
                rcbAction.Items.Add(itemDelete);

                RadComboBoxItem itemReissue = new RadComboBoxItem();
                itemReissue.Text = "Reissue SO";
                itemReissue.Value = "3";
                rcbAction.Items.Add(itemReissue);
            }
            RadComboBoxItem itemPrint = new RadComboBoxItem();
            itemPrint.Text = "Print SO";
            itemPrint.Value = "4";
            rcbAction.Items.Add(itemPrint);

            rcbAction.DataBind();

            if (lblprjcode.Text == "11736" || lblprjcode.Text == "HMIM" || lblprjcode.Text == "HMHS" || lblprjcode.Text == "123" || lblprjcode.Text == "demo" || lblprjcode.Text == "MOE")
            {
                trstatus.Visible = true;
            }
            else
            {
                trstatus.Visible = false;
            }
            tdBuilding.Visible = (lblNewProject.Text == "1")?true:false;
        }

    }
}
