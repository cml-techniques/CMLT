using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BusinessLogic;
using App_Properties;
using System.Data;
using CmlTechniques.Models;
using System.IO;

namespace CmlTechniques.Services
{
    /// <summary>
    /// Summary description for LoadData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class LoadData : System.Web.Services.WebService
    {

        [WebMethod]
        public List<CASModel> GetData()
        {
            List<CASModel> docLog = new List<CASModel>();

            string prj = Context.Request.QueryString["prj"].ToString();
            //DataTable dt = GetMVCableData();

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "db_" + prj;
            DataTable dt = _objbll.LoadDataTable("LoadMVCableLog", _objdb);

            foreach (DataRow dr in dt.Rows)
            {
                CASModel cableTestData = new CASModel();
                cableTestData.documentId = Convert.ToInt32(dr["doc_id"].ToString());
                cableTestData.cableReference = dr["cable_reference"].ToString();
                cableTestData.panelReference = dr["panel_reference"].ToString();
                cableTestData.fedFrom = dr["fed_from"].ToString();
                cableTestData.powerTo = dr["power_to"].ToString();
                cableTestData.documentName = dr["document_name"].ToString();

                docLog.Add(cableTestData);
            }
            return docLog;
        }

        [WebMethod]
        public void SaveLog(string id, string cr, string pr, string ff, string pt, string doc, string preVer, string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + prj;
            _clscassheet _objcls = new _clscassheet();
            _objcls.cas_id = Convert.ToInt32(id);
            _objcls.reff = cr;
            _objcls.panel_ref = pr;
            _objcls.fed_from = ff;
            _objcls.p_power_to = pt;
            _objcls.p10 = doc;
            _objcls.uid = "";
            _objbll.SaveCableLog(_objcls, _objdb);
            if(doc != preVer)
            {
                string dirFullPath = HttpContext.Current.Server.MapPath("..//CMS_DOCS//") + prj + "\\CableLog\\" + preVer;

                if (File.Exists(dirFullPath))
                {
                    File.Delete(dirFullPath);
                }
            }            
        }


        [WebMethod]
        public void DeleteLog(string ids, string pdfs, string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + prj;
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_name = ids;           
            _objbll.DeleteDocuments("DeleteCableLog",_objcls, _objdb);

            string[] docs = pdfs.Split(',');
            string dirFullPath = HttpContext.Current.Server.MapPath("..//CMS_DOCS//") + prj + "\\CableLog\\";

            foreach (string pdf in docs)
            {                
                if (File.Exists(dirFullPath + pdf.Trim()))
                {
                    File.Delete(dirFullPath + pdf);
                }
            }
        }
        
    }
}
