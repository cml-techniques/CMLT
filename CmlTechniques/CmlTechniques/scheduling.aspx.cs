﻿using System;
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
    public partial class scheduling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                Populate_Tree();
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
        private void Populate_Tree()
        {
            // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["project"] + "');", true);
            mytree.Nodes.Clear();
            publicCls.publicCls _obj = new publicCls.publicCls();
            _obj.Load_Tree((string)Session["project"], "nothing");
            var _service = from o in publicCls.publicCls._dtservice.AsEnumerable()
                           select o;
            string folder = "";
            foreach (var row in _service)
            {
                TreeNode _root = new TreeNode();
                _root.Text = row[2].ToString();
                _root.Value = row[0].ToString() + "#" + row[4].ToString();
                _root.SelectAction = TreeNodeSelectAction.Expand;
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
                        _leaf.SelectAction = TreeNodeSelectAction.Expand;
                        folder = row2[2].ToString().Replace("&", "<>");
                        _leaf.NavigateUrl = "javascript:openFrame('" + row2[0].ToString() + "_P" + row1[0].ToString() + "_S" + row[0].ToString()+ "_N" + folder +   "_T" +  row2[7].ToString() + "' )"; 
                        if (_leaf.Text != "")
                            _parent.ChildNodes.Add(_leaf);
                        var Group = from o in publicCls.publicCls._dtgroup.AsEnumerable()
                                    where o.Field<int>(5) == Convert.ToInt32(row2[0].ToString())
                                    select o;
                        foreach (var row3 in Group)
                        {
                            TreeNode _group = new TreeNode();
                            _group.Text = row3[2].ToString();
                            _group.Value = row3[0].ToString() + "#" + row3[4].ToString();
                            _group.SelectAction = TreeNodeSelectAction.Expand;
                            folder = row3[2].ToString().Replace("&", "<>");
                            _group.NavigateUrl = "javascript:openFrame('" + row3[0].ToString() + "_P" + row1[0].ToString() + "_S" + row[0].ToString() + "_N" + folder + "_T" + row3[7].ToString() + "_D" + row2[0].ToString() + "'  )";
                            if (_group.Text != "")
                                _leaf.ChildNodes.Add(_group);
                            var subgroup = from o in publicCls.publicCls._dtsubgroup.AsEnumerable()
                                           where o.Field<int>(5) == Convert.ToInt32(row3[0].ToString())
                                           select o;
                            foreach (var row4 in subgroup)
                            {
                                TreeNode _subgroup = new TreeNode();
                                _subgroup.Text = row4[2].ToString();
                                _subgroup.Value = row4[0].ToString() + "#" + row4[4].ToString();
                                _subgroup.SelectAction = TreeNodeSelectAction.Expand;
                                folder = row4[2].ToString().Replace("&", "<>");
                                _subgroup.NavigateUrl = "javascript:openFrame('" + row4[0].ToString() + "_P" + row1[0].ToString() + "_S" + row[0].ToString() + "_N" + folder + "_T" + row3[7].ToString() + "_D" + row3[0].ToString() + "' )";//
                                if (_subgroup.Text != "")
                                    _group.ChildNodes.Add(_subgroup);
                                var subgroup1 = from o in publicCls.publicCls._dtsubgroup1.AsEnumerable()
                                                where o.Field<int>(5) == Convert.ToInt32(row4[0].ToString())
                                                select o;
                                foreach (var row5 in subgroup1)
                                {
                                    TreeNode _subgroup1 = new TreeNode();
                                    _subgroup1.Text = row5[2].ToString();
                                    _subgroup1.Value = row5[0].ToString() + "#" + row5[4].ToString();
                                    _subgroup1.SelectAction = TreeNodeSelectAction.Expand;
                                    folder = row5[2].ToString().Replace("&", "<>");
                                    _subgroup1.NavigateUrl = "javascript:openFrame('" + row5[0].ToString() + "_P" + row1[0].ToString() + "_S" + row[0].ToString() + "_N" + folder + "' )";
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

        protected void btnrefresh_Click(object sender, EventArgs e)
        {

        }

        
    }
}
