using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
using System.IO;

namespace CmlTechniques
{
    public partial class casreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Load_Ini_Data();
        }
        protected void Load_Ini_Data()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clscassheet _objcas = new _clscassheet();
            //Session["sch"] = Request.QueryString[0].ToString();
            _objcas.sch = 4;
            _objcas.prj_code = "1";
            myview.DataSource = _objbll.Load_casMain(_objcas,_objdb);
            myview.DataBind();
            //load_cas_sys();
        }

        protected void export_Click(object sender, EventArgs e)
        {
            Response.Clear();    // Setup the response header.    
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=CasSheet.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";    // Turn off view state.    
            this.EnableViewState = false;    // Create a string writer.    
            var stringWriter = new StringWriter();    // Create an HTML text writer and give it a string writer to use.    
            var htmlTextWriter = new HtmlTextWriter(stringWriter);    // Disable paging so we get all rows.    
            //dsTrucks.EnablePaging = false;    // Render the list view control into the HTML text writer.    
            // my_in_view.DataBind();
            myview.RenderControl(htmlTextWriter);
            //listViewTrucks.RenderControl(htmlTextWriter);    // Grab the final HTML out of the string writer.    
            string output = stringWriter.ToString();    // Write the HTML output to the response, which in this case, is an Excel file.    
            Response.Write(output);
            Response.End();
        }

        protected void print_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
