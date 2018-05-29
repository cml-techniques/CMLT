using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using App_Properties;
using DataLinkLibrary;

namespace BusinessLogic
{
    
    public class BLL_Dml
    {
        DLL_Dml _objDLL = new DLL_Dml();

        public void _chngPwd(_clsuser _obj, _database _objdb)
        {
            _objDLL._chngPwd("ChangePassword", _obj,_objdb);
        }
        public bool _validUser(_clsuser _obj, _database _objdb)
        {
            return _objDLL._validUser("ChkUserLogin", _obj,_objdb);
        }
        public string getUserGroup(_clsuser _obj, _database _objdb)
        {
            return _objDLL._getUserGroup("getUserGroup", _obj,_objdb);
        }
        public DataTable load_service(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_service("loadservice",_obj,_objdb);
        }
        public DataTable load_package(_database _objdb)
        {
            return _objDLL.load_master("loadpackage",_objdb);
        }
      
        public DataTable load_doctype(_database _objdb)
        {
            return _objDLL.load_master("loaddoctype",_objdb);
        }
     
        public DataTable load_subgroup(_database _objdb)
        {
            return _objDLL.load_master("loadsubgroup",_objdb);
        }
        public DataTable load_subgroup1(_database _objdb)
        {
            return _objDLL.load_master("loadsubgroup1",_objdb);
        }
        public DataTable load_group(_database _objdb)
        {
            return _objDLL.load_master("loadgroup",_objdb);
        }
        public DataTable load_project(_database _objdb)
        {
            return _objDLL.load_master("LoadProject",_objdb);
        }
        public DataTable load_document(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.load_document("loaddocuments",_obj,_objdb);
        }
        public void addcomment(_clscomment _obj, _database _objdb)
        {
            _objDLL.addcomment("addcomment", _obj,_objdb);
        }
      
        public DataTable load_comments(_clsdocument _obj, _database _objdb)
        {
           return _objDLL.load_comments("loadcomments", _obj,_objdb);
        }
     
        public void addtobasket(_clscomment _obj, _database _objdb)
        {
            _objDLL.addtobasket("addtocommentbasket", _obj,_objdb);
        }
       
        public DataTable load_schedule(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master ("LoadSchedule",_obj,_objdb);
        }
        public void file_upload(_clsdocument _obj, _database _objdb)
        {
            _objDLL.file_upload("FileUploading", _obj,_objdb);
        }
        public void _projectmaster(_clsproject _obj, _database _objdb)
        {
            _objDLL._projectmaster("CreateProject", _obj,_objdb);
        }
        public void Create_Schedule(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Create_Schedule("CreateSchedule", _obj,_objdb);
        }
        public void Create_user(_clsuser _obj, _database _objdb)
        {
            _objDLL.Create_user("CreateUser",_obj,_objdb);
        }
     
        public void Create_TreeFolder(_clstreefolder _obj, _database _objdb)
        {
            _objDLL.Tree_Folder("Create_Treefolder", _obj,_objdb);
        }
        public void Edit_Tree_Folder(_clstreefolder _obj, _database _objdb)
        {
            _objDLL.Edit_Tree_Folder("Edit_TreeFolder", _obj,_objdb);
        }
        public void Move_Tree_Folder(_clstreefolder _obj, _database _objdb)
        {
            _objDLL.Move_Tree_Folder("Move_TreeFolder", _obj,_objdb);
        }
        public void Create_Manufacture(_clsmanufacture _obj, _database _objdb)
        {
            _objDLL.Create_Manufacture("CreateManufacture", _obj,_objdb);
        }
        public DataTable load_manufacturer(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master("LoadManufacture", _obj,_objdb);
        }
      
        public void Move_document(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Move_document("Manage_document", _obj,_objdb);
        }
        public DataTable load_projecthome(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_projecthome("load_projecthome", _obj,_objdb);
        }
        public void SetDocDuration(_clsdocduration _obj, _database _objdb)
        {
            _objDLL.SetDocDuration("SetDocDuration", _obj,_objdb);
        }
        public DataTable load_User(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master("LoadUsers", _obj,_objdb);
        }
        public DataTable load_usersrv(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_usersrv("LoadUser_Services", _obj,_objdb);
        }
        public DataTable LoadDocDatails(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.LoadDocDatails("LoadDocumentDetails", _obj,_objdb);
        }
        public void SetDocStatus(_clsdocument _obj, _database _objdb)
        {
            _objDLL.SetDocStatus("SetDocStatus", _obj,_objdb);
        }
      
        public string GetAutoPassword(_clsuser _obj, _database _objdb)
        {
            return _objDLL.GetAutoPassword("GetAutoPassword", _obj,_objdb);
        }
        public DataTable load_RptOMmanual(_clsuser _obj, _database _objdb)
        {
            //return _objDLL.Load_Reports("ReportOMManual",_obj );
            return _objDLL.load_master("ReportOMManual", _obj,_objdb);
        }
        public void Insert_UserPrj(_clsuser _obj, _database _objdb)
        {
            _objDLL.Insert_UserPrj("Insert_UserPrj_Tbl", _obj,_objdb);
        }
        public void Edit_Access(_clsuser _obj, _database _objdb)
        {
            _objDLL.Edit_Access("EditUserAccess", _obj,_objdb);
        }
        public void Insert_UserService(_clsuser _obj, _database _objdb)
        {
            _objDLL.Insert_UserService("Set_UserService", _obj,_objdb);
        }
        public void Delete_Doc(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Delete_Doc("Delete_Document", _obj,_objdb);
        }
        public void Create_Contractor(_clsmanufacture _obj, _database _objdb)
        {
            _objDLL.Create_Contractor("CreateContractor", _obj,_objdb);
        }
        public DataTable load_Contractor(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master("LoadContractor", _obj,_objdb);
        }
        public DataTable Load_DocDatails(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_DocDatails("Load_OMManualDetailsRPT", _obj,_objdb);
        }
        public DataTable load_documentsALL(_database _objdb)
        {
            return _objDLL.load_master("loaddocumentsALL",_objdb);
        }
        public DataTable Doc_Summary_Rpt(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master("Doc_Summary_Report", _obj,_objdb);
        }
        public DataTable Load_Doc_Dur(_database _objdb)
        {
            return _objDLL.load_master("Load_Doc_Dur",_objdb);
        }
        public void Set_Reminder(_clsdocduration _obj, _database _objdb)
        {
            _objDLL.Set_Reminder("SetReminder", _obj,_objdb);
        }
        public int Get_ManualID(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_ManualID("Get_DocId", _obj,_objdb);
        }
        public void add_resp(_clscomment _obj, _database _objdb)
        {
            _objDLL.add_resp("ad_resp", _obj,_objdb);
        }
       
        public DataTable Load_cas_sys(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_cas_sys("load_cms_cas_sys", _obj,_objdb);
        }
        public string LoadCASHeader(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.LoadCASHeader("LoadCASHeader", _obj, _objdb);
        }
      
        public void add_asset_code(_clsassetcode _obj, _database _objdb)
        {
            _objDLL.add_asset_code("add_asset_code", _obj,_objdb);
        }
        public void Edit_asset_code(_clsassetcode _obj, _database _objdb)
        {
            _objDLL.Edit_asset_code("Edit_asset_code", _obj,_objdb);
        }
        public void add_ele_out_cir_test(_cls_ele_testing _obj, _database _objdb)
        {
            _objDLL.add_ele_out_cir_test("add_ele_out_cir_test", _obj,_objdb);
        }
        public void add_ele_pnl_eqi_test(_cls_ele_testing _obj, _database _objdb)
        {
            _objDLL.add_ele_pnl_eqi_test("add_ele_pnl_eqi_test", _obj,_objdb);
        }
        public DataTable Load_casMain(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_casMain("load_casMain", _obj,_objdb);
        }
     
        public void UpdateUserLog(_clslog _obj, _database _objdb)
        {
            _objDLL.UpdateUserLog("UpdateUserLog", _obj, _objdb);
        }
        public DataTable Load_User_Log(_database _objdb)
        {
            return _objDLL.load_master("Load_User_Log",_objdb);
        }
        public void LOG_OUT(_clslog _obj, _database _objdb)
        {
            _objDLL.LOG_OUT("log_off", _obj,_objdb);
        }
        public string CheckOMExist(_clstreefolder _obj, _database _objdb)
        {
            return _objDLL.CheckOMExist("CheckOMExist", _obj,_objdb);
        }
        public void Add_CMS_Document(_clscmsdocument _obj, _database _objdb)
        {
            _objDLL.Add_CMS_Document("Add_CMS_Document", _obj,_objdb);
        }
        public void Add_CMS_Document1(_clscmsdocument _obj, _database _objdb)
        {
            _objDLL.Add_CMS_Document1("Add_CMS_Document", _obj, _objdb);
        }
        public DataTable Load_CMS_Document(_clscmsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_CMS_Docs("Load_CMS_Document", _obj,_objdb);
        }
        public void Add_CMS_Comments(_clscmscomment _obj, _database _objdb)
        {
            _objDLL.Add_CMS_Comments("Add_cms_comments", _obj,_objdb);
        }
      
        public DataTable Load_casMain_Edit(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_casMain_Edit("load_casMain_Edit", _obj,_objdb);
        }
        public void Insert_Cas_Testing(_cls_ele_testing _obj, _database _objdb)
        {
            _objDLL.Insert_Cas_Testing("Insert_Cas_Testing", _obj,_objdb);
        }
        public string ChkUserLoggedIN(_clsuser _obj, _database _objdb)
        {
            return _objDLL.ChkUserLoggedIN("ChkUserLoggedIN", _obj,_objdb);
        }
        public string Document_Review_Log(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Document_Review_Log("insert_doc_review_log", _obj, _objdb);
        }
        public DataTable Load_Doc_review_log(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Load_Document_Review_Log("Load_doc_review_log", _obj,_objdb);
        }
        public void Document_Review_Details(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Document_Review_Details("insert_doc_review_details", _obj,_objdb);
        }
        public DataTable Load_Document_Review_Details(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Load_Document_Review_Details("Load_doc_review_details", _obj,_objdb);
        }
        public DataTable load_commentbasket(_clscomment _obj, _database _objdb)
        {
            return _objDLL.load_comment_basket("load_comment_basket", _obj,_objdb);
        }
        public void Remove_basket(_clscomment _obj, _database _objdb)
        {
            _objDLL.Remove_basket("remove_comment_basket", _obj,_objdb);
        }
        public DataTable Load_CMS_Users(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Load_CMSUsers("Load_CMS_Users", _obj, _objdb);
        }
        public DataTable Load_CMS_Users_Email(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Load_CMSUsers("Load_CMS_Users_Email", _obj, _objdb);
        }
       
        public DataTable Load_FolderTree_Cms(_clstreefolder _obj, _database _objdb)
        {
            return _objDLL.Load_FolderTree_Cms("load_cms_TreeFolder", _obj,_objdb);
        }
        public string SO_Dir(_clsSO _obj, _database _objdb)
        {
            return _objDLL.SO_Dir("insert_SO_dir", _obj,_objdb);
        }
        public DataTable Load_so_dir(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master("load_so_dir", _obj,_objdb);
        }
        public void SO_Details(_clsSO _obj, _database _objdb)
        {
            _objDLL.SO_Details("insert_so_details", _obj,_objdb);
        }
        public DataTable Load_SO_Details(_clsSO _obj, _database _objdb)
        {
            return _objDLL.Load_SO_Details("load_so_details", _obj,_objdb);
        }
       
        public DataTable Load_SO_Photo(_clsSO _obj, _database _objdb)
        {
            return _objDLL.Load_SO_Details("load_so_photo", _obj,_objdb);
        }
        public void Cassheet_Master(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Cassheet_Master("insert_Cassheet_master", _obj,_objdb);
        }
        public void Cassheet_update(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Cassheet_update("cassheet_updation", _obj,_objdb);
        }
        public void Cassheet_update1(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Cassheet_update1("cassheet_updation", _obj, _objdb);
        }
       
        public DataTable Load_ALLUsers(_database _objdb)
        {
            return _objDLL.load_master("LoadALLUsers",_objdb);
        }
        public void Set_User_Permission(_clsuser _obj, _database _objdb)
        {
            _objDLL.Set_User_Permission("set_user_permission", _obj,_objdb);
        }
        public DataTable Load_User_Permission(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Load_Details("Load_User_Permission", _obj,_objdb);
        }
        public bool Module_Access(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Module_Access("get_module_access", _obj,_objdb);
        }
      
        public void create_package(_clspackage _obj, _database _objdb)
        {
            _objDLL.create_package("create_package", _obj,_objdb);
        }
        public DataTable Load_Cas_service(_database _objdb)
        {
            return _objDLL.load_master("load_cas_service",_objdb);
        }
        public DataTable Load_Cas_service_drso(_database _objdb)
        {
            return _objDLL.load_master("load_cas_service_drso", _objdb);
        }
     
        public DataTable LOAD_SYS_CMS_CASSHEET(_database _objdb)
        {
            return _objDLL.load_master("LOAD_CMS_SYS_CASSHEETS",_objdb);
        }
        public DataTable LOAD_SYS_SERVICE(_database _objdb)
        {
            return _objDLL.load_master("LOAD_SYS_SERVICE",_objdb);
        }
        public void Config_CMSFolderTree(_clsFolderTree _obj, _database _objdb)
        {
            _objDLL.Config_CMSFolderTree("Config_CMSFolderTree", _obj,_objdb);
        }
        public DataTable Load_Project_CMSFolder(_database _objdb)
        {
            return _objDLL.load_master("Load_Project_CMSFolder",_objdb);
        }
        public DataTable Load_filter_element(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_filter_element("load_FILTER_element", _obj,_objdb);
        }
        public DataTable Filtering(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Filtering("Cassheet_Filtering", _obj,_objdb);
        }
        public DataTable Load_SubFolder(_clsFolderTree _obj, _database _objdb)
        {
            return _objDLL.Load_SubFolder("load_cassheet_folder", _obj,_objdb);
        }
        public DataTable Load_Ms_Systems(_clsMaster _obj, _database _objdb)
        {
            return _objDLL.Load_Ms_Systems("load_ms_systems", _obj, _objdb);
        }
        public void Config_Ms_Schedule(_clsMaster _obj, _database _objdb)
        {
            _objDLL.Config_Ms_Schedule("Config_Ms_Schedule", _obj, _objdb);
        }
       
