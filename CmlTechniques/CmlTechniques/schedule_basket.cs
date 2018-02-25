using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CmlTechniques
{
    public class schedule_basket
    {
        private static DataTable _basket;

        static schedule_basket()
		{
			// Initialise data
            _basket = new DataTable();
            _basket.Columns.Add("id", typeof(int));
            _basket.Columns.Add("service", typeof(string));
            _basket.Columns.Add("package", typeof(string));
            _basket.Columns.Add("doctype", typeof(string));
            _basket.Columns.Add("doctitle", typeof(string));
            _basket.Columns.Add("docname", typeof(string));
            _basket.Columns.Add("Folder_name", typeof(string));
            _basket.Columns.Add("Folder_id", typeof(string));
		}
        public DataTable GetData()
        {
            return _basket;
        }
        public int GetCount()
        {
            //return data.Rows.Count;
            return _basket.Rows.Count;
        }
        public void Insert(string service, string package, string doctype, string doctitle, string docname,string folder_name,string folder_id)
        {
            _basket.Rows.Add(new object[] { _basket.Rows.Count + 1, service, package, doctype, doctitle, docname, folder_name, folder_id});
        }
        public void Delete(int id)
        {
            _basket.Select("Id=" + id)[0].Delete();
            _basket.AcceptChanges();
        }
        public void clear()
        {
            _basket.Rows.Clear();
        }
        public void Update(int id, string name, int stockLevel)
        {
            //DataRow row = data.Select("Id=" + id)[0];
            //row["Name"] = name;
            //row["StockLevel"] = stockLevel;
        }
        public void rowup(int idx)
        {
            _basket.Select("Id=" + idx)[0] = _basket.Rows[idx + 1];
        }
    }
}
