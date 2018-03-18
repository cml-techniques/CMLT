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
    public partial class cmstree1 : System.Web.UI.Page
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
            DataTable _dtsys = _objbll.Load_Prj_MsSystem(_objdb);
            DataTable _dttype = _objbll.Load_Prj_MsType(_objdb);
            DataTable _dtrtype = _objbll.Load_Prj_TrType(_objdb);
            DataTable _dtserMs = _objbll.Load_Prj_Service_MS(_objdb);
            DataTable _dtdiv = _objbll.load_cas_div(_objdb);
            var _module = from o in _dtmodule.AsEnumerable()
                          where o.Field<int>(2) == 0
                          select o;
            int _idx = 0;
            foreach (var mod in _module)
            {

                if (_permission.Substring(_idx, 1) == "1")
                {
                    TreeNode _n0 = new TreeNode();
                    _n0.Text = mod[1].ToString();
                    _n0.Value = mod[0].ToString();
                    string _prm = "";
                    if (mod[1].ToString() == "Commissioning Plan" || mod[1].ToString() == "Commissioning/ Training/ O and M Plans")
                    {
                        _prm = mod[0].ToString() + "_M" + mod[0].ToString() + "_N" + mod[1].ToString() + "_P" + Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _prm + "','1')";
                    }
                    else if (mod[1].ToString() == "Dashboard")
                    {
                        //_prm = mod[0].ToString() + "_M" + mod[0].ToString() + "_N" + mod[1].ToString() + "_P" + Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + Project + "','28')";
                    }
                    else if (mod[1].ToString() == "Commissioning Report")
                    {
                        _prm = mod[0].ToString() + "_M" + mod[0].ToString() + "_N" + mod[1].ToString() + "_P" + Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _prm + "','1')";
                    }
                    else if (mod[1].ToString() == "Document Review")
                    {
                        string _parm = "";
                        _parm = Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _parm + "','3')";
                    }
                    else if (mod[1].ToString() == "Systems List")
                    {
                        string _parm = "";
                        _parm = Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _parm + "','31')";
                    }
                    else if (mod[1].ToString() == "Site Observation" || mod[1].ToString() == "Commissioning Snags")
                    {
                        _prm = Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _prm + "','8')";
                    }
                    else if (mod[1].ToString() == "Memo Issued")
                    {
                        _prm = mod[0].ToString() + "_M" + mod[0].ToString() + "_N" + mod[1].ToString() + "_P" + Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _prm + "','22')";
                    }
                    else if (mod[1].ToString() == "WIR CML Comments")
                    {
                        _prm = mod[0].ToString() + "_M" + mod[0].ToString() + "_N" + mod[1].ToString() + "_P" + Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _prm + "','24')";
                    }
                    else if (mod[1].ToString() == "CX Issues Log")
                    {
                        _prm = Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _prm + "','27')";
                    }
                    else if (mod[1].ToString() == "CX IR Record Schedule")
                    {
                        _prm = Project;
                        _n0.NavigateUrl = "javascript:parent.callcms('" + _prm + "','29')";
                    }
                    else if (mod[1].ToString() == "CAS Sheets" || mod[1].ToString() == "Test Packs")
                    {
                        if (Project == "ASAO" || Project == "Trial")
                        {
                            _prm = "0_P" + Project + "_T2";
                            _n0.NavigateUrl = "javascript:parent.callcms('" + _prm + "','25')";
                            _n0.SelectAction = TreeNodeSelectAction.SelectExpand;
                        }
                        else
                        {
                            _n0.SelectAction = TreeNodeSelectAction.Expand;
                        }
                    }
                    else
                        _n0.SelectAction = TreeNodeSelectAction.Expand;
                    mytree.Nodes.Add(_n0);
                    var _div = from o in _dtdiv.AsEnumerable()
                               select o;
                    if (mod[1].ToString() == "CAS Sheets" || mod[1].ToString() == "T & C Documentation")
                    {
                        foreach (var div in _div)
                        {
                            TreeNode _n01 = new TreeNode();
                            _n01.Text = div[1].ToString();
                            _n01.Value = div[0].ToString();
                            _n01.SelectAction = TreeNodeSelectAction.Expand;
                            _n0.ChildNodes.Add(_n01);
                            var _service = from o in _dtser.AsEnumerable()
                                           select o;
                            foreach (var ser in _service)
                            {
                                TreeNode _n1 = new TreeNode();
                                _n1.Text = ser[1].ToString();
                                _n1.Value = ser[0].ToString();
                                _n1.SelectAction = TreeNodeSelectAction.Expand;
                                if (mod[1].ToString() == "CAS Sheets" || mod[1].ToString() == "T & C Documentation" || mod[1].ToString() == "Test Packs")
                                {
                                    if (Project == "11736" || Project == "Traini" || Project == "AFV")
                                    {
                                        if (div[1].ToString() != "Infrastructure")
                                            _n01.ChildNodes.Add(_n1);
                                    }
                                    else
                                        _n0.ChildNodes.Add(_n1);
                                    if (mod[1].ToString() == "CAS Sheets" || mod[1].ToString() == "Test Packs")
                                    {
                                        if (Project == "ASAO" || Project == "Trial")
                                        {
                                            _prm = ser[0].ToString() + "_P" + Project + "_T3";
                                            _n1.NavigateUrl = "javascript:parent.callcms('" + _prm + "','25')";
                                            _n1.SelectAction = TreeNodeSelectAction.SelectExpand;
                                        }
                                    }
                                }
                                var _cassheet = from o in _dtcas.AsEnumerable()
                                                where o.Field<int>(2) == Convert.ToInt32(ser[0].ToString())
                                                select o;
                                foreach (var cas in _cassheet)
                                {
                                    TreeNode _n2 = new TreeNode();
                                    _n2.Text = cas[1].ToString();
                                    _n2.Value = cas[0].ToString();
                                    _prm = cas[0].ToString() + "_P" + Project + "_D" + div[0].ToString();

                                    if (mod[1].ToString() == "CAS Sheets")
                                    {
                                        _n2.NavigateUrl = "javascript:parent.callcms('" + _prm + "','0')";
                                        _n1.ChildNodes.Add(_n2);

                                    }
                                    else if (mod[1].ToString() == "T & C Documentation")
                                    {
                                        _n2.NavigateUrl = "javascript:parent.callcms('" + _prm + "','13')";
                                        _n1.ChildNodes.Add(_n2);
                                    }
                                    else if (mod[1].ToString() == "Test Packs")
                                    {
                                        _prm = cas[0].ToString() + "_P" + Project;
                                        _n2.NavigateUrl = "javascript:parent.callcms('" + _prm + "','30')";
                                        _n1.ChildNodes.Add(_n2);
                                    }
                                }
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

                                        string vpath = _n3.ValuePath;

                                        _prm = typ[0].ToString() + "_M" + sys[0].ToString() + "_N" + mod[1].ToString() + " > " + ser[1].ToString() + " > " + sys[2].ToString() + " > " + typ[1].ToString() + "_P" + Project+"_V"+ vpath;
                                        _prm = _prm.Replace("&", "^");
                                        _n5.NavigateUrl = "javascript:parent.callcms('" + _prm + "','4')";
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
                                    //_prm = _trow[0].ToString() + "_P" + _srow[0].ToString() + "_N" + _trow[1].ToString() + "_M" + _srow[1].ToString() + "_S0";
                                    _prm = _trow[0].ToString() + "_M" + _srow[0].ToString() + "_N" + mod[1].ToString() + " > " + _hrow[1].ToString() + " > " + _srow[1].ToString() + " > " + _trow[1].ToString() + "_P" + Project;
                                    _prm = _prm.Replace("&", "^");
                                    _t.NavigateUrl = "javascript:parent.callcms('" + _prm + "','15')";
                                    _s.ChildNodes.Add(_t);
                                    count += 1;
                                }
                                if (count == 0)
                                {
                                    _prm = _srow[0].ToString() + "_M" + _hrow[0].ToString() + "_N" + mod[1].ToString() + " > " + _hrow[1].ToString() + " > " + _srow[1].ToString() + "_P" + Project;
                                    _prm = _prm.Replace("&", "^");
                                    _s.NavigateUrl = "javascript:parent.callcms('" + _prm + "','15')";
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
                        _prm = sub[0].ToString() + "_M" + mod[0].ToString() + "_N" + mod[1].ToString() + " > " + sub[1].ToString() + "_P" + Project;
                        if (mod[1].ToString() == "Programmes")
                        {
                            _n4.NavigateUrl = "javascript:parent.callcms('" + _prm + "_V" + _n0.ValuePath + "','7')";
                        }
                        else if (mod[1].ToString() == "Minutes")
                        {
                            _n4.NavigateUrl = "javascript:parent.callcms('" + _prm + "','6')";
                        }
                        else if (mod[1].ToString() == "Letters")
                        {
                            _n4.NavigateUrl = "javascript:parent.callcms('" + _prm + "','23')";
                        }
                        _n0.ChildNodes.Add(_n4);
                    }
                }
                if (mod[2].ToString() == "0")
                {
                    _idx += 1;
                }
            }
            mytree.CollapseAll();
        }
    }
}
