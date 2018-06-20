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
    public partial class Dashboard : System.Web.UI.Page
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
            DataTable dt= _objbll.Get_ProjectInformation(_objcls, _objdb);

            string _location = "";

            foreach(DataRow dr in dt.Rows)
            {
                lblproject.Text = dr["prj_name"].ToString();
                //lblprojectprint.Text = dr["prj_name"].ToString();
                _location= dr["Location"].ToString();

            }

            //if ( string.IsNullOrEmpty(_location)) lblcmlhead.Text = "CML International LLC";
            //else lblcmlhead.Text = "CML International (" + _location + ") LLC";


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
            DataSet ds = _objbll.GetDashBoardSummary(_objcls, _objdb);
            List<ChartDetails> dataList = new List<ChartDetails>();
            int count = ds.Tables.Count;
            HttpContext.Current.Session["GetChartData"] = ds.Tables[count - 1];
            foreach (DataRow dr in ds.Tables[count - 1].Rows)
            {
                ChartDetails details = new ChartDetails   
                {
                    Label = dr["CAS_NAME"].ToString(),
                    GraphActualData = Convert.ToDecimal(dr["PROGRESS"]),
                    //GraphPlannedData = Convert.ToDecimal(dr[2])
                };
                dataList.Add(details);
            }
            return dataList;
        }
        [WebMethod(EnableSession = true)]
        public static List<List<ServiceDetails>> GetServiceData(string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database
            {
                DBName = "DB_" + prj
            };

            Load_Service(_objdb.DBName);
            List<int> list = _dtService.AsEnumerable().Where(x => (x.Field<int>("SYS_SER_ID") == 1 || x.Field<int>("SYS_SER_ID") == 2 || x.Field<int>("SYS_SER_ID") == 3) || x.Field<int>("SYS_SER_ID") == 4).Select(dr => dr.Field<int>("SYS_SER_ID")).ToList();
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
                List<ServiceDetails> datalist7 = new List<ServiceDetails>();
                foreach (DataRow dr in _dt1.Tables[count - 1].Rows)
                {
                    ServiceDetails serdetails = new ServiceDetails
                    {
                        Label = dr["CAS_NAME"].ToString(),
                        Progress = Convert.ToDecimal(dr["AMOUNT"]),
                        //PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                        ID = Convert.ToInt32(dr["CAS_ID"])
                    };
                    if (i == 1)
                        datalist1.Add(serdetails);
                    else if (i == 2)
                        datalist2.Add(serdetails);
                    else if (i == 3)
                        datalist7.Add(serdetails);
                    else if (i == 4)
                        datalist4.Add(serdetails);

                }
                if (i == 1)
                {
                    nestedlist.Add(datalist1);
                    HttpContext.Current.Session["GetServiceData_1"] = _dt1.Tables[count - 1];
                }
                else if (i == 2)
                {
                    nestedlist.Add(datalist2);
                    HttpContext.Current.Session["GetServiceData_2"] = _dt1.Tables[count - 1];
                }
                else if (i == 3)
                {
                    nestedlist.Add(datalist7);
                    HttpContext.Current.Session["GetServiceData_7"] = _dt1.Tables[count - 1];
                }
                else if (i == 4)
                {
                    nestedlist.Add(datalist4);
                    HttpContext.Current.Session["GetServiceData_3"] = _dt1.Tables[count - 1];
                }

            }
            return nestedlist;
        }

        [WebMethod(EnableSession = true)]
        public static List<List<ChartDetails>> GetCasDetails(string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database { DBName = "DB_" + prj };
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
                        Label = dr["PKG_NAME"].ToString(),
                        //GraphPlannedData = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                        GraphActualData = Convert.ToDecimal(dr["Overall"]),
                    };
                    if (i == 10)
                        datalist1.Add(casdetails);
                    else if (i == 20)
                        datalist2.Add(casdetails);
                }
                if (i == 10)
                {
                    nestedlist.Add(datalist1);
                    HttpContext.Current.Session["GetCasDetails_1"] = _dt1.Tables[0];
                }
                else if (i == 20)
                {
                    nestedlist.Add(datalist2);
                    HttpContext.Current.Session["GetCasDetails_2"] = _dt1.Tables[0];
                }
            }
            return nestedlist;
        }
        [WebMethod(EnableSession = true)]
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
                        Label = dr["PKG_NAME"].ToString(),
                        Progress = Convert.ToDecimal(dr["OVERALL"]),
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