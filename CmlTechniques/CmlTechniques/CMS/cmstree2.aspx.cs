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
using App_Properties;
using BusinessLogic;

namespace CmlTechniques.CMS
{
    public partial class cmstree2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString["PRJ"].ToString();
                Populate_CMSTREE(_prm);
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
        protected void Populate_CMSTREE(string Project)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _clscassheet _objcls1 = new _clscassheet();
            _objdb.DBName = "dbCML";
            _objcls.uid = (string)Session["uid"];
            _objcls.project_code = Project;
            string _permission = _objbll.Get_User_Permission(_objcls, _objdb);
            _objdb.DBName = "DB_" + Project;
            DataTable _dtmodule = _objbll.Load_Prj_Module(_objdb);
            DataTable _dtser = _objbll.Load_Prj_Service(_objdb);
            DataTable _dtcas = _objbll.Load_Prj_Cassheet(_objdb);
            //DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);
            //DataTable _dttype = _objbll.Load_Prj_MsType(_objdb);
            //DataTable _dtrtype = _objbll.Load_Prj_TrType(_objdb);
            //DataTable _dtserMs = _objbll.Load_Prj_Service_MS(_objdb);
            //DataTable _dtdiv = _objbll.load_cas_div(_objdb);
            var _module = from o in _dtmodule.AsEnumerable()
                          where o.Field<int>(2) == 0
                          select o;
            int _idx = 0;
            foreach (var mod in _module)
            {

                if (_permission.Substring(_idx, 1) == "1")
                {
                    string _prm = "";
                    TreeNode _n0 = new TreeNode();
                    _n0.Text = mod[1].ToString();
                    _n0.Value = mod[0].ToString();
                    _prm = mod[1].ToString();


                    if (mod[1].ToString() == "CAS Sheets")
                    {
                        _n0.SelectAction = TreeNodeSelectAction.Expand;

                        foreach (DataRow drow in _dtser.Rows)
                        {
                            TreeNode _n01 = new TreeNode();
                            _n01.Text = drow["PRJ_SER_NAME"].ToString();
                            _n01.Value = drow["PRJ_SER_ID"].ToString();
                            _n01.SelectAction = TreeNodeSelectAction.Expand;
                            _n0.ChildNodes.Add(_n01);
                            var _cassheet = from o in _dtcas.AsEnumerable()
                                            where o.Field<int>(2) == Convert.ToInt32(drow["PRJ_SER_ID"].ToString()) && o.Field<int>("Parent_Id") == 0
                                            select o;
                            foreach (var cas in _cassheet)
                            {
                                TreeNode _n2 = new TreeNode();
                                _n2.Text = cas[1].ToString();
                                _n2.Value = cas[0].ToString();
                                _prm = "prj=" + Project + "&id=" + cas[0].ToString() + "&mod=CAS";
                                _n01.ChildNodes.Add(_n2);
                                if (cas["Folder"].ToString() == "True")
                                {
                                    _n2.SelectAction = TreeNodeSelectAction.Expand;
                                    var _cassheetsub = from o in _dtcas.AsEnumerable()
                                                       where o.Field<int>("Parent_Id") == Convert.ToInt32(cas[0].ToString())
                                                       select o;
                                    foreach (var cas_sub in _cassheetsub)
                                    {
                                        TreeNode _n3 = new TreeNode();
                                        _n3.Text = cas_sub[1].ToString();
                                        _n3.Value = cas_sub[0].ToString();
                                        _prm = "prj=" + Project + "&id=" + cas_sub[0].ToString() + "&mod=CAS";
                                        _n3.NavigateUrl = "javascript:parent.callcms('" + _prm + "','35')";
                                        _n3.SelectAction = TreeNodeSelectAction.Select;
                                        _n2.ChildNodes.Add(_n3);
                                    }
                                }
                                else
                                {
                                    _n2.NavigateUrl = "javascript:parent.callcms('" + _prm + "','35')";
                                    _n2.SelectAction = TreeNodeSelectAction.Select;
                                }
                            }

                        }

                    }
                    mytree.Nodes.Add(_n0);


                }
            }
            mytree.CollapseAll();
        }
    }
}
