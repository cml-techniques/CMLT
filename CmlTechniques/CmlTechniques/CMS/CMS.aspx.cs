using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CmlTechniques.CMS
{
    public partial class CMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {

                //if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                //{
                string _prm = Request.QueryString[0].ToString();
                //http://www.cmldubai.com/Default.aspx?Id=1P_1_M1_NMethod%Statement%20%Electrical%20%1.01%%HV%Panels%and%switchgear%20%MS_P123M_1
                //string _prm = "1P_1_M1_NMethod%Statement%_A%Electrical%_A%1.01%%HV%Panels%and%switchgear%_A%MS_P123M_1";
                //string _123 = "1P_1_M1_NMethod%Statement%_A%Electrical%_A%1.01%%HV%Panels%and%switchgear%_A%MS_P123M_1";
               // string _345 = "1P_1_M1_NMethod%Statement %Electrical %1.01%%HV%Panels%and%switchgear %MS_P123M_1";
                //_prm = "1P_OPHM_MinutesF_Comm.%MeetingsFI_10";
                _prm = _prm.Replace("%", " ");
                if (_prm.Substring(0, 2) == "1P")
                {
                    string _mod = _prm.Substring(_prm.IndexOf("M_") + 2);
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _mod + "');", true);
                    string _prj = "";
                    if (_mod != "1")
                        _prj = _prm.Substring(_prm.IndexOf("P_") + 2, _prm.IndexOf("M_") - (_prm.IndexOf("P_") + 2));
                    string _fol = "";
                    string _fid = "";
                    string _id = "";
                    if (_mod == "CP")
                    {
                        _id = "2_M2_NCommissioning Plan_P" + _prj;
                        content.Attributes.Add("src", "cmsdoclist.aspx?id=" + _id);                       

                    }
                    else if (_mod == "CR")
                    {
                        _id = "15_M14_NCommissioning Reports_P" + _prj;
                        content.Attributes.Add("src", "cmsdoclist.aspx?id=" + _id);
                    }
                    else if (_mod == "DR")
                    {
                        content.Attributes.Add("src", "cmsdocreview.aspx?PRJ=" + _prj + "&ACN=0");
                    }
                    else if (_mod == "SO")
                    {
                        if (Session["access"] == null || Session["access"].ToString() == "")
                        {
                            if (Session["uid"].ToString().IndexOf("@cmlgroup.ae") == -1)
                            {
                                Session["access"] = "Read Only";
                            }
                            else
                            {
                                Session["access"] = "Review/Comment";
                            }
                        }
                        //content.Attributes.Add("src", "so.aspx?PRJ=" + _prj+"&ACN=0");
                        content.Attributes.Add("src", "SOLog.aspx?PRJ=" + _prj + "&ACN=0");
                    }
                    else if (_mod == "1")
                    {
                        _prm = _prm.Replace("20", ">");
                        _prj = _prm.Substring(_prm.IndexOf("_P") + 2, _prm.IndexOf("M_") - (_prm.IndexOf("_P") + 2));
                        _id = _prm.Substring(_prm.IndexOf("P_") + 2, _prm.IndexOf("M_") - (_prm.IndexOf("P_") + 2));
                        content.Attributes.Add("src", "methodstatements.aspx?id=" + _id);
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _id + "');", true);
                    }
                    else if (_mod == "FAT")
                    {
                        if (_prj == "MOE") content.Attributes.Add("src", "FATestUploadsList1.aspx?" + Request.QueryString.ToString());
                        else content.Attributes.Add("src", "FATestUploadsList.aspx?" + Request.QueryString.ToString());
                    }
                    else
                    {
                        _mod = _prm.Substring(_prm.IndexOf("M_") + 2, _prm.IndexOf("F_") - (_prm.IndexOf("M_") + 2));
                        _fol = _prm.Substring(_prm.IndexOf("F_") + 2, _prm.IndexOf("FI_") - (_prm.IndexOf("F_") + 2));
                        _fid = _prm.Substring(_prm.IndexOf("FI_") + 3);
                        if (_mod == "Minutes")
                        {
                            _id = _fid + "_M5_NMinutes > " + _fol + "_P" + _prj;
                            content.Attributes.Add("src", "../cmsminutes.aspx?id=" + _id);
                        }
                        else if (_mod == "Programmes")
                        {
                            _id = _fid + "_M6_NProgrammes > " + _fol + "_P" + _prj;
                            content.Attributes.Add("src", "../cmsprogrammes.aspx?id=" + _id);
                        }

                    }
                    //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + _mod + "');", true);
                    if (_prj == "11736" || _prj == "Traini")
                        tree.Attributes.Add("src", "cmstree1.aspx?PRJ=" + _prj);
                    //else if (_prj == "11736i")
                    //    tree.Attributes.Add("src", "cmstree2.aspx?PRJ=" + _prj);
                    else
                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prj + "&ID=" + (string)Session["uid"]);
                    head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + _prj);
                    menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + _prj);
                }
                else if (_prm == "CP" || _prm == "CR") 
                {
                    string prm = (string)Session["project"];

                    if (prm == "11736" || prm == "Traini")
                        tree.Attributes.Add("src", "cmstree1.aspx?PRJ=" + prm);
                    //else if (prm == "11736i")
                    //    tree.Attributes.Add("src", "cmstree2.aspx?PRJ=" + prm);
                    else
                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + prm + "&ID=" + (string)Session["uid"]);

                    head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + prm);
                    menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + prm);
                    string _id = "";
                    if(_prm=="CP")
                        _id = "2_M2_NCommissioning Plan_P" + prm;
                    else if (prm == "ABS" && _prm == "CR")
                        _id = "15_M14_NCommissioning Reports_P" + prm;
                    else if(_prm=="CR")
                        _id = "19_M19_NCommissioning Report_P" + prm;                    
                    content.Attributes.Add("src", "cmsdoclist.aspx?id=" + _id);
                    


                }
                else if (_prm == "MS")
                {
                    string prm = (string)Session["project"];
                    if (prm == "ABS")
                    {
                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + prm + "&ID=" + (string)Session["uid"]);
                        head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + prm);
                        menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + prm);

                        var id = "id=" + Request.QueryString["id"].ToString() + "&Div=" + Request.QueryString["Div"].ToString();

                        content.Attributes.Add("src", "methodstatements1.aspx?" + id);
                    }

                    else
                    {

                        if (prm == "11736" || prm == "Traini")
                            tree.Attributes.Add("src", "cmstree1.aspx?PRJ=" + prm);
                        //else if (prm == "11736i")
                        //    tree.Attributes.Add("src", "cmstree2.aspx?PRJ=" + prm);
                        else
                            tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + prm + "&ID=" + (string)Session["uid"]);

                        head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + prm);
                        menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + prm);
                        string _id = Session["Fold_cms"].ToString() + "_M" + Session["M_id_cms"].ToString() + "_N" + Session["M_na_cms"].ToString() + "_P" + Session["project"].ToString() + "_V" + Session["Treepath"].ToString();
                        if (prm == "12761")
                            content.Attributes.Add("src", "ms12761.aspx?id=" + _id);
                        else
                            content.Attributes.Add("src", "methodstatements.aspx?id=" + _id);

                    }

                }
                else if (_prm == "PV")
                {
                    string prm = (string)Session["project"];

                    if (prm == "11736" || prm == "Traini")
                        tree.Attributes.Add("src", "cmstree1.aspx?PRJ=" + prm);
                    //else if (prm == "11736i")
                    //    tree.Attributes.Add("src", "cmstree2.aspx?PRJ=" + prm);
                    else
                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + prm + "&ID=" + (string)Session["uid"]);

                    head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + prm);
                    menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + prm);
                    string _id = Session["Fold_cms"].ToString() + "_M" + Session["M_id_cms"].ToString() + "_N" + Session["M_na_cms"].ToString() + "_P" + Session["project"].ToString() + "_V" + Session["Treepath"].ToString();
                    content.Attributes.Add("src", "../cmsprogrammes.aspx?id=" + _id);


                }
                else if (_prm == "FAT")
                {
                    //_prm = (string)Session["project"];
                    _prm = Request.QueryString["prj"].ToString();
                   tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prm + "&ID=" + (string)Session["uid"]);
                    head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + _prm);
                    menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + _prm);

                    if (_prm == "MOE") content.Attributes.Add("src", "FATestUploadsList1.aspx?" + Request.QueryString.ToString());
                    else
                        content.Attributes.Add("src", "FATestUploadsList.aspx?" + Request.QueryString.ToString());

                }
                else if (_prm == "MRPT")
                {
                    //_prm = (string)Session["project"];
                    _prm = Request.QueryString["PRJ"].ToString();

                    tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prm + "&ID=" + (string)Session["uid"]);
                    head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + _prm);
                    menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + _prm);

                    if (_prm == "HMIM") content.Attributes.Add("src", "MonthlyReport.aspx?" + Request.QueryString.ToString());


                }
                else
                {
                    if (_prm == "000") _prm = (string)Session["project"];
                    if (_prm == "11736" || _prm == "Traini")
                        tree.Attributes.Add("src", "cmstree1.aspx?PRJ=" + _prm);
                    //else if (_prm == "11736i")
                    //    tree.Attributes.Add("src", "cmstree2.aspx?PRJ=" + _prm);
                    else
                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prm + "&ID=" + (string)Session["uid"]);
                    head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + _prm);
                    menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + _prm);

                    if (_prm == "PCD" || _prm == "ARSD") content.Attributes.Add("src", "Dashboard1.aspx?prj=" + _prm);
                }
                


                //}
                //string _prm=Request.QueryString["PRJ"].ToString();
                //tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prm);
                //else
                //    Response.Redirect("../userlogin.aspx?id=1P_123M_CP");
            }
            //}
        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["uid"] != null)
                {
                    Session["uid"] = Server.HtmlEncode(Request.Cookies["uid"].Value);
                }
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }

            }
        }
    }
}
