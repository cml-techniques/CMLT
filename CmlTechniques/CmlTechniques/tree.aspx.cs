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
    public partial class tree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Populate_Tree();
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
                        string type = row2[7].ToString();
                        if (row2[7].ToString() == "1")
                            type = "1";
                        string path = row[2].ToString() + "@" + row1[2].ToString() + "*" + row2[2].ToString();
                        path = path.Replace("&", "<>");
                        _leaf.NavigateUrl = "javascript:parent.openFrame('" + row2[0].ToString() + "_P" + path + row2[7].ToString() + "_B" + "','" + type + "')";
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
                            _group.NavigateUrl = "javascript:parent.openFrame('" + row3[0].ToString() + "_P" + path + row2[7].ToString() + "_B" + "','" + type + "')";
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
                                _subgroup.NavigateUrl = "javascript:parent.openFrame('" + row4[0].ToString() + "_P" + path + row3[7].ToString() + "_B" + "','" + type + "')";
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
    }
}
