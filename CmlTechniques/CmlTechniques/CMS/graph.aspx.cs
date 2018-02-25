using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Drawing;
using GraphsLibrary;
//using CrystalDecisions.Web;

namespace CmlTechniques.CMS
{
    public partial class graph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _qry = Request.QueryString[0].ToString();
                if (_qry == "0")
                    load_data();
                else if (_qry == "1")
                    load_srv_data();
                else if (_qry == "2")
                    load_prj_data();
            }
        }
        protected void load_data()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            //info1.AddMergedColumns(new int[] { 1, 2 }, "Panel/Equipment Test");
            //info1.AddMergedColumns(new int[] { 3, 4 }, "Outgoing Circuit Test");
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            _objcas.sys = 1;
            //Graph2.DataSource = _objbll.Load_casMain_Graph(_objcas);
            //Graph2.Draw();

            //Chart1.DataSource = SqlDataSource1;
            //Chart1.Series["Series1"].XValueMember = "Euip";
            //Chart1.Series["Series1"].YValueMembers = "total";
            //// Data bind to the selected data source 
            //Chart1.DataBind();
            //Chart2.DataSource = SqlDataSource1;
            //Chart2.Series["Series2"].XValueMember = "Euip";
            //Chart2.Series["Series2"].YValueMembers = "total";
            //Chart2.DataBind();
            //Chart3.DataSource = SqlDataSource1;
            //Chart3.Series["Series2"].XValueMember = "Euip";
            //Chart3.Series["Series2"].YValueMembers = "total";
            //Chart3.DataBind();
            //Chart4.DataSource = SqlDataSource1;
            //Chart4.Series["Series2"].XValueMember = "Euip";
            //Chart4.Series["Series2"].YValueMembers = "total";
            //Chart4.DataBind();


            //if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            //{
               
            //    Chart4.Titles["t1"].Text = "CAS E5 Electrical Services. LV Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);

            //}
            //else if ((string)Session["sch"] == "2")
            //{


            //    Chart4.Titles["t1"].Text = "CAS E1 Electrical Services. HV-MV Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);

            //}
            //else if ((string)Session["sch"] == "6")
            //{


            //    Chart4.Titles["t1"].Text = "CAS E3 Electrical Services. Earthing & Lightning Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);

            //}
            //else if ((string)Session["sch"] == "3")
            //{

            //    Chart4.Titles["t1"].Text = "CAS E2 Electrical Services. HV & MV Transformers Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);


            //}
            //else if ((string)Session["sch"] == "4")
            //{

            //    Chart4.Titles["t1"].Text = "Generator - Electrical Services Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.Load_CasSummary(_objcas, _objdb);

            //}
            //else if ((string)Session["sch"] == "7")
            //{

            //    Chart4.Titles["t1"].Text = "Emergency Lightning - Electrical Services Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.Load_CasSummary_test(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "8")
            //{
            //    Chart4.Titles["t1"].Text = "CAS2 Mechanical Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "11")
            //{
            //    Chart4.Titles["t1"].Text = "CAS 9 ELV - Lighting Control Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "12")
            //{
            //    Chart4.Titles["t1"].Text = "CAS 11 ELV - Structured Cabling Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "13")
            //{
            //    Chart4.Titles["t1"].Text = "CAS 8 ELV - CCTV Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "17")
            //{
            //    Chart4.Titles["t1"].Text = "CAS PH1 Public Health Services Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "18")
            //{
            //    Chart4.Titles["t1"].Text = "CAS PH2 Fire Protection Services  Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "19")
            //{
            //    Chart4.Titles["t1"].Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "20")
            //{
            //    Chart4.Titles["t1"].Text = "CAS ELV 2 - BMS Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart4.DataSource = _objbll.LOAD_CAS_PKG_SUMMARY(_objcas, _objdb);
            //}
            //else if ((string)Session["sch"] == "12")
            //{
            //    Chart5.Titles["t1"].Text = "CAS PH3 Fire Extinguishing Systems Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart5.DataSource = _objbll.Load_CasSummary_test(_objcas,_objdb);

            //}
            //else if ((string)Session["sch"] == "14")
            //{
            //    Chart5.Titles["t1"].Text = "CAS ELV-BMS Commissioning Activity Schedule - " + (string)Session["projectname"];
            //    Chart5.DataSource = _objbll.Load_CasSummary_test(_objcas,_objdb);

            //}
            //Chart5.Series["Default"].XValueMember = "code";
            //Chart5.Series["Default"].YValueMembers = "total";
            //Chart5.Series["Default"].IsValueShownAsLabel=true;

            //Chart5.DataBind();



            //Chart4.Series["Series2"].XValueMember = "CATE_NAME";
            //Chart4.Series["Series2"].YValueMembers = "TOTAL";
            //Chart4.Series["Series2"].Label = "#VALY%";
            //Chart4.ChartAreas["ChartArea1"].AxisX.ScaleView.Size = 20;
            //Chart4.DataBind();

            
        }
        protected void load_srv_data()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.srv = Convert.ToInt32((string)Session["srv_id"]);
            //Chart4.Titles["t1"].Text = (string)Session["srv_name"] + " Commissioning Activity Schedule - " + (string)Session["projectname"];
            //Chart4.DataSource = _objbll.LOAD_CAS_SERVICE_SUMMARY(_objcas, _objdb);
            //Chart4.Series["Series2"].XValueMember = "PRJ_CAS_NAME";
            //Chart4.Series["Series2"].YValueMembers = "PROGRESS";
            //Chart4.Series["Series2"].Label = "#VALY%";
            //Chart4.DataBind();


        }
        protected void load_prj_data()
        {
           // BLL_Dml _objbll = new BLL_Dml();
           // _database _objdb = new _database();
           // _objdb.DBName = "DB_" + (string)Session["project"];
           // Chart4.Titles["t1"].Text = "Testing & Commissioning Summary - " + (string)Session["projectname"];
           // Chart4.DataSource = _objbll.LOAD_CAS_PRJ_SUMMARY(_objdb);
           // Chart4.Series["Series2"].XValueMember = "PRJ_SER_NAME";
           // Chart4.Series["Series2"].YValueMembers = "total";
           //// Chart4.Series["Series2"].IsValueShownAsLabel = true;
           // Chart4.Series["Series2"].Label = "#VALY%";

           // Chart4.DataBind();


        }   
    }
}
