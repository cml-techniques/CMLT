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
using System.Text;
//using System.Net.Mail;
//using System.Net;
using System.Net.Mail;
using BusinessLogic;
using App_Properties;
using System.Xml;
using System.Net;

namespace publicCls
{
    public class publicCls
    {
        public static string _user = "";
        public static string _logintime = "";
        public static string _filename = "";
        public static string _access = "";
        public static string _doctype = "";
        public static string _project = "";
        public static string _project_name = "";
        public static DataTable _dtservice;
        public static DataTable _dtpackage;
        public static DataTable _dtdoctype;
        public static DataTable _dtgroup;
        public static DataTable _dtsubgroup;
        public static DataTable _dtsubgroup1;
        public static DataTable _dtdocuments;
        public static DataTable _dtdocdur;
        public static DataTable _dtsnag;
        public void Send_Email(string _toAddress, string _Subject, string _Body)
        {
            try
            {
                SmtpClient _myclient = new SmtpClient("mail.cmltechniques.com");
                _myclient.EnableSsl = false;
                _myclient.Port = 25;
                _myclient.Credentials = new System.Net.NetworkCredential("admin@cmltechniques.com", "Admin@123");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("\"CML Techniques\"  <admin@cmltechniques.com>");
                msg.To.Add(new MailAddress(_toAddress));
                msg.Priority = MailPriority.High;
                msg.Subject = _Subject;
                msg.Body = _Body;
                _myclient.Send(msg);

                //SmtpClient _myclient = new SmtpClient("213.171.197.40", 25);
                ////_myclient.EnableSsl = true;
                //_myclient.Credentials = new System.Net.NetworkCredential("admin@cmldubai.com", "Cmluser@123");
                //MailMessage msg = new MailMessage();
                //msg.From = new MailAddress("\"CML Techniques\"  <admin@cmltechniques.com>");
                //msg.To.Add(new MailAddress(_toAddress));
                //msg.Subject = _Subject;               
                //msg.Body = _Body;
                //_myclient.Send(msg);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Send_Email_Html(string _toAddress, string _Subject, string _Body)
        {
            try
            {

                SmtpClient _myclient = new SmtpClient("mail.cmltechniques.com");
                _myclient.EnableSsl = false;
                _myclient.Port = 25;
                _myclient.Credentials = new System.Net.NetworkCredential("admin@cmltechniques.com", "Admin@123");
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("\"CML Techniques\"  <admin@cmltechniques.com>");
                msg.To.Add(new MailAddress(_toAddress));
                msg.Priority = MailPriority.High;
                msg.Subject = _Subject;
                msg.Body = _Body;
                _myclient.Send(msg);

                //SmtpClient _myclient = new SmtpClient("cmltechniques.com");
                //_myclient.EnableSsl = false;
                //_myclient.Port = 25;
                //_myclient.Credentials = new System.Net.NetworkCredential("webmail@cmltechniques.com", "cml@123");
                //MailMessage msg = new MailMessage();
                //msg.From = new MailAddress("\"CML Techniques\"  <webmail@cmltechniques.com>");
                //msg.To.Add(new MailAddress(_toAddress));
                //msg.Priority = MailPriority.High;
                //msg.Subject = _Subject;
                //msg.IsBodyHtml = true;
                //msg.Body = _Body;
                ////_myclient.Send("admin@cmlinternational.net", _toAddress, _Subject, _Body);
                //_myclient.Send(msg);

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
        public void Load_Tree(string project, string user)
        {
            //if (user != "nothing")
            //    if (_dtservice != null) return;
            BLL_Dml _dtobj = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = project;
            _objcls.uid = user;
            _dtservice = _dtobj.load_service(_objcls, _objdb);
            _dtpackage = _dtobj.load_package(_objdb);
            _dtdoctype = _dtobj.load_doctype(_objdb);
            _dtgroup = _dtobj.load_group(_objdb);
            _dtsubgroup = _dtobj.load_subgroup(_objdb);
            _dtsubgroup1 = _dtobj.load_subgroup1(_objdb);
        }
        public void Load_Documents()
        {
            //if (_dtdocuments != null) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _dtdocuments = _objbll.load_documentsALL(_objdb);

        }
        public void Load_doc_dur()
        {
            //if (_dtdocdur != null) return;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _dtdocdur = _objbll.Load_Doc_Dur(_objdb);
        }
        public void SendReminder(string _project)
        {
            DateTime _today = DateTime.Now;
            var _result = from o in _dtdocdur.AsEnumerable()
                          where o.Field<string>(9) == _project
                          select o;
            foreach (var row in _result)
            {
                DateTime _upload = Convert.ToDateTime(row[4].ToString());
                TimeSpan _Diff = _today.Subtract(_upload);
                if (_Diff.Days == Convert.ToInt32(row[6].ToString()))
                {
                    SendRem(_Diff.Days.ToString(), row[10].ToString(), row[2].ToString(), "First Reminder");
                }
                else if (_Diff.Days == Convert.ToInt32(row[7].ToString()))
                {
                    SendRem(_Diff.Days.ToString(), row[10].ToString(), row[2].ToString(), "Second Reminder");
                }
                else if (_Diff.Days == Convert.ToInt32(row[8].ToString()))
                {
                    SendRem(_Diff.Days.ToString(), row[10].ToString(), row[2].ToString(), "Third Reminder");
                }

            }
        }
        void SendRem(string _days, string project, string package, string rem)
        {
            string Body = "Ref. " + project + " - " + package + "\n\n" + "This is an automatically generated email to advise you that there is " + _days + " days left for review and comments on the above O & M Manual." + "\n\n" + "Thank you in anticipation of co-operation." + "\n\n" + "CML" + "\n" + "Techniques" + "\n\n\n" + "http://www.cmlinternational.net/aspnet/default.aspx";
            string _sub = "Ref. " + project + " - " + package + " " + rem;
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsuser _objcls = new _clsuser();
            _objcls.project_code = project;
            DataTable _user = _objbll.load_User(_objcls, _objdb);
            var list = from o in _user.AsEnumerable()
                       select o;
            foreach (var row in list)
            {
                Send_Email(row[0].ToString(), _sub, Body);
            }
        }
        public void Load_Snag()
        {
            //BLL_Dml _objbll = new BLL_Dml();
            //_database _objdb = new _database();
            //_clsSnag _objcls = new _clsSnag();
            //_objdb.DBName = "DBCML";
            //_objcls.project = "1";
            //_objcls.status = "OPEN";
            //_dtsnag=_objbll.Load_Snag_Master(_objcls, _objdb);
        }
        public string GetIpLocation(string IP)
        {
            //this line is to check the clien ip address from the server itself
            //string IP = Request.ServerVariables["REMOTE_ADDR"];

            //Initializing a new xml document object to begin reading the xml file returned
            XmlDocument doc = new XmlDocument();

            //NOTE: www.showmyip.com only allows 199 request/day 
            //as a free call, for more requests u could register with them
            /////////////////

            //send the request to www.showmyip.com sending the ip as a query string
            //and loads the xml file in the document object
            doc.Load("http://www.showmyip.com/xml/?ip=" + IP);

            //begin finding the country by tag name
            XmlNodeList nodeLstCountry = doc.GetElementsByTagName("lookup_country");

            ////begin finding the city by tag name
            XmlNodeList nodeLstCity = doc.GetElementsByTagName("lookup_city2");

            //concatinating the result for show, u could also use it
            //to save in data base
            string Loc = "Country :" + nodeLstCountry[0].InnerText +
                 " --  City :" + nodeLstCity[0].InnerText + "" + IP;

            return Loc;

        }

        public DataTable GetLocation(string strIPAddress)
        {
            //Create a WebRequest with the current Ip
            WebRequest _objWebRequest = WebRequest.Create("http://freegeoip.appspot.com/xml/" + strIPAddress);
            //Create a Web Proxy
            WebProxy _objWebProxy = new WebProxy("http://freegeoip.appspot.com/xml/" + strIPAddress, true);

            //Assign the proxy to the WebRequest
            _objWebRequest.Proxy = _objWebProxy;

            //Set the timeout in Seconds for the WebRequest
            _objWebRequest.Timeout = 2000;

            try
            {
                //Get the WebResponse 
                WebResponse _objWebResponse = _objWebRequest.GetResponse();
                //Read the Response in a XMLTextReader
                XmlTextReader _objXmlTextReader = new XmlTextReader(_objWebResponse.GetResponseStream());

                //Create a new DataSet
                DataSet _objDataSet = new DataSet();
                //Read the Response into the DataSet
                _objDataSet.ReadXml(_objXmlTextReader);

                return _objDataSet.Tables[0];
                //                    <?xml version="1.0" encoding="UTF-8"?>
                //<Response>
                //    <Status>true</Status>
                //    <Ip>xxx.xxx.xxx.xxx</Ip>
                //    <CountryCode>BD</CountryCode>
                //    <CountryName>Bangladesh</CountryName>
                //    <RegionCode>81</RegionCode>
                //    <RegionName>Dhaka</RegionName>
                //    <City>Dhaka</City>
                //    <ZipCode></ZipCode>
                //    <Latitude>23.723</Latitude>
                //    <Longitude>90.4086</Longitude>
                //</Response>
            }
            catch
            {
                return null;
            }
        } // End of GetLocation

        public bool Load_User_Module_Permission(string project,string uid,int ModuleId) 
        {
            bool permission = false;    
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "DB_" + project;
            _clsdocument _objcls = new _clsdocument();
            _objcls.folder_id = ModuleId;
            _objcls.uid = uid;
            DataTable _dt = _objbll.LOAD_USERMODULE_PERMISSION(_objcls, _objdb);
            if (_dt.Rows.Count > 0) { permission = _dt.Rows[0][0].ToString() == "True" ? true : false; }
            return permission;

        }

    }
}
