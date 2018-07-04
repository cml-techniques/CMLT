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
using System.Threading.Tasks;

namespace CmlTechniques.CMS
{
    public partial class Dashboard_Print : System.Web.UI.Page   
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

            string _location = "";  

            foreach (DataRow dr in dt.Rows)
            {
                lblprojectprint.Text = dr["prj_name"].ToString();
                _location = dr["Location"].ToString();
            }
            if (string.IsNullOrEmpty(_location)) lblcmlhead.Text = "CML International LLC";
            else lblcmlhead.Text = "CML International (" + _location + ") LLC";
        }
        [WebMethod]
        //public static List<ChartDetails> GetChartData(string prj)
       public static async Task<List<ChartDetails>> GetChartData(string prj)
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
            DataTable ds = (DataTable)(HttpContext.Current.Session["GetChartData"]);
            List<ChartDetails> dataList = new List<ChartDetails>();
            foreach (DataRow dr in ds.Rows)
            {
                ChartDetails details = new ChartDetails
                {
                    Label = dr["CAS_NAME"].ToString(),
                    GraphActualData = Convert.ToDecimal(dr["PROGRESS"]),
                    //GraphPlannedData = Convert.ToDecimal(dr[2])
                };
                dataList.Add(details);
            }
            await Task.Yield();
            return dataList;
        }
        [WebMethod]
        //public static List<List<ServiceDetails>> GetServiceData(string prj)
            public static async Task<List<List<ServiceDetails>>> GetServiceData(string prj)
        {

            //List<int> list = _dtService.AsEnumerable().Where(x => (x.Field<int>("SYS_SER_ID") == 1 || x.Field<int>("SYS_SER_ID") == 2 || x.Field<int>("SYS_SER_ID") == 4)).Select(dr => dr.Field<int>("SYS_SER_ID")).ToList();
            List<List<ServiceDetails>> nestedlist = new List<List<ServiceDetails>>();


                DataTable _dt1 = (DataTable)(HttpContext.Current.Session["GetServiceData_1"]);

                //int count = _dt1.Tables.Count;
                List<ServiceDetails> datalist1 = new List<ServiceDetails>();
                List<ServiceDetails> datalist2 = new List<ServiceDetails>();
                List<ServiceDetails> datalist4 = new List<ServiceDetails>();
               List<ServiceDetails> datalist7 = new List<ServiceDetails>(); 
            foreach (DataRow dr in _dt1.Rows)
                {
                    ServiceDetails serdetails = new ServiceDetails
                    {
                        Label = dr["CAS_NAME"].ToString(),
                        Progress = Convert.ToDecimal(dr["AMOUNT"]),
                        //PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                        ID = Convert.ToInt32(dr["CAS_ID"])
                    };
                     datalist1.Add(serdetails);
                    }

                    nestedlist.Add(datalist1);


                    DataTable _dt2 = (DataTable)(HttpContext.Current.Session["GetServiceData_2"]);

                    foreach (DataRow dr in _dt2.Rows)
                    {
                        ServiceDetails serdetails = new ServiceDetails
                        {
                            Label = dr["CAS_NAME"].ToString(),
                            Progress = Convert.ToDecimal(dr["AMOUNT"]),
                            //PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                            ID = Convert.ToInt32(dr["CAS_ID"])
                        };
                        datalist2.Add(serdetails);

                    }
                nestedlist.Add(datalist2);

            DataTable _dt4 = (DataTable)(HttpContext.Current.Session["GetServiceData_7"]);

            foreach (DataRow dr in _dt4.Rows)
            {
                ServiceDetails serdetails = new ServiceDetails
                {
                    Label = dr["CAS_NAME"].ToString(),
                    Progress = Convert.ToDecimal(dr["AMOUNT"]),
                    //PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                    ID = Convert.ToInt32(dr["CAS_ID"])
                };
                datalist7.Add(serdetails);
            }
            nestedlist.Add(datalist7);

            DataTable _dt3 = (DataTable)(HttpContext.Current.Session["GetServiceData_3"]);

                foreach (DataRow dr in _dt3.Rows)
                {
                    ServiceDetails serdetails = new ServiceDetails
                    {
                        Label = dr["CAS_NAME"].ToString(),
                        Progress = Convert.ToDecimal(dr["AMOUNT"]),
                        //PlannedProgress = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                        ID = Convert.ToInt32(dr["CAS_ID"])
                    };
                    datalist4.Add(serdetails);
                }
                nestedlist.Add(datalist4);

            await Task.Yield();

            return nestedlist;
        }

        [WebMethod]
        //public static List<List<ChartDetails>> GetCasDetails(string prj)
        public static async Task<List<List<ChartDetails>>> GetCasDetails(string prj)
        {
            List<List<ChartDetails>> nestedlist = new List<List<ChartDetails>>();
            DataTable _dt1 = (DataTable)(HttpContext.Current.Session["GetCasDetails_1"]);

            List<ChartDetails> datalist1 = new List<ChartDetails>();

            foreach (DataRow dr in _dt1.Rows)
            {
                ChartDetails casdetails = new ChartDetails
                {
                    Label = dr["PKG_NAME"].ToString(),
                    //GraphPlannedData = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                    GraphActualData = Convert.ToDecimal(dr["Overall"]),
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
                    Label = dr["PKG_NAME"].ToString(),
                    //GraphPlannedData = Convert.ToDecimal(dr["PCOMPROGRESS"]),
                    GraphActualData = Convert.ToDecimal(dr["Overall"]),
                };
                datalist2.Add(casdetails);
            }
            nestedlist.Add(datalist2);


            await Task.Yield();
            return nestedlist;
        }
        [WebMethod]
        //public static List<CasSheetDetails> GetModalDetails(int casid, string prj)
              public static async Task<List<CasSheetDetails>> GetModalDetails(int casid, string prj)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database { DBName = "DB_" + prj };
            //Load_Cassheet(_objdb.DBName);
            List<CasSheetDetails> datalist1 = new List<CasSheetDetails>();
            //bool i = _dtCassheet.AsEnumerable().Where(x => x.Field<int>("PRJ_CAS_ID") == casid).Any();
            //if (i)
            //{
            //    _clscassheet _objcls = new _clscassheet();
            //    _objcls.sch = casid;
            //    _objcls.b_zone = "ALL";
            //    _objcls.cate = "ALL";
            //    _objcls.f_level = "ALL";
            //    _objcls.fed_from = "ALL";
            //    _objcls.loca = "ALL";
            //    _objcls.build_id = 0;
            //    _objcls.mode = 1;
            //    DataTable _dt1 = _objbll.Generate_CAS_Graph_Summary1(_objcls, _objdb);
            //    foreach (DataRow dr in _dt1.Rows)
            //    {
            //        CasSheetDetails casdetails = new CasSheetDetails
            //        {
            //            Label = dr["PKG_NAME"].ToString(),
            //            Progress = Convert.ToDecimal(dr["OVERALL"]),
            //        };
            //        datalist1.Add(casdetails);
            //    }

            //}
            await Task.Yield();
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
        //private static void Load_Cassheet(string prj)
        //{
        //    BLL_Dml _objbll = new BLL_Dml();
        //    _database _objdb = new _database
        //    {
        //        DBName = prj
        //    };
        //    _dtCassheet = _objbll.Load_Prj_Cassheet(_objdb);
        //}
    }

}