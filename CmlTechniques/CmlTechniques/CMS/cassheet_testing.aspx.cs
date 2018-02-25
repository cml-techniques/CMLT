using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Collections;

namespace CmlTechniques.CMS
{
    public partial class cassheet_testing : System.Web.UI.Page
    {
        [Serializable]
        private class minfo_
        {
            // indexes of merged columns
            public List<int> MergedColumns = new List<int>();
            // key-value pairs: key = the first column index, value = number of the merged columns
            public Hashtable StartColumns = new Hashtable();
            // key-value pairs: key = the first column index, value = common title of the merged columns 
            public Hashtable Titles = new Hashtable();

            //parameters: the merged columns indexes, common title of the merged columns 
            public void AddMergedColumns(int[] columnsIndexes, string title)
            {
                MergedColumns.AddRange(columnsIndexes);
                StartColumns.Add(columnsIndexes[0], columnsIndexes.Length);
                Titles.Add(columnsIndexes[0], title);
            }
        }
        private minfo_ info
        {
            get
            {
                if (ViewState["info"] == null)
                    ViewState["info"] = new minfo_();
                return (minfo_)ViewState["info"];
            }
        }
        private void RenderHeader(HtmlTextWriter output, Control container)
        {
            for (int i = 0; i < container.Controls.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[i];
                //stretch non merged columns for two rows
                if (!info.MergedColumns.Contains(i))
                {
                    cell.Attributes["rowspan"] = "2";
                    cell.RenderControl(output);
                }
                else //render merged columns common title
                    if (info.StartColumns.Contains(i))
                    {
                        output.Write(string.Format("<th align='center' colspan='{0}'>{1}</th>",
                                 info.StartColumns[i], info.Titles[i]));
                    }
            }

            //close the first row	
            output.RenderEndTag();
            //set attributes for the second row
            mygrid.HeaderStyle.AddAttributesToRender(output);
            //start the second row
            output.RenderBeginTag("tr");

            //render the second row (only the merged columns)
            for (int i = 0; i < info.MergedColumns.Count; i++)
            {
                TableCell cell = (TableCell)container.Controls[info.MergedColumns[i]];
                cell.RenderControl(output);
            }
        }

