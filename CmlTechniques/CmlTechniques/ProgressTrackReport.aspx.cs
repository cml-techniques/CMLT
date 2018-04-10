using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App_Properties;
using BusinessLogic;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
namespace CMLTechQ.DMS
{
    public partial class ProgressTrackReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //lbluseridhidden.Text = Request.QueryString["Auth1"].ToString();
                //lblprjid.Text = Request.QueryString["Auth2"].ToString();

             

                Get_ProjectInfo();

                GenerateReport();

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
        private void Get_ProjectInfo()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clsproject _objcls = new _clsproject();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _objcls.prj_id = 7;
            DataTable _dt = _objbll.Get_ProjectInformation(_objcls, _objdb);
            lblprj.Text = _dt.Rows[0].ItemArray[0].ToString();
        }
        private void GenerateReport()
        {

            DataSet _ds = new DataSet();

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.project_code = lblprj.Text;


            DataTable _dt = new DataTable();
         

            ReportDocument cryRpt = new ReportDocument();

            if (lblprjid.Text != "50")
            {
                DataTable _dt1 = new DataTable();
                _clsuser _objcls1 = new _clsuser();
                _objcls1.project_code = lblprj.Text; ;

                _dt = _objbll.load_ProgressTrackingsheet(_objcls, _objdb);
                _dt1 = _objbll.Get_Project_Logo(_objcls1, _objdb);



                //_dt.TableName = "ProgressTrackingReport";

                //_dt.WriteXmlSchema(Server.MapPath("") + "\\ProgressTrackingReport.xml");


                //_dt1.TableName = "ProjectLogo";

                //_dt1.WriteXmlSchema(Server.MapPath("") + "\\ProjectLogo.xml");

                if (lblprjid.Text == "57")
                {
                    cryRpt.Load(Server.MapPath("ProgressTrackingReport_Mc12.rpt"));
                }
                else {
                    cryRpt.Load(Server.MapPath("ProgressTrackingReport.rpt"));
                }

                cryRpt.Database.Tables[1].SetDataSource(_dt1);

            }

            else
            {
                _dt = _objbll.load_ProgressTrackingsheet1(_objcls, _objdb);
                cryRpt.Load(Server.MapPath("ProgressTrackingReport_Oph.rpt"));
            }

            cryRpt.Database.Tables[0].SetDataSource(_dt);

            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.Zoom(90);
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
            CrystalReportViewer1.RefreshReport();


        }
        }
    }