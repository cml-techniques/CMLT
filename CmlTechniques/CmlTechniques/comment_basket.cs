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
    //[dataobject]
    public class comment_basket
    {
        private static DataTable _basket;

        static comment_basket()
		{
			// Initialise data
            _basket = new DataTable();
            _basket.Columns.Add("id", typeof(int));
            //_basket.Columns.Add("page", typeof(string));
            //_basket.Columns.Add("sec", typeof(string));
            _basket.Columns.Add("comment", typeof(string));
            _basket.Columns.Add("desc", typeof(string));
            //_basket.Columns.Add("uid", typeof(string));
            //_basket.PrimaryKey = new DataColumn[] { _basket.Columns[0] };
            //_basket.Rows.Add(new object[] { 1, "1","2","1450" });
            //_basket.Rows.Add(new object[] { 2, "1", "3", "14502222" });
            //_basket.Rows.Add(new object[] { 2, "Socks", 543 });
            //_basket.Rows.Add(new object[] { 3, "Hats", 26 });
            //_basket.Rows.Add(new object[] { 4, "Shoes", 341 });
            //_basket.Rows.Add(new object[] { 5, "Belts", 897213 });
            //_basket.Rows.Add(new object[] { 6, "Gloves", 217 });
            //_basket.Rows.Add(new object[] { 7, "Ties", 6812 });
            //_basket.Rows.Add(new object[] { 8, "Shorts", 6854432 });
            //_basket.Rows.Add(new object[] { 9, "Shirts", 703354 });
            //_basket.Rows.Add(new object[] { 10, "Jackets", 68045 });
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
		public void Insert(string comment,string desc)
		{
            _basket.Rows.Add(new object[] { _basket.Rows.Count + 1,comment,desc });            
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