        public static DataTable _dtMaster;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Load_Master();
                Load_Cassheet();
                Merging();
                Load_Filtering_Elements();
                //Grouping();
                Session["filter"] = "no";
                Session["zone"] = "";
                Session["flvl"] = "";
                Session["cat"] = "";
                Session["fed"] = "";
            }
        }
        private void Load_Master()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch = Convert.ToInt32((string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            _dtMaster = _objbll.Load_casMain_Edit(_objcas, _objdb);
        }
        protected void Load_Cassheet()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcas = new _clscassheet();
            //_objcas.sch = Convert.ToInt32((string)Session["sch"]);
            //_objcas.prj_code = (string)Session["project"];
            ////info.AddMergedColumns(new int[] { 3, 4, 5, 6 }, "Asset Code");
            //mygrid.DataSource = _objbll.Load_casMain_Edit(_objcas,_objdb);
            //mygrid.DataBind();
            //GridViewHelper _help = new GridViewHelper(mygrid);
            //_help.RegisterGroup("Sys_name", true, true);
            //_help.GroupHeader += new GroupEvent(helper_GroupHeader);
            //_help.ApplyGroupSort();
            mygrid.DataSource = _dtMaster;
            mygrid.DataBind();
            GridViewHelper _help = new GridViewHelper(mygrid);
            _help.RegisterGroup("Sys_name", true, true);
            _help.GroupHeader += new GroupEvent(helper_GroupHeader);
            _help.ApplyGroupSort();

        }
        protected void Merging()
        {
            info.AddMergedColumns(new int[] { 3, 4, 5,6 }, "Asset Code");
        }
        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            if (groupName == "Sys_name")
            {
                row.BackColor = System.Drawing.Color.FromName("#b1dff6");
                row.Cells[0].Text = "&nbsp;&nbsp;" + row.Cells[0].Text;
                row.Height = 30;
            }

        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

        protected void mygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            mygrid.PageIndex = e.NewPageIndex;
            mygrid.DataBind();
        }

        protected void mygrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = mygrid.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                //dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                dataView.Sort = "Sys_id" + " " + ConvertSortDirectionToSql(e.SortDirection);

                mygrid.DataSource = dataView;
                mygrid.DataBind();
            }
        }
        protected void arrange_testing()
        {
            //if ((string)Session["sch"] == "1")
            //{
            //    pnlele.Visible = true;
            //    test1.Text = "Torque Test";
            //    test2.Text = "IR Test";
            //    test3.Text = "Pressure Test";
            //    test4.Text = "Secondary Injection Test";
            //    test5.Text = "Contact Resistance";
            //    test6.Text = "Funcational Test";
            //    test7.Text = "Site Panel Test Completed";
            //    test8.Text = "Total Cold Tested";
            //    test9.Text = "Cold Complete";
            //    test10.Text = "Total Live Tested";
            //    test11.Text = "Live Complete";
            //    BLL_Dml _objbll = new BLL_Dml();
            //    _database _objdb = new _database();
            //    _objdb.DBName = "DB_" + (string)Session["project"];
            //    _clscassheet _objcas = new _clscassheet();
            //    _objcas.sch = 1;
            //    _objcas.prj_code = (string)Session["project"];
            //    DataTable _dt = _objbll.Load_casMain_Edit(_objcas,_objdb);
            //    var result = from o in _dt.AsEnumerable()
            //                 where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
            //                 select o;
            //    foreach (var row in result)
            //    {
            //        date8.Text = row[14].ToString();
            //        date1.Text = row[24].ToString();
            //        date2.Text = row[25].ToString();
            //        date3.Text = row[26].ToString();
            //        date4.Text = row[27].ToString();
            //        date5.Text = row[28].ToString();
            //        date6.Text = row[29].ToString();
            //        dev1.Text = row[21].ToString();
            //        tested1.Text = row["tested1"].ToString();
            //        date11.Text = row[31].ToString();
            //        tested2.Text = row["tested2"].ToString();
            //        date13.Text = row[32].ToString();
            //        date14.Text = row[16].ToString();
            //        date15.Text = row[17].ToString();
            //    }

            //}
            //else if ((string)Session["sch"] == "11")
            //{
            //    pnlmech.Visible = true;
            //    BLL_Dml _objbll = new BLL_Dml();
            //    _database _objdb = new _database();
            //    _objdb.DBName = "DB_" + (string)Session["project"];
            //    _clscassheet _objcas = new _clscassheet();
            //    _objcas.sch = 11;
            //    _objcas.prj_code = (string)Session["project"];
            //    DataTable _dt = _objbll.Load_casMain_Edit(_objcas,_objdb);
            //    var result = from o in _dt.AsEnumerable()
            //                 where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
            //                 select o;
            //    foreach (var row in result)
            //    {
            //        date8.Text = row[14].ToString();
            //        precom1.Text = row[24].ToString();
            //        comm1.Text = row[25].ToString();
            //        witnessed1.Text = row[26].ToString();
            //        duty.Text = row[35].ToString();
            //        precom2.Text = row[27].ToString();
            //        comm2.Text = row[28].ToString();
            //        witnessed2.Text = row[29].ToString();
            //        date14.Text = row[16].ToString();
            //        date15.Text = row[17].ToString();
            //        comm.Text = row[18].ToString();
            //        actby.Text = row[19].ToString();
            //        date18.Text = row[20].ToString();
            //    }

            //}
            //else if ((string)Session["sch"] == "12")
            //{
            //    pnlph.Visible = true;
            //    BLL_Dml _objbll = new BLL_Dml();
            //    _database _objdb = new _database();
            //    _objdb.DBName = "DB_" + (string)Session["project"];
            //    _clscassheet _objcas = new _clscassheet();
            //    _objcas.sch = 12;
            //    _objcas.prj_code = (string)Session["project"];
            //    DataTable _dt = _objbll.Load_casMain_Edit(_objcas,_objdb);
            //    var result = from o in _dt.AsEnumerable()
            //                 where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
            //                 select o;
            //    foreach (var row in result)
            //    {
            //        date8.Text = row[14].ToString();
            //        phtest1.Text = row[24].ToString();
            //        phtest2.Text = row[25].ToString();
            //        phtest3.Text = row[26].ToString();
            //        phtest4.Text = row[27].ToString();
            //        date14.Text = row[16].ToString();
            //        date15.Text = row[17].ToString();
            //        comm.Text = row[18].ToString();
            //        actby.Text = row[19].ToString();
            //        date18.Text = row[20].ToString();
            //    }
                
            //}
            //else if ((string)Session["sch"] == "13")
            //{
            //    pnlfire.Visible = true;
            //    BLL_Dml _objbll = new BLL_Dml();
            //    _database _objdb = new _database();
            //    _objdb.DBName = "DB_" + (string)Session["project"];
            //    _clscassheet _objcas = new _clscassheet();
            //    _objcas.sch = 13;
            //    _objcas.prj_code = (string)Session["project"];
            //    DataTable _dt = _objbll.Load_casMain_Edit(_objcas,_objdb);
            //    var result = from o in _dt.AsEnumerable()
            //                 where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
            //                 select o;
            //    foreach (var row in result)
            //    {
            //        date8.Text = row[14].ToString();
            //        fairtested.Text = row[24].ToString();
            //        dvscomplete.Text = row[25].ToString();
            //        looptestcomplete.Text = row[26].ToString();
            //        soundlvltest.Text = row[27].ToString();
            //        batest.Text = row[28].ToString();
            //        ghetest.Text = row[29].ToString();
            //        dvstested.Text = row[35].ToString();
            //        no_dvs.Text = row[21].ToString();
            //        inface.Text = row[22].ToString();
            //        infacetested.Text = row[36].ToString();
            //        date14.Text = row[16].ToString();
            //        date15.Text = row[17].ToString();
            //        comm.Text = row[18].ToString();
            //        actby.Text = row[19].ToString();
            //        date18.Text = row[20].ToString();
            //    }
            //}
            //else if ((string)Session["sch"] == "14")
            //{
            //    pnlbms.Visible = true;
            //    BLL_Dml _objbll = new BLL_Dml();
            //    _database _objdb = new _database();
            //    _objdb.DBName = "DB_" + (string)Session["project"];
            //    _clscassheet _objcas = new _clscassheet();
            //    _objcas.sch = 14;
            //    _objcas.prj_code = (string)Session["project"];
            //    DataTable _dt = _objbll.Load_casMain_Edit(_objcas,_objdb);
            //    var result = from o in _dt.AsEnumerable()
            //                 where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
            //                 select o;
            //    foreach (var row in result)
            //    {
            //        date8.Text = row[14].ToString();
            //        pointcomplete.Text = row[24].ToString();
            //        bmsirtest.Text = row[25].ToString();
            //        bmspptest.Text = row[26].ToString();
            //        sqoptest.Text = row[27].ToString();
            //        bmsghetest.Text = row[28].ToString();
            //        bmspoints.Text = row[21].ToString();
            //        date14.Text = row[16].ToString();
            //        date15.Text = row[17].ToString();
            //        comm.Text = row[18].ToString();
            //        actby.Text = row[19].ToString();
            //        date18.Text = row[20].ToString();
            //    }
            //}
        }

        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int _rowidx = Convert.ToInt32(e.CommandArgument);
            ////GridViewRow _srow = mygrid.Rows[_rowidx +1];
            ////TableCell _item = _srow.Cells[12];
            //if (_rowidx < mygrid.Rows.Count-1)
            //    _rowidx += 1;
            //else
            //    _rowidx = mygrid.Rows.Count - 1;
            ////string _id = _item.Text;
            //Session["casid"] = mygrid.Rows[_rowidx].Cells[12].Text;
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["casid"] + "');", true);
            //arrange_testing();
            //btnDummy_ModalPopupExtender.Show();
            //GridViewHelper _help = new GridViewHelper(mygrid);
            //_help.RegisterGroup("Sys_name", true, true);
            //_help.GroupHeader += new GroupEvent(helper_GroupHeader);
            //_help.ApplyGroupSort();
            Load_Cassheet();
        }
        private void Update()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            _objcls.test1 = test1.Text;
            _objcls.test2 = test2.Text;
            _objcls.test3 = test3.Text;
            _objcls.test4 = test4.Text;
            _objcls.test5 = test5.Text;
            _objcls.test6 = test6.Text;
            _objcls.test7 = test7.Text;
            _objcls.test11 = test8.Text;
            _objcls.test12 = test10.Text;
            _objcls.test13 = test11.Text;
            _objcls.test14 = test12.Text;
            _objcls.test15 = "";
            _objcls.tested1 = notested1.Text;
            _objcls.test8 = testcomp1.Text;
            _objcls.tested2 = notested2.Text;
            _objcls.test9 = testcomp2.Text;
            _objcls.comm = txtcomment.Text;
            _objcls.act_by = actby.Text;
            _objcls.act_date = actdate.Text;
            _objcls.compl = "";
            _objcls.test10 = test9.Text ;
            _objcls.per_com1 = per_com1();
            _objcls.per_com2 = per_com2();
            _objcls.per_com3 = per_com3();
            _objcls.per_com4 = per_com4();
            _objcls.power_on = txtppon.Text;
            _objcls.dev1 = txtdevices1.Text;
            _objcls.accept1 = conaccept1.Text;
            _objcls.accept2 = conaccept2.Text;
            _objcls.filed1 = txtfiled1.Text;
            _objcls.filed2 = txtfiled.Text;
            _objbll.Cassheet_update(_objcls, _objdb);
            btnDummy_ModalPopupExtender.Hide();

        }
        private void Load_cassheet_details()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcas = new _clscassheet();
            _objcas.sch =Convert.ToInt32( (string)Session["sch"]);
            _objcas.prj_code = (string)Session["project"];
            DataTable _dt = _objbll.Load_casMain_Edit(_objcas, _objdb);
            var result = from o in _dt.AsEnumerable()
                         where o.Field<int>(0) == Convert.ToInt32((string)Session["casid"])
                         select o;
            foreach (var row in result)
            {
                txtppon.Text = row[14].ToString();
                if ((string)Session["sch"] == "20")
                {
                    test1.Text = row["devices2"].ToString();
                }
                else
                {
                    test1.Text = row[24].ToString();
                }
                test2.Text = row[25].ToString();
                test3.Text = row[26].ToString();
                test4.Text = row[27].ToString();
                test5.Text = row[28].ToString();
                test6.Text = row[29].ToString();
                txtdevices1.Text = row[21].ToString();
                notested1.Text = row["tested1"].ToString();
                testcomp1.Text = row[31].ToString();
                notested2.Text = row["tested2"].ToString();
                testcomp2.Text = row[32].ToString();
                conaccept1.Text = row["accept1"].ToString();
                txtfiled1.Text = row["filed1"].ToString();
                conaccept2.Text = row["accept2"].ToString();
                txtfiled.Text = row["filed2"].ToString();
                txtcomment.Text = row[18].ToString();
                actby.Text = row[19].ToString();
                actdate.Text = row[20].ToString();
                test9.Text = row["test10"].ToString();
                test7.Text = row["test7"].ToString();
                test8.Text = row["test11"].ToString();
                test10.Text = row["test12"].ToString();
                test11.Text = row["test13"].ToString();
                test12.Text = row["test14"].ToString();
            }
            if ((string)Session["sch"] == "8")
                txtdevices1.Text = String.Empty;
        }
        protected void Cassheet_Updation()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "DB_" + (string)Session["project"];
            //_clscassheet _objcls = new _clscassheet();
            //try
            //{
            //    _objcls.cas_id = Convert.ToInt32((string)Session["casid"]);
            //    _objcls.power_on = date8.Text;
            //    if ((string)Session["sch"] == "10")
            //    {
            //        _objcls.test1 = date1.Text;
            //        _objcls.test2 = date2.Text;
            //        _objcls.test3 = date3.Text;
            //        _objcls.test4 = date4.Text;
            //        _objcls.test5 = date5.Text;
            //        _objcls.test6 = date6.Text;
            //        _objcls.test7 = date7.Text;
            //        _objcls.tested1 = tested1.Text;
            //        _objcls.test8 = date11.Text;
            //        _objcls.tested2 = tested2.Text;
            //        _objcls.test9 = date13.Text;
            //    }
            //    else if ((string)Session["sch"] == "11")
            //    {
            //        _objcls.test1 = precom1.Text;
            //        _objcls.test2 = comm1.Text;
            //        _objcls.test3 = witnessed1.Text;
            //        _objcls.test4 = precom2.Text;
            //        _objcls.test5 = comm2.Text;
            //        _objcls.test6 = witnessed2.Text;
            //        _objcls.test7 = "";
            //        _objcls.tested1 =Decimal.Round(per_com1(),2).ToString();
            //        _objcls.test8 = "";
            //        _objcls.tested2 = "";
            //        _objcls.test9 = "";
            //    }
            //    else if ((string)Session["sch"] == "12")
            //    {
            //        _objcls.test1 = phtest1.Text;
            //        _objcls.test2 = phtest2.Text;
            //        _objcls.test3 = phtest3.Text;
            //        _objcls.test4 = phtest4.Text;
            //        _objcls.test5 = "";
            //        _objcls.test6 = "";
            //        _objcls.test7 = "";
            //        _objcls.tested1 = "";
            //        _objcls.test8 = "";
            //        _objcls.tested2 = "";
            //        _objcls.test9 = "";
            //    }
            //    else if ((string)Session["sch"] == "13")
            //    {
            //        _objcls.test1 = fairtested.Text;
            //        _objcls.test2 = dvscomplete.Text;
            //        _objcls.test3 = looptestcomplete.Text;
            //        _objcls.test4 = soundlvltest.Text;
            //        _objcls.test5 = batest.Text;
            //        _objcls.test6 = ghetest.Text;
            //        _objcls.test7 = "";
            //        _objcls.tested1 = dvstested.Text;
            //        _objcls.test8 = "";
            //        _objcls.tested2 = infacetested.Text; ;
            //        _objcls.test9 = "";
            //    }
            //    else if ((string)Session["sch"] == "14")
            //    {
            //        _objcls.test1 = pointcomplete.Text;
            //        _objcls.test2 = bmsirtest.Text;
            //        _objcls.test3 = bmspptest.Text;
            //        _objcls.test4 = sqoptest.Text;
            //        _objcls.test5 = bmsghetest.Text;
            //        _objcls.test6 = "";
            //        _objcls.test7 = "";
            //        _objcls.tested1 = "";
            //        _objcls.test8 = "";
            //        _objcls.tested2 = ""; ;
            //        _objcls.test9 = "";
            //    }
            //    _objcls.con_acce = date14.Text;
            //    _objcls.ts_filed = date15.Text;
            //    _objcls.comm = comm.Text;
            //    _objcls.act_by = actby.Text;
            //    _objcls.act_date = date18.Text;
            //    _objcls.compl = "";
            //    _objcls.test10 = "";
            //    _objcls.per_com1 = per_com1();
            //    _objcls.per_com2 = per_com2();
            //    _objcls.per_com3 = per_com3();                
            //    _objbll.Cassheet_update(_objcls,_objdb);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //btnDummy_ModalPopupExtender.Hide();
        }
        protected decimal per_com1()
        {
            
            decimal _percentage=0;
            //if ((string)Session["sch"] == "1")
            //{
            //    //int test = 0;
            //    //if(test1.Text!="" && test1.Text!)
            //}
            int count = 0;
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            {
                if (txtdevices1.Text == "") return 0;
                if (test1.Text != "")
                    count += 1;
                if (test2.Text != "")
                    count += 1;
                if (test3.Text != "")
                    count += 1;
                if (test4.Text != "")
                    count += 1;
                if (test5.Text != "")
                    count += 1;
                if (test6.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 6) * 100;
            }
            else if ((string)Session["sch"] == "2")
            {
                
                if (test1.Text != "")
                    count += 1;
                if (test2.Text != "")
                    count += 1;
                if (test3.Text != "")
                    count += 1;
                if (test4.Text != "")
                    count += 1;
                if (test5.Text != "")
                    count += 1;
                if (test6.Text != "")
                    count += 1;
                if (test7.Text != "")
                    count += 1;
                if (test8.Text != "")
                    count += 1;
                if (test10.Text != "")
                    count += 1;
                if (test11.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 10) * 100;
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "17")
            {
                //if (test1.Text != "")
                //    count += 1;
                //if (test2.Text != "")
                //    count += 1;
                ////if (test3.Text != "")
                ////    count += 1;
                //_percentage = (Convert.ToDecimal(count) / 2) * 100;
                if (test1.Text != "")
                    _percentage = 1;
            }
            else if ((string)Session["sch"] == "4")
            {
                if (txtdevices1.Text == "") return 0;
                if (test1.Text != "")
                    count += 1;
                if (test2.Text != "")
                    count += 1;
                if (test3.Text != "")
                    count += 1;
                if (test4.Text != "")
                    count += 1;
                if (test5.Text != "")
                    count += 1;
                if (test6.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 6) * 100;
            }
            else if ((string)Session["sch"] == "3")
            {
                if (test1.Text != "")
                    count += 1;
                if (test2.Text != "")
                    count += 1;
                if (test3.Text != "")
                    count += 1;
                if (test4.Text != "")
                    count += 1;
                if (test5.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 5) * 100;
            }
            else if ((string)Session["sch"] == "6")
            {
                if (test1.Text != "" || txtdevices1.Text!="")
                    _percentage = 100;
            }
            else if ((string)Session["sch"] == "18")
            {
                if (txtdevices1.Text == "") return 0;
                _percentage = Convert.ToInt32(txtdevices1.Text);
               
            }
            else if ((string)Session["sch"] == "19")
            {
                if (test1.Text != "")
                    count += 1;
                if (test2.Text != "")
                    count += 1;
                if (test3.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 3) * 100;

            }
            else if ((string)Session["sch"] == "20")
            {
                if (test1.Text == "") return 0;
                if (test2.Text != "")
                {
                    _percentage = Convert.ToInt32(test2.Text);
                }
                else
                    _percentage = 0;

            }

            else if ((string)Session["sch"] == "11" || (string)Session["sch"] == "13")
            {
                if (test1.Text != "")
                {
                    _percentage = Convert.ToInt32(test1.Text);
                }
                else
                    _percentage = 0;
            }
            return _percentage;
        }
        protected decimal per_com2()
        {
            
            decimal _percentage = 0;
            int count = 0;
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            {
                if (txtdevices1.Text == "") return 0;
                if (notested1.Text == "")
                    notested1.Text = "0";
                _percentage = (Convert.ToDecimal(notested1.Text) / Convert.ToDecimal(txtdevices1.Text)) * 100;
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "17")
            {
                //if (txtdevices1.Text != "")
                //    count += 1;
                //if (notested1.Text != "")
                //    count += 1;
                //if (testcomp1.Text != "")
                //    count += 1;
                //_percentage = (Convert.ToDecimal(count) / 3) * 100;
                if (test2.Text != "")
                    _percentage = 1;
            }
            else if ((string)Session["sch"] == "4")
            {
                if (txtdevices1.Text == "") return 0;
                if (notested1.Text == "")
                    notested1.Text = "0";
                _percentage = (Convert.ToDecimal(notested1.Text) / Convert.ToDecimal(txtdevices1.Text)) * 100;
            }
            else if ((string)Session["sch"] == "2" || (string)Session["sch"] == "3")
            {
                if (txtdevices1.Text == "") return 0;
                _percentage = 100;
            }
            else if ((string)Session["sch"] == "6")
            {
                if (test6.Text != "" || test9.Text != "")
                    _percentage = 100;
            }
            else if ((string)Session["sch"] == "18")
            {
                if (notested1.Text == "") return 0;
                _percentage = Convert.ToInt32(notested1.Text);

            }
            else if ((string)Session["sch"] == "20")
            {
                if (notested1.Text == "") return 0;
                _percentage = Convert.ToInt32(notested1.Text);
               

            }
            else if ((string)Session["sch"] == "11" || (string)Session["sch"] == "13")
            {
                if (test2.Text != "")
                {
                    _percentage = Convert.ToInt32(test2.Text);
                }
                else
                    _percentage = 0;
            }
            else if ((string)Session["sch"] == "12")
            {
                if (test1.Text != "")
                {
                    _percentage = Convert.ToInt32(test1.Text);
                }
                else
                    _percentage = 0;
            }
            return _percentage;
        }
        protected decimal per_com3()
        {
            //if (dev1.Text == "") return 0;
            decimal _percentage = 0;
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            {
                if (notested2.Text == "")
                    notested2.Text = "0";
                if (notested2.Text.ToUpper() == "NA")
                    _percentage = 101;
                else
                    _percentage = (Convert.ToDecimal(notested2.Text) / Convert.ToDecimal(txtdevices1.Text)) * 100;
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "17" )
            {
                if (test3.Text != "")
                    _percentage = 1;
            }
            else if ((string)Session["sch"] == "20")
            {
                if (notested2.Text == "") return 0;
                _percentage = Convert.ToInt32(notested2.Text);


            }
            else if ((string)Session["sch"] == "11" || (string)Session["sch"] == "13")
            {
                if (test3.Text != "")
                {
                    _percentage = Convert.ToInt32(test3.Text);
                }
                else
                    _percentage = 0;
            }
           
            return _percentage;
        }
        protected decimal per_com4()
        {
            //if (dev1.Text == "") return 0;
            decimal _percentage = 0;
            int count = 0;
            if ((string)Session["sch"] == "6" )
            {
                if (test9.Text != "")
                    _percentage = 100;
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "17")
            {
                if (txtdevices1.Text != "")
                    count += 1;
                if (notested1.Text != "")
                    count += 1;
                _percentage = (Convert.ToDecimal(count) / 2) * 100;
            }
            else if ((string)Session["sch"] == "20")
            {
                if (testcomp2.Text == "") return 0;
                _percentage = Convert.ToInt32(testcomp2.Text);
            }
            else if ((string)Session["sch"] == "13")
            {
                if (test4.Text != "")
                {
                    _percentage = Convert.ToInt32(test4.Text);
                }
                else
                    _percentage = 0;
            }
            return _percentage;
        }
        protected void date2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void date5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void date14_TextChanged(object sender, EventArgs e)
        {

        }

        protected void date15_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //Cassheet_Updation();
            Update();
            //DateTime _date = Convert.ToDateTime(date1.Text.ToString());
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _date + "');", true);
            Load_Cassheet();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
            Load_Cassheet();
        }

        protected void mygrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
        }

        protected void mygrid_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Session["casid"] = mygrid.SelectedIndex.ToString();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + (string)Session["casid"] + "');", true);
        }

        protected void mygrid_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void mygrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            
        }

        protected void mygrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Session["casid"] = mygrid.Rows[e.RowIndex].Cells[12].Text;
           // string _data = mygrid.Rows[e.RowIndex].Cells[2].Text;
           //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _data + "');", true);
            Session["idx"] = e.RowIndex.ToString();
            arrange_testing();
           // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('I'm Here!');", true);

            Load_cassheet_details();
            Config_TestLabel();
            btnDummy_ModalPopupExtender.Show();
            //Load_Cassheet();
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[12].Visible = false;
            //if ((string)Session["sch"] == "1")
            //{
            //    // e.Row.Cells[11].Visible = true;
            //    //e.Row.Cells[10].Visible = false;
            //    //e.Row.Cells[8].Visible = false;
            //    mygrid.Columns[11].HeaderText = "No. of Circuits";
            //}
            //else if ((string)Session["sch"] == "11")
            //{
            //    //e.Row.Cells[11].Visible = true;
            //    e.Row.Cells[11].Visible = false;
            //    mygrid.Columns[10].HeaderText = "Description";
            //    e.Row.Cells[8].Visible = false;
            //}
            //else if ((string)Session["sch"] == "12")
            //{
            //    e.Row.Cells[10].Visible = false;
            //    e.Row.Cells[11].Visible = false;
            //    e.Row.Cells[8].Visible = false;
            //}
            //else if ((string)Session["sch"] == "13")
            //{
            //    e.Row.Cells[9].Visible = false;
            //    e.Row.Cells[8].Visible = false;
            //    mygrid.Columns[10].HeaderText = "No. of Devices";
            //    mygrid.Columns[11].HeaderText = "No. of Interfaces";
            //}
            //else if ((string)Session["sch"] == "14")
            //{
            //    e.Row.Cells[8].Visible = false;
            //    e.Row.Cells[9].Visible = false;
            //    mygrid.Columns[10].HeaderText = "System Controlled/Monitored by DCC";
            //    mygrid.Columns[11].HeaderText = "No. of Points";
            //}
            //if (e.Row.Cells[1].Text != "") return;
            //e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            ////e.Row.Cells[11].Visible = false;
            if ((string)Session["sch"] == "1" || (string)Session["sch"] == "5")
            {
                // e.Row.Cells[11].Visible = true;
                //e.Row.Cells[10].Visible = false;
                //e.Row.Cells[8].Visible = false;
                //mygrid.Columns[11].HeaderText = "No.of Circuits";
                lbl1.Text = "PROVIDES POWER TO";
                lbl3.Text = "FED FROM";
                lbl2.Text = "SUBSTATION";
                lbnum.Text = "NO.OF CIRCUITS";
                
            }
            else if ((string)Session["sch"] == "2")
            {
                //e.Row.Cells[11].Visible = true;
                //e.Row.Cells[11].Visible = false;
                mygrid.Columns[10].HeaderText = "Substation";
                //e.Row.Cells[8].Visible = false;
                lbl1.Text = "PROVIDES POWER TO";
                lbl3.Text = "FED FROM";
                
            }
            else if ((string)Session["sch"] == "3")
            {
                //e.Row.Cells[9].Visible = false;
                mygrid.Columns[10].HeaderText = "Area";
                //e.Row.Cells[11].Visible = false;
                //e.Row.Cells[7].Visible = false;
                lbl1.Text = "PROVIDES POWER TO";
                lbl3.Text = "FED FROM";
                lbl2.Text = "AREA";
            }
            else if ((string)Session["sch"] == "4")
            {
                mygrid.Columns[11].HeaderText = "No.of Circuits";
            }
            else if ((string)Session["sch"] == "6")
            {
                //e.Row.Cells[9].Visible = false;
                mygrid.Columns[8].HeaderText = "Provides Earthing to";
                //e.Row.Cells[10].Visible = false;
                //e.Row.Cells[11].Visible = false;
                lbl1.Text = "PROVIDES EARTHING TO";
               

            }
            else if ((string)Session["sch"] == "7")
            {
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[10].Visible = false;
                mygrid.Columns[11].HeaderText = "No. of Emergency Lights";
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "9" || (string)Session["sch"] == "17")
            {
                e.Row.Cells[8].Visible = false;
                //e.Row.Cells[11].Visible = false;
                mygrid.Columns[10].HeaderText = "Description";
                lbl1.Text = "FED FROM";
                lbl3.Text = "DESCRIPTION";
            }
            else if ((string)Session["sch"] == "10")
            {
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                mygrid.Columns[10].HeaderText = "No.of Devices";
                mygrid.Columns[11].HeaderText = "No.of Interfaces";
            }
            else if ((string)Session["sch"] == "16")
            {
                mygrid.Columns[8].HeaderText = "Sys. Controlled/Monitored";
                mygrid.Columns[9].HeaderText = "Fed From";
                mygrid.Columns[10].HeaderText = "No.of Points";
                mygrid.Columns[11].HeaderText = "No.of Interfaces";
                lbl1.Text = "SYS.CONTROLLED/ MONITORED";
                lbl3.Text = "FED FROM";
                lbl2.Text = "NO.OF POINTS";
                lbnum.Text = "NO.OF INTERFACES";
            }
            else if ((string)Session["sch"] == "18")
            {
               
                lbl3.Text = "DESCRIPTION";
                lbnum.Text = "QUANTITY";
            }
            else if ((string)Session["sch"] == "20")
            {
                e.Row.Cells[9].Visible = false;
                lbl1.Text = "SYS.CONTROLLED/ MONITORED";
                lbl3.Text = "NO.OF 240V CIRCUITS";
                lbl2.Text = "NO.OF POINTS";
                lbnum.Text = "";
            }
            else if ((string)Session["sch"] == "11")
            {
                e.Row.Cells[9].Visible = false;
                lbl1.Text = "NO. OF CIRCUITS";
                lbl3.Text = "";
                lbl2.Text = "";
                lbnum.Text = "";
                lblloc.Text = "AREA SERVED FOR LC";
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
            else if ((string)Session["sch"] == "12")
            {
                lbl1.Text = "CONNECTED FROM";
                lbl3.Text = "NO. OF POINTS";
                lbl2.Text = "";
                lbnum.Text = "";
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
            else if ((string)Session["sch"] == "13")
            {
                e.Row.Cells[9].Visible = false;
                lbl1.Text = "NO. OF POINTS";
                lbl3.Text = "";
                lbl2.Text = "";
                lbnum.Text = "";
                lblloc.Text = "SYS.MONITORED";
                e.Row.Cells[8].Visible = false;
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
            }

            e.Row.Cells[12].Visible = false;
            //e.Row.Cells[13].Visible = false;

            //mygrid.Columns[10].HeaderText = lbnum.Text;
            if (e.Row.Cells[1].Text != "") return;
            e.Row.Cells[1].Text = (e.Row.DataItemIndex + 1).ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[3].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[4].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[7].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[8].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
                e.Row.Cells[9].Attributes.Add("style", "word-break:break-all;word-wrap:break-word");

            }
        }

        protected void mygrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.SetRenderMethodDelegate(RenderHeader);
        }

        protected void date3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void date4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void date11_TextChanged(object sender, EventArgs e)
        {

        }

        protected void date1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Config_TestLabel()
        {
            if ((string)Session["sch"] == "1" || (string)Session["sch"]=="5")
            {
                Label1.Text = "Planned Power On";
                testhead1.Text = "PANEL/EQUIPMENT TESTING";
                Label2.Text = "Torque Test";
                Label3.Text = "IR Test";
                Label4.Text = "Pressure Test";
                Label5.Text = "Secondary Injection Test";
                Label6.Text = "Contact resistance";
                Label7.Text = "Functional Test";
                Label8.Visible = false;

                testhead2.Text = "OUT GOING CIRCUIT TESTING";
                Label9.Text = "Total No.of Circuits";
                Label10.Text = "Total Cold Tested";
                Label11.Text = "Cold Completed";
                Label12.Text = "Total Live Tested";
                Label13.Text = "Live Completed";
                test7.Visible = false;
                test8.Visible = false;
                test9.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                
            }
            else if ((string)Session["sch"] == "8" || (string)Session["sch"] == "17")
            {
                Label1.Text = "Planned Power On";
                if ((string)Session["sch"] == "8")
                    testhead1.Text = "MECHANICAL SYSTEMS";
                else
                    testhead1.Text = "COMMISSIONING TEST";
                Label2.Text = "Pre.Comm";Label3.Text = "Comm";Label4.Text = "Witnessed Date";
                Label5.Text = "";
                Label6.Text = "";
                Label7.Text = "";
                Label8.Text = "";

                testhead2.Text = "CONTROLS";
                Label9.Text = "Pre.Comm";
                Label10.Text = "Comm";
                Label11.Text = "Witnessed";
                Label12.Text = "";
                Label13.Text = "";
                Label14.Text = "";
                Label19.Text = "";
                Label21.Text = "";
                test4.Visible = false;
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                notested2.Visible = false;
                conaccept2.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                txtfiled.Visible = false;
                date13_CalendarExtender.PopupButtonID = "txtdevices1";
                date13_CalendarExtender.TargetControlID = "txtdevices1";
                date12_CalendarExtender.PopupButtonID = "notested1";
                date12_CalendarExtender.TargetControlID = "notested1";

            }
            else if ((string)Session["sch"] == "2")
            {
                Label1.Text = "Planned Power On";
                testhead1.Text = "PANEL/EQUIPMENT TESTING";
                Label2.Text = "Torque Test";
                Label3.Text = "IR Test";
                Label4.Text = "Hi Pot Test";
                Label5.Text = "VT Test";
                Label6.Text = "CT Test";
                Label7.Text = "Primary Injection Test";
                Label8.Text = "Secondary Injection Test";
                Label16.Text = "Contact Resistance Test";
                Label22.Text = "Functional Test";
                Label23.Text = "Protective Relay Final Setting";
                Label24.Text = "";

                testhead2.Text = "22/11KV HV Test";
                Label9.Text = "Cable IR and Hi Pot";
                Label10.Text = "";
                Label11.Text = "";
                Label12.Text = "";
                Label13.Text = "";
                txtdevices1.Text = "";
                date13_CalendarExtender.PopupButtonID = "txtdevices1";
                date13_CalendarExtender.TargetControlID = "txtdevices1";
                testcomp2.Visible = false;
                test12.Visible = false;
                testcomp1.Visible = false;
                notested1.Visible = false;
                notested2.Visible = false;
                test9.Visible = false;
            }
            else if ((string)Session["sch"] == "3")
            {
                Label1.Text = "Planned Power On";
                testhead1.Text = "PANEL/EQUIPMENT TESTING";
                Label2.Text = "Winding Insulation Resistance Test";
                Label3.Text = "Ratio Test";
                Label4.Text = "Winding Resistance Test";
                Label5.Text = "Vector Group Test";
                Label6.Text = "Temp Relay Functional Test";
                Label7.Text = "";
                Label8.Text = "";
                Label16.Text = "";
                Label22.Text = "";
                Label23.Text = "";
                Label24.Text = "";

                testhead2.Text = "CABLE TEST";
                Label9.Text = "Cable Test";
                Label10.Text = "";
                Label11.Text = "";
                Label12.Text = "";
                Label13.Text = "";

               
                testcomp2.Visible = false;
                test9.Visible = false;
                date13_CalendarExtender.PopupButtonID = "txtdevices1";
                date13_CalendarExtender.TargetControlID = "txtdevices1";
                testcomp2.Visible = false;
                testcomp1.Visible = false;
                notested1.Visible = false;
                notested2.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                notested2.Visible = false;

            }
            else if ((string)Session["sch"] == "4")
            {
                Label1.Text = "Planned Power On";
                testhead1.Text = "GENERATOT TESTING";
                Label2.Text = "Pre Com";
                Label3.Text = "Control/Fuel System";
                Label4.Text = "Initial Run Test";
                Label5.Text = "Load Test";
                Label6.Text = "Functional Test";
                Label7.Text = "Full Run Test";
                Label8.Text = "";
                Label16.Text = "";
                Label22.Text = "";
                Label23.Text = "";
                Label24.Text = "";

                testhead2.Text = "OUTGOING CIRCUIT TEST";
                Label9.Text = "Total No.of Circuits";
                Label10.Text = "Total Cold Tested";
                Label11.Text = "Cold Complete";
                Label12.Text = "";
                Label13.Text = "";
                txtppon.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                notested2.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;

            }
            else if ((string)Session["sch"] == "7")
            {
                Label1.Text = "";
                testhead1.Text = "EMERGENCY LIGHTNING TESTING";
                Label2.Text = "Continuity/IR Test";
                Label3.Text = "Change Over Test";
                Label4.Text = "3 Hour Duration Test";
                Label5.Text = "PC Head End Test";
                Label6.Text = "";
                Label7.Text = "";
                Label8.Text = "";
                Label16.Text = "";
                Label22.Text = "";
                Label23.Text = "";
                Label24.Text = "";
                txtppon.Visible = false;
                testhead2.Text = "";
                Label9.Text = "No.of Emergency Lights";
                Label10.Text = "";
                Label11.Text = "";
                Label12.Text = "";
                Label13.Text = "";
                notested2.Visible = false;
                notested1.Visible = false;
                testcomp1.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
              
            }
            else if ((string)Session["sch"] == "6")
            {
                Label1.Text = "";
                testhead1.Text = "Earthing Protection";
                Label2.Text = "Earth Pit Test";
                Label3.Text = "Consultant Accepted";
                Label4.Text = "Test Sheet Filed";
                Label5.Text = "";
                Label6.Text = "";
                Label7.Text = "Bonding of All Equipment Complete";
                Label8.Text = "";
                Label16.Text = "";
                Label22.Text = "";
                Label23.Text = "";
                Label24.Text = "";
                txtppon.Visible = false;
                testhead2.Text = "Lightning Protection";
                Label9.Text = "Lightning Protection Pit Test";
                Label10.Text = "Consultant Accepted";
                Label11.Text = "Test Sheet Filed";
                Label12.Text = "";
                Label13.Text = "";
                Label14.Text = "Lightning Protection Bonding of Roof Equipment and Down Conductor Test Complete";
                notested2.Visible = false;
                testcomp2.Visible = false;
                test4.Visible = false;
                test5.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                date12_CalendarExtender.PopupButtonID = "notested1";
                date12_CalendarExtender.TargetControlID = "notested1";
                date15_CalendarExtender.PopupButtonID = "txtdevices1";
                date15_CalendarExtender.TargetControlID = "txtdevices1";

            }
            else if ((string)Session["sch"] == "16")
            {
                Label1.Text = "Installation Complete";
                testhead1.Text = "ELV TESTING";
                Label2.Text = "Continuity/IR Test";
                Label3.Text = "Programing";
                Label4.Text = "Seq.of OP Test";
                Label5.Text = "Interface Test";
                Label6.Text = "Graphic Head End Test";
                Label7.Text = "";
                Label8.Text = "";
                Label16.Text = "";
                Label22.Text = "";
                Label23.Text = "";
                Label24.Text = "";
                testhead2.Text = "";
                Label9.Text = "No.of Points";
                Label10.Text = "No.of Points Tested";
                Label11.Text = "Point Test Complete";
                Label12.Text = "No.of Interface Points";
                Label13.Text = "No.of Interface Tested";
                Label14.Text = "Interface Test Complete";
                testcomp1.Visible = false;
                conaccept2.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;

            }
            else if ((string)Session["sch"] == "18")
            {
                Label1.Text = "";
                Label2.Text = "Witnessed"; Label3.Text = ""; Label4.Text = "";
                Label5.Text = "";
                Label6.Text = "";
                Label7.Text = "";
                Label8.Text = "";
                testhead2.Text = "";
                Label9.Text = "Quantity";
                Label10.Text = "Tested";
                Label11.Text = "";
                Label12.Text = "";
                Label13.Text = "";
                Label14.Text = "";
                Label19.Text = "";
                Label21.Text = "";
                test2.Visible = false;
                test3.Visible = false;
                test4.Visible = false;
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                notested2.Visible = false;
                conaccept2.Visible = false;
                testcomp1.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                txtfiled.Visible = false;
                txtppon.Visible = false;
                
            }
            else if ((string)Session["sch"] == "19")
            {
                Label1.Text = "Planned Power On";
                Label2.Text = "Room/System Integrity Test"; Label3.Text = "Stand Alone Commission"; Label4.Text = "Fire & BMS Interface Test";
                Label5.Text = "Witnessed";
                Label6.Text = "";
                Label7.Text = "";
                Label8.Text = "";
                testhead2.Text = "";
                Label9.Text = "";
                Label10.Text = "";
                Label11.Text = "";
                Label12.Text = "";
                Label13.Text = "";
                Label14.Text = "";
                Label19.Text = "";
                Label21.Text = "";
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                notested2.Visible = false;
                conaccept2.Visible = false;
                testcomp1.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                txtfiled.Visible = false;
                txtdevices1.Visible = false;
                notested1.Visible = false;
                
            }
            else if ((string)Session["sch"] == "20")
            {
                Label1.Text = "";
                testhead1.Text = "";
                Label2.Text = "No.of 240V Circuits";
                Label3.Text = "No.of 240V Circuits Tested";
                Label4.Text = "";
                Label5.Text = "";
                Label6.Text = "";
                Label7.Text = "";
                Label8.Text = "";
                Label16.Text = "";
                Label22.Text = "";
                Label23.Text = "";
                Label24.Text = "";
                testhead2.Text = "";
                Label9.Text = "No.of Points";
                Label10.Text = "Point to Point Test";
                Label11.Text = "Point Test Complete";
                Label12.Text = "Sequence of OP Test";
                Label13.Text = "Graphic/Head End Test";
                Label14.Text = "";
                Label19.Text = "";
                Label21.Text = "";
                txtppon.Visible = false;
                conaccept2.Visible = false;
                test9.Visible = false;
                test3.Visible = false;
                test4.Visible = false;
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                txtfiled.Visible = false;
                date2_CalendarExtender.TargetControlID = "test4";
                test2_CalendarExtender.TargetControlID = "test5";
                date12_CalendarExtender.TargetControlID = "txtfiled";

            }
            else if ((string)Session["sch"] == "11")
            {
                Label2.Text = "Continuity/IR Test Complete" ;
                Label3.Text = "No.of Lightning Circuits Tested";
                Label4.Text = "PC Head End Interface Test";
                Label9.Text = "No of Circuits";
                txtppon.Visible = false;
                conaccept2.Visible = false;
                test9.Visible = false;
                test4.Visible = false;
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                txtfiled.Visible = false;
                notested1.Visible = false;
                notested2.Visible = false;
                testcomp1.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                Label19.Text = "";
                Label21.Text = "";
                date2_CalendarExtender.TargetControlID = "test4";
                test2_CalendarExtender.TargetControlID = "test5";
                date4_CalendarExtender.TargetControlID = "test8";
                date12_CalendarExtender.TargetControlID = "txtfiled";
            }
            else if ((string)Session["sch"] == "12")
            {
                Label2.Text = "Continuity/Points Used";
                Label9.Text = "No of Points";
                txtppon.Visible = false;
                conaccept2.Visible = false;
                test2.Visible = false;
                test3.Visible = false;
                test4.Visible = false;
                test9.Visible = false;
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                txtfiled.Visible = false;
                notested1.Visible = false;
                notested2.Visible = false;
                testcomp1.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                Label19.Text = "";
                Label21.Text = "";
                date2_CalendarExtender.TargetControlID = "test6";
               
            }
            else if ((string)Session["sch"] == "13")
            {
                Label2.Text = "Continuity Test";
                Label3.Text = "CCTV View Locally";
                Label4.Text = "CCTV View From Head End";
                Label5.Text = "Test Software";
                Label9.Text = "No of Points";
                txtppon.Visible = false;
                conaccept2.Visible = false;
                test9.Visible = false;
                test5.Visible = false;
                test6.Visible = false;
                test7.Visible = false;
                test8.Visible = false;
                test10.Visible = false;
                test11.Visible = false;
                test12.Visible = false;
                txtfiled.Visible = false;
                notested1.Visible = false;
                notested2.Visible = false;
                testcomp1.Visible = false;
                testcomp2.Visible = false;
                test9.Visible = false;
                Label19.Text = "";
                Label21.Text = "";
                date2_CalendarExtender.TargetControlID = "test6";
                test2_CalendarExtender.TargetControlID = "test5";
                date4_CalendarExtender.TargetControlID = "test8";
                date12_CalendarExtender.TargetControlID = "txtfiled";
                date5_CalendarExtender.TargetControlID = "test7";
            }
        }

        protected void date2_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void date4_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void btnupdate_Click1(object sender, EventArgs e)
        {

        }

        protected void drbuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["zone"] = drbuilding.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text);
        }

        protected void drcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["cat"] = drcategory.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text);
        }

        protected void drflevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["flvl"] = drflevel.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text);
        }

        protected void drfed_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["fed"] = drfed.SelectedItem.Value;
            Filtering(drbuilding.SelectedItem.Text, drcategory.SelectedItem.Text, drflevel.SelectedItem.Text, drfed.SelectedItem.Text);
        }
        private void Load_Filtering_Elements()
        {
            var _bzone = (from DataRow dRow in _dtMaster.Rows
                          orderby dRow["B_Z"]
                          select new { col1 = dRow["B_Z"] }).Distinct();
            foreach (var row in _bzone)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drbuilding.Items.Add(_itm);
            }
            drbuilding.DataBind();
            var _fedf = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["F_from"]
                         select new { col1 = dRow["F_from"] }).Distinct();
            foreach (var row in _fedf)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drfed.Items.Add(_itm);
            }
            drfed.DataBind();
            var _cate = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["Cat"]
                         select new { col1 = dRow["Cat"] }).Distinct();
            foreach (var row in _cate)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drcategory.Items.Add(_itm);
            }
            drcategory.DataBind();
            var _flvl = (from DataRow dRow in _dtMaster.Rows
                         orderby dRow["F_lvl"]
                         select new { col1 = dRow["F_lvl"] }).Distinct();
            foreach (var row in _flvl)
            {
                ListItem _itm = new ListItem();
                _itm.Text = row.col1.ToString();
                _itm.Value = row.col1.ToString();
                drflevel.Items.Add(_itm);
            }
            drflevel.DataBind();
            drbuilding.Items.Insert(0, "All");
            drcategory.Items.Insert(0, "All");
            drflevel.Items.Insert(0, "All");
            drfed.Items.Insert(0, "All");
            //drbuilding.SelectedValue = (string)Session["zone"];
            //drcategory.SelectedValue = (string)Session["cat"];
            //drflevel.SelectedValue = (string)Session["flvl"];
            //drfed.SelectedValue = (string)Session["fed"];
        }
        public static DataTable _dtfilter;
        private void Filtering(string _el1, string _el2, string _el3, string _el4)
        {
            if (_el1 == "") _el1 = "All";
            if (_el2 == "") _el2 = "All";
            if (_el3 == "") _el3 = "All";
            if (_el4 == "") _el4 = "All";
            _dtfilter = _dtMaster;
            DataTable _dtresult = new DataTable();
            _dtresult.Columns.Add("e_b_ref", typeof(string));
            _dtresult.Columns.Add("B_Z", typeof(string));
            _dtresult.Columns.Add("Cat", typeof(string));
            _dtresult.Columns.Add("F_lvl", typeof(string));
            _dtresult.Columns.Add("Sq_No", typeof(string));
            _dtresult.Columns.Add("Loc", typeof(string));
            _dtresult.Columns.Add("P_P_to", typeof(string));
            _dtresult.Columns.Add("F_from", typeof(string));
            _dtresult.Columns.Add("Substation", typeof(string));
            _dtresult.Columns.Add("devices1", typeof(string));
            _dtresult.Columns.Add("C_id", typeof(int));
            _dtresult.Columns.Add("Sys_name", typeof(string));
            _dtresult.Columns.Add("Sys_id", typeof(int));
            var _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          select o;
            }
            else if (_el1 != "All" && _el2 == "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 != "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("B_Z") == _el1 && o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 == "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 != "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("Cat") == _el2 && o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 == "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 != "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_lvl") == _el3 && o.Field<string>("F_from") == _el4
                          select o;
            }
            else if (_el1 == "All" && _el2 == "All" && _el3 == "All" && _el4 != "All")
            {
                _filter = from o in _dtfilter.AsEnumerable()
                          where o.Field<string>("F_from") == _el4
                          select o;
            }
            foreach (var row in _filter)
            {
                DataRow _row = _dtresult.NewRow();
                _row[0] = row["e_b_ref"].ToString();
                _row[1] = row["B_Z"].ToString();
                _row[2] = row["Cat"].ToString();
                _row[3] = row["F_lvl"].ToString();
                _row[4] = row["Seq_No"].ToString();
                _row[5] = row["Loc"].ToString();
                _row[6] = row["p_p_to"].ToString();
                _row[7] = row["F_from"].ToString();
                _row[8] = row["Substation"].ToString();
                _row[9] = row["devices1"].ToString();
                _row[10] = row["C_id"].ToString();
                _row[11] = row["Sys_name"].ToString();
                _row[12] = row["Sys_id"].ToString();
                _dtresult.Rows.Add(_row);
            }
            mygrid.DataSource = _dtresult;
            mygrid.DataBind();
            GridViewHelper _help = new GridViewHelper(mygrid);
            _help.RegisterGroup("Sys_name", true, true);
            _help.GroupHeader += new GroupEvent(helper_GroupHeader);
            _help.ApplyGroupSort();

        }
    }
}
