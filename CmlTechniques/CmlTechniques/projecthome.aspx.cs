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
    public partial class projecthome1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
           
            if (!IsPostBack)
            {
                if ((string)Session["uid"] != null)
                {
                    string _prm = Request.QueryString["PRJ"].ToString();
                    lblprj.Text = _prm;
                    Session["project"] = lblprj.Text;
                    GetProjectName(_prm);
                    userinfo.Text = "Login as : " + (string)Session["uid"] + " , ";
                    prjhead.Src = "images/" + lblprj.Text + "top.jpg";
                    Populate_Tree();
                    mytree.DataBind();
                    SendReminder(lblprj.Text);

                }
                else
                    Response.Redirect("Default.aspx");
            }
        }
        private void GetProjectName(string _prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = _prj;
            prj.Text = _objbll.Get_ProjectName(_objcls, _objdb) + " - DMS";
        }
        private void SendReminder(string _project)
        {
            publicCls.publicCls _obj1 = new publicCls.publicCls();
            _obj1.Load_doc_dur();
            DateTime _today = DateTime.Now;
            BLL_Dml _objbll = new BLL_Dml();
            
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocduration _obj = new _clsdocduration();
            var _result = from o in publicCls.publicCls._dtdocdur.AsEnumerable()
                          where o.Field<string>(9) == _project
                          select o;
            //int count = 1;
            foreach (var row in _result)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('yES');", true);
                //return;
                DateTime _upload = Convert.ToDateTime(row[4].ToString());
                TimeSpan _Diff = _today.Subtract(_upload);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ _Diff.Days.ToString() + row[6].ToString() +"');", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" +  + "');", true);
                int _srv = Convert.ToInt32(row[13].ToString());
                _obj.Folder_id = Convert.ToInt32(row[11].ToString());
                if (_Diff.Days.ToString() == row[6].ToString())
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _Diff.Days.ToString() + row[12].ToString() + "');", true);
                    //if (count > 3) return;
                    //count += 1;
                    if (row[12].ToString() != "1")
                    {
                        if (row[6].ToString() != "0")
                        {
                            _obj.Remind = 1;
                            int _days = Convert.ToInt32(row[5].ToString()) - Convert.ToInt32(row[6].ToString());

                            SendRem(row[5].ToString(), _days.ToString(), row[10].ToString(), row[2].ToString(), "First Reminder", _srv);
                            _objbll.Set_Reminder(_obj, _objdb);
                        }
                    }
                }
                else if (_Diff.Days.ToString() == row[7].ToString())
                {
                    if (row[12].ToString() != "2")
                    {
                        if (row[7].ToString() != "0")
                        {
                            _obj.Remind = 2;
                            int _days = Convert.ToInt32(row[5].ToString()) - Convert.ToInt32(row[7].ToString());
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + row[7].ToString() + "');", true);
                            SendRem(row[5].ToString(), _days.ToString(), row[10].ToString(), row[2].ToString(), "Second Reminder", _srv);
                            _objbll.Set_Reminder(_obj, _objdb);
                        }
                    }
                }
                else if (_Diff.Days.ToString() == row[8].ToString())
                {
                    if (row[12].ToString() != "3")
                    {
                        if (row[8].ToString() != "0")
                        {
                            _obj.Remind = 3;
                            int _days = Convert.ToInt32(row[5].ToString()) - Convert.ToInt32(row[8].ToString());
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _Diff.Days.ToString() + "');", true);
                            if (_days > 0)
                            {
                                SendRem(row[5].ToString(), _days.ToString(), row[10].ToString(), row[2].ToString(), "Third Reminder", _srv);
                                _objbll.Set_Reminder(_obj, _objdb);
                            }
                            else
                            {
                                SendCon(row[5].ToString(), row[10].ToString(), row[2].ToString(), Convert.ToInt32(row[0].ToString()), _srv);
                            }
                        }
                    }
                }
                else if (_Diff.Days >= Convert.ToInt32(row[5].ToString()))
                {
                    SendCon(row[5].ToString(), row[10].ToString(), row[2].ToString(), Convert.ToInt32(row[0].ToString()), _srv);
                }
            }
        }
        void SendRem(string _period, string _days, string project, string package, string rem, int _srv)
        {
            if (_days == "0") return;
            string Body = "Ref. " + project + " - " + package + "\n\n" + "This is an automatically generated email to remind you that the O & M noted above has been available for the last " + _period + " days. There is now only " + _days + " days left within the review period." + "\n\n" + "Could you please find time to review the manual and make any comments using the comment screen within the next " + _days + " days." + "\n\n" + "If you have reviewed and have no comments on the manual, please confirm with 'No comments' on exit from the website." + "\n\n" + "Thank you in anticipation of co-operation." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            string _sub = "Ref. " + project + " - " + package + " " + rem;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            publicCls.publicCls _obj = new publicCls.publicCls();
            DataTable _user = _objbll.load_User(_objcls, _objdb);
            var list = from o in _user.AsEnumerable()
                       where o.Field<string>(2) == "Review/Comment" || o.Field<string>(2) == "Review/Comment/Status"
                       select o;
            foreach (var row in list)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + row[0].ToString() + "');", true);
                _objcls.uid = row[0].ToString();
                DataTable _usersrv = _objbll.load_usersrv(_objcls, _objdb);
                var serv = from o in _usersrv.AsEnumerable()
                           where o.Field<int>(0) == _srv
                           select o;
                foreach (var row1 in serv)
                {
                    _obj.Send_Email(row[0].ToString(), _sub, Body);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + row[0].ToString() + "');", true);
                }
                //_obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            }
           // _obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);

        }
        void SendCon(string _days, string project, string package, int _id, int _srv)
        {
            string Body = "Ref. " + project + " - " + package + "\n\n" + "This is an automatically generated email to confirm that the review period for the above O & M has now lapsed." + "\n\n" + "The O & M remains available to view but the comments window is not available." + "\n\n" + "If you have not reviewed and left any comments, Please contact CML to discuss options that may be available for an extension period to complete the review process." + "\n\n" + "Thank you for your attention and understanding." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "https://cmltechniques.com";
            string _sub = "Ref. " + project + " - " + package;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            publicCls.publicCls _obj = new publicCls.publicCls();
            DataTable _user = _objbll.load_User(_objcls, _objdb);
            var list = from o in _user.AsEnumerable()
                       where o.Field<string>(2) == "Review/Comment" || o.Field<string>(2) == "Review/Comment/Status"
                       select o;
            foreach (var row in list)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + row[0].ToString() + "');", true);
                _objcls.uid = row[0].ToString();
                DataTable _usersrv = _objbll.load_usersrv(_objcls, _objdb);
                var serv = from o in _usersrv.AsEnumerable()
                           where o.Field<int>(0) == _srv
                           select o;
                foreach (var row1 in serv)
                {
                    _obj.Send_Email(row[0].ToString(), _sub, Body);
                }
                //_obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            }
            _clsdocument _objdoc = new _clsdocument();
            _objdoc.doc_id = _id;
            _objdoc.status = "REVISED";
            _objbll.SetDocStatus(_objdoc, _objdb);
            //_obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
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
        private void Populate_Tree()
        {
            publicCls.publicCls _obj = new publicCls.publicCls();
            _obj.Load_Tree(lblprj.Text, (string)Session["uid"]);
            mytree.Nodes.Clear();
            //BLL_Dml _dtobj = new BLL_Dml();
            //_clsuser  _objcls = new _clsuser ();
            //_objcls.project_code = (string)Session["project"];
            //_objcls.uid = (string)Session["uid"];
            //_dtservice = _dtobj.load_service(_objcls);
            //_dtpackage = _dtobj.load_package();
            //_dtdoctype = _dtobj.load_doctype();
            //_dtgroup = _dtobj.load_group();
            //_dtsubgroup = _dtobj.load_subgroup();
            //_dtsubgroup1 = _dtobj.load_subgroup1();
            //"<span onclick='return false;'>" + dsTreeSet.Tables[0].Rows[i]["TextField"].ToString() + "</span>"; 

            var _service = from o in publicCls.publicCls._dtservice.AsEnumerable()
                           select o;
            foreach (var row in _service)
            {
                TreeNode _root = new TreeNode();
                //_root.Text = "<span href='exp_coll(0)' onclick='javascript:exp_coll(0);' >" + row[2].ToString() + "</span>";
                _root.Text = row[2].ToString();
                _root.Value = row[0].ToString() + "#" + row[4].ToString();
                //_root.SelectAction = TreeNodeSelectAction.Expand;
                //_root.NavigateUrl = "javascript:void(0)";
                //_root.NavigateUrl = "javascript:TreeView_ToggleNode(" + mytree.ClientID + "_Data," + 0 + "," + mytree.ClientID + "n" + 0 + ",’ ‘," + mytree.ClientID + "n" + 0 + "Nodes)";
                if (row[3].ToString() == "10")
                {
                    _root.SelectAction = TreeNodeSelectAction.Select;
                    string _prm = lblprj.Text + "_P" + row[7].ToString();
                    _root.NavigateUrl = "javascript:openView('" + _prm + "')";
                }
                else
                {
                    _root.SelectAction = TreeNodeSelectAction.Expand;
                }

                if (_root.Text != "")
                    mytree.Nodes.Add(_root);
                var _package = from o in publicCls.publicCls._dtpackage.AsEnumerable()
                               where o.Field<int>(5) == Convert.ToInt32(row[0].ToString())
                               select o;

                foreach (var row1 in _package)
                {
                    TreeNode _parent = new TreeNode();
                    _parent.Text = row1[2].ToString();
                    _parent.Value = row1[0].ToString() + "#" + row1[4].ToString();
                    _parent.SelectAction = TreeNodeSelectAction.Expand;
                    //_parent.NavigateUrl = "javascript:void(0)";
                    if (_parent.Text != "")
                        _root.ChildNodes.Add(_parent);
                    var _doctype = from o in publicCls.publicCls._dtdoctype.AsEnumerable()
                                   where o.Field<int>(5) == Convert.ToInt32(row1[0].ToString())
                                   select o;
                    foreach (var row2 in _doctype)
                    {
                        TreeNode _leaf = new TreeNode();
                        _leaf.Text = row2[2].ToString();
                        _leaf.Value = row2[0].ToString() + "#" + row2[4].ToString();
                        //_leaf.SelectAction = TreeNodeSelectAction.Select;
                        string type = row2[7].ToString();
                        if (row2[7].ToString() == "1")
                            type = "1";
                        string path = row[2].ToString() + "@" + row1[2].ToString() + "*" + row2[2].ToString();
                        path = path.Replace("&", "<>");
                        _leaf.NavigateUrl = "javascript:openFrame('" + row2[0].ToString() + "_P" + path + row2[7].ToString() + "_B" + "','" + type + "')";
                        if (_leaf.Text != "")
                            _parent.ChildNodes.Add(_leaf);
                        var Group = from o in publicCls.publicCls._dtgroup.AsEnumerable()
                                    where o.Field<int>(5) == Convert.ToInt32(row2[0].ToString())
                                    select o;
                        foreach (var row3 in Group)
                        {
                            TreeNode _group = new TreeNode();
                            _group.Text = row3[2].ToString();
                            _group.Value = row3[0] + "#" + row3[4].ToString();
                            if (row2[7].ToString() == "1")
                                type = "1";
                            else
                                type = row2[7].ToString();
                            path = row[2].ToString() + "@" + row1[2].ToString() + "*" + row3[2].ToString();
                            path = path.Replace("&", "<>");
                            _group.NavigateUrl = "javascript:openFrame('" + row3[0].ToString() + "_P" + path + row2[7].ToString() + "_B" + "','" + type + "')";
                            if (_group.Text != "")
                                _leaf.ChildNodes.Add(_group);
                            var subgroup = from o in publicCls.publicCls._dtsubgroup.AsEnumerable()
                                           where o.Field<int>(5) == Convert.ToInt32(row3[0].ToString())
                                           select o;
                            foreach (var row4 in subgroup)
                            {
                                TreeNode _subgroup = new TreeNode();
                                _subgroup.Text = row4[2].ToString();
                                _subgroup.Value = row4[0] + "#" + row4[4].ToString();
                                path = row[2].ToString() + "@" + row1[2].ToString() + "*" + row4[2].ToString();
                                path = path.Replace("&", "<>");
                                type = row2[7].ToString();
                                _subgroup.NavigateUrl = "javascript:openFrame('" + row4[0].ToString() + "_P" + path + row3[7].ToString() + "_B" + "','" + type + "')";
                                if (_subgroup.Text != "")
                                    _group.ChildNodes.Add(_subgroup);
                                var subgroup1 = from o in publicCls.publicCls._dtsubgroup1.AsEnumerable()
                                                where o.Field<int>(5) == Convert.ToInt32(row4[0].ToString())
                                                select o;
                                foreach (var row5 in subgroup1)
                                {
                                    TreeNode _subgroup1 = new TreeNode();
                                    _subgroup1.Text = row5[2].ToString();
                                    _subgroup1.Value = row5[0] + "#" + row5[4].ToString();
                                    if (_subgroup1.Text != "")
                                        _subgroup.ChildNodes.Add(_subgroup1);
                                }
                            }

                        }

                    }
                }
            }
            mytree.CollapseAll();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Log_off();
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "logoff();", true);
        }
        void _toDeleteCookies()
        {
            //if (Request.Browser.Cookies)
            //{
            //    string[] _cookies = Request.Cookies.AllKeys;
            //    foreach (string cookie in _cookies)
            //    {
            //        Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-10);
            //    }
            //}

            if (Request.Cookies["uid"] != null)
            {
                HttpCookie _CookieUid = new HttpCookie("uid");
                _CookieUid.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookieUid);
            }
            if (Request.Cookies["pwd"] != null)
            {
                HttpCookie _CookiePwd = new HttpCookie("pwd");
                _CookiePwd.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookiePwd);
            }
            if (Request.Cookies["chk"] != null)
            {
                HttpCookie _CookieChk = new HttpCookie("chk");
                _CookieChk.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookieChk);
            }
            if (Request.Cookies["access"] != null)
            {
                HttpCookie _CookieUaccess = new HttpCookie("access");
                _CookieUaccess.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookieUaccess);
            }
            if (Request.Cookies["group"] != null)
            {
                HttpCookie _CookieUgroup = new HttpCookie("group");
                _CookieUgroup.Expires = DateTime.Now.AddDays(-10);
                Response.Cookies.Add(_CookieUgroup);
            }
        }
        void Log_off()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clslog _objcls = new _clslog();
            _objcls.uid = (string)Session["uid"];
            string _logout = Request.Form["_logout"].ToString();
            _objcls.logout = _logout;
            _objbll.LOG_OUT(_objcls, _objdb);
            _toDeleteCookies();
        }

        protected void btnindex_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Yes! You Have Clicked')", true);
            myframe.Attributes.Add("src", "OMIndex.aspx?PRJ=" + lblprj.Text);
        }
        
    }
}
