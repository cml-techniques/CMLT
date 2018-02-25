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
using com.flajaxian;
using BusinessLogic;
using App_Properties;
using System.IO;

namespace CmlTechniques
{
    public partial class MultiUpload : System.Web.UI.Page
    {
        public static DataTable _dtable;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //    Load_Schedule();

        }
        private void Load_Schedule()
        {

            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = (string)Session["project"];
            _dtable = _objbll.load_schedule(_objcls, _objdb);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void FileUploader1_FileReceived(object sender, com.flajaxian.FileReceivedEventArgs e)
        {

            if (Validate_File(e.File.FileName) == true)
            {
                e.File.SaveAs(Server.MapPath("Documents" + "\\" + e.File.FileName));
                Multi_Upload(e.File.FileName);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('" + e.File.FileName + "');", true);
            }
        }
        private bool Validate_File(string _fname)
        {
            string _Doc_type = (string)Session["folder"];
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_objdb.DBName = "dbCML";
            //_clsuser _objcls = new _clsuser();
            //_objcls.project_code = (string)Session["project"];
            //DataTable _schedule = _objbll.load_schedule(_objcls, _objdb);
            //DataTable _dtable1 = new DataTable();
            //_dtable1.Columns.Add("package");
            //_dtable1.Columns.Add("Folder");
            //_dtable1.Columns.Add("manufacture");
            //_dtable1.Columns.Add("doc_name");
            //_dtable1.Columns.Add("Folder_id");
            //_dtable1.Columns.Add("id");
            //_dtable1.Columns.Add("srv");
            var _List = from o in _dtable.AsEnumerable()
                        where o.Field<int>(5) == Convert.ToInt32(_Doc_type) && o.Field<string>(3) == _fname
                        select o;
            foreach (var row in _List)
            {
                //if (_fname == row[3].ToString())
                //{
                FileInfo _finfo = new FileInfo(Server.MapPath("Documents" + "\\" + _fname));
                if (_finfo.Exists == true) _finfo.Delete();
                lblpos.Text = row["possition"].ToString();
                return true;
                //}
            }
            lblpos.Text = "0";
            return false;
        }
        private void Multi_Upload(string _fname)
        {
            string _Doc_type = (string)Session["folder"];
            var _List = from o in _dtable.AsEnumerable()
                        where o.Field<int>(5) == Convert.ToInt32(_Doc_type) && o.Field<string>(3) == _fname
                        select o;
            try
            {
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "dbCML";
                _clsdocument _objcls = new _clsdocument();
                foreach (var row in _List)
                {
                    //if (_fname == row[3].ToString())
                    //{
                        FileInfo _finfo = new FileInfo(Server.MapPath("Documents" + "\\" + _fname));
                        if (_finfo.Exists == true)
                        {

                            _objcls.doc_name = row[3].ToString();
                            _objcls.doc_title = row[2].ToString();
                            _objcls.doctype_code = 0;
                            _objcls.package_code = 0;
                            _objcls.uploaded_date = DateTime.Now;
                            _objcls.service_code = 0;
                            _objcls.uploaded = true;
                            _objcls.schid = Convert.ToInt32(row[0].ToString());
                            _objcls.folder_id = Convert.ToInt32(row[5].ToString());
                            string _size = _finfo.Length.ToString();
                            _objcls.file_size = decimal.Round((Convert.ToDecimal(_size) / 1024), 2).ToString() + "KB";
                            // _objcls.file_size = decimal.Round((Convert.ToDecimal(_size) / 1024), 2).ToString() + "KB";
                            _objcls.uid = (string)Session["uid"];
                            _objcls.type = "";
                            _objcls.possition = Convert.ToInt32(lblpos.Text);
                            _objbll.file_upload(_objcls, _objdb);
                            return;

                        }
                    }
                //}

            }
            catch (Exception ex)
            {
                //Label1.Text = ex.ToString();
            }

        }
        protected void FileUploader1_DataBinding(object sender, EventArgs e)
        {
            
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('hai');", true);
        }
        protected void FileNameDetermining(object sender, FileNameDeterminingEventArgs args)
        {

            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('hai');", true);
        }

        protected void FileUploader1_Init(object sender, EventArgs e)
        {

        }

        protected void FileUploader1_PreRender(object sender, EventArgs e)
        {

        }

    }
}
