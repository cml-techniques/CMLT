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
    public partial class ReportsNew : System.Web.UI.Page
    {
        ReportDocument cryRpt = new ReportDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Page_Unload(object sender, EventArgs e)
        {
                //cryRpt.Dispose();
                //cryRpt.Close();
        }
        private void GenerateReport(string _type)
        {
            
            DataSet _ds = new DataSet();
            DataTable _dt=new DataTable();
            //_ds.WriteXmlSchema(Server.MapPath("") + "\\bsummary.xml");
            
            
            if (_type == "8")
            {
                if (lblsch.Text == "1")
                {
                   
                    _dt = GetRptData("8_1_3");
                    _ds.Tables.Add(_dt);
                    //_ds.WriteXmlSchema(Server.MapPath("") + "\\bs2.xml");
                    _dt = GetRptData("8_1_6");
                    _ds.Tables.Add(_dt);
                    //_ds.WriteXmlSchema(Server.MapPath("") + "\\bs6.xml");
                    _dt = GetRptData("8_1_5");
                    _ds.Tables.Add(_dt);
                    //_ds.WriteXmlSchema(Server.MapPath("") + "\\bs5.xml");
                    _dt = GetRptData("8_1_7");
                    _ds.Tables.Add(_dt);
                    //_ds.WriteXmlSchema(Server.MapPath("") + "\\bs7.xml");
                    //if (lbldiv.Text == "3")
                    //{
                        _dt = GetRptData("8_1_2");
                        _ds.Tables.Add(_dt);
                        //_ds.WriteXmlSchema(Server.MapPath("") + "\\bs.xml");
                    //}
                        cryRpt.Load(Server.MapPath("bs1.rpt"));
                        cryRpt.Subreports[0].Database.Tables[0].SetDataSource(_ds.Tables[0]);
                        cryRpt.Subreports[1].Database.Tables[0].SetDataSource(_ds.Tables[4]);
                        cryRpt.Subreports[2].Database.Tables[0].SetDataSource(_ds.Tables[1]);
                        cryRpt.Subreports[3].Database.Tables[0].SetDataSource(_ds.Tables[2]);
                        cryRpt.Subreports[4].Database.Tables[0].SetDataSource(_ds.Tables[3]);
                        cryRpt.SetParameterValue(0, lbldiv.Text);
                }
                else if (lblsch.Text == "3")
                {

                    _dt = GetRptData("8_3_20");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_3_10");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_3_11");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_3_12");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_3_14");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_3_16");
                    _ds.Tables.Add(_dt);
                    cryRpt.Load(Server.MapPath("bs3.rpt"));
                    cryRpt.Subreports[0].Database.Tables[0].SetDataSource(_ds.Tables[0]);
                    cryRpt.Subreports[1].Database.Tables[0].SetDataSource(_ds.Tables[1]);
                    cryRpt.Subreports[2].Database.Tables[0].SetDataSource(_ds.Tables[2]);
                    cryRpt.Subreports[3].Database.Tables[0].SetDataSource(_ds.Tables[3]);
                    cryRpt.Subreports[4].Database.Tables[0].SetDataSource(_ds.Tables[4]);
                    cryRpt.Subreports[5].Database.Tables[0].SetDataSource(_ds.Tables[5]);
                    cryRpt.SetParameterValue(0, lbldiv.Text);
                }
                else if (lblsch.Text == "2")
                {

                    _dt = GetRptData("8_2_8");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_2_21");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_2_9");
                    _ds.Tables.Add(_dt);
                    cryRpt.Load(Server.MapPath("bs2.rpt"));
                    cryRpt.Subreports[0].Database.Tables[0].SetDataSource(_ds.Tables[0]);
                    cryRpt.Subreports[1].Database.Tables[0].SetDataSource(_ds.Tables[2]);
                    cryRpt.Subreports[2].Database.Tables[0].SetDataSource(_ds.Tables[1]);
                    cryRpt.SetParameterValue(0, lbldiv.Text);
                }
                else if (lblsch.Text == "4")
                {

                    _dt = GetRptData("8_4_17");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_4_18");
                    _ds.Tables.Add(_dt);
                    _dt = GetRptData("8_4_19");
                    _ds.Tables.Add(_dt);
                    cryRpt.Load(Server.MapPath("bs4.rpt"));
                    cryRpt.Subreports[0].Database.Tables[0].SetDataSource(_ds.Tables[0]);
                    cryRpt.Subreports[1].Database.Tables[0].SetDataSource(_ds.Tables[1]);
                    cryRpt.Subreports[2].Database.Tables[0].SetDataSource(_ds.Tables[2]);
                    cryRpt.SetParameterValue(0, lbldiv.Text);
                }
                //cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
               
            }
            else if (_type == "3" || _type == "7")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("BAreaSummary1.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue(0, lbldiv.Text);
                
            }
            else if (_type == "23")
            {

                //DataSet _ds = new DataSet();
                //DataTable _dt = GetRptData(_type);
                //DataTable _dt1 = loadSummary();

                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);

                DataTable _dt1 = loadSummary();

                // _ds.Tables.Add(_dt);
                _ds.Tables.Add(_dt1);


                cryRpt.Load(Server.MapPath("cas_bc_p.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.Subreports[0].Database.Tables[0].SetDataSource(_ds.Tables[1]);



                cryRpt.SetParameterValue(0, lblzone.Text);
                cryRpt.SetParameterValue(1, lblcat.Text);
                cryRpt.SetParameterValue(2, lblfl.Text);
                cryRpt.SetParameterValue(3, lblfd.Text);
                cryRpt.SetParameterValue(0, lbldiv.Text);
            }
            else if (_type == "pc")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                //_ds.WriteXmlSchema(Server.MapPath("") + "\\pclist.xml");

                cryRpt.Load(Server.MapPath("pilecapslist.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
            }
            else if (_type == "uso")
            {
                _dt = (DataTable)Session["dtsoreport"];
                _ds.Tables.Add(_dt);

                cryRpt.Load(Server.MapPath("csnag.rpt"));

                  cryRpt.Database.Tables["Comm_snag"].SetDataSource(_ds.Tables[0]);


                  cryRpt.SetParameterValue("SubmitDate", (string)Session["SubmitDate"]);
                  cryRpt.SetParameterValue("ActionBy", (string)Session["ActionBy"]);
                  cryRpt.SetParameterValue("Discipline", (string)Session["Discipline"]);
                  cryRpt.SetParameterValue("Building", (string)Session["Building"]);
                  cryRpt.SetParameterValue("CompDate", (string)Session["CompDate"]);


            }
            else if (_type == "csp")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 9);
            }
            else if (_type == "csp5")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 5);
            }
            else if (_type == "csp8")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 8);
            }
            else if (_type == "csp17")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 17);
            }
            else if (_type == "csp10")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 10);
            }
            else if (_type == "csp6")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 6);
            }
            else if (_type == "csp4")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 4);
            }
            else if (_type == "csp7")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 7);
            }
            else if (_type == "csp18")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 18);
            }
            else if (_type == "csp19")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 19);
            }
            else if (_type == "csp20")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 20);
            }
            else if (_type == "csp15")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 15);
            }
            else if (_type == "csp21")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 21);
            }
            else if (_type == "csp13")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 13);
            }
            else if (_type == "csp11")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 11);
            }
            else if (_type == "csp12")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 12);
            }
            else if (_type == "csp26")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 26);
            }
            else if (_type == "csp22")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 22);
            }
            else if (_type == "csp27")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 27);
            }
            else if (_type == "csp16")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 16);
            }
            else if (_type == "csp25")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 25);
            }
            else if (_type == "csp24")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 24);
            }
            else if (_type == "csp28")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("comprogress.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue("id", 28);
            }
            else if (_type == "25")
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);

                cryRpt.Load(Server.MapPath("BuildingSummary_HMIM.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
            }
            else
            {
                _dt = GetRptData(_type);
                _ds.Tables.Add(_dt);
                cryRpt.Load(Server.MapPath("BAreaSummary.rpt"));
                cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
                cryRpt.SetParameterValue(0, lbldiv.Text);
            }
            //cryRpt.Database.Tables[0].SetDataSource(_ds.Tables[0]);
            
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
            //cryRpt.Dispose();
        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString[0].ToString();
                if (lblprj.Text != "OPH" && lblprj.Text != "PCD")
                {
                    lbldiv.Text = Request.QueryString[1].ToString();
                    string _type = Request.QueryString[2].ToString();
                    lblsch.Text = Request.QueryString[3].ToString();
                    if (_type != "pc")
                    {
                        if (lblsch.Text == "23")
                        {
                            lblzone.Text = Request.QueryString["Zone"].ToString();
                            lblfl.Text = Request.QueryString["Fl"].ToString();
                            lblfd.Text = Request.QueryString["Fd"].ToString();
                            lblcat.Text = Request.QueryString["Cat"].ToString();
                        }
                    }
                    GenerateReport(_type);
                }
                else
                {
                    string _sch = Request.QueryString["sch"].ToString();
                    if (_sch == "9")
                        GenerateReport("csp");
                    else if (_sch == "5")
                        GenerateReport("csp5");
                    else if (_sch == "8")
                        GenerateReport("csp8");
                    else if(_sch=="17")
                        GenerateReport("csp17");
                    else if (_sch == "10")
                        GenerateReport("csp10");
                    else if (_sch == "6")
                        GenerateReport("csp6");
                    else if (_sch == "4")
                        GenerateReport("csp4");
                    else if (_sch == "7")
                        GenerateReport("csp7");
                    else if (_sch == "18")
                        GenerateReport("csp18");
                    else if (_sch == "19")
                        GenerateReport("csp19");
                    else if (_sch == "20")
                        GenerateReport("csp20");
                    else if (_sch == "15")
                        GenerateReport("csp15");
                    else if (_sch == "21")
                        GenerateReport("csp21");
                    else if (_sch == "13")
                        GenerateReport("csp13");
                    else if (_sch == "11")
                        GenerateReport("csp11");
                    else if (_sch == "12")
                        GenerateReport("csp12");
                    else if (_sch == "26")
                        GenerateReport("csp26");
                    else if (_sch == "22")
                        GenerateReport("csp22");
                    else if (_sch == "27")
                        GenerateReport("csp27");
                    else if (_sch == "16")
                        GenerateReport("csp16");
                    else if (_sch == "25")
                        GenerateReport("csp25");
                    else if (_sch == "24")
                        GenerateReport("csp24");
                    else if (_sch == "28")
                        GenerateReport("csp28");
                }
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
        private DataTable loadSummary()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + lblprj.Text;
            _clscassheet _objcls = new _clscassheet();

            _objcls.c_s_id = Convert.ToInt32(lblsch.Text);
            _objcls.build_id = Convert.ToInt32(lbldiv.Text);

            return _objbll.Generate_Package_Summary(_objcls, _objdb);

            // _ds.WriteXmlSchema(Server.MapPath("") + "\\barea1.xml");


        }
        private DataTable GetRptData( string _type)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clscassheet _objcls = new _clscassheet();
            _objdb.DBName = "DB_" + lblprj.Text;
            if (_type == "1")
                return _objbll.GENERATE_DIV_SUMMARY(_objdb);
            else if (_type == "2")
            {
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_BAREA_SUMMARY(_objcls, _objdb);
            }
            else if (_type == "4")
            {
                lbldiv.Text = "01";
                return _objbll.GENERATE_DIV_SUMMARY_PRJ( _objdb);
            }
            else if (_type == "5")
            {
                _objcls.srv = Convert.ToInt32(lbldiv.Text);
                lbldiv.Text = "02";
                return _objbll.GENERATE_DIV_SER_SUMMARY(_objcls,_objdb);
            }
            else if (_type == "3")
            {
                _objcls.srv = Convert.ToInt32(lblsch.Text);
                //_objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_CAS_PKG_SUMMARY(_objcls, _objdb);
            }
            else if (_type == "6")
            {
                lbldiv.Text = "03";
                return _objbll.GENERATE_OVERALL_SUMMARY_BLDG( _objdb);
            }
            else if (_type == "6_1")
            {
                lbldiv.Text = "03";
                return _objbll.GENERATE_OVERALL_SUMMARY_BLDG1(_objdb);
            }
            else if (_type == "6_2")
            {
                lbldiv.Text = "03";
                return _objbll.GENERATE_OVERALL_SUMMARY_BLDG2(_objdb);
            }
            else if (_type == "6_3")
            {
                lbldiv.Text = "03";
                return _objbll.GENERATE_OVERALL_SUMMARY_BLDG3(_objdb);
            }
            else if (_type == "7")
            {
                _objcls.sch = Convert.ToInt32(lblsch.Text);
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY(_objcls, _objdb);
            }
            else if (_type == "8_1_3")
            {
                _objcls.sch = 3;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_3", _objcls, _objdb);
            }
            else if (_type == "8_1_6")
            {
                _objcls.sch = 6;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_6", _objcls, _objdb);
            }
            else if (_type == "8_1_5")
            {
                _objcls.sch = 5;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_5", _objcls, _objdb);
            }
            else if (_type == "8_1_7")
            {
                _objcls.sch = 7;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_7", _objcls, _objdb);
            }
            else if (_type == "8_1_2")
            {
                _objcls.sch = 2;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_2", _objcls, _objdb);
            }
            else if (_type == "8_3_20")
            {
                _objcls.sch = 20;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_20", _objcls, _objdb);
            }
            else if (_type == "8_3_10")
            {
                _objcls.sch = 10;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_10", _objcls, _objdb);
            }
            else if (_type == "8_3_11")
            {
                _objcls.sch = 11;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_11", _objcls, _objdb);
            }
            else if (_type == "8_3_12")
            {
                _objcls.sch = 12;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_12", _objcls, _objdb);
            }
            else if (_type == "8_3_14")
            {
                _objcls.sch = 14;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_14", _objcls, _objdb);
            }
            else if (_type == "8_3_16")
            {
                _objcls.sch = 16;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_16", _objcls, _objdb);
            }
            else if (_type == "8_2_8")
            {
                _objcls.sch = 8;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_8", _objcls, _objdb);
            }
            else if (_type == "8_2_21")
            {
                _objcls.sch = 21;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_21", _objcls, _objdb);
            }
            else if (_type == "8_2_9")
            {
                _objcls.sch = 9;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_9", _objcls, _objdb);
            }
            else if (_type == "8_4_17")
            {
                _objcls.sch = 17;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_17", _objcls, _objdb);
            }
            else if (_type == "8_4_18")
            {
                _objcls.sch = 18;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_18", _objcls, _objdb);
            }
            else if (_type == "8_4_19")
            {
                _objcls.sch = 19;
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);
                return _objbll.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY1_19", _objcls, _objdb);
            }
            else if (_type == "23")
            {
                _objcls.c_s_id = Convert.ToInt32(lblsch.Text);
                _objcls.build_id = Convert.ToInt32(lbldiv.Text);

                _objcls.b_zone = lblzone.Text;
                _objcls.cate = lblcat.Text;
                _objcls.f_level = lblfl.Text;
                _objcls.fed_from = lblfd.Text;
                return _objbll.Generate_Cassheet_Report(_objcls, _objdb);
            }
            else if (_type == "pc")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 25;
                _objcas.prj_code = lblprj.Text;
                return _objbll.Load_casMain_Edit(_objcas, _objdb);
            }
            else if (_type == "csp")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 9;
                return _objbll.Generate_Commissioning_Summary(_objcas, _objdb);
            }
            else if (_type == "csp5")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 5;
                return _objbll.Generate_Commissioning_Summary_LV(_objcas, _objdb);
            }
            else if (_type == "csp8")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 8;
                return _objbll.Generate_Commissioning_Summary_ME(_objcas, _objdb);
            }
            else if (_type == "csp17")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 17;
                return _objbll.Generate_Commissioning_Summary_PH(_objcas, _objdb);
            }
            else if (_type == "csp10")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 10;
                return _objbll.Generate_Commissioning_Summary_FAS(_objcas, _objdb);
            }
            else if (_type == "csp6")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 6;
                return _objbll.Generate_Commissioning_Summary_ELP(_objcas, _objdb);
            }
            else if (_type == "csp4")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 4;
                return _objbll.Generate_Commissioning_Summary_Gen(_objcas, _objdb);
            }
            else if (_type == "csp7")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 7;
                return _objbll.Generate_Commissioning_Summary_Emg(_objcas, _objdb);
            }
            else if (_type == "csp18")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 18;
                return _objbll.Generate_Commissioning_Summary_ph2(_objcas, _objdb);
            }
            else if (_type == "csp19")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 19;
                return _objbll.Generate_Commissioning_Summary_ph3(_objcas, _objdb);
            }
            else if (_type == "csp20")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 20;
                return _objbll.Generate_Commissioning_Summary_bms(_objcas, _objdb);
            }
            else if (_type == "csp15")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 15;
                return _objbll.Generate_Commissioning_Summary_Vesda(_objcas, _objdb);
            }
            else if (_type == "csp21")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 21;
                return _objbll.Generate_Commissioning_Summary_Flush(_objcas, _objdb);
            }
            else if (_type == "csp13")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 13;
                return _objbll.Generate_Commissioning_Summary_cctv(_objcas, _objdb);
            }
            else if (_type == "csp11")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 11;
                return _objbll.Generate_Commissioning_Summary_LCS(_objcas, _objdb);
            }
            else if (_type == "csp12")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 12;
                return _objbll.Generate_Commissioning_Summary_SCN(_objcas, _objdb);
            }
            else if (_type == "csp26")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 26;
                return _objbll.Generate_Commissioning_Summary_LDS(_objcas, _objdb);
            }
            else if (_type == "csp22")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 22;
                return _objbll.Generate_Commissioning_Summary_Acs(_objcas, _objdb);
            }
            else if (_type == "csp27")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 27;
                return _objbll.Generate_Commissioning_Summary_PAVA(_objcas, _objdb);
            }
            else if (_type == "csp16")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 16;
                return _objbll.Generate_Commissioning_Summary_ELV(_objcas, _objdb);
            }
            else if (_type == "csp25")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 25;
                return _objbll.Generate_Commissioning_Summary_IST(_objcas, _objdb);
            }
            else if (_type == "csp24")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 24;
                return _objbll.Generate_Commissioning_Summary_KLE(_objcas, _objdb);
            }
            else if (_type == "csp28")
            {
                _clscassheet _objcas = new _clscassheet();
                _objcas.sch = 28;
                return _objbll.Generate_Commissioning_Summary_HVTS(_objcas, _objdb);
            }
            else if (_type == "25")
            {
                return _objbll.GENERATE_CAS_BUILDNG_SUMMARY( _objdb);
            }
            return null;
        }
    }
}
