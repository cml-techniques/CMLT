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
using BusinessLogic;
using App_Properties;

namespace CmlTechniques.CMS
{
    public partial class DocPdfView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                lblprjid.Text = Request.QueryString["prj"].ToString();
                lblmod.Text = Request.QueryString["mod"].ToString();
                lblid.Text = Request.QueryString["doc"].ToString();

                Get_Title((string)Session["file"]);
                string file = "https://cmltechniques.com/CMS_DOCS/" + lblprjid.Text + "/" + (string)Session["file"];

                //string file = "http://www.cmltechniques.com/CMS_DOCS/12761/Pump alignment and setting to work Rev00 updated 8.7.14.pdf";

                myframe.Attributes.Add("src", file);

            }
        }
        private void Get_Title(string _file)
        {
            if (lblmod.Text == "FAT")
                {
                    if (lblprjid.Text == "MOE")
                    {
                        lbltitle.Text = "Commissioning Report | " + _file;
                    }

                    else
                        lbltitle.Text = "Factory Acceptance Test Uploads | " + _file;
                }
            else if (lblmod.Text == "MRPT")
            {
                lbltitle.Text = "Monthly Report | " + _file;

            }
        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            //Response.Redirect("CMS.aspx?mod=" + lblmod.Text + "&PRJ=" + lblprjid.Text + "&id=" + lblid.Text);

            //if (lblprjid.Text == "HMIM")
            //{
            //    Response.Redirect("CMS.aspx?mod=" + lblmod.Text +"&PRJ=" + lblprjid.Text + "&id=" + lblid.Text);
            //}
            //else
            //{
            //    Response.Redirect("CMS.aspx?mod=FAT&PRJ=" + lblprjid.Text + "&id=" + lblid.Text);
            //}
            if (lblprjid.Text == "HMIM")
            {
                //Response.Redirect("CMS2.aspx?mod=" + lblmod.Text + "&PRJ=" + lblprjid.Text + "&id=" + lblid.Text);
                Response.Redirect("CMS2.aspx?auh=" + (string)Session["uid"] + "&prj=" + lblprjid.Text + "&mod=" + lblmod.Text + "&id=" + lblid.Text);
            }
            else
            {
                Response.Redirect("CMS.aspx?mod=" + lblmod.Text + "&PRJ=" + lblprjid.Text + "&id=" + lblid.Text);
            }


        }

    }
}