        public void Config_Prj_Service(_sysconfig _obj, _database _objdb)
        {
            _objDLL.Config_Prj_Service("CONFIG_PRJ_SERVICE", _obj, _objdb);
        }
        public void Config_Prj_Cassheet( _sysconfig _obj, _database _objdb)
        {
            _objDLL.Config_Prj_Cassheet("CONFIG_PRJ_CASSHEET", _obj, _objdb);
        }
        public void Config_Prj_MsSystem(_sysconfig _obj, _database _objdb)
        {
            _objDLL.Config_Prj_MsSystem("CONFIG_PRJ_MSSYSTEM", _obj, _objdb);
        }
        public DataTable Load_Prj_Module(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_MODULES", _objdb);
        }
     
        public DataTable Load_Prj_Service(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_SERVICE", _objdb);
        }
        public DataTable Load_Prj_Cassheet(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_CASSHEET", _objdb);
        }
        public DataTable Load_Prj_Cassheet_12761(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_CASSHEET_RPT", _objdb);
        }
        public DataTable Load_Prj_MsSystem(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_MSSYSTEM", _objdb);
        }
        public DataTable Load_Prj_MsType(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_MSTYPE", _objdb);
        }
        public DataTable Load_Prj_TrType(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_TRTYPE", _objdb);
        }
        public void Upload_TestSheet( _clscassheet _obj, _database _objdb)
        {
            _objDLL.Upload_TestSheet("upload_testsheet", _obj, _objdb);
        }
      
        public DataTable Get_casinfo(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_casinfo("get_casinfo", _obj, _objdb);
        }
       
        public DataTable Load_cas_sys_info(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_cas_sys("load_cas_sys_info", _obj, _objdb);
        }
       
        public void Create_Company( _clsproject _obj, _database _objdb)
        {
            _objDLL.Create_Company("Create_company", _obj, _objdb);
        }
        public DataTable Load_Company_Master( _database _objdb)
        {
            return _objDLL.load_master("Load_Com_Master", _objdb);
        }
        public void Create_Prj_Company( _clsproject _obj, _database _objdb)
        {
            _objDLL.Create_Prj_Company("Insert_Prj_company", _obj, _objdb);
        }
        public DataTable Load_PrjCompany(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master("Load_PrjCompany", _obj, _objdb);
        }
     
        public void Generate_DRReport(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Generate_DRReport("DR_RPT",_obj, _objdb);
        }
        public void Add_SO_Details_Basket( _clsSO _obj, _database _objdb)
        {
            _objDLL.Add_SO_Details_Basket("Insert_SO_Temp", _obj, _objdb);
        }
        public void Add_SO_Photo_Basket(_clsSO _obj, _database _objdb)
        {
            _objDLL.SO_Photo("Insert_SO_Photo_Temp", _obj, _objdb);
        }
        public DataTable Load_SO_Basket( _clsSO _obj, _database _objdb)
        {
            return _objDLL.Load_SO_Basket("Load_SO_Temp", _obj, _objdb);
        }
        public DataTable Load_SO_Photo_Basket( _clsSO _obj, _database _objdb)
        {
            return _objDLL.Load_SO_Details("Load_SO_Photo_Temp", _obj, _objdb);
        }
        public void Remove_SO_Details_Basket( _clsSO _obj, _database _objdb)
        {
            _objDLL.Remove_SO_Details_Basket("delete_so_temp", _obj, _objdb);
        }
        public void Update_SO_Details( _clsSO _obj, _database _objdb)
        {
            _objDLL.Update_SO_Details("update_sodetails", _obj, _objdb);
        }
        public void Update_SO_Resp( _clsSO _obj, _database _objdb)
        {
            _objDLL.Update_SO_Resp("Update_SoResponse", _obj, _objdb);
        }
        public void Update_SO_CMLResp(_clsSO _obj, _database _objdb)
        {
            _objDLL.Update_SO_Resp("Update_SoCMLResponse", _obj, _objdb);
        }
        public void Generate_SOReport( _clsSO _obj, _database _objdb)
        {
            _objDLL.Generate_SOReport("SO_RPT", _obj, _objdb);
        }
        public void Generate_SOIMG( _clsSO _obj, _database _objdb)
        {
            _objDLL.Generate_SOIMG("SO_RPT1", _obj, _objdb);
        }
        public void Generate_PRG_RPT(_database _objdb)
        {
            _objDLL.Generate_PRG_RPT("PROGRAMMS_RPT", _objdb);
        }
        public void Generate_DR_SO_RPT(_database _objdb)
        {
            _objDLL.Generate_DR_SO_RPT("GEN_DR_SO_RPT", _objdb);
        }
      
        public void Generate_CP_RPT(_database _objdb)
        {
            _objDLL.Generate_PRG_RPT("CP_RPT", _objdb);
        }
        public void Generate_CAS_RPT( _database _objdb)
        {
            _objDLL.Generate_CAS_RPT("CASSHEET_RPT", _objdb);
        }
        public void Generate_CAS_RPT_1(_database _objdb)
        {
            _objDLL.Generate_CAS_RPT("CASSHEET_RPT_1", _objdb);
        }
        public DataTable LOAD_CAS_PKG_SUMMARY(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.LOAD_CAS_PKG_SUMMARY("CAS_PKG_SUMMARY", _obj, _objdb);
        }
      
        public void dr_cml_comment(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.dr_cml_comment("DR_CML_COMMENTS", _obj, _objdb);
        }
      
        public void Create_Building( _clscassheet _obj, _database _objdb)
        {
            _objDLL.Create_Building("Create_Building", _obj, _objdb);
        }
        public DataTable Load_Buildings(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master("Load_Building", _obj, _objdb);
        }
        public void Delete_Schedule(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Delete_Schedule("Delete_Schedule", _obj, _objdb);
        }
        public int Get_Seq(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_Seq("Get_SeqNo", _obj, _objdb);
        }
        public int Get_Position(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_Position("Get_Position", _obj, _objdb);
        }
        public DataTable Load_CasTestNames(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_cas_sys("Load_CasTestNames", _obj, _objdb);
        }
      
        public void Generate_CASSummary_PKG_RPT(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Generate_CASSummary_PKG_RPT("Insert_CasSummary_pkg", _obj, _objdb);
        }
        public void Generate_CASSummary_PKG_RPT_ASAO(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Generate_CASSummary_PKG_RPT_asao("Insert_CasSummary_pkg_asao", _obj, _objdb);
        }
        public void Clear_CassummaryRpt(_database _objdb)
        {
            _objDLL.Clear_Rpt("Clear_Summary_Graph", _objdb);
        }
        public void Create_FLevel(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Create_FLevel("Create_FLevel", _obj, _objdb);
        }
        public DataTable Load_Flvl(_database _objdb)
        {
            return _objDLL.load_master("Load_FLvl", _objdb);
        }
      
        public void Insert_CasServiceSummary( _clscassheet _obj, _database _objdb)
        {
            _objDLL.Insert_CasServiceSummary("Insert_CasService_Summary", _obj, _objdb);
        }
        public void Clear_CasServiceSummary( _database _objdb)
        {
            _objDLL.Clear_CasServiceSummary("Clear_CasService_Summary", _objdb);
        }
        public void Update_CMSDoc_Status(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Update_CMSDoc_Status("Update_CMSDocStatus", _obj, _objdb);
        }
        public void Generate_MS_Summary(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Generate_MS_Summary("Generate_MS_Summary", _obj, _objdb);
        }
        public void Generate_TR_Summary(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Generate_MS_Summary("Generate_TR_Summary", _obj, _objdb);
        }
        public DataTable Load_MSStatus(_database _objdb)
        {
            return _objDLL.load_master("Get_MsStatus", _objdb);
        }
        public void Clear_MSSummary(_database _objdb)
        {
            _objDLL.Clear_CasServiceSummary("Clear_MS_Summary", _objdb);
        }
        public string Get_MsDoc_No(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_MsDoc_No("Get_MsDoc_No", _obj, _objdb);
        }
        public string Get_TrDoc_No(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_MsDoc_No("Get_TrDoc_No", _obj, _objdb);
        }
        public DataTable Load_CMS_CommentsAll(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_CMS_CommentsAll("Load_CMS_Comments_All", _obj, _objdb);
        }
        public DataTable Load_CMS_DocInfo(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_CMS_DocInfo("Load_CMS_DocInfo", _obj, _objdb);
        }
        public void Update_CML_DocReponse(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Update_CML_DocReponse("Update_CML_DocResponse", _obj, _objdb);
        }
        public void Update_CML_DocReponse1(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Update_CML_DocReponse1("Update_CML_DocResponse", _obj, _objdb);
        }
        public void Update_CML_DocCmtStatus(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Update_CML_DocCmtStatus("Update_CML_DocCmtStatus", _obj, _objdb);
        }
        public DataTable Load_Training_Folder(_database _objdb)
        {
            return _objDLL.load_master("Load_Training_Folder", _objdb);
        }
        public void Manage_TrainingFolder(_clsFolderTree _obj, _database _objdb)
        {
            _objDLL.Manage_TrainingFolder("Manage_TrainingFolder", _obj, _objdb);
        }
        public string Get_FolderInfo(_clsFolderTree _obj, _database _objdb)
        {
            return _objDLL.Get_FolderInfo("Get_FolderInfo", _obj, _objdb);
        }
        public void GEN_CMSDOCCOMM_RPT(_clsdocument _obj, _database _objdb)
        {
            _objDLL.GEN_CMSDOCCOMM_RPT("GEN_CMS_Comments_RPT", _obj, _objdb);
        }
        public void GEN_CMSDOCINFO_RPT(_clsdocument _obj, _database _objdb)
        {
            _objDLL.GEN_CMSDOCINFO_RPT("GEN_CMS_DocInfo_RPT", _obj, _objdb);
        }
        public void Gen_MS_Schedule_Summary(_database _objdb)
        {
            _objDLL.Gen_MS_Schedule_Summary("Generate_MsSchedule_Summary", _objdb);
        }
        public DataTable Gen_MS_Schedule_Summary_12761(_database _objdb)
        {
            return _objDLL.Gen_MS_Schedule_Summary_12761("Generate_MsSchedule_Summary", _objdb);
        }
        public void Gen_MSComment_Rpt(_database _objdb)
        {
            _objDLL.Gen_MS_Schedule_Summary("Gen_MsComment_Rpt", _objdb);
        }
        public int Check_EngRef(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Check_EngRef("Check_EngRef", _obj, _objdb);
        }
       
        public DataTable Load_MSSchedule_Summary(_database _objdb)
        {
            return _objDLL.load_master("Load_MS_Schedule_Summary", _objdb);
        }
        public void Generate_MS_Summary_ALL(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Generate_MS_Summary_ALL("Generate_MS_Summary_ALL", _obj, _objdb);
        }
        public string Get_MsDoc_No_All(_database _objdb)
        {
            return _objDLL.Get_MsDoc_No_All("Get_MsDoc_No_ALL", _objdb);
        }
        public void Generate_TR_Summary_ALL(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Generate_MS_Summary_ALL("Generate_TR_Summary_All", _obj, _objdb);
        }
        public string Get_TrDoc_No_All(_database _objdb)
        {
            return _objDLL.Get_MsDoc_No_All("Get_TrDoc_No_All", _objdb);
        }
        public int Get_SysId( _clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_SysId("Get_SysId", _obj, _objdb);
        }
        public void Set_CMSAccess(_clsuser _obj, _database _objdb)
        {
            _objDLL.Set_CMSAccess("Set_CMSAccess", _obj, _objdb);
        }
        public string Get_CMSAccess(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Get_CMSAccess("Get_CMSPermission", _obj, _objdb);
        }
      
        public void CMSDoc_Permission(_clscmsdocument _obj, _database _objdb)
        {
            _objDLL.CMSDoc_Permission("CMSDoc_Permission", _obj, _objdb);
        }
       
        public void Add_ReviewSettings(_clscmsdocument _obj, _database _objdb)
        {
            _objDLL.Add_ReviewSettings("Add_ReviewPeriod", _obj, _objdb);
        }
        public DataTable Load_DocumentReviewPeriod( _database _objdb)
        {
            return _objDLL.load_master("Load_DocReviewPeriods", _objdb);
        }
        public int Get_ReviewPeriod( _clscmsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_ReviewPeriod("Get_ReviewPeriod", _obj, _objdb);
        }
        public string Get_User_Permission(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Get_User_Permission("Get_User_Permission", _obj, _objdb);
        }
        public string Get_User_cmsAccess(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Get_User_cmsAccess("Get_User_cmsAccess", _obj, _objdb);
        }
        public void Manage_MsFolder(_clscmsdocument _obj, _database _objdb)
        {
            _objDLL.Manage_MsFolder("Manage_MSFolder", _obj, _objdb);
        }
      
        public string Get_ProjectName(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Get_ProjectName("Get_ProjectName", _obj, _objdb);
        }
      
        public void Update_PrjLogo(_clsproject _obj, _database _objdb)
        {
            _objDLL.Update_PrjLogo("Update_Logo", _obj, _objdb);
        }
        public void Update_RPTLogo(_clsproject _obj, _database _objdb)
        {
            _objDLL.Update_RPTLogo("Update_RPTLogo", _obj, _objdb);
        }
        public DataTable Load_Document_Review_INFO(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Load_Document_Review_Details("Load_doc_review_INFO", _obj, _objdb);
        }
      
        public void Config_Prj_Service_MS(_sysconfig _obj, _database _objdb)
        {
            _objDLL.Config_Prj_Service("CONFIG_PRJ_SERVICE_MS", _obj, _objdb);
        }
        public DataTable Load_Prj_Service_MS(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_SERVICE_MS", _objdb);
        }
       
        public DataTable Load_casMain_SP(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_casMain_Edit("load_casMain_sp", _obj, _objdb);
        }
        public DataTable Load_ScheduleList(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_ScheduleList("LoadSchedule_List", _obj, _objdb);
        }
     
        public void Insert_DRTemp(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Insert_DRTemp("Insert_DR_Details_Temp", _obj, _objdb);
        }
        public void Delete_DRTemp(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Delete_DRTemp("Delete_Dr_Details_temp", _obj, _objdb);
        }
        public void Remove_DRTemp(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Remove_DRTemp("Remove_Dr_Details_temp", _obj, _objdb);
        }
        public DataTable Load_DRTemp(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Load_DRTemp("Load_DR_Details_Temp", _obj, _objdb);
        }
       
        public int Get_NoofCas(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_NoofCas("Get_NoofCassheet", _obj, _objdb);
        }
       
        public DataTable Load_Project_FloorLevel(_database _objdb)
        {
            return _objDLL.load_master("Load_Project_FloorLevel", _objdb);
        }
        public DataTable Load_Project_BZone(_database _objdb)
        {
            return _objDLL.load_master("Load_Project_BZone", _objdb);
        }
        public void Generate_TS_Upload_Rpt(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Generate_TS_Upload_Rpt("GENERATE_TS_RPT", _obj, _objdb);
        }
        public string Get_Est_TSCompl_date(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_Est_TSCompl_date("Get_Est_TS_Completion", _obj, _objdb);
        }
      
