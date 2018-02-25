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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;

namespace CmlTechniques.CMS
{
    public partial class Summary : System.Web.UI.Page
    {
        public static DataTable _dtMaster;
        public static DataTable _dtfilter;
        public static DataTable _dtresult;
        public static DataTable _dtsummary;
        protected void Page_Load(object sender, EventArgs e)
        {
                Session["Report"] = null;
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
                if (Request.Cookies["sch"] != null)
                {
                    Session["sch"] = Server.HtmlEncode(Request.Cookies["sch"].Value);
                }
                if (Request.Cookies["srv"] != null)
                {
                    Session["srv"] = Server.HtmlEncode(Request.Cookies["srv"].Value);
                }
            }
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32(lblsch.Text);
            _objcas.prj_code = lblprj.Text;
            if (lblprj.Text == "HMIM" || lblprj.Text == "14211" || lblprj.Text == "HMHS")
                _objcas.sys = Convert.ToInt32(lbldiv.Text);
            else
                _objcas.sys = 0;
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
            if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
            {
                if (lbldiv.Text == "1")
                {
                    var _result = _dtMaster.Select("b_z ='PMCW' OR b_z ='PMPW' OR b_z ='PMVW'");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "2")
                {
                    var _result = _dtMaster.Select("b_z LIKE 'PMMB%' OR b_z='PMMV' OR b_z='PMST' OR b_z='PPP3' OR b_z='PPP4' OR b_z='PMMU' OR b_z='PMDW' ");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "3")
                {
                    var _result = _dtMaster.Select("b_z ='PSEC' OR b_z='PMWT' OR b_z='PSWB' OR b_z='PSGC' OR b_z='Energy Centre' OR b_z='PSGS'");
                    _dtresult = _result.Any() ? _result.CopyToDataTable() : _dtMaster.Clone();
                }
                else if (lbldiv.Text == "4")
                    _dtresult = null;
                else
                    _dtresult = _dtMaster;

            }
            else
                _dtresult = _dtMaster;
        }
        private void Load_Filtering_Elements()
        {
            var _bzone = (from DataRow dRow in _dtMaster.Rows
                          orderby dRow["B_Z"]
                          select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in _bzone)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drbuilding.Items.Add(_itm);
            }
            drbuilding.DataBind();
            var _fedf = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["F_from"]
                         select new { col1 = dRow["F_from"] }).Distinct();
            foreach (var row in _fedf)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drfed.Items.Add(_itm);
            }
            drfed.DataBind();
            var _cate = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["Cat"]
                         select new { col1 = dRow["Cat"] }).Distinct();
            foreach (var row in _cate)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drcategory.Items.Add(_itm);
            }
            drcategory.DataBind();
            var _flvl = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["F_lvl"]
                         select new { col1 = dRow["F_lvl"] }).Distinct();
            foreach (var row in _flvl)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drflevel.Items.Add(_itm);
            }
            drflevel.DataBind();
            var _loc = (from DataRow dRow in _dtMaster.Rows
                        orderby dRow["Loc"]
                        select new { col1 = dRow["Loc"] }).Distinct();
            foreach (var row in _loc)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drloc.Items.Add(_itm);
            }
            drloc.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            drloc.Items.Insert(0, "All");
            drbuilding.SelectedValue = (string)Session["zone"];
            drcategory.SelectedValue = (string)Session["cat"];
            drflevel.SelectedValue = (string)Session["flvl"];
            drfed.SelectedValue = (string)Session["fed"];
            drloc.SelectedValue = (string)Session["loc"];
        }
        
        private void Filtering(string _el1, string _el2, string _el3, string _el4,string _el5)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            if (_el5 == "") _el5 = "All";
            Load_Master();
            _dtfilter = _dtMaster;
            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 != "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 != "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_from") == _el4 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("Loc") == _el5
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All" && _el5 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("Loc") == _el5
                          select o;
            }
            _dtresult = _filter.Any() ? _filter.CopyToDataTable() : _dtMaster.Clone();
            Generate_Summary();
            //Summary2();
        }
        //private void Generate_Summary()
        //{

        //    switch (lblsch1.Text)
        //    {
        //        case "1": { if (drtype.SelectedItem.Value == "1")  Summary1_5(); else if (drtype.SelectedItem.Value == "2") Building1_5();  break; }
        //        //case "2": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2")Building2(); break; }
        //        case "2": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo") Building_Summary(2); else Building2(); } break; }
        //        //case "3": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary3_1(); else Summary3(); } else if (drtype.SelectedItem.Value == "2")Building3(); break; }
        //        case "3": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary3_1(); else Summary3(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo") Building_Summary(3); else Building3(); } break; }
        //        case "120": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary3_1(); else Summary3(); } else if (drtype.SelectedItem.Value == "2")Building3(); break; }
        //        //case "4": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary4_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary4_2(); else Summary4(); } else if (drtype.SelectedItem.Value == "2")Building4(); break; }
        //        case "4": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary4_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary4_2(); else Summary4(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo") Building_Summary(4); else Building_Summary(4); } break; }
        //        //case "5": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary5_1(); else if (lblprj.Text == "ASAO" || lblprj.Text=="OPH") Summary5_asao(); else Summary1_5(); } else if (drtype.SelectedItem.Value == "2")Building1_5(); break; }
        //        case "5": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary5_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "OPH") Summary5_asao(); else Summary1_5(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo") Building_Summary(5); else Building1_5(); } break; }
        //        //case "6": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary6_1(); else Summary6(); } else if (drtype.SelectedItem.Value == "2")Building6(); break; }
        //        case "6": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary6_1(); else Summary6(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo") Building_Summary(6); else Building6(); } break; }
        //        //case "7": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary7_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1") { Summary_7_1(); } else Summary7(); } else if (drtype.SelectedItem.Value == "2")Building7(); break; }
        //        case "7": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary7_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1") { Summary_7_1(); } else Summary7(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo") Building_Summary(7); else Building7(); } break; }
        //        case "8": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "9": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary9_1(); else Summary9(); } else if (drtype.SelectedItem.Value == "2")Building9(); break; }
        //        case "10": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary10_1_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1") Summary10_2(); else if (lblprj.Text == "11736")Summary10_11736(); else if (lblprj.Text == "14211")Summary10_14211(); else if (lblprj.Text == "OPH") Summary10_oph(); else Summary10(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211")Building_Summary(10); else Building10(); } break; }
                
        //        case "11": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1") Summary11_1(); else if (lblprj.Text == "OPH") Summary11_oph(); else Summary11(); } else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211")Building_Summary(11); else Building11(); break; }
        //        case "12": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary12_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary12_2(); else if (lblprj.Text == "MOE")Summary12_moe(); else if (lblprj.Text == "14211")Summary12_14211(); else if (lblprj.Text == "OPH") Summary12_oph(); else Summary12(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "MOE") Building12_moe(); else Building12(); } break; }
        //        case "13": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "14211")Summary13_14211(); else if (lblprj.Text == "OPH") Summary13_oph(); else Summary13(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211")Building_Summary(13); else Building13(); } break; }
        //        case "14": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else Summary14(); } else if (drtype.SelectedItem.Value == "2")Building14(); break; }
        //        case "15": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "OPH") Summary15_Oph(); else Summary15(); } else if (drtype.SelectedItem.Value == "2")Building15(); break; }
        //        case "17": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary17_1(); else Summary17(); } else if (drtype.SelectedItem.Value == "2")Building17(); break; }
        //        case "18": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary17_1(); else Summary18(); } else if (drtype.SelectedItem.Value == "2")Building18(); break; }
        //        case "19": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary19_1(); else Summary19(); } else if (drtype.SelectedItem.Value == "2")Building19(); break; }
        //        case "20": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary20_2(); else if (lblprj.Text == "14211")Summary20_14211(); else Summary20(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211")Building_Summary(20); else Building20(); } break; }
        //        case "21": { if (drtype.SelectedItem.Value == "1") Summary21(); else if (drtype.SelectedItem.Value == "2")Building21(); break; }
        //        case "22": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else Summary22(); } else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211")Building_Summary(22);else Building22(); break; }
        //        //case "23": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary23_1(); else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")Summary23_2(); else Summary23(); } else if (drtype.SelectedItem.Value == "2")Building23(); break; }
        //        case "23": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary23_1(); else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")Summary23_2(); else Summary23(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo") Building_Summary(23); else Building23(); } break; }
        //        case "16": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else Summary16(); } else if (drtype.SelectedItem.Value == "2")Building16(); break; }
        //        case "24": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "12761")Summary24_2(); else Summary24(); } else if (drtype.SelectedItem.Value == "2")Building24(); break; }
        //        case "30": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211") Summary30_14211(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211")Building_Summary(30); else Building8(); break; }
        //        case "25": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "OPH") Summary25a(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "27": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary27_1(); else if (lblprj.Text == "12761")Summary23_12761(); else if (lblprj.Text == "OPH")Summary27_OPH(); if (lblprj.Text == "HMIM")Summary27_HMIM(); else Summary8(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "HMIM")Building_Summary(27); else Building8(); break; }
        //        case "26": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "OPH") Summary26_oph(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "28": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary28_1(); else if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")Summary10(); else if (lblprj.Text == "14211")Summary28_14221(); else if (lblprj.Text == "OPH")Summary24(); else Summary19(); } else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211")Building_Summary(28); else Building19(); break; }
        //        case "34": { if (drtype.SelectedItem.Value == "1") if (lblprj.Text == "14211")Summary34_14211(); else Summary34(); else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "14211") Building_Summary(34); else Building34(); break; }
        //        case "35": { if (drtype.SelectedItem.Value == "1") if (lblprj.Text == "14211")Summary35_14211(); else Summary34(); else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211")Building_Summary(35);else Building34(); break; }
        //        case "36": { if (drtype.SelectedItem.Value == "1") Summary34(); else if (drtype.SelectedItem.Value == "2")Building34(); break; }
        //        case "32": { if (drtype.SelectedItem.Value == "1")if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary32(); else if (lblprj.Text == "14211")Summary32_14211(); else Summary20(); else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211")Building_Summary(32); else Building20(); break; }
        //        case "31": { if (drtype.SelectedItem.Value == "1")if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary31(); else if (lblprj.Text == "14211") Summary31_14221(); else Summary10(); else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211")Building_Summary(31); else Building10(); break; }
        //        case "37": { if (drtype.SelectedItem.Value == "1") Summary37(); else if (lblprj.Text == "14211")Summary37_14211(); else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211")Building_Summary(37); Building37(); break; }
        //        case "29": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary29_1(); else if (lblprj.Text == "14211")Summary29_14211(); else if (lblprj.Text == "ASAO") Summary29_ASAO(); else Summary8(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "14211")Building_Summary(29); else Building8(); break; }
        //        case "121": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2") Building2(); break; }
        //        case "119": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2")Building2(); break; }
        //        case "118": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2")Building2(); break; }
        //        case "44": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary5_1(); else Summary1_5(); } else if (drtype.SelectedItem.Value == "2")Building1_5(); break; }
        //        case "46": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary27_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "51": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "52": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "53": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "54": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; } 
        //        case "55": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "56": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "57": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "58": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "59": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "60": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "62": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "61": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
        //        case "39": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211") Summary39_14211(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "14211")Building_Summary(39); break; }
        //        case "33": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211") Summary33(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "14211")Building_Summary(33); break; }
                
        //    }

        //}
        private void Generate_Summary()
        {

            switch (lblsch1.Text)
            {
                case "1": { if (drtype.SelectedItem.Value == "1")  Summary1_5(); else if (drtype.SelectedItem.Value == "2") Building1_5(); break; }
                case "2": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(2); else Building2(); } break; }
                case "3": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary3_1(); else Summary3(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(3); else Building3(); } break; }
                case "120": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary3_1(); else Summary3(); } else if (drtype.SelectedItem.Value == "2")Building3(); break; }
                case "4": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary4_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary4_2(); else Summary4(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(4); else Building_Summary(4); } break; }
                case "5": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary5_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "OPH") Summary5_asao(); else Summary1_5(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(5); else Building1_5(); } break; }
                case "6": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary6_1(); else Summary6(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(6); else Building6(); } break; }
                case "7": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary7_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1") { Summary_7_1(); } else Summary7(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(7); else Building7(); } break; }
                case "8": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(8); else Building8(); } break; }
                case "9": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary9_1(); else Summary9(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(9); else Building9(); } break; }
                case "10": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary10_1_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1") Summary10_2(); else if (lblprj.Text == "11736")Summary10_11736(); else if (lblprj.Text == "14211")Summary10_14211(); else if (lblprj.Text == "HMIM")Summary10_HMIM(); else Summary10(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211" || lblprj.Text == "demo" || lblprj.Text == "BCC1" || lblprj.Text == "11784") Building_Summary(10); else Building10(); } break; }
                case "11": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1") Summary11_1(); else Summary11(); } else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211" || lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(11); else Building11(); break; }
                case "12": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary12_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary12_2(); else if (lblprj.Text == "MOE")Summary12_moe(); else if (lblprj.Text == "14211")Summary12_14211(); else Summary12_OPH(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "MOE" || lblprj.Text == "demo" || lblprj.Text == "BCC1" || lblprj.Text == "11784") Building12_moe(); else Building12(); } break; }
                case "13": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "14211")Summary13_14211(); else Summary13(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211" || lblprj.Text == "11784") Building_Summary(13); else Building13(); } break; }
                case "14": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else Summary14(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(14); else Building14(); } break; }
                case "15": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "OPH") Summary15_Oph(); else Summary15(); } else if (drtype.SelectedItem.Value == "2")Building15(); break; }
                case "17": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary17_1(); else Summary17(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(17); else Building17(); } break; }
                case "18": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary17_1(); else Summary18(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(18); else Building18(); } break; }
                case "19": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary19_1(); else Summary19(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(19); else Building19(); } break; }
                case "20": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary20_2(); else Summary20(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211" || lblprj.Text == "BCC1" || lblprj.Text == "11784") Building_Summary(20); else Building20(); } break; }
                case "21": { if (drtype.SelectedItem.Value == "1") Summary21(); else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(21); else Building21(); } break; }
                case "22": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else Summary22(); } else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211" || lblprj.Text == "11784") Building_Summary(22); else Building22(); break; }
                case "23": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary23_1(); else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")Summary23_2(); else Summary23(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "11784") Building_Summary(23); else Building23(); } break; }
                case "16": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else Summary16(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "demo" || lblprj.Text == "BCC1") Building_Summary(16); else Building16(); } break; }
                case "24": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary20_1(); else if (lblprj.Text == "12761") Summary24_2(); else Summary24(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "11784") Building_Summary(24); else Building24(); } break; }
                case "30": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211") Summary30_14211(); else if (lblprj.Text == "11784") Summary7(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211" || lblprj.Text=="11784")Building_Summary(30); else Building8(); break; }
                case "25": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "OPH") Summary25a(); else if (lblprj.Text == "11784") Summary2(); else Summary8(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "11784")Building_Summary(25); else Building8(); } break; }
                case "27": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary27_1(); else if (lblprj.Text == "12761")Summary23_12761(); else if (lblprj.Text == "12761")Summary27_OPH(); else if (lblprj.Text == "HMIM" || lblprj.Text == "OCEC")Summary27_HMIM(); else if (lblprj.Text == "11784")Summary4(); else Summary8(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "HMIM" || lblprj.Text=="11784")Building27(); else  Building8(); break; }
                case "26": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary20_1(); else if (lblprj.Text == "11784")Summary3(); else Summary8(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "11784") Building_Summary(26); else Building8(); } break; }
                case "28": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary28_1(); else if (lblprj.Text == "HMIM")Summary28_HMIM(); else if (lblprj.Text == "14211")Summary28_14221(); else if (lblprj.Text == "OPH")Summary24(); else if (lblprj.Text == "11784") Summary1_5(); else Summary19(); } else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211" || lblprj.Text == "11784")Building_Summary(28); else Building19(); break; }
                case "34": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211") Summary34_14211(); else if (lblprj.Text == "11784") Summary11(); else Summary34(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211" || lblprj.Text=="11784")Building_Summary(34); else Building34(); } break; }
                case "35": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211") Summary35_14211(); if (lblprj.Text == "11784") Summary12(); else Summary34(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211" || lblprj.Text=="11784") Building_Summary(35); else Building34(); } break; }
                case "36": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "11784") Summary13(); else Summary34(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "11784") Building_Summary(36);  Building34(); } break; }
                case "32": { if (drtype.SelectedItem.Value == "1")if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary32(); else if (lblprj.Text == "14211")Summary32_14211(); else if (lblprj.Text == "11784")Summary9(); else if (lblprj.Text == "MOE")Summary24(); else Summary20(); else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211" || lblprj.Text == "11784")Building_Summary(32); else Building20(); break; }
                case "31": { if (drtype.SelectedItem.Value == "1")if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")Summary31(); else if (lblprj.Text == "14211") Summary31_14221(); else if (lblprj.Text == "11784")  Summary8(); else if (lblprj.Text == "MOE")  Summary23_12761(); else Summary10(); else if (drtype.SelectedItem.Value == "2")if (lblprj.Text == "14211" || lblprj.Text == "11784")Building_Summary(31); else Building10(); break; }
                case "37": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211")Summary37_14211(); else if (lblprj.Text == "11784")Summary14(); else Summary37(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "14211" || lblprj.Text=="11784") Building_Summary(37); else Building37(); } break; }
                case "29": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary29_1(); else if (lblprj.Text == "14211")Summary29_14211(); else if (lblprj.Text == "11784")Summary6(); else Summary8(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "14211" || lblprj.Text == "11784")Building_Summary(29); else Building8(); break; }
                case "121": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2") Building2(); break; }
                case "119": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2")Building2(); break; }
                case "118": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary2_1(); else Summary2(); } else if (drtype.SelectedItem.Value == "2")Building2(); break; }
                case "44": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary5_1(); else if (lblprj.Text == "11784") Summary23(); else Summary1_5(); } else if (drtype.SelectedItem.Value == "2") { if (lblprj.Text == "11784")Building_Summary(44); else Building1_5(); } break; }
                case "46": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD")Summary27_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "51": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "52": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "53": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "54": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "55": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "56": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "57": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "58": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "59": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "60": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "62": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "61": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "CCAD") Summary8_1(); else Summary8(); } else if (drtype.SelectedItem.Value == "2")Building8(); break; }
                case "39": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211") Summary39_14211(); else if (lblprj.Text == "11784") Summary18(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "14211")Building_Summary(39); break; }
                case "33": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "14211") Summary33(); else if (lblprj.Text == "14211") Summary10(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "14211" || lblprj.Text=="11784")Building_Summary(33); break; }
                case "38": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "11784") Summary17(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "11784")Building_Summary(38); break; }
                case "40": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "11784") Summary19(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "11784")Building_Summary(40); break; }
                case "41": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "11784") Summary20(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "11784")Building_Summary(41); break; }
                case "42": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "11784") Summary21(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "11784")Building_Summary(42); break; }
                case "43": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "11784") Summary22(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "11784")Building_Summary(43); break; }
                case "45": { if (drtype.SelectedItem.Value == "1") { if (lblprj.Text == "11784") Summary24(); } else if (drtype.SelectedItem.Value == "2") if (lblprj.Text == "11784")Building_Summary(45); break; }
                

            }

        }
        private void Summary39()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;

                decimal _total = 0;
                int count = 0;
                int count_COT = 0;

                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;


                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());



                    count_COT += 1;
                    count += Convert.ToInt32(_row["devices1"].ToString());



                    if (_row["Cat"].ToString() == "R21" || _row["Cat"].ToString() == "R22" || _row["Cat"].ToString() == "R25" || _row["Cat"].ToString() == "R26" || _row["Cat"].ToString() == "R27")
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count2 += 1;

                    }

                    if (_row["Cat"].ToString() == "R01" || _row["Cat"].ToString() == "R02" || _row["Cat"].ToString() == "R09")
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count3 += 1;

                    }

                    if (_row["Cat"].ToString() == "R10" || _row["Cat"].ToString() == "R11")
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        count4 += 1;

                    }
                    if (_row["Cat"].ToString() == "R03" || _row["Cat"].ToString() == "R05")
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        count5 += 1;

                    }


                }

                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 39;

                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();


                    if (row[0].ToString() == "Cable Test")
                    {
                        _drow[1] = count.ToString();
                        _drow[2] = decimal.Round(_p1).ToString();
                        if (count > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count) * 100);
                    }
                    else if (row[0].ToString() == "Repeater Functional Test")
                    {
                        _drow[1] = count2.ToString();
                        _drow[2] = decimal.Round(_p2).ToString();
                        if (count2 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count2) * 100);
                    }
                    else if (row[0].ToString() == "Antenna Functional Test")
                    {
                        _drow[1] = count3.ToString();
                        _drow[2] = decimal.Round(_p3).ToString();
                        if (count3 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count3) * 100);
                    }
                    else if (row[0].ToString() == "Splitter Functional Test")
                    {
                        _drow[1] = count4.ToString();
                        _drow[2] = decimal.Round(_p4).ToString();
                        if (count4 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count4) * 100);
                    }
                    else if (row[0].ToString() == "Coupler /Combiner Functional Test")
                    {
                        _drow[1] = count5.ToString();
                        _drow[2] = decimal.Round(_p5).ToString();
                        if (count5 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count5) * 100);
                    }
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary34_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;
                    string _s = "";

                    decimal _t1 = 0;
                    decimal _t2 = 0;
                    decimal _t3 = 0;

                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        else
                            _t1 += 1;

                        if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            count2 += 1;
                        }
                        else
                            _t2 += 1;

                        if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            count3 += 1;
                        }
                        else
                            _t3 += 1;

                        _s = _row[0].ToString();
                        count += 1;
                        _s = _row[0].ToString();

                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;

                    if (_t1 >= count) _per1 = -1;
                    if (_t2 >= count) _per2 = -1;
                    if (_t3 >= count) _per3 = -1;



                    if (_per1 >= 0)
                    {
                        if (count1 != 0)
                            _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1));
                    }

                    if (_per2 >= 0)
                    {
                        if (count2 != 0)
                            _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count2));
                    }

                    if (_per3 >= 0)
                    {
                        if (count3 != 0)
                            _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count3));
                    }


                    if (_per1 != -1 && _per2 == -1 && _per3 == -1)
                    {
                        _total = Decimal.Round((_per1), MidpointRounding.AwayFromZero);
                        //_p2 = -1;
                    }
                    else if (_per1 == -1 && _per2 != -1 && _per3 == -1)
                    {
                        _total = Decimal.Round((_per2), MidpointRounding.AwayFromZero);
                        //_p2 = -1;
                    }
                    else if (_per1 == -1 && _per2 == -1 && _per3 != -1)
                    {
                        _total = Decimal.Round((_per3), MidpointRounding.AwayFromZero);
                        // _p2 = -1;
                    }
                    else if (_per1 == -1 && _per2 != -1 && _per3 != -1)
                    {
                        _total = Decimal.Round(((_per2 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                        //_p2 = -1;
                    }
                    else if (_per1 != -1 && _per2 != -1 && _per3 == -1)
                    {
                        _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), MidpointRounding.AwayFromZero);
                        // _p2 = -1;
                    }
                    else if (_per1 != -1 && _per2 == -1 && _per3 != -1)
                    {
                        _total = Decimal.Round(((_per1 * 0.6m) + (_per3 * 0.4m)), MidpointRounding.AwayFromZero);
                        //_p2 = -1;
                    }
                    else
                        _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.1m) + (_per3 * 0.3m)), MidpointRounding.AwayFromZero);

                    if (_total < 0) _total = 0;

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = _per3.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary33()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;



                decimal _total = 0;
                int count = 0;
                int count1 = 0;


                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }


                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        count1 += Convert.ToInt32(_row["devices1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    }


                }

                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 33;

                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();


                    if (row[0].ToString() == "Cable Test")
                    {
                        _drow[1] = count.ToString();
                        _drow[2] = decimal.Round(_p1).ToString();

                        if (count > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count) * 100);



                    }
                    else if (row[0].ToString() == "Functional Test")
                    {
                        _drow[1] = count1.ToString();
                        _drow[2] = decimal.Round(_p2).ToString();
                        if (count1 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count1) * 100);

                    }

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }

        }
        private void Summary1_5()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    int _na1 = 0;
                    int _na2 = 0;

                    //25-05-2017-Jene : Changes made to change count value from item count to circuit count.
                    int circuitCount = 0;
                    int coldTestCount = 0;
                    int liveTestCount = 0;


                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        if (_row["tested1"].ToString().Length > 0 && IsNumeric(_row["tested1"].ToString()) == false) _na1 += 1;
                        if (_row["tested2"].ToString().Length > 0 && IsNumeric(_row["tested2"].ToString()) == false) _na2 += 1;
                        count += 1;

                        //25-05-2017-Jene : Changes made to change count value from item count to circuit count.
                        if (_row["tested1"] != null && _row["tested1"].ToString() != "" && IsNumeric(_row["tested1"].ToString()))
                        {
                            coldTestCount += Convert.ToInt32(_row["tested1"]);
                        }
                        if (_row["tested2"] != null && _row["tested2"].ToString() != "" && IsNumeric(_row["tested2"].ToString()))
                        {
                            liveTestCount += Convert.ToInt32(_row["tested2"]);
                        }
                        if (_row["devices1"] != null && _row["devices1"].ToString() != "")
                        {
                            circuitCount += Convert.ToInt32(_row["devices1"]);
                        }
                        //END


                    }
                    //decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count),0,MidpointRounding.AwayFromZero);
                    //decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                    //decimal _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;

                    if (count != 0)
                        _per1 = (_p1 / Convert.ToDecimal(count));

                    //25-05-2017-Jene : Changes made to change count value from item count to circuit count.
                    //if (count != 0)
                    //{
                    //    if (_na1 == count)
                    //        _per2 = -1;
                    //    else
                    //        _per2 = (_p2 / Convert.ToDecimal(count - _na1));
                    //}
                    //if (count != 0)
                    //{
                    //    if (_na2 == count)
                    //        _per3 = -1;
                    //    else
                    //        _per3 = (_p3 / Convert.ToDecimal(count - _na2));
                    //}

                    if (coldTestCount != 0 && circuitCount != 0)
                    {
                        _per2 = ((coldTestCount * 100) / Convert.ToDecimal(circuitCount));
                    }
                    if (liveTestCount != 0 && circuitCount != 0)
                    {
                        _per3 = ((liveTestCount * 100) / Convert.ToDecimal(circuitCount));
                    }
                    //END




                    if (lblsch1.Text == "5" || (lblsch1.Text == "28" && lblprj.Text == "11784"))
                    {
                        _total = 0;
                        if (row.col3.ToString() == "MDB")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "PFC")
                        {
                            if (lblprj.Text == "HMIM" || lblprj.Text == "HMHS")
                            {
                                _total = Decimal.Round((_per1), MidpointRounding.AwayFromZero);
                                _per2 = -1;
                                _per3 = -1;

                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                            {
                                if (_per2 == -1 && _per3 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                }
                                else if (_per3 == -1 && _per2 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p3 = -1;
                                }
                                else if (_per2 == -1 && _per3 == -1)
                                {
                                    _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                    _p3 = -1;
                                }
                                else

                                    _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                            }
                        }
                        else if (row.col3.ToString() == "HCP")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "DB")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                            {
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                _p1 = -1;
                            }
                        }
                        else if (row.col3.ToString() == "LCP")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                            {
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                _p1 = -1;
                            }
                        }
                        else if (row.col3.ToString() == "UPS")
                        {
                            if (lblprj.Text == "MOE" || lblprj.Text == "MOE1")
                            {
                                if (_per1 != -1 && _per2 == -1)
                                {
                                    _total = Decimal.Round((_per1), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                }
                                else if (_per1 == -1 && _per2 != -1)
                                {
                                    _total = Decimal.Round((_per2), MidpointRounding.AwayFromZero);
                                    _p1 = -1;
                                }
                                else
                                    _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                if (_per2 == -1 && _per3 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                }
                                else if (_per3 == -1 && _per2 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p3 = -1;
                                }
                                else if (_per2 == -1 && _per3 == -1)
                                {
                                    _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                    _p3 = -1;
                                }
                                else
                                {
                                    _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                    _p1 = -1;
                                }
                            }
                        }
                        else if (row.col3.ToString() == "EFP")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                            {
                                _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                                _p1 = -1;
                            }
                        }
                        else if (row.col3.ToString() == "SMDB")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "MCC")
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                        else if (row.col3.ToString() == "ATS")
                        {
                            if (lblprj.Text == "MOE" || lblprj.Text == "MOE1")
                            {
                                if (_per1 != -1 && _per2 == -1)
                                {
                                    _total = Decimal.Round((_per1), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                }
                                else if (_per1 == -1 && _per2 != -1)
                                {
                                    _total = Decimal.Round((_per2), MidpointRounding.AwayFromZero);
                                    _p1 = -1;
                                }
                                else
                                    _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                if (_per2 == -1 && _per3 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                }
                                else if (_per3 == -1 && _per2 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p3 = -1;
                                }
                                else if (_per2 == -1 && _per3 == -1)
                                {
                                    _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                    _p3 = -1;
                                }
                                else
                                    _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                            }
                        }

                        else if (row.col3.ToString() == "BDT")
                        {
                            if (lblprj.Text == "MOE" || lblprj.Text == "MOE1")
                            {
                                _total = Decimal.Round((_per1), MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                //_p3 = -1;
                                if (_per2 == -1 && _per3 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                }
                                else if (_per3 == -1 && _per2 != -1)
                                {
                                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                    _p3 = -1;
                                }
                                else if (_per2 == -1 && _per3 == -1)
                                {
                                    _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                    _p2 = -1;
                                    _p3 = -1;
                                }
                                else
                                    _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                            }
                        }
                        else
                        {
                            if (_per2 == -1 && _per3 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                            }
                            else if (_per3 == -1 && _per2 != -1)
                            {
                                _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                                _p3 = -1;
                            }
                            else if (_per2 == -1 && _per3 == -1)
                            {
                                _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                                _p2 = -1;
                                _p3 = -1;
                            }
                            else
                                _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                    }
                    if (_total < 0) _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = _per3.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary5_asao()
        {
            try
            {
                decimal _circuits = 0;
                decimal _tlive = 0;
                decimal _tcold = 0;
                decimal _twit = 0;
                decimal _panel = 0;
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _total = 0;
                    decimal _circuit = 0;
                    int count = 0;
                    string _s = "";
                    decimal _na1 = 0;
                    decimal _na2 = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p1 += 1;
                        //if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                        //    _p2 += 1;
                        //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        //if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100)
                        //    _p3 += 1;
                        //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        if (row.col3.ToString() == "DB")
                        {
                            _circuits += Convert.ToDecimal(_row["devices1"].ToString());
                            if (IsNumeric(_row["tested1"].ToString()) == true)
                                _tcold += Convert.ToInt32(_row["tested1"].ToString());
                            if (IsNumeric(_row["tested2"].ToString()) == true)
                                _tlive += Convert.ToInt32(_row["tested2"].ToString());
                            _twit += Convert.ToInt32(_row["per_com4"].ToString());
                        }
                        _circuit += Convert.ToDecimal(_row["devices1"].ToString());
                        decimal _device = 0;
                        _device = Convert.ToDecimal(_row["devices1"].ToString());
                        if (_row["tested1"].ToString().Length > 0 && IsNumeric(_row["tested1"].ToString()) == false) _na1 += _device;
                        if (_row["tested2"].ToString().Length > 0 && IsNumeric(_row["tested2"].ToString()) == false) _na2 += _device;
                        _p5 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;

                    if (count != 0)
                        _per1 = (_p5 / Convert.ToDecimal(count));
                    //if (_circuits != 0)
                    //{
                    if (_na1 >= _circuit)
                        _per2 = -1;
                    else
                    {
                        if (_circuit > 0)
                            _per2 = (_p2 / Convert.ToDecimal(_circuit - _na1)) * 100;
                    }
                    //}
                    //if (_circuits != 0)
                    //{
                    if (_na2 >= _circuit)
                        _per3 = -1;
                    else
                    {
                        if (_circuit > 0)
                            _per3 = (_p3 / Convert.ToDecimal(_circuit - _na2)) * 100;
                    }
                    //}
                    //_tlive += _p2;
                    //_tcold += _p3;
                    //_twit += _p4;
                    _panel += _p1;
                    if (row.col3.ToString() == "MDB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "PFC")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "HCP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "DB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "LCP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "UPS")
                    {
                        if (_per2 == -1 && _per3 != -1 && _per1 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1 && _per1 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1 && _per1 != -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else if (_per2 != -1 && _per3 != -1 && _per1 == -1)
                        {
                            _total = Decimal.Round(((_per2 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                        }
                    }
                    else if (row.col3.ToString() == "EFP")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                        {
                            _total = Decimal.Round((_per2 * 0.6m) + (_per3 * 0.4m), MidpointRounding.AwayFromZero);
                            _p1 = -1;
                        }
                    }
                    else if (row.col3.ToString() == "SMDB")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "MCC")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "ATS")
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }

                    else if (row.col3.ToString() == "BDT")
                    {
                        //_p3 = -1;
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else if (row.col3.ToString() == "GPU")
                    {
                        //_p3 = -1;
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.8m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        if (_per2 == -1 && _per3 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                        }
                        else if (_per3 == -1 && _per2 != -1)
                        {
                            _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), MidpointRounding.AwayFromZero);
                            _p3 = -1;
                        }
                        else if (_per2 == -1 && _per3 == -1)
                        {
                            _total = Decimal.Round(((_per1)), MidpointRounding.AwayFromZero);
                            _p2 = -1;
                            _p3 = -1;
                        }
                        else
                            _total = Decimal.Round((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m), MidpointRounding.AwayFromZero);
                    }
                    if (_total < 0) _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        private void Summary2()
        {            
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    int count1 = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    int _count2 = 0;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        //if (_row["Pwr_on"].ToString().ToUpper() != "N/A")
                        //{
                        //    _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                        //    _count2 += 1;
                        //}
                        if (_row["test14"].ToString().ToUpper() != "N/A")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _count2 += 1;
                        }
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1),0,MidpointRounding.AwayFromZero);
                    decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count),0,MidpointRounding.AwayFromZero);
                    decimal _per3 = (_p3) / Convert.ToDecimal(_count2);
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                        _total = Decimal.Round(_per1 * 0.6m + _per3 * 0.4m);
                    else
                        _total = Decimal.Round((_per1 * 0.9m) + (_per2 * 0.1m),0,MidpointRounding.AwayFromZero);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary25a()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;
                    string _s = "";
                    //int count1 = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) >= 0)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            count2 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) >= 0)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            count3 += 1;
                        }
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (count1 > 0)
                        _per1 = (_p1 / Convert.ToDecimal(count1)) * 100;
                    if (count2 > 0)
                        _per2 = (_p2 / Convert.ToDecimal(count2)) * 100;
                    if (count3 > 0)
                        _per3 = (_p3 / Convert.ToDecimal(count3)) * 100;
                    _total = Decimal.Round(((_per1 + _per2 + _per3) / 3), MidpointRounding.AwayFromZero);

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = 0;
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = _per3.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                //mygridsumm.DataSource = _dtsummary;
                //mygridsumm.DataBind();
                //_summary = _dtsummary;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary8()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        }
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1) 
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        }
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        }
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = _p1 / Convert.ToDecimal(count);
                    decimal _per2 = _p2 / Convert.ToDecimal(count);
                    decimal _per3 = _p3 / Convert.ToDecimal(count);
                    _total = Decimal.Round((((_per1 * 0.2m) + (_per2 * 0.8m)) * 100), MidpointRounding.AwayFromZero);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary26_oph()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    decimal count1 = 0;
                    decimal count2 = 0;
                    decimal count3 = 0;
                    decimal count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                count1 += Convert.ToDecimal(_row["devices1"].ToString());
                        }
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                count2 += Convert.ToDecimal(_row["devices1"].ToString());
                        }
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                count3 += Convert.ToDecimal(_row["devices1"].ToString());
                        }

                        if (IsNumeric(_row["devices1"].ToString()) == true)
                            count += Convert.ToDecimal(_row["devices1"].ToString());
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (count1 > 0)
                        _per1 = (_p1 / count1) * 100;
                    if (count2 > 0)
                        _per2 = (_p2 / count2) * 100;
                    if (count3 > 0)
                        _per3 = (_p3 / count3) * 100;
                    _total = Decimal.Round((_per1 * 0.3m) + (_per2 * 0.3m) + (_per2 * 0.4m), 0, MidpointRounding.AwayFromZero);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary29_ASAO()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        if (IsNumeric(_row["devices1"].ToString()) == true)
                            count += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (count > 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "-1";
                    _drow[3] = Decimal.Round(_p1).ToString();
                    _drow[4] = Decimal.Round(_p2).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary3()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    int count1 = 0;
                    int _count2 = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        if (_row["test14"].ToString().ToUpper() != "N/A")
                        {
                            _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _count2 += 1;
                        }
                        
                        count += 1;
                    }
                    decimal _per1=0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (count1>0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1),0,MidpointRounding.AwayFromZero);
                    
                    if (count > 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count),0,MidpointRounding.AwayFromZero);
                       
                    }
                    if (_count2>0)
                        _per3 = (_p3) / Convert.ToDecimal(_count2);
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                        _total = Decimal.Round(_per1* 0.6m + _per3 * 0.4m);
                    else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                        _total = Decimal.Round(_per2);
                    else
                    {
                        if(_p1<0)
                            _total=Decimal.Round(_per2 * 0.1m);
                        else
                            _total = Decimal.Round((_per1 * 0.9m) + (_per2 * 0.1m),0,MidpointRounding.AwayFromZero);
                    }
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary6()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;
                    int _cnt = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) >= 0)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            count1 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) >= 0)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            count2 += 1;
                        }
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                        {
                            _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                            count3 += 1;
                        }
                        _s = _row[0].ToString();
                        _cnt += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    if (count > 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 0, MidpointRounding.AwayFromZero);
                    if (count1 > 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count1), 0, MidpointRounding.AwayFromZero);
                    if (count2 > 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count2), 0, MidpointRounding.AwayFromZero);
                    if (count3 > 0)
                        _per4 = Decimal.Round(_p4 / Convert.ToDecimal(count3), 0, MidpointRounding.AwayFromZero);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    if (row.col3.ToString() == "LP")
                    {
                        _drow[2] = _per3.ToString();
                        _drow[3] = _per4.ToString();
                        _total = Decimal.Round((_per3 * 0.9m) + (_per4 * 0.1m),0,MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        _drow[2] = _per1.ToString();
                        _drow[3] = _per2.ToString();
                        _total = Decimal.Round((_per1 * 0.9m) + (_per2 * 0.1m),0,MidpointRounding.AwayFromZero);
                    }
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //private void Summary4()
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            //_row[0] = row.col1.ToString();
        //            //_row[1] = row.col2.ToString();
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _total = 0;
        //            int count = 0;
        //            int count2 = 0;
        //            int count3 = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
        //                {
        //                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                    count += 1;
        //                }
        //                if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
        //                {
        //                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                    count2 += 1;
        //                }
        //                if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
        //                {
        //                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                    count3 += 1;
        //                }
        //                _s = _row[0].ToString();
                       
        //            }
        //            decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
        //            decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count2));
        //            decimal _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count3));
        //            _total = Decimal.Round((_per1 * 0.6m) + (_per2 * 0.1m) + (_per3 * 0.3m));
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = _per1.ToString();
        //            _drow[3] = _per2.ToString();
        //            _drow[4] = _per3.ToString();
        //            _drow[5] = _total.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        private void Summary4()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;
                    string _s = "";

                    decimal _t1 = 0;
                    decimal _t2 = 0;
                    decimal _t3 = 0;

                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        else
                            _t1 += 1;

                        if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            count2 += 1;
                        }
                        else
                            _t2 += 1;

                        if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            count3 += 1;
                        }
                        else
                            _t3 += 1;

                        _s = _row[0].ToString();
                        count += 1;
                        _s = _row[0].ToString();

                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;

                    if (_t1 >= count) _per1 = -1;
                    if (_t2 >= count) _per2 = -1;
                    if (_t3 >= count) _per3 = -1;



                    if (_per1 >= 0)
                    {
                        if (count1 != 0)
                            _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count1));
                    }

                    if (_per2 >= 0)
                    {
                        if (count2 != 0)
                            _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count2));
                    }

                    if (_per3 >= 0)
                    {
                        if (count3 != 0)
                            _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count3));
                    }


                    if (_per1 != -1 && _per2 == -1 && _per3 == -1)
                    {
                        _total = Decimal.Round((_per1), MidpointRounding.AwayFromZero);
                        //_p2 = -1;
                    }
                    else if (_per1 == -1 && _per2 != -1 && _per3 == -1)
                    {
                        _total = Decimal.Round((_per2), MidpointRounding.AwayFromZero);
                        //_p2 = -1;
                    }
                    else if (_per1 == -1 && _per2 == -1 && _per3 != -1)
                    {
                        _total = Decimal.Round((_per3), MidpointRounding.AwayFromZero);
                        // _p2 = -1;
                    }
                    else if (_per1 == -1 && _per2 != -1 && _per3 != -1)
                    {
                        _total = Decimal.Round(((_per2 * 0.5m) + (_per3 * 0.5m)), MidpointRounding.AwayFromZero);
                        //_p2 = -1;
                    }
                    else if (_per1 != -1 && _per2 != -1 && _per3 == -1)
                    {
                        _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), MidpointRounding.AwayFromZero);
                        // _p2 = -1;
                    }
                    else if (_per1 != -1 && _per2 == -1 && _per3 != -1)
                    {
                        _total = Decimal.Round(((_per1 * 0.8m) + (_per3 * 0.2m)), MidpointRounding.AwayFromZero);
                        //_p2 = -1;
                    }
                    else
                        _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.1m) + (_per3 * 0.3m)), MidpointRounding.AwayFromZero);

                    if (_total < 0) _total = 0;

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = _per3.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        private void Summary4_2()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p1 += 1;
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) == 100)
                            _p2 += 1;
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    decimal _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)) * 100);
                    _total = Decimal.Round((_per1 * 0.7m) + (_per2 * 0.3m));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary7()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;

                int count = 0;
                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;
                int count6 = 0;
                int count7 = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());


                    }
                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count2 += Convert.ToInt32(_row["devices1"].ToString());
                    }

                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count3 += Convert.ToInt32(_row["devices1"].ToString());
                    }

                    if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        count4 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        count5 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                    {
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        count6 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                    {
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count7 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    //count += Convert.ToInt32(_row["devices1"].ToString());

                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);

                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = count.ToString();
                    if (row[0].ToString() == "Continuity/IR Test Complete")
                    {
                        _drow[2] = decimal.Round(_p1).ToString();
                        _drow[1] = count.ToString();
                        if (count > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count) * 100;
                    }
                    else if (row[0].ToString() == "Addressing")
                    {
                        _drow[2] = decimal.Round(_p2).ToString();
                        _drow[1] = count2.ToString();
                        if (count2 > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count2) * 100;
                    }
                    else if (row[0].ToString() == "Fault Testing")
                    {
                        _drow[2] = decimal.Round(_p3).ToString();
                        _drow[1] = count3.ToString();
                        if (count3 > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count3) * 100;
                    }
                    else if (row[0].ToString() == "Change Over Test")
                    {
                        _drow[2] = decimal.Round(_p4).ToString();
                        _drow[1] = count4.ToString();
                        if (count4 > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count4) * 100;
                    }
                    else if (row[0].ToString() == "Lux Level Test")
                    {
                        _drow[2] = decimal.Round(_p5).ToString();
                        _drow[1] = count5.ToString();
                        if (count5 > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count5) * 100;
                    }
                    else if (row[0].ToString() == "Duration Test")
                    {
                        _drow[2] = decimal.Round(_p6).ToString();
                        _drow[1] = count6.ToString();
                        if (count6 > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count6) * 100;
                    }
                    else if (row[0].ToString() == "PC Head End Test"|| row[0].ToString() == "Pc Head End Test")
                    {
                        _drow[2] = decimal.Round(_p7).ToString();
                        _drow[1] = count7.ToString();
                        if (count7 > 0)
                            _total = (Convert.ToDecimal(_drow[2].ToString()) / count7) * 100;
                    }
                    if (_total >= 99.5m && _total < 100m) _total = 99;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = decimal.Round(_total).ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary20()
        {
            try
            {
               _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _points = 0;
                decimal _devices = 0;
                decimal _systems = 0;
                decimal _total = 0;
                decimal _points2 = 0;
                decimal _systems2 = 0;
                decimal _systems3 = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _points += Convert.ToInt32(_row["devices3"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _points2 += Convert.ToInt32(_row["devices3"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _systems += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _systems2 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                    {
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _systems3 += Convert.ToInt32(_row["devices1"].ToString());
                    }  

                    //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    //_points += Convert.ToInt32(_row["devices3"].ToString());
                    //_devices += Convert.ToInt32(_row["devices2"].ToString());
                    //_systems += Convert.ToInt32(_row["devices1"].ToString());

                    //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    //_points += Convert.ToInt32(_row["devices3"].ToString());
                    //_devices += Convert.ToInt32(_row["devices2"].ToString());
                    //_systems += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 20;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();

                    if (row[0].ToString() == "Cable Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_points); }
                    else if (row[0].ToString() == "Points to Points Test") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_points2); }
                    else if (row[0].ToString() == "Calibration/Functional Test") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_devices); }
                    else if (row[0].ToString() == "Sequence of Operation") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Graphic/Head End Test") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_systems2); }
                    else if (row[0].ToString() == "Loop Tuning") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_systems3); }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_drow[2].ToString() != "0")
                    {
                        _total =(Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100;
                        if (_total >= 99.5m && _total < 100m) _total = 99;
                    }
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = decimal.Round(_total).ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary20_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _points = 0;
                decimal _devices = 0;
                decimal _systems = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _points += Convert.ToInt32(_row["devices3"].ToString());
                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                    _systems += Convert.ToInt32(_row["devices1"].ToString());

                    //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    //_points += Convert.ToInt32(_row["devices3"].ToString());
                    //_devices += Convert.ToInt32(_row["devices2"].ToString());
                    //_systems += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 20;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Cable Continuity / IR Tests") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_points); }
                    else if (row[0].ToString() == "Points to Points Tests") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_points); }
                    else if (row[0].ToString() == "Calibration / Functional Test") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_devices); }
                    else if (row[0].ToString() == "Sequence of Operation") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Graphic / Head End Tests") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_systems); }
                    else if (row[0].ToString() == "Loop Tuning") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_systems); }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary32_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _total = 0;
                int count = 0;
                int count_COT = 0;

                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;


                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {

                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());

                        count_COT += 1;
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }

                    if (_row["Cat"].ToString() == "R21" || _row["Cat"].ToString() == "R22" || _row["Cat"].ToString() == "R25" || _row["Cat"].ToString() == "R26" || _row["Cat"].ToString() == "R27")
                    {
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            count2 += 1;
                        }

                    }

                    if (_row["Cat"].ToString() == "R01" || _row["Cat"].ToString() == "R02" || _row["Cat"].ToString() == "R09")
                    {
                        if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            count3 += 1;
                        }

                    }

                    if (_row["Cat"].ToString() == "R10" || _row["Cat"].ToString() == "R11")
                    {

                        if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                        {
                            _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                            count4 += 1;
                        }

                    }
                    if (_row["Cat"].ToString() == "R03" || _row["Cat"].ToString() == "R05")
                    {
                        if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                        {
                            _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                            count5 += 1;
                        }

                    }


                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 32;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();


                    if (row[0].ToString() == "Cable Test")
                    {
                        _drow[1] = count.ToString();
                        _drow[2] = decimal.Round(_p1).ToString();
                        if (count > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count) * 100);
                    }
                    else if (row[0].ToString() == "Repeater Functional Test")
                    {
                        _drow[1] = count2.ToString();
                        _drow[2] = decimal.Round(_p2).ToString();
                        if (count2 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count2) * 100);
                    }
                    else if (row[0].ToString() == "Antenna Functional Test")
                    {
                        _drow[1] = count3.ToString();
                        _drow[2] = decimal.Round(_p3).ToString();
                        if (count3 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count3) * 100);
                    }
                    else if (row[0].ToString() == "Splitter Functional Test")
                    {
                        _drow[1] = count4.ToString();
                        _drow[2] = decimal.Round(_p4).ToString();
                        if (count4 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count4) * 100);
                    }
                    else if (row[0].ToString() == "Coupler / Combiner Functional Test")
                    {
                        _drow[1] = count5.ToString();
                        _drow[2] = decimal.Round(_p5).ToString();
                        if (count5 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count5) * 100);
                    }
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary20_2()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _total = 0;
                decimal _points = 0;
                decimal _tested1 = 0;
                decimal _tested2 = 0;
                decimal _tested3 = 0;


                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;

                int count = 0;
                decimal _qty = 0;
                decimal _qty1 = 0;
                decimal _qty2 = 0;
                decimal _qty3 = 0;
                decimal _qty4 = 0;
                decimal _qty5 = 0;
                decimal _qty6 = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (_row["test1"].ToString() != "N/A")
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _qty1 += Convert.ToDecimal(_row["devices3"].ToString());
                    }
                    if (_row["test2"].ToString() != "N/A")
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _qty2 += Convert.ToDecimal(_row["devices3"].ToString());
                    }
                    if (_row["test3"].ToString() != "N/A")
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _qty3 += Convert.ToDecimal(_row["devices2"].ToString());
                    }
                    if (_row["test4"].ToString() != "N/A")
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        if (IsNumeric(_row["des"].ToString()) == true)
                            _qty4 += Convert.ToDecimal(_row["des"].ToString());
                    }
                    if (_row["test5"].ToString() != "N/A")
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _qty5 += Convert.ToDecimal(_row["devices3"].ToString());
                    }
                    if (_row["test6"].ToString() != "N/A")
                    {
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _qty6 += Convert.ToDecimal(_row["devices1"].ToString());
                    }
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);

                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Cable Continuity/IR Test")
                    {
                        _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_qty1);
                        if (_qty1 > 0)
                            _total = (_p1 / _qty1) * 100;
                        _weighting = _total * 0.2m;
                    }
                    else if (row[0].ToString() == "Points to Points Test")
                    {
                        _drow[2] = Decimal.Round(_p2).ToString();
                        _drow[1] = Decimal.Round(_qty2);
                        if (_qty2 > 0)
                            _total = (_p2 / _qty2) * 100;
                        _weighting = _total * 0.33m;
                    }

                    else if (row[0].ToString() == "Calibration/Functional Test")
                    {
                        _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_qty3);
                        if (_qty3 > 0)
                            _total = (_p3 / _qty3) * 100;
                        _weighting = _total * 0.33m;
                    }
                    else if (row[0].ToString() == "Sequence of Operation")
                    {
                        _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_qty4);
                        if (_qty4 > 0)
                            _total = (_p4 / _qty4) * 100;
                        _weighting = _total * 0.1m;
                    }
                    else if (row[0].ToString() == "Graphic/Head End Test")
                    {
                        _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_qty5);
                        if (_qty5 > 0)
                            _total = (_p5 / _qty5) * 100;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Loop Tuning")
                    {
                        _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_qty6);
                        if (_qty6 > 0)
                            _total = (_p6 / _qty6) * 100;
                        _weighting = _total * 0.02m;
                    }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    //if (_drow[2].ToString() != "0")
                    //    _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = decimal.Round(_weighting).ToString();
                    _drow[4] = "0";
                    _drow[5] = decimal.Round(_weighting).ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
       
        //private void Summary32()
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        decimal _total = 0;
        //        decimal _points = 0;
        //        decimal _tested1 = 0;
        //        decimal _tested2 = 0;
        //        decimal _tested3 = 0;

        //        var distinctRows = (from DataRow dRow in _dtMaster.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            decimal _p1 = 0;
        //            decimal _p2 = 0;
        //            decimal _p3 = 0;
        //            decimal _p4 = 0;
        //            decimal _p5 = 0;
        //            decimal _p6 = 0;
        //            decimal _p7 = 0;

        //            int count = 0;
        //            decimal _qty = 0;
        //            var _result = from _data in _dtMaster.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
        //                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
        //                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
        //                _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
        //                _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
        //                count += Convert.ToInt32(_row["devices3"].ToString());
        //                _qty += 1;
        //            }
        //            decimal _per1 = 0;
        //            decimal _per2 = 0;
        //            if (_p1 != 0)
        //            {
        //                _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
        //            }
        //            if (_p2 != 0)
        //            {
        //                _per2 = Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
        //            }
        //            _tested1 += _p1;
        //            _tested2 += _p2;
        //            _tested3 += _p3;
        //            _points += count;
        //            _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = _qty.ToString();
        //            _drow[2] = "0";
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _total.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        private void Summary32()   
        {
            try
            {
                 _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _total = 0;
                decimal _points = 0;

                decimal _tested1 = 0;
                decimal _tested2 = 0;
                decimal _tested3 = 0;




                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;

                    int count = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p4 += 1;
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                            _p5 += 1;
                        //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        count += Convert.ToInt32(_row["devices3"].ToString());
                        _qty += 1;


                        if (IsNumeric(_row["test1"].ToString()) && IsNumeric(_row["test2"].ToString()))
                        {
                            _tested1 += ((Convert.ToDecimal(_row["test1"].ToString()) + Convert.ToDecimal(_row["test2"].ToString())) / 2);

                        }



                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    if (_p1 > 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
                    }
                    else
                        _per1 = -1;

                    if (_p2 >= 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
                    }
                    else
                        _per2 = -1;


                    if (_per1 != -1 && _per2 != -1)
                    {
                        _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 != -1 && _per2 == -1)
                    {
                        _total = Decimal.Round(_per1, MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 == -1 && _per2 != -1)
                    {
                        _total = Decimal.Round(_per2, MidpointRounding.AwayFromZero);

                    }


                    _points += count;


                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p4).ToString();
                    _drow[3] = decimal.Round(_p5).ToString();
                    _drow[4] = decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }

                if (_points != 0)

                    if (_tested1 > 0 && _tested2 > 0)
                    {
                        _total = Decimal.Round((((_tested1 * 0.2m) + (_tested2 * 0.8m) / _points) * 100), MidpointRounding.AwayFromZero);
                    }
                    else if (_tested1 > 0 && _tested2 <= 0)
                    {
                        _total = Decimal.Round(((_tested1 / _points) * 100), MidpointRounding.AwayFromZero);
                    }
                    else if (_tested1 <= 0 && _tested2 > 0)
                    {
                        _total = Decimal.Round(((_tested2 / _points) * 100), MidpointRounding.AwayFromZero);
                    }


                DataRow _drow1 = _dtsummary.NewRow();
                if (lblsch.Text == "20")
                    _drow1[0] = "BMS Points";
                else
                    _drow1[0] = "Points";
                _drow1[1] = decimal.Round(_points).ToString();
                _drow1[2] = decimal.Round(_tested1).ToString();
                _drow1[3] = decimal.Round(_tested2).ToString();
                _drow1[4] = decimal.Round(_tested3).ToString();
                _drow1[5] = _total.ToString();
                _drow1[6] = "Points";
                _dtsummary.Rows.Add(_drow1);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }



        private void Summary13()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); }
                    else if (row[0].ToString() == "CCTV View Locally") { _drow[2] = Decimal.Round(_p2).ToString(); }
                    else if (row[0].ToString() == "CCTV View From Head End") { _drow[2] = Decimal.Round(_p3).ToString(); }
                    else if (row[0].ToString() == "CCTV Addressing/Software Test") { _drow[2] = Decimal.Round(_p4).ToString(); }
                    else if (row[0].ToString() == "CCTV Recording/Back-up Restore Test") { _drow[2] = Decimal.Round(_p5).ToString(); }
                    //else if (row[0].ToString() == "Pc Head End Test") _drow[2] = decimal.Round(_p7).ToString();
                    if (_drow[2].ToString() != "0")
                        _total = (Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100;
                        //_total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                        if (_total >= 99.5m && _total < 100m) _total = 99;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = decimal.Round(_total).ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary13_oph()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _devices1 = 0;
                decimal _devices2 = 0;
                decimal _devices3 = 0;
                decimal _devices4 = 0;
                decimal _devices5 = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _devices1 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com2"].ToString()) >= 0)
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _devices2 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com3"].ToString()) >= 0)
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _devices3 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com4"].ToString()) >= 0)
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _devices4 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com5"].ToString()) >= 0)
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _devices5 += Convert.ToInt32(_row["devices1"].ToString());
                    }
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _devices1.ToString(); }
                    else if (row[0].ToString() == "CCTV View Locally") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = _devices2.ToString(); }
                    else if (row[0].ToString() == "CCTV View From Head End") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = _devices3.ToString(); }
                    else if (row[0].ToString() == "CCTV Addressing/Software Test") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = _devices4.ToString(); }
                    else if (row[0].ToString() == "CCTV Recording/Back-up Restore Test") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = _devices5.ToString(); }
                    if (_drow[1].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary13_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _points1 = 0;
                decimal _points2 = 0;
                decimal _points3 = 0;
                decimal _points4 = 0;
                decimal _points5 = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test1"].ToString() != "N/A") _points1 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test2"].ToString() != "N/A") _points2 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test3"].ToString() != "N/A") _points3 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test4"].ToString() != "N/A") _points4 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test5"].ToString() != "N/A") _points5 += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 13;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity / IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _points1.ToString(); }
                    else if (row[0].ToString() == "VSS View Locally") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = _points2.ToString(); }
                    else if (row[0].ToString() == "VSS View from Head End PC") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = _points3.ToString(); }
                    else if (row[0].ToString() == "VSS Addressing / Software Test") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = _points4.ToString(); }
                    else if (row[0].ToString() == "VSS Recording / Back-up Storage Test") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = _points5.ToString(); }
                    if (_drow[1].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary30_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _devices = 0;
                decimal _devices1 = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    if (_row["test1"].ToString() != "N/A") _devices += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test2"].ToString() != "N/A") _devices1 += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_14211";
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 30;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();

                    if (row[0].ToString() == "Cable Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _devices.ToString(); }
                    else if (row[0].ToString() == "Functional Test") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = _devices1.ToString(); }
                    if (_drow[1].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary22()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _devices1 = 0;
                decimal _devices2 = 0;
                decimal _devices3 = 0;
                decimal _devices4 = 0;
                decimal _devices5 = 0;
                decimal _devices6 = 0;
                decimal _devices7 = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1) _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1) _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1) _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1) _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1) _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1) _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1) _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    if (_row["test1"].ToString() != "N/A") _devices1 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test2"].ToString() != "N/A") _devices2 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test3"].ToString() != "N/A") _devices3 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test4"].ToString() != "N/A") _devices4 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test5"].ToString() != "N/A") _devices5 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test6"].ToString() != "N/A") _devices6 += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test7"].ToString() != "N/A") _devices7 += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _devices1.ToString(); }
                    else if (row[0].ToString() == "Addressing/Programming Test") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = _devices2.ToString(); }
                    else if (row[0].ToString() == "Fault & Alarm Test") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = _devices3.ToString(); }
                    else if (row[0].ToString() == "Access Card Swipe") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = _devices4.ToString(); }
                    else if (row[0].ToString() == "Power Failure Test") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = _devices5.ToString(); }
                    else if (row[0].ToString() == "Interface Test") { _drow[2] = decimal.Round(_p6).ToString(); _drow[1] = _devices6.ToString(); }
                    else if (row[0].ToString() == "PC Headend/Graphics Test") { _drow[2] = decimal.Round(_p7).ToString(); _drow[1] = _devices7.ToString(); }
                    if (_drow[1].ToString() != "0")
                    {
                        _total = (Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100;
                        if (_total >= 99.5m && _total < 100m) _total = 99;
                    }
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = decimal.Round(_total).ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary11()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _circuits1 = 0;
                decimal _circuits2 = 0;
                decimal _circuits3 = 0;
                decimal _scenes = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    if (_row["test1"].ToString() != "N/A") _circuits1 += Convert.ToInt32(_row["devices2"].ToString());
                    if (_row["test2"].ToString() != "N/A") _circuits2 += Convert.ToInt32(_row["devices2"].ToString());
                    if (_row["test3"].ToString() != "N/A") _scenes += Convert.ToInt32(_row["devices1"].ToString());
                    if (_row["test4"].ToString() != "N/A") _circuits3 += Convert.ToInt32(_row["devices2"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();

                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _circuits1.ToString(); }
                    else if (row[0].ToString() == "No.Of Lighting Circuits Tested") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = _circuits2.ToString(); }
                    else if (row[0].ToString() == "Addressing/Programming Test") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = _scenes.ToString(); }
                    else if (row[0].ToString() == "PC Headend/Interface Test") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = _circuits3.ToString(); }
                    if (_drow[1].ToString() != "0")
                    {
                        _total = (Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100;
                        if (_total >= 99.5m && _total < 100m) _total = 99;
                    }
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = decimal.Round(_total).ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary11_oph()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _circuits1 = 0;
                decimal _circuits2 = 0;
                decimal _circuits3 = 0;
                decimal _scenes = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _circuits1 += Convert.ToInt32(_row["devices2"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com2"].ToString()) >= 0)
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _circuits2 += Convert.ToInt32(_row["devices2"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com3"].ToString()) >= 0)
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _scenes += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com4"].ToString()) >= 0)
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _circuits3 += Convert.ToInt32(_row["devices2"].ToString());
                    }
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();

                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _circuits1.ToString(); }
                    else if (row[0].ToString() == "No.Of Lighting Circuits Tested") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = _circuits2.ToString(); }
                    else if (row[0].ToString() == "Addressing/Programming Test") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = _scenes.ToString(); }
                    else if (row[0].ToString() == "PC Headend/Interface Test") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = _circuits3.ToString(); }
                    if (_drow[1].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary12_oph()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _points = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (Convert.ToDecimal(_row["per_com1"].ToString()) >= 0)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _points += Convert.ToInt32(_row["devices1"].ToString());
                    }
                   
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();

                    if (row[0].ToString() == "Cable Tests") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = _points.ToString(); }
                   
                    if (_drow[1].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary11_1()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));


                decimal _total = 0;
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    int count = 0;
                    decimal _circuit = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                        _circuit += Convert.ToInt32(_row["devices2"].ToString());
                        //_interface += Convert.ToInt32(_row["devices1"].ToString());
                        //if (IsNumeric(_row["test2"].ToString()) == true)
                        //    _device_tested += Convert.ToDecimal(_row["test2"].ToString());
                        //if (IsNumeric(_row["test4"].ToString()) == true)
                        //    _interface_tested += Convert.ToDecimal(_row["test4"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = (_p4 + _p2 + _p3) / 3;
                    if (_circuit > 0)
                    {
                        _per1 = _p1 / _circuit;
                    }
                    if (count > 0)
                    {
                        _per2 = _per3 / Convert.ToDecimal(count);
                    }
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _qty.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary12()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    if (row.col3.ToString() == "CU" || row.col3.ToString() == "FO")
                    {
                        decimal _p1 = 0;
                        decimal _total = 0;
                        decimal _points = 0;
                        string _test = "";
                        var _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                      select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _points += Convert.ToDecimal(_row["devices1"].ToString());
                        }

                        if (row.col3.ToString() == "CU") _test = "CAT 6 Cable Tests";
                        else if (row.col3.ToString() == "FO") _test = "Fibre Optic Cable Tests";
                        if (_p1 != 0)
                            _total = Decimal.Round((_p1 / _points) * 100);
                        DataRow _drow = _dtsummary.NewRow();
                        _drow[0] = _test;
                        _drow[1] = _points.ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        _drow[3] = "0";
                        _drow[4] = "0";
                        _drow[5] = _total.ToString();
                        _drow[6] = _test;
                        _dtsummary.Rows.Add(_drow);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary12_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 12;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;

                foreach (var row in TestNames)
                {
                    decimal _p1 = 0;
                    decimal _devices = 0;
                    decimal _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "CAT 3/ CAT 6A Cable Tests")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "CU6" || _data.Field<string>("Cat") == "AC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (_row["test1"].ToString() != "N/A") _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                    }
                    else if (row[0].ToString() == "COP50 Cable Tests")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "COP50"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (_row["test1"].ToString() != "N/A") _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                    }
                    else if (row[0].ToString() == "OF Cable Tests")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FO"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (_row["test1"].ToString() != "N/A") _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                    }
                    else if (row[0].ToString() == "OFA Cable Tests")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "OFA"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (_row["test1"].ToString() != "N/A") _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                    }
                    else if (row[0].ToString() == "OFB Cable Tests")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "OFB"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (_row["test1"].ToString() != "N/A") _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                    }

                    else if (row[0].ToString() == "WII/ WOI/ WOD Functional Tests")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "WII" || _data.Field<string>("Cat") == "WOI" || _data.Field<string>("Cat") == "WOD"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (_row["test1"].ToString() != "N/A") _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;

                    }

                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        private void Summary12_OPH()    
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();

                    decimal _p1 = 0;
                    decimal _total = 0;
                    decimal _points = 0;
                    string _test = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _points += Convert.ToDecimal(_row["devices1"].ToString());
                    }

                    if (_points != 0)
                        _total = Decimal.Round((_p1 / _points) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _points.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    //_drow[3] = _total.ToString();

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col2.ToString();

                    _dtsummary.Rows.Add(_drow);



                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        private void Summary29_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;

                decimal _p3 = 0;



                decimal _total = 0;
                int count = 0;
                int count1 = 0;
                int count2 = 0;



                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }


                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        count1 += Convert.ToInt32(_row["devices1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    }

                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                    {
                        count2 += Convert.ToInt32(_row["devices1"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    }


                }

                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 29;

                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();


                    if (row[0].ToString() == "Cable Continuity Test")
                    {
                        _drow[1] = count.ToString();
                        _drow[2] = decimal.Round(_p1).ToString();

                        if (count > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count) * 100);



                    }
                    else if (row[0].ToString() == "Audio Functional Test")
                    {
                        _drow[1] = count1.ToString();
                        _drow[2] = decimal.Round(_p2).ToString();
                        if (count1 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count1) * 100);


                    }
                    else if (row[0].ToString() == "Video Functional Test")
                    {
                        _drow[1] = count1.ToString();
                        _drow[2] = decimal.Round(_p3).ToString();
                        if (count1 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count2) * 100);


                    }

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }

        }
        private void Summary12_moe()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _qty = 0;
                decimal _tested = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _points = 0;
                    string _test = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _points += Convert.ToDecimal(_row["devices1"].ToString());
                    }
                    _qty += _points;
                    _tested += _p1;
                }
                decimal _total = 0;
                if (_qty > 0)
                    _total = Decimal.Round((_tested / _qty) * 100, 0, MidpointRounding.AwayFromZero);
                DataRow _drow = _dtsummary.NewRow();
                _drow[0] = "Cable Tests";
                _drow[1] = _qty.ToString();
                _drow[2] = Decimal.Round(_tested).ToString();
                _drow[3] = "0";
                _drow[4] = "0";
                _drow[5] = _total.ToString();
                _drow[6] = "Cable Tests";
                _dtsummary.Rows.Add(_drow);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary12_2()
        {
            try
            {
                decimal _total = 0;
                decimal _idf = 0;
                decimal _mdf = 0;
                decimal _idft = 0;
                decimal _mdft = 0;
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtMaster.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _qty = 0;
                    decimal _points = 0;
                    string _test = "";
                    var _result = from _data in _dtMaster.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        //_p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        if (IsNumeric(_row["test1"].ToString()) == true)
                            _p1 += Convert.ToDecimal(_row["test1"].ToString());
                        //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _points += Convert.ToDecimal(_row["devices1"].ToString());
                        _qty += 1;
                    }

                    if (_points != 0)
                        _total = Decimal.Round((_p1 / _points)*100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _points.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                //if (_idf != 0)
                //    _total = Decimal.Round((_idft / _idf) * 100);
                //DataRow _drow1 = _dtsummary.NewRow();
                //_drow1[0] = "Outlets";
                //_drow1[1] = Decimal.Round(_idf).ToString();
                //_drow1[2] = Decimal.Round(_idft).ToString();
                //_drow1[3] = "0";
                //_drow1[4] = "0";
                //_drow1[5] = _total.ToString();
                //_drow1[6] = "1";
                //_dtsummary.Rows.Add(_drow1);
                //if (_mdf != 0)
                //    _total = Decimal.Round((_mdft / _mdf) * 100);
                //DataRow _drow2 = _dtsummary.NewRow();
                //_drow2[0] = "Fibre Pairs";
                //_drow2[1] = Decimal.Round(_mdf).ToString();
                //_drow2[2] = Decimal.Round(_mdft).ToString();
                //_drow2[3] = "0";
                //_drow2[4] = "0";
                //_drow2[5] = _total.ToString();
                //_drow2[6] = "1";
                //_dtsummary.Rows.Add(_drow2);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

      
        private void Summary15()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _p8 = 0;
                decimal _p9 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    _p8 += Convert.ToDecimal(_row["per_com8"].ToString());
                    _p9 += Convert.ToDecimal(_row["per_com9"].ToString());
                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); }
                    else if (row[0].ToString() == "Key Card Activated") { _drow[2] = Decimal.Round(_p2).ToString(); }
                    else if (row[0].ToString() == "Do Not Disturb(DND)/Doorbell") { _drow[2] = Decimal.Round(_p3).ToString(); }
                    else if (row[0].ToString() == "Make Up Room(MUR)") { _drow[2] = Decimal.Round(_p4).ToString(); }
                    else if (row[0].ToString() == "FCU/Temp Control") { _drow[2] = Decimal.Round(_p5).ToString(); }
                    else if (row[0].ToString() == "Energy Management System") _drow[2] = decimal.Round(_p6).ToString();
                    else if (row[0].ToString() == "Lighting Scene Control") { _drow[2] = Decimal.Round(_p7).ToString(); }
                    else if (row[0].ToString() == "Blinds Control Interface") { _drow[2] = Decimal.Round(_p8).ToString(); }
                    else if (row[0].ToString() == "Monitoring Interface(Future)") _drow[2] = decimal.Round(_p9).ToString();
                    if(_drow[2].ToString()!="0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary15_oph()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _p8 = 0;
                decimal _p9 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                //foreach (var _row in _result)
                //{
                //    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                //    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                //    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                //    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                //    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                //    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                //    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                //    _p8 += Convert.ToDecimal(_row["per_com8"].ToString());
                //    _p9 += Convert.ToDecimal(_row["per_com9"].ToString());
                //    _devices += Convert.ToInt32(_row["devices1"].ToString());
                //}
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    //_drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/ IR Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {

                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Test Hole Test")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Test Hole Test Complete")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "FA Interface Test")
                    {
                        foreach (var _row in _result)
                        {

                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "FA Interface Test Complete")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Cause & Effect Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[2].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;

                    _drow[3] = "0";
                    _drow[4] = "0";

                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary14()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    //if (_row["cat"].ToString() == "AVP")
                    //{
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _devices += Convert.ToInt32(_row["devices1"].ToString());
                    //}
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _drow[1] = _devices.ToString();
                    if (row[0].ToString() == "Continuity/IR Test") { _drow[2] = Decimal.Round(_p1).ToString(); }
                    else if (row[0].ToString() == "Door Intercom Alert/Bell") { _drow[2] = Decimal.Round(_p2).ToString(); }
                    else if (row[0].ToString() == "Audio/Visual Test") { _drow[2] = Decimal.Round(_p3).ToString(); }
                    else if (row[0].ToString() == "Door Release Test") { _drow[2] = Decimal.Round(_p4).ToString(); }
                    if (_drow[2].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        //private void Summary23() 
        //{
        //    try
        //    {
        //        _dtsummary = new DataTable();
        //        _dtsummary.Columns.Add("SYS_NAME", typeof(string));
        //        _dtsummary.Columns.Add("QTY", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
        //        _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
        //        _dtsummary.Columns.Add("TOTAL", typeof(string));
        //        _dtsummary.Columns.Add("CODE", typeof(string));
        //        var distinctRows = (from DataRow dRow in _dtresult.Rows
        //                            select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
        //        foreach (var row in distinctRows)
        //        {
        //            //_row[0] = row.col1.ToString();
        //            //_row[1] = row.col2.ToString();
        //            decimal _p1 = 0;
        //            //decimal _p2 = 0;
        //            //decimal _p3 = 0;
        //            decimal _total = 0;
        //            int count = 0;
        //            //int count1 = 0;
        //            string _s = "";
        //            var _result = from _data in _dtresult.AsEnumerable()
        //                          where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
        //                          select _data;
        //            //int _count2 = 0;
        //            foreach (var _row in _result)
        //            {
        //                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
        //                _s = _row[0].ToString();
        //                count += 1;
        //            }
        //              decimal _per1 = 0;
        //            if (count != 0)
        //                _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
        //            _total = Decimal.Round((_per1) * 100);

        //            DataRow _drow = _dtsummary.NewRow();
        //            _drow[0] = row.col2.ToString();
        //            _drow[1] = count.ToString();
        //            _drow[2] = Decimal.Round(_p1).ToString();
        //            _drow[3] = "0";
        //            _drow[4] = "0";
        //            _drow[5] = _total.ToString();
        //            _drow[6] = row.col3.ToString();
        //            _dtsummary.Rows.Add(_drow);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
        //    }
        //}
        private void Summary23()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                decimal _count1 = 0;
                decimal _count2 = 0;
                decimal _LiftCount = 0;
                decimal _EscCount = 0;
                decimal _travelCount = 0;
                decimal _BMUCount = 0;
                decimal _LiftTested = 0;
                decimal _EscTested = 0;
                decimal _travelTested = 0;
                decimal _BMUTested = 0; 

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com8"].ToString());
                    _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    if (_row["Cat"].ToString() == "LIFT")
                        _count2 += 1;
                    _count1 += 1;

                    if (_row["Cat"].ToString() == "LIFT")
                    {
                        _LiftCount += 1;
                        if (_row["per_com1"].ToString() == "100" || _row["per_com1"].ToString() == "100.00")
                            _LiftTested += 1;
                    }
                    else if (_row["Cat"].ToString() == "TRV")
                    {
                        _travelCount += 1;
                        if (_row["per_com1"].ToString() == "100" || _row["per_com1"].ToString() == "100.00")
                            _travelTested += 1;
                    }
                    else if (_row["Cat"].ToString() == "ESC")
                    {
                        _EscCount += 1;
                        if (_row["per_com1"].ToString() == "100" || _row["per_com1"].ToString() == "100.00")
                            _EscTested += 1;
                    }
                    else if (_row["Cat"].ToString() == "BMU")
                    {
                        _BMUCount += 1;
                        if (_row["per_com1"].ToString() == "100" || _row["per_com1"].ToString() == "100.00")
                            _BMUTested += 1;
                    }
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Tested & Comm.") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "3rd Party Inspected") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Emergency Lighting") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "Power Failure Mode") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Lift Monitoring System") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "Intercom") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_count2); }
                    else if (row[0].ToString() == "BMS/ Fire Alarm Interface") { _drow[2] = Decimal.Round(_p7).ToString(); _drow[1] = Decimal.Round(_count1); }
                    else if (row[0].ToString() == "Lifts / Elevators") { _drow[2] = Decimal.Round(_LiftTested).ToString(); _drow[1] = Decimal.Round(_LiftCount); }
                    else if (row[0].ToString() == "Escalators") { _drow[2] = Decimal.Round(_EscTested).ToString(); _drow[1] = Decimal.Round(_EscCount); }
                    else if (row[0].ToString() == "Travelators") { _drow[2] = Decimal.Round(_travelTested).ToString(); _drow[1] = Decimal.Round(_travelCount); }
                    else if (row[0].ToString() == "BMUs") { _drow[2] = Decimal.Round(_BMUTested).ToString(); _drow[1] = Decimal.Round(_BMUCount); }
                    if (_drow[2].ToString() != "0" && _drow[1].ToString() != string.Empty && _drow[2].ToString() != string.Empty)
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary23_1()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                int count = 0;

                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;
                decimal _total = 0;
                decimal _qty = 0;
                int _qty1 = 0;
                int _qty2 = 0;
                int _qty3 = 0;
                int _qty4 = 0;
                int _qty5 = 0;
                int _qty6 = 0;
                int _qty7 = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com8"].ToString());
                    
                    _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                   
                    _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                    _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                    _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                    if (_row["test1"].ToString().ToUpper() != "N/A") _qty1 += 1;
                    if (_row["Cat"].ToString() == "LIFT" || _row["Cat"].ToString() == "ESC")
                    {
                        if (_row["test3"].ToString().ToUpper() != "N/A") _qty3 += 1;
                        if (_row["test5"].ToString().ToUpper() != "N/A") _qty5 += 1;
                        if (_row["test6"].ToString().ToUpper() != "N/A") _qty6 += 1;
                        if (_row["test7"].ToString().ToUpper() != "N/A") _qty7 += 1;
                    }
                    else if (_row["Cat"].ToString() == "BMU")
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        if (_row["test2"].ToString().ToUpper() != "N/A") _qty2 += 1;
                        if (_row["test4"].ToString().ToUpper() != "N/A") _qty4 += 1;
                    }
                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    if (row[0].ToString() == "Tested & Comm.") { _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_qty1); }
                    else if (row[0].ToString() == "3rd Party Inspected") { _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_qty2); }
                    else if (row[0].ToString() == "Emergency Lighting") { _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_qty3); }
                    else if (row[0].ToString() == "Power Failure Mode") { _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_qty4); }
                    else if (row[0].ToString() == "Lift Monitoring System") { _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_qty5); }
                    else if (row[0].ToString() == "Intercom") { _drow[2] = Decimal.Round(_p6).ToString(); _drow[1] = Decimal.Round(_qty6); }
                    else if (row[0].ToString() == "BMS/ Fire Alarm Interface") { _drow[2] = Decimal.Round(_p7).ToString(); _drow[1] = Decimal.Round(_qty7); }
                    if (_drow[1].ToString() != "0")
                        _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / (Convert.ToDecimal(_drow[1].ToString()))) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary23_2() 
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    if (_p2 != 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count));

                    _total = Decimal.Round((_per1 * 0.1m) + (_per2 * 0.45m) + (_per3 * 0.45m));
                    DataRow _drow = _dtsummary.NewRow();

                    _drow["SYS_NAME"] = row.col2.ToString();
                    _drow["QTY"] = count.ToString();
                    _drow["PER_COMPLETED"] = _per1.ToString();
                    _drow["PER_COMPLETED1"] = _per2.ToString();
                    _drow["PER_COMPLETED2"] = _per3.ToString();
                    _drow["TOTAL"] = _total.ToString();
                    _drow["CODE"] = row.col3.ToString();

                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary23_12761()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                int count = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        if (_row["per_com1"].ToString() == "100")
                            _p2 += 1;
                        //_p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        //_p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        //_p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        //_p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        //_p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        //_p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        //count += Convert.ToInt32(_row["devices1"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    // _per1 = (_p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7) / 7;
                    _per1 = _p2;
                    if (_qty != 0)
                        _total = decimal.Round((_per1 / _qty) * 100);
                    DataRow _drow = _dtsummary.NewRow();

                    _drow["SYS_NAME"] = row.col2.ToString();
                    _drow["QTY"] = count.ToString();
                    _drow["PER_COMPLETED"] = _per1.ToString();
                    _drow["PER_COMPLETED1"] = "0";
                    _drow["PER_COMPLETED2"] = "0";
                    _drow["TOTAL"] = _total.ToString();
                    _drow["CODE"] = row.col3.ToString();

                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary21()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += 1;
                    }
                    if(_p1!=0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary9()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count += 1;
                    }
                    //decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    //decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    if (_p1 != 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary17()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary18()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count += Convert.ToInt32(_row["devices1"].ToString());
                        }
                    }
                    if (_p1 != 0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary19()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _s = _row[0].ToString();
                            count += 1;
                        }
                    }
                    if (_p1 != 0)
                        _total = _p1 / Convert.ToDecimal(count);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary10()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    if (lblprj.Text != "12710")
                    {
                        if (row[0].ToString() == "Circuit IR Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                    if(IsNumeric(_row["devices2"].ToString())==true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            foreach (var _row in _result)
                            {
                                
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();


                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "PAVA")
                                {

                                    _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                                //else if (_row["cat"].ToString() == "FTU")
                                //{
                                //    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                //}
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                            
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                //if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                    if (IsNumeric(_row["devices1"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices1"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "FTP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {
                            _count = 0;

                            //if (lblprj.Text == "BCC1")
                            //{
                            //    _result = from _data in _dtresult.AsEnumerable()
                            //              where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP"
                            //              select _data;
                            //}


                            foreach (var _row in _result)
                            {
                                //if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                //if (_row["cat"].ToString() == "FACP")
                                //{
                                //    _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                //    if (IsNumeric(_row["devices2"].ToString()) == true)
                                //        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                //    //_count += 1;
                                //}
                                if (lblprj.Text == "BCC1")
                                {
                                    if (_row["cat"].ToString() == "FACP" | _row["cat"].ToString() == "FARP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                    _count += 1;
                                }

                                }
                                else
                                {
                                   
                                    if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                    //if (_row["cat"].ToString() == "FACP" | _row["cat"].ToString() == "FARP")
                                    {
                                        _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                        if (IsNumeric(_row["devices2"].ToString()) == true)
                                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                                        //_count += 1;
                                    }

                                }


                            }
                            if (lblprj.Text == "BCC1")
                                _drow[1] = Decimal.Round(_count).ToString();
                            else 
                                _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {
                            _count = 0;

                            foreach (var _row in _result)
                            {
                                if (lblprj.Text == "BCC1")
                                {
                                    if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA")
                                    {
                                        _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                        if (IsNumeric(_row["devices2"].ToString()) == true)
                                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                                        _count += 1;
                                    }
                                }
                                else
                                {
                                    //if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP")
                                    
                                    if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                    {
                                        _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                        if (IsNumeric(_row["devices2"].ToString()) == true)
                                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                                    }
                                }
                            }
                            if (lblprj.Text == "BCC1")
                                _drow[1] = Decimal.Round(_count).ToString();
                            else
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                if (lblprj.Text == "BCC1")
                                {
                                    if (_row["cat"].ToString() == "CE")
                                    {
                                        _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                        if (IsNumeric(_row["devices2"].ToString()) == true)
                                            _devices += Convert.ToInt32(_row["devices2"].ToString());
                                        _count += 1;
                                    }
                                }
                                else
                                {
                                    if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA")
                                        {
                                            _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                                        }
                                }
                            }
                            if (lblprj.Text == "BCC1")
                                _drow[1] = Decimal.Round(_count).ToString();
                            else
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else
                        {
                            _drow[1] = "0";
                            _drow[2] = "0";
                        }
                    }
                    else
                    {
                        if (row[0].ToString() == "Circuit IR Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Device/Address Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();


                        }
                        else if (row[0].ToString() == "Sound Level Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {

                                    _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                                //else if (_row["cat"].ToString() == "FTU")
                                //{
                                //    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                //}
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                        }
                        else if (row[0].ToString() == "Interface Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                    if (IsNumeric(_row["devices1"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices1"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Fire Telephone Test")
                        {
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "FTP")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Battery Autonomy Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                 //where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                //if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                    //_count += 1;
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Graphic Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTP" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else if (row[0].ToString() == "Cause Effect Test")
                        {
                            _count = 0;
                            foreach (var _row in _result)
                            {
                                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "FARP" || _row["cat"].ToString() == "FSCP" || _row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "FTU" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "LHD" || _row["cat"].ToString() == "BDC" || _row["cat"].ToString() == "VESDA" || _row["cat"].ToString() == "CAES" || _row["cat"].ToString() == "AS")
                                {
                                    _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                    if (IsNumeric(_row["devices2"].ToString()) == true)
                                        _devices += Convert.ToInt32(_row["devices2"].ToString());
                                }
                            }
                            _drow[1] = Decimal.Round(_devices).ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();

                        }
                        else
                        {
                            _drow[1] = "0";
                            _drow[2] = "0";
                        }
                    }
                    if (_drow[2].ToString() != "0")
                    {

                        _total = (Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString())) * 100;
                        if (_total >= 99.5m && _total < 100m) _total = 99;
                    }
                    else
                        _total = 0;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] =  Decimal.Round(_total).ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }


        private void Summary10_oph()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    if (row[0].ToString() == "Continuity/ IR Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS" || _data.Field<string>("Cat") == "MFAP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                //if (IsNumeric(_row["devices2"].ToString()) == true)
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Device/Address Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS" || _data.Field<string>("Cat") == "MFAP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                //if (IsNumeric(_row["devices2"].ToString()) == true)
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                //if (IsNumeric(_row["devices2"].ToString()) == true)
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "CAES" || _data.Field<string>("Cat") == "AS" || _data.Field<string>("Cat") == "MFAP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                //if (IsNumeric(_row["devices1"].ToString()) == true)
                                //    _devices += Convert.ToInt32(_row["devices1"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    //else if (row[0].ToString() == "Fire Telephone Test")
                    //{
                    //    _result = from _data in _dtresult.AsEnumerable()
                    //              where _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "FTP"
                    //              select _data;
                    //    foreach (var _row in _result)
                    //    {
                    //        if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                    //        {
                    //            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                    //            //if (IsNumeric(_row["devices2"].ToString()) == true)
                    //            //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                    //            _devices += 1;
                    //        }
                    //    }
                    //    _drow[1] = Decimal.Round(_devices).ToString();
                    //    _drow[2] = Decimal.Round(_p1).ToString();

                    //}
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;

                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                //if (IsNumeric(_row["devices2"].ToString()) == true)
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                ////_count += 1;
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;

                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                //if (IsNumeric(_row["devices2"].ToString()) == true)
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;

                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                //if (IsNumeric(_row["devices2"].ToString()) == true)
                                //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        //_drow[1] = "0";
                        //_drow[2] = "0";

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[2].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary15_Oph()   
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 15;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    if (row[0].ToString() == "Continuity/ IR Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {

                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Test Hole Test")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Test Hole Test Complete")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "FA Interface Test")
                    {
                        foreach (var _row in _result)
                        {

                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "FA Interface Test Complete")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Cause & Effect Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }

                    if (_drow[2].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        private void Summary10_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_14211";
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    int idx = 0;
                    decimal _qty = 0;
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Circuit IR Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SLC" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "NAC" || _data.Field<string>("Cat") == "INT" || _data.Field<string>("Cat") == "FT" || _data.Field<string>("Cat") == "ANS" || _data.Field<string>("Cat") == "J"
                                  select _data;
                        decimal _intrface = 0;
                        decimal _panel = 0;

                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _devices += 1;

                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.15m;
                    }
                    else if (row[0].ToString() == "Device / Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SLC" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "NAC" || _data.Field<string>("Cat") == "ANS" || _data.Field<string>("Cat") == "FT" || _data.Field<string>("Cat") == "INT" || _data.Field<string>("Cat") == "J"
                                  select _data;
                        decimal _interface = 0;
                        decimal _p2 = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());

                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            if (_row["Cat"].ToString() == "SLC")
                            {
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _interface += Convert.ToInt32(_row["devices1"].ToString());
                                _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices + _interface).ToString();
                        _drow[2] = Decimal.Round(_p1 + _p2).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.6m;
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "NAC" || _data.Field<string>("Cat") == "VAC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SLC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.13m;
                    }
                    else if (row[0].ToString() == "Fire Telephone Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FT"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.13m;
                    }

                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAS" || _data.Field<string>("Cat") == "ACPS" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.03m;

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAS" || _data.Field<string>("Cat") == "ACPS" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                            _panel += 1;

                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "C&E Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAS"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.05m;

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }

                    _drow[3] = "0";
                    _drow[4] = decimal.Round(_weighting, 0).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    if (Convert.ToDecimal(_drow[1].ToString()) > 0)
                        _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary10_11736()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    int idx = 0;
                    decimal _qty = 0;

                    if (row[0].ToString() == "Circuit IR Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "DRS" || _data.Field<string>("Cat") == "FARP"
                                  select _data;
                        decimal _intrface = 0;
                        decimal _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            if (_row["Cat"].ToString() == "FAL")
                            {
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _intrface += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["Cat"].ToString() == "FARP")
                                _panel += 1;
                        }
                        _devices = _devices + _intrface + _panel;
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Device/Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "VESDA"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "PAVA"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "VESDA"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            _p2 += Convert.ToDecimal(_row["per_com8"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round((_p1 + _p2) / 2).ToString();

                    }
                    else if (row[0].ToString() == "Fire Telephone Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Disabled Refuge")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "DRS"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Fire Alarm Repeater Panel")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FARP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            //if (IsNumeric(_row["devices2"].ToString()) == true)
                            //    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FAVP" || _data.Field<string>("Cat") == "DRS" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "VESDA"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FAVP" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "VESDA"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;

                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FAVP" || _data.Field<string>("Cat") == "VESDA"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        //_drow[1] = "0";
                        //_drow[2] = "0";

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[1].ToString() != "0")
                    {
                        _total = ((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;

                    if (_total >= 99 && _total <= 100)
                        _total = 99;
                    else
                        _total = decimal.Round(_total);


                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Generate_Summary_Graph()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clscassheet _objcls = new _clscassheet();
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objbll.Clear_CassummaryRpt(_objdb);
            var _result = from _data in _dtsummary.AsEnumerable()
                          select _data;
            int count = 0;
            foreach (var row in _result)
            {
                _objcls.sys_mon = row["SYS_NAME"].ToString();
                _objcls.qty = row["QTY"].ToString();
                _objcls.per_com1 = Convert.ToDecimal(row["PER_COMPLETED"].ToString());
                _objcls.per_com2 = Convert.ToDecimal(row["PER_COMPLETED1"].ToString());
                _objcls.per_com3 = Convert.ToDecimal(row["PER_COMPLETED2"].ToString());
                _objcls.total = Convert.ToDecimal(row["TOTAL"].ToString());
                _objcls.cate = row["CODE"].ToString();
                _objcls.quantity = Convert.ToInt32(row["QTY"].ToString());
                _objbll.Generate_CASSummary_PKG_RPT(_objcls, _objdb);

                count += 1;
            }
        }
        protected void drbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["zone"] = drbuilding.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text,drloc.SelectedItem.Text);
        }
        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text,drloc.SelectedItem.Text);
           // Generate_Summary();
        }
        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text,drloc.SelectedItem.Text);
        }
        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text,drloc.SelectedItem.Text);
        }
        protected void btngenerate_Click(object sender, EventArgs e)
        {
            bool isNewProject = (Array.IndexOf(Constants.CMLTConstants.recentProjects, lblprj.Text) > -1) ? true : false;
            if (isNewProject && drtype.SelectedItem.Value == "2")
            {
                Building_Summary(Convert.ToInt32(lblsch1.Text));
            }
            else
                Generate_Summary();

            Generate_Summary_Graph();

            Generate_Reports();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Clicked');", true);
        }
        private string get_project()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsuser _objcls = new _clsuser();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _objcls.project_code = lblprj.Text;
            return _objbll.Get_ProjectName(_objcls, _objdb);
        }
        private string Get_Facility_Name()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_14211";
            _objcls.sch = Convert.ToInt32(lbldiv.Text);
            return _objbll.Get_Facility_Name(_objcls, _objdb);
        }
        void Generate_Graph_Summary_New(string sch_id, string mode)         
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            _objcls.sch = Convert.ToInt32(sch_id);   
            _objcls.b_zone = drbuilding.SelectedItem.Text;
            _objcls.cate = drcategory.SelectedItem.Text;
            _objcls.f_level = drflevel.SelectedItem.Text;
            _objcls.fed_from = drfed.SelectedItem.Text;
            _objcls.loca = drloc.SelectedItem.Text;
            _objcls.build_id = Convert.ToInt32(lbldiv.Text);
            _objcls.mode = Convert.ToInt32(mode);
            _objbll.Generate_CAS_Graph_Summary(_objcls, _objdb);  
        }
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Unload(object sender, EventArgs e)
        {               
                //cryRpt.Dispose();
                //cryRpt.Close();  
        }
        private void Generate_Reports()
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            if (lblprj.Text == "14211")
            {
                cryRpt.Load(Server.MapPath("Graph_KAIA.rpt"));
                string _fac = Get_Facility_Name();
                cryRpt.SetParameterValue("facility", _fac);
            }
            else  if (lblprj.Text == "ARSD")
            {
                cryRpt.Load(Server.MapPath("Graph_pcd.rpt"));
            }
            else
                cryRpt.Load(Server.MapPath("Graph.rpt"));
            //crConnectionInfo.ServerName = "213.171.197.149,49296";
            //crConnectionInfo.DatabaseName = "DBCML";
            //crConnectionInfo.UserID = "CT_user";
            //crConnectionInfo.Password = "CTplus#2016";
            crConnectionInfo.ServerName = Constants.CMLTConstants.serverName;
            crConnectionInfo.DatabaseName = Constants.CMLTConstants.dbName;
            crConnectionInfo.UserID = Constants.CMLTConstants.dbUserName;
            crConnectionInfo.Password = Constants.CMLTConstants.dbPassword;
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            //string _s = "MEP";
            //string selectionformula = "{CAS_RPT.BZONE}='" + _s + "' and {CAS_RPT.CATE}=\"DB\"";
            //SelectionFormula(cryRpt, (string)Session["zone"], (string)Session["cat"], (string)Session["flvl"], (string)Session["fed"]);
            string _graph = "";
            if (lblprj.Text == "HMIM")
            {
                string _bldg = "";
                if (lbldiv.Text == "1") _bldg = "CENTRAL UTILITY CENTRE";
                else if (lbldiv.Text == "2") _bldg = "PIAZZA";
                else if (lbldiv.Text == "3") _bldg = "SERVICE BUILDING";
                else if (lbldiv.Text == "4") _bldg = "HARAM";
                _graph ="(" + _bldg + ") Summary - " + drtype.SelectedItem.Text;
            }
            else if (lblprj.Text == "HMHS")
            {
                string _bldg = "";
                if (lbldiv.Text == "1") _bldg = "HOSPITAL";
                else if (lbldiv.Text == "2") _bldg = "PLOT 1 SECURITY BUILDING";
                _graph = "(" + _bldg + ") Summary - " + drtype.SelectedItem.Text;
            }
            else
                _graph = "Summary - " + drtype.SelectedItem.Text;
            
            if ((string)Session["zone"] == null) Session["zone"] = "All";
            if ((string)Session["flvl"] == null) Session["flvl"] = "All";
            if ((string)Session["cat"] == null) Session["cat"] = "All";
            if ((string)Session["fed"] == null) Session["fed"] = "All";
            if ((string)Session["loc"] == null) Session["loc"] = "All";
            string _name = lblsch.Text;
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
            {
                if (_name == "21")
                    _name = "21A";
                else if (_name == "8")
                    _name = "8A";
                else if (_name == "23")
                   _name = "23A";
                    
            }
            if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
            {
                if (_name == "23") _name = "23_P";
                else if (_name == "24") _name = "24_P";
            }
             if (lblprj.Text == "12761")
            {
                if (_name == "24") _name = "24_CP";
                else if (_name == "27") _name = "27_CP";
            }
             if ((lblprj.Text == "HMIM" || lblprj.Text == "HMHS" ) && lblsch.Text == "28")
             {
                 _name = "28A";
             }
             if ((lblprj.Text == "OPH") && lblsch.Text == "25")
             {
                 _name = "25o";
             }
             if ((lblprj.Text == "OPH") && lblsch.Text == "28")
             {
                 _name = "28_OPH";
             }
             if ((lblsch.Text == "27") && (lblprj.Text == "HMIM" || lblprj.Text == "OCEC"))
             {
                 _name = "27_" + lblprj.Text;
             }

             if ((lblprj.Text == "OPH") && lblsch.Text == "20")
             {
                 _name = "20_OPH";
             }
             if (lblprj.Text == "11784" && Convert.ToInt32(lblsch.Text)>24)
             {
                 _name = lblsch.Text + "_" + lblprj.Text;
             }
             if (lblprj.Text == "MOE" && (lblsch.Text == "31" || lblsch.Text == "32"))
             {
                 _name = lblsch.Text + "_" + lblprj.Text;
             }


            cryRpt.SetParameterValue("name",_name);
            cryRpt.SetParameterValue("project", get_project());
            cryRpt.SetParameterValue("data_title", Get_Title());
            cryRpt.SetParameterValue("graph",_graph);
            cryRpt.SetParameterValue("bz", (string)Session["zone"]);
            cryRpt.SetParameterValue("cat", (string)Session["cat"]);
            cryRpt.SetParameterValue("fl", (string)Session["flvl"]);
            cryRpt.SetParameterValue("ff", (string)Session["fed"]);
            cryRpt.SetParameterValue("lo", (string)Session["loc"]);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
        private void Page_Init(object sender, EventArgs e)
        {

            //Session["filter"] = "no";
            //Session["zone"] = "All";
            //Session["flvl"] = "All";
            //Session["cat"] = "All";
            //Session["fed"] = "All";
            //Session["loc"] = "All";
            //Generate_Reports();
            _ReadCookies();
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                if (_prm.Contains("_D") == true)
                {
                    lblsch.Text = _prm.Substring(1, _prm.IndexOf("_P") - 1);
                    lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_D") - (_prm.IndexOf("_P") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_D") + 2);
                }
                else if (_prm.Contains("_F") == true)
                {
                    lblsch.Text = _prm.Substring(1, _prm.IndexOf("_P") - 1);
                    lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("_F") - (_prm.IndexOf("_P") + 2));
                    lbldiv.Text = _prm.Substring(_prm.IndexOf("_F") + 2);
                }
                else
                {
                    lblsch.Text = _prm.Substring(1, _prm.IndexOf("_P") - 1);
                    lblprj.Text = _prm.Substring(_prm.IndexOf("_P") + 2);
                    lbldiv.Text = "0";
                }
                lblsch1.Text = lblsch.Text;
                if (lblprj.Text == "CCAD")
                {
                    if (lblsch.Text == "30" || lblsch.Text == "31" || lblsch.Text == "32" || lblsch.Text == "33" || lblsch.Text == "34" || lblsch.Text == "35" || lblsch.Text == "36" || lblsch.Text == "37" || lblsch.Text == "38" || lblsch.Text == "39" || lblsch.Text == "40")
                        lblsch1.Text = "9";
                    else if (lblsch.Text == "63" || lblsch.Text == "64" || lblsch.Text == "65" || lblsch.Text == "66" || lblsch.Text == "67" || lblsch.Text == "68" || lblsch.Text == "69" || lblsch.Text == "70" || lblsch.Text == "71" || lblsch.Text == "72" || lblsch.Text == "73")
                    {
                        lblsch1.Text = "61";
                    }
                    else if (lblsch.Text == "74" || lblsch.Text == "75" || lblsch.Text == "76" || lblsch.Text == "77" || lblsch.Text == "78" || lblsch.Text == "79" || lblsch.Text == "80" || lblsch.Text == "81" || lblsch.Text == "82" || lblsch.Text == "83" || lblsch.Text == "84")
                    {
                        lblsch1.Text = "62";
                    }
                    else if (lblsch.Text == "101" || lblsch.Text == "97" || lblsch.Text == "95")
                    {
                        lblsch1.Text = "18";
                    }
                    else if (lblsch.Text == "102")
                    {
                        lblsch1.Text = "19";
                    }
                    else if (lblsch.Text == "100")
                    {
                        lblsch1.Text = "28";
                    }
                    else if (lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117")
                    {
                        lblsch1.Text = "17";
                    }
                    else if (lblsch.Text == "103" || lblsch.Text == "104" || lblsch.Text == "105" || lblsch.Text == "106" || lblsch.Text == "109" || lblsch.Text == "110" || lblsch.Text == "111" || lblsch.Text == "112" || lblsch.Text == "116")
                        lblsch1.Text = "27";
                }
                Load_Master();
                Session["filter"] = "no";
                Session["zone"] = "All";
                Session["flvl"] = "All";
                Session["cat"] = "All";
                Session["fed"] = "All";
                Session["loc"] = "All";
                Load_Filtering_Elements();


                    Generate_Summary();
                    Generate_Summary_Graph();
               
                     Generate_Reports();

                if (_prm.Substring(0, 1) == "0")
                    tdback.Visible = false;
            }
            else
            {
                if (Session["Report"] != null)
                {
                    CrystalReportViewer1.ReportSource = (ReportDocument)Session["Report"];
                    CrystalReportViewer1.DataBind();
                }
            }
        }
        protected void TimerTick(object sender, EventArgs e)
        {
            //Load_Master();
            //Session["filter"] = "no";
            //Session["zone"] = "All";
            //Session["flvl"] = "All";
            //Session["cat"] = "All";
            //Session["fed"] = "All";
            //Session["loc"] = "All";
            //Load_Filtering_Elements();
            //Generate_Summary();
            //Generate_Summary_Graph();
            //Timer1.Enabled = false;
            //imgLoader.Visible = false;
        }
        protected void drloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["loc"] = drloc.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text, drloc.SelectedItem.Text);
        }
        protected void drtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Generate_Summary();
        }
        private void Building1_5()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sch = 5;
                _objcls.b_zone = drbuilding.SelectedItem.Text;
                _objcls.cate = drcategory.SelectedItem.Text;
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = drfed.SelectedItem.Text;
                _objcls.loca = drloc.SelectedItem.Text;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                DataTable _dt = _objbll.Generate_Bldg_Rpt(_objcls, _objdb);
                foreach (DataRow _row in _dt.Rows)
                {
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = _row["BLDG_NAME"].ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _row["Overall"].ToString();
                    _drow[6] = _row["BLDG_NAME"].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building2()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sch = 2;
                _objcls.b_zone = drbuilding.SelectedItem.Text;
                _objcls.cate = drcategory.SelectedItem.Text;
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = drfed.SelectedItem.Text;
                _objcls.loca = drloc.SelectedItem.Text;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                DataTable _dt = _objbll.Generate_Bldg_Rpt(_objcls, _objdb);
                foreach (DataRow _row in _dt.Rows)
                {
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = _row["BLDG_NAME"].ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _row["Overall"].ToString();
                    _drow[6] = _row["BLDG_NAME"].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building8()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = Decimal.Round(_p1 * 0.2m, 2);
                    decimal _per2 = Decimal.Round(_p2 * 0.8m, 2);
                    decimal _per3 = 0;
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    decimal _t = _per1 + _per2;
                    if (_t != 0)
                        _total = Decimal.Round(((_per1 + _per2) / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building3()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sch = 3;
                _objcls.b_zone = drbuilding.SelectedItem.Text;
                _objcls.cate = drcategory.SelectedItem.Text;
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = drfed.SelectedItem.Text;
                _objcls.loca = drloc.SelectedItem.Text;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                DataTable _dt = _objbll.Generate_Bldg_Rpt(_objcls, _objdb);
                foreach (DataRow _row in _dt.Rows)
                {
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = _row["BLDG_NAME"].ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _row["Overall"].ToString();
                    _drow[6] = _row["BLDG_NAME"].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building6()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sch = 6;
                _objcls.b_zone = drbuilding.SelectedItem.Text;
                _objcls.cate = drcategory.SelectedItem.Text;
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = drfed.SelectedItem.Text;
                _objcls.loca = drloc.SelectedItem.Text;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                DataTable _dt = _objbll.Generate_Bldg_Rpt(_objcls,_objdb);
                foreach (DataRow _row in _dt.Rows)
                {
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = _row["BLDG_NAME"].ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _row["Overall"].ToString();
                    _drow[6] = _row["BLDG_NAME"].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building12_moe()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sch = 12;
                _objcls.b_zone = drbuilding.SelectedItem.Text;
                _objcls.cate = drcategory.SelectedItem.Text;
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = drfed.SelectedItem.Text;
                _objcls.loca = drloc.SelectedItem.Text;
                DataTable _dt = _objbll.Generate_Bldg_Rpt(_objcls, _objdb);
                foreach (DataRow _row in _dt.Rows)
                {
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = _row["BLDG_NAME"].ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _row["Overall"].ToString();
                    _drow[6] = _row["BLDG_NAME"].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building4()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    if (_p2 != 0)
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count));
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count));
                    decimal _t = _per1 + _per2 + _per3;
                    if (_t != 0)
                        _total = Decimal.Round((_per1 + _per2 + _per3) / 3);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _per1.ToString();
                    _drow[3] = _per2.ToString();
                    _drow[4] = _per3.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building7()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }


                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    decimal _t = _p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7;
                    if (_t != 0)
                        _total = decimal.Round(((_p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7) / (count * 7)) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building20()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _points = 0;
                    decimal _devices = 0;
                    decimal _systems = 0;
                    decimal _total = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _points += Convert.ToInt32(_row["devices2"].ToString());
                        _devices += Convert.ToInt32(_row["devices3"].ToString());
                        _systems += Convert.ToInt32(_row["devices1"].ToString());
                    }

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    decimal _t = _p1 + _p2 + _p3 + _p4 + _p5 + _p6;
                    if (_t != 0)
                        _total = decimal.Round(((_p1 + _p2 + _p3 + _p4 + _p5 + _p6) / ((_points * 2 + _devices + _systems * 3))) * 100);
                   // _total = decimal.Round(_p1 + _p2 + _p3 + _p4 + _p5 + _p6);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building13()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _devices = 0;
                    decimal _total = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _devices += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = _devices.ToString();
                    _drow[2] = "0";
                    decimal _t = _p1 + _p2 + _p3 + _p4 + _p5;
                    if (_t != 0)
                        _total = Decimal.Round(((_p1 + _p2 + _p3 + _p4 + _p5) / (_devices * 5)) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building22()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _devices = 0;
                    decimal _total = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        _devices += Convert.ToInt32(_row["devices1"].ToString());
                    }

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = _devices.ToString();
                    _drow[2] = "0";
                    decimal _t = _p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7;
                    if (_t != 0)
                        _total = decimal.Round(((_p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7) / (_devices * 7)) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building11()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _circuits = 0;
                    decimal _scenes = 0;
                    decimal _total = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _scenes += Convert.ToInt32(_row["devices1"].ToString());
                        _circuits += Convert.ToInt32(_row["devices2"].ToString());
                    }

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    decimal _t = _p1 + _p2 + _p3 + _p4;
                    if (_t != 0)
                        _total = decimal.Round(((_p1 + _p2 + _p3 + _p4) / (_circuits * 3 + _scenes)) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building12()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"]}).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    //if (row.col2.ToString() == "CU" || row.col2.ToString() == "FO")
                    //{
                        decimal _p1 = 0;
                        decimal _total = 0;
                        decimal _points = 0;
                        string _cat = "";
                        var _result = from _data in _dtresult.AsEnumerable()
                                      where _data.Field<string>("B_Z") == row.col1.ToString()
                                      select _data;
                        foreach (var _row in _result)
                        {
                            _cat = _row["Cat"].ToString();
                            if (_row["Cat"].ToString() == "CU" || _row["Cat"].ToString() == "FO")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                _points += Convert.ToDecimal(_row["devices1"].ToString());
                            }
                        }
                        if (_cat == "CU" || _cat == "FO")
                        {
                            if (_p1 != 0)
                                _total = Decimal.Round((_p1 / _points) * 100);
                            DataRow _drow = _dtsummary.NewRow();
                            _drow[0] = row.col1.ToString();
                            _drow[1] = _points.ToString();
                            _drow[2] = Decimal.Round(_p1).ToString();
                            _drow[3] = "0";
                            _drow[4] = "0";
                            _drow[5] = _total.ToString();
                            _drow[6] = row.col1.ToString();
                            _dtsummary.Rows.Add(_drow);
                        }
                    }

                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building15()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _p9 = 0;
                    decimal _devices = 0;
                    decimal _total = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        _p8 += Convert.ToDecimal(_row["per_com8"].ToString());
                        _p9 += Convert.ToDecimal(_row["per_com9"].ToString());
                        _devices += Convert.ToInt32(_row["devices1"].ToString());
                    }

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = _devices.ToString();
                    _drow[2] = "0";
                    decimal _t = _p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7 + _p8 + _p9;
                    if (_t != 0)
                        _total = decimal.Round(((_p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7 + _p8 + _p9) / (_devices * 9)) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building14()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _devices = 0;
                    decimal _total = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (_row["cat"].ToString() == "AVP")
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                            _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                    }
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = _devices.ToString();
                    _drow[2] = "0";
                    decimal _t = _p1 + _p2 + _p3 + _p4;
                    if (_t != 0)
                        _total = decimal.Round(((_p1 + _p2 + _p3 + _p4) / (_devices * 4)) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building23()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _count1 = 0;
                    decimal _count2 = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        _count1 += 1;
                    }
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = _count1.ToString();
                    _drow[2] = 0;
                    decimal _t = _p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7;
                    if (_t != 0)
                        _total = decimal.Round(((_p1 + _p2 + _p3 + _p4 + _p5 + _p6 + _p7) / (_count1 * 7)) * 100);
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building21()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += 1;
                    }
                    if(_p1!=0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building9()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count += 1;
                    }
                    if (_p1 != 0)
                        _total = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building17()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    //decimal _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                    //decimal _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                    decimal _per1 = Decimal.Round(_p1 * 0.2m, 2);
                    decimal _per2 = Decimal.Round(_p2 * 0.8m, 2);
                    decimal _per3 = 0;
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    decimal _t = _per1 + _per2;
                    if (_t != 0)
                        _total = Decimal.Round(((_per1 + _per2) / Convert.ToDecimal(count)) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building18()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (_p1 != 0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building19()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += 1;
                    }
                    if (_p1 != 0)
                        _total = _p1 / Convert.ToDecimal(count);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private string Get_Title()
        {
            if (drtype.SelectedItem.Value == "2")
                return "BUILDINGS";
            else
            {
                if (lblprj.Text == "14211")
                    return "SYSTEMS";
                else
                {
                    if (lblsch1.Text == "1" || lblsch1.Text == "2" || lblsch1.Text == "3" || (string)Session["sch"] == "4" || lblsch1.Text == "5" || lblsch1.Text == "6" || lblsch1.Text == "8" || lblsch1.Text == "9" || lblsch1.Text == "21" || (string)Session["sch"] == "17" || lblsch1.Text == "18" || lblsch1.Text == "19")
                        return "SYSTEMS";
                    else
                        return "TESTS";
                }

            }
        }
        private void Building10()
        {
            //try
            //{
            //    _dtsummary.Columns.Add("SYS_NAME", typeof(string));
            //    _dtsummary.Columns.Add("QTY", typeof(string));
            //    _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
            //    _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
            //    _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
            //    _dtsummary.Columns.Add("TOTAL", typeof(string));
            //    _dtsummary.Columns.Add("CODE", typeof(string));
            //    decimal _p1 = 0;
            //    decimal _devices = 0;
            //    decimal _total = 0;
            //    decimal _count = 0;
            //    var _result = from _data in _dtresult.AsEnumerable()
            //                  select _data;
            //    BLL_Dml _objbll = new BLL_Dml();
            //    _database _objdb = new _database();
            //    _objdb.DBName = "DB_" + lblprj.Text;
            //    _clscassheet _objcas = new _clscassheet();
            //    _objcas.sch = Convert.ToInt32(lblsch1.Text);
            //    DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
            //    var TestNames = from _data in _dtnames.AsEnumerable()
            //                    select _data;
            //    foreach (var row in TestNames)
            //    {
            //        DataRow _drow = _dtsummary.NewRow();
            //        _drow[0] = row[0].ToString();
            //        _devices = 0;
            //        _p1 = 0;
            //        if (row[0].ToString() == "Circuit IR Test")
            //        {
            //            foreach (var _row in _result)
            //            {
            //                if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "CKT" || _row["cat"].ToString() == "FTU")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
            //                    _devices += Convert.ToInt32(_row["devices2"].ToString());
            //                }
            //            }
            //            _drow[1] = Decimal.Round(_devices).ToString();
            //            _drow[2] = Decimal.Round(_p1).ToString();
            //        }
            //        else if (row[0].ToString() == "Device/Address Test")
            //        {
            //            foreach (var _row in _result)
            //            {
            //                if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "CKT" || _row["cat"].ToString() == "FTU")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
            //                    _devices += Convert.ToInt32(_row["devices2"].ToString());
            //                }
            //            }
            //            _drow[1] = Decimal.Round(_devices).ToString();
            //            _drow[2] = Decimal.Round(_p1).ToString();


            //        }
            //        else if (row[0].ToString() == "Sound Level Test")
            //        {
            //            foreach (var _row in _result)
            //            {
            //                if (_row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "CKT")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
            //                    _devices += Convert.ToInt32(_row["devices2"].ToString());
            //                }
            //                else if (_row["cat"].ToString() == "FTU")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
            //                    _devices += Convert.ToInt32(_row["devices2"].ToString());
            //                }
            //            }
            //            _drow[1] = Decimal.Round(_devices).ToString();
            //            _drow[2] = Decimal.Round(_p1).ToString();
            //        }
            //        else if (row[0].ToString() == "Interface Test")
            //        {
            //            foreach (var _row in _result)
            //            {
            //                if (_row["cat"].ToString() == "FAL" || _row["cat"].ToString() == "VAC" || _row["cat"].ToString() == "CKT")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
            //                    _devices += Convert.ToInt32(_row["devices1"].ToString());
            //                }
            //            }
            //            _drow[1] = Decimal.Round(_devices).ToString();
            //            _drow[2] = Decimal.Round(_p1).ToString();

            //        }
            //        else if (row[0].ToString() == "Fire Telephone Test")
            //        {
            //            foreach (var _row in _result)
            //            {
            //                if (_row["cat"].ToString() == "FTU")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
            //                    _devices += Convert.ToInt32(_row["devices2"].ToString());
            //                }
            //            }
            //            _drow[1] = Decimal.Round(_devices).ToString();
            //            _drow[2] = Decimal.Round(_p1).ToString();

            //        }
            //        else if (row[0].ToString() == "Battery Autonomy Test")
            //        {
            //            _count = 0;
            //            foreach (var _row in _result)
            //            {
            //                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "FTP")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
            //                    _count += 1;
            //                }
            //            }
            //            _drow[1] = Decimal.Round(_devices).ToString();
            //            _drow[2] = Decimal.Round(_p1).ToString();

            //        }
            //        else if (row[0].ToString() == "Graphic Test")
            //        {
            //            _count = 0;
            //            foreach (var _row in _result)
            //            {
            //                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "FTP")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
            //                    _count += 1;
            //                }
            //            }
            //            _drow[1] = Decimal.Round(_devices).ToString();
            //            _drow[2] = Decimal.Round(_p1).ToString();

            //        }
            //        else if (row[0].ToString() == "Cause Effect Test")
            //        {
            //            _count = 0;
            //            foreach (var _row in _result)
            //            {
            //                if (_row["cat"].ToString() == "FACP" || _row["cat"].ToString() == "PAVA" || _row["cat"].ToString() == "FTP")
            //                {
            //                    _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
            //                    _count += 1;
            //                }
            //            }
            //            _drow[1] = Decimal.Round(_devices).ToString();
            //            _drow[2] = Decimal.Round(_p1).ToString();

            //        }
            //        if (_drow[1].ToString() != "0")
            //        {
            //            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
            //        }
            //        else
            //            _total = 0;
            //        _drow[3] = "0";
            //        _drow[4] = "0";
            //        _drow[5] = _total.ToString();
            //        _drow[6] = row[0].ToString();
            //        _dtsummary.Rows.Add(_drow);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            //}
            _dtsummary = new DataTable();
            _dtsummary.Columns.Add("SYS_NAME", typeof(string));
            _dtsummary.Columns.Add("QTY", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
            _dtsummary.Columns.Add("TOTAL", typeof(string));
            _dtsummary.Columns.Add("CODE", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in distinctRows)
            {
                //_row[0] = row.col1.ToString();
                //_row[1] = row.col2.ToString();
                decimal _p1 = 0;
                decimal _total = 0;
                int count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("B_Z") == row.col1.ToString()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    if (IsNumeric(_row["devices1"].ToString()) == true)
                        count += Convert.ToInt32(_row["devices1"].ToString());
                }
                if (count != 0)
                    _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
                DataRow _drow = _dtsummary.NewRow();
                _drow[0] = row.col1.ToString();
                _drow[1] = count.ToString();
                _drow[2] = Decimal.Round(_p1).ToString();
                _drow[3] = "0";
                _drow[4] = "0";
                _drow[5] = _total.ToString();
                _drow[6] = row.col1.ToString();
                _dtsummary.Rows.Add(_drow);
            }
        }
        private bool IsNumeric(object Expression)
        {
            // Variable to collect the Return value of the TryParse method.
            bool isNum;

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        private void Summary16()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    if (row[0].ToString() == "Continuity/ IR Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Point to Point Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Calibration/ Functional Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {

                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                                else
                                    _devices += 0;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Sequence of Operation Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Graphics/ Head End Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[2].ToString() != "0")
                    {
                        
                        _total = (Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString())) * 100;
                        if (_total >= 99.5m && _total < 100m) _total = 99;
                    }
                    else
                        _total = 0;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = Decimal.Round(_total).ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building16()
        {
            _dtsummary = new DataTable();
            _dtsummary.Columns.Add("SYS_NAME", typeof(string));
            _dtsummary.Columns.Add("QTY", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
            _dtsummary.Columns.Add("TOTAL", typeof(string));
            _dtsummary.Columns.Add("CODE", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in distinctRows)
            {
                //_row[0] = row.col1.ToString();
                //_row[1] = row.col2.ToString();
                decimal _p1 = 0;
                decimal _total = 0;
                int count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("B_Z") == row.col1.ToString()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                    count += Convert.ToInt32(_row["devices1"].ToString());
                }
                if (_p1 != 0)
                    _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
                DataRow _drow = _dtsummary.NewRow();
                _drow[0] = row.col1.ToString();
                _drow[1] = count.ToString();
                _drow[2] = Decimal.Round(_p1).ToString();
                _drow[3] = "0";
                _drow[4] = "0";
                _drow[5] = _total.ToString();
                _drow[6] = row.col1.ToString();
                _dtsummary.Rows.Add(_drow);
            }
        }
        private void Summary24()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _total = 0;
                    decimal _count = 0;

                    _total = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _s = _row[0].ToString();
                        _count += 1;
                    }
                    decimal _per1 = 0;
                    if (_count != 0)
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_count), 2);
                    _total = Decimal.Round((_per1) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary24_2()

        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED3", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    decimal _count = 0;
                    _total = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _s = _row[0].ToString();
                        _count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    if (_count != 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_count), 2);
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(_count), 2);
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(_count), 2);
                        _per4 = Decimal.Round(_p4 / Convert.ToDecimal(_count), 2);
                    }
                    _total = Decimal.Round(((_per1 * 0.1m) + (_per2 * 0.2m) + (_per3 * 0.35m) + (_per4 * 0.35m)) * 100, 0, MidpointRounding.AwayFromZero);

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _count.ToString();
                    _drow[2] = Decimal.Round(_per1).ToString();
                    _drow[3] = Decimal.Round(_per2).ToString();
                    _drow[4] = Decimal.Round(_per3).ToString();
                    _drow[5] = Decimal.Round(_per4).ToString();
                    _drow[6] = _total.ToString();
                    _drow[7] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }

        }
        private void Building24()
        {
            _dtsummary = new DataTable();
            _dtsummary.Columns.Add("SYS_NAME", typeof(string));
            _dtsummary.Columns.Add("QTY", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
            _dtsummary.Columns.Add("TOTAL", typeof(string));
            _dtsummary.Columns.Add("CODE", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in distinctRows)
            {
                //_row[0] = row.col1.ToString();
                //_row[1] = row.col2.ToString();
                decimal _p1 = 0;
                decimal _total = 0;
                int count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("B_Z") == row.col1.ToString()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                    count += 1;
                }
                if (count != 0)
                    _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
                DataRow _drow = _dtsummary.NewRow();
                _drow[0] = row.col1.ToString();
                _drow[1] = count.ToString();
                _drow[2] = Decimal.Round(_p1).ToString();
                _drow[3] = "0";
                _drow[4] = "0";
                _drow[5] = _total.ToString();
                _drow[6] = row.col1.ToString();
                _dtsummary.Rows.Add(_drow);
            }
        }
        private void Summary34()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count += 1;
                    }
                    if (count != 0)
                        _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = 0;
                    _drow[4] = 0;
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building34()
        {
            _dtsummary = new DataTable();
            _dtsummary.Columns.Add("SYS_NAME", typeof(string));
            _dtsummary.Columns.Add("QTY", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
            _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
            _dtsummary.Columns.Add("TOTAL", typeof(string));
            _dtsummary.Columns.Add("CODE", typeof(string));
            var distinctRows = (from DataRow dRow in _dtresult.Rows
                                select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in distinctRows)
            {
                //_row[0] = row.col1.ToString();
                //_row[1] = row.col2.ToString();
                decimal _p1 = 0;
                decimal _total = 0;
                int count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              where _data.Field<string>("B_Z") == row.col1.ToString()
                              select _data;
                foreach (var _row in _result)
                {
                    _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                    count += 1;
                }
                if (count != 0)
                    _total = Decimal.Round(_p1 / Convert.ToDecimal(count), 2) * 100;
                DataRow _drow = _dtsummary.NewRow();
                _drow[0] = row.col1.ToString();
                _drow[1] = count.ToString();
                _drow[2] = Decimal.Round(_p1).ToString();
                _drow[3] = "0";
                _drow[4] = "0";
                _drow[5] = _total.ToString();
                _drow[6] = row.col1.ToString();
                _dtsummary.Rows.Add(_drow);
            }
        }
        private void Summary8_1()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    decimal _overall = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _com1 = 0;
                    decimal _com2 = 0;
                    if (_p1 != 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        _com1 = _per1 * 100;
                    }
                    if (_p2 != 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        _com2 = _per2 * 100;
                    }
                    if (_p3 != 0)
                        _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
                    if (_p6 != 0)
                        _per4 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
                    if (_p7 != 0)
                        _per5 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
                    _total1 = Decimal.Round(((_per4 * 0.5m) + (_per5 * 0.5m)) * 100);
                    _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary9_1()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    decimal _overall = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _p8 += Convert.ToDecimal(_row["per_com4"].ToString());//ins
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    decimal _com1 = 0;
                    decimal _com2 = 0;
                    if (_p1 != 0)
                    {
                        _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        _com1 = _per1 * 100;
                    }
                    if (_p2 != 0)
                    {
                        _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        _com2 = _per2 * 100;
                    }
                    if (_p4 != 0)
                        _per3 = Decimal.Round(_p4 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_com1 * 0.1m) + (_com2 * 0.9m)));
                    if (_p5 != 0)
                        _per4 = Decimal.Round(_p5 / Convert.ToDecimal(count), 2);
                    if (_p6 != 0)
                        _per5 = Decimal.Round(_p6 / Convert.ToDecimal(count), 2);
                    if (_p8 != 0)
                        _per6 = Decimal.Round(_p8 / Convert.ToDecimal(count), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round(_p7 / Convert.ToDecimal(count), 2);
                    _total1 = Decimal.Round(((_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m) + (_per7 * 0.25m)) * 100);
                    _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary27_OPH()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;

                    if (row[0].ToString() == "Continuity/ IR Tests")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "DB Levels")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();


                    }
                    else if (row[0].ToString() == "Paging Mic")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {

                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                _devices += 1;
                            }

                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Addressing / Software Test")
                    {
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                _devices += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }

                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[2].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        private void Summary2_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com2"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com3"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com4"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com5"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per3 * 0.25m) + (_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary5_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (row.col3.ToString() == "PFC")
                        _total = Decimal.Round(_per1, 2);
                    else if (row.col3.ToString() == "MDB" || row.col3.ToString() == "VFD" || row.col3.ToString() == "MCC")
                        _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), 2);
                    else if (row.col3.ToString() == "ATS" || row.col3.ToString() == "UPS" || row.col3.ToString() == "LCP" || row.col3.ToString() == "BAT")
                        _total = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)), 2);
                    else if (row.col3.ToString() == "IPS")
                        _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    else if (row.col3.ToString() == "DB")
                        _total = Decimal.Round(((_per2 * 0.7m) + (_per3 * 0.3m)), 2);
                    else
                        _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.3m) + (_per3 * 0.2m)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary4_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(((_per1 * 0.6m) + (_per2 * 0.4m)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary6_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    if (_p1 != 0)
                        _per1 = ((_p1 / Convert.ToDecimal(count)) * 100);
                    if (_p2 != 0)
                        _per2 = ((_p2 / Convert.ToDecimal(count)) * 100);
                    if (_p3 != 0)
                        _per3 = ((_p3 / Convert.ToDecimal(count)) * 100);
                    _total = Decimal.Round(((Decimal.Round(_per1) * 0.6m) + (Decimal.Round(_per2) * 0.3m) + (Decimal.Round(_per3) * 0.1m)), 0, MidpointRounding.AwayFromZero);
                    if (_p4 != 0)
                        _per4 = (_p4 / Convert.ToDecimal(count));
                    if (_p5 != 0)
                        _per5 = (_p5 / Convert.ToDecimal(count));
                    if (_p6 != 0)
                        _per6 = (_p6 / Convert.ToDecimal(count));
                    if (_p7 != 0)
                        _per7 = (_p7 / Convert.ToDecimal(count));
                    //_total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m)) * 100), 2);
                    _total1 = Decimal.Round((((_per4 * 0.5m) + (_per7 * 0.5m)) * 100), 0, MidpointRounding.AwayFromZero);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)), 0, MidpointRounding.AwayFromZero);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary3_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary7_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                        if (IsNumeric(_row["devices2"].ToString()) == true)
                            qty += Convert.ToInt32(_row["devices2"].ToString());
                        if (IsNumeric(_row["test1"].ToString()) == true)
                            _cold += Convert.ToInt32(_row["test1"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(((_per1 * 0.5m) + (_per2 * 0.5m)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.25m) + (_per5 * 0.25m) + (_per6 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary20_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//inst
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per3 * 0.2m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary12_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());//inst
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//pft
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pwron
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//fpt
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round((_per1), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per2 * 0.2m) + (_per3 * 0.2m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary10_1()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    if (row[0].ToString() == "Circuit IR / Continuity Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "FA Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "FA Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                            else
                                _devices += 0;
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Voice Evac Speaker Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Fire Telephone Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            //_count += 1;
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Graphic/ Head End Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[1].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }
                    else
                        _total = 0;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
       
        private void Summary10_2()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    int idx = 0;
                    decimal _qty = 0;
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Circuit IR Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTC"
                                  select _data;
                        decimal _intrface = 0;
                        decimal _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.15m;
                    }
                    else if (row[0].ToString() == "Device/Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.6m;
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "NAC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                            if (IsNumeric(_row["devices1"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices1"].ToString());
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.13m;
                    }

                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.03m;

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;

                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                            if (IsNumeric(_row["devices2"].ToString()) == true)
                                _devices += Convert.ToInt32(_row["devices2"].ToString());
                            _panel += 1;
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        if (_drow[1].ToString() != "0")
                        {
                            _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                        }
                        else
                            _total = 0;
                        _weighting = _total * 0.05m;

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }

                    _drow[3] = "0";
                    _drow[4] = _weighting.ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary31()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    int count = 0;
                    decimal _qty = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count += Convert.ToInt32(_row["devices2"].ToString());
                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    if (_p1 != 0)
                    {
                        if (row.col3.ToString() == "VAC")
                            _per1 = Decimal.Round(_p1 / Convert.ToDecimal(count), 2);
                        else
                            _per1 = Decimal.Round(_p1 / Convert.ToDecimal(_qty), 2);
                    }
                    if (_p2 != 0)
                    {
                        if (row.col3.ToString() == "VAC")
                            _per2 = Decimal.Round(_p2 / Convert.ToDecimal(count), 2);
                        else
                            _per2 = Decimal.Round(_p2 / Convert.ToDecimal(_qty), 2);
                    }
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100);
                    _devices += count;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    if (row.col3.ToString() == "VAC")
                        _drow[1] = count.ToString();
                    else
                        _drow[1] = _qty.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary17_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//inst
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pft
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//pwron
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//fpt
                        _p8 += Convert.ToDecimal(_row["per_com8"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    decimal _per8 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100, 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                    if (_p8 != 0)
                        _per8 = Decimal.Round((_p8 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per8 * 0.2m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary19_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                  
                    decimal _overall = Decimal.Round(((_per1 * 0.8m) + (_per2 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary27_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//inst
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    decimal _per8 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 2);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 2);
                    _total = Decimal.Round(_per2, 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per5 * 0.25m) + (_per6 * 0.25m) + (_per7 * 0.25m) + (_per3 * 0.25m)) * 100), 2);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary37()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)) * 100);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)) * 100);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)) * 100);
                    _total = Decimal.Round((_per1 + _per2 + _per3 + _per4) / 4);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = 0;
                    _drow[3] = 0;
                    _drow[4] = 0;
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building37()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["B_Z"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("B_Z") == row.col1.ToString()
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)) * 100);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)) * 100);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)) * 100);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)) * 100);
                    _total = Decimal.Round((_per1 + _per2 + _per3 + _per4) / 4);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col1.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = 0;
                    _drow[3] = 0;
                    _drow[4] = 0;
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col1.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary29_1()
        {

            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    int qty = 0;
                    int _cold = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//inst
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    decimal _per8 = 0;
                    if (_p1 != 0)
                        _per1 = Decimal.Round((_p1 / Convert.ToDecimal(count)), 0, MidpointRounding.AwayFromZero);
                    if (_p2 != 0)
                        _per2 = Decimal.Round((_p2 / Convert.ToDecimal(count)), 0, MidpointRounding.AwayFromZero);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)), 0, MidpointRounding.AwayFromZero);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);

                    _total1 = Decimal.Round((((_per4 * 0.2m) + (_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per3 * 0.2m)) * 100), 0, MidpointRounding.AwayFromZero);

                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary28_1()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());//inst
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());//pft
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());//pwron
                        _p6 += Convert.ToDecimal(_row["per_com6"].ToString());//fpt
                        _p7 += Convert.ToDecimal(_row["per_com7"].ToString());//arm
                        _s = _row[0].ToString();
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    decimal _per4 = 0;
                    decimal _per5 = 0;
                    decimal _per6 = 0;
                    decimal _per7 = 0;
                    if (_p1 != 0)
                        _per1 = _p1 / Convert.ToDecimal(count);
                    if (_p2 != 0)
                        _per2 = _p2 / Convert.ToDecimal(count);
                    _total = Decimal.Round(_per1 * 0.2m + _per2 * 0.8m, 0, MidpointRounding.AwayFromZero);
                    if (_p4 != 0)
                        _per4 = Decimal.Round((_p4 / Convert.ToDecimal(count)), 2);
                    if (_p5 != 0)
                        _per5 = Decimal.Round((_p5 / Convert.ToDecimal(count)), 2);
                    if (_p6 != 0)
                        _per6 = Decimal.Round((_p6 / Convert.ToDecimal(count)), 2);
                    if (_p7 != 0)
                        _per7 = Decimal.Round((_p7 / Convert.ToDecimal(count)), 2);
                    if (_p3 != 0)
                        _per3 = Decimal.Round((_p3 / Convert.ToDecimal(count)), 2);
                    _total1 = Decimal.Round((((_per5 * 0.2m) + (_per6 * 0.2m) + (_per7 * 0.2m) + (_per3 * 0.2m) + (_per4 * 0.2m)) * 100), 0, MidpointRounding.AwayFromZero);
                    decimal _overall = Decimal.Round(((_total * 0.8m) + (_total1 * 0.2m)), 0, MidpointRounding.AwayFromZero);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _overall.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary28_2()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _total = 0;
                    decimal _total1 = 0;
                    int count = 0;
                    string _s = "";
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100)
                            _p4 += 1;
                        if (Convert.ToDecimal(_row["per_com2"].ToString()) == 100)
                            _p5 += 1;
                        count += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (count != 0)
                        _per1 = _p1 / Convert.ToDecimal(count);
                    if (count != 0)
                        _per2 = _p2 / Convert.ToDecimal(count);
                    //if (_p3 != 0)
                    //    _per3 = Decimal.Round(_p3 / Convert.ToDecimal(count), 2);
                    _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)));
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary10_1_1()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _p2 = 0;
                decimal _devices1 = 0;
                decimal _p3 = 0;
                decimal _devices2 = 0;
                decimal _p4 = 0;
                decimal _devices3 = 0;
                decimal _qty = 0;
                decimal _tested = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    _devices1 = 0;
                    _p2 = 0;
                    _devices2 = 0;
                    _p3 = 0;
                    _devices3 = 0;
                    _p4 = 0;
                    _qty = 0;
                    _tested = 0;
                    int idx = 0;

                    if (row[0].ToString() == "Circuit IR / Continuity Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAD" || _data.Field<string>("Cat") == "FAM" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "FA Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAD"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                       _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "FA Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAM"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices1"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "Voice Evac Speaker Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "ANN" || _data.Field<string>("Cat") == "FSC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "Fire Telephone Device Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTL"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FCC" || _data.Field<string>("Cat") == "FAD" || _data.Field<string>("Cat") == "FAM" || _data.Field<string>("Cat") == "FTL" || _data.Field<string>("Cat") == "SPC" || _data.Field<string>("Cat") == "FSC" || _data.Field<string>("Cat") == "ANN"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                       _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                    }
                    else if (row[0].ToString() == "Graphic/ Head End Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAD"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (_row["B_Z"].ToString() == "CUP")
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "SOUTH GALLERY")
                            {
                                _p2 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices1 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "CLINIC")
                            {
                                _p3 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices2 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                            else if (_row["B_Z"].ToString() == "D&T" || _row["B_Z"].ToString() == "ICU" || _row["B_Z"].ToString() == "SWING" || _row["B_Z"].ToString() == "PATIENT")
                            {
                                _p4 += Convert.ToDecimal(_row["per_com5"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices3 += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _qty = _devices + _devices1 + _devices2 + _devices3;
                        _tested = _p1 + _p2 + _p3 + _p4;
                   }
                    if (_qty != 0)
                    {
                        _total = Decimal.Round((_tested / _qty) * 100);
                    }
                    else
                        _total = 0;
                    _drow[1] = _qty.ToString();
                    _drow[2] = _tested.ToString();
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary_7_1()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));

                decimal _total = 0;
                decimal _tested = 0;

                decimal _emg = 0;
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _qty = 0;
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _p4 = 0;
                    decimal _p5 = 0;
                    decimal _p6 = 0;
                    decimal _p7 = 0;
                    decimal _p8 = 0;
                    decimal _test = 0;
                    decimal _circuit = 0;
                    int count = 0;
                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        if (row.col3.ToString() == "CIR")
                        {
                            if (IsNumeric(_row["test1"].ToString()) == true)
                            {
                                _test += Convert.ToDecimal(_row["test1"].ToString());
                            }
                            count += Convert.ToInt32(_row["devices1"].ToString());
                            _circuit += Convert.ToInt32(_row["devices2"].ToString());
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                            _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                            _p6 += Convert.ToDecimal(_row["per_com6"].ToString());
                            _p7 += Convert.ToDecimal(_row["per_com7"].ToString());
                        }

                        _p8 += Convert.ToDecimal(_row["per_com8"].ToString());

                        _qty += 1;
                    }
                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;
                    if (row.col3.ToString() == "CIR")
                    {
                        if (_circuit > 0)
                            _per1 = _test / _circuit;
                        if (count > 0)
                        {
                            _per3 = ((_p2 + _p3 + _p4 + _p5 + _p6 + _p7) / 6);
                            _per2 = (((_p2 + _p3 + _p4 + _p5 + _p6 + _p7) / count) / 6) * 100;
                        }
                    }
                    else
                    {
                        if (_qty > 0)
                        {
                            _per1 = _p1 / _qty;
                            _per2 = _p2 / _qty;
                        }
                    }
                    _tested += _per1;
                    _total = decimal.Round((_per1 * 0.2m + _per2 * 0.8m));
                    _emg += count;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = _qty.ToString();
                    _drow[2] = decimal.Round(_p1).ToString();
                    _drow[3] = decimal.Round(_per2).ToString();
                    _drow[4] = decimal.Round(_p8).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building_Summary(int sch_id)
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sch = sch_id;
                _objcls.b_zone = drbuilding.SelectedItem.Text;
                _objcls.cate = drcategory.SelectedItem.Text;
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = drfed.SelectedItem.Text;
                _objcls.loca = drloc.SelectedItem.Text;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                DataTable _dt = _objbll.Generate_Bldg_Rpt(_objcls, _objdb);
                foreach (DataRow _row in _dt.Rows)
                {
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = _row["BLDG_NAME"].ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _row["Overall"].ToString();
                    _drow[6] = _row["BLDG_NAME"].ToString();
                    _dtsummary.Rows.Add(_drow);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary31_14221()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;



                decimal _total = 0;
                int count = 0;
                int count1 = 0;


                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 31;

                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);


                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }


                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        count1 += Convert.ToInt32(_row["devices1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    }


                }
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();


                    if (row[0].ToString() == "Cable Test")
                    {
                        _drow[1] = count.ToString();
                        _drow[2] = decimal.Round(_p1).ToString();

                        if (count > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count) * 100);
                        //else _total = 100;


                    }
                    else if (row[0].ToString() == "Functional Test")
                    {
                        _drow[1] = count1.ToString();
                        _drow[2] = decimal.Round(_p2).ToString();
                        if (count1 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count1) * 100);
                        else _total = 100;

                    }

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary28_14221()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;



                decimal _total = 0;
                int count = 0;
                int count1 = 0;
                int count2 = 0;


                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 28;

                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);


                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }


                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        count1 += Convert.ToInt32(_row["devices1"].ToString());
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                    {
                        count2 += Convert.ToInt32(_row["devices1"].ToString());
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                    }


                }
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();


                    if (row[0].ToString() == "Continuity/IR Test")
                    {
                        _drow[1] = count.ToString();
                        _drow[2] = decimal.Round(_p1).ToString();

                        if (count > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count) * 100);



                    }
                    else if (row[0].ToString() == "AVS Test(Audio Part)")
                    {
                        _drow[1] = count1.ToString();
                        _drow[2] = decimal.Round(_p2).ToString();
                        if (count1 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count1) * 100);


                    }
                    else if (row[0].ToString() == "AVS Test(Video Part)")
                    {
                        _drow[1] = count2.ToString();
                        _drow[2] = decimal.Round(_p3).ToString();
                        if (count2 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count2) * 100);


                    }

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }

        private void Summary39_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;

                decimal _total = 0;
                int count = 0;
                int count_COT = 0;

                int count2 = 0;
                int count3 = 0;
                int count4 = 0;
                int count5 = 0;


                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {

                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {

                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());

                        count_COT += 1;
                        count += Convert.ToInt32(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        count2 += Convert.ToInt32(_row["devices1"].ToString()); ;
                    }

                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        count3 += Convert.ToInt32(_row["devices1"].ToString()); ;
                    }


                    if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                    {
                        _p4 += Convert.ToDecimal(_row["per_com6"].ToString());
                        count4 += Convert.ToInt32(_row["devices1"].ToString()); ;
                    }


                    if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                    {
                        _p5 += Convert.ToDecimal(_row["per_com7"].ToString());
                        count5 += Convert.ToInt32(_row["devices1"].ToString()); ;
                    }




                }

                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 39;

                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();


                    if (row[0].ToString() == "Cable Test")
                    {
                        _drow[1] = count.ToString();
                        _drow[2] = decimal.Round(_p1).ToString();
                        if (count > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count) * 100);
                    }
                    else if (row[0].ToString() == "Device Functional Test")
                    {
                        _drow[1] = count2.ToString();
                        _drow[2] = decimal.Round(_p2).ToString();
                        if (count2 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count2) * 100);
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _drow[1] = count3.ToString();
                        _drow[2] = decimal.Round(_p3).ToString();
                        if (count3 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count3) * 100);
                    }
                    else if (row[0].ToString() == "Sequence of Operation")
                    {
                        _drow[1] = count4.ToString();
                        _drow[2] = decimal.Round(_p4).ToString();
                        if (count4 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count4) * 100);
                    }
                    else if (row[0].ToString() == "Graphics/Head End Tests")
                    {
                        _drow[1] = count5.ToString();
                        _drow[2] = decimal.Round(_p5).ToString();
                        if (count5 > 0)
                            _total = decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / count5) * 100);
                    }

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("cmsreports.aspx?idx=1&prj=" + lblprj.Text);
        }
        private void Summary35_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    //_row[0] = row.col1.ToString();
                    //_row[1] = row.col2.ToString();
                    decimal _p1 = 0;
                    decimal _p2 = 0;
                    decimal _p3 = 0;
                    decimal _total = 0;
                    int count = 0;
                    string _s = "";

                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;


                    decimal _t1 = 0;
                    decimal _t2 = 0;
                    decimal _t3 = 0;



                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {

                        if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                        {

                            _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                            count1 += 1;
                        }
                        else
                            _t1 += 1;

                        if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                        {
                            _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                            count2 += 1;
                        }
                        else
                            _t2 += 1;

                        if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                        {
                            _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                            count3 += 1;
                        }
                        else
                            _t3 += 1;

                        _s = _row[0].ToString();
                        count += 1;
                    }

                    decimal _per1 = 0;
                    decimal _per2 = 0;
                    decimal _per3 = 0;


                    if (_t1 >= count) _per1 = -1;
                    if (_t2 >= count) _per2 = -1;
                    if (_t3 >= count) _per3 = -1;


                    if (_p1 > 0)
                        _per1 = _p1 / Convert.ToDecimal(count1);
                    if (_p2 > 0)
                        _per2 = _p2 / Convert.ToDecimal(count2);
                    if (_p3 > 0)
                        _per3 = Decimal.Round(_p3);


                    if (_per1 != -1 && _per2 != -1)
                    {
                        _total = Decimal.Round(((_per1 * 0.2m) + (_per2 * 0.8m)) * 100, MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 != -1 && _per2 == -1)
                    {
                        _total = Decimal.Round((_per1) * 100, MidpointRounding.AwayFromZero);
                    }
                    else if (_per1 == -1 && _per2 != -1)
                        _total = Decimal.Round((_per2) * 100, MidpointRounding.AwayFromZero);
                    else
                        _total = 0;

                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = Decimal.Round(_p1).ToString();
                    _drow[3] = Decimal.Round(_p2).ToString();
                    _drow[4] = Decimal.Round(_p3).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col3.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary37_14211()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _total = 0;
                decimal _points = 0;
                decimal _tested1 = 0;
                decimal _tested2 = 0;
                decimal _tested3 = 0;


                decimal _p1 = 0;
                decimal _p2 = 0;
                decimal _p3 = 0;
                decimal _p4 = 0;
                decimal _p5 = 0;
                decimal _p6 = 0;
                decimal _p7 = 0;

                int count = 0;
                decimal _qty = 0;
                decimal _devices1 = 0;
                decimal _devices2 = 0;
                decimal _devices3 = 0;
                decimal _devices4 = 0;
                decimal _devices5 = 0;

                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                foreach (var _row in _result)
                {
                    if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                    {
                        _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                        _devices1 += Convert.ToDecimal(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                    {
                        _p2 += Convert.ToDecimal(_row["per_com2"].ToString());
                        _devices2 += Convert.ToDecimal(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                    {
                        _p3 += Convert.ToDecimal(_row["per_com3"].ToString());
                        _devices3 += Convert.ToDecimal(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                    {
                        _p4 += Convert.ToDecimal(_row["per_com4"].ToString());
                        _devices4 += Convert.ToDecimal(_row["devices1"].ToString());
                    }
                    if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                    {
                        _p5 += Convert.ToDecimal(_row["per_com5"].ToString());
                        _devices5 += Convert.ToDecimal(_row["devices1"].ToString());
                    }

                }
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = Convert.ToInt32(lblsch1.Text);
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);

                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Cable Test")
                    {
                        _drow[2] = Decimal.Round(_p1).ToString(); _drow[1] = Decimal.Round(_devices1);
                    }
                    else if (row[0].ToString() == "Functional Test")
                    {
                        _drow[2] = Decimal.Round(_p2).ToString(); _drow[1] = Decimal.Round(_devices2);
                    }

                    else if (row[0].ToString() == "Interface Test")
                    {
                        _drow[2] = Decimal.Round(_p3).ToString(); _drow[1] = Decimal.Round(_devices3);
                    }
                    else if (row[0].ToString() == "Sequence of Operation")
                    {
                        _drow[2] = Decimal.Round(_p4).ToString(); _drow[1] = Decimal.Round(_devices4);
                    }
                    else if (row[0].ToString() == "Graphics / Head End Tests")
                    {
                        _drow[2] = Decimal.Round(_p5).ToString(); _drow[1] = Decimal.Round(_devices5);
                    }

                    if (_drow[2].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }

                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    _dtsummary.Rows.Add(_drow);
                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary27_HMIM()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                var distinctRows = (from DataRow dRow in _dtresult.Rows
                                    select new { col1 = dRow["Sys_Id"], col2 = dRow["Sys_name"], col3 = dRow["Cat"] }).Distinct();
                foreach (var row in distinctRows)
                {
                    decimal _p1 = 0;
                    decimal _total = 0;
                    int count = 0;

                    var _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<int>("Sys_id") == Convert.ToInt32(row.col1.ToString())
                                  select _data;
                    foreach (var _row in _result)
                    {
                        if (Convert.ToDecimal(_row["per_com1"].ToString()) == 100) _p1 += 1;
                        count += 1;
                    }
                    if (count > 0)
                        _total = decimal.Round((Convert.ToDecimal(_p1) / (Convert.ToDecimal(count))) * 100);
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row.col2.ToString();
                    _drow[1] = count.ToString();
                    _drow[2] = _p1;
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _total.ToString();
                    _drow[6] = row.col2.ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary10_HMIM()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    int idx = 0;
                    decimal _qty = 0;
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Circuit IR Test")
                    {


                        _result = from _data in _dtresult.AsEnumerable()
                                  //where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {

                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Device/Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  //where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  //where _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "CKT" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  where _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "CKT" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  //where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "FARP" || _data.Field<string>("Cat") == "FSCP" || _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FTP" || _data.Field<string>("Cat") == "FTU" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "VAC" || _data.Field<string>("Cat") == "LHD" || _data.Field<string>("Cat") == "BDC" || _data.Field<string>("Cat") == "VESDA" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Fire Telephone Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTU"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()

                                  where _data.Field<string>("Cat") == "SFACP" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                _devices += 1;
                                //_qty += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                _devices += 1;
                                //_qty += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                    }
                    else if (row[0].ToString() == "Cause Effect Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAVA"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                _devices += 1;
                                // _qty += 1;
                            }

                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();
                        //_drow[1] = "0";
                        //_drow[2] = "0";

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }
                    if (_drow[1].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }

                    _drow[3] = "0";
                    _drow[4] = decimal.Round(_weighting, 0).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    //if (Convert.ToDecimal(_drow[1].ToString()) > 0)
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Building27()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _clscassheet _objcls = new _clscassheet();
                _objdb.DBName = "DB_" + lblprj.Text;
                _objcls.sch = 27;
                _objcls.b_zone = drbuilding.SelectedItem.Text;
                _objcls.cate = drcategory.SelectedItem.Text;
                _objcls.f_level = drflevel.SelectedItem.Text;
                _objcls.fed_from = drfed.SelectedItem.Text;
                _objcls.loca = drloc.SelectedItem.Text;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                DataTable _dt = _objbll.Generate_Bldg_Rpt(_objcls, _objdb);
                foreach (DataRow _row in _dt.Rows)
                {
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = _row["BLDG_NAME"].ToString();
                    _drow[1] = "0";
                    _drow[2] = "0";
                    _drow[3] = "0";
                    _drow[4] = "0";
                    _drow[5] = _row["Overall"].ToString();
                    _drow[6] = _row["BLDG_NAME"].ToString();
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
        private void Summary28_HMIM()
        {
            try
            {
                _dtsummary = new DataTable();
                _dtsummary.Columns.Add("SYS_NAME", typeof(string));
                _dtsummary.Columns.Add("QTY", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED1", typeof(string));
                _dtsummary.Columns.Add("PER_COMPLETED2", typeof(string));
                _dtsummary.Columns.Add("TOTAL", typeof(string));
                _dtsummary.Columns.Add("CODE", typeof(string));
                decimal _p1 = 0;
                decimal _devices = 0;
                decimal _total = 0;
                decimal _count = 0;
                var _result = from _data in _dtresult.AsEnumerable()
                              select _data;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "DB_" + lblprj.Text;
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 28;
                DataTable _dtnames = _objbll.Load_CasTestNames(_objcas, _objdb);
                var TestNames = from _data in _dtnames.AsEnumerable()
                                select _data;
                foreach (var row in TestNames)
                {
                    _total = 0;
                    DataRow _drow = _dtsummary.NewRow();
                    _drow[0] = row[0].ToString();
                    _devices = 0;
                    _p1 = 0;
                    int idx = 0;
                    decimal _qty = 0;
                    decimal _weighting = 0;
                    if (row[0].ToString() == "Circuit IR Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "CSC" || _data.Field<string>("Cat") == "LASC" || _data.Field<string>("Cat") == "LSC" || _data.Field<string>("Cat") == "SM" || _data.Field<string>("Cat") == "MM" || _data.Field<string>("Cat") == "SC"
                                  select _data;

                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com1"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com1"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                        _weighting = _total * 0.15m;
                    }
                    else if (row[0].ToString() == "Device / Address Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "CSC" || _data.Field<string>("Cat") == "LASC" || _data.Field<string>("Cat") == "LSC" || _data.Field<string>("Cat") == "SM" || _data.Field<string>("Cat") == "MM" || _data.Field<string>("Cat") == "SC"
                                  select _data;
                        decimal _interface = 0;
                        decimal _p2 = 0;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {

                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());

                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();


                        _weighting = _total * 0.6m;
                    }
                    else if (row[0].ToString() == "Sound Level Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "CSC" || _data.Field<string>("Cat") == "LASC" || _data.Field<string>("Cat") == "LSC" || _data.Field<string>("Cat") == "SC"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com4"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com4"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "Interface Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FAL" || _data.Field<string>("Cat") == "FIM" || _data.Field<string>("Cat") == "SOUNDER/STROBE"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com3"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com3"].ToString());
                                if (IsNumeric(_row["devices1"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices1"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                        _weighting = _total * 0.13m;
                    }
                    else if (row[0].ToString() == "Fire Telephone Test")
                    {
                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FTU"
                                  select _data;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com2"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com2"].ToString());
                                if (IsNumeric(_row["devices2"].ToString()) == true)
                                    _devices += Convert.ToInt32(_row["devices2"].ToString());
                            }
                        }
                        _drow[1] = Decimal.Round(_devices).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                        _weighting = _total * 0.13m;
                    }

                    else if (row[0].ToString() == "Battery Autonomy Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "SSR" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com5"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com5"].ToString());
                                _panel += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                        _weighting = _total * 0.03m;

                    }
                    else if (row[0].ToString() == "Graphic Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAVA" || _data.Field<string>("Cat") == "FTP"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com6"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com6"].ToString());
                                _panel += 1;
                            }

                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();


                        _weighting = _total * 0.02m;
                    }
                    else if (row[0].ToString() == "C&E Test")
                    {

                        _result = from _data in _dtresult.AsEnumerable()
                                  where _data.Field<string>("Cat") == "FACP" || _data.Field<string>("Cat") == "PAVA"
                                  select _data;
                        int _panel = 0;
                        foreach (var _row in _result)
                        {
                            if (Convert.ToDecimal(_row["per_com7"].ToString()) != -1)
                            {
                                _p1 += Convert.ToDecimal(_row["per_com7"].ToString());
                                _panel += 1;
                            }
                        }
                        _drow[1] = Decimal.Round(_panel).ToString();
                        _drow[2] = Decimal.Round(_p1).ToString();

                        _weighting = _total * 0.05m;

                    }
                    else
                    {
                        _drow[1] = "0";
                        _drow[2] = "0";
                    }

                    if (_drow[1].ToString() != "0")
                    {
                        _total = Decimal.Round((Convert.ToDecimal(_drow[2].ToString()) / Convert.ToDecimal(_drow[1].ToString()) * 100));
                    }

                    _drow[3] = "0";
                    _drow[4] = decimal.Round(_weighting, 0).ToString();
                    _drow[5] = _total.ToString();
                    _drow[6] = row[0].ToString();
                    //if (Convert.ToDecimal(_drow[1].ToString()) > 0)
                    _dtsummary.Rows.Add(_drow);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + ex.Message + "');", true);
            }
        }
    }
}
