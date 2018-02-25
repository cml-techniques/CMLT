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
    public partial class projecthome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if ((string)Session["uid"] != null)
            {
                prj.Text = (string)Session["projectname"]+ " - DMS" ;
                userinfo.Text = "Login as : " + (string)Session["uid"] + " , " ;
            }
            else
                Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                //ImageButton2.Visible = false;
                //Label1.Text = "Welcome to " + (string)Session["projectname"] + " online Operating and Maintenance Manuals";
                prjhead.Src = "images/" + (string)Session["project"] + "head.jpg";
                prjlogo.Src = "images/" + (string)Session["project"] + "logo.jpg";
                Populate_Tree();
                mytree.DataBind();
                SendReminder((string)Session["project"]);
               
                //publicCls.publicCls _obj = new publicCls.publicCls();
                //_obj.SendReminder((string)Session["project"]);
               // mydiv.Style.Add("visibility", "visible");
                //myframe.Style.Add("Visibility", "hidden");
                //pnlom.Style.Add("Visibility", "hidden");
               // mydiv.Style.Add("Visibility", "visible");
                //mydiv.Visible = true;
               // myframe.Visible = false;
                //pnlom.Visible = false;
                //myobject.Visible = false;
            }
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
                            _objbll.Set_Reminder(_obj,_objdb);
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
                            _objbll.Set_Reminder(_obj,_objdb);
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
                            SendRem(row[5].ToString(), _days.ToString(), row[10].ToString(), row[2].ToString(), "Third Reminder", _srv);
                            _objbll.Set_Reminder(_obj,_objdb);
                        }

                    }
                }
                else if(_Diff.Days >= Convert.ToInt32(row[5].ToString()))
                {
                    SendCon(row[5].ToString(), row[10].ToString(), row[2].ToString(), Convert.ToInt32(row[0].ToString()),_srv);
                }

            }
        }
        void SendRem(string _period,string _days, string project, string package, string rem,int _srv)
        {
            string Body = "Ref. " + project + " - " + package + "\n\n" + "This is an automatically generated email to remind you that the O & M noted above has been available for the last " + _period + " days. There is now only " + _days + " days left within the review period." + "\n\n" + "Could you please find time to review the manual and make any comments using the comment screen within the next " + _days + " days." + "\n\n" + "If you have reviewed and have no comments on the manual, please confirm with 'No comments' on exit from the website." + "\n\n" + "Thank you in anticipation of co-operation." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmldubai.com";
            string _sub = "Ref. " + project + " - " + package + " " + rem;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            publicCls.publicCls _obj = new publicCls.publicCls();
            DataTable _user = _objbll.load_User(_objcls,_objdb);
            var list = from o in _user.AsEnumerable()
                       where o.Field<string>(2) == "Review/Comment" || o.Field<string>(2) == "Review/Comment/Status"
                       select o;
            foreach (var row in list)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + row[0].ToString() + "');", true);
                _objcls.uid = row[0].ToString();
                DataTable _usersrv = _objbll.load_usersrv(_objcls,_objdb);
                var serv = from o in _usersrv.AsEnumerable()
                           where o.Field<int>(0)==_srv
                           select o;
                foreach (var row1 in serv)
                {
                    _obj.Send_Email(row[0].ToString(), _sub, Body);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + row[0].ToString() + "');", true);
                }
                //_obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
            }
            _obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
           
        }
        void SendCon(string _days, string project, string package, int _id,int _srv)
        {
            string Body = "Ref. " + project + " - " + package + "\n\n" + "This is an automatically generated email to confirm that the review period for the above O & M has now lapsed." + "\n\n" + "The O & M remains available to view but the comments window is not available." +  "\n\n" + "If you have not reviewed and left any comments, CML will contact you to discuss options that may be available for an extension period to complete the review process." + "\n\n" + "Thank you for your attention and understanding." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmldubai.com";
            string _sub = "Ref. " + project + " - " + package;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            publicCls.publicCls _obj = new publicCls.publicCls();
            DataTable _user = _objbll.load_User(_objcls,_objdb);
            var list = from o in _user.AsEnumerable()
                       where o.Field<string>(2) == "Review/Comment" || o.Field<string>(2) == "Review/Comment/Status"
                       select o;
            foreach (var row in list)
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + row[0].ToString() + "');", true);
                _objcls.uid = row[0].ToString();
                DataTable _usersrv = _objbll.load_usersrv(_objcls,_objdb);
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
            _objbll.SetDocStatus(_objdoc,_objdb);
            _obj.Send_Email("ssurajpdmsn@gmail.com", _sub, Body);
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
            _obj.Load_Tree((string)Session["project"], (string)Session["uid"]);
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
                _root.SelectAction = TreeNodeSelectAction.Expand;
                //_root.NavigateUrl = "javascript:void(0)";
                //_root.NavigateUrl = "javascript:TreeView_ToggleNode(" + mytree.ClientID + "_Data," + 0 + "," + mytree.ClientID + "n" + 0 + ",’ ‘," + mytree.ClientID + "n" + 0 + "Nodes)";
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
                        string type = "0";
                        if (row2[7].ToString()=="1")
                            type = "1";
                        string path = row[2].ToString() + "@" + row1[2].ToString() + "*" + row2[2].ToString();
                        path = path.Replace("&", "<>");
                        _leaf.NavigateUrl = "javascript:openFrame('" + row2[0].ToString() + "_P" + path + row2[7].ToString() + "B" + "','" + type + "')";
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
                            if (row3[7].ToString() == "1")
                                type = "1";
                            else
                                type = "0";
                            path = row[2].ToString() + "@" + row1[2].ToString() + "*" + row2[2].ToString();
                            path = path.Replace("&", "<>");
                            _group.NavigateUrl = "javascript:openFrame('" + row3[0].ToString() + "_P" + path + row2[7].ToString() + "B" + "','" + type + "')";
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
                                path = row[2].ToString() + "@" + row1[2].ToString() + "*" + row2[2].ToString();
                                path = path.Replace("&", "<>");
                                _subgroup.NavigateUrl = "javascript:openFrame('" + row4[0].ToString() + "_P" + path + row3[7].ToString() + "B" + "','" + type + "')";
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
        protected void mytree_SelectedNodeChanged(object sender, EventArgs e)
        {
            //myframe.Style.Add("display", "none");
            //myframe.Visible = false;
            ////myframe.Attributes.Remove("src");
            //mydiv.Visible = true;
            //if (mytree.SelectedNode.Value != "")
            //{
                //mytree.CollapseAll();
                //TreeNode tn = mytree.SelectedNode;
                //tn.Expand(); 
                //while (tn.Parent != null) 
                //{ tn = tn.Parent; tn.Expand(); }

                //if (mytree.SelectedNode.Expanded == true)
                //    mytree.ExpandDepth = 0;
                //else
                //{
                //    //mytree.CollapseAll();
                //    mytree.ExpandDepth = 1;
                //    //mytree.SelectedNode.Expand();
                //}
                //if (mytree.SelectedNode.Depth < 2) return;
                ////myframe.Style.Add("Visibility", "hidden");
                ////mydiv.Style.Add("Visibility", "visible");

                
                string _value = mytree.SelectedNode.Value.ToString();
                
                Session["folder_id"] = _value.Substring(0, _value.IndexOf("#"));
                //Load_document();
                Clear_Selection(mytree.Nodes);

            //myframe.Visible = true;
            //myframe.Attributes.Add("src", "cmlhome.aspx");
            //myframe.Visible = true;
            //Load_document();
                
            //}
        }
        void Clear_Selection(TreeNodeCollection _tnc)
        {
            foreach (TreeNode _tn in _tnc)
            {
                _tn.Selected = false;
                Clear_Selection(_tn.ChildNodes);
            }

        }
        private void Load_document()
        {
            //userinfo.Text = (string)Session["folder_id"];          
            //getPath();
            ////BLL_Dml _objbll = new BLL_Dml();
            ////_clsdocument _objcls = new _clsdocument();
            ////_objcls.folder_id = Convert.ToInt32((string)Session["folder_id"]);
            ////_objcls.enabled = true;
            //int _id = Convert.ToInt32((string)Session["folder_id"]);
            //bool _enable = true;
            //publicCls.publicCls _obj = new publicCls.publicCls();
            //_obj.Load_Documents();
            //if (mytree.SelectedNode.Text == "O & M Manual")
            //{
            //    //myframe.Visible = false;
            //    //myframe.Style.Add("visibility", "hidden");
            //   // mydiv.Style.Add("visibility", "visible");
            //    //myframe.Attributes.Remove("src");
            //    mydocgridom.Visible = true;
            //    //pnlom.Style.Add("Visibility", "visible");
            //    //mydocgridom.Style.Add("Visibility", "visible");
            //    //mydocgridom.DataSource = _objbll.load_document(_objcls);
            //    //mydocgridom.DataBind();
            //    //load_prversion();
            //    //mydocgrid.Style.Add("Visibility", "hidden");
            //    publicCls.publicCls._doctype = "1";
            //    DataTable _dtable1 = new DataTable();
            //    _dtable1.Columns.Add("doc_name");
            //    _dtable1.Columns.Add("uploaded_date");
            //    _dtable1.Columns.Add("file_size");
            //    _dtable1.Columns.Add("version");
            //    _dtable1.Columns.Add("STATUS");
            //    var Result = from o in publicCls.publicCls._dtdocuments.AsEnumerable()
            //                 where o.Field<int>(0) == _id && o.Field<bool>(1) == _enable
            //                 select o;
            //    foreach (var row in Result)
            //    {
            //        DataRow _myrow = _dtable1.NewRow();
            //        _myrow[0] = row[4].ToString();
            //        _myrow[1] = row[6].ToString();
            //        _myrow[2] = row[7].ToString();
            //        _myrow[3] = row[9].ToString();
            //        _myrow[4] = row[11].ToString();
            //        _dtable1.Rows.Add(_myrow);
            //    }
            //    mydocgridom.DataSource = _dtable1;
            //    mydocgridom.DataBind();
            //    DataTable _dtable3 = new DataTable();
            //    _dtable3.Columns.Add("doc_name");
            //    _dtable3.Columns.Add("version");
            //    _dtable3.Columns.Add("comments");
            //    _dtable3.Columns.Add("uploaded_date");
            //    _dtable3.Columns.Add("STATUS");
            //    _enable = false;
            //    var Result3 = from o in publicCls.publicCls._dtdocuments.AsEnumerable()
            //                  where o.Field<int>(0) == _id && o.Field<bool>(1) == _enable
            //                  select o;
            //    foreach (var row in Result3)
            //    {
            //        DataRow _myrow = _dtable3.NewRow();
            //        _myrow[0] = row[4].ToString();
            //        _myrow[1] = row[9].ToString();
            //        _myrow[2] = row[10].ToString();
            //        _myrow[3] = row[6].ToString();
            //        _myrow[4] = row[11].ToString();
            //        _dtable3.Rows.Add(_myrow);
            //    }
            //    gridprv.DataSource = _dtable3;
            //    gridprv.DataBind();
           // }
            
            
        }
        //void load_prversion()

        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _clsdocument _objcls = new _clsdocument();
        //    _objcls.folder_id = Convert.ToInt32((string)Session["folder_id"]);
        //    _objcls.enabled = false;
        //    gridprv.DataSource = _objbll.load_document(_objcls);
        //    gridprv.DataBind();
        //}
        //protected void mydocgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //mydiv.Visible = false;
        //    //myframe.Visible = true;
        //    //int _rowidx = Convert.ToInt32(e.CommandArgument);
        //    //GridViewRow _srow = mydocgrid.Rows[_rowidx];
        //    //TableCell _item = _srow.Cells[0];
        //    //string _file = _item.Text;
        //    //Session["file"] = _item.Text;
        //    //myframe.Attributes.Add("src", "viewdocument.aspx");
        //}
        void getPath()
        {
            //if (mytree.SelectedNode.Depth == 2)
            //{
            //    Label1.Text = mytree.SelectedNode.Parent.Parent.Text + " >> " + mytree.SelectedNode.Parent.Text + " >> " + mytree.SelectedNode.Text;
            //}
            //else
            //    Label1.Text = "";
        }

        //protected void mydocgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    e.Row.Cells[0].Visible = false;
        //}

        int nodeIndex = 0;
        private void ToggleTreeNode(TreeNode node)
        {


            foreach (TreeNode _node in node.ChildNodes)
            {


                if (_node.NavigateUrl == "" || _node.NavigateUrl == string.Empty)
                {

                    _node.NavigateUrl = "javascript:TreeView_ToggleNode(" + mytree.ClientID + "_Data," + nodeIndex + "," + mytree.ClientID + "n" + nodeIndex + ",’ ‘," + mytree.ClientID + "n" + nodeIndex + "Nodes)";


                }


                nodeIndex++;


                if (_node.ChildNodes.Count > 0)


                    ToggleTreeNode(_node);


            }


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            mytree.ExpandAll();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            mytree.ExpandAll();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            //ExpCol("1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //if(Button2.Text=="Expand All")
            //    ExpCol("0");
            //else
            //    ExpCol("1");
        }
        //void ExpCol(string action)
        //{
        //    if (action == "1")
        //    {
        //        foreach (TreeNode _node in mytree.Nodes)
        //        {
        //            _node.CollapseAll();
        //            //if (_node.Expanded == true)
        //            //{
        //            //    _node.CollapseAll();
        //            //    Button2.Text = "Expand All";
        //            //    ImageButton2.Visible = false;
        //            //    ImageButton1.Visible = true;

        //            //}
        //            //else
        //            //{
        //            //    _node.ExpandAll();
                    
        //            Button2.Text = "Expand All";
        //            ImageButton2.Visible = false;
        //            ImageButton1.Visible = true;

        //            //}
        //        }
        //    }
        //    else
        //    {
        //        foreach (TreeNode _node in mytree.Nodes)
        //        {
        //            _node.ExpandAll();
        //            Button2.Text = "Collapse All";
        //            ImageButton2.Visible = true;
        //            ImageButton1.Visible = false;
                  
        //        }
        //    }
        //}
        
       
    }
}