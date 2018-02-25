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
using System.IO;
using App_Properties;


namespace CmlTechniques
{
    public partial class tcuploadmulti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Session["casid"] = "2";
                //Session["project"] = "123";
                loadData();
            }

        }
        void loadData() 
        {
            BLL_Dml _dtobj = new BLL_Dml();
            _database _objdb = new _database();
            _clsams _objcls = new _clsams();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _objcls.sys_id = Convert.ToInt32((string)Session["casid"]);

            DataTable _dtable = _dtobj.Get_Cassheet_master_Dtls(_objcls,_objdb);

            gvupload.DataSource = _dtable;
            gvupload.DataBind();

        }

        bool validation()
        {
            bool val=false;
           foreach (GridViewRow gvRow in gvupload.Rows)
            {
              FileUpload file = (FileUpload)gvRow.FindControl("fupload");
                if (file.HasFile) return true;

           }
            return val;
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (!validation())
            {

                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select the file!');", true);
                return;
            }

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + (string)Session["project"];
            _clscassheet _objcls = new _clscassheet();
            string _dir = (string)Session["project"];

            if (Directory.Exists(Server.MapPath("CMS_DOCS") + "\\" + _dir) == false)
                Directory.CreateDirectory(Server.MapPath("CMS_DOCS") + "\\" + _dir);

            foreach (GridViewRow gvRow in gvupload.Rows)
            {


                FileUpload file = (FileUpload)gvRow.FindControl("fupload");
                if (file.HasFile)
                {
                    file.SaveAs(Server.MapPath("CMS_DOCS") + "\\" + _dir + "\\" + System.IO.Path.GetFileName(file.FileName));

                    _objcls.cas_id = Convert.ToInt16(gvRow.Cells[5].Text);
                    _objcls.ts_filed = DateTime.Now.ToString().Substring(0, 10);
                    _objcls.testsheet = System.IO.Path.GetFileName(file.FileName);
                    _objbll.Upload_TestSheet(_objcls, _objdb);
                    

                }
             }
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Test sheet Sucessfully Uploaded!');", true);
            Response.Redirect("tcdocumentation.aspx?" + Request.QueryString.ToString());      
            }

        protected void gvupload_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            e.Row.Cells[5].Visible = false;
            
        }

        protected void brncancel_Click(object sender, EventArgs e)
        {
           Response.Redirect("tcdocumentation.aspx?" + Request.QueryString.ToString());      

        }

        }
}
