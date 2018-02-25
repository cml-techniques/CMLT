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
    public partial class cmsmanagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_project();
                //populate_casTree();
                //Populate_CMSTREE();
                mytree.Visible = false;
            }

        }
       
        void load_project()
        {
            BLL_Dml _objbal = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            DataTable _dtable=_objbal.load_project(_objdb);
            var _result = from o in _dtable.AsEnumerable()
                          where o.Field<string>(5) == "YES"
                          select o;
            foreach (var row in _result)
            {
                ListItem _lst = new ListItem();
                _lst.Text = row[1].ToString();
                _lst.Value = row[0].ToString();
                drproject.Items.Add(_lst);
            }
            drproject.DataBind();
            drproject.Items.Insert(0, "--Select Project--");
        }
        protected void Populate_CMSTREE()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            _objdb.DBName = "DB_" + (string)Session["project"];
            DataTable _dtmodule = _objbll.Load_Prj_Module(_objdb);
            _objdb.DBName = "DB_" + (string)Session["project"];
            DataTable _dtser = _objbll.Load_Prj_Service(_objdb);
            DataTable _dtcas = _objbll.Load_Prj_Cassheet(_objdb);
            DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);
            DataTable _dttype = _objbll.Load_Prj_MsType(_objdb);
            DataTable _dtrtype = _objbll.Load_Prj_TrType(_objdb);
            DataTable _dtserMs = _objbll.Load_Prj_Service_MS(_objdb);
            string Project = drproject.SelectedItem.Value;
            var _module = from o in _dtmodule.AsEnumerable()
                          where o.Field<int>(2) == 0 && o.Field<string>(1) != "CAS Sheets"
                          select o;
            foreach (var mod in _module)
            {
                
                TreeNode _n0 = new TreeNode();
                _n0.Text = mod[1].ToString();
                _n0.Value = mod[0].ToString();
                string _prm = mod[0].ToString() + "_P" + mod[0].ToString() + "_N" + mod[1].ToString() + "_M" + mod[1].ToString() + "_S0" + "_PR" + Project;
                if (mod[1].ToString() == "Commissioning Plan" || mod[1].ToString() == "Memo Issued" || mod[1].ToString() == "WIR CML Comments" || mod[1].ToString() == "Commissioning Report" || mod[1].ToString() == "Monthly Reports")
                    _n0.NavigateUrl = "javascript:load('" + _prm + "')";
                else
                    _n0.SelectAction = TreeNodeSelectAction.Expand;
                if (drproject.SelectedValue.ToString() == "BNGA")
                {
                    if (mod[1].ToString() != "Cas Sheet" && mod[1].ToString() != "Site Observation" && mod[1].ToString() != "T & C Documentation")
                    {
                        mytree.Nodes.Add(_n0);
                    }
                    if (mod[1].ToString() == "Document Review")
                    {
                            TreeNode _n1 = new TreeNode();
                            _n1.Text = "Mechanical Review";
                            _n1.Value = "MR";
                            _n1.SelectAction = TreeNodeSelectAction.Select;
                            _prm = mod[0].ToString() + "_P" + mod[0].ToString() + "_N" + mod[1].ToString() + "_M" +_n1.Text + "_S0" + "_PR" + Project;
                            _n1.NavigateUrl = "javascript:load('" + _prm + "')";
                            _n0.ChildNodes.Add(_n1);
                    }
                }
                else
                {
                    if (mod[1].ToString() != "Cas Sheet" && mod[1].ToString() != "Document Review" && mod[1].ToString() != "Site Observation" && mod[1].ToString() != "T & C Documentation")
                    {
                        mytree.Nodes.Add(_n0);
                    }

                }
                var _service = from o in _dtser.AsEnumerable()
                               select o;
                foreach (var ser in _service)
                {
                    TreeNode _n1 = new TreeNode();
                    _n1.Text = ser[1].ToString();
                    _n1.Value = ser[0].ToString();
                    _n1.SelectAction = TreeNodeSelectAction.Expand;
                    if (mod[1].ToString() == "Cas Sheet" || mod[1].ToString() == "T & C Documentation")
                    {
                        _n0.ChildNodes.Add(_n1);
                    }
                    var _cassheet = from o in _dtcas.AsEnumerable()
                                    where o.Field<int>(2) == Convert.ToInt32(ser[0].ToString())
                                    select o;
                    foreach (var cas in _cassheet)
                    {
                        TreeNode _n2 = new TreeNode();
                        _n2.Text = cas[1].ToString();
                        _n2.Value = cas[0].ToString();
                        if (mod[1].ToString() == "Cas Sheet" || mod[1].ToString() == "T & C Documentation")
                        {
                            _n1.ChildNodes.Add(_n2);
                        }
                    }
                    
                }






                if (mod[1].ToString() == "Method Statement")
                {
                    var _serviceMS = from o in _dtserMs.AsEnumerable()
                                     select o;
                    foreach (var ser in _serviceMS)
                    {
                        TreeNode _n1 = new TreeNode();
                        _n1.Text = ser[1].ToString();
                        _n1.Value = ser[0].ToString();
                        _n1.SelectAction = TreeNodeSelectAction.Expand;
                        _n0.ChildNodes.Add(_n1);
                        var _system = from o in _dtsys.AsEnumerable()
                                      where o.Field<int>(3) == Convert.ToInt32(ser[0].ToString())
                                      select o;
                        foreach (var sys in _system)
                        {
                            TreeNode _n3 = new TreeNode();
                            _n3.Text = sys[2].ToString();
                            _n3.Value = sys[0].ToString();

                            _n3.SelectAction = TreeNodeSelectAction.Expand;
                            if (mod[1].ToString() == "Method Statement")
                            {
                                _n1.ChildNodes.Add(_n3);
                                var _type = from o in _dttype.AsEnumerable()
                                            select o;
                                foreach (var typ in _type)
                                {
                                    TreeNode _n5 = new TreeNode();
                                    _n5.Text = typ[1].ToString();
                                    _n5.Value = typ[0].ToString();
                                    //_prm = typ[0].ToString() + "_P" + sys[0].ToString() + "_N" + typ[1].ToString() + "_M" + mod[1].ToString() + "_S" + ser[0].ToString() + "_PR" + Project;
                                    _prm = "0" + typ[0].ToString() + "_M" + sys[0].ToString() + "_N" + mod[1].ToString() + " > " + ser[1].ToString() + " > " + sys[2].ToString() + " > " + typ[1].ToString() + "_P" + Project + "_S" + ser[0].ToString();
                                    _prm = _prm.Replace("&", "^");
                                    _n5.NavigateUrl = "javascript:load('" + _prm + "')";
                                    _n3.ChildNodes.Add(_n5);
                                }
                            }
                        }
                    }
                }
                if (mod[1].ToString() == "Training")
                {
                    _objdb.DBName = "DB_" + (string)Session["project"];
                    DataTable _dtmaster = _objbll.Load_Training_Folder(_objdb);
                    var _Head = from _hdata in _dtmaster.AsEnumerable()
                                where _hdata.Field<int>("TYPE") == 0
                                select _hdata;

                    foreach (var _hrow in _Head)
                    {
                        TreeNode _h = new TreeNode();
                        _h.Text = _hrow[1].ToString();
                        _h.Value = _hrow[0].ToString();
                        _h.SelectAction = TreeNodeSelectAction.Expand;
                        //mytree.FindNode("Training").ChildNodes.Add(_h);
                        _n0.ChildNodes.Add(_h);
                        var _System = from _sdata in _dtmaster.AsEnumerable()
                                      where _sdata.Field<int>("PARENT_ID") == Convert.ToInt32(_hrow[0].ToString())
                                      select _sdata;
                        foreach (var _srow in _System)
                        {
                            TreeNode _s = new TreeNode();
                            _s.Text = _srow[1].ToString();
                            _s.Value = _srow[0].ToString();
                            _s.SelectAction = TreeNodeSelectAction.Expand;
                            _h.ChildNodes.Add(_s);
                            var _type = from _tdata in _dtmaster.AsEnumerable()
                                        where _tdata.Field<int>("PARENT_ID") == Convert.ToInt32(_srow[0].ToString())
                                        select _tdata;
                            int count = 0;
                            foreach (var _trow in _type)
                            {
                                TreeNode _t = new TreeNode();
                                _t.Text = _trow[1].ToString();
                                _t.Value = _trow[0].ToString();
                                //_prm = _trow[0].ToString() + "_P" + _srow[0].ToString() + "_L" + _trow[4].ToString() + "_T" + _trow[2].ToString();
                                _prm = _trow[0].ToString() + "_P" + _srow[0].ToString() + "_N" + _trow[1].ToString() + "_M" + mod[1].ToString() + "_S" + _hrow[0].ToString() + "_PR" + Project;
                                _t.NavigateUrl = "javascript:load('" + _prm + "')";
                                _s.ChildNodes.Add(_t);
                                count += 1;
                            }
                            if (count == 0)
                            {
                                _prm = _srow[0].ToString() + "_P" + _hrow[0].ToString() + "_N" + _srow[1].ToString() + "_M" + mod[1].ToString() + "_S" + _hrow[0].ToString() + "_PR" + Project;
                                _s.NavigateUrl = "javascript:load('" + _prm + "')";
                            }
                        }
                    }
                }
                var _sub = from o in _dtmodule.AsEnumerable()
                           where o.Field<int>(2) == Convert.ToInt32(mod[0].ToString())
                           select o;
                foreach (var sub in _sub)
                {
                    TreeNode _n4 = new TreeNode();
                    _n4.Text = sub[1].ToString();
                    _n4.Value = sub[0].ToString();
                    _prm = sub[0].ToString() + "_P" + mod[0].ToString() + "_N" + sub[1].ToString() + "_M" + mod[1].ToString() + "_S0" + "_PR" + Project;
                    _prm = _prm.Replace("&", "<>");
                    _n4.NavigateUrl = "javascript:load('" + _prm + "')";

                    if (Project == "NBO")
                    {
                        if (mod[1].ToString() == "Commissioning Plan") { _n0.NavigateUrl = "#"; }
                       
                        if (mod[1].ToString() == "Minutes" || mod[1].ToString() == "Programmes")
                        {
                            _n4.NavigateUrl = "#";

                            var _inner = from o in _dtmodule.AsEnumerable()
                                         where o.Field<int>(2) == Convert.ToInt32(sub[0].ToString())
                                         select o;

                            foreach (var _inn in _inner)
                            {
                                TreeNode _n5 = new TreeNode();
                                _n5.Text = _inn[1].ToString();
                                _n5.Value = _inn[0].ToString();


                                _prm = sub[0].ToString() + "_P" + _inn[0].ToString() + "_N" + sub[1].ToString() + "_M" + mod[1].ToString() + "_S0" + "_PR" + Project;
                                _prm = _prm.Replace("&", "<>");
                                _n5.NavigateUrl = "javascript:load('" + _prm + "')";


                                _n5.SelectAction = TreeNodeSelectAction.Expand;
                                _n4.ChildNodes.Add(_n5);
                            }
                        }
                    }
                    _n0.ChildNodes.Add(_n4);
                }

            }
            mytree.CollapseAll();
        }
        private void Populate_Training()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            DataTable _dtmaster = _objbll.Load_Training_Folder(_objdb);
            var _Head = from _hdata in _dtmaster.AsEnumerable()
                        where _hdata.Field<int>("TYPE") == 0
                        select _hdata;
            
            foreach (var _hrow in _Head)
            {
                TreeNode _h = new TreeNode();
                _h.Text = _hrow[1].ToString();
                _h.Value = _hrow[0].ToString();
                string _prm = _hrow[0].ToString() + "_P0_L" + _hrow[4].ToString() + "_T" + _hrow[2].ToString();
                _h.NavigateUrl = "javascript:Load1('" + _prm + "')";
                mytree.FindNode("Training").ChildNodes.Add(_h);
                var _System = from _sdata in _dtmaster.AsEnumerable()
                              where _sdata.Field<int>("PARENT_ID") == Convert.ToInt32(_hrow[0].ToString())
                              select _sdata;
                foreach (var _srow in _System)
                {
                    TreeNode _s = new TreeNode();
                    _s.Text = _srow[1].ToString();
                    _s.Value = _srow[0].ToString();
                    _prm = _srow[0].ToString() + "_P" + _hrow[0].ToString() + "_L" + _srow[4].ToString() + "_T" + _srow[2].ToString();
                    _s.NavigateUrl = "javascript:Load1('" + _prm + "')";
                    _h.ChildNodes.Add(_s);
                    var _type = from _tdata in _dtmaster.AsEnumerable()
                                where _tdata.Field<int>("PARENT_ID") == Convert.ToInt32(_srow[0].ToString())
                                select _tdata;
                    foreach (var _trow in _type)
                    {
                        TreeNode _t = new TreeNode();
                        _t.Text = _trow[1].ToString();
                        _t.Value = _trow[0].ToString();
                        _prm = _trow[0].ToString() + "_P" + _srow[0].ToString() + "_L" + _trow[4].ToString() + "_T" + _trow[2].ToString();
                        _t.NavigateUrl = "javascript:Load1('" + _prm + "')";
                        _s.ChildNodes.Add(_t);
                    }
                }
            }

        }
        protected void populate_casTree()
        {
            mytree.Nodes.Clear();
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clstreefolder _objcls = new _clstreefolder();
            _objcls.Folder_type = 0;
            DataTable _dt0 = _objbll.Load_FolderTree_Cms(_objcls,_objdb);
            _objcls.Folder_type = 1;
            DataTable _dt1 = _objbll.Load_FolderTree_Cms(_objcls,_objdb);
            _objcls.Folder_type = 2;
            DataTable _dt2 = _objbll.Load_FolderTree_Cms(_objcls,_objdb);
            _objcls.Folder_type = 3;
            DataTable _dt3 = _objbll.Load_FolderTree_Cms(_objcls,_objdb);
            _objcls.Folder_type = 4;
            DataTable _dt4 = _objbll.Load_FolderTree_Cms(_objcls,_objdb);
            var _0 = from o in _dt0.AsEnumerable()
                     select o;
            foreach (var row in _0)
            {
                TreeNode _n0 = new TreeNode();
                _n0.Text = row[1].ToString();
                _n0.Value = row[0].ToString() ;
                string _prm = row[0].ToString() + "_M" + row[0].ToString() + "_MN" + row[1].ToString();
                if(_n0.Value=="2")
                    _n0.NavigateUrl = "javascript:load('" + _prm + "')";
                else
                    _n0.SelectAction = TreeNodeSelectAction.Expand;
                mytree.Nodes.Add(_n0);
                var _1 = from o in _dt1.AsEnumerable()
                         where o.Field<int>(2) == Convert.ToInt32(row[0].ToString())
                         select o;
                foreach (var row1 in _1)
                {
                    TreeNode _n1 = new TreeNode();
                    _n1.Text = row1[1].ToString();
                    _n1.Value = row1[0].ToString() ;
                    _n1.SelectAction = TreeNodeSelectAction.Expand;
                    _prm = row1[0].ToString() + "_M" + row[0].ToString() + "_MN" + row[1].ToString();
                    if (_n0.Value == "5")
                        _n1.NavigateUrl = "javascript:load('" + _prm + "')";
                    else if (_n0.Value == "6")
                        _n1.NavigateUrl = "javascript:load('" + _prm + "')"; 
                    _n0.ChildNodes.Add(_n1);
                    var _2 = from o in _dt2.AsEnumerable()
                             where o.Field<int>(2) == Convert.ToInt32(row1[0].ToString())
                             select o;
                    foreach (var row2 in _2)
                    {
                        TreeNode _n2 = new TreeNode();
                        _n2.Text = row2[1].ToString();
                        _n2.Value = row2[0].ToString();
                        _n1.ChildNodes.Add(_n2);
                        var _3 = from o in _dt3.AsEnumerable()
                                 where o.Field<int>(2) == Convert.ToInt32(row2[0].ToString())
                                 select o;
                        foreach (var row3 in _3)
                        {
                            TreeNode _n3 = new TreeNode();
                            _n3.Text = row3[1].ToString();
                            _n3.Value = row3[0].ToString();
                            _n2.ChildNodes.Add(_n3);
                            var _4 = from o in _dt4.AsEnumerable()
                                     where o.Field<int>(2) == Convert.ToInt32(row3[0].ToString())
                                     select o;
                            foreach (var row4 in _4)
                            {
                                TreeNode _n4 = new TreeNode();
                                _n4.Text = row4[1].ToString();
                                _n4.Value = row4[0].ToString();
                                _prm = row4[0].ToString() + "_M" + row[0].ToString() + "_MN" + row[1].ToString();
                                _n4.NavigateUrl = "javascript:load('" + _prm + "');"; 
                                //_n4.Target = "myframe1";
                                _n3.ChildNodes.Add(_n4);
                            }
                        }
                    }
                }

            }
            mytree.CollapseAll();

        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            //myframe.Attributes.Add("src", "../cmsuploads.aspx");
        }

        protected void draction_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["action"] = draction.SelectedItem.Value;
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            if (drproject.SelectedItem.Text == "--Select Project--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Project!');", true);
                return;
            }
            Session["project"] = drproject.SelectedItem.Value;
            Session["projectname"] = drproject.SelectedItem.Text;
            if (draction.SelectedItem.Value == "0")
            {
                mytree.Nodes.Clear();
                Populate_CMSTREE();
                mytree.Visible = true;
                myframe1.Attributes.Add("src", "");
            }
            else if (draction.SelectedItem.Value == "1")
            {
                myframe1.Attributes.Add("src", "cmsuserpermission.aspx?PRJ=" + drproject.SelectedItem.Value);
                mytree.Visible = false;
            }
            else if (draction.SelectedItem.Value == "3")
            {
                myframe1.Attributes.Add("src", "createpackages.aspx?id=" + drproject.SelectedItem.Value);
                mytree.Visible = false;
            }
            else if (draction.SelectedItem.Value == "4")
            {
                mytree.Nodes.Clear();
                Populate_Training_Folder();
                //myframe1.Attributes.Add("src", "building_master.aspx");
                mytree.Visible = true;
            }
            else if (draction.SelectedItem.Value == "5")
            {
                mytree.Nodes.Clear();
                myframe1.Attributes.Add("src", "ConfigMS.aspx?id=" + drproject.SelectedItem.Value);
                mytree.Visible = true;
            }
            else if (draction.SelectedItem.Value == "6")
            {
                mytree.Nodes.Clear();
                myframe1.Attributes.Add("src", "ConfigMinutes.aspx?id=" + drproject.SelectedItem.Value);
                mytree.Visible = true;
            }
            else if (draction.SelectedItem.Value == "7")
            {
                mytree.Nodes.Clear();
                Populate_Ms_Folder();
                mytree.Visible = true;
            }
            else if (draction.SelectedItem.Value == "8")
            {
                myframe1.Attributes.Add("src", "CreateCasPanel.aspx?id=" + drproject.SelectedItem.Value);
                mytree.Visible = false;
            }

        }

        private void Populate_Training_Folder()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            DataTable _dtmaster = _objbll.Load_Training_Folder(_objdb);
            var _Head = from _hdata in _dtmaster.AsEnumerable()
                        where _hdata.Field<int>("TYPE") == 0
                        select _hdata;
            foreach (var _hrow in _Head)
            {
                TreeNode _h = new TreeNode();
                _h.Text = _hrow[1].ToString();
                _h.Value = _hrow[0].ToString();
                string _prm = _hrow[0].ToString() + "_P0_L" + _hrow[4].ToString() + "_T" + _hrow[2].ToString();
                _h.NavigateUrl = "javascript:Load1('" + _prm + "')";
                mytree.Nodes.Add(_h);
                var _System = from _sdata in _dtmaster.AsEnumerable()
                              where _sdata.Field<int>("PARENT_ID") == Convert.ToInt32(_hrow[0].ToString())
                              select _sdata;
                foreach (var _srow in _System)
                {
                    TreeNode _s = new TreeNode();
                    _s.Text = _srow[1].ToString();
                    _s.Value = _srow[0].ToString();
                    _prm = _srow[0].ToString() + "_P" + _hrow[0].ToString() + "_L" + _srow[4].ToString() + "_T" + _srow[2].ToString();
                    _s.NavigateUrl = "javascript:Load1('" + _prm + "')";
                    _h.ChildNodes.Add(_s);
                    var _type = from _tdata in _dtmaster.AsEnumerable()
                                where _tdata.Field<int>("PARENT_ID") == Convert.ToInt32(_srow[0].ToString())
                                select _tdata;
                    foreach (var _trow in _type)
                    {
                        TreeNode _t = new TreeNode();
                        _t.Text = _trow[1].ToString();
                        _t.Value = _trow[0].ToString();
                        _prm = _trow[0].ToString() + "_P" + _srow[0].ToString() + "_L" + _trow[4].ToString() + "_T" + _trow[2].ToString();
                        _t.NavigateUrl = "javascript:Load1('" + _prm + "')";
                        _s.ChildNodes.Add(_t);
                    }
                }
            }
            mytree.CollapseAll();
        }

        private void Populate_Ms_Folder()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "dbCML";
            _objcls.uid = (string)Session["uid"];
            _objcls.project_code = (string)Session["project"];
            string _permission = _objbll.Get_User_Permission(_objcls, _objdb);
            _objdb.DBName = "DB_" + (string)Session["project"];
            DataTable _dtser = _objbll.Load_Prj_Service_MS(_objdb);
            DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);
            DataTable _dttype = _objbll.Load_Prj_MsType(_objdb);
            var _service = from o in _dtser.AsEnumerable()
                           select o;
            foreach (var ser in _service)
            {
                TreeNode _n1 = new TreeNode();
                _n1.Text = ser[1].ToString();
                _n1.Value = ser[0].ToString();
                _n1.SelectAction = TreeNodeSelectAction.Expand;
                string _prm = "0_T0_S" + ser[0].ToString();
                _prm = _prm.Replace("&", "^");
                _n1.NavigateUrl = "javascript:Load2('" + _prm + "')";
                mytree.Nodes.Add(_n1);
                var _system = from o in _dtsys.AsEnumerable()
                              where o.Field<int>(3) == Convert.ToInt32(ser[0].ToString())
                              select o;
                foreach (var sys in _system)
                {
                    TreeNode _n2 = new TreeNode();
                    _n2.Text = sys[2].ToString();
                    _n2.Value = sys[0].ToString();
                    _n2.SelectAction = TreeNodeSelectAction.Expand;
                    _prm = sys[0].ToString() + "_T" + sys[2].ToString() + "_S" + ser[0].ToString();
                    _prm = _prm.Replace("&", "^");
                    _n2.NavigateUrl = "javascript:Load2('" + _prm + "')";
                    _n1.ChildNodes.Add(_n2);
                    var _type = from o in _dttype.AsEnumerable()
                                select o;
                    foreach (var typ in _type)
                    {
                        TreeNode _n3 = new TreeNode();
                        _n3.Text = typ[1].ToString();
                        _n3.Value = typ[0].ToString();
                        //_n5.NavigateUrl = "javascript:parent.callcms('" + _prm + "','4')";
                        _n2.ChildNodes.Add(_n3);
                    }


                }

            }
            mytree.CollapseAll();
        }
    }
}
