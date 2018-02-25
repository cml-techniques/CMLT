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
    public partial class cmsnew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userinfo.Text = "Login as : " + (string)Session["uid"] + " , ";
                prj.Text = (string)Session["projectname"] + " - CMS ";
                prjhead.Src = "images/" + (string)Session["project"] + "top.jpg";
                //prjlogo.Src = "images/" + (string)Session["project"] + "logo.jpg";
                //populate_casTree();
                Populate_CMSTREE();
                //if ((string)Session["project"] == "BCC1")
                //    main.Style.Add(HtmlTextWriterStyle.BackgroundImage, "images/BCC1body.jpg");
               
            }
        }
        protected void Populate_CMSTREE()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            DataTable _dtmodule = _objbll.Load_Prj_Module(_objdb);
            _objdb.DBName ="DB_" + (string)Session["project"];
            DataTable _dtser = _objbll.Load_Prj_Service(_objdb);
            DataTable _dtcas = _objbll.Load_Prj_Cassheet(_objdb);
            DataTable _dtsys=_objbll.Load_Prj_MsSystem(_objdb);
            DataTable _dttype = _objbll.Load_Prj_MsType(_objdb);
            DataTable _dtrtype = _objbll.Load_Prj_TrType(_objdb);
            var _module = from o in _dtmodule.AsEnumerable()
                          where o.Field<int>(2)==0
                          select o;
            foreach (var mod in _module)
            {
                TreeNode _n0 = new TreeNode();
                _n0.Text = mod[1].ToString();
                _n0.Value = mod[0].ToString();
                string _prm = "";
                if (mod[1].ToString() == "Commissioning Plan")
                {
                    _prm = mod[0].ToString() + "_M" + mod[0].ToString() + "_N" + mod[1].ToString() ;
                    _n0.NavigateUrl = "javascript:callcms('" + _prm + "','1')";
                }
                else if (mod[1].ToString() == "Document Review")
                    _n0.NavigateUrl = "javascript:callcms('" + mod[1].ToString() + "','3')";
                else if (mod[1].ToString() == "Site Observation")
                    _n0.NavigateUrl = "javascript:callcms('" + mod[1].ToString() + "','8')";
                else
                    _n0.SelectAction = TreeNodeSelectAction.Expand;
                mytree.Nodes.Add(_n0);
                var _service = from o in _dtser.AsEnumerable()
                                select o;
                foreach (var ser in _service)
                {
                    TreeNode _n1 = new TreeNode();
                    _n1.Text = ser[1].ToString();
                    _n1.Value = ser[0].ToString();
                    _n1.SelectAction = TreeNodeSelectAction.Expand;
                    if (mod[1].ToString() == "Cas Sheet" || mod[1].ToString() == "Method Statement" || mod[1].ToString() == "T & C Documentation" || mod[1].ToString() == "Training")
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
                        _prm = cas[0].ToString() + "_S" + ser[0].ToString();
                        
                        if (mod[1].ToString() == "Cas Sheet")
                        {
                            _n2.NavigateUrl = "javascript:callcms('" + _prm + "','0')";
                            _n1.ChildNodes.Add(_n2);
                        }
                        else if(mod[1].ToString() == "T & C Documentation")
                        {
                            _n2.NavigateUrl = "javascript:callcms('" + _prm + "','13')";
                            _n1.ChildNodes.Add(_n2);
                        }
                    }
                    var _system = from o in _dtsys.AsEnumerable()
                                  where o.Field<int>(3) == Convert.ToInt32(ser[0].ToString())
                                  select o;
                    foreach (var sys in _system)
                    {
                        TreeNode _n3 = new TreeNode();
                        _n3.Text = sys[2].ToString();
                        _n3.Value = sys[0].ToString();
                        
                        _n3.SelectAction = TreeNodeSelectAction.Expand;
                        if (mod[1].ToString() == "Method Statement" || mod[1].ToString() == "Training")
                        {
                            _n1.ChildNodes.Add(_n3);
                        }
                        if (mod[1].ToString() == "Method Statement" )
                        {

                            var _type = from o in _dttype.AsEnumerable()
                                        select o;
                            foreach (var typ in _type)
                            {
                                TreeNode _n5 = new TreeNode();
                                _n5.Text = typ[1].ToString();
                                _n5.Value = typ[0].ToString();
                                _prm = typ[0].ToString() + "_M" + sys[0].ToString() + "_N" + mod[1].ToString() + " > " + ser[1].ToString() + " > " + sys[2].ToString() + " > " + typ[1].ToString();
                                _prm = _prm.Replace("&", "^");
                                _n5.NavigateUrl = "javascript:callcms('" + _prm + "','4')";
                                _n3.ChildNodes.Add(_n5);
                            }
                        }
                        if (mod[1].ToString() == "Training")
                        {

                            var _type = from o in _dtrtype.AsEnumerable()
                                        select o;
                            foreach (var typ in _type)
                            {
                                TreeNode _n5 = new TreeNode();
                                _n5.Text = typ[1].ToString();
                                _n5.Value = typ[0].ToString();
                                _prm = typ[0].ToString() + "_M" + sys[0].ToString() + "_N" + mod[1].ToString() + " > " + ser[1].ToString() + " > " + sys[2].ToString() + " > " + typ[1].ToString();
                                _prm = _prm.Replace("&", "^");
                                _n5.NavigateUrl = "javascript:callcms('" + _prm + "','15')";
                                _n3.ChildNodes.Add(_n5);
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
                    _prm = sub[0].ToString() + "_M" + mod[0].ToString() + "_N" + mod[1].ToString() + " > " + sub[1].ToString();
                    if (mod[1].ToString() == "Programmes")
                    {
                        _n4.NavigateUrl = "javascript:callcms('" + _prm + "','7')";
                    }
                    else if (mod[1].ToString() == "Minutes")
                    {
                        _n4.NavigateUrl = "javascript:callcms('" + _prm + "','6')";
                    }
                    _n0.ChildNodes.Add(_n4);
                }
            }
            mytree.CollapseAll();
        }
        protected void populate_casTree()
        {
            
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
                _n0.Value = row[0].ToString();
                string _prm = row[0].ToString() + "_P" + row[1].ToString() + " > " + "";
                if(_n0.Value=="1" || _n0.Value=="4" || _n0.Value=="5" || _n0.Value=="6")
                    _n0.SelectAction = TreeNodeSelectAction.Expand;
                else if(_n0.Value=="2")
                    _n0.NavigateUrl = "javascript:callcms('" + _prm + "','1')";                
                else if(_n0.Value=="3")
                    _n0.NavigateUrl = "javascript:callcms('" + row[1].ToString() + "','3')";
                else if (_n0.Value == "7")
                    _n0.NavigateUrl = "javascript:callcms('" + row[1].ToString() + "','8')"; 
                mytree.Nodes.Add(_n0);
                var _1 = from o in _dt1.AsEnumerable()
                         where o.Field<int>(2)==Convert.ToInt32(row[0].ToString())
                         select o;
                foreach (var row1 in _1)
                {
                    TreeNode _n1 = new TreeNode();
                    _n1.Text = row1[1].ToString();
                    _n1.Value = row1[0].ToString();
                    _n1.SelectAction = TreeNodeSelectAction.Expand;
                    _prm = row1[0].ToString() + "_P" + row[1].ToString() + " > " + row1[1].ToString();
                    if(_n0.Value=="5" )
                        _n1.NavigateUrl = "javascript:callcms('" + _prm + "','6')"; 
                    else if(_n0.Value=="6")
                        _n1.NavigateUrl = "javascript:callcms('" + _prm + "','7')";
                    //else if (_n0.Value == "1")
                    //{
                    //    _prm=row1[0].ToString() ;
                    //    _n1.NavigateUrl = "javascript:callcms('" + _prm + "','0')";
                    //}
                    _n0.ChildNodes.Add(_n1);
                    var _2 = from o in _dt2.AsEnumerable()
                             where o.Field<int>(2) == Convert.ToInt32(row1[0].ToString())
                             select o;
                    foreach (var row2 in _2)
                    {
                        TreeNode _n2 = new TreeNode();
                        _n2.Text = row2[1].ToString();
                        _n2.Value = row2[0].ToString();
                        _prm = row2[0].ToString() + "_S" + row1[0].ToString();
                        if (_n0.Value == "1")
                        {
                            //_prm = row1[0].ToString();
                            _n2.NavigateUrl = "javascript:callcms('" + _prm + "','0')";
                        }
                        else
                            _n2.SelectAction = TreeNodeSelectAction.Expand;
                        _n1.ChildNodes.Add(_n2);

                        if (_n2.Value == "21")
                        {
                            TreeNode _a = new TreeNode();
                            _a.Text = "Add";
                            _a.Value = "Add";
                            _a.NavigateUrl = "javascript:callcms('" + _prm + "','0')";
                            _n2.ChildNodes.Add(_a);

                            TreeNode _b = new TreeNode();
                            _b.Text = "Edit";
                            _b.Value = "Edit";
                            _b.NavigateUrl = "../lveletesting.aspx";
                            _b.Target = "myframe";
                            _n2.ChildNodes.Add(_b);

                            TreeNode _c = new TreeNode();
                            _c.Text = "View";
                            _c.Value = "View";
                            _c.NavigateUrl = "CMS/caslvreport.aspx";
                            _c.Target = "myframe";
                            _n2.ChildNodes.Add(_c);


                        }



                        var _3 = from o in _dt3.AsEnumerable()
                                 where o.Field<int>(2) == Convert.ToInt32(row2[0].ToString())
                                 select o;
                        foreach (var row3 in _3)
                        {
                            TreeNode _n3 = new TreeNode();
                            _n3.Text = row3[1].ToString();
                            _n3.Value = row3[0].ToString();
                            _n3.SelectAction = TreeNodeSelectAction.Expand;
                            _n2.ChildNodes.Add(_n3);
                            var _4 = from o in _dt4.AsEnumerable()
                                     where o.Field<int>(2) == Convert.ToInt32(row3[0].ToString())
                                     select o;
                            foreach (var row4 in _4)
                            {
                                TreeNode _n4 = new TreeNode();
                                _n4.Text = row4[1].ToString();
                                _n4.Value = row4[0].ToString();
                                string _path =row4[0].ToString() + "_P" +  row[1].ToString() + " > " + row1[1].ToString() + " > " + row2[1].ToString() + " > " + row3[1].ToString() + " > " + row4[1].ToString();
                                _path = _path.Replace("&", "^");
                                _n4.NavigateUrl = "javascript:callcms('" + _path + "','4')"; 
                                _n3.ChildNodes.Add(_n4);
                            }
                        }
                    }
                }

            }
            mytree.CollapseAll();

        }
    }
}
