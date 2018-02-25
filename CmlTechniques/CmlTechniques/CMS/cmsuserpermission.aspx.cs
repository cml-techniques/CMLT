using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class cmsuserpermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString["PRJ"].ToString();
                load_user(_prm);
                Session["project"] = _prm;
                Label1.Text = (string)Session["project"];
                chknoti.Visible = false;
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
            }
        }
        protected void load_user(string Project)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('"+ (string)Session["project"] +"');", true);

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = Project;
            DataTable _dtable = _objbll.load_User(_objcls,_objdb);
            var _result = from o in _dtable.AsEnumerable()
                          where o.Field<bool>(3) == true
                          select o;
            foreach (var row in _result)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[0].ToString();
                _lst.Value = row[0].ToString();
                drprjuser.Items.Add(_lst);
            }
            drprjuser.Items.Insert(0, "<<Select User>>");
        }
        protected void populate_casTree()
        {
            mytree.Nodes.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + Label1.Text;
            _clstreefolder _objcls = new _clstreefolder();
            _objcls.Folder_type = 0;
            DataTable _dt0 = _objbll.LOAD_PRJMAINMODULES(_objdb);
            //DataTable _dt0 = _objbll.Load_FolderTree_Cms(_objcls,_objdb);
            //_objcls.Folder_type = 1;
            //DataTable _dt1 = _objbll.Load_FolderTree_Cms(_objcls,_objdb);
            //_objcls.Folder_type = 2;
            //DataTable _dt2 = _objbll.Load_FolderTree_Cms(_objcls);
            //_objcls.Folder_type = 3;
            //DataTable _dt3 = _objbll.Load_FolderTree_Cms(_objcls);
            //_objcls.Folder_type = 4;
            //DataTable _dt4 = _objbll.Load_FolderTree_Cms(_objcls);
            var _0 = from o in _dt0.AsEnumerable()
                     select o;
            foreach (var row in _0)
            {
                TreeNode _n0 = new TreeNode();
                _n0.Text = row[1].ToString();
                _n0.Value = row[0].ToString();
                _n0.SelectAction = TreeNodeSelectAction.Expand;
                mytree.Nodes.Add(_n0);
                //var _1 = from o in _dt1.AsEnumerable()
                //         where o.Field<int>(2) == Convert.ToInt32(row[0].ToString())
                //         select o;
                //foreach (var row1 in _1)
                //{
                //    TreeNode _n1 = new TreeNode();
                //    _n1.Text = row1[1].ToString();
                //    _n1.Value = row1[0].ToString();
                //    _n1.SelectAction = TreeNodeSelectAction.Expand;
                //    _n0.ChildNodes.Add(_n1);
                //    //var _2 = from o in _dt2.AsEnumerable()
                //    //         where o.Field<int>(2) == Convert.ToInt32(row1[0].ToString())
                //    //         select o;
                //    //foreach (var row2 in _2)
                //    //{
                //    //    TreeNode _n2 = new TreeNode();
                //    //    _n2.Text = row2[1].ToString();
                //    //    _n2.Value = row2[0].ToString();
                //    //    _n2.SelectAction = TreeNodeSelectAction.Expand;
                //    //    _n1.ChildNodes.Add(_n2);
                //    //    var _3 = from o in _dt3.AsEnumerable()
                //    //             where o.Field<int>(2) == Convert.ToInt32(row2[0].ToString())
                //    //             select o;
                //    //    foreach (var row3 in _3)
                //    //    {
                //    //        TreeNode _n3 = new TreeNode();
                //    //        _n3.Text = row3[1].ToString();
                //    //        _n3.Value = row3[0].ToString();
                //    //        _n3.SelectAction = TreeNodeSelectAction.Expand;
                //    //        _n2.ChildNodes.Add(_n3);
                //    //        var _4 = from o in _dt4.AsEnumerable()
                //    //                 where o.Field<int>(2) == Convert.ToInt32(row3[0].ToString())
                //    //                 select o;
                //    //        foreach (var row4 in _4)
                //    //        {
                //    //            TreeNode _n4 = new TreeNode();
                //    //            _n4.Text = row4[1].ToString();
                //    //            _n4.Value = row4[0].ToString();
                //    //            _n3.ChildNodes.Add(_n4);
                //    //        }
                //    //    }
                //    //}
                //}

            }
            mytree.CollapseAll();
        }
        protected void drprjuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drprjuser.SelectedItem.Text != "<<Select User>>")
            {
                populate_casTree();
                Load_user_permission();
                chknoti.Visible = true;
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            set_permission();
        }
        protected void set_permission()
        {
            if (drprjuser.SelectedItem.Text == "<<Select User>>")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Select User');", true);
                return;
            }
            if (draccess.SelectedItem.Text == "<<Select Access>>")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Select User Access');", true);
                return;
            }
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = drprjuser.SelectedItem.Value;
            _objcls.access = draccess.SelectedItem.Text;
            _objcls.permission = permission();
            _objcls.project_code = Label1.Text;
            bool _notification = false;
            if (chknoti.Checked == true)
                _notification = true;
            _objcls.notification = _notification;
            _objbll.Set_User_Permission(_objcls,_objdb);
            ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('User Permissions are updated');", true);
        }
        protected string permission()
        {
            string _per = "";
            for (int i = 0; i <= mytree.Nodes.Count - 1; i++)
            {
                if (mytree.Nodes[i].Checked == true) _per = _per + "1";
                else _per = _per + "0";
                for (int j = 0; j <= mytree.Nodes[i].ChildNodes.Count - 1; j++)
                {
                    if (mytree.Nodes[i].ChildNodes[j].Checked == true) _per = _per + "1";
                    else _per = _per + "0";
                }
            }
            return _per;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('" + _per + "');", true);
        }
        protected void Load_user_permission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.uid = drprjuser.SelectedItem.Value;
            _objcls.project_code = Label1.Text;
            DataTable _dtable=_objbll.Load_User_Permission(_objcls,_objdb);
            var _result = from o in _dtable.AsEnumerable()
                          select o;
            string _uper="";
            int _count=0;
            string _access = "";
            foreach (var row in _result)
            {
                _uper = row[1].ToString();
                _access = row[0].ToString();
                if (row[2].ToString() == "True")
                    chknoti.Checked = true;
                else
                    chknoti.Checked = false;
            }
            draccess.ClearSelection();
            if (_access != "") draccess.Items.FindByText(_access).Selected = true;
            if (_uper.Length <= 0) return;
            for (int i = 0; i <= mytree.Nodes.Count - 1; i++)
            {
                //if (mytree.Nodes[i].Checked == true) _per = _per + "1";
                //else _per = _per + "0";
                if (_uper.Substring(_count, 1) == "1") mytree.Nodes[i].Checked = true;
                else mytree.Nodes[i].Checked = false;
                _count += 1;
                for (int j = 0; j <= mytree.Nodes[i].ChildNodes.Count - 1; j++)
                {
                    //if (mytree.Nodes[i].ChildNodes[j].Checked == true) _per = _per + "1";
                    //else _per = _per + "0";
                    if (_uper.Substring(_count, 1) == "1") mytree.Nodes[i].ChildNodes[j].Checked = true;
                    else mytree.Nodes[i].ChildNodes[j].Checked = false;
                    _count += 1;
                }
            }
        }

    }
}
