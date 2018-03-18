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
    public partial class Dashboard1 : System.Web.UI.Page
    {
        public static DataTable _dtService;
        public static DataTable _dtCassheet;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblprj.Text = Request.QueryString["prj"].ToString();
                if (lblprj.Text == "ARSD")
                    lbl1.Text = "The Address Residence Sky View";
                if (lblprj.Text == "AFV")
                    lbl1.Text = "The Address Residence Fountain View";
                else if (lblprj.Text == "PCD")
                    lbl1.Text = "Planned Completion Date Development";
            }
        }
        [WebMethod]
        public static List<ChartDetails> GetChartData(string prj)
        {   
           BLL_Dml _objbll = new BLL_Dml();

            _database _objdb = new _database
            {
                DBName = "DB_"+ prj
            };
            _clscassheet _objcls = new _clscassheet
            {
                date = DateTime.Today,
                b_zone = "All",
                f_level = "All"
            };
            DataSet ds = _objbll.GetDashBoardSummary(_objcls, _objdb);
            List<ChartDetails> dataList = new List<ChartDetails>();
            int count = ds.Tables.Count;
            foreach (DataRow dr in ds.Tables[count - 1].Rows)
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
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database
            {
                DBName = "DB_"+ prj 
            };

            Load_Service(_objdb.DBName);
            List<int> list = _dtService.AsEnumerable().Where(x => (x.Field<int>("SYS_SER_ID") == 1 || x.Field<int>("SYS_SER_ID") == 2 || x.Field<int>("SYS_SER_ID") == 4)).Select(dr => dr.Field<int>("SYS_SER_ID")).ToList();
            List<List<ServiceDetails>> nestedlist = new List<List<ServiceDetails>>();
            foreach (int i in list)
            {
                _clscassheet _objcls = new _clscassheet();
               // _objdb.DBName = 
                _objcls.srv = i;
                _objcls.date = DateTime.Today;
                _objcls.b_zone = "ALL";
                //_objcls.cate = "ALL";
                _objcls.f_level = "ALL";
                DataSet _dt1 = _objbll.GeneratePlannedServiceSummary(_objcls, _objdb);
                int count = _dt1.Tables.Count;
                List<ServiceDetails> datalist1 = new List<ServiceDetails>();
                List<ServiceDetails> datalist2 = new List<ServiceDetails>();
                List<ServiceDetails> datalist4 = new List<ServiceDetails>();
                foreach (DataRow dr in _dt1.Tables[count - 1].Rows)
                {
                    ServiceDetails serdetails = new ServiceDetails
                    {
                        Label = dr["PCKAGE"].ToString(),
                        Progress = Convert.ToDecimal(dr["COMPROGRESS"]),
                        PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                        ID = Convert.ToInt32(dr["ID"])
                    };
                    if (i == 1)
                        datalist1.Add(serdetails);
                    else if (i == 2)
                        datalist2.Add(serdetails);
                    else if (i == 4)
                        datalist4.Add(serdetails);
                }
                if (i == 1)
                    nestedlist.Add(datalist1);
                else if (i == 2)
                    nestedlist.Add(datalist2);
                else if (i == 4)
                    nestedlist.Add(datalist4);
            }
            return nestedlist;
        }
        [WebMethod]
        public static List<ExecutiveDetails> GetExecutiveData(string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();

            _database _objdb = new _database
            {
                DBName = "DB_"+prj
            };
            List<ExecutiveDetails> datalist3 = new List<ExecutiveDetails>();
            if(prj == "PCD")
            {
                DataTable dsresult = _objbll.load_dashboarddummy(_objdb);
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
            }
                
            else if(prj == "ARSD")
            {
                _clscassheet _objcls = new _clscassheet();
                _objcls.mode = 1;
                var todaysdate = DateTime.Today;
                string from = DateTime.Today.AddMonths(-3).ToString("dd/MM/yyyy");
                string to = DateTime.Today.AddMonths(2).ToString("dd/MM/yyyy");
                _objcls.dtastart = DateTime.ParseExact(from, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                _objcls.dtpstart = DateTime.ParseExact(to, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                _objcls.cate = "Overall";
                DataSet dsresult = _objbll.Get_Total_Executive_Summary_DashBoard(_objcls, _objdb);
                int count = dsresult.Tables.Count;
                foreach (DataRow dr in dsresult.Tables[count-1].Rows)
                {
                    ExecutiveDetails execdetails = new ExecutiveDetails
                    {
                        Label = dr["CAS_NAME"].ToString(),
                        ActualProgress = ((dr["PROGRESS"]) == DBNull.Value) ? (decimal?)null : Convert.ToDecimal(dr["PROGRESS"]),
                        PlannedProgress = ((dr["P_PROGRESS"]) == DBNull.Value) ? (decimal?)null : Convert.ToDecimal(dr["P_PROGRESS"])
                    };
                    datalist3.Add(execdetails);
                }
            }           
            return datalist3;
        }

        [WebMethod]
        public static List<List<ChartDetails>> GetCasDetails(string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database { DBName = "DB_"+prj };
            Load_Cassheet(_objdb.DBName);
            List<int> list = _dtCassheet.AsEnumerable().Where(x => (x.Field<int>("PRJ_CAS_ID") == 10 || x.Field<int>("PRJ_CAS_ID") == 20)).Select(dr => dr.Field<int>("PRJ_CAS_ID")).ToList();
            List<List<ChartDetails>> nestedlist = new List<List<ChartDetails>>();
            foreach (int i in list)
            {
                _clscassheet _objcls = new _clscassheet();
                _objcls.sch = i;
                _objcls.b_zone = "ALL";
                _objcls.cate = "ALL";
                _objcls.f_level = "ALL";
                _objcls.fed_from = "ALL";
                _objcls.loca = "ALL";
                _objcls.build_id = 0;
                _objcls.mode = 1;
                _objcls.date = DateTime.Today;
                DataSet _dt1 = _objbll.Generate_ProgressComparison_Graph(_objcls, _objdb);
                List<ChartDetails> datalist1 = new List<ChartDetails>();
                List<ChartDetails> datalist2 = new List<ChartDetails>();
                foreach (DataRow dr in _dt1.Tables[0].Rows)
                {
                    ChartDetails casdetails = new ChartDetails
                    {
                        Label = dr["PCKAGE"].ToString(),
                        GraphPlannedData = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                        GraphActualData = Convert.ToDecimal(dr["COMPROGRESS"]),
                    };
                    if (i == 10)
                        datalist1.Add(casdetails);
                    else if (i == 20)
                        datalist2.Add(casdetails);
                }
                if (i == 10)
                    nestedlist.Add(datalist1);
                else if (i == 20)
                    nestedlist.Add(datalist2);
            }
            return nestedlist;
        }
        [WebMethod]
        public static List<CasSheetDetails> GetModalDetails(int casid,string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database { DBName = "DB_"+prj };
            Load_Cassheet(_objdb.DBName);
            List<CasSheetDetails> datalist1 = new List<CasSheetDetails>();
            bool i = _dtCassheet.AsEnumerable().Where(x => x.Field<int>("PRJ_CAS_ID") == casid).Any();
            if(i)
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
        //private static LoadData()
        //{
            
        //    return List;
        //}
    }

}