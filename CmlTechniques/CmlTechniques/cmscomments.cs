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
    public class cmscomments
    {
         private static DataTable _basket;

         static cmscomments()
		{
			// Initialise data
            _basket = new DataTable();
            _basket.Columns.Add("id", typeof(int));
            _basket.Columns.Add("comment", typeof(string));
           
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
        //[DataObjectMethod(DataObjectMethodType.Select)]
		public DataTable GetData()
		{
            //return data;
            return _basket;
		}

		/// <summary>
		/// Gets the number of entries.
		/// </summary>
		public int GetCount()
		{
            //return data.Rows.Count;
            return _basket.Rows.Count;
		}

		/// <summary>
		/// Adds an entry.
		/// </summary>
        //[DataObjectMethod(DataObjectMethodType.Insert)]
		public void Insert(string comment)
		{
            _basket.Rows.Add(new object[] { _basket.Rows.Count + 1, comment });            
		}

		/// <summary>
		/// Updates an entry.
		/// </summary>
        //[DataObjectMethod(DataObjectMethodType.Update)]
		public void Update(int id, string name, int stockLevel)
		{
            //DataRow row = data.Select("Id=" + id)[0];
            //row["Name"] = name;
            //row["StockLevel"] = stockLevel;
		}

		/// <summary>
		/// Deletes an entry.
		/// </summary>
        //[DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int id)
		{
            _basket.Select("Id=" + id)[0].Delete();
            _basket.AcceptChanges();
		}
        public void clear()
        {
            _basket.Rows.Clear();
        }
    }
}