        public void Update_DrIssueTo(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Update_DrIssueTo("UPDATE_DRISSUETO", _obj, _objdb);
        }
        public DataTable Load_SO_Info(_clsSO _obj, _database _objdb)
        {
            return _objDLL.Load_SO_Info("LOAD_SITEOBSERVATION_INFO", _obj, _objdb);
        }
        public void Update_SOIssueTo(_clsSO _obj, _database _objdb)
        {
            _objDLL.Update_SOIssueTo("UPDATE_SOISSUETO", _obj, _objdb);
        }
        public DataTable LOAD_PRJMAINMODULES(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJ_MAINMODULES", _objdb);
        }
        public DataTable LOAD_PRJSUMMARY_HEADS(_database _objdb)
        {
            return _objDLL.load_master("LOAD_PRJSUMMARY_HEADS", _objdb);
        }
        public void Generate_Cas_SrvSum_All(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Generate_Cas_SrvSum_All("GENERATE_CAS_SRV_SUM_ALL", _obj, _objdb);
        }
        public string Get_CasName(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_CasName("GET_CASNAME", _obj, _objdb);
        }
        public void Clear_Srv_Sum(_database _objdb)
        {
            _objDLL.Clear_Srv_Sum("CLEAR_SRV_SUM", _objdb);
        }
        public string Get_SrvName(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_SrvName("GET_SRV_NAME", _obj, _objdb);
        }
        public DataTable Load_serv_package(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_serv_package("LOAD_SRV_PACKAGES", _obj, _objdb);
        }
        public void Insert_DMS_TCDOC(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Insert_DMS_TCDOC("INSERT_DMS_TCDOC_TBL", _obj, _objdb);
        }
        public DataTable Load_DMS_TCDOC_SYS(_clscassheet _obj, _database _objdb)
        {
           return _objDLL.Load_DMS_TCDOC_SYS("LOAD_DMS_TCDOC_SYS", _obj, _objdb);
        }
        public DataTable Load_DMS_TCDOC(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_DMS_TCDOC("LOAD_TESTSHEETS_DMS", _obj, _objdb);
        }
        public void Delete_DMS_TCDOC(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Delete_DMS_TCDOC("delete_DMS_TCDOC_TBL", _obj, _objdb);
        }
        public DataTable load_dms_user_email(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.load_dms_user_email("Load_dms_User_email", _obj, _objdb);
        }
        public int Get_Package_Service(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_Package_Service("Get_package_service", _obj, _objdb);
        }
        public void dml_cas_panel(_clscassheet _obj, _database _objdb)
        {
            _objDLL.dml_cas_panel("dml_cas_panel", _obj, _objdb);
        }
        public DataTable load_cas_panel(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.load_cas_panel("Load_Cas_Panels", _obj, _objdb);
        }
        public int get_panel_id(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.get_panel_id("get_panel_id", _obj, _objdb);
        }
        public void Generate_CASSummary_PKG_RPT_CCAD_FAS(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Generate_CASSummary_PKG_RPT_CCAD_FAS("Insert_CasSummary_pkg_CCAD_FAS", _obj, _objdb);
        }
        public void Clear_CassummaryRpt1(_database _objdb)
        {
            _objDLL.Clear_Rpt("Clear_Summary_Graph1", _objdb);
        }
        public void Insert_SO_Uversion(_clsSO _obj, _database _objdb)
        {
            _objDLL.Insert_SO_Uversion("insert_SO_uversion", _obj, _objdb);
        }
        public DataTable Load_So_Uversion(_database _objdb)
        {
            return _objDLL.Load_So_Uversion("Load_So_Uversion", _objdb);
        }
        public DataTable Load_SOUversion_Details(_clsSO _obj, _database _objdb)
        {
            return _objDLL.Load_SO_Details("Load_SOUversion_Details", _obj, _objdb);
        }
        public void Generate_CASSummary_PKGGRP_CCAD_MEC(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Generate_CASSummary_PKGGRP_CCAD_MEC("Generate_PkgGroup_Summary", _obj, _objdb);
        }
        public string get_main_sys(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.get_main_sys("get_main_sys", _obj, _objdb);
        }
        public string get_main_cat(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.get_main_sys("get_main_category", _obj, _objdb);
        }
        public void Clear_PkgGroup_Summ(_database _objdb)
        {
            _objDLL.Clear_Rpt("clear_pkggrp_sum", _objdb);
        }
        public void Generate_Cassheet_Summary(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Generate_Cassheet_Summary("generate_cas_summary", _obj, _objdb);
        }
        public void Clear_Cassheet_Summary(_database _objdb)
        {
            _objDLL.Clear_Rpt("Clear_Cas_Summary", _objdb);
        }
        public int get_schedule_possition(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.get_schedule_possition("Get_Schedule_Possition", _obj, _objdb);
        }
        public void Insert_dmsdoc_upload( _clsdocument _obj, _database _objdb)
        {
            _objDLL.Insert_dmsdoc_upload("Upload_Dmsdoc", _obj, _objdb);
        }
        public DataTable load_dms_doc_upload(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.load_dms_doc_upload("Load_dmsdoc_upload", _obj, _objdb);
        }
        public int dml_cx_issues_log(_clscassheet _obj, _database _objdb)
        {
           return _objDLL.dml_cx_issues_log("dml_cx_issues_log", _obj, _objdb);
        }
        public void Generate_CX_Log_Rpt(_database _objdb)
        {
            _objDLL.Generate_CX_Log_Rpt("Generate_CX_Log_Summary", _objdb);
        }
        public void update_cx_risk_assessment(_clscassheet _obj, _database _objdb)
        {
            _objDLL.update_cx_risk_assessment("update_cx_risk_assessment", _obj, _objdb);
        }
        public void update_cx_mitigation(_clscassheet _obj, _database _objdb)
        {
            _objDLL.update_cx_mitigation("update_cx_mitigation", _obj, _objdb);
        }
        public DataTable load_cx_issues_basic( _clscassheet _obj, _database _objdb)
        {
            return _objDLL.load_cx_issues("load_cx_issue_log", _obj, _objdb);
        }
        public DataTable load_cx_issues_assessment( _clscassheet _obj, _database _objdb)
        {
            return _objDLL.load_cx_issues("load_cx_assessment", _obj, _objdb);
        }
        public DataTable load_cx_issues_mitigation(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.load_cx_issues("load_cx_mitigation", _obj, _objdb);
        }
        public void update_cx_summary(_clscassheet _obj, _database _objdb)
        {
            _objDLL.update_cx_summary("update_cx_summary", _obj, _objdb);
        }
        public DataTable Load_CX_Buildings(_database _objdb)
        {
            return _objDLL.load_master("Load_CX_Buildings", _objdb);
        }
        public int Get_Cx_IssuesRaised(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_Cx_IssuesRaised("Get_IssuesRaised", _obj, _objdb);
        }
        public void Insert_CX_RO_Summary_rpt(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Insert_CX_RO_Summary_rpt("Insert_CX_RO_Sumary_rpt", _obj, _objdb);
        }
        public void Clear_CX_SO_Summary_rpt(_database _objdb)
        {
            _objDLL.Clear_Rpt("Clear_CX_RO_Summary_rpt", _objdb);
        }
        public DataTable Load_Document_Review_Items(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Load_Document_Review_Items("Load_Dr_Itm_Edit", _obj, _objdb);
        }
        public void Edit_DR(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Edit_DR("Edit_DR", _obj, _objdb);
        }
        public void Edit_SO(_clsSO _obj, _database _objdb)
        {
            _objDLL.Edit_SO("Edit_SO", _obj, _objdb);
        }
        public DataTable Load_SO_Items( _clsSO _obj, _database _objdb)
        {
            return _objDLL.Load_SO_Items("Load_SO_Itm_Edit", _obj, _objdb);
        }
        public void Dml_CXIR_Schedule(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Dml_CXIR_Schedule("dml_cxir_schedule", _obj, _objdb);
        }
        public DataTable Load_CXIR_Schedule_Details(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_CXIR_Schedule_Details("Load_CXIR_Schedule_Details", _obj, _objdb);
        }
        public int Get_CMS_TC_Scheduled(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_CMS_TC_Count("Get_DMS_TC_Scheduled", _obj, _objdb);
        }
        public int Get_CMS_TC_Upladed(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_CMS_TC_Count("Get_DMS_TC_Uploaded", _obj, _objdb);
        }
        public bool Check_CMS(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Check_CMS("Check_CMS_Access", _obj, _objdb);
        }
        public DataTable Load_Cassheet_Sub(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_Cassheet_Sub("Get_Cassheet_Sub", _obj, _objdb);
        }
        public DataTable Load_Cassheet_Sub_System_List(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_Cassheet_Sub("Get_Cassheet_Sub1", _obj, _objdb);
        }
        public DataTable Load_User_DMS_Projects(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Load_User_Projects("Load_User_DMS_Projects", _obj, _objdb);
        }
        public DataTable Load_User_CMS_Projects(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Load_User_Projects("Load_User_CMS_Projects", _obj, _objdb);
        }
        public void dml_com_certificate(_clstestpack _obj, _database _objdb)
        {
            _objDLL.dml_com_certificate("dml_com_certificate", _obj, _objdb);
        }
        public string Get_Assetcode(_clstestpack _obj, _database _objdb)
        {
            return _objDLL.Get_Assetcode("Get_Assetcode", _obj, _objdb);
        }
        public void dml_precom_checklist(_clstestpack _obj, _database _objdb)
        {
            _objDLL.dml_precom_checklist("dml_precom_checklist", _obj, _objdb);
        }
        public void insert_precom_checklist_list(_clstestpack _obj, _database _objdb)
        {
            _objDLL.insert_precom_checklist_list("insert_precom_checklist_list", _obj, _objdb);
        }
        public string Get_PlantRef(_clstestpack _obj, _database _objdb)
        {
            return _objDLL.Get_PlantRef("Get_PlantRef", _obj, _objdb);
        }
        public DataTable Load_Comm_Certificate(_clstestpack _obj, _database _objdb)
        {
            return _objDLL.Load_TP_Details("Load_Comm_Certificate", _obj, _objdb);
        }
     
        public int Get_FolderType( _clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_FolderType("Get_FolderType", _obj, _objdb);
        }
        public int Get_FolderType_Type(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_FolderType("Get_FolderType_Type", _obj, _objdb);
        }
        public void Delete_dms_upload(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Delete_Doc("Delete_dms_upload", _obj, _objdb);
        }
        public void DML_System_List(_clscassheet _obj, _database _objdb)
        {
            _objDLL.DML_System_List("dml_system_list", _obj, _objdb);
        }
        public DataTable Load_System_List(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_System_List("Load_System_List", _obj, _objdb);
        }
        public DataTable Load_System_List_Edit(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_System_List_Edit("Load_System_List_edit", _obj, _objdb);
        }
        public void Update_System_List(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Update_System_List("update_system_list", _obj, _objdb);
        }
     
        public void Add_Cas_MultiEdit_Temp(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Add_Cas_MultiEdit_Temp("add_cas_multiedit_temp", _obj, _objdb);
        }
        public void GENERATE_PROJECT_SUMMARY(_clscassheet _obj, _database _objdb)
        {
            _objDLL.GENERATE_PROJECT_SUMMARY("GENERATE_SRV_SUMMARY",_obj, _objdb);
        }
        public void GENERATE_SERVICE_SUMMARY(_clscassheet _obj, _database _objdb)
        {
            _objDLL.GENERATE_SERVICE_SUMMARY("GENERATE_CAS_SER_SUMMARY", _obj, _objdb);
        }
        public void GENERATE_PACKAGE_SUMMARY(_clscassheet _obj, _database _objdb)
        {
            _objDLL.GENERATE_PACKAGE_SUMMARY("GENERATE_CAS_PKG_SUMMARY", _obj, _objdb);
        }

        public void GENERATE_SRVOVR_SUMMARY(_database _objdb)
        {
            _objDLL.GENERATE_SRVOVR_SUMMARY("GENERATE_CAS_OVERALL_SUMMARY", _objdb);
        }
        public void GENERATE_SRVOVR_SUMMARY_SPLIT(_clscassheet _obj, _database _objdb)
        {
            _objDLL.GENERATE_SRVOVR_SUMMARY_SPLIT("GENERATE_CAS_OVERALL_SUMMARY_SPLIT", _obj, _objdb);
        }
        public void Update_Circuit(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Update_Circuit("UPDATE_CIRSUITS", _obj, _objdb);
        }
        public void Generate_DBMS_Summary_ALL(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Generate_DBMS_Summary_ALL("Generate_DBMS_Summary_ALL", _obj, _objdb);
        }
        public DataTable Load_DBMSStatus(_database _objdb)
        {
            return _objDLL.load_master("Get_DBMsStatus", _objdb);
        }
        public void Clear_DBMSSummary(_database _objdb)
        {
            _objDLL.Clear_CasServiceSummary("Clear_DBMS_Summary", _objdb);
        }
        public DataTable Load_TreeFolder_Parent(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_master("Get_TreeFolderParent", _obj, _objdb);
        }
        public string Get_DBMsDoc_No_All(_clstreefolder _obj, _database _objdb)
        {
            return _objDLL.Get_DBMsDoc_No_All("Get_DBMsDoc_No_ALL", _obj, _objdb);
        }
        public void Delete_CMS_Doc(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Delete_Doc("Delete_CMS_Document", _obj, _objdb);
        }
        public DataTable Load_cassheet_data(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_casMain("Load_Cassheet_data", _obj, _objdb);
        }

        public void Delete_TestSheet(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Delete_TestSheet("Delete_Testsheet", _obj, _objdb);
        }
       
