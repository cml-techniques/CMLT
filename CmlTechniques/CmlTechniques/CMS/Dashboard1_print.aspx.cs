using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Web.Services;
namespace CmlTechniques.CMS
{
    public partial class Dashboard1_print : System.Web.UI.Page
    {
        public static DataTable _dtService;
        public static DataTable _dtCassheet;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                Get_ProjectDetails();
            }
        }
        private void Get_ProjectDetails()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = lblprj.Text;
            DataTable dt = _objbll.Get_ProjectInformation(_objcls, _objdb);

            foreach (DataRow dr in dt.Rows)
            {
                //lblproject.Text = dr["prj_name"].ToString();
                lblprojectprint.Text = dr["prj_name"].ToString();

            }
        }
        [WebMethod(EnableSession = true)]
        public static List<ChartDetails> GetChartData(string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();

            _database _objdb = new _database
            {
                DBName = "DB_" + prj
            };
            _clscassheet _objcls = new _clscassheet
            {
                date = DateTime.Today,
                b_zone = "All",
                f_level = "All"
            };
            //DataSet ds = _objbll.GetDashBoardSummary(_objcls, _objdb);

            DataTable ds = (DataTable)(HttpContext.Current.Session["GetChartData"]);
           List <ChartDetails> dataList = new List<ChartDetails>();
            //int count = ds.Count;
            foreach (DataRow dr in ds.Rows)
            {
                ChartDetails details = new ChartDetails
                {
                    Label = dr[0].ToString(),
                    GraphActualData = Convert.ToDecimal(dr[1]),
                    GraphPlannedData = Convert.ToDecimal(dr[2])
                };
                dataList.Add(details);
            }
            return dataList;
        }
        [WebMethod]
        public static List<List<ServiceDetails>> GetServiceData(string prj)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database
            //{
            //    DBName = "DB_" + prj
            //};

            //Load_Service(_objdb.DBName);
            //List<int> list = _dtService.AsEnumerable().Where(x => (x.Field<int>("SYS_SER_ID") == 1 || x.Field<int>("SYS_SER_ID") == 2 || x.Field<int>("SYS_SER_ID") == 4)).Select(dr => dr.Field<int>("SYS_SER_ID")).ToList();
            List<List<ServiceDetails>> nestedlist = new List<List<ServiceDetails>>();
            //foreach (int i in list)
            //{
                //_clscassheet _objcls = new _clscassheet();
                // _objdb.DBName = 
                //_objcls.srv = i;
                //_objcls.date = DateTime.Today;
                //_objcls.b_zone = "ALL";
                ////_objcls.cate = "ALL";
                //_objcls.f_level = "ALL";
                //DataSet _dt1 = _objbll.GeneratePlannedServiceSummary(_objcls, _objdb);

            DataTable _dt1 = (DataTable)(HttpContext.Current.Session["GetServiceData_1"]);

                List<ServiceDetails> datalist1 = new List<ServiceDetails>();
                List<ServiceDetails> datalist2 = new List<ServiceDetails>();
                List<ServiceDetails> datalist4 = new List<ServiceDetails>();

                foreach (DataRow dr in _dt1.Rows)
                {
                    ServiceDetails serdetails = new ServiceDetails
                    {
                        Label = dr["PCKAGE"].ToString(),
                        Progress = Convert.ToDecimal(dr["COMPROGRESS"]),
                        PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                        ID = Convert.ToInt32(dr["ID"])
                    };
                datalist1.Add(serdetails);
                }
            nestedlist.Add(datalist1);

            DataTable _dt2 = (DataTable)(HttpContext.Current.Session["GetServiceData_2"]);

            foreach (DataRow dr in _dt2.Rows)
            {
                ServiceDetails serdetails = new ServiceDetails
                {
                    Label = dr["PCKAGE"].ToString(),
                    Progress = Convert.ToDecimal(dr["COMPROGRESS"]),
                    PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                    ID = Convert.ToInt32(dr["ID"])
                };
                datalist2.Add(serdetails);
            }
            nestedlist.Add(datalist2);

            DataTable _dt3 = (DataTable)(HttpContext.Current.Session["GetServiceData_3"]);

            foreach (DataRow dr in _dt3.Rows)
            {
                ServiceDetails serdetails = new ServiceDetails
                {
                    Label = dr["PCKAGE"].ToString(),
                    Progress = Convert.ToDecimal(dr["COMPROGRESS"]),
                    PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                    ID = Convert.ToInt32(dr["ID"])
                };
                datalist4.Add(serdetails);
            }
            nestedlist.Add(datalist4);


            //}
            return nestedlist;
        }
        [WebMethod]
        public static List<ExecutiveDetails> GetExecutiveData(string prj)
        {
            //BLL_Dml _objbll = new BLL_Dml();

            //_database _objdb = new _database
            //{
            //    DBName = "DB_" + prj
            //};
            List<ExecutiveDetails> datalist3 = new List<ExecutiveDetails>();

            //DataTable dsresult = _objbll.load_dashboarddummy(_objdb);
            DataTable dsresult = (DataTable)(HttpContext.Current.Session["GetExecutiveData"]);

            foreach (DataRow dr in dsresult.Rows)  //Tables[count - 1]
            {
                ExecutiveDetails execdetails = new ExecutiveDetails
                {
                    Label = dr["CAS_NAME"].ToString(),
                    ActualProgress = ((dr["PROGRESS"]) == DBNull.Value) ? (decimal?)null : Convert.ToDecimal(dr["PROGRESS"]),
                    PlannedProgress = ((dr["P_PROGRESS"]) == DBNull.Value) ? (decimal?)null : Convert.ToDecimal(dr["P_PROGRESS"])
                };
                datalist3.Add(execdetails);
            }
          
            return datalist3;
        }

        [WebMethod]
        public static List<List<ChartDetails>> GetCasDetails(string prj)
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database { DBName = "DB_" + prj };
            //Load_Cassheet(_objdb.DBName);
            //List<int> list = _dtCassheet.AsEnumerable().Where(x => (x.Field<int>("PRJ_CAS_ID") == 10 || x.Field<int>("PRJ_CAS_ID") == 20)).Select(dr => dr.Field<int>("PRJ_CAS_ID")).ToList();
            List<List<ChartDetails>> nestedlist = new List<List<ChartDetails>>();
            //foreach (int i in list)
            //{
            //    _clscassheet _objcls = new _clscassheet();
            //    _objcls.sch = i;
            //    _objcls.b_zone = "ALL";
            //    _objcls.cate = "ALL";
            //    _objcls.f_level = "ALL";
            //    _objcls.fed_from = "ALL";
            //    _objcls.loca = "ALL";
            //    _objcls.build_id = 0;
            //    _objcls.mode = 1;
            //    _objcls.date = DateTime.Today;
            //    DataSet _dt1 = _objbll.Generate_ProgressComparison_Graph(_objcls, _objdb);

            DataTable _dt1 = (DataTable)(HttpContext.Current.Session["GetCasDetails_1"]);

            List<ChartDetails> datalist1 = new List<ChartDetails>();
                foreach (DataRow dr in _dt1.Rows)
                {
                    ChartDetails casdetails = new ChartDetails
                    {
                        Label = dr["PCKAGE"].ToString(),
                        GraphPlannedData = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                        GraphActualData = Convert.ToDecimal(dr["COMPROGRESS"]),
                    };
                        datalist1.Add(casdetails);
                }
                    nestedlist.Add(datalist1);

            DataTable _dt2 = (DataTable)(HttpContext.Current.Session["GetCasDetails_2"]);

            List<ChartDetails> datalist2 = new List<ChartDetails>();
            foreach (DataRow dr in _dt2.Rows)
            {
                ChartDetails casdetails = new ChartDetails
                {
                    Label = dr["PCKAGE"].ToString(),
                    GraphPlannedData = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                    GraphActualData = Convert.ToDecimal(dr["COMPROGRESS"]),
                };
                datalist2.Add(casdetails);
            }
            nestedlist.Add(datalist2);

            return nestedlist;
        }
        [WebMethod]
        public static List<CasSheetDetails> GetModalDetails(int casid, string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database { DBName = "DB_" + prj };
            Load_Cassheet(_objdb.DBName);
            List<CasSheetDetails> datalist1 = new List<CasSheetDetails>();
            bool i = _dtCassheet.AsEnumerable().Where(x => x.Field<int>("PRJ_CAS_ID") == casid).Any();
            if (i)
            {
                _clscassheet _objcls = new _clscassheet();
                _objcls.sch = casid;
                _objcls.b_zone = "ALL";
                _objcls.cate = "ALL";
                _objcls.f_level = "ALL";
                _objcls.fed_from = "ALL";
                _objcls.loca = "ALL";
                _objcls.build_id = 0;
                _objcls.mode = 1;
                DataTable _dt1 = _objbll.Generate_CAS_Graph_Summary1(_objcls, _objdb);
                foreach (DataRow dr in _dt1.Rows)
                {
                    CasSheetDetails casdetails = new CasSheetDetails
                    {
                        Label = dr[6].ToString(),
                        Progress = Convert.ToDecimal(dr[5]),
                    };
                    datalist1.Add(casdetails);
                }

            }
            return datalist1;
        }
        private static void Load_Service(string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database
            {
                DBName = prj
            };
            _dtService = _objbll.Load_Prj_Service(_objdb);
        }
        private static void Load_Cassheet(string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database
            {
                DBName = prj
            };
            _dtCassheet = _objbll.Load_Prj_Cassheet(_objdb);
        }

        protected void Timer1_db_Tick(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "prints", "calls1();", true);
            //Timer1_db.Dispose();
        }
        //private static LoadData()
        //{

        //    return List;
        //}
    }

}