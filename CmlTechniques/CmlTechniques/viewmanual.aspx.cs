using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques
{
    public partial class viewmanual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                Label2.Text = _prm;
                load_document();
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
                if (Request.Cookies["cfile"] != null)
                {
                    Session["cfile"] = Server.HtmlEncode(Request.Cookies["cfile"].Value);
                }
                if (Request.Cookies["file"] != null)
                {
                    Session["file"] = Server.HtmlEncode(Request.Cookies["file"].Value);
                }
                if (Request.Cookies["access"] != null)
                {
                    Session["access"] = Server.HtmlEncode(Request.Cookies["access"].Value);
                }
                if (Request.Cookies["id"] != null)
                {
                    Session["id"] = Server.HtmlEncode(Request.Cookies["id"].Value);
                }



            }
        }

        protected void cmdadd_Click(object sender, EventArgs e)
        {
            //lbstatus.Text = "ok";            
            //comment_basket _objbasket = new comment_basket();
            //_objbasket.Insert(txtpno.Text, txtsno.Text, txtcmnt.Text,(string)Session["uid"]);
            //mybasket.DataBind();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscomment _objcls = new _clscomment();
            _objcls.page_no = txtpno.Text;
            _objcls.sec_no = txtsno.Text;
            _objcls.comment = txtcmnt.Text;
            _objcls.user_id = (string)Session["uid"];
            _objcls.prj_code = (string)Session["project"];
            _objcls.module = "DMS";
            _objcls.type = 1;//for OM
            _objcls.doc_id = Convert.ToInt32((string)Session["id"]);
            _objbll.addtobasket(_objcls,_objdb);
            load_Basket();
            txtpno.Text = "";
            txtsno.Text = "";
            txtcmnt.Text = "";
        }
        void load_Basket()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscomment _objcls = new _clscomment();
            _objcls.user_id = (string)Session["uid"];
            _objcls.prj_code = (string)Session["project"];
            _objcls.module = "DMS";
            _objcls.type = 1;//for OM
            _objcls.doc_id = Convert.ToInt32((string)Session["id"]);            
            mybasket.DataSource = _objbll.load_commentbasket(_objcls,_objdb);
            mybasket.DataBind();
        }
        private void load_document()
        {
            Session["cfile"] = (string)Session["file"];
            
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["file"] + "');", true);
            //_ReadCookies();
                GetDuration();
                load_status();
                load_Basket();
            //comment_basket _obj = new comment_basket();
            //_obj.clear();
            //lbstatus.Text = (string)Session["file"];
                myframe.Attributes.Add("src", "viewdocument.aspx?id=0");

        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _Cookiefile = new HttpCookie("file");
                _Cookiefile.Value = (string)Session["file"];
                _Cookiefile.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookiefile);
                HttpCookie _Cookieid = new HttpCookie("id");
                _Cookieid.Value = (string)Session["id"];
                _Cookieid.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookieid);
                HttpCookie _Cookiecfile = new HttpCookie("cfile");
                _Cookiecfile.Value = (string)Session["cfile"];
                _Cookiecfile.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Cookiecfile);
            }
            else
                return;
        }
        void GetDuration()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
           // _objcls.doc_name = (string)Session["file"];
            _objcls.doc_id = Convert.ToInt32(Label2.Text);
            DataTable _dtduration = _objbll.LoadDocDatails(_objcls,_objdb);
            var _service = from o in _dtduration.AsEnumerable()
                           select o;
            DateTime _date = DateTime.Now;
            int duration = 0;
            foreach (var row in _service)
            {
                _date = Convert.ToDateTime(row[1].ToString());
                if(row[2].ToString()!="")
                    duration = Convert.ToInt32(row[2].ToString());
                //_Create_Cookies();
                lbstatus.Text = row[3].ToString();
                lblsrv.Text=row["service_code"].ToString();
                //if(lbstatus.Text != "ACCEPTED")
                //    duration = Convert.ToInt32(row[2].ToString());
            }
            System.TimeSpan diff = DateTime.Now.Subtract(_date);
            if (duration <= diff.Days )
            {
                lbduration.Text = "DOCUMENT IS CLOSED";
                //lbstatus.Text = "CLOSSED";
                mydiv.Visible = false;                
            }
            else
            {
                lbduration.Text = (duration - diff.Days).ToString() + " DAYS REMAINING FOR REVIEWING";
            }
            if (lbduration.Text != "DOCUMENT IS CLOSED")
            {
                cmdsave.Visible = true;
                
                if ((string)Session["access"] == "Review/Comment")
                {
                    mydiv.Visible = false;
                    //mydiv1.Visible = false;
                }
                else
                {
                    mydiv.Visible = true;    
                    //mydiv1.Visible = true;
                }
            }
            else
            {
                if ((string)Session["access"] != "Review/Comment")
                {
                    mydiv1.Visible = true;
                    cmdsave.Visible = true;
                    cmdsave.Text = "Update Status";
                }
                else
                    cmdsave.Visible = false;
                mydiv.Visible = false;
               
            }

        }

        protected void mybasket_RowDataBound(object sender, GridViewRowEventArgs e)
        {
                if (e.Row.RowType == DataControlRowType.DataRow)
                    e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

                e.Row.Cells[4].Visible = false;
        }
        protected void btnYes_Click(object sender, EventArgs e)
        {
            //Response.Redirect("projectdetails.aspx");
            btnDummy_ModalPopupExtender.Hide();
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "", "window.location.href='projecthome.aspx'", true);

           Save_Comments();
           btnDummy_ModalPopupExtender.Hide();
           Response.Redirect("DMS.aspx?PRJ=" + (string)Session["project"]);
        }

        protected void cmdsave_Click(object sender, EventArgs e)
        {
            _ReadCookies();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('"+ (string)Session["access"] +"');", true);
            if ((string)Session["access"] == "Review/Comment/Status" || (string)Session["access"] == "Admin")
            {
                //if (drstatus.Text == "-- Status --")
                //{

                //    btnDummy_ModalPopupExtender.Show();
                //}
                //else
                //{
                    ChangeStatus();
                    Save_Comments();

                //}
            }
            else
                Save_Comments();
            Response.Redirect("DMS.aspx?PRJ=" + (string)Session["project"]);

        }
        void load_status()
        {
            drstatus.Items.Add("ACCEPTED");
            drstatus.Items.Add("ACCEPTED WITH COMMENTS");
            drstatus.Items.Add("REJECTED");
            //drstatus.Items.Add("REVISED");
            drstatus.Items.Insert(0, "-- Status --");
        }
        void Save_Comments()
        {
            if (mybasket.Rows.Count <= 0) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscomment _objcls = new _clscomment();
            for (int i = 0; i <= mybasket.Rows.Count - 1; i++)
            {
                _objcls.com_date = DateTime.Now;
                _objcls.comment = mybasket.Rows[i].Cells[3].Text;
                _objcls.page_no = mybasket.Rows[i].Cells[1].Text;
                _objcls.sec_no = mybasket.Rows[i].Cells[2].Text;
                _objcls.doc_id =Convert.ToInt32((string)Session["id"]);
                _objcls.user_id = (string)Session["uid"];
                _objbll.addcomment(_objcls,_objdb);
            }
            ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Comment Saved!');", true);
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcl = new _clsuser();
            _objcl.project_code = (string)Session["project"];
            string project = _objbll.Get_ProjectName(_objcl, _objdb);
            Send_Acknow(project);            
            //comment_basket _obj = new comment_basket();
            //_obj.clear();
            mybasket.DataSource = "";
            mybasket.DataBind();
            Send_Admin(project);
            //Response.Redirect("projecthome.aspx");
            btnDummy_ModalPopupExtender.Hide();
            Response.Redirect("DMS.aspx?PRJ=" + (string)Session["project"]);
            //ScriptManager.RegisterStartupScript(this, typeof(string), "", "window.location.href='projecthome.aspx'", true);
        }
        void ChangeStatus()
        {
            if (drstatus.SelectedItem.Text == "-- Status --") return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32((string)Session["id"]);
            _objcls.status = drstatus.SelectedItem.Text;
            _objbll.SetDocStatus(_objcls,_objdb);
        }

        protected void cmdadd1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DMS.aspx?PRJ=" + (string)Session["project"]);
        }
        void load_users()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_clsuser _objcls = new _clsuser();
            //_objcls.project_code = (string)Session["project"];
            //DataTable _user = _objbll.load_User(_objcls);
            ////string _service = drppackages.SelectedValue.ToString();

            //var list = from o in _user.AsEnumerable()
            //           select o;

            //foreach (var row in list)
            //{
            //    //if (row[3].ToString().Contains(_service) == true)
            //    //{
            //    Send_Notification(row[0].ToString());
            //    //}
            //}


        }
        void Send_Acknow(string project)
        {
            publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "This is an automatically generated email to confirm CML Techniques are in receipt of your comments made for the above manual." + "\n\n" + "The comments will receive attention and the manual will be revised as required." + "\n\n" + "Thank you in anticipation of your co-operation with the review process." + "\n\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            string _sub = "Ref. " + project + " - " + ((string)Session["cfile"]).Substring(0, ((string)Session["cfile"]).Length - 3);
            _objcls.Send_Email((string)Session["uid"], _sub, Body);

        }
        void Send_Admin(string project)
        {
            //publicCls.publicCls _objcls = new publicCls.publicCls();
            string Body = "To: CML Techniques Project Managers," + "\n\n" + "Ref. " + (string)Session["projectname"] + " - " + ((string)Session["cfile"]).Substring(0, ((string)Session["cfile"]).Length - 3) + "\n\n" + "A comment(s) has been made on the above manual by " + (string)Session["uid"]  + "\n" + "Please consider the comment(s) and revise the O & M appropriate." + "\n\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            string _sub = "Ref. " + project + " - " + ((string)Session["cfile"]).Substring(0, ((string)Session["cfile"]).Length - 3);

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objusr = new _clsuser();
            _objusr.project_code = (string)Session["project"];
            publicCls.publicCls _obj = new publicCls.publicCls();
            _clsdocument _objcls1 = new _clsdocument();
            _objcls1.project_code = (string)Session["project"];
            _objcls1.schid = Convert.ToInt32(lblsrv.Text);
            DataTable _dt = _objbll.load_dms_user_email(_objcls1, _objdb);
            var list = from o in _dt.AsEnumerable()
                       where o.Field<string>(1) == "Review/Comment" || o.Field<string>(1) == "Review/Comment/Status"
                       select o;
            foreach (var row in list)
            {
                _obj.Send_Email(row[0].ToString(), _sub, Body);
            }
           // _obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
        }

        protected void mybasket_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowidx = Convert.ToInt32(e.CommandArgument);
            GridViewRow _srow = mybasket.Rows[_rowidx];
            TableCell _id = _srow.Cells[4];
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscomment _objcls = new _clscomment();
            _objcls.comm_id = Convert.ToInt32(_id.Text);
            _objbll.Remove_basket(_objcls,_objdb);
            load_Basket();
        }
    }
}
