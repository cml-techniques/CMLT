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

namespace CmlTechniques
{
    public partial class DMSReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _prm = Request.QueryString[0].ToString();
                lblprj.Text = _prm;
                loadfolderList();
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            Session["srv"] = ddlFolderlist.SelectedItem.Text;
            Session["folderId"] = ddlFolderlist.SelectedValue;
            Insert_ReportData();
            Generate_Reports();

        }
        
        void loadfolderList()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            //_clsproject _objcls = new _clsproject();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "dbCML";
            _objcls.project_code = lblprj.Text;
            DataTable _dt = _objbll.Load_TreeFolder_Parent(_objcls, _objdb);
            ddlFolderlist.DataSource = _dt;
            ddlFolderlist.DataTextField = _dt.Columns["folder_description"].ToString();
            ddlFolderlist.DataValueField = _dt.Columns["Folder_id"].ToString();
            ddlFolderlist.DataBind();
        }
        private void Insert_ReportData()
        {
            //int folderId;
            //folderId = Convert.ToInt16(ddlFolderlist.SelectedValue);


            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsdocument _objcls = new _clsdocument();
            _objdb.DBName = "DBCML";
            _clsproject _objcls1 = new _clsproject();
            _objcls1.prjcode = lblprj.Text;
            _objbll.Update_RPTLogo(_objcls1, _objdb);
            _objbll.Clear_DBMSSummary(_objdb);

            DataTable _dtable = _objbll.Load_DBMSStatus(_objdb);
            var _status = from _data in _dtable.AsEnumerable()
                          select _data;
            foreach (var row in _status)
            {
                _objcls.folder_id = Convert.ToInt16(Session["folderId"]);
                _objcls.project_code = lblprj.Text;
                _objcls.status = row[0].ToString();
                _objbll.Generate_DBMS_Summary_ALL(_objcls, _objdb);
            }
            _objcls.folder_id = Convert.ToInt16(Session["folderId"]);
            _objcls.status = "1";
            _objcls.project_code = lblprj.Text;
            _objbll.Generate_DBMS_Summary_ALL(_objcls, _objdb);
           // parm = "ms_" + GetDocNo_All();

        }
        private string GetDocNo_All()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _clstreefolder _objcls = new _clstreefolder();
            _objcls.Project_code = (string)Session["project"];
            _objcls.Folder_id = Convert.ToInt16(Session["folderId"]);
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            return _objbll.Get_DBMsDoc_No_All(_objcls, _objdb);
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
            cryRpt.Load(Server.MapPath("dbms_summary.rpt"));
            crConnectionInfo.ServerName = "37.61.235.103";
            crConnectionInfo.DatabaseName = "DBCML";
            crConnectionInfo.UserID = "sa";
            crConnectionInfo.Password = "vCr6wgu3";
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            //string _parm = Request.QueryString[0].ToString();
            string _parm = "ms_" + GetDocNo_All();

            string _nos = _parm.Substring(3);
            string _type = _parm.Substring(0, 2);
            cryRpt.SetParameterValue("srv", (string)Session["srv"]);
            cryRpt.SetParameterValue("project", (string)Session["projectname"]);
            cryRpt.SetParameterValue("total", _nos);
            cryRpt.SetParameterValue("type", _type);
            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.DataBind();
            Session["Report"] = cryRpt;
        }
        private void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Report"] = null;
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
    }
}
