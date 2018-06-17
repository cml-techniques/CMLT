using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;

namespace CmlTechniques.CMS
{
    public partial class cassheet_master : System.Web.UI.Page
    {
        public bool isPcdProject;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                lbluid.Text = (string)Session["uid"];
                string _query = Request.QueryString[0].ToString();
                lblsch.Text = _query.Substring(0, _query.IndexOf("_P"));
                if (_query.Contains("_D") == true)
                {
                    Session["project"] = _query.Substring(_query.IndexOf("_P") + 2, _query.IndexOf("_D") - (_query.IndexOf("_P") + 2));
                    lbldiv.Text = _query.Substring(_query.IndexOf("_D") + 2);

                }
                else
                {
                    Session["project"] = _query.Substring(_query.IndexOf("_P") + 2);
                    lbldiv.Text = "0";
                }
                lblprj.Text = (string)Session["project"];
             
                _Create_Cookies();
                //if ((string)Session["project"] == "123")
                Permission();

             

            }
            isPcdProject = (Array.IndexOf(Constants.CMLTConstants.PcdProjects, lblprj.Text) > -1) ? true : false;

        }
         private void Permission()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _clsuser _objcls = new _clsuser();
            _objdb.DBName = "dbCML";
            _objcls.uid = (string)Session["uid"];
            _objcls.project_code = lblprj.Text;
            string _access = _objbll.Get_User_cmsAccess(_objcls, _objdb);
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
            {
                btnsum1.Visible = true;
                if (lblsch.Text == "33" || lblsch.Text == "34" || lblsch.Text == "35")
                    btnsum.Visible = false;
            }
            else if (lblprj.Text == "CCAD" || lblprj.Text=="Traini")
            {
                if (lblsch.Text == "8")
                    btnsum1.Visible = true;
                else
                    btnsum1.Visible = false;
            }
            else if (lblprj.Text == "12761" && lblsch.Text == "23")
            {
                btnsum.Visible = false;
                btnsum1.Visible = false;
            }
            else if ((isPcdProject)||(lblprj.Text == "OPH" && (lblsch.Text == "2" || lblsch.Text == "5" || lblsch.Text == "8" || lblsch.Text == "17" || lblsch.Text == "10" || lblsch.Text == "6" || lblsch.Text == "21" || lblsch.Text == "9" || lblsch.Text == "4" || lblsch.Text == "7" || lblsch.Text == "18" || lblsch.Text == "19" || lblsch.Text == "20" || lblsch.Text == "15" || lblsch.Text == "21" || lblsch.Text == "13" || lblsch.Text == "11" || lblsch.Text == "12" || lblsch.Text == "26" || lblsch.Text == "22" || lblsch.Text == "27" || lblsch.Text == "25" || lblsch.Text == "16" || lblsch.Text == "24" || lblsch.Text == "28")))
            {
                btnsum1.Visible = true;
                btnsum1.Text = "PROGRESS COMPARISON";
            }
            else if (lblprj.Text == "12761" && lblsch.Text == "25")
            {
                //btnedit.Visible = false;
                //btnsum.Visible = false;caslv
                //btnnew.Visible = false;
                //btnrpt.Visible = false;
                //btnsum1.Visible = false;
                //btninput.Visible = false;
                menucontainer.Visible = false;
            }
            else
                btnsum1.Visible = false;

            if (_access != "Admin")
            {
                if ((lblsch.Text == "45" && lblprj.Text !="11784") || lblsch.Text == "47" || lblsch.Text == "48" || lblsch.Text == "49" || lblsch.Text == "50" || lblsch.Text == "60" || lblsch.Text == "92" || lblsch.Text == "93"  || lblsch.Text == "96" || lblsch.Text == "98" || lblsch.Text == "110")
                {
                    btnnew.Visible = false;
                    btnedit.Visible = false;
                    btnsum.Visible = false;
                    btninput.Visible = false;
                    btnrpt.Visible = false;
                    btnsum1.Visible = false;
                    myframe1.Attributes.Add("src", "NoCas.aspx?id=" + lblsch.Text);
                }
                else
                {
                    btnnew.Visible = false;
                    btnedit.Visible = false;
                    Load_FullSchedule();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "ChangeCls(3);", true);
                }
            }
            else
            {
                if ((lblsch.Text == "45" && lblprj.Text != "11784") || lblsch.Text == "47" || lblsch.Text == "48" || lblsch.Text == "49" || lblsch.Text == "50" || lblsch.Text == "60" || lblsch.Text == "92" || lblsch.Text == "93" || lblsch.Text == "96" || lblsch.Text == "98" || lblsch.Text == "110")
                {
                    btnnew.Visible = false;
                    btnedit.Visible = false;
                    btnsum.Visible = false;
                    btninput.Visible = false;
                    btnrpt.Visible = false;
                    btnsum1.Visible = false;
                    myframe1.Attributes.Add("src", "NoCas.aspx?id=" + lblsch.Text);
                }
                else
                {
                    string _prm = lblprj.Text + "_S" + lblsch.Text;
                    if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    {
                        if (lblsch.Text == "33" || lblsch.Text == "34" || lblsch.Text == "35")
                        {
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntry1.aspx?id=" + _prm);
                            btnedit.Visible = false;
                        }
                        else if(lblsch.Text=="20")
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntry_BMS.aspx?id=" + _prm);
                        else
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
                        //myframe1.Attributes.Add("src", "../CasDataEntry_New.aspx?id=" + _prm);
                    }
                    else if (lblprj.Text == "CCAD")
                    {
                        if (lblsch.Text == "12")
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntry2.aspx?id=" + _prm);
                        else if (lblsch.Text == "18" || lblsch.Text == "101" || lblsch.Text == "97" || lblsch.Text == "95")
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntry3.aspx?id=" + _prm);
                        else if (lblsch.Text == "10" || lblsch.Text == "11")
                            myframe1.Attributes.Add("src", "../CAS/Cas_Entry.aspx?id=" + _prm);
                        else
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
                    }
                    else if (lblprj.Text == "12761" && lblsch.Text=="25")
                    {
                        myframe1.Attributes.Add("src", "PileCapsEntry.aspx?id=" + _prm);
                    }
                    //else if (lblprj.Text == "12761" && lblsch.Text == "27")
                    //{
                    //    myframe1.Attributes.Add("src", "../Cassheet_DataEntry2.aspx?id=" + _prm);
                    //}
                    else
                    {
                        if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                        {
                            _prm = _prm + "_D" + lbldiv.Text;
                            if (lblsch.Text == "23")
                            {
                                myframe1.Attributes.Add("src", "../Cassheet_DataEntrypp.aspx?id=" + _prm);
                            }
                            else
                                myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
                        }
                        else if (lblprj.Text == "12761" && lblsch.Text == "23")
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntry23.aspx?id=" + _prm);
                        else if (lblprj.Text == "12761" && lblsch.Text == "24")
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntryCP.aspx?id=" + _prm);
                        else if (lblprj.Text == "OPH" && lblsch.Text == "20")
                            myframe1.Attributes.Add("src", "../CAS_DataEntry.aspx?id=" + _prm);
                        else
                        {
                            if (lblprj.Text == "AFV") _prm = _prm + "_D" + lbldiv.Text;
                            myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
                        }
                        //myframe1.Attributes.Add("src", "../CasDataEntry_New.aspx?id=" + _prm);
                    }
                }
            }
        }
        void _Create_Cookies()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _CookieSch = new HttpCookie("sch");
                _CookieSch.Value = lblsch.Text;
                _CookieSch.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSch);
                HttpCookie _CookieSrv = new HttpCookie("srv");
                _CookieSrv.Value = (string)Session["srv"];
                _CookieSrv.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_CookieSrv);

            }
            else
                return;
        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
               
            }
        }
        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            //string _id = lblsch.Text;
            //if (Menu1.Items[0].Selected == true)
            //    myframe.Attributes.Add("src", "../casintdata.aspx");
            //else if (Menu1.Items[1].Selected == true)
            //    myframe.Attributes.Add("src", "cassheet_testing.aspx");
            //else if (Menu1.Items[3].Selected == true)
            //    myframe.Attributes.Add("src", "caslvreport.aspx");

        }
        protected void btnnew_Click(object sender, EventArgs e)
        {
            //if ((string)Session["project"] == "123")
            //    myframe1.Attributes.Add("src", "../cassheet_entry.aspx");
            //else
            string _prm = lblprj.Text + "_S" + lblsch.Text;
            if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
            {
                if (lblsch.Text == "33" || lblsch.Text == "34" || lblsch.Text == "35")
                {
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry1.aspx?id=" + _prm);
                    btnedit.Visible = false;
                }
                else if (lblsch.Text == "20")
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry_BMS.aspx?id=" + _prm);
                else
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
            }
            else if (lblprj.Text == "CCAD")
            {
                if (lblsch.Text == "12")
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry2.aspx?id=" + _prm);
                else if (lblsch.Text == "18" || lblsch.Text == "101" || lblsch.Text == "97" || lblsch.Text == "95")
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry3.aspx?id=" + _prm);
                else if (lblsch.Text == "10" || lblsch.Text == "11")
                    myframe1.Attributes.Add("src", "../CAS/Cas_Entry.aspx?id=" + _prm);
                else
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
            }
            else
            {
                if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                {
                    _prm = _prm + "_D" + lbldiv.Text;
                    if (lblsch.Text == "23")
                    {
                        myframe1.Attributes.Add("src", "../Cassheet_DataEntrypp.aspx?id=" + _prm);
                    }
                    else
                        myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);
                }
                else if (lblprj.Text == "12761" && lblsch.Text == "23")
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry23.aspx?id=" + _prm);
                else if (lblprj.Text == "12761" && lblsch.Text == "24")
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntryCP.aspx?id=" + _prm);
                else if (lblprj.Text == "OPH"  && lblsch.Text == "20")
                    myframe1.Attributes.Add("src", "../CAS_DataEntry.aspx?id=" + _prm);
                else
                {
                    if (lblprj.Text=="AFV") _prm = _prm + "_D" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "../Cassheet_DataEntry.aspx?id=" + _prm);

                }
            }
        }
        protected void btnedit_Click(object sender, EventArgs e)
        {
            string _prm = lblprj.Text + "_S" + lblsch.Text;
            if (lblprj.Text == "CCAD")
            {
                if (lblsch.Text == "12")
                    myframe1.Attributes.Add("src", "Commissioning_Testing3.aspx?id=" + _prm);
                else if (lblsch.Text == "18" || lblsch.Text == "101" || lblsch.Text == "97" || lblsch.Text == "95")
                    myframe1.Attributes.Add("src", "Commissioning_Testing4.aspx?id=" + _prm);
                else if (lblsch.Text == "10" || lblsch.Text == "11")
                    myframe1.Attributes.Add("src", "../CAS/Commissioning.aspx?id=" + _prm);
                else
                    myframe1.Attributes.Add("src", "Commissioning_Testing2.aspx?id=" + _prm);
            }
            else if (lblprj.Text == "ASAO" && lblsch.Text == "20")
            {
                myframe1.Attributes.Add("src", "Commissioning_Testing_BMS.aspx?id=" + _prm);
            }
            else
            {
                if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                {
                    _prm = _prm + "_D" + lbldiv.Text;

                    if (lblsch.Text == "23")
                    {
                        myframe1.Attributes.Add("src", "Commissiong_Testing5.aspx?id=" + _prm);
                    }
                    else
                        myframe1.Attributes.Add("src", "Commissiong_Testing.aspx?id=" + _prm);
                }
                else
                {
                    if (lblprj.Text == "12761" && lblsch.Text == "23")
                    {
                        myframe1.Attributes.Add("src", "Commissiong_Testing23.aspx?id=" + _prm);
                    }
                    else if (lblprj.Text == "12761" && lblsch.Text == "24")
                    {
                        myframe1.Attributes.Add("src", "Commissioning_TestingCP.aspx?id=" + _prm);
                    }
                    else if (lblsch.Text == "33" && lblprj.Text != "11784")
                        myframe1.Attributes.Add("src", "Commissioning_Testing1.aspx?id=" + _prm);
                    else if (isPcdProject)
                    {
                        if (lblprj.Text == "ARSD" && lblsch.Text == "16")
                        {
                            string _url = lblprj.Text + "_S" + lblsch.Text;
                            myframe1.Attributes.Add("src", "Commissiong_Testing.aspx?id=" + _prm);
                        }
                        else
                        {
                            string _url = "prj="+lblprj.Text + "&sch=" + lblsch.Text;
                            if (lblprj.Text == "AFV") _url = "prj="+ lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                            myframe1.Attributes.Add("src", "CAS_Commissioning1.aspx?" + _url);

                        }
                    }
                    else if ((lblsch.Text == "5" || lblsch.Text == "8" || lblsch.Text == "17" || lblsch.Text == "10" || lblsch.Text == "6" || lblsch.Text == "21" || lblsch.Text == "4" || lblsch.Text == "7" || lblsch.Text == "18" || lblsch.Text == "19" || lblsch.Text == "20" || lblsch.Text == "15" || lblsch.Text == "13" || lblsch.Text == "11" || lblsch.Text == "12" || lblsch.Text == "26" || lblsch.Text == "22" || lblsch.Text == "27" || lblsch.Text == "25" || lblsch.Text == "16" || lblsch.Text == "24" || lblsch.Text == "28") && (lblprj.Text == "OPH"))
                    {
                        string _url = lblprj.Text + "&sch=" + lblsch.Text;
                        if (lblsch.Text == "20")
                            myframe1.Attributes.Add("src", "CAS_Commissioning2.aspx?prj=" + _url);
                        else
                            myframe1.Attributes.Add("src", "CAS_Commissioning1.aspx?prj=" + _url);
                    }
                    else if (lblprj.Text == "OCEC" && lblsch.Text == "27")
                    {
                        string _url = lblprj.Text + "_S" + lblsch.Text;
                        myframe1.Attributes.Add("src", "CAS_Commissioning.aspx?prj=" + _url);
                    }
                    else
                        myframe1.Attributes.Add("src", "Commissiong_Testing.aspx?id=" + _prm);
                }
            }
        }
        private void Load_FullSchedule()
        {
            Session["sch_id"] = lblsch.Text;
            if (lblsch.Text == "5" || lblsch.Text == "1" || (lblprj.Text == "11784" && lblsch.Text == "28"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "caslv1report.aspx?id=5_P" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "caslvreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "caslvreport1.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "caslvreport_pcd.aspx?"+url);
                }
                else
                    myframe1.Attributes.Add("src", "caslvreport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
                //myframe1.Attributes.Add("src", "Reports.aspx?id=cas");
            }
            else if (lblsch.Text == "44" && lblprj.Text!="11784")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "caslv1report.aspx?id=44_P" + lblprj.Text);
            }
            else if (lblsch.Text == "2" || (lblprj.Text == "11784" && lblsch.Text == "25"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casmv1report.aspx?id=2_P" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casmvreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casmvreport_pcd.aspx?" +url);
                }
                else
                    myframe1.Attributes.Add("src", "casmvreport.aspx?id=" + lblprj.Text +"&sch="+ lblsch.Text);
            }
            else if (lblsch.Text == "121")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casmv1report.aspx?id=121_P" + lblprj.Text);
            }
            else if (lblsch.Text == "119")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casmv1report.aspx?id=119_P" + lblprj.Text);
            }
            else if (lblsch.Text == "118")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casmv1report.aspx?id=118_P" + lblprj.Text);
            }
            else if (lblsch.Text == "3" || lblsch.Text == "120" || (lblprj.Text == "11784" && lblsch.Text == "26"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "castrans1report.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
                else if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                    myframe1.Attributes.Add("src", "castrans2report.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "castransreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "castransreport_pcd.aspx?" + url);
                }
                else
                    myframe1.Attributes.Add("src", "castransreport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "4" || (lblprj.Text == "11784" && lblsch.Text == "27"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casgen1report.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casgenreport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casgenreport_pcd.aspx?" + url);
                }
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casgenreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else
                    myframe1.Attributes.Add("src", "casgenreport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "6" ||(lblprj.Text == "11784" && lblsch.Text == "29"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "caselp1report.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "caselpreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "caselpreport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "caselpreport_pcd.aspx?" + url);
                }
                else
                    myframe1.Attributes.Add("src", "caselpreport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "7" || (lblprj.Text == "11784" && lblsch.Text == "30"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casemg1report.aspx?id=" + lblprj.Text);
                if (lblprj.Text == "ASAO")
                    myframe1.Attributes.Add("src", "casemg2report.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casemgreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casemgreport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casemgreport_pcd.aspx?" + url);
                }
                else
                    myframe1.Attributes.Add("src", "casemgreport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "8" || (lblprj.Text == "11784" && lblsch.Text == "31"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=8_P" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casmereport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casmereport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casmereport_pcd.aspx?" + url);
                }
                else
                    myframe1.Attributes.Add("src", "casmereport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "51")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=51_P" + lblprj.Text);
            }
            else if (lblsch.Text == "52")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=52_P" + lblprj.Text);
            }
            else if (lblsch.Text == "53")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=53_P" + lblprj.Text);
            }
            else if (lblsch.Text == "54")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=54_P" + lblprj.Text);
            }
            else if (lblsch.Text == "55")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=55_P" + lblprj.Text);
            }
            else if (lblsch.Text == "56")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=56_P" + lblprj.Text);
            }
            else if (lblsch.Text == "57")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=57_P" + lblprj.Text);
            }
            else if (lblsch.Text == "58")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=58_P" + lblprj.Text);
            }
            else if (lblsch.Text == "59")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=59_P" + lblprj.Text);
            }
            else if (lblsch.Text == "60")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=60_P" + lblprj.Text);
            }
            else if (lblsch.Text == "61")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=61_P" + lblprj.Text);
            }
            else if (lblsch.Text == "62")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=62_P" + lblprj.Text);
            }
            else if (lblsch.Text == "63")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=63_P" + lblprj.Text);
            }
            else if (lblsch.Text == "64")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=64_P" + lblprj.Text);
            }
            else if (lblsch.Text == "65")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=65_P" + lblprj.Text);
            }
            else if (lblsch.Text == "66")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=66_P" + lblprj.Text);
            }
            else if (lblsch.Text == "67")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=67_P" + lblprj.Text);
            }
            else if (lblsch.Text == "68")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=68_P" + lblprj.Text);
            }
            else if (lblsch.Text == "69")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=69_P" + lblprj.Text);
            }
            else if (lblsch.Text == "70")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=70_P" + lblprj.Text);
            }
            else if (lblsch.Text == "71")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=71_P" + lblprj.Text);
            }
            else if (lblsch.Text == "72")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=72_P" + lblprj.Text);
            }
            else if (lblsch.Text == "73")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=73_P" + lblprj.Text);
            }
            else if (lblsch.Text == "74")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=74_P" + lblprj.Text);
            }
            else if (lblsch.Text == "75")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=75_P" + lblprj.Text);
            }
            else if (lblsch.Text == "76")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=76_P" + lblprj.Text);
            }
            else if (lblsch.Text == "77")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=77_P" + lblprj.Text);
            }
            else if (lblsch.Text == "78")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=78_P" + lblprj.Text);
            }
            else if (lblsch.Text == "79")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=79_P" + lblprj.Text);
            }
            else if (lblsch.Text == "80")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=80_P" + lblprj.Text);
            }
            else if (lblsch.Text == "81")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=81_P" + lblprj.Text);
            }
            else if (lblsch.Text == "82")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=82_P" + lblprj.Text);
            }
            else if (lblsch.Text == "83")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=83_P" + lblprj.Text);
            }
            else if (lblsch.Text == "84")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casme1report.aspx?id=84_P" + lblprj.Text);
            }
            else if (lblsch.Text == "9" || (lblprj.Text == "11784" && lblsch.Text == "32"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casfdreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casfdreport2.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casfdreport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casfdreport_pcd.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casfdreport.aspx?id=" + lblprj.Text+"&sch="+lblsch.Text);
            }
            else if (lblsch.Text == "10" || (lblprj.Text == "11784" && lblsch.Text == "33"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "../CAS/cas3Creport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casfavareport2.aspx?id=10_P" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casfavareport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casfavareport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casfavareport_pcd.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casfavareport.aspx?id="+ lblsch.Text +"_P" + lblprj.Text);
            }
            else if (lblsch.Text == "11" || (lblprj.Text == "11784" && lblsch.Text == "34"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "../CAS/cas3Dreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "caslcsreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "caslcsreport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "caslcsreport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "caslcsreport_pcd.aspx?id=" + lblprj.Text);  
                else
                    myframe1.Attributes.Add("src", "caslcsreport.aspx?id=" + lblprj.Text+ "&sch="+lblsch.Text);
            }
            else if (lblsch.Text == "12" || (lblprj.Text == "11784" && lblsch.Text == "35"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Freport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casscnreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casscnreport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "caslcsreport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casscnreport_pcd.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casscnreport.aspx?id=" + lblprj.Text+ "&sch="+lblsch.Text);
            }
            else if (lblsch.Text == "13" || (lblprj.Text == "11784" && lblsch.Text == "36"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Hreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "cascctvreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "cascctvreport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "cascctvreport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "cascctvreport_pcd.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "cascctvreport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "17" || lblsch.Text == "85" || lblsch.Text == "86" || lblsch.Text == "87" || lblsch.Text == "88" || lblsch.Text == "89" || lblsch.Text == "90" || lblsch.Text == "91" || lblsch.Text == "99" || lblsch.Text == "107" || lblsch.Text == "108" || lblsch.Text == "117" || (lblprj.Text == "11784" && lblsch.Text == "38"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas4Areport.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casph1report.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch=17");
                else
                {
                    if (lblprj.Text == "OPH")
                        myframe1.Attributes.Add("src", "casph1report_oph.aspx?prj=" + lblprj.Text);
                    else if (isPcdProject)
                    {
                        string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                        if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                        myframe1.Attributes.Add("src", "casph1report_pcd.aspx?" + url);
                    }
                    //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                    //    myframe1.Attributes.Add("src", "casph1report_pcd.aspx?prj=" + lblprj.Text);
                    else
                        myframe1.Attributes.Add("src", "casph1report.aspx?prj=" + lblprj.Text + "&div=0&sch="+lblsch.Text);
                }
            }

            else if (lblsch.Text == "18" || lblsch.Text == "101" || lblsch.Text == "97" || lblsch.Text == "95" || (lblprj.Text == "11784" && lblsch.Text == "39"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas4Breport.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casph2report.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch=18");
                else if (lblprj.Text == "MOE")
                    myframe1.Attributes.Add("src", "casph2report_MOE.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch=" + lblsch.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casph2report_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casph2report_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casph2report_pcd.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casph2report.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "19" || lblsch.Text == "102" || (lblprj.Text == "11784" && lblsch.Text == "40"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas4Creport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casph3report.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch=19");
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casph3report_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casph3report_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casph3report_pcd.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casph3report.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch="+lblsch.Text);
            }
            else if (lblsch.Text == "20" || (lblprj.Text == "11784" && lblsch.Text == "41"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casbms1report.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casbmsreport.aspx?id=20_P" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "ASAO")
                    myframe1.Attributes.Add("src", "casbmsreport_asao.aspx?id=20_P" + lblprj.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casbmsreport_oph.aspx?id=20_P" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casbmsreport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casbmsreport_pcd.aspx?id=" + lblsch.Text +"&prj="+lblprj.Text);  
                else
                    myframe1.Attributes.Add("src", "casbmsreport.aspx?id="+lblsch.Text +"_P" + lblprj.Text);
            }
            else if (lblsch.Text == "21" || (lblprj.Text == "11784" && lblsch.Text == "42"))
                if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casflureport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casflureport_oph.aspx?prj=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casflureport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casflureport_pcd.aspx?prj=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casflureport.aspx?id=" + lblprj.Text+"&sch="+lblsch.Text);
            else if (lblsch.Text == "22" || (lblprj.Text == "11784" && lblsch.Text == "43"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Ereport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casacsreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casacsreport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casacsreport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casacsreport_pcd.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casacsreport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "15")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Greport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casVESDAreport.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casgrmsreport_PCD.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
                //    myframe1.Attributes.Add("src", "casgrmsreport_PCD.aspx?id=" + lblprj.Text); 
                else
                    myframe1.Attributes.Add("src", "casgrmsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "14" ||(lblprj.Text == "11784" && lblsch.Text == "37"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3jreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casavireport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casavireport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD") 
                //    myframe1.Attributes.Add("src", "casavireport_pcd.aspx?id=" + lblprj.Text+ "&sch="+lblsch.Text);
                else
                    myframe1.Attributes.Add("src", "casavireport.aspx?id=" + lblprj.Text+ "&sch="+lblsch.Text);
            }
            else if (lblsch.Text == "23" || (lblprj.Text == "11784" && lblsch.Text == "44") || (lblprj.Text == "MOE" && lblsch.Text == "31"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Breport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casbatterychargesreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "12761")
                    myframe1.Attributes.Add("src", "CasFullScheduleReport23.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "caslereport.aspx?id=" + lblsch.Text + "&prj=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (lblsch.Text == "16")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Ireport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "caselvreport.aspx?id=" + lblprj.Text + "_D" + lbldiv.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "caselvreport_oph.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "caselvreport_pcd.aspx?" + url);
                }
                //else if (lblprj.Text == "PCD")
                //    myframe1.Attributes.Add("src", "caselvreport_pcd.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "caselvreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "24" || (lblsch.Text == "41" && lblprj.Text == "123") || (lblprj.Text == "11784" && lblsch.Text == "45")|| (lblprj.Text == "MOE" && lblsch.Text == "32"))
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Kreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "11736")
                    myframe1.Attributes.Add("src", "casph1report.aspx?prj=" + lblprj.Text + "&div=" + lbldiv.Text + "&sch=24");
                else if (lblprj.Text == "12761")
                    myframe1.Attributes.Add("src", "CasFullScheduleReportCP.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casklereport_oph.aspx?" + url);
                }
                //else if (lblprj.Text == "OPH" || lblprj.Text == "PCD")
                //    myframe1.Attributes.Add("src", "casklereport_oph.aspx?id=" + lblprj.Text);
                //else if (lblprj.Text == "11784" || lblprj.Text == "123")
                //    myframe1.Attributes.Add("src", "cas_kit_report.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
                else
                    myframe1.Attributes.Add("src", "casklereport.aspx?id=" + lblprj.Text+"&sch="+lblsch.Text);
            }
            else if (lblsch.Text == "30")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=30_P" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casdfsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "25")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Lreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casISTreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "SRH")
                    myframe1.Attributes.Add("src", "casElvIPTVreport.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
                else
                    myframe1.Attributes.Add("src", "casacmreport.aspx?id=25_P" + lblprj.Text);
            }
            else if (lblsch.Text == "27" || lblsch.Text == "103" || lblsch.Text == "104" || lblsch.Text == "105" || lblsch.Text == "106" || lblsch.Text == "109" || lblsch.Text == "110" || lblsch.Text == "111")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas5Areport.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
                else if (lblprj.Text=="12761")
                    myframe1.Attributes.Add("src", "caslereport.aspx?id=27&prj=" + lblprj.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casPAVAreport.aspx?id=" + lblprj.Text);
              else if (lblprj.Text == "OCEC")
                      myframe1.Attributes.Add("src", "casHvtreport.aspx?id=27&prj=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casacmreport.aspx?id=27_P" + lblprj.Text);
            }
            else if (lblsch.Text == "112" || lblsch.Text == "113" || lblsch.Text == "114" || lblsch.Text == "115" || lblsch.Text == "116")
            {
                myframe1.Attributes.Add("src", "cas5ReportNew.aspx?id=" + lblsch.Text + "_P" + lblprj.Text);
            }
            else if (lblsch.Text == "46")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas5Areport.aspx?id=46_P" + lblprj.Text);
            }
            else if (lblsch.Text == "26")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas3Mreport.aspx?id=" + lblprj.Text);
                else if (lblprj.Text == "OPH")
                    myframe1.Attributes.Add("src", "casldreport_oph.aspx?id=" + lblprj.Text);      
                else
                    myframe1.Attributes.Add("src", "casccsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "28" || lblsch.Text == "100")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas5Breport.aspx?id=" + lblprj.Text);
                else if ((lblprj.Text == "OPH"&& lblsch.Text == "28"))
                    myframe1.Attributes.Add("src", "casMVTreport.aspx?id=" + lblprj.Text);
                else if (isPcdProject)
                {
                    string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                    if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "casMVTreport.aspx?" + url);
                }
                else
                    myframe1.Attributes.Add("src", "casfesreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "29")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "cas1Greport.aspx?id=" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casfpsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "34")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    string _prm = lblprj.Text + "_S" + lblsch.Text;
                    myframe1.Attributes.Add("src", "cassitreport.aspx?id=" + _prm);
                }
                else if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=34_P" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "caspfsreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "35")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    string _prm = lblprj.Text + "_S" + lblsch.Text;
                    myframe1.Attributes.Add("src", "cassitreport.aspx?id=" + _prm);
                }
                else if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=35_P" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casvslreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "36")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=36_P" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "caseotreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "33")
            {
                if (lblprj.Text == "ASAO" || lblprj.Text == "ASAO1")
                {
                    string _prm = lblprj.Text + "_S" + lblsch.Text;
                    myframe1.Attributes.Add("src", "cassitreport.aspx?id=" + _prm);
                }
                else if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=33_P" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "cassitreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "32")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=32_P" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casbmsreport.aspx?id=32_P" + lblprj.Text);
            }
            else if (lblsch.Text == "31")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=31_P" + lblprj.Text);
                else if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                    myframe1.Attributes.Add("src", "casfavareport.aspx?id=31_P" + lblprj.Text + "_D" + lbldiv.Text);

                myframe1.Attributes.Add("src", "casfavareport.aspx?id=31_P" + lblprj.Text);
            }
            else if (lblsch.Text == "37")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=37_P" + lblprj.Text);
                else
                    myframe1.Attributes.Add("src", "casbcreport.aspx?id=" + lblprj.Text);
            }
            else if (lblsch.Text == "38")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=38_P" + lblprj.Text);
            }
            else if (lblsch.Text == "39")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=39_P" + lblprj.Text);
            }
            else if (lblsch.Text == "40")
            {
                if (lblprj.Text == "CCAD")
                    myframe1.Attributes.Add("src", "casfd1report.aspx?id=40_P" + lblprj.Text);
            }
            else
                myframe1.Attributes.Add("src", "");
            //if((string)Session["project"]=="BCC1")
            //    if (lblsch.Text == "1")
            //        myframe1.Attributes.Add("src", "caslvreport.aspx");
        }
        protected void btnrpt_Click(object sender, EventArgs e)
        {
            Load_FullSchedule();
        }
        protected void btnsum_Click(object sender, EventArgs e)
        {
            //myframe1.Attributes.Add("src", "graph.aspx?id=0");
            if (lblsch.Text != "33" || lblprj.Text=="11784")
            {
                if (lblprj.Text == "11736" || lblprj.Text == "Traini" || lblprj.Text == "11736s")
                     myframe1.Attributes.Add("src", "Summary.aspx?id=0" + lblsch.Text + "_P" + lblprj.Text + "_D" + lbldiv.Text);
                else if (isPcdProject)
                {
                    string url = "Id=" + lblsch.Text + "&Prj=" + lblprj.Text + "&Type=0";
                    if (lblprj.Text == "AFV") url = "Id=" + lblsch.Text + "&Prj=" + lblprj.Text + "&Type=0" + "&div=" + lbldiv.Text;
                    myframe1.Attributes.Add("src", "Summary_New.aspx?" + url);
                }
                //else if (isPcdProject)
                //      myframe1.Attributes.Add("src", "Summary_New.aspx?Id=" + lblsch.Text + "&Prj=" + lblprj.Text +"&Type=0");
                else  if (!(lblprj.Text == "12761" && lblsch.Text == "23"))
                     myframe1.Attributes.Add("src", "Summary.aspx?id=0" + lblsch.Text + "_P" + lblprj.Text);
            }
        }
        protected void btnsum1_Click(object sender, EventArgs e)
        {
            //myframe1.Attributes.Add("src", "graph.aspx?id=0");
            //if (lblsch.Text != "33")
            //    myframe1.Attributes.Add("src", "Summary.aspx?id=0" + lblprj.Text);
            //if (lblsch.Text != "33")
            string _parm = lblsch.Text + "_P" + lblprj.Text;
            if (lblprj.Text == "ASAO" || lblprj.Text=="ASAO1")
            {
                myframe1.Attributes.Add("src", "cas_summary.aspx?id=" + _parm);
            }
            else if (lblprj.Text == "CCAD" && lblsch.Text == "8")
            {
                myframe1.Attributes.Add("src", "Summary_Grouped.aspx?id=" + _parm);
            }
            else if (lblprj.Text == "Traini" && lblsch.Text == "8")
            {
                myframe1.Attributes.Add("src", "Summary_Grouped.aspx?id=" + _parm);
            }
            else if (lblprj.Text == "OPH")
            {
                myframe1.Attributes.Add("src", "ReportsNew.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            }
            else if (isPcdProject)
            {
                string url = "id=" + lblprj.Text + "&sch=" + lblsch.Text;
                if (lblprj.Text == "AFV") url = "id=" + lblprj.Text + "&sch=" + lblsch.Text + "&div=" + lbldiv.Text;
                myframe1.Attributes.Add("src", "pcdComparison.aspx?" + url);
            }
            //else if (lblprj.Text == "PCD" || lblprj.Text == "ARSD")
            //{
            //    myframe1.Attributes.Add("src", "pcdComparison.aspx?id=" + lblprj.Text + "&sch=" + lblsch.Text);
            //}
        }

        protected void btninput_Click(object sender, EventArgs e)
        {
           // string _prm = lblsch.Text + "_P" + lblprj.Text;
           // myframe1.Attributes.Add("src", "../CAS/TC2.aspx?id=" + _prm);
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Not Available');", true);
        }

    }
}
