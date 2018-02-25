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
    public partial class fileupload : System.Web.UI.Page
    {
        public static DataTable _dtable;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                //loadData();
                //Panel3.Visible = false;
                //drpsub.Visible = false;
                //Label2.Visible = false;
                //drpsub1.Visible = false;
                //Label3.Visible = false;
                //Panel1.Visible = false;
                string _query = Request.QueryString[0].ToString();
                if (_query == "0") return;
                _query = _query.Replace("<>", "&");
                Session["folder"] = _query.Substring(0, _query.IndexOf("_T"));
                Session["type"] = _query.Substring(_query.IndexOf("_T") + 2,1);
                Session["parent"] = _query.Substring(_query.IndexOf("_P") + 2);
                txtdoc.Text = (string)Session["parent"];
                Load_Schedule();
                Get_Schedule();
                Label1.Text = _query;
            }
        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["projectname"] != null)
                {
                    Session["projectname"] = Server.HtmlEncode(Request.Cookies["projectname"].Value);
                }
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
            }
        }
        protected void show_Click(object sender, EventArgs e)
        {
            myschedule_basket.Visible = true;
            Get_Schedule1();
            Check_OMManual();
            //Label1.Text = "";
            if (myschedule_basket.Rows.Count > 0)
                Label1.Text = myschedule_basket.Rows[0].Cells[8].Text;
            else
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('No Schedule!');", true);
        }

        //DataTable _schedule;
        private void loadData()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsuser  _objcls = new _clsuser ();
            //_objcls.project_code = (string)Session["project"];
            //drppackages.DataSource = _objbll.load_AvailablePackages(_objcls,_objdb);
            //drppackages.DataTextField = "Package_description";
            //drppackages.DataValueField = "Package_id";
            //drppackages.DataBind();
            //drppackages.Items.Insert(0, "-- Select Available Package --");
            //drpmanufacture.DataSource = _objbll.load_manufacturer(_objcls);
            //drpmanufacture.DataTextField = "Manufacture_Name";
            //drpmanufacture.DataValueField = "Manufacture_code";
            //drpmanufacture.DataBind();
            //drpmanufacture.Items.Insert(0, "-- Select Manufacture Name --");
        }
        void load_doctype()
        {
            //if (drpmanufacture.Items.Count > 0) return;
            //drpmanufacture.Items.Clear();
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsmanufacture _objcls = new _clsmanufacture();
            //_objcls.project_code = (string)Session["project"];
            //DataTable _Doctype = _objbll.load_doctype(_objdb);
            //DataTable _dtable1 = new DataTable();
            //_dtable1.Columns.Add("id");
            //_dtable1.Columns.Add("type");
            //var _List = from o in _Doctype.AsEnumerable()
            //            where o.Field<int>(5) ==Convert.ToInt32( drppackages.SelectedItem.Value)
            //            select o;

            //foreach (var row in _List)
            //{
            //    DataRow _myrow = _dtable1.NewRow();
            //    _myrow[0] = row[0].ToString() + "_T" + row[7].ToString();
            //    _myrow[1] = row[2].ToString();
            //    _dtable1.Rows.Add(_myrow);
            //}
            //drpmanufacture.DataSource = _dtable1;
            //drpmanufacture.DataTextField = "type";
            //drpmanufacture.DataValueField = "id";
            //drpmanufacture.DataBind();
        }
        private void load_group()
        {
            //drpsub.Visible = true;
            //drpsub.Items.Clear();
            //BLL_Dml _dtobj = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            ////drpsub.DataSource = 
            ////drpsub.DataBind();
            //string _id = drpmanufacture.SelectedItem.Value.Substring(0, drpmanufacture.SelectedItem.Value.IndexOf("_T"));
            //DataTable _dtable = _dtobj.load_group(_objdb);
            //var _result=from o in _dtable.AsEnumerable()
            //            where o.Field<int>(5) == Convert.ToInt32(_id)
            //            select o;
            //foreach (var row in _result)
            //{
            //    ListItem _lst = new ListItem();
            //    _lst.Text = row[2].ToString();
            //    _lst.Value = row[0].ToString();
            //    drpsub.Items.Add(_lst);
            //}
            //if (drpsub.Items.Count <= 0)
            //{ drpsub.Visible = false; Label2.Visible=false; }
            //else
            //    Label2.Visible = true;
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
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    CheckBox _chk =(CheckBox)myschedule_basket.Rows[i].Cells[0].FindControl("chk");
                    if (_chk.Checked == true)
                    {
                        
                        if (myschedule_basket.Rows[i].Cells[4].Text != System.IO.Path.GetFileName(hpf.FileName))
                        {
                            //Label1.Text = "Please check the document name which you selected!";
                            return;
                        }
                        string _filename = System.IO.Path.GetFileName(hpf.FileName);
                       // if (ChekSpecialCharacter(_filename) == true) return;
                        hpf.SaveAs(Server.MapPath("Documents") + "\\" + System.IO.Path.GetFileName(hpf.FileName));
                        _objcls.doc_name = System.IO.Path.GetFileName(hpf.FileName);
                        _objcls.doc_title = myschedule_basket.Rows[i].Cells[3].Text;
                        _objcls.doctype_code = 0;
                        _objcls.package_code = 0;
                        _objcls.uploaded_date = DateTime.Now;
                        _objcls.service_code = 0; ;
                        _objcls.uploaded = true;
                        _objcls.schid = Convert.ToInt32(myschedule_basket.Rows[i].Cells[7].Text);
                        _objcls.folder_id = Convert.ToInt32(myschedule_basket.Rows[i].Cells[5].Text);
                        _objcls.file_size = decimal.Round((Convert.ToDecimal(hpf.ContentLength) / 1024), 2).ToString() + "KB";
                        _objcls.uid = (string)Session["uid"];
                        if ((string)Session["status"] == "true")
                        {
                            _objcls.type = "O & M Manual";

                        }
                        else
                            _objcls.type = "";
                        _objcls.possition = Convert.ToInt32(myschedule_basket.Rows[i].Cells[9].Text);
                        _objbll.file_upload(_objcls,_objdb);
                        if ((string)Session["status"] == "true")
                        {
                            SetDocDuration();
                            load_users();
                            //Panel3.Visible = false;
                        }
                        
                       

                    }
                        
                    //Response.Write("<b>File: </b>" + hpf.FileName + " <b>Size:</b> " +
                    //    hpf.ContentLength + " <b>Type:</b> " + hpf.ContentType + " Uploaded Successfully <br/>");
                    //_objcls.doc_name = System.IO.Path.GetFileName(hpf.FileName);
                    //_objcls.doc_title = System.IO.Path.GetFileName(hpf.FileName).Substring(0, System.IO.Path.GetFileName(hpf.FileName).Length - 4);
                    //_objcls.doctype_code = doctypedrlst.SelectedItem.Text;
                    //_objcls.package_code = packagedrlst.SelectedItem.Text;
                    //_objcls.uploaded_date = DateTime.Now;
                    //_objcls.service_code = "";
                    //_objcls.uploaded = true;
                    //_objcls.file_size = (hpf.ContentLength / 1024).ToString() + "KB";
                    //_objbll.file_upload(_objcls);
                    //Label1.Text = "Uploading Completed Successfully...";
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Documents Uploaded!');", true);
                    clear();
                }

            }

        }
        void load_package()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //DataTable _packagetbl = _objbll.load_package();
            //var _result = from o in _packagetbl.AsEnumerable()
            //              where o.Field<string>(2) == servicedrlst.Text
            //              select o;
            //packagedrlst.Items.Clear();
            //foreach (var row in _result)
            //{
            //    packagedrlst.Items.Add(row[1].ToString());
            //}
            //packagedrlst.Items.Insert(0, "---- Select Package ----");
            //packagedrlst.DataBind();
        }

        void Check_OMManual()
        {
            //string _type = drpmanufacture.SelectedItem.Value.Substring(drpmanufacture.SelectedItem.Value.IndexOf("_T") + 2);
           // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["type"] + "');", true);
            string _type = (string)Session["type"];
            if (myschedule_basket.Rows.Count > 0)
            {
                if (_type == "1")
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + myschedule_basket.Rows[0].Cells[5].Text + "');", true);
                    int Folder_Id = Convert.ToInt32(myschedule_basket.Rows[0].Cells[5].Text);
                    BLL_Dml _objbll = new BLL_Dml();
                    _database _objdb = new _database();
                    _objdb.DBName = "dbCML";
                    _clstreefolder _objcls = new _clstreefolder();
                    _objcls.Folder_id = Folder_Id;
                    Session["status"] = "true";
                    btnDummy_ModalPopupExtender.Show();
                    //if (_objbll.CheckOMExist(_objcls,_objdb) == "0")
                    //{
                    //    btnDummy_ModalPopupExtender.Show();
                    //}
                    //else
                    //{
                    //    Session["Rev"] = "Revised";
                    //}
                }
                else
                    Session["status"] = "false";
            }
        }

        protected void cmdupload_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["status"] +"');", true);
           uploadFiles();
            
        }
        void clear()
        {
            loadData();
            myschedule_basket.Visible = false;
        }
        protected void upload_Click(object sender, EventArgs e)
        {
            
        }
        private void load_schedule()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //schedulenamedrlst.DataSource = _objbll.load_schedule();
            //schedulenamedrlst.DataTextField = "Sch_name";
            //schedulenamedrlst.DataBind();
            //schedulenamedrlst.Items.Insert(0, "--- Select Schedule ----");
        }
        void load_manufacture()
        {
            //manudrlist.Items.Add("Manufacture 1");
            //manudrlist.Items.Add("Manufacture 2");
            //manudrlist.Items.Insert(0, "---- Select manufacture ----");

        }
        private void Load_Schedule()
        {
            
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            _dtable = _objbll.load_schedule(_objcls, _objdb);
        }
        private void Get_Schedule()
        {
            string _folder = (string)Session["folder"];
            DataTable _dtable1 = new DataTable();
            _dtable1.Columns.Add("package");
            _dtable1.Columns.Add("Folder");
            _dtable1.Columns.Add("manufacture");
            _dtable1.Columns.Add("doc_name");
            _dtable1.Columns.Add("Folder_id");
            _dtable1.Columns.Add("id");
            _dtable1.Columns.Add("srv");
            var _List = from o in _dtable.AsEnumerable()
                        where o.Field<int>(5) == Convert.ToInt32(_folder)
                        select o;
            try
            {
                foreach (var row in _List)
                {
                    DataRow _myrow = _dtable1.NewRow();
                    _myrow[0] = "aa";
                    _myrow[1] = row[6].ToString();
                    _myrow[2] = row[2].ToString();
                    _myrow[3] = row[3].ToString();
                    _myrow[4] = row[5].ToString();
                    _myrow[5] = row[0].ToString();
                    _myrow[6] = row[7].ToString();
                    _dtable1.Rows.Add(_myrow);
                }
                //myschedule_basket.DataSource = _dtable1;
                //myschedule_basket.DataBind();
                myschedule.DataSource = _dtable1;
                myschedule.DataBind();
            }
            catch (Exception ex)
            {
                //Label1.Text = ex.ToString();
            }

        }
        private void Get_Schedule1()
        {
            string _folder = (string)Session["folder"];
            DataTable _dtable1 = new DataTable();
            _dtable1.Columns.Add("package");
            _dtable1.Columns.Add("Folder");
            _dtable1.Columns.Add("manufacture");
            _dtable1.Columns.Add("doc_name");
            _dtable1.Columns.Add("Folder_id");
            _dtable1.Columns.Add("id");
            _dtable1.Columns.Add("srv");
            _dtable1.Columns.Add("possition");
            var _List = from o in _dtable.AsEnumerable()
                        where o.Field<int>(5) == Convert.ToInt32(_folder)
                        select o;
            try
            {
                foreach (var row in _List)
                {
                    DataRow _myrow = _dtable1.NewRow();
                    _myrow[0] = "aa";
                    _myrow[1] = row[6].ToString();
                    _myrow[2] = row[2].ToString();
                    _myrow[3] = row[3].ToString();
                    _myrow[4] = row[5].ToString();
                    _myrow[5] = row[0].ToString();
                    _myrow[6] = row[7].ToString();
                    _myrow[7] = row["possition"].ToString();
                    _dtable1.Rows.Add(_myrow);
                }
                myschedule_basket.DataSource = _dtable1;
                myschedule_basket.DataBind();
                //myschedule.DataSource = _dtable1;
                //myschedule.DataBind();
            }
            catch (Exception ex)
            {
                //Label1.Text = ex.ToString();
            }

        }
        

        

        
        protected void myschedule_basket_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[9].Visible = false;
            //Label1.Text = "hai";
        }

        protected void drppackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_doctype();
        }

        void Check_IfOMManual()
        {
            //Label1.Text = "Success";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = "Success";
        }

        protected void myschedule_basket_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Label1.Text = "Success";
        }

        protected void myschedule_basket_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Panel3.Visible = true;
        }

        protected void myschedule_basket_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Label1.Text = "Success";
        }

        protected void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow _row = (GridViewRow)chk.Parent.Parent;
            string _folder = myschedule_basket.Rows[_row.RowIndex].Cells[2].Text;
            //Label1.Text = _folder;
            string str = "O & M Manual";
            //Panel3.Visible = true;
            if (chk.Checked == true)
            {
            if (_folder.Substring(_folder.IndexOf("M"))== str.Substring(str.IndexOf("M")))
            {
                //Panel3.Visible = true;
                //myschedule_basket.Enabled = false;
            }
            else
            {
                //Panel3.Visible = false;
            }
            }
            else
            {
                //Panel3.Visible = false;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void myschedule_basket_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Label1.Text = "this is currect";
        }

        protected void myschedule_basket_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Label1.Text = "this is currect";

        }

        void SetDocDuration()
        {
            if (time.Text == "0") return;//Revised OM Manual
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocduration _objcls = new _clsdocduration();
            //string _Doc_type = drpmanufacture.SelectedItem.Value.Substring(0, drpmanufacture.SelectedItem.Value.IndexOf("_T"));
            string _Doc_type = (string)Session["folder"];
            _objcls.Folder_id = Convert.ToInt32(_Doc_type);
            _objcls.Duration =Convert.ToInt32( time.Text);
            _objcls.First = Convert.ToInt32(remind1.Text);
            _objcls.Second = Convert.ToInt32(remind2.Text);
            _objcls.Third = Convert.ToInt32(remind3.Text);
            _objcls.prj_code = (string)Session["project"];
            _objbll.SetDocDuration(_objcls,_objdb);
        }

        protected void cmdsetduration_Click(object sender, EventArgs e)
        {
            if (time.Text == "0")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Enter Review Period');", true);
                return;
            }                
            Session["status"] = "true";
            cmdupload.Enabled = true;
            myschedule_basket.Enabled = true;
            //cmdupload.Attributes["onclick"] = "Button2_Click";
            
        }
        protected void btnCont_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ txtremind1.Text +"');", true);
            //if (time.Text == "0")
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Time Limit is invalid');", true);
            //    return;
            //}
            //else if (Convert.ToInt32(txtremind1.Text) > Convert.ToInt32(time.Text))
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Not allowed to enter more than' + '"+ time.Text  +"' + 'days');", true);
            //    return;
            //}
            //else if (Convert.ToInt32(txtremind1.Text) > Convert.ToInt32(remind2.Text))
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Second Reminder days should be greater than the First Reminder days');", true);
            //    return;
            //}
            //if (Convert.ToInt32(txtremind2.Text) > Convert.ToInt32(remind3.Text))
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Third Reminder days should be greater than the Second Reminder days');", true);
            //    return;
            //}
            //btnDummy_ModalPopupExtender.Hide();
        }
        void load_users()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser   _objcls = new _clsuser ();
            _objcls.project_code = (string)Session["project"];
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsuser _objcl = new _clsuser();
            //_objcl.project_code = (string)Session["project"];
            string project = _objbll.Get_ProjectName(_objcls, _objdb);
            //DataTable _user = _objbll.load_User(_objcls,_objdb);
            //int _service =Convert.ToInt32(myschedule_basket.Rows[0].Cells[8].Text);
            //var list = from o in _user.AsEnumerable()
            //           where o.Field<string>(2) == "Review/Comment" || o.Field<string>(2) == "Review/Comment/Status"
            //           select o;
            int count = 0;

            _clsdocument _objcls1 = new _clsdocument();
            _objcls1.project_code = (string)Session["project"];
            _objcls1.schid = Convert.ToInt32(Label1.Text);
            DataTable _dt = _objbll.load_dms_user_email(_objcls1, _objdb);
            var list = from o in _dt.AsEnumerable()
                       where o.Field<string>(1) == "Review/Comment" || o.Field<string>(1) == "Review/Comment/Status"
                       select o;

            foreach (var row in list)
            {
                //if (row[4].ToString() == _service)
                //{
                //_objcls.uid = row[0].ToString();
                //DataTable _usersrv = _objbll.load_usersrv(_objcls,_objdb);
                //var _srv = from o in _usersrv.AsEnumerable()
                //           where o.Field<int>(0)==_service
                //           select o;
                //foreach (var row1 in _srv)
                //{
                //    if ((string)Session["Rev"] == "Revised")
                //        Send_Mail_Revised(row[0].ToString(), row[2].ToString(), project);
                //    else
                //        Send_Mail(row[0].ToString(), row[2].ToString(), project);
                //}
                //}
                //if(count==0)
                //    Send_Mail("ssurajpdmsn@gmail.com","Review/Comment","trial");
                //count+=1;
                if ((string)Session["Rev"] == "Revised")
                    Send_Mail_Revised(row[0].ToString(), row[1].ToString(), project);
                else
                    Send_Mail(row[0].ToString(), row[1].ToString(), project);
            }
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsuser _objcl = new _clsuser();
            //_objcl.project_code = (string)Session["project"];
            //string project = _objbll.Get_ProjectName(_objcl, _objdb);
            //if ((string)Session["Rev"] == "Revised")
            //    Send_Mail_Revised("ssurajpdmsn@gmail.com", "Review/Comment/Status",project);
            //else
            //    Send_Mail("ssurajpdmsn@gmail.com", "Review/Comment",project);

        }
        void Send_Mail(string user_id,string access,string project)
        {
            
            publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "";
            if (access == "Review/Comment")
            {
                Body = "Ref. " + project + " - " + (string)Session["parent"] + "\n\n" + "This is an automatically generated email to advise you that the O & M noted above has been uploaded to CML web site and is available for review." + "\n\n" + "Could you please find time to review the manual and make any comments using the comment screen within the next " + time.Text + " days." + "\n\n" + "If you review and have no comments on the manual, please confirm with 'No comments' on exit from the website." + "\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            }
            else if (access == "Review/Comment/Status")
            {
                Body = "Ref. " + project + " - " + (string)Session["parent"] + "\n\n" + "This is an automatically generated email to advise you that the O & M noted above has been uploaded to CML web site and is available for review." + "\n\n" + "Could you please find time to review the manual and make any comments using the comment screen within the next " + time.Text + " days." + "\n\n" + "If you review and have no comments on the manual, please confirm with 'No comments' on exit from the website." + "\n\n" + "Thank you in anticipation of co-operation." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            }
            string _sub = "Ref. " + project + " - " + (string)Session["parent"];                
            _objcls.Send_Email(user_id, _sub, Body);
        }
        void Send_Mail_Revised(string user_id, string access,string project)
        {
           
            publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "";
            if (access == "Review/Comment")
            {
                Body = "Ref. " + project + " - " + (string)Session["parent"] + "\n\n" + "This is an automatically generated email to advise you that the O & M noted above has been revised and is now available for further review." + "\n\n" + "Could you please find time to review changes made and make further comment(s) if required." + "\n\n" + "If no further comment(s) are required, please confirm with 'No comments' on exit from the website." + "\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            }
            else if (access == "Review/Comment/Status")
            {
                Body = "Ref. " + project + " - " + (string)Session["parent"] + "\n\n" + "This is an automatically generated email to advise you that the O & M noted above has been uploaded to CML web site and is available for review." + "\n\n" + "Could you please find time to review changes and if acceptable change the status of the manual on exit from the website." + "\n\n" + "Thank you in anticipation of co-operation." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            }
            string _sub = "Ref. " + project + " - " + (string)Session["parent"];
            _objcls.Send_Email(user_id, _sub, Body);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            uploadFiles();
        }

        protected void drpmanufacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Label1.Text = drpmanufacture.SelectedItem.Value;
            load_group();
        }
        private void load_Subgroup()
        {
            //drpsub1.Visible = true;
            //drpsub1.Items.Clear();
            //BLL_Dml _dtobj = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            ////drpsub.DataSource = 
            ////drpsub.DataBind();
            //string _id = drpsub.SelectedItem.Value;
            //DataTable _dtable = _dtobj.load_subgroup(_objdb);
            //var _result = from o in _dtable.AsEnumerable()
            //              where o.Field<int>(5) == Convert.ToInt32(_id)
            //              select o;
            //foreach (var row in _result)
            //{
            //    ListItem _lst = new ListItem();
            //    _lst.Text = row[2].ToString();
            //    _lst.Value = row[0].ToString();
            //    drpsub1.Items.Add(_lst);
            //}
            //if (drpsub1.Items.Count <= 0)
            //{ drpsub1.Visible = false; Label3.Visible = false; }
            //else
            //    Label3.Visible = true;
        }

        protected void drpsub1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void drpsub_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_Subgroup();
        }
        protected void FileUploader1_FileReceived(object sender, com.flajaxian.FileReceivedEventArgs e)
        {
            if (Validate_File(e.File.FileName) == true)
            {
                e.File.SaveAs(Server.MapPath("UploadFolder" + "\\" + e.File.FileName));
               // Multi_Upload(e.File.FileName);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + e.File.FileName + "');", true);
            }
        }
        private bool Validate_File(string _fname)
        {
            string _Doc_type = (string)Session["folder"];
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsuser _objcls = new _clsuser();
            //_objcls.project_code = (string)Session["project"];
            //DataTable _schedule = _objbll.load_schedule(_objcls, _objdb);
            //DataTable _dtable1 = new DataTable();
            //_dtable1.Columns.Add("package");
            //_dtable1.Columns.Add("Folder");
            //_dtable1.Columns.Add("manufacture");
            //_dtable1.Columns.Add("doc_name");
            //_dtable1.Columns.Add("Folder_id");
            //_dtable1.Columns.Add("id");
            //_dtable1.Columns.Add("srv");
            var _List = from o in _dtable.AsEnumerable()
                        where o.Field<int>(5) == Convert.ToInt32(_Doc_type)
                        select o;
            foreach (var row in _List)
            {
                if (_fname == row[3].ToString())
                {
                    FileInfo _finfo = new FileInfo(Server.MapPath("UploadFolder" + "\\" + _fname));
                    if (_finfo.Exists == true) _finfo.Delete();
                    return true;
                }
            }
            return false;
        }
        private void Multi_Upload(string _fname)
        {
            string _Doc_type = (string)Session["folder"];
            var _List = from o in _dtable.AsEnumerable()
                        where o.Field<int>(5) == Convert.ToInt32(_Doc_type)
                        select o;
            try
            {
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "dbCML";
                _clsdocument _objcls = new _clsdocument();
                foreach (var row in _List)
                {
                    if (_fname == row[3].ToString())
                    {
                        FileInfo _finfo = new FileInfo(Server.MapPath("Documents" + "\\" + _fname));
                        if (_finfo.Exists == true)
                        {
                            
                            _objcls.doc_name = row[3].ToString();
                            _objcls.doc_title = row[2].ToString();
                            _objcls.doctype_code = 0;
                            _objcls.package_code = 0;
                            _objcls.uploaded_date = DateTime.Now;
                            _objcls.service_code = 0;
                            _objcls.uploaded = true;
                            _objcls.schid = Convert.ToInt32(row[0].ToString());
                            _objcls.folder_id = Convert.ToInt32(row[5].ToString());
                            string _size = _finfo.Length.ToString();
                            _objcls.file_size = decimal.Round((Convert.ToDecimal(_size) / 1024), 2).ToString() + "KB";
                           // _objcls.file_size = decimal.Round((Convert.ToDecimal(_size) / 1024), 2).ToString() + "KB";
                            _objcls.uid = (string)Session["uid"];
                            _objcls.type = "";
                            _objbll.file_upload(_objcls, _objdb);
                            load_schedule();
                            Get_Schedule();
                            return;

                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                //Label1.Text = ex.ToString();
            }

        }

       
    }
}