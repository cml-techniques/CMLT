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

namespace CmlTechniques.CMS
{
    public partial class view_document : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                Populate_CMSTREE();
                ExpandNode();
            }

        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["fpath"] != null)
                {
                    Session["fpath"] = Server.HtmlEncode(Request.Cookies["fpath"].Value);
                }
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
            }
        }
        protected void Populate_CMSTREE()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            DataTable _dtmodule = _objbll.Load_Prj_Module(_objdb);
            _objdb.DBName = "DB_" + (string)Session["project"];
            DataTable _dtser = _objbll.Load_Prj_Service(_objdb);
            //DataTable _dtcas = _objbll.Load_Prj_Cassheet(_objdb);
            DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);
            DataTable _dttype = _objbll.Load_Prj_MsType(_objdb);
            DataTable _dtrtype = _objbll.Load_Prj_TrType(_objdb);
            var _module = from o in _dtmodule.AsEnumerable()
                          where o.Field<int>(2) == 0
                          select o;
            foreach (var mod in _module)
            {
                if (mod[1].ToString() == "Method Statement")
                {
                    string _prm = "";
                    TreeNode _n0 = new TreeNode();
                    _n0.Text = mod[1].ToString();
                    _n0.Value = mod[0].ToString();
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
                                _n1.ChildNodes.Add(_n3);
                                var _type = from o in _dttype.AsEnumerable()
                                            select o;
                                foreach (var typ in _type)
                                {
                                    TreeNode _n5 = new TreeNode();
                                    _n5.Text = typ[1].ToString();
                                    _n5.Value = typ[0].ToString();
                                    _prm = typ[0].ToString() + "_M" + sys[0].ToString() + "_N" + mod[1].ToString() + " > " + ser[1].ToString() + " > " + sys[2].ToString() + " > " + typ[1].ToString();
                                    _prm = _prm.Replace("&", "^");
                                    _n5.NavigateUrl = "javascript:parent.callcms('" + _prm + "','0')";
                                    _n3.ChildNodes.Add(_n5);
                                }
                           
                        }

                    }


                }
            }
            mytree.CollapseAll();
        }

        private void ExpandNode()
        {
            string _path = (string)Session["fpath"];
            _path = _path.Substring(_path.IndexOf("#")+1);
            string _ser = _path.Substring(0,_path.IndexOf("#")).Trim();
            _path = _path.Substring(_path.IndexOf("#") + 1);
            string _sys = _path.Substring(0, _path.IndexOf("#")).Trim();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('" + _ser + "');", true);
            //string _pkg = _path.Substring(_path.IndexOf("@") + 1, _path.IndexOf("*") - _path.IndexOf("@") - 1);
            //_pkg = _pkg.Replace("<>", "&");
            mytree.Nodes[0].Expand();
            foreach (TreeNode _node in mytree.Nodes[0].ChildNodes)
            {
                if (_node.Text == _ser)
                {
                    _node.Expand();
                    foreach (TreeNode _child in _node.ChildNodes)
                    {
                        if (_child.Text == _sys)
                        {
                            _child.Expand();
                            return;
                        }
                    }
                }

            }

        }
    }
}