        public DataTable load_cas_div(_database _objdb)
        {
            return _objDLL.load_master("Load_Cas_Div", _objdb);
        }
        public DataTable GENERATE_BAREA_SUMMARY(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.GENERATE_BAREA_SUMMARY("GENERATE_SYS__DIV_SUMMARY_OVERALL", _obj, _objdb);
        }
        public DataTable GENERATE_DIV_SUMMARY(_database _objdb)
        {
            return _objDLL.GENERATE_DIV_SUMMARY("GENERATE_CAS_DIV_SUMMARY", _objdb);
        }
        public DataTable GENERATE_DIV_SUMMARY_PRJ(_database _objdb)
        {
            return _objDLL.GENERATE_DIV_SUMMARY("GENERATE_CAS_SER_SUMMARY_PRJ", _objdb);
        }
        public DataTable GENERATE_DIV_SER_SUMMARY(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.GENERATE_DIV_SER_SUMMARY("GENERATE_CAS_DIV_SER_SUMMARY1", _obj, _objdb);
        }
        public DataTable GENERATE_OVERALL_SUMMARY_BLDG( _database _objdb)
        {
            return _objDLL.GENERATE_DIV_SUMMARY("GENERATE_OVERALL_SUMMARY_BLDG", _objdb);
        }
        public DataTable GENERATE_OVERALL_SUMMARY_BLDG1(_database _objdb)
        {
            return _objDLL.GENERATE_DIV_SUMMARY("GENERATE_OVERALL_SUMMARY_BLDG1", _objdb);
        }
        public DataTable GENERATE_OVERALL_SUMMARY_BLDG2(_database _objdb)
        {
            return _objDLL.GENERATE_DIV_SUMMARY("GENERATE_OVERALL_SUMMARY_BLDG2", _objdb);
        }
        public DataTable GENERATE_OVERALL_SUMMARY_BLDG3(_database _objdb)
        {
            return _objDLL.GENERATE_DIV_SUMMARY("GENERATE_OVERALL_SUMMARY_BLDG3", _objdb);
        }
        public DataTable GENERATE_OVERALL_SUMMARY_BLDG4(_database _objdb)
        {
            return _objDLL.GENERATE_DIV_SUMMARY("GENERATE_OVERALL_SUMMARY_BLDG4", _objdb);
        }
        public DataTable GENERATE_PKG_DIV_SUMMARY(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.GENERATE_PKG_DIV_SUMMARY("GENERATE_PKG_DIV_SUMMARY", _obj, _objdb);
        }
        public DataTable GENERATE_CAS_PKG_SUMMARY(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.GENERATE_DIV_SER_SUMMARY("GENERATE_CAS_PKG_SUMMARY", _obj, _objdb);
        }
        public DataTable GENERATE_PKG_DIV_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            return _objDLL.GENERATE_PKG_DIV_SUMMARY(_sp, _obj, _objdb);
        }
        public DataTable Load_CasBuildings(_database _objdb)
        {
            return _objDLL.load_master("Load_CasBuildings", _objdb);
        }
      

        public DataTable Generate_Cassheet_Report(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Cassheet_Report("CASSHEET_RPT", _obj, _objdb);
        }
        public DataTable Generate_Package_Summary(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Package_Summary("GENERATE_PKG_SUMMARY", _obj, _objdb);
        }
        public DataTable Get_ProjectInformation(_clsproject _obj, _database _objdb)
        {
            return _objDLL.Get_ProjectInformation("Get_ProjectInformation", _obj, _objdb);
        }
      
        public DataTable Get_Cassheet_master_Dtls(_clsams _obj, _database _objdb)
        {
            return _objDLL.Load_SpareParts("Get_Cassheet_master_Dtls", _obj, _objdb);
        }
      
        public void DR_Photo(_clsSO _obj, _database _objdb)
        {
            _objDLL.SO_Photo("Insert_DR_Photo_Temp", _obj, _objdb);
        }
        public DataTable Load_DR_Photo_Temp(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Load_Document_Review_Details("Load_DR_Photo_Temp", _obj, _objdb);
        }
        public void Remove_DR_Details_Basket(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Remove_DR_Details_Basket("Delete_Dr_Details_temp", _obj, _objdb);
        }
        public void Update_DR_Details(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.Update_DR_Details("update_DRdetails", _obj, _objdb);
        }
        public DataTable Load_DR_Image(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Load_Document_Review_Details("load_dr_photo", _obj, _objdb);
        }
      
        public void dml_dr_pdf(_clsdocreview _obj, _database _objdb)
        {
            _objDLL.dml_dr_pdf("dml_DR_pdf", _obj, _objdb);
        }
        public DataTable Load_dr_pdf(_database _objdb)
        {
            return _objDLL.load_master("Load_dr_pdf", _objdb);
        }
      
        public DataTable Load_dr_pdf_details(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Load_dr_pdf_details("Load_dr_pdf_details",_obj, _objdb);
        }
      
        public DataTable Generate_Bldg_Rpt(_clscassheet _obj,_database _objdb)
        {
            return _objDLL.Generate_Bldg_Rpt("GENERATE_SUMMARY_BLDG", _obj, _objdb);
        }
      
        public DataTable Generate_CASPkg_Rpt(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_CASPkg_Rpt("GENERATE_SUMMARY_PKG", _obj, _objdb);
        }
      
        
        public DataTable Load_Building_Summary_ASAO(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_Building_Suammry_ASAO("Load_BZ_Summary",_obj, _objdb);
        }
       
        public string GetUserAccess(_clsuser _obj, _database _objdb)
        {
            return _objDLL.GetUserAccess("getUserAccess", _obj, _objdb);
        }
      
        public string Get_file(_clscmsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_file("get_file", _obj, _objdb);
        }
        public void Update_msinfo(_clscmsdocument _obj, _database _objdb)
        {
            _objDLL.Update_msinfo("update_msinfo", _obj, _objdb);
        }
        public DataTable Get_MsInfo( _clscmsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_MsInfo("get_msinfo", _obj, _objdb);
        }
      
        public string Get_DocStatus(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_DocStatus("Get_DocStatus", _obj, _objdb);
        }
     
        public DataTable Load_fclty_Package(_database _objdb)
        {
            return _objDLL.load_master("Load_Fclty_Packages", _objdb);
        }
        public DataTable Load_Facility(_database _objdb)
        {
            return _objDLL.load_master("Load_Facility", _objdb);
        }
      
        public DataTable Load_Comment_Details(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_Comment_Details("Get_Comment_Info", _obj, _objdb);
        }
        public void Gen_MSSchedule_Graph(_database _objdb)
        {
            _objDLL.Gen_MSSchedule_Graph("GEN_MSSCHEDULE_GRAPH", _objdb);
        }
        public DataTable Load_CMS_Document_All(_clscmsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_CMS_Docs("Load_CMS_Document_All", _obj, _objdb);
        }
        public DataTable Gen_MS_Schedule_Summary_12761_Previous(_database _objdb)
        {
            return _objDLL.Gen_MS_Schedule_Summary_12761("Generate_MsSchedule_Summary_Prev", _objdb);
        }
        public void insert_MS_Schedule_Report(_clsMaster _obj, _database _objdb)
        {
            _objDLL.insert_MS_Schedule_Report("Generate_MS_Schedule_Report", _obj, _objdb);
        }
        public bool GetEmailNotify(_clsuser _obj, _database _objdb)
        {
            return _objDLL.GetEmailNotify("CheckUserNotification", _obj, _objdb);
        }
        public DataTable User_Prj_AllModules(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_projecthome("User_Prj_Modules_Tbl_Load", _obj, _objdb);
        }
        public void Insert_User_Prj_Modules(_clsuser _obj, _database _objdb)
        {
            _objDLL.Insert_User_Prj_Modules("User_Prj_Modules_Tbl_InsertUpdate", _obj, _objdb);
        }
        public void Delete_User_Prj_Modules_Tbl(_clsSnag _obj, _database _objdb)
        {
            _objDLL.Update_Doc_Control("User_Prj_Modules_Tbl_Delete", _obj, _objdb);
        }
       
