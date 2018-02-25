using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques
{
    public partial class managetree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                Populate_Tree();
                myframe.Attributes.Add("src", "managetreeSub.aspx?id=0");
                Session["possition"] = "0";
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
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        

        protected void cmdsave_Click(object sender, EventArgs e)
        {
            
        }
        void Clear()
        {
            
        }
        void Load_Service()
        {
            
        }
        //DataTable _dtservice;
        //DataTable _dtpackage;
        //DataTable _dtdoctype;
        //DataTable _dtgroup;
        //DataTable _dtsubgroup;
        //DataTable _dtsubgroup1;
        private void Populate_Tree()
        {
           // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["project"] + "');", true);
            mytree.Nodes.Clear();
            //BLL_Dml _dtobj = new BLL_Dml();
            //_clsuser  _objcls = new _clsuser ();
            //_objcls.project_code = (string)Session["project"];
            //_objcls.uid = "nothing";
            //_dtservice = _dtobj.load_service(_objcls);
            //_dtpackage = _dtobj.load_package();
            //_dtdoctype = _dtobj.load_doctype();
            //_dtgroup = _dtobj.load_group();
            //_dtsubgroup = _dtobj.load_subgroup();
            //_dtsubgroup1 = _dtobj.load_subgroup1();
            
            publicCls.publicCls _obj = new publicCls.publicCls();
            _obj.Load_Tree((string)Session["project"],"nothing");
            var _service = from o in publicCls.publicCls._dtservice.AsEnumerable()
                           select o;
            string folder = "";
            foreach (var row in _service)
            {
                TreeNode _root = new TreeNode();
                _root.Text = row[2].ToString();
                _root.Value = row[0].ToString()+ "#" + row[4].ToString();
                _root.SelectAction = TreeNodeSelectAction.Expand;
                folder = row[2].ToString().Replace("&", "<>");
                _root.NavigateUrl = "javascript:openFrame('" + row[0].ToString() + "_L" + row[4].ToString() + "_N" + folder + "_P" + "0" + "_D1" + "')";
                if (_root.Text != "")
                    mytree.Nodes.Add(_root);
                var _package = from o in publicCls.publicCls._dtpackage.AsEnumerable()
                               where o.Field<int >(5) == Convert.ToInt32( row[0].ToString())
                               select o;

                foreach (var row1 in _package)
                {
                    TreeNode _parent = new TreeNode();
                    _parent.Text = row1[2].ToString();
                    _parent.Value = row1[0].ToString() + "#" + row1[4].ToString();
                    _parent.SelectAction = TreeNodeSelectAction.Expand;
                    folder = row1[2].ToString().Replace("&", "<>");
                    _parent.NavigateUrl = "javascript:openFrame('" + row1[0].ToString() + "_L" + row1[4].ToString() + "_N" + folder + "_P" + row[0].ToString() + "_D2" + "')";
                    if (_parent.Text != "")
                        _root.ChildNodes.Add(_parent);
                    var _doctype = from o in publicCls.publicCls._dtdoctype.AsEnumerable()
                                   where o.Field<int>(5) == Convert.ToInt32( row1[0].ToString())
                                   select o;
                    foreach (var row2 in _doctype)
                    {
                        TreeNode _leaf = new TreeNode();
                        _leaf.Text = row2[2].ToString();
                        _leaf.Value = row2[0].ToString() + "#" + row2[4].ToString();
                        _leaf.SelectAction = TreeNodeSelectAction.Expand;
                        folder = row2[2].ToString().Replace("&", "<>");
                        _leaf.NavigateUrl = "javascript:openFrame('" + row2[0].ToString() + "_L" + row2[4].ToString() + "_N" + folder +"_P" + row1[0].ToString() + "_D3" + "' )";
                        if (_leaf.Text != "")
                            _parent.ChildNodes.Add(_leaf);
                        var Group = from o in publicCls.publicCls._dtgroup.AsEnumerable()
                                    where o.Field<int>(5) == Convert.ToInt32( row2[0].ToString())
                                    select o;
                        foreach (var row3 in Group)
                        {
                            TreeNode _group = new TreeNode();
                            _group.Text = row3[2].ToString();
                            _group.Value = row3[0].ToString() + "#" + row3[4].ToString();
                            _group.SelectAction = TreeNodeSelectAction.Expand;
                            folder = row3[2].ToString().Replace("&", "<>");
                            _group.NavigateUrl = "javascript:openFrame('" + row3[0].ToString() + "_L" + row3[4].ToString() + "_N" + folder + "_P" + row2[0].ToString() + "_D4" + "')";
                            if (_group.Text != "")
                                _leaf.ChildNodes.Add(_group);
                            var subgroup = from o in publicCls.publicCls._dtsubgroup.AsEnumerable()
                                         where o.Field<int>(5) == Convert.ToInt32( row3[0].ToString())
                                         select o;
                            foreach (var row4 in subgroup)
                            {
                                TreeNode _subgroup = new TreeNode();
                                _subgroup.Text = row4[2].ToString();
                                _subgroup.Value = row4[0].ToString() + "#" + row4[4].ToString();
                                _subgroup.SelectAction = TreeNodeSelectAction.Expand;
                                folder = row4[2].ToString().Replace("&", "<>");
                                _subgroup.NavigateUrl = "javascript:openFrame('" + row4[0].ToString() + "_L" + row4[4].ToString() + "_N" + folder + "_P" + row3[0].ToString() + "_D5" + "')";
                                if (_subgroup.Text != "")
                                    _group.ChildNodes.Add(_subgroup);
                                var subgroup1 = from o in publicCls.publicCls._dtsubgroup1.AsEnumerable()
                                                where o.Field<int>(5) == Convert.ToInt32( row4[0].ToString())
                                                select o;
                                foreach (var row5 in subgroup1)
                                {
                                    TreeNode _subgroup1 = new TreeNode();
                                    _subgroup1.Text = row5[2].ToString();
                                    _subgroup1.Value = row5[0].ToString() + "#" + row5[4].ToString();
                                    _subgroup1.SelectAction = TreeNodeSelectAction.Expand;
                                    folder = row5[2].ToString().Replace("&", "<>");
                                    _subgroup1.NavigateUrl = "javascript:openFrame('" + row5[0].ToString() + "_L" + row5[4].ToString() + "_N" + folder + "_P" + row4[0].ToString() + "_D6" + "')";
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
        void getPath(string _value)
        {
            //BLL_Dml _dtobj = new BLL_Dml();
            //_clsuser  _objcls = new _clsuser ();
            //_objcls.project_code = (string)Session["project"];
            //_objcls.uid = "nothing";
            ////_dtservice = _dtobj.load_service(_objcls);
            ////_dtpackage = _dtobj.load_package();
            ////_dtdoctype = _dtobj.load_doctype();
            //string _srv_code="";
            //string _pkg_code = "";
            //string _doc_code = "";
            //string _path = "";
            //Session["possition"] = _value.Substring(_value.IndexOf("#")+1);
            //if (_value.Length < 1) return;
            //else
            //    _srv_code = _value.Substring(0, 1);
            //var _service = from o in _dtservice.AsEnumerable()
            //               where o.Field<string>(1) == _srv_code
            //               select o;
            //foreach (var row in _service)
            //    _path = row[2].ToString();
            //if (_value.Length < 4)
            //{
            //    //Label1.Text = _path;
            //    Session["level"] = "1";
            //    return;
            //}
            //else
            //    _pkg_code = _value.Substring(1, 4);
            //var _package = from o in _dtpackage.AsEnumerable()
            //               where o.Field<string>(1) == _pkg_code
            //               select o;
            //foreach (var row1 in _package)
            //    _path = _path + " >> " + row1[2].ToString();
            //if (_value.Length < 8)
            //{
            //    //Label1.Text = _path;
            //    Session["level"] = "2";
            //    return;
            //}
            //else
            //    _doc_code = _value.Substring(5, 1);
            //var _doctype = from o in _dtdoctype.AsEnumerable()
            //               where o.Field<string>(1) == _doc_code
            //               select o;
            //foreach (var row2 in _doctype)
            //    _path = _path + " >> " + row2[2].ToString();

            ////Label1.Text = _path;
            //Session["level"] = "3";
            ////Label1.Text = (string)Session["possition"];
            ////Label1.Text = _value.Substring(_value.IndexOf("#"));
            ////Label1.Text = _value;
        }

        protected void mytree_SelectedNodeChanged(object sender, EventArgs e)
        {
            //Label1.Text = mytree.SelectedNode.ValuePath.ToString();
            //getPath(mytree.SelectedNode.Value.ToString());
            if (mytree.SelectedNode.Depth < 2) return;
            string _value = mytree.SelectedNode.Value.ToString();
            Session["possition"] = _value.Substring(_value.IndexOf("#") + 1);
            Session["folder_id"]=_value.Substring(0,_value.IndexOf("#")) ;
           // mytree.SelectedNode.Checked = true;
            mytree.SelectedNode.Selected = true;
            //Panel1.Visible = false;
            //txtfolder.Text = "";
            //Label1.Text=(string)Session["id"];
            load_documents();
            
        }
        void load_documents()
        {
            if (mytree.SelectedNode.Depth < 2) return;
            BLL_Dml _objbll = new BLL_Dml();
            _clsdocument _objcls = new _clsdocument();
            _objcls.folder_id = Convert.ToInt32((string)Session["folder_id"]);
            _objcls.enabled = true;
            //mygrid.DataSource = _objbll.load_document(_objcls);
            //mygrid.DataBind();

        }
        protected void mytree_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            //Label1.Text = mytree.SelectedNode.Value.ToString();
        }
        public string _value = "";
        protected void cmdnewfolder_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            ////_menu = "1";
            //Session["_menu"] = "1";
            //txtfolder.Text = "";
            //pnledit.Visible = false;
        }

        protected void cmdsubfolder_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            //Session["_menu"] = "2";
            //txtfolder.Text = "";
            //pnledit.Visible = false;
        }

        protected void cmdedit_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            //Session["_menu"] = "3";
            //txtfolder.Text = mytree.SelectedNode.Text;
            //rdbrename.Checked = false;
            //rdbmove.Checked = false;
            //rdbdelete.Checked = false;
            //txtpossition.Visible = false;
            //txtrename.Visible = false;
            //pnledit.Visible = true ;
        }

        protected void cmddelete_Click(object sender, EventArgs e)
        {
            //Panel1.Visible = true;
            //Session["_menu"] = "4";
            //txtfolder.Text = mytree.SelectedNode.Text;
            //pnledit.Visible = false;
        }
        void Continue_()
        {
            //Label1.Text = mytree.SelectedNode.Depth.ToString();
//------------------------------------------------ Existing ----------------------------------------//

            //Label1.Text = Label1.Text.Substring(0, Label1.Text.IndexOf(">>") - 1).Trim();
            //string _temp = Label1.Text.Substring(Label1.Text.IndexOf(">>") + 2).Trim();
            //Label1.Text = _temp.Substring(_temp.IndexOf(">>") + 2).Trim();
            //BLL_Dml _objbll = new BLL_Dml();
            //_clsManageTree _objcls = new _clsManageTree();
            //string _menu = (string)Session["_menu"];
            //string _level = (string)Session["level"];
            //string _possition = (string)Session["possition"];
           
            //if (_menu == "1")//create new folder
            //{
            //    _objcls.desciption = txtfolder.Text;
            //    _objcls.possition = Convert.ToInt32(_possition);
            //    if (_level == "1")
            //    {
            //        _objcls.service = "";
            //        try
            //        {
            //            _objbll.Create_Service(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }
            //    }
            //    else if (_level == "2")
            //    {
            //        _objcls.service = Label1.Text.Substring(0, Label1.Text.IndexOf(">>") - 1).Trim();
            //        try
            //        {
            //            _objbll.Create_Package(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }
            //    }
            //    else if (_level == "3")
            //    {
            //        _objcls.service = "";
            //        try
            //        {
            //            _objbll.Create_DocType(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }
            //    }
            //}
            //else if (_menu == "2")//create sub folder
            //{
            //    _objcls.desciption = txtfolder.Text;
            //    if (_level == "1")
            //    {
            //        _objcls.service = Label1.Text;
            //        _objcls.possition = 0;
            //        try
            //        {
            //            _objbll.Create_Package(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }

            //    }
            //    else if (_level == "2")
            //    {
            //        _objcls.service = "";
            //        _objcls.possition = 0;
            //        try
            //        {
            //            _objbll.Create_DocType(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }
            //    }
            //    else if (_level == "3")
            //    {
            //        string _temp = Label1.Text.Substring(Label1.Text.IndexOf(">>") + 2).Trim();
            //        //Label1.Text = _temp.Substring(_temp.IndexOf(">>") + 2).Trim();
            //        //string _temp = Label1.Text.Substring(0, Label1.Text.IndexOf(">>") - 1).Trim();
            //        _objcls.service = _temp.Substring(_temp.IndexOf(">>") + 3).Trim();
            //        _objcls.possition = 0;
            //        try
            //        {
            //            _objbll.Create_Group(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }
            //    }
            //}
            //else if (_menu == "3")
            //{
            //    _objcls.desciption = txtfolder.Text;
            //    _objcls.possition =Convert.ToInt32(txtpossition.Text);                
            //    if (_level == "1")
            //    {
            //        //Label1.Text = mytree.SelectedNode.Value.Substring(0, mytree.SelectedNode.Value.IndexOf("#"));
            //        _objcls.code = mytree.SelectedNode.Value.Substring(0,mytree.SelectedNode.Value.IndexOf("#"));
            //        _objcls.service = "";
            //        _objcls.mode = 1;
            //        try
            //        {
            //            _objbll.Edit_Service(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }
            //    }
            //    else if (_level == "2")
            //    {
            //        _objcls.service = Label1.Text.Substring(0, Label1.Text.IndexOf(">>") - 1).Trim();
            //        _objcls.code = mytree.SelectedNode.Value.Substring(1, mytree.SelectedNode.Value.IndexOf("#") - 1);
            //        _objcls.mode = 1;
            //        //Label1.Text = Label1.Text.Substring(0, Label1.Text.IndexOf(">>") - 1).Trim();
            //        try
            //        {
            //            _objbll.Edit_Package(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }
            //    }
            //    else if (_level == "3")
            //    {
            //        _objcls.service = "";
            //        try
            //        {
            //            _objbll.Create_DocType(_objcls);
            //        }
            //        catch (Exception ex)
            //        {
            //            Label1.Text = ex.ToString();
            //        }
            //    }
            //}
            //Populate_Tree();
            //txtfolder.Text = "";
//------------------------------------------------- end of existing -------------------------------//
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clstreefolder _objcls = new _clstreefolder();

            try
            {
                string _menu = (string)Session["_menu"];
                //string _level = (string)Session["level"];
                int _level = 1;
                //if (mytree.Nodes.Count > 0)
                //{
                //    _level = Convert.ToInt32(mytree.SelectedNode.Depth.ToString()) + 1;
                //}
                string _possition = (string)Session["possition"];
                if (_possition != "0")
                {
                    if (mytree.Nodes.Count > 0)
                    {
                        _level = Convert.ToInt32(mytree.SelectedNode.Depth.ToString()) + 1;
                    }
                }
                if (_menu == "1")//create new folder
                {
                    try
                    {
                        if (mytree.Nodes.Count == 0)
                        {
                            _possition = "0";
                            _level = 1;
                        }
                        //_objcls.Folder_description = txtfolder.Text;
                        _objcls.Folder_type = _level;
                        _objcls.Folder_possition = Convert.ToInt32(_possition);
                        _objcls.Enabled = true;
                        _objcls.Project_code = (string)Session["project"];
                        if (_level == 1)
                        {
                            _objcls.Parent_folder = "0";

                        }
                        else if (_level == 2)
                        {
                            _objcls.Parent_folder = mytree.SelectedNode.Parent.Value.Substring(0,mytree.SelectedNode.Parent.Value.IndexOf("#"));

                        }
                        else if (_level == 3)
                        {
                            //Label1.Text = Label1.Text.Substring(0, Label1.Text.IndexOf(">>") - 1).Trim();
                            _objcls.Parent_folder = mytree.SelectedNode.Parent.Value.Substring(0, mytree.SelectedNode.Parent.Value.IndexOf("#"));

                        }
                        else if (_level == 4)
                        {

                            //Label1.Text = "yes";
                            _objcls.Parent_folder = mytree.SelectedNode.Parent.Value.Substring(0, mytree.SelectedNode.Parent.Value.IndexOf("#"));
                        }
                        else if (_level == 5)
                        {

                            //Label1.Text = "yes";
                            _objcls.Parent_folder = mytree.SelectedNode.Parent.Value.Substring(0, mytree.SelectedNode.Parent.Value.IndexOf("#"));
                        }

                        _objbll.Create_TreeFolder(_objcls,_objdb);
                    }
                    catch (Exception ex)
                    {
                        //Label1.Text = ex.ToString();
                    }

                }
                else if (_menu == "2")//create sub folder
                {
                    if (mytree.Nodes.Count == 0) return;
                    //_objcls.Folder_description = txtfolder.Text;
                    _objcls.Folder_type = _level + 1;
                    _objcls.Folder_possition = 0;
                    _objcls.Enabled = true;
                    _objcls.Project_code = (string)Session["project"];
                    if (_level == 1)
                    {
                        _objcls.Parent_folder = mytree.SelectedNode.Value.Substring(0, mytree.SelectedNode.Value.IndexOf("#"));

                    }
                    else if (_level == 2)
                    {
                        _objcls.Parent_folder = mytree.SelectedNode.Value.Substring(0, mytree.SelectedNode.Value.IndexOf("#"));
                    }
                    else if (_level == 3)
                    {
                        _objcls.Parent_folder = mytree.SelectedNode.Value.Substring(0, mytree.SelectedNode.Value.IndexOf("#"));
                    }
                    else if (_level == 4)
                    {
                        _objcls.Parent_folder = mytree.SelectedNode.Value.Substring(0, mytree.SelectedNode.Value.IndexOf("#"));
                    }
                    else if (_level == 5)
                    {
                        _objcls.Parent_folder = mytree.SelectedNode.Value.Substring(0, mytree.SelectedNode.Value.IndexOf("#"));

                    }
                    //Label1.Text = mytree.SelectedNode.Value.Substring(0, mytree.SelectedNode.Value.IndexOf("#"));
                    _objbll.Create_TreeFolder(_objcls,_objdb);
                }
                else if (_menu == "3")//edit folder
                {
                    string _value = mytree.SelectedNode.Value.ToString();
                    int _id = Convert.ToInt32(_value.Substring(0, _value.IndexOf("#")));
                    _objcls.Folder_id = _id;
                    if ((string)Session["edit_type"] != "move")
                    {
                        //_objcls.Folder_description = txtrename.Text;
                        _objcls.mode = (string)Session["edit_type"];
                        _objbll.Edit_Tree_Folder(_objcls,_objdb);
                    }
                    else
                    {
                       // _objcls.Folder_possition = Convert.ToInt32(txtpossition.Text);
                        //Label1.Text = _id.ToString();
                        _objbll.Move_Tree_Folder(_objcls,_objdb);
                    }

                }
            }
            catch (Exception ex)
            {
                //Label1.Text = ex.ToString();
            }
            Populate_Tree();
            //txtfolder.Text = "";

        }

        protected void continue_Click(object sender, EventArgs e)
        {
            //Label1.Text = "";
            //if (txtfolder.Text == "") return;
            Continue_();
            //Label1.Text = (string)Session["_menu"];
        }

        protected void rdbrename_CheckedChanged(object sender, EventArgs e)
        {
            Session["edit_type"] = "rename";
            //txtrename.Visible = true;
            //txtpossition.Visible = false;
            //txtrename.Text = txtfolder.Text;
            //txtrename.Focus();
            //rdbmove.Checked = false;
            //rdbdelete.Checked = false;
        }

        protected void rdbmove_CheckedChanged(object sender, EventArgs e)
        {
            //Session["edit_type"] = "move";
            //txtrename.Visible = false;
            //txtpossition.Visible = true;
            //rdbrename.Checked = false;
            //rdbdelete.Checked = false;
        }

        protected void rdbdelete_CheckedChanged(object sender, EventArgs e)
        {
            //Session["edit_type"] = "delete";
            //txtrename.Visible = false;
            //txtpossition.Visible = false;
            //rdbrename.Checked = false;
            //rdbmove.Checked = false;
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }

        

        protected void cmdup_Click(object sender, EventArgs e)
        {
            Move_Document("up");
            
          
            
        }

        protected void cmddown_Click(object sender, EventArgs e)
        {
            Move_Document("down");
        }
        void Move_Document(string _move)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32((string)Session["doc_id"]);
            _objcls.folder_id = Convert.ToInt32((string)Session["folder_id"]);
            _objcls.possition = Convert.ToInt32((string)Session["possition"]);
            _objcls.move = _move;
            _objbll.Move_document(_objcls,_objdb);
            load_documents();
            //set_select(_move);
            //_objbll.load_document(_objcls);
        }

        protected void mygrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Session["doc_id"] = mygrid.SelectedRow.Cells[2].Text;
            //Session["possition"] = mygrid.SelectedRow.Cells[3].Text;
            //Session["index"] = mygrid.SelectedIndex;
        }
        void set_select(string _move)
        {
            //int idx = mygrid.SelectedIndex;
            //if (_move == "up")
            //    idx -= 1;
            //else
            //    idx += 1;
            //mygrid.Rows[idx].Attributes["BackColor"] = "#E2DED6";
            
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Label2.Text = e.CommandName;
            //int idx = int.Parse(e.CommandArgument.ToString());
            ////Label2.Text = idx.ToString();
            //Session["doc_id"] = mygrid.Rows[idx].Cells[2].Text;
            //Session["possition"] = mygrid.Rows[idx].Cells[3].Text;
            //Move_Document(e.CommandName);
            //if (e.CommandName == "up")
            //    mygrid.Rows[idx - 1].BackColor = System.Drawing.Color.LightBlue;
            //else if (e.CommandName == "down")
            //    mygrid.Rows[idx + 1].BackColor = System.Drawing.Color.LightBlue;
            //else if (e.CommandName == "delete")
            //{
            //    //mygrid.Rows[idx].BackColor = System.Drawing.Color.LightBlue;
            //    BLL_Dml _objbll = new BLL_Dml();
            //    _clsdocument _objcls = new _clsdocument();
            //    _objcls.doc_id = Convert.ToInt32((string)Session["doc_id"]);
            //    _objbll.Delete_Doc(_objcls);
            //    mygrid.DataBind();
            //}
            
        }

        protected void mygrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           // mygrid.Rows[e.RowIndex].BackColor = System.Drawing.Color.LightBlue;
        }

        protected void btnrefresh_Click(object sender, EventArgs e)
        {
            Populate_Tree();
        }

       

       
        
    }
}
