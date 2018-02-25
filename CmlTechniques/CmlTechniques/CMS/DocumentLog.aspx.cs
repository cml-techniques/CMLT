using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CmlTechniques.Models;
using System.Web.Services;
using System.Web.Script.Services;
using BusinessLogic;
using App_Properties;
using System.Data;

namespace CmlTechniques.CMS
{
    public partial class DocumentLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            {
                string _prm = Request.QueryString[0].ToString();
                _prm = _prm.Replace("<>", "&");
                Session["Fold_cms"] = _prm.Substring(0, _prm.IndexOf("_M"));
                Session["M_id_cms"] = _prm.Substring(_prm.IndexOf("_M") + 2, _prm.IndexOf("_N") - (_prm.IndexOf("_M") + 2));
                Session["M_na_cms"] = _prm.Substring(_prm.IndexOf("_N") + 2, _prm.IndexOf("_P") - (_prm.IndexOf("_N") + 2));
                lblProjectCode.Value = _prm.Substring(_prm.IndexOf("_P") + 2);
                lblModuleName.Text = (string)Session["M_na_cms"];
                SetProjectName();
            }
        }
        private void SetProjectName()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblProjectCode.Value;
            prj.Text = _objbll.Get_ProjectName(_objcls, _objdb);
        }
        //[WebMethod]
        //public static List<CASModel> GetData(string projectCode)
        //{
        //    List<CASModel> docLog = new List<CASModel>();


        //    //DataTable dt = GetMVCableData();

        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();
        //    _objdb.DBName = "db_" + projectCode;
        //    DataTable dt = _objbll.LoadDataTable("LoadMVCableLog", _objdb);

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        CASModel cableTestData = new CASModel();
        //        cableTestData.documentId = Convert.ToInt32(dr["doc_id"].ToString());
        //        cableTestData.cableReference = dr["cable_reference"].ToString();
        //        cableTestData.panelReference = dr["panel_reference"].ToString();
        //        cableTestData.fedFrom = dr["fed_from"].ToString();
        //        cableTestData.powerTo = dr["power_to"].ToString();
        //        cableTestData.documentName = dr["document_name"].ToString();

        //        docLog.Add(cableTestData);
        //    }
        //    return docLog;
        //}




        //[WebMethod]
        //public static List<CASModel> SaveLog(string id,string cr, string pr, string ff, string pt, string doc, string prj)
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();
        //    _objdb.DBName = "DB_" + prj;
        //    _clscassheet _objcls = new _clscassheet();
        //    _objcls.cas_id = Convert.ToInt32(id);
        //    _objcls.reff = cr;
        //    _objcls.panel_ref = pr;
        //    _objcls.fed_from = ff;
        //    _objcls.p_power_to = pt;
        //    _objcls.p10 = doc;
        //    _objcls.uid = "";
        //    DataTable dt = _objbll.SaveCableLog(_objcls, _objdb);

        //    List<CASModel> docLog = new List<CASModel>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        CASModel cableTestData = new CASModel();
        //        cableTestData.documentId = Convert.ToInt32(dr["doc_id"].ToString());
        //        cableTestData.cableReference = dr["cable_reference"].ToString();
        //        cableTestData.panelReference = dr["panel_reference"].ToString();
        //        cableTestData.fedFrom = dr["fed_from"].ToString();
        //        cableTestData.powerTo = dr["power_to"].ToString();
        //        cableTestData.documentName = dr["document_name"].ToString();

        //        docLog.Add(cableTestData);
        //    }
        //    return docLog;
        //}
        
        //private DataTable GetMVCableData()
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database();           
        //    _objdb.DBName = "db_HMIM";
        //    DataTable dt = _objbll.LoadDataTable("LoadTestDocumentLog", _objdb);
        //    return dt;
        //}
    }
}