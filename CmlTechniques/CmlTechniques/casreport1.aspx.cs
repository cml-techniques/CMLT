using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.Drawing;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
//http://www.agrinei.com/gridviewhelper/gridviewhelper_en.htm
namespace CmlTechniques
{
    public partial class casreport1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    Load_Ini_Data();
        }

        protected void export_Click(object sender, EventArgs e)
        {
            //Response.Clear();    // Setup the response header.    
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=CasSheet.xls");
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.Charset = "";    // Turn off view state.    
            //this.EnableViewState = false;    // Create a string writer.    
            //var stringWriter = new StringWriter();    // Create an HTML text writer and give it a string writer to use.    
            //var htmlTextWriter = new HtmlTextWriter(stringWriter);    // Disable paging so we get all rows.    
            ////dsTrucks.EnablePaging = false;    // Render the list view control into the HTML text writer.    
            //// my_in_view.DataBind();
            //mygrid.RenderControl(htmlTextWriter);
            ////listViewTrucks.RenderControl(htmlTextWriter);    // Grab the final HTML out of the string writer.    
            //string output = stringWriter.ToString();    // Write the HTML output to the response, which in this case, is an Excel file.    
            //Response.Write(output);
            //Response.End();
            //VerifyRenderingInServerForm(mygrid);
            Response.Clear();

            Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");

            Response.Charset = "";

            // If you want the option to open the Excel file without saving than

            // comment out the line below

            // Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();

            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            mygrid.RenderControl(htmlWrite);

            Response.Write(stringWrite.ToString());

            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

            // Confirms that an HtmlForm control is rendered for the
            //specified ASP.NET server control at run time.


        }

        protected void Load_Ini_Data()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_clscassheet _objcas = new _clscassheet();
            ////Session["sch"] = Request.QueryString[0].ToString();
            //_objcas.sch = 4;
            //_objcas.prj_code = "1";
            //mygrid.DataSource = _objbll.Load_casMain(_objcas);
            //mygrid.DataBind();
            //load_cas_sys();
            GridViewHelper _help = new GridViewHelper(mygrid);
            _help.RegisterGroup("sys_name", true, true);
            _help.ApplyGroupSort();
            
            
        }

        protected void print_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
       
    }
}