        public void Generate_CAS_RPT_BLG(_database _objdb)
        {
            _objDLL.Generate_CAS_RPT_BLG("CASSHEET_RPT_BlG", _objdb);
        }
        public string Get_Facility_Name(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_Facility_Name("Get_Facility_Name", _obj, _objdb);
        }
        public DataTable Load_CMS_Document_Div(_clscmsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_CMS_Docs_Div("Load_CMS_Document_Div", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_LV(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_LV", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_ME(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_ME", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_PH(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_PH", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_FAS(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_FAS", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_ELP(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_ELP", _obj, _objdb);
        }
        public DataTable Load_CAS_Details(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_CAS_Details("Load_CAS_Details", _obj, _objdb);
        }
        public void Gen_MS_Schedule_Summary(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Gen_MS_Schedule_Summary("Generate_MsSchedule_Summary", _obj, _objdb);
        }
        public void Gen_MSComment_Rpt(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Gen_MS_Schedule_Summary("Gen_MsComment_Rpt", _obj, _objdb);
        }
        public void Generate_MS_Summary_ALL_Div(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Generate_MS_Summary_ALL_Div("Generate_MS_Summary_ALL", _obj, _objdb);
        }
        public void Generate_MS_Summary_Div(_clsdocument _obj, _database _objdb)
        {
            _objDLL.Generate_MS_Summary_Div("Generate_MS_Summary", _obj, _objdb);
        }
        public int Get_Position_Div(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_Position_Div("Get_Position", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_Gen(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_gen", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_Emg(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_Emg", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_ph2(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_ph2", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_ph3(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_ph3", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_bms(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_bms", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_Flush(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_Flush", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_Vesda(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_VESDA", _obj, _objdb);
        }
        public int Get_Get_MsDoc_No_ALL_Div(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_Get_MsDoc_No_ALL_Div("Get_MsDoc_No_ALL", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_cctv(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_cctv", _obj, _objdb);
        }
        public void Manage_MsFolder_Div(_clscmsdocument _obj, _database _objdb)
        {
            _objDLL.Manage_MsFolder_Div("Manage_MSFolder", _obj, _objdb);
        }
        public DataTable Load_MSSYSTEM(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_AssetMaster("Load_MSSYSTEM", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_LCS(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_LCS", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_SCN(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_SCN", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_LDS(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_LDS", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_Acs(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_Acs", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_PAVA(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_PAVA", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_ELV(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_ELV", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_IST(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_IST", _obj, _objdb);
        }
        public string Get_Buiding_Permission(_clsuser _obj, _database _objdb)
        {
            return _objDLL.Get_Buiding_Permission("Get_BuildingPermission", _obj, _objdb);
        }
       
        public DataTable Generate_Commissioning_Summary_KLE(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_KLE", _obj, _objdb);
        }
        public DataTable Generate_Commissioning_Summary_HVTS(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Commissioning_Summary("Generate_Commissioning_Summary_Graph_HVTS", _obj, _objdb);
        }
        public DataTable GENERATE_CAS_BUILDNG_SUMMARY(_database _objdb)
        {
            return _objDLL.GENERATE_DIV_SUMMARY("GENERATE_CAS_BUILDNG_SUMMARY", _objdb);
        }
        public string Get_Building_Name(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Get_Facility_Name("Get_Build_Name", _obj, _objdb);
        }
        public DataTable Load_Project_FloorLevel(_clstis _obj, _database _objdb)
        {
            return _objDLL.LOAD_FLOOR("Load_Project_FloorLevel", _obj, _objdb);
        }

        public DataTable Load_Project_BZone(_clstis _obj, _database _objdb)
        {
            return _objDLL.LOAD_FLOOR("Load_Project_BZone", _obj, _objdb);
        }

        public DataTable Load_SO_Admin_Response(_clsuser _obj, _database _objdb)
        {
            return _objDLL.load_service("Get_SO_Response_Permission", _obj, _objdb);
        }
        public DataTable Get_CAS_BuildingPermission(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Load_cas_sys("Get_CAS_BuildingPermission", _obj, _objdb);
        }
        public DataTable Load_SO_Report(_database _objdb)
        {
            return _objDLL.load_master("Load_SO_Report", _objdb);
        }
        public DataTable Load_Prj_Cassheet_Bldng(_clstis _obj, _database _objdb)
        {
            return _objDLL.LOAD_FLOOR("LOAD_PRJ_CASSHEET_BLDNG", _obj, _objdb);
        }
       
        public DataSet Load_DR_SO_CommentLog(_clsSO _obj, _database _objdb)
        {
            return _objDLL.load_dataset("Load_SO_DR_Comment_Log", _obj, _objdb);
        }
        public DataTable Get_User_Log(_clslog _obj, _database _objdb)
        {
            return _objDLL.Get_User_Log(_obj, "Get_User_Log", _objdb);
        }
       
        public DataTable Load_CAS_MarketingSuit(_database _objdb)
        {
            return _objDLL.load_master("LOAD_CAS_MarketingSuit", _objdb);
        }
        
        public DataTable Load_So_pdf_details(_clsdocreview _obj, _database _objdb)
        {
            return _objDLL.Load_dr_pdf_details("Load_SO_pdf_details", _obj, _objdb);
        }
        public DataTable Load_SO_pdf(_database _objdb)
        {
            return _objDLL.load_master("Load_SO_pdf", _objdb);
        }
        public void dml_SO_pdf(_clsSO _obj, _database _objdb)
        {
            _objDLL.dml_SO_pdf("dml_SO_pdf", _obj, _objdb);
        }
        public void Generate_DR_SO_RPT_PDF(_database _objdb)
        {
            _objDLL.Generate_DR_SO_RPT("GEN_DR_SO_RPT_PDF", _objdb);
        }
        public DataTable LoadDataTable(string sp, _database _objdb)
        {
            return _objDLL.LoadDataTable(sp, _objdb);
        }
        public void Generate_CAS_Graph_Summary(_clscassheet _obj, _database _objdb) 
        {
            _objDLL.Generate_CAS_Graph_Summary("GET_CAS_GRAPH_SUMMARY", _obj, _objdb);
        }
        public void Generate_Prj_summary_Overall(_clscassheet _obj,_database _objdb)  
        {
            _objDLL.GENERATE_PROJECT_SUMMARY("GENERATE_PRJ_SUMMARY_SER_OVERALL",_obj, _objdb);
        }
        public DataSet Generate_ProgressComparison_Graph(_clscassheet _obj, _database _objdb)     
        {
            return _objDLL.Generate_ProgressComparison_Graph("Generate_ProgressComparison_Graph", _obj, _objdb);    
        }
        public void Generate_Prj_summary_Overall_Pcd(_clscassheet _obj, _database _objdb)      
        {
            _objDLL.GENERATE_PROJECT_SUMMARY_PCD("GENERATE_PRJ_SUMMARY_SER_OVERALL_PCD", _obj, _objdb); 
        }
       
        public void Get_Total_Executive_Summary(_clscassheet _obj, _database _objdb)
        {
            _objDLL.Get_Total_Executive_Summary("GET_TOTAL_EXECUTIVE_SUMMARY", _obj, _objdb);
        }
     
        public DataTable load_dashboarddummy(_database _objdb)
        {
            return _objDLL.load_master("load_dashboard", _objdb);
        }
        public DataTable Generate_CAS_Graph_Summary1(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_CAS_Graph_Summary1("GET_CAS_GRAPH_SUMMARY", _obj, _objdb);
        }
        public DataSet GeneratePlannedServiceSummary(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.GeneratePlannedServiceSummary("GENERATE_PRJ_SUMMARY_SERVICE_PCD", _obj, _objdb);
        }
        public DataSet GetDashBoardSummary(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.GenerateDashboardSummary("GENERATE_PRJ_SUMMARY_SER_OVERALL_PCD", _obj, _objdb);
        }
        public DataTable Generate_CASPkg_Rpt_Bldng(_clscassheet _obj, _database _objdb)
        {
            return _objDLL.Generate_Bldg_Rpt("GENERATE_SUMMARY_PKG", _obj, _objdb);
        }
        public void Generate_Prj_summary_Overall_Bldng(_clscassheet _obj, _database _objdb)
        {
            _objDLL.GENERATE_SERVICE_SUMMARY("GENERATE_PRJ_SUMMARY_SER_OVERALL", _obj, _objdb);
        }
        public DataTable LOAD_USERMODULE_PERMISSION(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.Load_ScheduleBasket("LOAD_USERMODULE_PERMISSION", _obj, _objdb);
        }
        public DataTable Load_User_AllModule(_clsdocument _obj, _database _objdb)
        {
            return _objDLL.load_usercomments("Load_User_Module", _obj, _objdb);
        }
        public void Update_User_ModulePermision(_clstreefolder _obj, _database _objdb)
        {
            _objDLL.Move_Tree_Folder("Update_User_ModulePermision", _obj, _objdb);
        }
        public void Set_User_ModulePermission(_clsuser _obj, _database _objdb)
        {
            _objDLL.Set_CMSAccess("Set_User_ModulePermission", _obj, _objdb);
        }
        public void SaveCableLog(_clscassheet _obj, _database _objdb)
        {
            _objDLL.SaveCableLog("SaveCableLog", _obj, _objdb);
        }
        public void DeleteDocuments(string sp, _clsdocument _obj, _database _objdb)
        {
            _objDLL.DeleteDocuments(sp, _obj, _objdb);
        }
        public string Get_Document(string sp, _clscmsdocument _obj, _database _objdb)
        {
            return _objDLL.Get_file(sp, _obj, _objdb);
        }
        public DataTable Get_ProjectInformation(_clsuser _obj,_database _objdb) 
        {
            return _objDLL.load_master("Get_ProjectInformation_Code", _obj, _objdb);
        }

        #region CommentedZeroRef
        //public DataTable Load_PrjPackage(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("Load_PrjPackages", _obj, _objdb);
        //}
        //public DataTable Load_PrjDocType(_clsFolderTree _obj, _database _objdb)
        //{
        //    return _objDLL.Load_PrjDocType("Load_PrjDocType", _obj, _objdb);
        //}
        //public void Editcomment(_clscomment _obj, _database _objdb)
        //{
        //    _objDLL.Editcomment("editcomment", _obj, _objdb);
        //}
        //public void Deletecomment(_clscomment _obj, _database _objdb)
        //{
        //    _objDLL.Deletecomment("deletecomment", _obj, _objdb);
        //}
        //public DataTable load_usercomments(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.load_usercomments("load_usercomments", _obj, _objdb);
        //}
        //public void ClearBasket(_database _objdb)
        //{
        //    _objDLL.ClearBasket("ClearBasket",_objdb);
        //}
        //public DataTable load_basket(_database _objdb)
        //{
        //    return _objDLL.load_basket("Loadbasket",_objdb);
        //}

        //----------------CREATED ON 13/03/2011---------------------------------//
        //public DataTable load_SummaryOfOMmanual(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Reports("OandM_Manual_Summary_Report",_obj,_objdb );
        //}
        //public void Create_Service(_clsManageTree _obj, _database _objdb)
        //{
        //    _objDLL.Manage_Tree("CreateService", _obj,_objdb);
        //}
        //public void Create_Package(_clsManageTree _obj, _database _objdb)
        //{
        //    _objDLL.Manage_Tree("CreatePackage", _obj,_objdb);
        //}
        //public void Create_DocType(_clsManageTree _obj, _database _objdb)
        //{
        //    _objDLL.Manage_Tree("CreateDocType", _obj,_objdb);
        //}
        //public void Create_Group(_clsManageTree _obj, _database _objdb)
        //{
        //    _objDLL.Manage_Tree("CreateGroup", _obj,_objdb);
        //}
        //public void Edit_Service(_clsManageTree _obj, _database _objdb)
        //{
        //    _objDLL.Edit_Tree("EditService", _obj,_objdb);
        //}
        //public void Edit_Package(_clsManageTree _obj, _database _objdb)
        //{
        //    _objDLL.Edit_Tree("EditPackage", _obj,_objdb);
        //}
        //--------------------Created on 15/03/2011-----------------//
        //public DataTable load_AvailablePackages(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("Load_AvailablePackages", _obj,_objdb);
        //}
        //public void SetAutoComplete(_clsuser _obj, _database _objdb)
        //{
        //    _objDLL.SetAutoComplete("SetAutoComplete", _obj,_objdb);
        //}
        //public DataTable load_cms_srv(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("load_cms_srv", _obj,_objdb);
        //}
        //public DataTable load_cms_cas_sch(_database _objdb)
        //{
        //    return _objDLL.load_master("load_cms_cas_sch",_objdb);
        //}
        //public DataTable Load_cas_building(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_Buildingzones", _objdb);
        //}
        //public void add_cas_main(_clscassheet _obj, _database _objdb)
        //{
        //    _objDLL.add_cas_main("dml_cas_main", _obj,_objdb);
        //}
        //public DataTable Load_EngReff(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_casMain("load_EngReff", _obj,_objdb);
        //}
        //public DataTable Load_Ele_Test1(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_CasSub("Load_cas_ele_pnl_eqi_test", _obj,_objdb);
        //}
        //public DataTable Load_Ele_Test2(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_CasSub("Load_ele_out_cir_test", _obj, _objdb);
        //}
        //public DataTable Load_Avl_Sys(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_casMain("load_avl_sys", _obj,_objdb);
        //}
        //public void LOG(_clslog _obj, _database _objdb)
        //{
        //    _objDLL.LOG("USER_LOG", _obj,_objdb);
        //}
        //public DataTable Load_CMS_Comments(_clscmscomment _obj, _database _objdb)
        //{
        //    return _objDLL.load_comments("Load_cms_comments",_obj,_objdb);
        //}
        //public DataTable Load_CMSUser(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.Load_CMSUser("Load_CMS_User", _obj, _objdb);
        //}
        //public void SO_Photo(_clsSO _obj, _database _objdb)
        //{
        //    _objDLL.SO_Photo("add_so_photo", _obj,_objdb);
        //}
        //public DataSet Load_casMain_Graph(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_casMain_Graph("load_casMain_Edit", _obj,_objdb);
        //}
        //public DataTable Load_CasSummary(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_casMain_Edit("Ele_Cas_Summary", _obj,_objdb);
        //}
        //public DataTable Load_CasSummary_test(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_casMain_Edit("Ele_Cas_test_Summary", _obj,_objdb);
        //}
        //public void RESTORE_DB(_database _obj, _database _objdb)
        //{
        //    _objDLL.RESTORE_DB("RESTORE_DB", _obj,_objdb);
        //}
        //public DataTable LOAD_SYS_CMS_MODULES(_database _objdb)
        //{
        //    return _objDLL.load_master("LOAD_CMS_SYS_MODULES",_objdb);
        //}
        //public DataTable Load_Ms_Schedule(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_Ms_Schedule", _objdb);
        //}
        //public DataTable Load_Prj_Main_Module(_database _objdb)
        //{
        //    return _objDLL.load_master("LOAD_PRJ_MAIN_MODULES", _objdb);
        //}
        //public void Add_CRS_Master(_clsCRS _obj, _database _objdb)
        //{
        //    _objDLL.Add_CRS_Master("ADD_CRS_MASTER", _obj, _objdb);
        //}
        //public void Add_AirBalancing(_clsCRS _obj, _database _objdb)
        //{
        //    _objDLL.Add_AirBalancing("ADD_AIRBALANCING", _obj, _objdb);
        //}
        //public DataTable Load_RecordSheet_Master(_clsFolderTree _obj, _database _objdb)
        //{
        //    return _objDLL.Load_SubFolder("load_recordsheet_master", _obj, _objdb);
        //}
        //public void CREATE_SYSCASPKG( _clspackage _obj, _database _objdb)
        //{
        //    _objDLL.CREATE_SYSCASPKG("CREATE_SYS_CASPKG", _obj, _objdb);
        //}
        //public DataTable Populate_TempDocList(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.load_document("Populate_Temp_Doc_List", _obj, _objdb);
        //}
        //public DataTable Load_Snag_Master( _clsSnag _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Snag_Master("LOAD_SNAG_MASTER", _obj, _objdb);
        //}
        //public void Add_Snag_Basket(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Add_Snag_Basket("add_snag_basket", _obj, _objdb);
        //}
        //public void Add_Snag_Img(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Add_Snag_Img("add_snag_img", _obj, _objdb);
        //}
        //public void Remove_Snag_Basket(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Remove_Snag_Basket("Remove_Snag", _obj, _objdb);
        //}
        //public int Create_Snag(_clsSnag _obj, _database _objdb)
        //{
        //    // return _objDLL.Create_Snag("INSERT_SNAG_MASTER", _obj, _objdb);
        //    return _objDLL.Create_Snag("INSERT_SNAGMASTER", _obj, _objdb);
        //}
        //public DataTable Load_SnagDetails_Basket(_clsSnag _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Snag_Basket("Load_Snag_Temp", _obj, _objdb);
        //}
        //public DataTable Load_SnagIMG(_clsSnag _obj, _database _objdb)
        //{
        //    //return _objDLL.Load_Snag_Basket("Load_Img_Temp", _obj, _objdb);
        //    return _objDLL.Load_SnagSub("Load_SnagIMG", _obj, _objdb);
        //}
        //public void Submit_Snag_Details( _clsSnag _obj, _database _objdb)
        //{
        //    //_objDLL.Submit_Snag_Details("Submit_Snag_Details", _obj, _objdb);
        //    _objDLL.Submit_Snag_Details("Insert_SnagSub", _obj, _objdb);
        //}
        //public void Snag_Issue(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Snag_Issue("snag_issue", _obj, _objdb);
        //}
        //public void Update_SnagResponse(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Update_SnagResponse("Update_SnagResponse", _obj, _objdb);
        //}
        //public void Update_SnagStatus( _clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Update_SnagStatus("Snag_Status", _obj, _objdb);
        //}
        //public int Insert_Snag_Pkg(_clsSnag _obj, _database _objdb)
        //{
        //   return  _objDLL.Insert_Snag_Pkg("Insert_Snag_Pkg", _obj, _objdb);
        //}
        //public void Inser_Snag_Pkg_Sub(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Inser_Snag_Pkg_Sub("Insert_Snag_Pkg_sub", _obj, _objdb);
        //}
        //public void Update_Doc_Control(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Update_Doc_Control("Update_Doc_Con", _obj, _objdb);
        //}
        //public DataTable Load_SnagPackage(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("Load_SnagPackage", _obj, _objdb);
        //}
        //public DataTable Load_SnagMaster(_clsSnag _obj, _database _objdb)
        //{
        //    return _objDLL.Load_SnagMaster("Load_SnagMaster", _obj, _objdb);
        //}
        //public DataTable Load_SnagSub(_clsSnag _obj, _database _objdb)
        //{
        //    return _objDLL.Load_SnagSub("Load_SnagDetails", _obj, _objdb);
        //}
        //public string Get_PkgCom_User(_clsSnag _obj, _database _objdb)
        //{
        //    return _objDLL.Get_PkgCom_User("Get_PkgCom_User", _obj, _objdb);
        //}
        //public DataTable Load_PkgCom_SubUser(_clsSnag _obj, _database _objdb)
        //{
        //    return _objDLL.Load_PkgCom_SubUser("Load_PkgCom_SubUser", _obj, _objdb);
        //}
        //public DataTable Load_SnagReport(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("Snag_Report", _obj, _objdb);
        //}
        //public DataSet load_dataset(_database _objdb)
        //{
        //    return _objDLL.load_dataset("loaddocumentsALL", _objdb);
        //}
        //public void Add_Photo_rpt(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Add_Photo_rpt("add_photo_rpt", _obj, _objdb);
        //}
        //public void Populate_SnagRpt(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Populate_SnagRpt("Snag_Report", _obj, _objdb);
        //}
        //public DataTable DR_Report(_database _objdb)
        //{
        //    return _objDLL.load_master("DR_Report", _objdb);
        //}
        //public void Generate_MS_RPT(_database _objdb)
        //{
        //    _objDLL.Generate_PRG_RPT("MS_RPT", _objdb);
        //}
        //public void CAS_PKG_SUM_RPT(_database _objdb)
        //{
        //    _objDLL.CAS_PKG_SUM_RPT("CAS_PKG_SUM_RPT", _objdb);
        //}
        //public DataTable LOAD_CAS_SERVICE_SUMMARY(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_CAS_SERVICE_SUMMARY("CAS_SERVICE_SUMMARY", _obj, _objdb);
        //}
        //public DataTable LOAD_CAS_PRJ_SUMMARY(_database _objdb)
        //{
        //    return _objDLL.LOAD_CAS_PRJ_SUMMARY("CAS_PRJ_SUMMARY", _objdb);
        //}
        //public void Insert_SummaryGraph(_clscassheet _obj, _database _objdb)
        //{
        //    _objDLL.Insert_SummaryGraph("Insert_Summary_Graph", _obj, _objdb);
        //}
        //public void Clear_CasRpt(_database _objdb)
        //{
        //    _objDLL.Clear_Rpt("Clear_CasRpt", _objdb);
        //}
        //public void Generate_CASsheet_RPT(_database _objdb)
        //{
        //    _objDLL.Generate_CASsheet_RPT("Cassheet_Report", _objdb);
        //}
        //public DataTable Load_CasServiceData(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_CasServiceData("Load_CasService_Data", _obj, _objdb);
        //}
        //public DataTable Load_SnagDetails_Stage1(_clsSnag _obj, _database _objdb)
        //{
        //    return _objDLL.Load_SnagDetails_Stage1("Load_SnagDetails_stage1", _obj, _objdb);
        //}
        //public void Update_SnagStage(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Update_SnagStage("Update_SnagStage", _obj, _objdb);
        //}
        //public DataTable Load_CMSUsers(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.Load_CMS_Users("Load_CMSUsers", _obj, _objdb);
        //}
        //public DataTable Load_UsersCompany(_clsproject _obj, _database _objdb)
        //{
        //    return _objDLL.Load_UsersCompany("Load_UsersCompany", _obj, _objdb);
        //}
        //public DataTable Load_AssetMaster(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AssetMaster("Load_Asset_Master", _obj, _objdb);
        //}
        //public string Get_TempSONo(_database _objdb)
        //{
        //    return _objDLL.Get_TempSONo("Get_TempSONo", _objdb);
        //}
        //public void DML_Manufacturer(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_Manufacturer("DML_Manufacturer", _obj, _objdb);
        //}
        //public DataTable Load_Manufacturer(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_manufacturer", _objdb);
        //}
        //public void DML_Supplier( _clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_Supplier("DML_Supplier", _obj, _objdb);
        //}
        ////public DataTable Load_Supplier(_database _objdb)
        ////{
        ////    return _objDLL.load_master("Load_supplier", _objdb);
        ////}
        //public DataTable Load_AssetInfo(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMSInfo("Load_Asset_Info", _obj, _objdb);
        //}
        //public void DML_AssetDetails(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_AssetDetails("DML_AssetDetails", _obj, _objdb);
        //}
        //public void DML_Purchase(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_Purchase("DML_Purchase", _obj, _objdb);
        //}
        //public void DML_Contractor(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_Contractor("DML_Contractor", _obj, _objdb);
        //}
        //public DataTable Load_Contractor(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_Contractor", _objdb);
        //}
        //public void DML_MaintenanceContract(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_MaintenanceContract("DML_Maintenance", _obj, _objdb);
        //}
        //public void DML_ElectricalDtls(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_ElectricalDtls("DML_ElectricalDetails", _obj, _objdb);
        //}
        //public void DML_MechanicalDtls(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_MechanicalDtls("DML_Mechanical_Details", _obj, _objdb);
        //}
        //public void DML_CivilDtls(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_CivilDtls("DML_CivilDetails", _obj, _objdb);
        //}
        //public DataTable Load_AMS_AssetDetails(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMSInfo("Load_AMS_AssetDetails", _obj, _objdb);
        //}
        //public DataTable Load_AMS_CivilDetails(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMSInfo("Load_AMS_CivilDetails", _obj, _objdb);
        //}
        //public DataTable Load_AMS_ElectricalDetails(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMSInfo("Load_AMS_ElectricalDetails", _obj, _objdb);
        //}
        //public DataTable Load_AMS_MechanicalDetails(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMSInfo("Load_AMS_MechanicalDetails", _obj, _objdb);
        //}
        //public DataTable Load_AMS_PurchaseDetails(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMSInfo("Load_AMS_PurchaseDetails", _obj, _objdb);
        //}
        //public DataTable Load_Schedules(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_ScheduleList("LoadSchedule_List", _obj, _objdb);
        //}
        //public DataTable Load_IndexFiles(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("Load_IndexFiles", _obj, _objdb);
        //}
        //public DataTable Load_PackageFolders(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("load_package", _obj, _objdb);
        //}
        //public DataTable Get_OMDetails(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_ScheduleList("Get_OMDetails", _obj, _objdb);
        //}
        //public void DML_CheckDates(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_CheckDates("DML_AMS_CheckDates", _obj, _objdb);
        //}
        //public string Get_CheckNames(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Get_CheckNames("Get_AMS_CheckName", _obj, _objdb);
        //}
        //public void Add_Task(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Add_Task("Add_AMS_Task", _obj, _objdb);
        //}
        //public DataTable Load_Ams_Task(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Ams_Task("Load_AMS_Task", _obj, _objdb);
        //}
        //public void Gen_AMS_Task_Rpt(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Gen_AMS_Task_Rpt("Generate_AMS_Task_Report", _obj, _objdb);
        //}
        //*********************************** TIS *********************************************
        //public DataTable LOAD_MASTER(_clstis _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_MASTER("LOAD_BUILDING", _obj, _objdb);
        //}
        //public DataTable LOAD_FLOOR(_clstis _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_FLOOR("LOAD_FLOOR", _obj, _objdb);
        //}
        //public DataTable LOAD_ZONE(_clstis _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_ZONE("LOAD_ZONE", _obj, _objdb);
        //}
        //public DataTable LOAD_TENANTS(_clstis _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_TENANTS("LOAD_TENANTS", _obj, _objdb);
        //}
        //public DataTable LOAD_FOLDER(_database _objdb)
        //{
        //    return _objDLL.LOAD_FOLDER("LOAD_FOLDER", _objdb);
        //}
        //public void DML_TENANCY_CONTRACT(_clstis _obj, _database _objdb)
        //{
        //    _objDLL.DML_TENANCY_CONTRACT("DML_TENANCY_CONTRACT", _obj, _objdb);
        //}
        //public DataTable LOAD_TENANCY_CONTRACT(_clstis _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_TENANCY_CONTRACT("LOAD_TENANCY_CONTRACT", _obj, _objdb);
        //}
        //public void DML_AUTHORITY_LETTER(_clstis _obj, _database _objdb)
        //{
        //    _objDLL.DML_AUTHORITY_LETTER("DML_AUTHORITY_LETTER", _obj, _objdb);
        //}
        //public DataTable LOAD_AUTHORITY_LETTER(_clstis _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_TENANCY_CONTRACT("LOAD_AUTHORITY_LETTER", _obj, _objdb);
        //}
        //public void DML_TC_DOCUMENTS(_clstis _obj, _database _objdb)
        //{
        //    _objDLL.DML_TC_DOCUMENTS("DML_TCDOCMENTS", _obj, _objdb);
        //}
        //public DataTable LOAD_TC_DOCUMENTS(_clstis _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_TENANCY_CONTRACT("LOAD_TC_DOCUMENTS", _obj, _objdb);
        //}
        //public DataTable LOAD_DATEREGISTER(_clstis _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_DATEREGISTER("LOAD_DATEREGISTER", _obj, _objdb);
        //}
        //public DataTable Load_PrjReference(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_PrjReference("Load_PrjReference", _obj, _objdb);
        //}
        //public void Edit_Task(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Edit_Task("Edit_AMS_Task", _obj, _objdb);
        //}
        //public void DML_SpareParts(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_SpareParts("DML_SpareParts", _obj, _objdb);
        //}
        //public DataTable Load_SpareParts(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_SpareParts("Load_SpareParts", _obj, _objdb);
        //}
        //public DataTable Load_AMSTaskList(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMSTaskList("Load_AMSTasks", _obj, _objdb);
        //}
        //public void Update_AMSCheckDates(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Update_AMSCheckDates("Update_AMSTaskDate", _obj, _objdb);
        //}
        //public void Add_SPBasket(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Add_SPBasket("Add_SPBasket", _obj, _objdb);
        //}
        //public DataTable Load_SPBasket(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_SPBasket("Load_SPBasket", _obj, _objdb);
        //}
        //public void Insert_TaskCompletion(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Insert_TaskCompletion("Task_Completion", _obj, _objdb);
        //}
        //public void Insert_SpUsed(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Insert_SpUsed("Insert_SpUsed", _obj, _objdb);
        //}
        //public void Delete_SPBasket(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Delete_SPBasket("Delete_SPBasket", _obj, _objdb);
        //}
        //public DataTable Load_BZone(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_CasAsset("Load_Bzones", _obj, _objdb);
        //}
        //public DataTable Load_FLevel(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_CasAsset("Load_FLevel", _obj, _objdb);
        //}
        //public DataTable Load_Cas_Docselection_AMS(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Cas_Docselection_AMS("Load_Cas_DocSelection_AMS", _obj, _objdb);
        //}
        //public DataTable Load_DMSDoc_AMS(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMSDoc_AMS("Load_DMSDocument_AMS", _obj, _objdb);
        //}
        //public void AMS_Register(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.AMS_Register("DML_AssetRegister", _obj, _objdb);
        //}
        //public string Get_Category(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Category("Get_Cate", _obj, _objdb);
        //}
        //public DataTable Load_Spareparts_Warning(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_Spareparts_Warning", _objdb);
        //}
        //public DataTable LOAD_AMS_SCHEDULE_TASK(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_AMS_SCHEDULE_TASK("LOAD_AMS_SCHEDULE_TASK", _obj, _objdb);
        //}
        //public DataTable Load_PPMS_Schedule_Daily(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_PPMS_Schedule_Daily", _objdb);
        //}
        //public void Insert_PPMSDaily_Temp(_database _objdb)
        //{
        //    _objDLL.Insert_PPMSDaily_Temp("INSERT_DAILYSCHEDULE_TEMP", _objdb);
        //}
        //public DataTable Load_PPMSSchedule_Temp(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_DailySchedule_Temp", _objdb);
        //}
        //public void Insert_TaskExtension(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.Insert_TaskExtension("Task_Extend", _obj, _objdb);
        //}
        //public void AMS_Document_Linking(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.AMS_Document_Linking("AMS_DOC_LINKING", _obj, _objdb);
        //}
        //public DataTable Load_AMS_Documents(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMS_Documents("Load_AMS_Documents", _obj, _objdb);
        //}
        //public DataTable Load_AMS_SubAssets(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMS_SubAssets("Load_AMS_SubAsset", _obj, _objdb);
        //}
        //public DataTable Load_Asset_Spareparts(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Asset_Spareparts("Load_Asset_Spareparts", _obj, _objdb);
        //}
        //public DataTable Load_Spareparts_Details(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Spareparts_Details("Load_Sparepart_Details", _obj, _objdb);
        //}
        //public void DML_AMS_System(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.DML_AMS_System("DML_AMS_System", _obj, _objdb);
        //}
        //public DataTable Load_AMS_System(_clsams _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AMS_System("Load_AMS_Systems", _obj, _objdb);
        //}
        //public void Generate_AmsRegister(_clsuser _obj, _database _objdb)
        //{
        //    _objDLL.Generate_AmsRegister("GENERATE_ASSETREGISTER", _obj, _objdb);
        //}
        //public DataTable Load_Precomm_Checklist(_clstestpack _obj, _database _objdb)
        //{
        //    return _objDLL.Load_TP_Details("Load_Precom_Checklist", _obj, _objdb);
        //}
        //public DataTable Load_Precomm_Checklist_List(_clstestpack _obj, _database _objdb)
        //{
        //    return _objDLL.Load_TP_Details("Load_Precom_Checklist_List", _obj, _objdb);
        //}
        //public void Set_Cassheet_Position(_clscassheet _obj, _database _objdb)
        //{
        //    _objDLL.Set_Cassheet_Position("Set_Cassheet_Possition", _obj, _objdb);
        //}
        //public DataTable LOAD_PROJECT_MODULE(_clsproject _obj, _database _objdb)
        //{
        //    return _objDLL.LOAD_PROJECT_MODULE("LOAD_PROJECTS_MODULE", _obj, _objdb);
        //}
        //public DataTable Load_Prj_BZ(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_prj_BZ", _objdb);
        //}
        //public DataTable Load_Prj_Flvl(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_prj_Flvl", _objdb);
        //}
        //public void Delete_DMS_Doc(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Delete_Doc("Delete_DMS_Document", _obj, _objdb);
        //}
        //public DataTable Load_AllServiceFolder(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AllServiceFolder("LoadAllServiceReminder", _obj, _objdb);
        //}
        //public DataTable Load_AllFolder_Documents(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMSDoc_AMS("LoadAllFolderDocuments", _obj, _objdb);
        //}
        //public void Insert_UserInbox(_clscommunication _obj, _database _objdb)
        //{
        //    _objDLL.Insert_UserInbox("Insert_UserInbox", _obj, _objdb);
        //}
        //public void Insert_UserOutbox(_clscommunication _obj, _database _objdb)
        //{
        //    _objDLL.Insert_UserOutbox("Insert_UserOutbox", _obj, _objdb);
        //}
        //public DataTable Load_UserInbox(_clscommunication _obj, _database _objdb)
        //{
        //    return _objDLL.Load_UserMessage("Load_UserInbox", _obj, _objdb);
        //}
        //public DataTable Load_UserOutbox(_clscommunication _obj, _database _objdb)
        //{
        //    return _objDLL.Load_UserMessage("Load_UserOutbox", _obj, _objdb);
        //}
        //public DataTable Load_Message(_clscommunication _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Message("Load_Message", _obj, _objdb);
        //}
        //public string Get_UserName(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.Get_UserName("Get_UserName", _obj, _objdb);
        //}
        //public void Inbox_MarkasRead(_clscommunication _obj, _database _objdb)
        //{
        //    _objDLL.Inbox_MarkasRead("MarkasRead", _obj, _objdb);
        //}
        //public int Get_UnreadInbox(_clscommunication _obj, _database _objdb)
        //{
        //    return _objDLL.Get_UnreadInbox("Get_UnreadMessageCount", _obj, _objdb);
        //}
        //public DataTable GENERATE_DIV_SUMMARY_SELECT(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.GENERATE_DIV_SUMMARY_SELECT("GENERATE_OVERALL_SUMMARY_BLDG_SELECT", _obj, _objdb);
        //}
        //public int Get_Servicefolder(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Package_Service("Get_Servicefolder", _obj, _objdb);
        //}

        //public DataTable Get_FolderDetails(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("Get_SubTreeFolders", _obj, _objdb);
        //}
        //public DataTable load_documentsFolderBased(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("load_AlldocumentsFolderBased", _obj, _objdb);
        //}
        //public int Get_DefaultService(_database _objdb)
        //{
        //    return _objDLL.Get_Default("Get_DefaultService", _objdb);
        //}
        //public int Get_DefaultCassheet(_database _objdb)
        //{
        //    return _objDLL.Get_Default("Get_DefaultCassheet", _objdb);
        //}
        //public DataTable load_AllDocumentsDirectFolder(_clstreefolder _obj, _database _objdb)   
        //{
        //    return _objDLL.Get_Folder_Details("load_AllDocumentsDirectFolder", _obj, _objdb);
        //}

        //public DataTable Get_Folder_Description(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("Get_folderdesc", _obj, _objdb);
        //}
        //public DataTable Load_Dms_Packages(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Dms_Packages("Load_dms_packages", _obj, _objdb);
        //}
        //public int Get_DefaultDMSsrv(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_DefaultDMSsrv("Get_DefaultService", _obj, _objdb);
        //}
        //public int Get_DefaultDMSpkg(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_DefaultDMSsrv("Get_DefaultPackage", _obj, _objdb);
        //}
        //public DataTable Load_AllsubFolders(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("load_AllsubFolders", _obj, _objdb);
        //}
        //public DataTable Get_DafaultMenuFolder(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_service("Get_DafaultMenuFolder", _obj, _objdb);
        //}
        //public DataTable Get_DafaultNavFolder(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("Get_DafaultNavFolder", _obj, _objdb);
        //}
        //public DataTable Get_folderProjectdescription1(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("Get_folderProjectdescription", _obj, _objdb);
        //}
        //public DataTable Get_CurrentUploadFolder(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("Get_CurrentUploadFolder", _obj, _objdb);
        //}
        //public DataTable Load_DocumentStatus(_database _objdb)
        //{
        //    return _objDLL.load_master("LoadDocumentStatus", _objdb);
        //}
        //public void FileUploadingNew(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.FileUploadingNew("FileUploadingNew", _obj, _objdb);
        //}
        //public DataTable GetDocumentVersion(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("GetDocumentVersion", _obj, _objdb);
        //}
        //public void FileUploading_New(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.FileUploading_New("FileUploading_New", _obj, _objdb);

        //}
        //public DataTable Generate_CAS_RPT_NEW(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_casMain("CASSHEET_RPT_NEW", _obj, _objdb);
        //}
        //public DataTable Generate_pkg_Summary_2(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.load_cas_panel("GENERATE_PKG_SUMMARY_2_1", _obj, _objdb);
        //}
        //public DataTable Generate_pkg_Summary_3(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.load_cas_panel("GENERATE_PKG_SUMMARY_3_1", _obj, _objdb);
        //}
        //public DataTable loadserviceDMS(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_service("loadserviceDMS", _obj, _objdb);
        //}
        //public void Update_documentdetails(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_documentdetails("Update_documentdetails", _obj, _objdb);
        //}
        //public DataTable Load_DocumentStyleMaster(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_DocumentStyleMaster", _objdb);
        //}
        //public DataTable GetDocumentVersion(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.load_document("GetDocumentVersion", _obj, _objdb);
        //}
        //public DataTable Load_CMLT_Projects(_database _objdb)
        //{
        //    return _objDLL.load_master("LoadCMLT_Projects", _objdb);
        //}
        //public DataTable Load_Prj_DefaultService(_database _objdb)
        //{
        //    return _objDLL.load_master("LOAD_PRJ_DEFAULT_SERVICE", _objdb);
        //}

        //public DataTable Load_DMSComments(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.load_comments("Load_DMSComments", _obj, _objdb);
        //}
        //public DataTable Get_DocumentDetails(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DocDatails("Get_DocumentDetails", _obj, _objdb);
        //}
        //public int Check_SubFolderDocumentsExists(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_CMS_TC_Count("Check_SubfolderDocumentsExists", _obj, _objdb);
        //}
        //public void Delete_DocumentNew(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Delete_DocumentNew("Delete_DocumentNew", _obj, _objdb);

        //}
        //public void Move_Tree_Folder_New(_clstreefolder _obj, _database _objdb)
        //{
        //    _objDLL.Move_Tree_Folder("Move_TreeFolderNew", _obj, _objdb);
        //}
        //public DataTable load_documentNew(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.load_document("loaddocumentsNew", _obj, _objdb);
        //}


        //public string Get_DocumentTitle(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_DocumentTitle("Get_DocumentTitle", _obj, _objdb);
        //}
        //public DataTable Get_FolderDetails(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMSDoc_AMS("Get_FolderDetails", _obj, _objdb);
        //}
        //public void dml_schedule_basket(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.dml_schedule_basket("DML_SCHEDULE_BASKET", _obj, _objdb);
        //}
        //public DataTable Load_ScheduleBasket(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_ScheduleBasket("LOAD_SCHEDULE_BASKET", _obj, _objdb);
        //}
        //public void Move_Folder(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Move_Folder("Manage_Folder", _obj, _objdb);
        //}
        //public void CreateDocSchedule(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.CreateDocSchedule("CreateSchedule_new", _obj, _objdb);
        //}
        //public void Create_Schedulebskt(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Create_Schedulebskt("CREATE_SCHEDULE_FROMBSKT", _obj, _objdb);
        //}
        //public int Check_DocumentStyleExists(_clsdocument _obj, _database _objdb)   
        //{
        //    return _objDLL.Get_CMS_TC_Count("Check_DocumentStyleExists", _obj, _objdb);
        //}

        //public void Delete_DocumentStyle(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Delete_DocumentStyle("Delete_DocumentStyleMaster_tbl", _obj, _objdb);

        //}
        //public int Check_Contractor_Exits(_clsmanufacture _obj, _database _objdb)
        //{
        //    return _objDLL.Check_Record_Exits("Check_Contractor_Exits", _obj, _objdb);
        //}
        //public DataTable Load_Document_Submit(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Document_Submit("Load_Document_Submit", _obj, _objdb);
        //}
        //public void Update_Document_Submit(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_Document_Submit("Update_Document_Submit", _obj, _objdb);
        //}
        //public DataTable Load_dms_user_email_New(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.load_dms_user_email("Load_dms_User_email_New", _obj, _objdb);
        //}
        //public void Insert_ProgressTracking(_clsProgressTracking _obj, _database _objdb)
        //{
        //    _objDLL.Insert_ProgressTracking("Insert_ProgressTracking", _obj, _objdb);
        //}
        //public DataTable Load_AllProgressTracking(_clsProgressTracking _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AllProgressTracking("Load_AllProgressTracking", _obj, _objdb);
        //}
        //public DataTable Get_ProgressTrackingDetails(_clsProgressTracking _obj, _database _objdb)
        //{
        //    return _objDLL.Get_ProgressTrackingDetails("Get_ProgressTrackingDetails", _obj, _objdb);
        //}
        //public DataTable Load_DMS_Report_Master(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMS_Report_Master("Load_dms_report_master", _obj, _objdb);
        //}
        //public void Update_Document_direct(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_Document_direct("Update_Document_direct", _obj, _objdb);
        //}
        //public void Update_Schedule_direct(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_Schedule_direct("Update_Schedule_Direct", _obj, _objdb);
        //}
        //public DataTable Get_DocumentFileName(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DocDatails("Get_DocumentFileName", _obj, _objdb);
        //}
        //public void Update_CommentStatus(_clsSnag _obj, _database _objdb)
        //{
        //    _objDLL.Update_Doc_Control("Update_CommentStatus", _obj, _objdb);
        //}
        //public void Update_CmlResponse(_clscomment _obj, _database _objdb)
        //{
        //    _objDLL.add_resp("Update_CmlResponse", _obj, _objdb);
        //}
        //public DataTable Get_ParentFolders(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMSDoc_AMS("Get_ParentFolders", _obj, _objdb);
        //}
        //public void Create_TreeFolderNew(_clstreefolder _obj, _database _objdb)
        //{
        //    _objDLL.Create_TreeFolderNew("Create_TreefolderNew", _obj, _objdb);
        //}
        //public DataTable Load_DMS_ParentFolders(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMSDoc_AMS("Load_DMS_ParentFolders", _obj, _objdb);
        //}
        //public void Delete_Tree_FolderNew(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Create_Schedulebskt("Delete_TreeFoldersNew", _obj, _objdb);
        //}
        //public DataTable Get_UserProjectPermission(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_usersrv("Get_UserProjectPermission", _obj, _objdb);
        //}
        //public void Update_DocumentStatus(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.SetDocStatus("Update_DocumentStatus", _obj, _objdb);
        //}
        //public DataTable load_ProgressTrackingsheet(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMS_Report_Master("load_ProgressTrackingsheet", _obj, _objdb);
        //}
        //public void Edit_Tree_FolderNew(_clstreefolder _obj, _database _objdb)
        //{
        //    _objDLL.Edit_Tree_Folder_New("Edit_TreeFolderNew", _obj, _objdb);
        //}
        //public DataTable Load_ManualQuick_View(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Document_Submit("Load_ManualQuick_View", _obj, _objdb);
        //}
        //public DataTable load_ManualQuickView_Report(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMS_Report_Master("load_ManualQuickView_Report", _obj, _objdb);
        //}

        //public void FileUploading_OM(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.FileUploading_New("FileUploading_OM", _obj, _objdb);

        //}
        //public void Update_ProgressTracking_tbl(_clsProgressTracking _obj, _database _objdb)
        //{
        //    _objDLL.Update_ProgressTracking_tbl("Update_ProgressTracking_tbl", _obj, _objdb);

        //}
        //public void Create_ProgressTreefolder(_clstreefolder _obj, _database _objdb)
        //{
        //    _objDLL.Create_TreeFolderNew("Create_ProgressTreefolder", _obj, _objdb);
        //}
        //public DataTable load_ProgressTreeFolder_Tbl(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_service("load_ProgressTreeFolder_Tbl", _obj, _objdb);
        //}
        //public DataTable Get_Progress_DraftIssueDate(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMSDoc_AMS("Get_Progress_DraftIssueDate", _obj, _objdb);
        //}
        //public DataTable LoadFolderSchedule(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("LoadFolderSchedule", _obj, _objdb);
        //}
        //public DataTable Load_Asset_Register(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_AssetRegister", _objdb);
        //}
        //public DataTable Load_dms_library_general(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_dms_library_general", _objdb);
        //}
        //public void Update_DocumentReviewtype(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.SetDocStatus("Update_DocumentReviewtype", _obj, _objdb);
        //}
        //public DataTable Load_DMS_TC_LinkDocument(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMS_TCDOC_SYS("Load_DMS_TC_LinkDocument", _obj, _objdb);
        //}
        //public DataTable Doc_Summary_Report_New(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("Doc_Summary_Report_New", _obj, _objdb);
        //}
        //public void dml_dms_library_general(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.dml_dms_library_general("dml_dms_library_general", _obj, _objdb);
        //}
        //public DataTable dms_manufacuter_general(_database _objdb)
        //{
        //    return _objDLL.load_master("load_manufacturer_general", _objdb);
        //}
        //public void addcomment_new(_clscomment _obj, _database _objdb)
        //{
        //    _objDLL.addcomment_new("addcomment_New", _obj, _objdb);
        //}
        //public void Editcomment_new(_clscomment _obj, _database _objdb)
        //{
        //    _objDLL.Editcomment_new("Editcomment_New", _obj, _objdb);
        //}

        //public DataTable load_CommentDetails(_clscomment _obj, _database _objdb)
        //{
        //    return _objDLL.load_CommentDetails("Load_commentDetails", _obj, _objdb);
        //}
        //public DataTable Generate_DocumentStatus(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_ScheduleList("Generate_DocumentStatus", _obj, _objdb);
        //}
        //public DataTable Load_dms_report_master_New(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMS_Report_Master("Load_dms_report_master_New", _obj, _objdb);
        //}
        //public void dml_amslocation(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.dml_amslocation("dml_location", _obj, _objdb);
        //}
        //public void dml_amsroom(_clsams _obj, _database _objdb)
        //{
        //    _objDLL.dml_amsroom("dml_room", _obj, _objdb);
        //}
        //public DataTable Load_amslocation(_database _objdb)
        //{
        //    return _objDLL.load_master("load_amslocation",_objdb);
        //}
        //public DataTable Load_amsroom(_database _objdb)
        //{
        //    return _objDLL.load_master("load_amsroom", _objdb);
        //}

        //public DataTable Get_DMS_LIBRARY_GENERAL_Details(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Load_System_List("Get_DMS_LIBRARY_GENERAL_Details", _obj, _objdb);
        //}
        //public void Insert_Manufaturer_tbl_General(_clsmanufacture _obj, _database _objdb)
        //{
        //    _objDLL.Create_Manufacture("Insert_MANUFACTURER_TBL_GENERAL", _obj, _objdb);
        //}
        //public void AddToProject_Library(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.AddToProject_Library("AddToProject_Library", _obj, _objdb);
        //}
        //public DataTable loadserviceDMS_Graph(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_service("loadserviceDMS_Graph", _obj, _objdb);
        //}
        //public DataTable Load_Document_Library_Project(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Document_Library_Project("Load_dms_library_project", _obj, _objdb);
        //}
        //public DataTable Generate_DocumentStatus_Other(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Generate_DocumentStatus_Other("Generate_DocumentStatus_Other", _obj, _objdb);
        //}
        //public DataTable UploadSummaryServiceList(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_service("UploadSummaryServiceList", _obj, _objdb);
        //}
        //public void Delete_Comment_Response(_clscomment _obj, _database _objdb)
        //{
        //    _objDLL.Deletecomment("Delete_Comment_Response", _obj, _objdb);
        //}
        //public void Move_Folder_New(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Move_Folder("Manage_Folder_New", _obj, _objdb);
        //}
        //public DataTable LoadSchedule_List_New(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_ScheduleList("LoadSchedule_List_New", _obj, _objdb);
        //}
        //public int Get_Document_Library_Count(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Document_Library_Count("Check_Document_Library_Exits", _obj, _objdb);
        //}

        //public DataTable Get_folderProjectdescription(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("Get_folderProjectdescription1", _obj, _objdb);
        //}
        //public DataTable load_AllDocumentsDirectFolder_TD(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("load_AllDocumentsDirectFolder_TD", _obj, _objdb);
        //}
        //public DataTable LoadAllDocuments_Service(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_ScheduleList("LoadAllDocuments_Service", _obj, _objdb);
        //}
        //public void Manage_Document_Position(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Move_Folder("Manage_Document_Position", _obj, _objdb);
        //}
        //public DataTable load_FolderDocuments(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("load_FolderDocuments", _obj, _objdb);
        //}
        //public void dml_dms_library_general_new(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.dml_dms_library_general_new("dml_dms_library_general_new", _obj, _objdb);
        //}
        //public DataTable Load_Buildinglevel_Navigation(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Buildinglevel_Navigation("Load_BuildingLevel_Navigation", _obj, _objdb);
        //}
        //public DataTable Load_CMS_Correspondance(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_CMS_Correspondance", _objdb);
        //}
        //public int Get_ServiceFolderType(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Package_Service("Get_ServiceFolderType", _obj, _objdb);
        //}
        //public void Insert_User_Log_Report(_clslog _obj, _database _objdb)
        //{
        //    _objDLL.Insert_User_Log_Report("Insert_Login_Report", _obj, _objdb);
        //}
        //public DataTable Load_User_Log_Period(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_User_Log_Period", _objdb);
        //}
        //public DataTable GENERATE_BUILDING_SUMMARY(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.GENERATE_BAREA_SUMMARY("GENERATE_SERVICE_SUMMARY_BLDNG", _obj, _objdb);
        //}
        //public int Get_NoofCas_Bldng(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Get_NoofCas_Bldng("Get_NoofCassheet_Bldng", _obj, _objdb);
        //}
        //public DataTable Get_DafaultNavFolder1(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Folder_Details("Get_DafaultNavFolder_4", _obj, _objdb);
        //}
        //public DataTable Load_AllProgressTracking1(_clsProgressTracking _obj, _database _objdb)
        //{
        //    return _objDLL.Load_AllProgressTracking("Load_AllProgressTracking1", _obj, _objdb);
        //}
        //public void Update_ProgressTracking_tbl1(_clsProgressTracking _obj, _database _objdb)
        //{
        //    _objDLL.Update_ProgressTracking_tbl("Update_ProgressTracking_tbl1", _obj, _objdb);

        //}
        //public DataTable Load_DR_SO_CommentLog(_clstreefolder _obj, _database _objdb)
        //{
        //    return _objDLL.Load_FolderTree_Cms("Load_SO_DR_Comment_Log", _obj, _objdb);
        //}
        //public DataTable Load_SO_Admin_Response(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_SO_Admin_Response", _objdb);
        //}
        //public DataTable Load_CMS_Document_New(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_CMS_Docs("Load_CMS_Document_New", _obj, _objdb);
        //}
        //public void Update_CMS_Document(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_CMS_Document("UpdateCMSDocDetails", _obj, _objdb);
        //}
        //public DataTable Get_Project_Logo(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_master("Get_Project_Logo", _obj, _objdb);
        //}
        //public DataTable load_ProgressTrackingsheet1(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DMS_Report_Master("load_ProgressTrackingsheet1", _obj, _objdb);
        //}
        //public DataTable load_DMSpackage(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_service("loadpackage1", _obj, _objdb);
        //}
        //public DataTable LoadDMSfolder(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.load_service("LoadDMSfolder", _obj, _objdb);
        //}
        /////////////so Image
        //public void Add_SO_PhotoImage_Basket(_clsSO _obj, _database _objdb)
        //{
        //    _objDLL.SO_PhotoImage("Insert_SO_Photo_Temp", _obj, _objdb);
        //}
        //public void Edit_SO_new(_clsSO _obj, _database _objdb)
        //{
        //    _objDLL.Edit_SO("Edit_SO_New", _obj, _objdb);
        //}
        //public DataTable load_TestPictureDB(_database _objdb)
        //{
        //    return _objDLL.load_master("load_TestPictureDB", _objdb);
        //}
        //public void SO_PhotoImage(_clsSO _obj, _database _objdb)
        //{
        //    _objDLL.SO_PhotoImage("add_so_photo", _obj, _objdb);
        //}
        //public void SaveTestPictureDB(_clsuser _obj, _database _objdb)
        //{
        //    _objDLL.SaveTestPictureDB("SaveTestPictureDB", _obj, _objdb);
        //}
        //public DataTable Load_Package_Summary_Details(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_Package_Summary_Details", _objdb);
        //}
        //////JD Changes
        ////public void Update_CMS_Doc_Inline(_clscmsdocument _obj, _database _objdb)
        ////{
        ////    _objDLL.Update_CMS_Doc_Inline("UpdateCMSDocInline", _obj, _objdb);
        ////}
        ////public void Save_CMS_Comments(_clscmscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.Save_CMS_Comments("Save_cms_comments", _obj, _objdb);
        ////}
        ////public void InsertCommentBasket(_clscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.InsertCommentBasket("InsertCommentBasket", _obj, _objdb);
        ////}

        ////public DataTable Load_CP_Comments(_clscmscomment _obj, _database _objdb)
        ////{
        ////    return _objDLL.Load_CP_Comments("Load_CP_Comments", _obj, _objdb);
        ////}
        ////public DataTable CT_Load_CMS_Document(_clscmsdocument _obj, _database _objdb)
        ////{
        ////    return _objDLL.Load_CMS_Docs("Load_CMS_Document_New", _obj, _objdb);
        ////}
        ////public void CT_Delete_CMS_Doc(_clsdocument _obj, _database _objdb)
        ////{
        ////    _objDLL.Delete_Doc("CT_Delete_CMS_Document", _obj, _objdb);
        ////}
        ////public void Delete_CMS_Comment(_clscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.Delete_CMS_Comment("Delete_CMS_Comment", _obj, _objdb);
        ////}
        ////public void Clear_Comment_Basket(_clscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.Clear_Comment_Basket("Clear_Comment_Basket", _obj, _objdb);
        ////}

        ///////New JJ DR
        ////public string DR_Saved(_clsdocreview _obj, _database _objdb)
        ////{
        ////    return _objDLL.DR_Saved("insert_DR_Saved", _obj, _objdb);
        ////}
        ////public void DR_Saved_Details(_clsdocreview _obj, _database _objdb)
        ////{
        ////    _objDLL.DR_Saved_Details("insert_DR_Saved_Details", _obj, _objdb);
        ////}
        ////public DataTable Load_DR_Saved(_clsuser _obj, _database _objdb)
        ////{
        ////    return _objDLL.Load_Document_Review_Log("Load_DR_Saved", _obj, _objdb);
        ////}
        ////public DataTable Load_DR_Saved_Details(_clsdocreview _obj, _database _objdb)
        ////{
        ////    return _objDLL.Load_Document_Review_Details("Load_DR_Saved_Details", _obj, _objdb);
        ////}
        ////public void Update_Comment_Response(_clscmscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.Update_Comment_Response("Update_Comment_Response", _obj, _objdb);
        ////}
        ////public void Update_Comment_Basket(_clscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.Update_Comment_Basket("Update_Comment_Basket", _obj, _objdb);
        ////}
        ////public DataTable Get_CMS_Settings(_clscmssettings _obj, _database _objdb)
        ////{
        ////    return _objDLL.Get_CMS_Settings("GetCMSSettings", _obj, _objdb);
        ////}
        ////public void Update_CMS_Settings(_clscmssettings _obj, _database _objdb)
        ////{
        ////    _objDLL.Update_CMS_Settings("UpdateCMSSettings", _obj, _objdb);
        ////}
        ////public void Update_CP_Comment(_clscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.Update_CP_Comment("Update_CP_Comment", _obj, _objdb);
        ////}
        ////public DataTable Load_CP_Comments_All(_clscmscomment _obj, _database _objdb)
        ////{
        ////    return _objDLL.Load_CP_Comments_All("Load_CP_Comments_All",_obj, _objdb);
        ////}

        ////public void UpdateCPCommentStatus(_clscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.UpdateCPCommentStatus("UpdateCPCommentStatus", _obj, _objdb);
        ////}
        ////public void Update_Issue_Comment(_clscomment _obj, _database _objdb)
        ////{
        ////    _objDLL.Update_Issue_Comment("Update_Issue_Comment", _obj, _objdb);
        ////}
        ////public void Document_Review_Details_New(_clsdocreview _obj, _database _objdb)
        ////{
        ////    _objDLL.Document_Review_Details_New("insert_doc_review_details_New", _obj, _objdb);
        ////}
        //public DataTable Load_CMS_DocumentAll(_database _objdb)
        //{
        //    return _objDLL.load_master("Load_CMS_DocumentAll", _objdb);
        //}
        //public void Delete_DMS_Document_New(_clsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Delete_DMS_Document_New("Delete_DMS_Document_New", _obj, _objdb);
        //}
        //public DataTable Generate_CAS_PKG_Summary_2(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Generate_CAS_PKG_Summary("GENERATE_CAS_PKG_SUMMARY_2", _obj, _objdb);
        //}
        //public void Issue_Unsaved_Comments(_clscmscomment _obj, _database _objdb)
        //{
        //    _objDLL.Issue_Unsaved_Comments("Issue_Unsaved_comments", _obj, _objdb);
        //}
        //public DataTable Get_MaxSeqNo(_database _objdb)
        //{
        //    return _objDLL.load_master("Get_MaxLibraryId", _objdb);
        //}
        //public DataTable Get_LibraryFileName(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DocDatails("Get_LibraryFileName", _obj, _objdb);
        //}
        //public int Check_Manufacture_Exits(_clsmanufacture _obj, _database _objdb)
        //{
        //    return _objDLL.Check_Record_Exits("Check_Manufacture_Exits", _obj, _objdb);
        //}


        //public DataTable Load_MS_Register(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_MS_Register("Load_MS_Register", _obj, _objdb);
        //}
        //public void Update_MS_Register_Inline(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_MS_Register_Inline("Update_MS_Register_Comment", _obj, _objdb);
        //}
        //public DataTable Load_MS_File_Tree(_database _objdb)
        //{
        //    return _objDLL.Load_MS_File_Tree("Load_MS_File_Tree", _objdb);
        //}
        //public DataTable Load_MS_Services(_database _objdb)
        //{
        //    return _objDLL.Load_MS_Services("Load_MS_Services", _objdb);
        //}
        //public void AddMSTreeNode(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.AddMSTreeNode("AddMSTreeNode", _obj, _objdb);
        //}
        //public void RenameMSTreeNode(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.RenameMSTreeNode("RenameMSTreeNode", _obj, _objdb);
        //}
        //public bool DeleteMSTreeNode(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.DeleteMSTreeNode("DeleteMSTreeNode", _obj, _objdb);
        //}
        //public void ShiftMSTreeNode(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.ShiftMSTreeNode("ShiftMSTreeNode", _obj, _objdb);
        //}
        //public void SaveMSFileTree(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.SaveMSFileTree("SaveMSSettings", _obj, _objdb);
        //}
        //public DataTable LoadMSFileTreeNav(_database _objdb)
        //{
        //    return _objDLL.LoadMSFileTreeNav("Load_MS_File_Tree_Nav", _objdb);
        //}
        //public DataTable Load_MS_Documents(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_MS_Documents("Load_MS_Documents", _obj, _objdb);
        //}
        //public void Update_MS_Register(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_MS_Register("UpdateMSRegister", _obj, _objdb);
        //}

        //public void Update_MS_Document(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_MS_Document("UpdateMSDocDetails", _obj, _objdb);
        //}

        //public DataTable Load_MS_Comments(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_MS_Comments("Load_MS_Comments", _obj, _objdb);
        //}

        //public void Issue_MS_Comments(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Issue_MS_Comments("Issue_MS_comments", _obj, _objdb);
        //}
        //public DataTable Get_Review_Document(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Review_Document("Get_Review_Document", _obj, _objdb);
        //}
        //public void ClearFileTreeBasket(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.ClearFileTreeBasket("ClearFileTreeBasket", _obj, _objdb);
        //}
        //public DataTable LoadMSStatusProgress(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.LoadMSStatusProgress("LoadMSStatusProgress", _obj, _objdb);
        //}
        //public void Update_Comment(_clscomment _obj, _database _objdb)
        //{
        //    _objDLL.Update_Comment("Update_Comment", _obj, _objdb);
        //}
        //public DataTable DeleteMSInfo(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.DeleteMSInfo("DeleteMSInfo", _obj, _objdb);
        //}
        //public DataTable Load_MM_Log(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_MM_Log("Load_MM_Log", _obj, _objdb);
        //}
        //public void Update_MM_Document(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Update_MM_Document("UpdateMMDocDetails", _obj, _objdb);
        //}
        //public DataTable Load_MM_Comments(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Load_MM_Comments("Load_MM_Comments", _obj, _objdb);
        //}
        //public void Issue_MM_Comments(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.Issue_MM_Comments("Issue_MM_comments", _obj, _objdb);
        //}
        //public DataTable LoadMMFileTreeNav(_database _objdb)
        //{
        //    return _objDLL.LoadMMFileTreeNav("Load_MM_File_Tree", _objdb);
        //}
        //public string DeleteCMSDocument(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.DeleteCMSDocument("DeleteCMSDocument", _obj, _objdb);
        //}
        //public void AddMMTreeNode(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.AddMMTreeNode("AddMMTreeNode", _obj, _objdb);
        //}
        //public void RenameMMTreeNode(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.RenameMMTreeNode("RenameMMTreeNode", _obj, _objdb);
        //}
        //public void DeleteMMTreeNode(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.DeleteMMTreeNode("DeleteMMTreeNode", _obj, _objdb);
        //}
        //public void ShiftMMTreeNode(_clscmsdocument _obj, _database _objdb)
        //{
        //    _objDLL.ShiftMMTreeNode("ShiftMMTreeNode", _obj, _objdb);
        //}
        //public DataTable SaveMMFileTree(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.SaveMMFileTree("SaveMMSettings", _obj, _objdb);
        //}

        ////-----------------------------------------

        //public void Update_SO_Details_New(_clsSO _obj, _database _objdb)
        //{
        //    _objDLL.Update_SO_Details_New("Update_So_Details", _obj, _objdb);
        //}
        //public string SO_Saved(_clsSO _obj, _database _objdb)
        //{
        //    return _objDLL.SO_Saved("insert_SO_Saved", _obj, _objdb);
        //}
        //public void SO_Saved_Details(_clsSO _obj, _database _objdb)
        //{
        //    _objDLL.SO_Saved_Details("insert_SO_Saved_Details", _obj, _objdb);
        //}
        //public DataTable Load_SO_Saved(_clsuser _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Document_Review_Log("Load_SO_Saved", _obj, _objdb);
        //}
        //public DataTable Load_SO_Saved_Main(_clsSO _obj, _database _objdb)
        //{
        //    return _objDLL.Load_SO_Details("Load_SO_Saved_Main", _obj, _objdb);
        //}
        //public DataTable Load_SO_Saved_Details(_clsSO _obj, _database _objdb)
        //{
        //    return _objDLL.Load_SO_Details("Load_SO_Saved_Details", _obj, _objdb);
        //}
        //public void So_Details_New(_clsSO _obj, _database _objdb)
        //{
        //    _objDLL.SO_Saved_Details("insert_so_details_New", _obj, _objdb);
        //}

        //public string Get_SODetails_Attachments(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_file("Get_SODetails_Attachments", _obj, _objdb);
        //}
        //public DataTable Load_DR_StatusGraph(_clsdocreview _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DR_StatusGraph("Load_DR_StatusGraph", _obj, _objdb);
        //}
        //public DataTable Load_DR_Saved_Main(_clsdocreview _obj, _database _objdb)
        //{
        //    return _objDLL.Load_Document_Review_Details("Load_DR_Saved_Main", _obj, _objdb);
        //}
        //public string Get_DRDetails_Attachments(_clscmsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.Get_file("Get_DRDetails_Attachments", _obj, _objdb);
        //}
        //public void Update_DR_Details_New(_clsdocreview _obj, _database _objdb)
        //{
        //    _objDLL.Update_DR_Details_New("Update_DR_Details", _obj, _objdb);
        //}
        //public DataTable Load_SO_StatusGraph(_clsdocreview _obj, _database _objdb)
        //{
        //    return _objDLL.Load_DR_StatusGraph("Load_SO_StatusGraph", _obj, _objdb);
        //}
        //public int ValidateDocumentRevision(_clsdocument _obj, _database _objdb)
        //{
        //    return _objDLL.ValidateDocumentRevision("ValidateDocumentRevision", _obj, _objdb);
        //}
        //public void Get_Executive_Summary_pcd(_clscassheet _obj, _database _objdb)
        //{
        //    _objDLL.Get_Executive_Summary_pcd("GET_EXECUTIVESUMMARY_PCD", _obj, _objdb);
        //}
        //Dashboard
        //public DataSet Get_Total_Executive_Summary_DashBoard(_clscassheet _obj, _database _objdb)
        //{
        //    return _objDLL.Get_Total_Executive_Summary_Dashboard("GET_TOTAL_EXECUTIVE_SUMMARY", _obj, _objdb);
        //}
        #endregion
    }
}
