using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic;
using App_Properties;
using System.Data;
using System.Web.Services;
using System.IO;

namespace CmlTechniques.CMS
{
    /// <summary>
    /// Summary description for LoadImage
    /// </summary>
    public class LoadImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                string projectcode = "";
                if (context.Request.QueryString["id"] != null)
                    projectcode = context.Request.QueryString["id"].ToString();


                context.Response.ContentType = "image/jpeg";
                Stream strm = ShowProjectImage(projectcode);
                byte[] buffer = new byte[4096];
                int byteSeq = strm.Read(buffer, 0, 4096);

                while (byteSeq > 0)
                {
                    context.Response.OutputStream.Write(buffer, 0, byteSeq);
                    byteSeq = strm.Read(buffer, 0, 4096);
                }

             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            }
        public Stream ShowProjectImage(string projectcode)
        {


            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DBCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = projectcode;
            DataTable dt = _objbll.Get_ProjectInformation(_objcls, _objdb);

            object img=null;
            foreach (DataRow dr in dt.Rows)
            {
                img = dr["prj_logo"];
            }
         
            try
            {
                return new MemoryStream((byte[])img);
            }
            catch
            {
                return null;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}