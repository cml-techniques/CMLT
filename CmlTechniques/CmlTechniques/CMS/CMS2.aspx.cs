using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CmlTechniques.CMS
{
    public partial class CMS2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string PName = "";
                if (Request.UrlReferrer != null)
                {
                    PName = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                }

                if (PName == "")
                {
                    Response.Redirect("https://cmltechniques.com");
                }

                string _prm = Request.QueryString[0].ToString();
                _prm = _prm.Replace("%", " ");

                string _id = "";
                string _user = (string)Session["uid"];
                string _mode = "";
                string _prj = "";

                if (_prm.Substring(0, 2) == "1P")
                {
                     _mode = _prm.Substring(_prm.IndexOf("M_") + 2);
                     _prj = _prm.Substring(_prm.IndexOf("P_") + 2, _prm.IndexOf("M_") - (_prm.IndexOf("P_") + 2));

                    if (_mode == "CP")
                    {
                     
                        if (_mode == "CP")
                        {
                            _id = "2_M2_NCommissioning Plan_P" + _prj;
                            //else if (_mod == "CR")
                            //    _id = "19_M19_NCommissioning Report_P" + _prj;
                            content.Attributes.Add("src", "cplans.aspx?id=" + _id);

                        }
                    }
                    else if  (_mode == "SO")
                    {
                        content.Attributes.Add("src", "so.aspx?PRJ=" + _prj + "&ACN=0");
                    }
                    else if (_mode == "DR")
                    {

                        content.Attributes.Add("src", "cmsdocreview.aspx?PRJ=" + _prj + "&ACN=0");
                    }
                    else
                    {
                       _mode = _prm.Substring(_prm.IndexOf("M_") + 2, _prm.IndexOf("F_") - (_prm.IndexOf("M_") + 2));
                        //string _mod = _prm.Substring(_prm.IndexOf("M_") + 2);

                        string _fol = _prm.Substring(_prm.IndexOf("F_") + 2, _prm.IndexOf("FI_") - (_prm.IndexOf("F_") + 2));
                        string _fid = _prm.Substring(_prm.IndexOf("FI_") + 3);

                        if (_mode == "Minutes")
                        {

                            _id = _fid + "_M5_NMinutes > " + _fol + "_P" + _prj;
                            content.Attributes.Add("src", "../cmsminutes.aspx?id=" + _id);

                        }
                        else if (_mode == "Programmes")
                        {
                            _id = _fid + "_M6_NProgrammes > " + _fol + "_P" + _prj;
                            content.Attributes.Add("src", "../cmsprogrammes.aspx?id=" + _id);
                        }


                    }


                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prj + "&ID=" + _user);
                        head.Attributes.Add("src", "../head1.aspx?mod=CMS&prj=" + _prj + "&auh=" + _user);
                        menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + _prj);



                }
                else if (_prm.Substring(0, 2) == "MS")
                {

                    _prj = Request.QueryString["prj"].ToString();

                    if (_prj == "HMIM" || _prj == "HMHS")
                    {
                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prj + "&ID=" + _user);
                        head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + _prj);
                        menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + _prj);

                        var id = "id=" + Request.QueryString["id"].ToString() + "&Div=" + Request.QueryString["Div"].ToString();

                        content.Attributes.Add("src", "methodstatements1.aspx?" + id);
                    }



                }
                else
                {

                    _user = Request.QueryString["auh"].ToString();
                    _prj = Request.QueryString["prj"].ToString();
                    _mode = Request.QueryString["mod"].ToString();
                    //string _pkg = Request.QueryString["pkg"].ToString();
                    //string _fac = Request.QueryString["fac"].ToString();
                    if (_mode == "0")
                    {
                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prj + "&ID=" + _user);
                        head.Attributes.Add("src", "../head1.aspx?mod=CMS&prj=" + _prj + "&auh=" + _user);
                        menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + _prj);
                    }
                    else if (_mode == "MRPT")
                    {
                        tree.Attributes.Add("src", "cmstree.aspx?PRJ=" + _prj + "&ID=" + _user);
                        head.Attributes.Add("src", "../head.aspx?id=CMS&prj=" + _prj);
                        menu.Attributes.Add("src", "cmsmenu.aspx?prj=" + _prj);

                        if (_prj == "HMIM") content.Attributes.Add("src", "MonthlyReport.aspx?" + Request.QueryString.ToString());

                    }
                }
            }
        }
    }
}