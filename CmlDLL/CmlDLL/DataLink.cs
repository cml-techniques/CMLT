using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using App_Properties;

namespace DataLinkLibrary
{
    public class SQL_Connection
    {
        SqlConnection Sqlcon;

        public SqlConnection con_open(string DB)
        {
            _database _objdb = new _database();

            string _query = "server=" + Constants.CMLTConstants.serverName + ";uid=" + Constants.CMLTConstants.dbUserName + ";pwd=" + Constants.CMLTConstants.dbPassword + ";database=" + DB + ";Connection Timeout=360000;Pooling=true;Min Pool Size=0;Max Pool Size=500;";
          

            Sqlcon = new SqlConnection(_query);
            try
            {
                //if (Sqlcon.State == ConnectionState.Open)
                //    Sqlcon.Close();
                Sqlcon.Open();
                return Sqlcon;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return Sqlcon;
        }
        
    }
    public class DLL_Dml
    {
        SqlCommand _cmd;
        SqlDataAdapter _dta;
        SQL_Connection _objcon = new SQL_Connection();
        public void _chngPwd(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@pwd", _obj.pwd);
            _cmd.ExecuteNonQuery();
            return;
        }
        public bool _validUser(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@pwd", _obj.pwd);
            _cmd.Parameters.Add("@validuser", SqlDbType.VarChar, 50);
            _cmd.Parameters["@validuser"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@validuser"].Value.ToString() != "")
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        public string GetAutoPassword(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 15);
            _cmd.Parameters["@pwd"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@pwd"].Value.ToString() != "")
                    return _cmd.Parameters["@pwd"].Value.ToString();
                else
                    return "0";
            }
            catch
            {
                throw;
            }
        }
        public string CheckOMExist(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.Add("@Project", SqlDbType.NVarChar, 6);
            _cmd.Parameters["@Project"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Project"].Value.ToString() != "")
                    return _cmd.Parameters["@Project"].Value.ToString();
                else
                    return "0";
            }
            catch
            {
                throw;
            }
        }
        public string _getUserGroup(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@pwd", _obj.pwd);
            _cmd.Parameters.Add("@usergroup", SqlDbType.VarChar, 50);
            _cmd.Parameters["@usergroup"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@usergroup"].Value.ToString() != "")
                    return _cmd.Parameters["@usergroup"].Value.ToString();
                else
                    return "nothing";
            }
            catch
            {
                throw;
            }
        }
        public string GetUserAccess(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.Add("@usergroup", SqlDbType.VarChar, 50);
            _cmd.Parameters["@usergroup"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            if (_cmd.Parameters["@usergroup"].Value.ToString() != "")
                return _cmd.Parameters["@usergroup"].Value.ToString();
            else
                return "nothing";
        }
        public DataTable load_master(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable load_document(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@Enabled", _obj.enabled);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void addcomment(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sec_no", _obj.sec_no);
            _cmd.Parameters.AddWithValue("@page_no", _obj.page_no);
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@com_date", _obj.com_date);
            _cmd.Parameters.AddWithValue("@user_id", _obj.user_id);
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.ExecuteNonQuery();
        }
        public void Editcomment(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@user_id", _obj.user_id);
            _cmd.Parameters.AddWithValue("@comm_id", _obj.comm_id);
            _cmd.ExecuteNonQuery();
        }
        public void Deletecomment(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@comm_id", _obj.comm_id);
            _cmd.ExecuteNonQuery();
        }
        public void addtobasket(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@page", _obj.page_no);
            _cmd.Parameters.AddWithValue("@sec", _obj.sec_no);
            _cmd.Parameters.AddWithValue("@uid", _obj.user_id);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@module", _obj.module);
            _cmd.Parameters.AddWithValue("@type", _obj.type);
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.ExecuteNonQuery();
        }
        public void ClearBasket(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            //_cmd.Parameters.AddWithValue("@id", _obj.comm_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable load_basket(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable load_comments(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable load_usercomments(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void file_upload(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@service", _obj.service_code);
            _cmd.Parameters.AddWithValue("@package", _obj.package_code);
            _cmd.Parameters.AddWithValue("@doctype", _obj.doctype_code);
            _cmd.Parameters.AddWithValue("@doc_title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@uploaded", _obj.uploaded);
            _cmd.Parameters.AddWithValue("@uploaded_date", _obj.uploaded_date);
            _cmd.Parameters.AddWithValue("@file_size", _obj.file_size);
            _cmd.Parameters.AddWithValue("@schid", _obj.schid);
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@type", _obj.type);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.ExecuteNonQuery();


        }
        public void _projectmaster(string _sp, _clsproject _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@project_code", _obj.prjcode);
            _cmd.Parameters.AddWithValue("@project_name", _obj.prjname);
            _cmd.Parameters.AddWithValue("@company", _obj.company);
            _cmd.Parameters.AddWithValue("@description", _obj.description);
            _cmd.Parameters.AddWithValue("@user", _obj.user);
            _cmd.Parameters.AddWithValue("@dms", _obj.dms);
            _cmd.Parameters.AddWithValue("@cms", _obj.cms);
            _cmd.Parameters.AddWithValue("@ams", _obj.tms);
            _cmd.Parameters.AddWithValue("@sns", _obj.sns);
            _cmd.Parameters.AddWithValue("@tis", _obj.tis);
            _cmd.Parameters.AddWithValue("@location", _obj.loc);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.ExecuteNonQuery();
            return;
        }
        public void Create_Schedule(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@service", _obj.service_code);
            _cmd.Parameters.AddWithValue("@package", _obj.package_code);
            _cmd.Parameters.AddWithValue("@doctype", _obj.doctype_code);
            _cmd.Parameters.AddWithValue("@doc_title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@date_tobeuploaded", _obj.uploaded_date);
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.ExecuteNonQuery();
        }
        public void Create_user(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@password", _obj.pwd);
            _cmd.Parameters.AddWithValue("@username", _obj.uname);
            _cmd.Parameters.AddWithValue("@user_group", _obj.user_group);
            _cmd.Parameters.AddWithValue("@CMS", _obj.CMS);
            _cmd.Parameters.AddWithValue("@DMS", _obj.DMS);
            _cmd.Parameters.AddWithValue("@TMS", _obj.TMS);
            _cmd.Parameters.AddWithValue("@CU", _obj.CU);
            _cmd.Parameters.AddWithValue("@CP", _obj.CP);
            _cmd.Parameters.AddWithValue("@PM", _obj.PM);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.Parameters.AddWithValue("@company", _obj.company);
            _cmd.ExecuteNonQuery();
        }

        //-----------------------Created on 13/03/2011--------------------------//
        public void Manage_Tree(string _sp, _clsManageTree _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@description", _obj.desciption);
            _cmd.Parameters.AddWithValue("@service", _obj.service);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.ExecuteNonQuery();
        }
        public void Edit_Tree(string _sp, _clsManageTree _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@description", _obj.desciption);
            _cmd.Parameters.AddWithValue("@service", _obj.service);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.Parameters.AddWithValue("@code", _obj.code);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        //--------------------Created on 15/03/2011-----------------//
        public void Tree_Folder(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_description", _obj.Folder_description);
            _cmd.Parameters.AddWithValue("@Folder_type", _obj.Folder_type);
            _cmd.Parameters.AddWithValue("@Folder_possition", _obj.Folder_possition);
            _cmd.Parameters.AddWithValue("@Parent_folder", _obj.Parent_folder);
            _cmd.Parameters.AddWithValue("@Project_code", _obj.Project_code);
            _cmd.Parameters.AddWithValue("@Enabled", _obj.Enabled);
            _cmd.Parameters.AddWithValue("@auto", _obj.auto);
            _cmd.ExecuteNonQuery();
        }
        public void Edit_Tree_Folder(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.AddWithValue("@Folder_description", _obj.Folder_description);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public void Move_Tree_Folder(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.AddWithValue("@Folder_possition", _obj.Folder_possition);
            _cmd.ExecuteNonQuery();
        }
        public void Create_Manufacture(string _sp, _clsmanufacture _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Manufacture_name", _obj.man_name);
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.ExecuteNonQuery();
        }
        public void Create_Contractor(string _sp, _clsmanufacture _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@con_name", _obj.man_name);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _cmd.ExecuteNonQuery();
        }
        public DataTable load_master(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_PrjDocType(string _sp, _clsFolderTree _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.Project_code);
            _cmd.Parameters.AddWithValue("@Parent", _obj.Parent_folder);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }

        public DataTable load_service(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Move_document(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.Parameters.AddWithValue("@move", _obj.move);
            _cmd.ExecuteNonQuery();
        }
        public DataTable load_projecthome(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void SetDocDuration(string _sp, _clsdocduration _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.AddWithValue("@Duration", _obj.Duration);
            _cmd.Parameters.AddWithValue("@First", _obj.First);
            _cmd.Parameters.AddWithValue("@Second", _obj.Second);
            _cmd.Parameters.AddWithValue("@Third", _obj.Third);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.ExecuteNonQuery();
        }
        public DataTable LoadDocDatails(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_DocDatails(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DOC_ID", _obj.doc_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void SetDocStatus(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.ExecuteNonQuery();
        }
        public void SetAutoComplete(string _sp, _clsuser _obj, _database _objdb)
        {
            //_cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            //_cmd.CommandType = CommandType.StoredProcedure;
            //_cmd.Parameters.AddWithValue("@uid", _obj.uid);
            //_cmd.Parameters.AddWithValue("@autocomplete", _obj.autocomplete);
            //_cmd.ExecuteNonQuery();
        }
        public void Insert_UserPrj(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _cmd.ExecuteNonQuery();
        }
        public void Insert_UserService(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@service", _obj.service);
            _cmd.Parameters.AddWithValue("@project_code", _obj.project_code);
            _cmd.ExecuteNonQuery();
        }
        public DataTable load_usersrv(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@project_code", _obj.project_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Edit_Access(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@access_level", _obj.access);
            _cmd.ExecuteNonQuery();
        }
        public void Delete_Doc(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_Reports(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@package", _obj.package_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Set_Reminder(string _sp, _clsdocduration _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_id", _obj.Folder_id);
            _cmd.Parameters.AddWithValue("@remind", _obj.Remind);
            _cmd.ExecuteNonQuery();
        }
        public int Get_ManualID(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.folder_id);
            _cmd.Parameters.Add("@doc_id", SqlDbType.Int);
            _cmd.Parameters["@doc_id"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@doc_id"].Value.ToString() != "")
                    return System.Convert.ToInt32(_cmd.Parameters["@doc_id"].Value.ToString());
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public int ValidateDocumentRevision(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.Add("@exists", SqlDbType.Int);
            _cmd.Parameters["@exists"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@exists"].Value.ToString() != "")
                    return System.Convert.ToInt32(_cmd.Parameters["@exists"].Value.ToString());
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void add_resp(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@comm_id", _obj.comm_id);
            _cmd.Parameters.AddWithValue("@resp", _obj.resp);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_cas_sys(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public string LoadCASHeader(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            _cmd.Parameters.Add("@cas_name", SqlDbType.VarChar, 200);
            _cmd.Parameters["@cas_name"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                    return _cmd.Parameters["@cas_name"].Value.ToString();
            }
            catch
            {
                throw;
            }
        }
        public void add_cas_main(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _cmd.Parameters.AddWithValue("@reff_", _obj.reff);
            _cmd.Parameters.AddWithValue("@desc_", _obj.desc);
            _cmd.Parameters.AddWithValue("@loca_", _obj.loca);
            _cmd.Parameters.AddWithValue("@p_power_to", _obj.p_power_to);
            _cmd.Parameters.AddWithValue("@fed_from", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@power_on", _obj.power_on);
            _cmd.Parameters.AddWithValue("@comm_", _obj.comm);
            _cmd.Parameters.AddWithValue("@act_by", _obj.act_by);
            _cmd.Parameters.AddWithValue("@act_date", _obj.act_date);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@date_", _obj.date);
            _cmd.Parameters.AddWithValue("@srv_id", _obj.srv);
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@con_acce", _obj.con_acce);
            _cmd.Parameters.AddWithValue("@filed", _obj.ts_filed);
            _cmd.Parameters.AddWithValue("@des_vol", _obj.des_vol);
            _cmd.Parameters.AddWithValue("@des_flow_rate", _obj.des_flow_rate);
            _cmd.Parameters.AddWithValue("@devices", _obj.dev);
            _cmd.Parameters.AddWithValue("@sys_monitored", _obj.sys_mon);
            _cmd.Parameters.AddWithValue("@fa_interfaces", _obj.fa_int);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.ExecuteNonQuery();
        }
        public void add_asset_code(string _sp, _clsassetcode _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cate_", _obj.cate);
            _cmd.Parameters.AddWithValue("@b_zone", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@f_level", _obj.f_level);
            _cmd.Parameters.AddWithValue("@seq_no", _obj.seq_no);
            _cmd.ExecuteNonQuery();
        }
        public void Edit_asset_code(string _sp, _clsassetcode _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@cate_", _obj.cate);
            _cmd.Parameters.AddWithValue("@b_zone", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@f_level", _obj.f_level);
            _cmd.Parameters.AddWithValue("@seq_no", _obj.seq_no);
            _cmd.ExecuteNonQuery();
        }
        public void add_ele_out_cir_test(string _sp, _cls_ele_testing _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@ttl_cold_tested", _obj.ttl_cold_tested);
            _cmd.Parameters.AddWithValue("@cold_complete", _obj.cold_complete);
            _cmd.Parameters.AddWithValue("@ttl_live_tested", _obj.ttl_live_tested);
            _cmd.Parameters.AddWithValue("@live_complete", _obj.live_complete);
            _cmd.ExecuteNonQuery();
        }
        public void add_ele_pnl_eqi_test(string _sp, _cls_ele_testing _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@torque_", _obj.torque);
            _cmd.Parameters.AddWithValue("@ir_", _obj.ir);
            _cmd.Parameters.AddWithValue("@pressure_", _obj.pressure);
            _cmd.Parameters.AddWithValue("@sec_injection_", _obj.sec_injection);
            _cmd.Parameters.AddWithValue("@con_resistance", _obj.con_resistance);
            _cmd.Parameters.AddWithValue("@functional_", _obj.functional);
            _cmd.Parameters.AddWithValue("@completed_", _obj.completed);
            _cmd.ExecuteNonQuery();
        }
        public void Insert_Cas_Testing(string _sp, _cls_ele_testing _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@torque_", _obj.torque);
            _cmd.Parameters.AddWithValue("@ir_", _obj.ir);
            _cmd.Parameters.AddWithValue("@pressure_", _obj.pressure);
            _cmd.Parameters.AddWithValue("@sec_injection_", _obj.sec_injection);
            _cmd.Parameters.AddWithValue("@con_resistance", _obj.con_resistance);
            _cmd.Parameters.AddWithValue("@functional_", _obj.functional);
            _cmd.Parameters.AddWithValue("@completed_", _obj.completed);
            _cmd.Parameters.AddWithValue("@ttl_cold_tested", _obj.ttl_cold_tested);
            _cmd.Parameters.AddWithValue("@cold_complete", _obj.cold_complete);
            _cmd.Parameters.AddWithValue("@ttl_live_tested", _obj.ttl_live_tested);
            _cmd.Parameters.AddWithValue("@live_complete", _obj.live_complete);
            _cmd.Parameters.AddWithValue("@pre_com_test", _obj.pre_com);
            _cmd.Parameters.AddWithValue("@c_f_test", _obj.c_f);
            _cmd.Parameters.AddWithValue("@load_test", _obj.load);
            _cmd.Parameters.AddWithValue("@full_run_test", _obj.full_run);
            _cmd.Parameters.AddWithValue("@wir_test", _obj.wir_test);
            _cmd.Parameters.AddWithValue("@ratio_test", _obj.ratio_test);
            _cmd.Parameters.AddWithValue("@wr_test", _obj.wr_test);
            _cmd.Parameters.AddWithValue("@vg_test", _obj.vg_test);
            _cmd.Parameters.AddWithValue("@hv_test", _obj.hv_test);
            _cmd.Parameters.AddWithValue("@lv_ir_test_gen", _obj.lv_ir_test_gen);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_casMain(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_casMain_Edit(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_CasSub(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void LOG(string _sp, _clslog _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@_uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@_ipaddress", _obj.ipaddr);
            _cmd.Parameters.AddWithValue("@_location", _obj.location);
            _cmd.Parameters.AddWithValue("@_login", _obj.login);
            _cmd.ExecuteNonQuery();
        }
        public void UpdateUserLog(string _sp, _clslog _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@_uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@_ipaddress", _obj.ipaddr);
            _cmd.Parameters.AddWithValue("@_country", _obj.Country);
            _cmd.Parameters.AddWithValue("@_region", _obj.Region);
            _cmd.Parameters.AddWithValue("@_location", _obj.location);
            _cmd.Parameters.AddWithValue("@_module", _obj.module);
            _cmd.Parameters.AddWithValue("@_login", _obj.login);
            _cmd.ExecuteNonQuery();
        }
        public void LOG_OUT(string _sp, _clslog _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@_uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@_logout", _obj.logout);
            _cmd.ExecuteNonQuery();
        }
        public void Add_CMS_Document(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@file_name", _obj.file_name);
            _cmd.Parameters.AddWithValue("@module_name", _obj.module_name);
            _cmd.Parameters.AddWithValue("@upload_date", _obj.upload_date);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder);
            _cmd.Parameters.AddWithValue("@module_id", _obj.module);
            _cmd.Parameters.AddWithValue("@reff_no", _obj.reff_no);
            _cmd.Parameters.AddWithValue("@srv_id", _obj.srv_id);
            _cmd.Parameters.AddWithValue("@Type", _obj.Type);
            _cmd.Parameters.AddWithValue("@Comment_by", _obj.Comment_By);
            _cmd.Parameters.AddWithValue("@doc_status", _obj.doc_status);
            _cmd.ExecuteNonQuery();
        }
        public void Add_CMS_Document1(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@file_name", _obj.file_name);
            _cmd.Parameters.AddWithValue("@module_name", _obj.module_name);
            _cmd.Parameters.AddWithValue("@upload_date", _obj.upload_date);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder);
            _cmd.Parameters.AddWithValue("@module_id", _obj.module);
            _cmd.Parameters.AddWithValue("@reff_no", _obj.reff_no);
            _cmd.Parameters.AddWithValue("@srv_id", _obj.srv_id);
            _cmd.Parameters.AddWithValue("@Type", _obj.Type);
            _cmd.Parameters.AddWithValue("@Comment_by", _obj.Comment_By);
            _cmd.Parameters.AddWithValue("@doc_status", _obj.doc_status);
            _cmd.Parameters.AddWithValue("@company", _obj.company);
            _cmd.ExecuteNonQuery();
        }
        public void Add_CMS_Comments(string _sp, _clscmscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project);
            _cmd.Parameters.AddWithValue("@module_name", _obj.module);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@comment_date", _obj.com_date);
            _cmd.Parameters.AddWithValue("@sec", _obj.sec);
            _cmd.Parameters.AddWithValue("@page", _obj.page);
            _cmd.ExecuteNonQuery();
        }
        public string ChkUserLoggedIN(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.Add("@ip", SqlDbType.VarChar, 50);
            _cmd.Parameters["@ip"].Direction = ParameterDirection.Output;
            _cmd.Parameters.Add("@login", SqlDbType.VarChar, 50);
            _cmd.Parameters["@login"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@ip"].Value.ToString() != "")
                    return _cmd.Parameters["@ip"].Value.ToString() + "_L" + _cmd.Parameters["@login"].Value.ToString();
                else
                    return "NotExist";
            }
            catch
            {
                throw;
            }
        }
        public DataTable Load_CMS_Docs(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@reff_no", _obj.reff_no);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public string Document_Review_Log(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _cmd.Parameters.AddWithValue("@dr_reviewed", _obj.dr_reviewed);
            _cmd.Parameters.AddWithValue("@issued_date", _obj.issued_date);
            _cmd.Parameters.AddWithValue("@issued_to", _obj.issued_to);
            _cmd.Parameters.AddWithValue("@dr_status", _obj.dr_status);
            _cmd.Parameters.AddWithValue("@project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.Parameters.AddWithValue("@service", _obj.service);
            _cmd.Parameters.AddWithValue("@building", _obj.building);
            _cmd.Parameters.AddWithValue("@Notes", _obj.Notes);
            _cmd.Parameters.AddWithValue("@Closeout_Date", _obj.closeout_date);
            _cmd.Parameters.Add("@dr_no", SqlDbType.VarChar, 15);
            _cmd.Parameters["@dr_no"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@dr_no"].Value.ToString();
        }
        public void Document_Review_Details(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_itm_id", _obj.dr_itm_id);
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _cmd.Parameters.AddWithValue("@details", _obj.details);
            _cmd.Parameters.AddWithValue("@response", _obj.response);
            _cmd.Parameters.AddWithValue("@desc", _obj.desc);
            _cmd.Parameters.AddWithValue("@date", _obj.issued_date);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_Document_Review_Details(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Remove_basket(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@id", _obj.comm_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_FolderTree_Cms(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_type", _obj.Folder_type);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public string SO_Dir(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_id", _obj.so_id);
            _cmd.Parameters.AddWithValue("@so_date", _obj.so_date);
            _cmd.Parameters.AddWithValue("@package", _obj.package);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@issued_date", _obj.issued_date);
            _cmd.Parameters.AddWithValue("@issued_to", _obj.issued_to);
            _cmd.Parameters.AddWithValue("@remarks", _obj.remarks);
            _cmd.Parameters.AddWithValue("@project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@closeoutdate", _obj.cdate);
            _cmd.Parameters.AddWithValue("@Building", _obj.so_building);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.Parameters.Add("@sono", SqlDbType.VarChar, 10);
            _cmd.Parameters["@sono"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@sono"].Value.ToString();

        }
        public void SO_Details(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_itm_id", _obj.so_itm_id);
            _cmd.Parameters.AddWithValue("@so_id", _obj.so_id);
            _cmd.Parameters.AddWithValue("@details", _obj.details);
            _cmd.Parameters.AddWithValue("@response", _obj.response);
            _cmd.Parameters.AddWithValue("@date", _obj.so_date);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public void SO_Photo(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@photo", _obj.photo);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_SO_Details(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_id", _obj.so_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable load_comment_basket(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.user_id);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@module", _obj.module);
            _cmd.Parameters.AddWithValue("@type", _obj.type);
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Cassheet_Master(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@c_s_id", _obj.c_s_id);
            _cmd.Parameters.AddWithValue("@p_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _cmd.Parameters.AddWithValue("@e_b_ref", _obj.reff);
            _cmd.Parameters.AddWithValue("@b_z", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@cat", _obj.cate);
            _cmd.Parameters.AddWithValue("@f_lvl", _obj.f_level);
            _cmd.Parameters.AddWithValue("@sq_no", _obj.seq_no);
            _cmd.Parameters.AddWithValue("@des", _obj.desc);
            _cmd.Parameters.AddWithValue("@loc", _obj.loca);
            _cmd.Parameters.AddWithValue("@p_p_to", _obj.p_power_to);
            _cmd.Parameters.AddWithValue("@f_from", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@sub_st", _obj.sub_st);
            _cmd.Parameters.AddWithValue("@s_c_m", _obj.s_c_m);
            _cmd.Parameters.AddWithValue("@dev1", _obj.dev1);
            _cmd.Parameters.AddWithValue("@dev2", _obj.dev2);
            _cmd.Parameters.AddWithValue("@dev3", _obj.dev3);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@Position", _obj.Position);
            _cmd.Parameters.AddWithValue("@Panel_id", _obj.panel_id);
            _cmd.ExecuteNonQuery();
        }
        public void Cassheet_update(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@pwron", _obj.power_on);
            _cmd.Parameters.AddWithValue("@comm", _obj.comm);
            _cmd.Parameters.AddWithValue("@actby", _obj.act_by);
            _cmd.Parameters.AddWithValue("@actdate", _obj.act_date);
            _cmd.Parameters.AddWithValue("@tested1", _obj.tested1);
            _cmd.Parameters.AddWithValue("@tested2", _obj.tested2);
            _cmd.Parameters.AddWithValue("@test1", _obj.test1);
            _cmd.Parameters.AddWithValue("@test2", _obj.test2);
            _cmd.Parameters.AddWithValue("@test3", _obj.test3);
            _cmd.Parameters.AddWithValue("@test4", _obj.test4);
            _cmd.Parameters.AddWithValue("@test5", _obj.test5);
            _cmd.Parameters.AddWithValue("@test6", _obj.test6);
            _cmd.Parameters.AddWithValue("@test7", _obj.test7);
            _cmd.Parameters.AddWithValue("@test8", _obj.test8);
            _cmd.Parameters.AddWithValue("@test9", _obj.test9);
            _cmd.Parameters.AddWithValue("@test10", _obj.test10);
            _cmd.Parameters.AddWithValue("@test11", _obj.test11);
            _cmd.Parameters.AddWithValue("@test12", _obj.test12);
            _cmd.Parameters.AddWithValue("@test13", _obj.test13);
            _cmd.Parameters.AddWithValue("@test14", _obj.test14);
            _cmd.Parameters.AddWithValue("@test15", _obj.test15);
            _cmd.Parameters.AddWithValue("@complete", _obj.compl);
            _cmd.Parameters.AddWithValue("@per_com1", _obj.per_com1);
            _cmd.Parameters.AddWithValue("@per_com2", _obj.per_com2);
            _cmd.Parameters.AddWithValue("@per_com3", _obj.per_com3);
            _cmd.Parameters.AddWithValue("@per_com4", _obj.per_com4);
            _cmd.Parameters.AddWithValue("@dev1", _obj.dev1);
            _cmd.Parameters.AddWithValue("@accept1", _obj.accept1);
            _cmd.Parameters.AddWithValue("@accept2", _obj.accept2);
            _cmd.Parameters.AddWithValue("@filed1", _obj.filed1);
            _cmd.Parameters.AddWithValue("@filed2", _obj.filed2);
            _cmd.Parameters.AddWithValue("@per_com5", _obj.per_com5);
            _cmd.Parameters.AddWithValue("@per_com6", _obj.per_com6);
            _cmd.Parameters.AddWithValue("@per_com7", _obj.per_com7);
            _cmd.Parameters.AddWithValue("@per_com8", _obj.per_com8);
            _cmd.Parameters.AddWithValue("@per_com9", _obj.per_com9);
            _cmd.Parameters.AddWithValue("@per_com10", _obj.per_com10);
            _cmd.ExecuteNonQuery();
        }
        public void Cassheet_update1(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@pwron", _obj.power_on);
            _cmd.Parameters.AddWithValue("@comm", _obj.comm);
            _cmd.Parameters.AddWithValue("@actby", _obj.act_by);
            _cmd.Parameters.AddWithValue("@actdate", _obj.act_date);
            _cmd.Parameters.AddWithValue("@tested1", _obj.tested1);
            _cmd.Parameters.AddWithValue("@tested2", _obj.tested2);
            _cmd.Parameters.AddWithValue("@test1", _obj.test1);
            _cmd.Parameters.AddWithValue("@test2", _obj.test2);
            _cmd.Parameters.AddWithValue("@test3", _obj.test3);
            _cmd.Parameters.AddWithValue("@test4", _obj.test4);
            _cmd.Parameters.AddWithValue("@test5", _obj.test5);
            _cmd.Parameters.AddWithValue("@test6", _obj.test6);
            _cmd.Parameters.AddWithValue("@test7", _obj.test7);
            _cmd.Parameters.AddWithValue("@test8", _obj.test8);
            _cmd.Parameters.AddWithValue("@test9", _obj.test9);
            _cmd.Parameters.AddWithValue("@test10", _obj.test10);
            _cmd.Parameters.AddWithValue("@test11", _obj.test11);
            _cmd.Parameters.AddWithValue("@test12", _obj.test12);
            _cmd.Parameters.AddWithValue("@test13", _obj.test13);
            _cmd.Parameters.AddWithValue("@test14", _obj.test14);
            _cmd.Parameters.AddWithValue("@test15", _obj.test15);
            _cmd.Parameters.AddWithValue("@complete", _obj.compl);
            _cmd.Parameters.AddWithValue("@per_com1", _obj.per_com1);
            _cmd.Parameters.AddWithValue("@per_com2", _obj.per_com2);
            _cmd.Parameters.AddWithValue("@per_com3", _obj.per_com3);
            _cmd.Parameters.AddWithValue("@per_com4", _obj.per_com4);
            _cmd.Parameters.AddWithValue("@dev1", _obj.dev1);
            _cmd.Parameters.AddWithValue("@accept1", _obj.accept1);
            _cmd.Parameters.AddWithValue("@accept2", _obj.accept2);
            _cmd.Parameters.AddWithValue("@filed1", _obj.filed1);
            _cmd.Parameters.AddWithValue("@filed2", _obj.filed2);
            _cmd.Parameters.AddWithValue("@per_com5", _obj.per_com5);
            _cmd.Parameters.AddWithValue("@per_com6", _obj.per_com6);
            _cmd.Parameters.AddWithValue("@per_com7", _obj.per_com7);
            _cmd.Parameters.AddWithValue("@per_com8", _obj.per_com8);
            _cmd.Parameters.AddWithValue("@per_com9", _obj.per_com9);
            _cmd.Parameters.AddWithValue("@per_com10", _obj.per_com10);
            _cmd.Parameters.AddWithValue("@planned1", _obj.planned1);
            _cmd.Parameters.AddWithValue("@planned2", _obj.planned2);
            _cmd.Parameters.AddWithValue("@planned3", _obj.planned3);
            _cmd.Parameters.AddWithValue("@planned4", _obj.planned4);
            _cmd.Parameters.AddWithValue("@planned5", _obj.planned5);
            _cmd.Parameters.AddWithValue("@planned6", _obj.planned6);
            _cmd.Parameters.AddWithValue("@planned7", _obj.planned7);
            _cmd.Parameters.AddWithValue("@planned8", _obj.planned8);
            _cmd.ExecuteNonQuery();
        }
        public DataSet Load_casMain_Graph(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _dta = new SqlDataAdapter(_cmd);
            DataSet _dtable = new DataSet();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable load_comments(string _sp, _clscmscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@id", _obj.doc_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Set_User_Permission(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@access", _obj.access);
            _cmd.Parameters.AddWithValue("@permission", _obj.permission);
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.AddWithValue("@email_", _obj.notification);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_Details(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public bool Module_Access(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@module", _obj.mode);
            _cmd.Parameters.Add("@access", SqlDbType.Bit);
            _cmd.Parameters["@access"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@access"].Value.ToString() == "True")
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        public void RESTORE_DB(string _sp, _database _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DBName", _obj.DBName);
            _cmd.Parameters.AddWithValue("@BackName", _obj.Bakname);
            _cmd.Parameters.AddWithValue("@DataName", _obj.Dataname);
            _cmd.Parameters.AddWithValue("@DataFileName", _obj.Datapath);
            _cmd.Parameters.AddWithValue("@LogName", _obj.Logname);
            _cmd.Parameters.AddWithValue("@LogFileName", _obj.Logpath);
            _cmd.ExecuteNonQuery();
        }
        public void create_package(string _sp, _clspackage _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@package", _obj.package);
            _cmd.Parameters.AddWithValue("@category", _obj.category);
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch_id);
            _cmd.Parameters.AddWithValue("@project", _obj.project);
            _cmd.Parameters.AddWithValue("@recordsheet", _obj.record_sheet);
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys_id);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public void Config_CMSFolderTree(string _sp, _clsFolderTree _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_description", _obj.Folder_description);
            _cmd.Parameters.AddWithValue("@folder_type", _obj.Folder_type);
            _cmd.Parameters.AddWithValue("@folder_possition", _obj.Folder_possition);
            _cmd.Parameters.AddWithValue("@parent_folder", _obj.Parent_folder);
            _cmd.Parameters.AddWithValue("@project_code", _obj.Project_code);
            _cmd.Parameters.AddWithValue("@enabled", _obj.Enabled);
            _cmd.Parameters.AddWithValue("@type", _obj.type);
            _cmd.Parameters.AddWithValue("@master_id", _obj.master_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_filter_element(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@filter", _obj.filter);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Filtering(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@filter", _obj.filter);
            _cmd.Parameters.AddWithValue("@element", _obj.element);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_SubFolder(string _sp, _clsFolderTree _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@parent", _obj.Parent_folder);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_Ms_Systems(string _sp, _clsMaster _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@ser_id", _obj.ser_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Config_Ms_Schedule(string _sp, _clsMaster _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@ser_id", _obj.ser_id);
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys_id);
            _cmd.Parameters.AddWithValue("@enabled", _obj.enabled);
            _cmd.ExecuteNonQuery();
        }
        public void Config_Prj_Service(string _sp, _sysconfig _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PRJ_SER_NAME", _obj.ser_name);
            _cmd.Parameters.AddWithValue("@ENABLED", _obj.enabled);
            _cmd.Parameters.AddWithValue("@SYS_SER_ID", _obj.ser_id);
            _cmd.ExecuteNonQuery();
        }
        public void Config_Prj_Cassheet(string _sp, _sysconfig _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PRJ_CAS_NAME", _obj.cas_name);
            _cmd.Parameters.AddWithValue("@ENABLED", _obj.enabled);
            _cmd.Parameters.AddWithValue("@SYS_SER_ID", _obj.ser_id);
            _cmd.Parameters.AddWithValue("@SYS_CAS_ID", _obj.cas_id);
            _cmd.ExecuteNonQuery();
        }
        public void Config_Prj_MsSystem(string _sp, _sysconfig _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PRJ_MSSYS_REFF", _obj.sys_reff);
            _cmd.Parameters.AddWithValue("@PRJ_MSSYS_NAME", _obj.sys_name);
            _cmd.Parameters.AddWithValue("@ENABLED", _obj.enabled);
            _cmd.Parameters.AddWithValue("@SYS_SER_ID", _obj.ser_id);
            _cmd.Parameters.AddWithValue("@SYS_MSSYS_ID", _obj.sys_id);
            _cmd.ExecuteNonQuery();
        }
        public void Upload_TestSheet(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@c_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@upload_date", _obj.ts_filed);
            _cmd.Parameters.AddWithValue("@testsheet", _obj.testsheet);
            _cmd.ExecuteNonQuery();
        }
        public void Add_CRS_Master(string _sp, _clsCRS _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@pkg_id", _obj.pkg_cate_id);
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys_id);
            _cmd.Parameters.AddWithValue("@eng_reff", _obj.eng_reff);
            _cmd.Parameters.AddWithValue("@asset_code", _obj.asset_code);
            _cmd.Parameters.AddWithValue("@rs_id", _obj.rs_id);
            _cmd.Parameters.AddWithValue("@tested_by", _obj.tested_by);
            _cmd.Parameters.AddWithValue("@instrument_used", _obj.instru_used);
            _cmd.Parameters.AddWithValue("@date_commenced", _obj.date_comm);
            _cmd.Parameters.AddWithValue("@date_completed", _obj.date_comp);
            _cmd.Parameters.AddWithValue("@witnessed_by", _obj.witnsd_by);
            _cmd.Parameters.AddWithValue("@date_witnessed", _obj.date_witnsd);
            _cmd.ExecuteNonQuery();
        }
        public void Add_AirBalancing(string _sp, _clsCRS _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@crs_id", _obj.crs_id);
            _cmd.Parameters.AddWithValue("@ter_reff", _obj.ter_reff);
            _cmd.Parameters.AddWithValue("@factor", _obj.factor);
            _cmd.Parameters.AddWithValue("@design1", _obj.design1);
            _cmd.Parameters.AddWithValue("@design2", _obj.design2);
            _cmd.Parameters.AddWithValue("@initial1", _obj.initial1);
            _cmd.Parameters.AddWithValue("@initial2", _obj.initial2);
            _cmd.Parameters.AddWithValue("@final1", _obj.final1);
            _cmd.Parameters.AddWithValue("@final2", _obj.final2);
            _cmd.Parameters.AddWithValue("@check1", _obj.check1);
            _cmd.Parameters.AddWithValue("@check2", _obj.check2);
            _cmd.Parameters.AddWithValue("@hood", _obj.hood);
            _cmd.Parameters.AddWithValue("@comments", _obj.comments);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Get_casinfo(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void CREATE_SYSCASPKG(string _sp, _clspackage _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@pkg_name", _obj.package);
            _cmd.Parameters.AddWithValue("@pkg_code", _obj.category);
            _cmd.Parameters.AddWithValue("@cas_id", _obj.sch_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_SnagMaster(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }

        public void Add_Snag_Basket(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _cmd.Parameters.AddWithValue("@area", _obj.area);
            _cmd.Parameters.AddWithValue("@details", _obj.description);
            _cmd.Parameters.AddWithValue("@room", _obj.room);
            _cmd.ExecuteNonQuery();
        }
        public void Add_Snag_Img(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _cmd.Parameters.AddWithValue("@img", _obj.img);
            _cmd.ExecuteNonQuery();
        }
        public void Remove_Snag_Basket(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@id", _obj.snag_id);
            _cmd.ExecuteNonQuery();
        }
        public void Submit_Snag_Details(string _sp, _clsSnag _obj, _database _objdb)
        {
            //_cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            //_cmd.CommandType = CommandType.StoredProcedure;
            //_cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            //_cmd.ExecuteNonQuery();
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Snag_id", _obj.snag_id);
            _cmd.Parameters.AddWithValue("@Area", _obj.area);
            _cmd.Parameters.AddWithValue("@Room", _obj.room);
            _cmd.Parameters.AddWithValue("@Details", _obj.description);
            _cmd.ExecuteNonQuery();

        }
        public int Create_Snag(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            //Old Proce.
            //_cmd.Parameters.AddWithValue("@ref_no", _obj.ref_no);
            //_cmd.Parameters.AddWithValue("@description", _obj.description);
            //_cmd.Parameters.AddWithValue("@service", _obj.service);
            //_cmd.Parameters.AddWithValue("@created_by", _obj.created_by);
            //_cmd.Parameters.AddWithValue("@date_created", _obj.date_created);
            //_cmd.Parameters.AddWithValue("@project", _obj.project);
            //New Proce. 09/10/2011
            //changes 18/10/2011
            _cmd.Parameters.AddWithValue("@Pkg_id", _obj.pkg_id);
            _cmd.Parameters.AddWithValue("@Subject", _obj.description);
            _cmd.Parameters.AddWithValue("@Created", _obj.created_by);
            _cmd.Parameters.AddWithValue("@Created_date", _obj.date_created);
            _cmd.Parameters.AddWithValue("@project", _obj.project);
            _cmd.Parameters.AddWithValue("@Area", _obj.area);
            _cmd.Parameters.AddWithValue("@Room", _obj.room);
            _cmd.Parameters.AddWithValue("@Details", _obj.description);
            _cmd.Parameters.AddWithValue("@Floor", _obj.Floor);
            _cmd.Parameters.Add("@Snag_id", SqlDbType.Int);
            _cmd.Parameters["@Snag_id"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            if (_cmd.Parameters["@Snag_id"].Value.ToString() != "")
                return (int)_cmd.Parameters["@Snag_id"].Value;
            else
                return 0;

        }
        public DataTable Load_Snag_Basket(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _cmd.Parameters.AddWithValue("@type", _obj.type);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_SnagSub(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_SnagDetails_Stage1(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.userid);
            _cmd.Parameters.AddWithValue("@pkg", _obj.package);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Snag_Issue(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _cmd.Parameters.AddWithValue("@issued_date", _obj.date_issued);
            _cmd.ExecuteNonQuery();
        }
        public void Update_SnagResponse(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _cmd.Parameters.AddWithValue("@response", _obj.response);
            _cmd.ExecuteNonQuery();
        }
        public void Update_SnagStatus(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.ExecuteNonQuery();
        }
        public void Update_SnagStage(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _cmd.ExecuteNonQuery();
        }
        public void Create_Company(string _sp, _clsproject _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Com_id", _obj.com_id);
            _cmd.Parameters.AddWithValue("@Com_Code", _obj.comcd);
            _cmd.Parameters.AddWithValue("@Com_Name", _obj.company);
            _cmd.Parameters.AddWithValue("@Status", _obj.status);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void Create_Prj_Company(string _sp, _clsproject _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Prj_code", _obj.prjcode);
            _cmd.Parameters.AddWithValue("@Com_id", _obj.com_id);
            _cmd.ExecuteNonQuery();
        }

        public void Inser_Snag_Pkg_Sub(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@pkg_id", _obj.pkg_id);
            _cmd.Parameters.AddWithValue("@com_id", _obj.com_id);
            _cmd.ExecuteNonQuery();
        }
        public int Insert_Snag_Pkg(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@pkg_name", _obj.pkg_name);
            _cmd.Parameters.AddWithValue("@com_id", _obj.com_id);
            _cmd.Parameters.AddWithValue("@project", _obj.project);
            _cmd.Parameters.Add("@pkg_id", SqlDbType.Int);
            _cmd.Parameters["@pkg_id"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@pkg_id"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@pkg_id"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void Update_Doc_Control(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Prj_com_id", _obj.pkg_id);
            _cmd.Parameters.AddWithValue("@userid", _obj.userid);
            _cmd.ExecuteNonQuery();
        }
        public string Get_PkgCom_User(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Pkg_id", _obj.pkg_id);
            _cmd.Parameters.Add("@user", SqlDbType.VarChar, 50);
            _cmd.Parameters["@user"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@user"].Value.ToString() != "")
                    return (string)_cmd.Parameters["@user"].Value;
                else
                    return "0";
            }
            catch
            {
                throw;
            }
        }
        public DataTable Load_PkgCom_SubUser(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Pkg_id", _obj.snag_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }

        public DataSet load_dataset(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _dta = new SqlDataAdapter(_cmd);
            DataSet _dtable = new DataSet();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Add_Photo_rpt(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@img", _obj.photo_rpt);
            _cmd.Parameters.AddWithValue("@snag_id", _obj.snag_id);
            _cmd.ExecuteNonQuery();
        }
        public void Populate_SnagRpt(string _sp, _clsSnag _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_DRReport(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.AddWithValue("@drid", _obj.dr_id);
            _cmd.ExecuteNonQuery();
        }
        public void Add_SO_Details_Basket(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_no", _obj.so_no);
            _cmd.Parameters.AddWithValue("@details", _obj.details);
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.AddWithValue("@package", _obj.package);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@Building", _obj.so_building);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public void Remove_SO_Details_Basket(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_id", _obj.so_id);
            _cmd.ExecuteNonQuery();
        }
        public void Remove_DR_Details_Basket(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_SO_Basket(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.AddWithValue("@package", _obj.package);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_SO_Details(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_id", _obj.so_id);
            _cmd.Parameters.AddWithValue("@so_no", _obj.so_no);
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.AddWithValue("@date", _obj.so_date);
            _cmd.Parameters.AddWithValue("@package", _obj.package);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public void Update_SO_Resp(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_itm_id", _obj.so_itm_id);
            _cmd.Parameters.AddWithValue("@response", _obj.response);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_SOReport(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.AddWithValue("@soid", _obj.so_id);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_SOIMG(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@itm_id", _obj.so_itm_id);
            _cmd.Parameters.AddWithValue("@photo", _obj.logo);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_PRG_RPT(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DBNAME", _objdb.Dataname);
            _cmd.Parameters.AddWithValue("@PROJECT", _objdb.project);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_DR_SO_RPT(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@RPT", _objdb.rpt);
            _cmd.Parameters.AddWithValue("@SRV", _objdb.Logname);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_CAS_RPT(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DBNAME", _objdb.Dataname);
            _cmd.Parameters.AddWithValue("@PROJECT", _objdb.project);
            _cmd.Parameters.AddWithValue("@PROJECT_CODE", _objdb.Datapath);
            _cmd.Parameters.AddWithValue("@CAS_ID", _objdb.rpt);
            _cmd.CommandTimeout = 360;
            _cmd.ExecuteNonQuery();
        }
        public DataTable LOAD_CAS_PKG_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void CAS_PKG_SUM_RPT(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DBNAME", _objdb.Dataname);
            _cmd.Parameters.AddWithValue("@SCH_ID", _objdb.cas);
            _cmd.ExecuteNonQuery();
        }
        public DataTable LOAD_CAS_SERVICE_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SER_ID", _obj.srv);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void dr_cml_comment(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_itm_id", _obj.dr_itm_id);
            _cmd.Parameters.AddWithValue("@comment", _obj.response);
            _cmd.ExecuteNonQuery();
        }
        public DataTable LOAD_CAS_PRJ_SUMMARY(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Create_Building(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Build_Id", _obj.build_id);
            _cmd.Parameters.AddWithValue("@Build_Name", _obj.build_name);
            _cmd.Parameters.AddWithValue("@Project", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@Mode", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public void Delete_Schedule(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sch_Id", _obj.schid);
            _cmd.ExecuteNonQuery();
        }
        public int Get_Seq(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sys_Id", _obj.sys);
            _cmd.Parameters.AddWithValue("@F_lvl", _obj.f_level);
            _cmd.Parameters.AddWithValue("@B_Z", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@Pos", _obj.Position);
            _cmd.Parameters.Add("@Seq_No", SqlDbType.Int);
            _cmd.Parameters["@Seq_No"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Seq_No"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@Seq_No"].Value;
                else
                    return 1;
            }
            catch
            {
                throw;
            }
        }
        public int Get_Position(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sys_Id", _obj.sys);
            _cmd.Parameters.Add("@Position", SqlDbType.Int);
            _cmd.Parameters["@Position"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Position"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@Position"].Value;
                else
                    return 1;
            }
            catch
            {
                throw;
            }
        }

        public void Insert_SummaryGraph(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys_name", _obj.sys_mon);
            _cmd.Parameters.AddWithValue("@total", _obj.per_com1);
            _cmd.ExecuteNonQuery();
        }
        public void Clear_Rpt(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public void Generate_CASsheet_RPT(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Cas_Id", _objdb.rpt);
            _cmd.Parameters.AddWithValue("@DBNAME", _objdb.Dataname);
            _cmd.Parameters.AddWithValue("@PROJECT", _objdb.project);
            _cmd.Parameters.AddWithValue("@PROJECT_CODE", _objdb.Datapath);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_CASSummary_PKG_RPT(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys", _obj.sys_mon);
            _cmd.Parameters.AddWithValue("@qty", _obj.qty);
            _cmd.Parameters.AddWithValue("@per1", _obj.per_com1);
            _cmd.Parameters.AddWithValue("@per2", _obj.per_com2);
            _cmd.Parameters.AddWithValue("@per3", _obj.per_com3);
            _cmd.Parameters.AddWithValue("@total", _obj.total);
            _cmd.Parameters.AddWithValue("@code", _obj.cate);
            _cmd.Parameters.AddWithValue("@quantity", _obj.quantity);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_CASSummary_PKG_RPT_asao(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys", _obj.sys_mon);
            _cmd.Parameters.AddWithValue("@qty", _obj.qty);
            _cmd.Parameters.AddWithValue("@per1", _obj.per_com1);
            _cmd.Parameters.AddWithValue("@per2", _obj.per_com2);
            _cmd.Parameters.AddWithValue("@per3", _obj.per_com3);
            _cmd.Parameters.AddWithValue("@total", _obj.total);
            _cmd.Parameters.AddWithValue("@code", _obj.cate);
            _cmd.Parameters.AddWithValue("@quantity", _obj.quantity);
            _cmd.Parameters.AddWithValue("@compl1", _obj.compl1);
            _cmd.Parameters.AddWithValue("@compl2", _obj.compl2);
            _cmd.Parameters.AddWithValue("@compl3", _obj.compl3);
            _cmd.Parameters.AddWithValue("@compl4", _obj.compl4);
            _cmd.Parameters.AddWithValue("@per", _obj.per_com4);
            _cmd.ExecuteNonQuery();
        }
        public void Create_FLevel(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@F_lvl", _obj.f_level);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_CasServiceData(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@srv_id", _obj.srv);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Insert_CasServiceSummary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_name", _obj.cate);
            _cmd.Parameters.AddWithValue("@progress", _obj.per_com1);
            _cmd.ExecuteNonQuery();
        }
        public void Clear_CasServiceSummary(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public void Update_CMSDoc_Status(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@doc_status", _obj.status);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_MS_Summary(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@srv_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@doc_status", _obj.status);
            _cmd.ExecuteNonQuery();
        }
        public string Get_MsDoc_No(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@srv", _obj.doc_id);
            _cmd.Parameters.Add("@total", SqlDbType.Int);
            _cmd.Parameters["@total"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@total"].Value.ToString() != "")
                    return _cmd.Parameters["@total"].Value.ToString();
                else
                    return "0";
            }
            catch
            {
                throw;
            }
        }
        public DataTable Load_CMS_CommentsAll(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Module", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@Doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@type", _obj.folder_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_CMS_DocInfo(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Doc_id", _obj.doc_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_CML_DocReponse(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@response", _obj.status);
            _cmd.ExecuteNonQuery();
        }
        public void Update_CML_DocReponse1(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@response", _obj.status);
            _cmd.Parameters.AddWithValue("@closed", _obj.enabled);
            _cmd.ExecuteNonQuery();
        }
        public void Update_CML_DocCmtStatus(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@closed", _obj.enabled);
            _cmd.ExecuteNonQuery();
        }
        public void Manage_TrainingFolder(string _sp, _clsFolderTree _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_Id", _obj.Folder_id);
            _cmd.Parameters.AddWithValue("@Folder_Name", _obj.Folder_description);
            _cmd.Parameters.AddWithValue("@Type", _obj.Folder_type);
            _cmd.Parameters.AddWithValue("@Parent_Id", _obj.Parent_folder);
            _cmd.Parameters.AddWithValue("@Mode", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public string Get_FolderInfo(string _sp, _clsFolderTree _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.Add("@Folder_Name", SqlDbType.VarChar, 100);
            _cmd.Parameters["@Folder_Name"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Folder_Name"].Value.ToString() != "")
                    return _cmd.Parameters["@Folder_Name"].Value.ToString();
                else
                    return "0";
            }
            catch
            {
                throw;
            }
        }
        public void GEN_CMSDOCCOMM_RPT(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Module", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@Doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@type", _obj.folder_id);
            _cmd.ExecuteNonQuery();
        }
        public void GEN_CMSDOCINFO_RPT(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Doc_id", _obj.doc_id);
            _cmd.ExecuteNonQuery();
        }
        public void Gen_MS_Schedule_Summary(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public DataTable Gen_MS_Schedule_Summary_12761(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public int Check_EngRef(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@E_b_Ref", _obj.reff);
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.Add("@Exist", SqlDbType.Int);
            _cmd.Parameters["@Exist"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Exist"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@Exist"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void Generate_MS_Summary_ALL(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_status", _obj.status);
            _cmd.ExecuteNonQuery();
        }
        public string Get_MsDoc_No_All(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add("@total", SqlDbType.Int);
            _cmd.Parameters["@total"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@total"].Value.ToString() != "")
                    return _cmd.Parameters["@total"].Value.ToString();
                else
                    return "0";
            }
            catch
            {
                throw;
            }
        }
        public int Get_SysId(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Category", _obj.cate);
            _cmd.Parameters.AddWithValue("@Sch_Id", _obj.sch);
            _cmd.Parameters.Add("@Sys_Id", SqlDbType.Int);
            _cmd.Parameters["@Sys_Id"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Sys_Id"].Value.ToString() != "")
                    return Convert.ToInt32(_cmd.Parameters["@Sys_Id"].Value.ToString());
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void Set_CMSAccess(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@Access", _obj.access);
            _cmd.Parameters.AddWithValue("@Type", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public string Get_CMSAccess(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@User_id", _obj.uid);
            _cmd.Parameters.AddWithValue("@Project", _obj.project_code);
            _cmd.Parameters.AddWithValue("@Type", _obj.mode);
            _cmd.Parameters.Add("@Access", SqlDbType.VarChar, 50);
            _cmd.Parameters["@Access"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@Access"].Value.ToString();
        }
        public DataTable Load_CMS_Users(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@Type", _obj.mode);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void CMSDoc_Permission(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Doc_Id", _obj.Doc_Id);
            _cmd.Parameters.AddWithValue("@Comments_By", _obj.Comment_By);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_UsersCompany(string _sp, _clsproject _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Company_Id", _obj.com_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Add_ReviewSettings(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Doc_Name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@Review_Period", _obj.Review_Days);
            _cmd.ExecuteNonQuery();
        }
        public int Get_ReviewPeriod(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Doc_Name", _obj.doc_name);
            _cmd.Parameters.Add("@Review_Days", SqlDbType.Int);
            _cmd.Parameters["@Review_Days"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Review_Days"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@Review_Days"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public string Get_User_Permission(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.Add("@permission", SqlDbType.VarChar, 15);
            _cmd.Parameters["@permission"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@permission"].Value.ToString() != "")
                    return _cmd.Parameters["@permission"].Value.ToString();
                else
                    return "000000000";
            }
            catch
            {
                throw;
            }
        }
        public string Get_User_cmsAccess(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.Add("@access", SqlDbType.VarChar, 10);
            _cmd.Parameters["@access"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@access"].Value.ToString() != "")
                    return _cmd.Parameters["@access"].Value.ToString();
                else
                    return "";
            }
            catch
            {
                throw;
            }
        }

        public DataTable Load_CMSUsers(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@Module", _obj.mode);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_CMSUser(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Manage_MsFolder(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Ms_Sys_Id", _obj.mssys_id);
            _cmd.Parameters.AddWithValue("@Ms_Sys_Name", _obj.mssys_name);
            _cmd.Parameters.AddWithValue("@Ser_Id", _obj.srv_id);
            _cmd.Parameters.AddWithValue("@Pos", _obj.pos);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_AssetMaster(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sch_Id", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public string Get_ProjectName(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project", _obj.project_code);
            _cmd.Parameters.Add("@Project_Name", SqlDbType.VarChar, 100);
            _cmd.Parameters["@Project_Name"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@Project_Name"].Value.ToString();
        }
        public string Get_TempSONo(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add("@so_no", SqlDbType.VarChar, 10);
            _cmd.Parameters["@so_no"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@so_no"].Value.ToString();
        }
        public void Update_PrjLogo(string _sp, _clsproject _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project", _obj.prjcode);
            _cmd.Parameters.AddWithValue("@logo", _obj.logo);
            _cmd.ExecuteNonQuery();
        }
        public void Update_RPTLogo(string _sp, _clsproject _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project", _obj.prjcode);
            _cmd.ExecuteNonQuery();
        }
        //################################################AMS####################################################

        public void DML_Manufacturer(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Manuf_Id", _obj.manufId);
            _cmd.Parameters.AddWithValue("@Manuf_Name", _obj.manufName);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_Supplier(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Supplier_Id", _obj.supId);
            _cmd.Parameters.AddWithValue("@Supplier_Name", _obj.supName);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_AMSInfo(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_Reg_Id", _obj.ams_reg_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void DML_AssetDetails(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_AD_Id", _obj.adId);
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Equip_No", _obj.eqpNo);
            _cmd.Parameters.AddWithValue("@Manufacturer_Id", _obj.manufId);
            _cmd.Parameters.AddWithValue("@Model_Ref", _obj.model);
            _cmd.Parameters.AddWithValue("@Serial_No", _obj.srlno);
            _cmd.Parameters.AddWithValue("@AMS_Sys_Id", _obj.ams_sys_id);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_Purchase(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_PD_Id", _obj.adId);
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Equip_No", _obj.eqpNo);
            _cmd.Parameters.AddWithValue("@Supplier_Id", _obj.supId);
            _cmd.Parameters.AddWithValue("@BPartner", _obj.partner);
            _cmd.Parameters.AddWithValue("@PO_No", _obj.pono);
            _cmd.Parameters.AddWithValue("@PPrice", _obj.pprice);
            _cmd.Parameters.AddWithValue("@Currency", _obj.cur);
            _cmd.Parameters.AddWithValue("@WExp_Date", _obj.edate);
            _cmd.Parameters.AddWithValue("@Replace_Cost", _obj.rcost);
            _cmd.Parameters.AddWithValue("@Replace_By", _obj.rpby);
            _cmd.Parameters.AddWithValue("@Purchase_date", _obj.pdate);
            _cmd.Parameters.AddWithValue("@Depreciation_Value", _obj.depreciation);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_Contractor(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Contr_Id", _obj.contrId);
            _cmd.Parameters.AddWithValue("@Contr_Name", _obj.contrName);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_MaintenanceContract(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@MC_Id", _obj.mcId);
            _cmd.Parameters.AddWithValue("@Cas_Id", _obj.casId);
            _cmd.Parameters.AddWithValue("@Equip_No", _obj.eqpNo);
            _cmd.Parameters.AddWithValue("@Contr_Id", _obj.contrId);
            _cmd.Parameters.AddWithValue("@Annual_Charges", _obj.pprice);
            _cmd.Parameters.AddWithValue("@S_Date", _obj.cdate);
            _cmd.Parameters.AddWithValue("@E_Date", _obj.edate);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_ElectricalDtls(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_ED_Id", _obj.eId);
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Equip_No", _obj.eqpNo);
            _cmd.Parameters.AddWithValue("@Phase", _obj.phase);
            _cmd.Parameters.AddWithValue("@Voltage", _obj.voltage);
            _cmd.Parameters.AddWithValue("@Amps", _obj.amp);
            _cmd.Parameters.AddWithValue("@Others", _obj.other);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_MechanicalDtls(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_MD_Id", _obj.mId);
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Equip_No", _obj.eqpNo);
            _cmd.Parameters.AddWithValue("@W_temp", _obj.wtemp);
            _cmd.Parameters.AddWithValue("@Rpm", _obj.rpm);
            _cmd.Parameters.AddWithValue("@Others", _obj.other);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_CivilDtls(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_CD_Id", _obj.cId);
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Equip_No", _obj.eqpNo);
            _cmd.Parameters.AddWithValue("@B_Area", _obj.bArea);
            _cmd.Parameters.AddWithValue("@A_Occupied", _obj.aOccupied);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_ScheduleList(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@Folder_Id", _obj.folder_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void DML_CheckDates(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@ACD_Id", _obj.ACD_id);
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Comm_SOD", _obj.Comm_SOD);
            _cmd.Parameters.AddWithValue("@Daily_Check", _obj.DailyChk);
            _cmd.Parameters.AddWithValue("@Weekly_Check", _obj.WeeklyChk);
            _cmd.Parameters.AddWithValue("@Monthly_Check", _obj.MonthlyChk);
            _cmd.Parameters.AddWithValue("@TMonths_Check", _obj.TMonthsChk);
            _cmd.Parameters.AddWithValue("@SMonths_Check", _obj.SMonthsChk);
            _cmd.Parameters.AddWithValue("@Yearly_Check", _obj.YearlyChk);
            _cmd.ExecuteNonQuery();
        }
        public string Get_CheckNames(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Date", _obj.edate);
            _cmd.Parameters.AddWithValue("@Cas_Id", _obj.casId);
            _cmd.Parameters.Add("@Check", SqlDbType.VarChar, 25);
            _cmd.Parameters["@Check"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Check"].Value.ToString() != "")
                    return (string)_cmd.Parameters["@Check"].Value;
                else
                    return "No";
            }
            catch
            {
                throw;
            }
        }
        public void Add_Task(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Task", _obj.task);
            _cmd.Parameters.AddWithValue("@Type", _obj.type);
            _cmd.Parameters.AddWithValue("@Man_Hrs", _obj.man_hrs);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_Ams_Task(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Type", _obj.type);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Gen_AMS_Task_Rpt(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Type", _obj.type);
            _cmd.ExecuteNonQuery();
        }
        //**************************************TIS******************************************************

        public DataTable LOAD_MASTER(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PROJECT_CODE", _obj.prj_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable LOAD_FLOOR(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@BLDG_ID", _obj.bldg_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable LOAD_ZONE(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@FLR_ID", _obj.flr_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable LOAD_TENANTS(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@ZN_ID", _obj.zn_id);
            _cmd.Parameters.AddWithValue("@FLR_ID", _obj.flr_id);
            _cmd.Parameters.AddWithValue("@TYPE", _obj.action);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable LOAD_FOLDER(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void DML_TENANCY_CONTRACT(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@TNC_NAME", _obj.tnc_name);
            _cmd.Parameters.AddWithValue("@UPLOAD_DATE", _obj.update);
            _cmd.Parameters.AddWithValue("@FILE_NAME", _obj.filename);
            _cmd.Parameters.AddWithValue("@FROM_DATE", _obj.fdate);
            _cmd.Parameters.AddWithValue("@TO_DATE", _obj.tdate);
            _cmd.Parameters.AddWithValue("@REMIND_DATE", _obj.rdate);
            _cmd.Parameters.AddWithValue("@VALUE", _obj.tvalue);
            _cmd.Parameters.AddWithValue("@CURRENCY", _obj.cur);
            _cmd.Parameters.AddWithValue("@TENANT_ID", _obj.tnts_id);
            _cmd.Parameters.AddWithValue("@PROJECT_CODE", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@ACTION", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable LOAD_TENANCY_CONTRACT(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@TENANT_ID", _obj.tnts_id);
            _cmd.Parameters.AddWithValue("@STATUS", _obj.status);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void DML_AUTHORITY_LETTER(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@LETTER_NAME", _obj.letter);
            _cmd.Parameters.AddWithValue("@FILE_NAME", _obj.filename);
            _cmd.Parameters.AddWithValue("@SUBJECT", _obj.subject);
            _cmd.Parameters.AddWithValue("@LETTER_FROM", _obj.from);
            _cmd.Parameters.AddWithValue("@RECEIVED", _obj.rdate);
            _cmd.Parameters.AddWithValue("@TENANT_ID", _obj.tnts_id);
            _cmd.Parameters.AddWithValue("@PROJECT_CODE", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@ACTION", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_TC_DOCUMENTS(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SERVICE_NAME", _obj.service);
            _cmd.Parameters.AddWithValue("@ENG_REFF", _obj.eng_ref);
            _cmd.Parameters.AddWithValue("@CATEGORY", _obj.cate);
            _cmd.Parameters.AddWithValue("@FLOOR_LEVEL", _obj.flevel);
            _cmd.Parameters.AddWithValue("@INSP_DATE", _obj.rdate);
            _cmd.Parameters.AddWithValue("@FILE_NAME", _obj.filename);
            _cmd.Parameters.AddWithValue("@TENANT_ID", _obj.tnts_id);
            _cmd.Parameters.AddWithValue("@PROJECT_CODE", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@ACTION", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable LOAD_DATEREGISTER(string _sp, _clstis _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@TENANT_ID", _obj.tnts_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_PrjReference(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sys_id", _obj.sys);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Edit_Task(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Task_Id", _obj.task_id);
            _cmd.Parameters.AddWithValue("@Task", _obj.task);
            _cmd.Parameters.AddWithValue("@Type", _obj.type);
            _cmd.Parameters.AddWithValue("@Man_Hrs", _obj.man_hrs);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void DML_SpareParts(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SP_Id", _obj.sp_id);
            _cmd.Parameters.AddWithValue("@Srv_Id", _obj.srv_id);
            _cmd.Parameters.AddWithValue("@Sys_Id", _obj.sys_id);
            _cmd.Parameters.AddWithValue("@SP_Name", _obj.sp_name);
            _cmd.Parameters.AddWithValue("@SP_Code", _obj.sp_code);
            _cmd.Parameters.AddWithValue("@SP_Cost", _obj.sp_cost);
            _cmd.Parameters.AddWithValue("@Manufacturer", _obj.manufId);
            _cmd.Parameters.AddWithValue("@Supplier", _obj.supId);
            _cmd.Parameters.AddWithValue("@Warning_Qty", _obj.wqty);
            _cmd.Parameters.AddWithValue("@Total_Qty", _obj.qty);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_SpareParts(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sys_id", _obj.sys_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_AMSTaskList(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Check_Date", _obj.chkdate);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_AMSCheckDates(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Date", _obj.edate);
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.ExecuteNonQuery();
        }
        public void Add_SPBasket(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@S_Parts", _obj.sp_name);
            _cmd.Parameters.AddWithValue("@S_Parts_Id", _obj.sp_id);
            _cmd.Parameters.AddWithValue("@Qty", _obj.qty);
            _cmd.Parameters.AddWithValue("@Uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@Cas_id", _obj.casId);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_SPBasket(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@Cas_id", _obj.casId);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Insert_TaskCompletion(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Task_Compl_Id", _obj.task_compl_id);
            _cmd.Parameters.AddWithValue("@Manpower", _obj.man_hrs);
            _cmd.Parameters.AddWithValue("@Comment", _obj.comments);
            _cmd.ExecuteNonQuery();
        }
        public void Insert_SpUsed(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Task_Compl_Id", _obj.task_compl_id);
            _cmd.Parameters.AddWithValue("@S_Parts_Id", _obj.sp_id);
            _cmd.Parameters.AddWithValue("@Qty", _obj.qty);
            _cmd.ExecuteNonQuery();
        }
        public void Delete_SPBasket(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Cas_Id", _obj.casId);
            _cmd.Parameters.AddWithValue("@User_id", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public void Insert_DRTemp(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Dr_Details", _obj.details);
            _cmd.Parameters.AddWithValue("@Dr_Descr", _obj.descr);
            _cmd.Parameters.AddWithValue("@Uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@Dr_Doc", _obj.dr_reviewed);
            _cmd.Parameters.AddWithValue("@Service", _obj.service);
            _cmd.Parameters.AddWithValue("@Building", _obj.building);
            _cmd.ExecuteNonQuery();
        }
        public void Delete_DRTemp(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@Dr_Doc", _obj.dr_reviewed);
            _cmd.Parameters.AddWithValue("@Service", _obj.service);
            _cmd.ExecuteNonQuery();
        }
        public void Remove_DRTemp(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Temp_Id", _obj.dr_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_DRTemp(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@Dr_Doc", _obj.dr_reviewed);
            _cmd.Parameters.AddWithValue("@Service", _obj.service);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_CasAsset(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@Sys_Id", _obj.sys);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_Cas_Docselection_AMS(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sys_Id", _obj.sys);
            _cmd.Parameters.AddWithValue("@B_Z", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@F_lvl", _obj.f_level);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_DMSDoc_AMS(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_Id", _obj.folder_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void AMS_Register(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@PROJECT_REF", _obj.prj_reff);
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch_id);
            _cmd.Parameters.AddWithValue("@SYS_ID", _obj.sys_id);
            _cmd.Parameters.AddWithValue("@BZONE", _obj.bzone);
            _cmd.Parameters.AddWithValue("@CAT", _obj.cat);
            _cmd.Parameters.AddWithValue("@FLEVEL", _obj.flvl);
            _cmd.Parameters.AddWithValue("@SEQ_NO", _obj.seq_no);
            _cmd.Parameters.AddWithValue("@PARENT", _obj.parent);
            _cmd.Parameters.AddWithValue("@POSSITION", _obj.position);
            _cmd.Parameters.AddWithValue("@CAS_ID", _obj.casId);
            _cmd.Parameters.AddWithValue("@LOCATION", _obj.location);
            _cmd.Parameters.AddWithValue("@PARENT_ASSET", _obj.parent_id);
            _cmd.Parameters.AddWithValue("@ACTION", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public string Get_Category(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sys_Id", _obj.sys);
            _cmd.Parameters.Add("@Cate", SqlDbType.VarChar, 10);
            _cmd.Parameters["@Cate"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                return (string)_cmd.Parameters["@Cate"].Value;
            }
            catch
            {
                throw;
            }
        }
        public int Get_NoofCas(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Srv_Id", _obj.srv);
            _cmd.Parameters.Add("@Count", SqlDbType.Int);
            _cmd.Parameters["@Count"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Count"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@Count"].Value;
                else
                    return 1;
            }
            catch
            {
                throw;
            }
        }
        public DataTable LOAD_AMS_SCHEDULE_TASK(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@TYPE", _obj.type);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Insert_PPMSDaily_Temp(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public void Insert_TaskExtension(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Task_Compl_Id", _obj.task_compl_id);
            _cmd.Parameters.AddWithValue("@Date", _obj.edate);
            _cmd.ExecuteNonQuery();
        }
        public void AMS_Document_Linking(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_DOC_ID", _obj.ams_doc_id);
            _cmd.Parameters.AddWithValue("@AMS_REG_ID", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@DOC_ID", _obj.dms_doc_id);
            _cmd.Parameters.AddWithValue("@DOC_NAME", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@DOC_TYPE", _obj.doc_type);
            _cmd.Parameters.AddWithValue("@DOC_PACKAGE", _obj.doc_package);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_AMS_Documents(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_Reg_Id", _obj.ams_reg_id);
            _cmd.Parameters.AddWithValue("@Doc_Type", _obj.doc_type);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_AMS_SubAssets(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Parent_Asset", _obj.ams_reg_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_Asset_Spareparts(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_Reg_Id", _obj.ams_reg_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_Spareparts_Details(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SP_Id", _obj.sp_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Generate_TS_Upload_Rpt(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PERIOD_START", _obj.act_date);
            _cmd.Parameters.AddWithValue("@SERVICE", _obj.srv);
            _cmd.ExecuteNonQuery();
        }
        public string Get_Est_TSCompl_date(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SERVICE", _obj.srv);
            _cmd.Parameters.Add("@COMP_DATE", SqlDbType.VarChar, 15);
            _cmd.Parameters["@COMP_DATE"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@COMP_DATE"].Value.ToString() != "")
                    return (string)_cmd.Parameters["@COMP_DATE"].Value;
                else
                    return "Not Available";
            }
            catch
            {
                throw;
            }
        }
        public void DML_AMS_System(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@AMS_SYS_ID", _obj.ams_sys_id);
            _cmd.Parameters.AddWithValue("@ASSET_ID", _obj.srv_id);
            _cmd.Parameters.AddWithValue("@GROUP_ID", _obj.sch_id);
            _cmd.Parameters.AddWithValue("@SYS_NAME", _obj.ams_sys_name);
            _cmd.Parameters.AddWithValue("@DESCRIPTION", _obj.descri);
            _cmd.Parameters.AddWithValue("@ACTION", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_AMS_System(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Group_Id", _obj.casId);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Generate_AmsRegister(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PROJECT", _obj.project_code);
            _cmd.ExecuteNonQuery();
        }
        public void Update_DrIssueTo(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DR_ID", _obj.dr_id);
            _cmd.Parameters.AddWithValue("@ISSUE_TO", _obj.issued_to);
            _cmd.Parameters.AddWithValue("@ISSUE_DATE", _obj.issued_date);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_SO_Info(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SO_Id", _obj.so_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_SOIssueTo(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SO_ID", _obj.so_id);
            _cmd.Parameters.AddWithValue("@ISSUE_TO", _obj.issued_to);
            _cmd.Parameters.AddWithValue("@ISSUE_DATE", _obj.issued_date);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_Cas_SrvSum_All(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SCH_NAME", _obj.sch_name);
            _cmd.Parameters.AddWithValue("@SYSTEM", _obj.sys_name);
            _cmd.Parameters.AddWithValue("@QTY", _obj.quantity);
            _cmd.Parameters.AddWithValue("@OVERALL", _obj.total);
            _cmd.Parameters.AddWithValue("@PRE_COM", _obj.pre_com);
            _cmd.Parameters.AddWithValue("@COM", _obj.com);
            _cmd.Parameters.AddWithValue("@WITNE", _obj.witne);
            _cmd.Parameters.AddWithValue("@INSTA", _obj.insta);
            _cmd.Parameters.AddWithValue("@POS", _obj.Position);
            _cmd.Parameters.AddWithValue("@WEIGHTING", _obj.per_com1);
            _cmd.Parameters.AddWithValue("@SRV_ID", _obj.srv);
            _cmd.ExecuteNonQuery();
        }
        public string Get_CasName(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch);
            _cmd.Parameters.Add("@CAS_NAME", SqlDbType.VarChar, 50);
            _cmd.Parameters["@CAS_NAME"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                return (string)_cmd.Parameters["@CAS_NAME"].Value;
            }
            catch
            {
                throw;
            }
        }
        public void Clear_Srv_Sum(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public string Get_SrvName(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch", _obj.sch);
            _cmd.Parameters.Add("@srv", SqlDbType.VarChar, 50);
            _cmd.Parameters["@srv"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                return (string)_cmd.Parameters["@srv"].Value;
            }
            catch
            {
                throw;
            }
        }
        public DataTable Load_serv_package(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SRV_ID", _obj.srv);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Insert_DMS_TCDOC(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PRJ_CODE", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@DMS_FOLDER", _obj.srv);
            _cmd.Parameters.AddWithValue("@CMS_SYS_ID", _obj.sys);
            _cmd.ExecuteNonQuery();
        }
        public void Delete_DMS_TCDOC(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PRJ_CODE", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@DMS_FOLDER", _obj.srv);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_DMS_TCDOC_SYS(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PRJ_CODE", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@DMS_FOLDER", _obj.srv);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_DMS_TCDOC(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SYS_ID", _obj.sys);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable load_dms_user_email(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@srv", _obj.schid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public int Get_Package_Service(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@package", _obj.package_code);
            _cmd.Parameters.Add("@srv", SqlDbType.Int);
            _cmd.Parameters["@srv"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@srv"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@srv"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void dml_cas_panel(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Panel_id", _obj.panel_id);
            _cmd.Parameters.AddWithValue("@Panel_ref", _obj.panel_ref);
            _cmd.Parameters.AddWithValue("@Sys_id", _obj.sys);
            _cmd.Parameters.AddWithValue("@Sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@Parent", _obj.parent);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable load_cas_panel(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public int get_panel_id(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@panel_ref", _obj.panel_ref);
            _cmd.Parameters.Add("@panel_id", SqlDbType.Int);
            _cmd.Parameters["@panel_id"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@panel_id"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@panel_id"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void Generate_CASSummary_PKG_RPT_CCAD_FAS(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys", _obj.sys_name);
            _cmd.Parameters.AddWithValue("@qty1", _obj.qty1);
            _cmd.Parameters.AddWithValue("@tested1", _obj.testd1);
            _cmd.Parameters.AddWithValue("@qty2", _obj.qty2);
            _cmd.Parameters.AddWithValue("@tested2", _obj.testd2);
            _cmd.Parameters.AddWithValue("@qty3", _obj.qty3);
            _cmd.Parameters.AddWithValue("@tested3", _obj.testd3);
            _cmd.Parameters.AddWithValue("@qty4", _obj.qty4);
            _cmd.Parameters.AddWithValue("@tested4", _obj.testd4);
            _cmd.Parameters.AddWithValue("@qty", _obj.quaty);
            _cmd.Parameters.AddWithValue("@tested", _obj.testd);
            _cmd.Parameters.AddWithValue("@total", _obj.total);
            _cmd.ExecuteNonQuery();
        }
        public void Insert_SO_Uversion(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_id", _obj.so_id);
            _cmd.Parameters.AddWithValue("@srv_id", _obj.srv_id);
            _cmd.Parameters.AddWithValue("@sub", _obj.sub);
            _cmd.Parameters.AddWithValue("@issue_date", _obj.idate);
            _cmd.Parameters.AddWithValue("@issued_by", _obj.issued_by);
            _cmd.Parameters.AddWithValue("@issued_to", _obj.issued_to);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@comments", _obj.comments);
            _cmd.Parameters.AddWithValue("@response", _obj.response);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@details", _obj.details);
            _cmd.Parameters.AddWithValue("@dt_compl", _obj.cdate);
            _cmd.Parameters.AddWithValue("@action", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_So_Uversion(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Generate_CASSummary_PKGGRP_CCAD_MEC(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@main_sys", _obj.sys_mon);
            _cmd.Parameters.AddWithValue("@sub_sys", _obj.sys_name);
            _cmd.Parameters.AddWithValue("@sys", _obj.sch_name);
            _cmd.Parameters.AddWithValue("@qty", _obj.quantity);
            _cmd.Parameters.AddWithValue("@tst1", _obj.per_com1);
            _cmd.Parameters.AddWithValue("@tst2", _obj.per_com2);
            _cmd.Parameters.AddWithValue("@tst3", _obj.per_com3);
            _cmd.Parameters.AddWithValue("@tst4", _obj.per_com4);
            _cmd.Parameters.AddWithValue("@tst5", _obj.per_com5);
            _cmd.Parameters.AddWithValue("@tst6", _obj.per_com6);
            _cmd.ExecuteNonQuery();
        }
        public string get_main_sys(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _cmd.Parameters.Add("@sys_name", SqlDbType.VarChar, 50);
            _cmd.Parameters["@sys_name"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@sys_name"].Value.ToString() != "")
                    return _cmd.Parameters["@sys_name"].Value.ToString();
                else
                    return "";
            }
            catch
            {
                throw;
            }
        }
        public void Generate_Cassheet_Summary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@srv", _obj.sys_mon);
            _cmd.Parameters.AddWithValue("@sch", _obj.sch_name);
            _cmd.Parameters.AddWithValue("@sys", _obj.sys_name);
            _cmd.Parameters.AddWithValue("@qty", _obj.quantity);
            _cmd.Parameters.AddWithValue("@t1", _obj.per_com1);
            _cmd.Parameters.AddWithValue("@t2", _obj.per_com2);
            _cmd.Parameters.AddWithValue("@t3", _obj.per_com3);
            _cmd.Parameters.AddWithValue("@t4", _obj.per_com4);
            _cmd.Parameters.AddWithValue("@t5", _obj.per_com5);
            _cmd.Parameters.AddWithValue("@t6", _obj.per_com6);
            _cmd.Parameters.AddWithValue("@t7", _obj.per_com7);
            _cmd.Parameters.AddWithValue("@c1", _obj.per_com8);
            _cmd.Parameters.AddWithValue("@c2", _obj.per_com9);
            _cmd.Parameters.AddWithValue("@p", _obj.Position);
            _cmd.Parameters.AddWithValue("@t8", _obj.per_com10);
            _cmd.Parameters.AddWithValue("@t9", _obj.per_com11);
            _cmd.Parameters.AddWithValue("@t10", _obj.per_com12);
            _cmd.ExecuteNonQuery();
        }
        public int get_schedule_possition(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.Add("@possition", SqlDbType.Int);
            _cmd.Parameters["@possition"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@possition"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@possition"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void Insert_dmsdoc_upload(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@file_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@upload_by", _obj.uid);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@type", _obj.folder_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable load_dms_doc_upload(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@type", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public int dml_cx_issues_log(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cx_log_id", _obj.c_s_id);
            _cmd.Parameters.AddWithValue("@source_doc", _obj.doc);
            _cmd.Parameters.AddWithValue("@source_doc_ref", _obj.reff);
            _cmd.Parameters.AddWithValue("@zutec_cx_issue", _obj.cx_issue);
            _cmd.Parameters.AddWithValue("@ser_id", _obj.srv);
            _cmd.Parameters.AddWithValue("@system", _obj.sch_name);
            _cmd.Parameters.AddWithValue("@issue_type", _obj.type);
            _cmd.Parameters.AddWithValue("@location", _obj.loca);
            _cmd.Parameters.AddWithValue("@description", _obj.desc);
            _cmd.Parameters.AddWithValue("@responsible", _obj.responsible);
            _cmd.Parameters.AddWithValue("@date_rep", _obj.dt_rep);
            _cmd.Parameters.AddWithValue("@date_tc", _obj.dt_tc);
            _cmd.Parameters.AddWithValue("@last_update", _obj.last_update);
            _cmd.Parameters.AddWithValue("@date_clsd", _obj.dt_closed);
            _cmd.Parameters.AddWithValue("@date_closure", _obj.dt_closure);
            _cmd.Parameters.AddWithValue("@resol_status", _obj.resol_status);
            _cmd.Parameters.AddWithValue("@discipline", _obj.disci);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.Parameters.Add("@id", SqlDbType.Int);
            _cmd.Parameters["@id"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@id"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@id"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void update_cx_risk_assessment(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cx_log_id", _obj.c_s_id);
            _cmd.Parameters.AddWithValue("@impact", _obj.impact);
            _cmd.Parameters.AddWithValue("@description", _obj.desc);
            _cmd.Parameters.AddWithValue("@probability", _obj.prob);
            _cmd.Parameters.AddWithValue("@timeline", _obj.timeline);
            _cmd.Parameters.AddWithValue("@resp_status", _obj.rstatus);
            _cmd.ExecuteNonQuery();
        }
        public void update_cx_mitigation(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cx_log_id", _obj.c_s_id);
            _cmd.Parameters.AddWithValue("@caction", _obj.caction);
            _cmd.Parameters.AddWithValue("@pfaction", _obj.faction);
            _cmd.Parameters.AddWithValue("@rstatus", _obj.rstatus);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_CX_Log_Rpt(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public DataTable load_cx_issues(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cx_log_id", _obj.c_s_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void update_cx_summary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cx_bldg_id", _obj.c_s_id);
            _cmd.Parameters.AddWithValue("@hi_p_closed", _obj.caction);
            _cmd.Parameters.AddWithValue("@hi_p_open", _obj.faction);
            _cmd.Parameters.AddWithValue("@comments", _obj.rstatus);
            _cmd.ExecuteNonQuery();
        }
        public int Get_Cx_IssuesRaised(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@bldg_name", _obj.loca);
            _cmd.Parameters.AddWithValue("@str_date", _obj.dt_rep);
            _cmd.Parameters.Add("@issues", SqlDbType.Int);
            _cmd.Parameters["@issues"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@issues"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@issues"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void Insert_CX_RO_Summary_rpt(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@bldg_name", _obj.loca);
            _cmd.Parameters.AddWithValue("@issues_raised", _obj.iss_raised);
            _cmd.Parameters.AddWithValue("@issues_raised_period", _obj.iss_period);
            _cmd.Parameters.AddWithValue("@issues_total", _obj.iss_total);
            _cmd.Parameters.AddWithValue("@issues_open", _obj.iss_open);
            _cmd.Parameters.AddWithValue("@hi_p_close", _obj.hi_p_close);
            _cmd.Parameters.AddWithValue("@hi_p_open", _obj.hi_p_open);
            _cmd.Parameters.AddWithValue("@resp1", _obj.resp1);
            _cmd.Parameters.AddWithValue("@resp2", _obj.resp2);
            _cmd.Parameters.AddWithValue("@resp3", _obj.resp3);
            _cmd.Parameters.AddWithValue("@resp4", _obj.resp4);
            _cmd.Parameters.AddWithValue("@resp5", _obj.resp5);
            _cmd.Parameters.AddWithValue("@comment", _obj.comm);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_Document_Review_Log(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@srv_name", _obj.service);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_Document_Review_Items(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_itm_id", _obj.dr_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Edit_DR(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _cmd.Parameters.AddWithValue("@dr_itm_id", _obj.dr_itm_id);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.reviewed_by);
            _cmd.Parameters.AddWithValue("@details", _obj.details);
            _cmd.Parameters.AddWithValue("@description", _obj.descr);
            _cmd.Parameters.AddWithValue("@action", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_SO_Items(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_itm_id", _obj.so_itm_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Edit_SO(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@so_id", _obj.so_id);
            _cmd.Parameters.AddWithValue("@so_itm_id", _obj.so_itm_id);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@details", _obj.details);
            _cmd.Parameters.AddWithValue("@cmmts", _obj.comments);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@action", _obj.mode);
            _cmd.Parameters.AddWithValue("@photo", _obj.photo);
            _cmd.ExecuteNonQuery();
        }
        public void Dml_CXIR_Schedule(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cx_ir_id", _obj.c_s_id);
            _cmd.Parameters.AddWithValue("@ir_ref", _obj.reff);
            _cmd.Parameters.AddWithValue("@ir_rev", _obj.ir_rev);
            _cmd.Parameters.AddWithValue("@dt_recv", _obj.dt_rep);
            _cmd.Parameters.AddWithValue("@dt_prop", _obj.dt_tc);
            _cmd.Parameters.AddWithValue("@am_pm", _obj.am_pm);
            _cmd.Parameters.AddWithValue("@test_type", _obj.type);
            _cmd.Parameters.AddWithValue("@discipline", _obj.sch_name);
            _cmd.Parameters.AddWithValue("@system", _obj.sys_name);
            _cmd.Parameters.AddWithValue("@details", _obj.desc);
            _cmd.Parameters.AddWithValue("@building", _obj.build_name);
            _cmd.Parameters.AddWithValue("@flevel", _obj.flevel);
            _cmd.Parameters.AddWithValue("@location", _obj.loca);
            _cmd.Parameters.AddWithValue("@ir_checked", _obj.ir_chkd);
            _cmd.Parameters.AddWithValue("@advise", _obj.advise);
            _cmd.Parameters.AddWithValue("@prop_start", _obj.dtpstart);
            _cmd.Parameters.AddWithValue("@actual_start", _obj.dtastart);
            _cmd.Parameters.AddWithValue("@dt_compl", _obj.dtcomp);
            _cmd.Parameters.AddWithValue("@visit", _obj.visit);
            _cmd.Parameters.AddWithValue("@witness", _obj.witness);
            _cmd.Parameters.AddWithValue("@ir_status", _obj.ir_status);
            _cmd.Parameters.AddWithValue("@doc_status", _obj.doc_status);
            _cmd.Parameters.AddWithValue("@svr_no", _obj.svr_no);
            _cmd.Parameters.AddWithValue("@notes", _obj.comm);
            _cmd.Parameters.AddWithValue("@action", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_CXIR_Schedule_Details(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cx_ir_id", _obj.c_s_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public int Get_CMS_TC_Count(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.Add("@count", SqlDbType.Int);
            _cmd.Parameters["@count"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@count"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@count"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public bool Check_CMS(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.Add("@cms", SqlDbType.Bit);
            _cmd.Parameters["@cms"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@cms"].Value.ToString() == "True")
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }
        public DataTable Load_Cassheet_Sub(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_User_Projects(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@user", _obj.uid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void dml_com_certificate(string _sp, _clstestpack _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@system", _obj.system);
            _cmd.Parameters.AddWithValue("@sheet_ref", _obj.sheet_ref);
            _cmd.Parameters.AddWithValue("@asset_code", _obj.asset_code);
            _cmd.Parameters.AddWithValue("@type_work", _obj.type_work);
            _cmd.Parameters.AddWithValue("@location", _obj.location);
            _cmd.Parameters.AddWithValue("@test_type", _obj.test_type);
            _cmd.Parameters.AddWithValue("@comments", _obj.comments);
            _cmd.Parameters.AddWithValue("@tested_by", _obj.tested_by);
            _cmd.Parameters.AddWithValue("@tested_date", _obj.tested_date);
            _cmd.Parameters.AddWithValue("@witnessed_by", _obj.witnessed_by);
            _cmd.Parameters.AddWithValue("@wit_date", _obj.wit_date);
            _cmd.Parameters.AddWithValue("@accepted_by", _obj.accepted_by);
            _cmd.Parameters.AddWithValue("@acce_date", _obj.acce_date);
            _cmd.Parameters.AddWithValue("@instru_used", _obj.instru_used);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public string Get_Assetcode(string _sp, _clstestpack _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.Add("@asset_code", SqlDbType.VarChar, 50);
            _cmd.Parameters["@asset_code"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@asset_code"].Value.ToString() != null)
                    return _cmd.Parameters["@asset_code"].Value.ToString();
                else
                    return "'N/A";
            }
            catch
            {
                throw;
            }
        }
        public string Get_PlantRef(string _sp, _clstestpack _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.Add("@ref", SqlDbType.VarChar, 50);
            _cmd.Parameters["@ref"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@ref"].Value.ToString() != null)
                    return _cmd.Parameters["@ref"].Value.ToString();
                else
                    return "'N/A";
            }
            catch
            {
                throw;
            }
        }
        public void dml_precom_checklist(string _sp, _clstestpack _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@sheet_ref", _obj.sheet_ref);
            _cmd.Parameters.AddWithValue("@asset_code", _obj.asset_code);
            _cmd.Parameters.AddWithValue("@system", _obj.system);
            _cmd.Parameters.AddWithValue("@location", _obj.location);
            _cmd.Parameters.AddWithValue("@plant_ref", _obj.plant_ref);
            _cmd.Parameters.AddWithValue("@rev", _obj.rev);
            _cmd.Parameters.AddWithValue("@tested_by", _obj.tested_by);
            _cmd.Parameters.AddWithValue("@witnessed_by", _obj.witnessed_by);
            _cmd.Parameters.AddWithValue("@dt_tested", _obj.tested_date);
            _cmd.Parameters.AddWithValue("@dt_witnessed", _obj.wit_date);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void insert_precom_checklist_list(string _sp, _clstestpack _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@chk_list_id", _obj.list_id);
            _cmd.Parameters.AddWithValue("@test", _obj.chk_list);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@status_date", _obj.tested_date);
            _cmd.Parameters.AddWithValue("@signature", _obj.signature);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_TP_Details(string _sp, _clstestpack _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public int Get_FolderType(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.Add("@type", SqlDbType.Int);
            _cmd.Parameters["@type"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@type"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@type"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void DML_System_List(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _cmd.Parameters.AddWithValue("@Critical", _obj.Critical);
            _cmd.Parameters.AddWithValue("@Responsible", _obj.resp1);
            _cmd.Parameters.AddWithValue("@P1", _obj.per_com1);
            _cmd.Parameters.AddWithValue("@P2", _obj.per_com2);
            _cmd.Parameters.AddWithValue("@P3", _obj.per_com3);
            _cmd.Parameters.AddWithValue("@P4", _obj.per_com4);
            _cmd.Parameters.AddWithValue("@P5", _obj.per_com5);
            _cmd.Parameters.AddWithValue("@P6", _obj.per_com6);
            _cmd.Parameters.AddWithValue("@P7", _obj.per_com7);
            _cmd.Parameters.AddWithValue("@P8", _obj.per_com8);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_System_List(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_System_List_Edit(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_System_List(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _cmd.Parameters.AddWithValue("@P7", _obj.p7);
            _cmd.Parameters.AddWithValue("@P8", _obj.p8);
            _cmd.Parameters.AddWithValue("@P9", _obj.p9);
            _cmd.Parameters.AddWithValue("@P10", _obj.p10);
            _cmd.Parameters.AddWithValue("@P11", _obj.p11);
            _cmd.Parameters.AddWithValue("@P12", _obj.p12);
            _cmd.Parameters.AddWithValue("@P13", _obj.p13);
            _cmd.Parameters.AddWithValue("@P14", _obj.p14);
            _cmd.ExecuteNonQuery();
        }
        public void Set_Cassheet_Position(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@cas_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _cmd.Parameters.AddWithValue("@pos", _obj.Position);
            _cmd.ExecuteNonQuery();
        }
        public void Add_Cas_MultiEdit_Temp(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@sys_id", _obj.sys);
            _cmd.Parameters.AddWithValue("@user_id", _obj.uid);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void GENERATE_PROJECT_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@BZONE", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.ExecuteNonQuery();
        }
        public void GENERATE_SERVICE_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SRV_ID", _obj.srv);
            _cmd.Parameters.AddWithValue("@BZONE", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.ExecuteNonQuery();
        }
        public void GENERATE_PACKAGE_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public DataTable LOAD_PROJECT_MODULE(string _sp, _clsproject _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@USERID", _obj.user);
            _cmd.Parameters.AddWithValue("@MODULE", _obj.module);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void GENERATE_SRVOVR_SUMMARY(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public void GENERATE_SRVOVR_SUMMARY_SPLIT(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SRV_ID", _obj.srv);
            _cmd.ExecuteNonQuery();
        }
        public void Update_Circuit(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@CAS_ID", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@CIRCUIT", _obj.dev1);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_DBMS_Summary_ALL(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_status", _obj.status);
            _cmd.Parameters.AddWithValue("@project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@Folder_Id", _obj.folder_id);
            _cmd.ExecuteNonQuery();
        }
        public string Get_DBMsDoc_No_All(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@project_code", _obj.Project_code);
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.Add("@total", SqlDbType.Int);
            _cmd.Parameters["@total"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@total"].Value.ToString() != "")
                    return _cmd.Parameters["@total"].Value.ToString();
                else
                    return "0";
            }
            catch
            {
                throw;
            }
        }
        public void Delete_TestSheet(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@c_id", _obj.cas_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_AllServiceFolder(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.Project_code);
            _cmd.Parameters.AddWithValue("@Service_id", _obj.Folder_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Insert_UserInbox(string _sp, _clscommunication _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@User_Id", _obj.userid);
            _cmd.Parameters.AddWithValue("@From_Id", _obj.mailid);
            _cmd.Parameters.AddWithValue("@Date_rcvd", _obj.maildate);
            _cmd.Parameters.AddWithValue("@Subject", _obj.subj);
            _cmd.Parameters.AddWithValue("@Message", _obj.message);
            _cmd.Parameters.AddWithValue("@Attachment", _obj.attachment);
            _cmd.Parameters.AddWithValue("@Project", _obj.project_code);
            _cmd.ExecuteNonQuery();
        }
        public void Insert_UserOutbox(string _sp, _clscommunication _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@User_Id", _obj.userid);
            _cmd.Parameters.AddWithValue("@To_Id", _obj.mailid);
            _cmd.Parameters.AddWithValue("@Date_sent", _obj.maildate);
            _cmd.Parameters.AddWithValue("@Subject", _obj.subj);
            _cmd.Parameters.AddWithValue("@Message", _obj.message);
            _cmd.Parameters.AddWithValue("@Attachment", _obj.attachment);
            _cmd.Parameters.AddWithValue("@Project", _obj.project_code);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_UserMessage(string _sp, _clscommunication _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.userid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_Message(string _sp, _clscommunication _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Item_id", _obj.item_id);
            _cmd.Parameters.AddWithValue("@Type", _obj.type);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public string Get_UserName(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.Add("@username", SqlDbType.VarChar, 50);
            _cmd.Parameters["@username"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                return _cmd.Parameters["@username"].Value.ToString();
            }
            catch
            {
                throw;
            }
        }
        public void Inbox_MarkasRead(string _sp, _clscommunication _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Itemid", _obj.item_id);
            _cmd.ExecuteNonQuery();
        }
        public int Get_UnreadInbox(string _sp, _clscommunication _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.userid);
            _cmd.Parameters.Add("@count", SqlDbType.Int);
            _cmd.Parameters["@count"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                return (int)_cmd.Parameters["@count"].Value;
            }
            catch
            {
                throw;
            }
        }
        public DataTable GENERATE_BAREA_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DIV_ID", _obj.build_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable GENERATE_DIV_SUMMARY(string _sp, _database _objdb)
        {
            try
            {
                _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 120;
                _dta = new SqlDataAdapter(_cmd);
                DataTable _dtable = new DataTable();
                _dta.Fill(_dtable);
                return _dtable;
            }
            catch
            {
                throw;
            }
        }
        public DataTable GENERATE_DIV_SUMMARY_SELECT(string _sp, _clscassheet _obj, _database _objdb)
        {
            try
            {
                _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.Parameters.AddWithValue("@bz", _obj.b_zone);
                _cmd.CommandTimeout = 120;
                _dta = new SqlDataAdapter(_cmd);
                DataTable _dtable = new DataTable();
                _dta.Fill(_dtable);
                return _dtable;
            }
            catch
            {
                throw;
            }
        }
        public DataTable GENERATE_DIV_SER_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SRV_ID", _obj.srv);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable GENERATE_PKG_DIV_SUMMARY(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DIV_ID", _obj.build_id);
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public string Get_Folder_Description(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            return _cmd.ExecuteScalar().ToString();
        }
        public DataTable Get_Folder_Details(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Generate_Cassheet_Report(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@c_s_id", _obj.c_s_id);
            _cmd.Parameters.AddWithValue("@b_z", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@cat", _obj.cate);
            _cmd.Parameters.AddWithValue("@f_lvl", _obj.f_level);
            _cmd.Parameters.AddWithValue("@f_from", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@DIV_ID", _obj.build_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Generate_Package_Summary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@DIV_ID", _obj.build_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Get_ProjectInformation(string _sp, _clsproject _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@prj_id", _obj.prj_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public int Get_Default(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.Add("@id", SqlDbType.Int);
            _cmd.Parameters["@id"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@id"].Value.ToString() != null)
                    return (int)_cmd.Parameters["@id"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public int Get_DefaultDMSsrv(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.Add("@id", SqlDbType.Int);
            _cmd.Parameters["@id"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@id"].Value.ToString() != null)
                    return (int)_cmd.Parameters["@id"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public DataTable Load_Dms_Packages(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@srv", _obj.folder_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void FileUploadingNew(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@service", _obj.service_code);
            _cmd.Parameters.AddWithValue("@package", _obj.package_code);
            _cmd.Parameters.AddWithValue("@doctype", _obj.doctype_code);
            _cmd.Parameters.AddWithValue("@doc_title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@uploaded", _obj.uploaded);
            _cmd.Parameters.AddWithValue("@uploaded_date", _obj.uploaded_date);
            _cmd.Parameters.AddWithValue("@file_size", _obj.file_size);
            _cmd.Parameters.AddWithValue("@schid", _obj.schid);
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@type", _obj.type);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@version", _obj.Version);
            _cmd.Parameters.AddWithValue("@Manual_title", _obj.Manual_title);
            _cmd.ExecuteNonQuery();

        }

        public void FileUploading_New(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@service", _obj.service_code);
            _cmd.Parameters.AddWithValue("@package", _obj.package_code);
            _cmd.Parameters.AddWithValue("@doctype", _obj.doctype_code);
            _cmd.Parameters.AddWithValue("@doc_title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@uploaded", _obj.uploaded);
            _cmd.Parameters.AddWithValue("@uploaded_date", _obj.uploaded_date);
            _cmd.Parameters.AddWithValue("@file_size", _obj.file_size);
            _cmd.Parameters.AddWithValue("@schid", _obj.schid);
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@type", _obj.type);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@title", _obj.Manual_title);
            _cmd.Parameters.AddWithValue("@Review", _obj.Review);
            _cmd.Parameters.AddWithValue("@DisplayVersion", _obj.DisplayVersion);
            _cmd.Parameters.AddWithValue("@DocStyleId", _obj.DocStyleId);
            _cmd.Parameters.AddWithValue("@DocStyleChange", _obj.DocStyleChange);
            _cmd.Parameters.AddWithValue("@submit", _obj.submit);
            _cmd.Parameters.AddWithValue("@ref", _obj.reff);
            _cmd.ExecuteNonQuery();

        }
        public void Update_documentdetails(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@doc_title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@DisplayVersion", _obj.DisplayVersion);
            _cmd.Parameters.AddWithValue("@Manual_title", _obj.Manual_title);
            _cmd.Parameters.AddWithValue("@DocStyleId", _obj.DocStyleId);
            _cmd.Parameters.AddWithValue("@DocStyleChange", _obj.DocStyleChange);
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.ExecuteNonQuery();
        }
        public void Delete_DocumentNew(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.Parameters.AddWithValue("@folder_Id", _obj.folder_id);
            _cmd.ExecuteNonQuery();
        }
        public string Get_DocumentTitle(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.Add("@title", SqlDbType.VarChar, 200);
            _cmd.Parameters["@title"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@title"].Value.ToString() != "")
                    return (string)_cmd.Parameters["@title"].Value;
                else
                    return "";
            }
            catch
            {
                throw;
            }
        }
        public void dml_schedule_basket(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SCH_ITM_ID", _obj.schid);
            _cmd.Parameters.AddWithValue("@PRJ_CODE", _obj.project_code);
            _cmd.Parameters.AddWithValue("@USERID", _obj.uid);
            _cmd.Parameters.AddWithValue("@DOCUMENT_TITLE", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@FOLDER_ID", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@FILE_NAME", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@PARTY_ID", _obj.party_id);
            _cmd.Parameters.AddWithValue("@PARTY_NAME", _obj.party_name);
            _cmd.Parameters.AddWithValue("@REF_NO", _obj.reff);
            _cmd.Parameters.AddWithValue("@ACTION", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_ScheduleBasket(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@FOLDER_ID", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@USERID", _obj.uid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Move_Folder(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.Parameters.AddWithValue("@move", _obj.move);
            _cmd.ExecuteNonQuery();
        }
        public void CreateDocSchedule(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@service", _obj.service_code);
            _cmd.Parameters.AddWithValue("@package", _obj.package_code);
            _cmd.Parameters.AddWithValue("@doctype", _obj.doctype_code);
            _cmd.Parameters.AddWithValue("@doc_title", _obj.party_name);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@date_tobeuploaded", _obj.uploaded_date);
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@possition", _obj.possition);
            _cmd.Parameters.AddWithValue("@title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@doc_ref", _obj.reff);
            _cmd.ExecuteNonQuery();
        }
        public void Create_Schedulebskt(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@FOLDER_ID", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@USERID", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public void Delete_DocumentStyle(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DocStyleId", _obj.DocStyleId);
            _cmd.ExecuteNonQuery();
        }
        public int Check_Record_Exits(string _sp, _clsmanufacture _obj, _database _objdb)
        {

            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));

            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.AddWithValue("@name", _obj.man_name);

            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);

            _cmd.Parameters.Add("@id", SqlDbType.Int, 6);

            _cmd.Parameters["@id"].Direction = ParameterDirection.Output;

            try
            {

                _cmd.ExecuteNonQuery();

                if (_cmd.Parameters["@id"].Value.ToString() != "")

                    return Convert.ToInt16(_cmd.Parameters["@id"].Value);

                else

                    return 0;

            }

            catch
            {

                throw;

            }

        }
        public DataTable Load_Document_Submit(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_Document_Submit(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void Insert_ProgressTracking(string _sp, _clsProgressTracking _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Progress_Id", _obj.Progress_id);
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.AddWithValue("@Section1", _obj.Section1);
            _cmd.Parameters.AddWithValue("@Section2", _obj.Section2);
            _cmd.Parameters.AddWithValue("@Section3", _obj.Section3);
            _cmd.Parameters.AddWithValue("@Section4", _obj.Section4);
            _cmd.Parameters.AddWithValue("@Section5", _obj.Section5);
            _cmd.Parameters.AddWithValue("@Section6", _obj.Section6);
            _cmd.Parameters.AddWithValue("@Section7", _obj.Section7);
            _cmd.Parameters.AddWithValue("@Section8", _obj.Section8);
            _cmd.Parameters.AddWithValue("@Section9", _obj.Section9);
            _cmd.Parameters.AddWithValue("@Section10", _obj.Section10);
            _cmd.Parameters.AddWithValue("@DraftIssueDate", _obj.DraftIssuedate);
            _cmd.Parameters.AddWithValue("@Remarks", _obj.Remarks);
            _cmd.Parameters.AddWithValue("@User_id", _obj.Userid);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_AllProgressTracking(string _sp, _clsProgressTracking _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Get_ProgressTrackingDetails(string _sp, _clsProgressTracking _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Progress_id", _obj.Progress_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_DMS_Report_Master(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_Document_direct(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@title", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@doc_title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@doc_ref", _obj.reff);
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void Update_Schedule_direct(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@doc_title", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@title", _obj.title);
            _cmd.Parameters.AddWithValue("@doc_ref", _obj.reff);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void Create_TreeFolderNew(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_description", _obj.Folder_description);
            _cmd.Parameters.AddWithValue("@Folder_code", _obj.Folder_code);
            _cmd.Parameters.AddWithValue("@Folder_type", _obj.Folder_type);
            _cmd.Parameters.AddWithValue("@Folder_possition", _obj.Folder_possition);
            _cmd.Parameters.AddWithValue("@Parent_folder", _obj.Parent_folder);
            _cmd.Parameters.AddWithValue("@Project_code", _obj.Project_code);
            _cmd.Parameters.AddWithValue("@Enabled", _obj.Enabled);
            _cmd.Parameters.AddWithValue("@auto", _obj.auto);
            _cmd.Parameters.AddWithValue("@Userid", _obj.Userid);
            _cmd.ExecuteNonQuery();
        }
        public void Edit_Tree_Folder_New(string _sp, _clstreefolder _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.AddWithValue("@Folder_code", _obj.Folder_code);
            _cmd.Parameters.AddWithValue("@Folder_description", _obj.Folder_description);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public void Update_DR_Details(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_no", _obj.dr_no);
            _cmd.Parameters.AddWithValue("@service", _obj.service);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.details);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public void dml_dr_pdf(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _cmd.Parameters.AddWithValue("@dr_no", _obj.dr_no);
            _cmd.Parameters.AddWithValue("@issue_date", _obj.ddate);
            _cmd.Parameters.AddWithValue("@issue_to", _obj.issued_to);
            _cmd.Parameters.AddWithValue("@service", _obj.service);
            _cmd.Parameters.AddWithValue("@subject", _obj.dr_reviewed);
            _cmd.Parameters.AddWithValue("@created_by", _obj.uid);
            _cmd.Parameters.AddWithValue("@file", _obj.details);
            _cmd.Parameters.AddWithValue("@comment", _obj.desc);
            _cmd.Parameters.AddWithValue("@response", _obj.response);
            _cmd.Parameters.AddWithValue("@status", _obj.dr_status);
            _cmd.Parameters.AddWithValue("@action", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public void Update_ProgressTracking_tbl(string _sp, _clsProgressTracking _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Progress_Id", _obj.Progress_id);
            _cmd.Parameters.AddWithValue("@Folder_id", _obj.Folder_id);
            _cmd.Parameters.AddWithValue("@Value", _obj.Value);
            _cmd.Parameters.AddWithValue("@User_id", _obj.Userid);
            _cmd.Parameters.AddWithValue("@Type", _obj.Type);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_dr_pdf_details(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@id", _obj.dr_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Generate_Bldg_Rpt(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch);
            _cmd.Parameters.AddWithValue("@BZ", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@CAT", _obj.cate);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.Parameters.AddWithValue("@FFROM", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@LOC", _obj.loca);
            _cmd.Parameters.AddWithValue("@Building", _obj.build_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Generate_CASPkg_Rpt(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SRV_ID", _obj.srv);
            _cmd.Parameters.AddWithValue("@BZ", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@CAT", _obj.cate);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.Parameters.AddWithValue("@FFROM", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@LOC", _obj.loca);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_Building_Suammry_ASAO(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@bz", _obj.b_zone);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void dml_dms_library_general(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@itm_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@srv_id", _obj.service_code);
            _cmd.Parameters.AddWithValue("@pkg_id", _obj.schid);
            _cmd.Parameters.AddWithValue("@man_id", _obj.party_id);
            _cmd.Parameters.AddWithValue("@contra_type", _obj.type);
            _cmd.Parameters.AddWithValue("@model", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@file_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@source", _obj.reff);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void addcomment_new(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sec_no", _obj.sec_no);
            _cmd.Parameters.AddWithValue("@page_no", _obj.page_no);
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@com_date", _obj.com_date);
            _cmd.Parameters.AddWithValue("@user_id", _obj.user_id);
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@Image_name", _obj.Image_name);
            _cmd.ExecuteNonQuery();
        }
        public void Editcomment_new(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@user_id", _obj.user_id);
            _cmd.Parameters.AddWithValue("@comm_id", _obj.comm_id);
            _cmd.Parameters.AddWithValue("@Image_name", _obj.Image_name);
            _cmd.ExecuteNonQuery();
        }
        public DataTable load_CommentDetails(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@comm_id", _obj.comm_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void dml_amslocation(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@location_id", _obj.id);
            _cmd.Parameters.AddWithValue("@location_name", _obj.location);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public void dml_amsroom(string _sp, _clsams _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@room_id", _obj.id);
            _cmd.Parameters.AddWithValue("@room_name", _obj.location);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.ExecuteNonQuery();
        }

        public string Get_file(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@id", _obj.Doc_Id);
            _cmd.Parameters.Add("@file", SqlDbType.VarChar, 100);
            _cmd.Parameters["@file"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@file"].Value.ToString();
        }
        public void Update_msinfo(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@msid", _obj.msid);
            _cmd.Parameters.AddWithValue("@sub_date", _obj.sbdate);
            _cmd.Parameters.AddWithValue("@rev_cml", _obj.rev_cml);
            _cmd.Parameters.AddWithValue("@bhc", _obj.status);
            _cmd.Parameters.AddWithValue("@rev_date", _obj.rvdate);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Get_MsInfo(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@reff_no", _obj.reff_no);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_Document_Library_Project(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }

        public DataTable Generate_DocumentStatus_Other(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@Service_id", _obj.srv_id);
            _cmd.Parameters.AddWithValue("@Type", _obj.Type);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public string Get_DocStatus(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.Add("@status", SqlDbType.VarChar, 50);
            _cmd.Parameters["@status"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@status"].Value.ToString();
        }

        public int Get_Document_Library_Count(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Itm_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@folder_id", _obj.folder_id);
            _cmd.Parameters.Add("@count", SqlDbType.Int);
            _cmd.Parameters["@count"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@count"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@count"].Value;
                else
                    return 0;
            }
            catch
            {
                throw;
            }
        }
        public void dml_dms_library_general_new(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@itm_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@srv_id", _obj.service_code);
            _cmd.Parameters.AddWithValue("@pkg_id", _obj.schid);
            _cmd.Parameters.AddWithValue("@man_id", _obj.party_id);
            _cmd.Parameters.AddWithValue("@contra_type", _obj.type);
            _cmd.Parameters.AddWithValue("@model", _obj.doc_title);
            _cmd.Parameters.AddWithValue("@file_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@source", _obj.reff);
            _cmd.Parameters.AddWithValue("@action", _obj.action);
            _cmd.Parameters.AddWithValue("@File_Size", _obj.file_size);
            _cmd.ExecuteNonQuery();
        }
        public void AddToProject_Library(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@itm_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@Folder_Id", _obj.folder_id);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_Comment_Details(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@id", _obj.doc_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Gen_MSSchedule_Graph(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.ExecuteNonQuery();
        }
        public void insert_MS_Schedule_Report(string _sp, _clsMaster _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SYSTEM", _obj.sys_name);
            _cmd.Parameters.AddWithValue("@SERVICE", _obj.ser_name);
            _cmd.Parameters.AddWithValue("@STATUS", _obj.sys_type);
            _cmd.ExecuteNonQuery();
        }
        public bool GetEmailNotify(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@project", _obj.project_code);
            _cmd.Parameters.Add("@notify", SqlDbType.Bit);
            _cmd.Parameters["@notify"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return Convert.ToBoolean(_cmd.Parameters["@notify"].Value);
        }
        public void Insert_User_Prj_Modules(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@prj_id", _obj.mode);
            _cmd.Parameters.AddWithValue("@CMS", _obj.CMS);
            _cmd.Parameters.AddWithValue("@DMS", _obj.DMS);
            _cmd.Parameters.AddWithValue("@TMS", _obj.TMS);
            //_cmd.Parameters.AddWithValue("@CU", _obj.CU);
            //_cmd.Parameters.AddWithValue("@CP", _obj.CP);
            //_cmd.Parameters.AddWithValue("@PM", _obj.PM);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_Buildinglevel_Navigation(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@prj", _obj.project_code);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Generate_CAS_RPT_BLG(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DBNAME", _objdb.Dataname);
            _cmd.Parameters.AddWithValue("@PROJECT", _objdb.project);
            _cmd.Parameters.AddWithValue("@PROJECT_CODE", _objdb.Datapath);
            _cmd.Parameters.AddWithValue("@CAS_ID", _objdb.rpt);
            _cmd.Parameters.AddWithValue("@Div_Id", _objdb.Div);
            _cmd.CommandTimeout = 360;
            _cmd.ExecuteNonQuery();

        }
        public string Get_Facility_Name(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@id", _obj.sch);
            _cmd.Parameters.Add("@name", SqlDbType.VarChar, 100);
            _cmd.Parameters["@name"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@name"].Value.ToString();
        }
        
        public DataTable Load_CMS_Docs_Div(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@reff_no", _obj.reff_no);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@Build_id", _obj.folder);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
           return _dtable;
        }
        public DataTable Generate_Commissioning_Summary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Load_CAS_Details(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@casid", _obj.cas_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Gen_MS_Schedule_Summary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@build_id", _obj.build_id);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_MS_Summary_ALL_Div(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_status", _obj.status);
            _cmd.Parameters.AddWithValue("@build_id", _obj.schid);
            _cmd.ExecuteNonQuery();
        }
        public void Generate_MS_Summary_Div(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@srv_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@doc_status", _obj.status);
            _cmd.Parameters.AddWithValue("@build_id", _obj.schid);
            _cmd.ExecuteNonQuery();
        }
        public int Get_Position_Div(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Sys_Id", _obj.sys);
            _cmd.Parameters.AddWithValue("@Div_id", _obj.build_id);
            _cmd.Parameters.Add("@Position", SqlDbType.Int);
            _cmd.Parameters["@Position"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Position"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@Position"].Value;
                else
                    return 1;
            }
            catch
            {
                throw;
            }
        }
        public int Get_Get_MsDoc_No_ALL_Div(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Srv_Id", _obj.srv);
            _cmd.Parameters.AddWithValue("@Build_id", _obj.build_id);
            _cmd.Parameters.Add("@Count", SqlDbType.Int);
            _cmd.Parameters["@Count"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Count"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@Count"].Value;
                else
                    return 1;
            }
            catch
            {
                throw;
            }
        }
        public void Manage_MsFolder_Div(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Ms_Sys_Id", _obj.mssys_id);
            _cmd.Parameters.AddWithValue("@Ms_Sys_Name", _obj.mssys_name);
            _cmd.Parameters.AddWithValue("@Ser_Id", _obj.srv_id);
            _cmd.Parameters.AddWithValue("@Pos", _obj.pos);
            _cmd.Parameters.AddWithValue("@Haram", _obj.Build1);
            _cmd.Parameters.AddWithValue("@Service", _obj.Build2);
            _cmd.Parameters.AddWithValue("@Cuc", _obj.Build3);
            _cmd.Parameters.AddWithValue("@Action", _obj.action);
            _cmd.ExecuteNonQuery();
        }
        public string Get_Buiding_Permission(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _cmd.Parameters.AddWithValue("@type", _obj.mode);
            _cmd.Parameters.Add("@permission", SqlDbType.VarChar, 10);
            _cmd.Parameters["@permission"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                return _cmd.Parameters["@permission"].Value.ToString();
            }
            catch
            {
                throw;
            }
        }
        public void Insert_User_Log_Report(string _sp, _clslog _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@User_Id", _obj.uid);
            _cmd.Parameters.AddWithValue("@Ip_Address", _obj.ipaddr);
            _cmd.Parameters.AddWithValue("@Country", _obj.Country);
            _cmd.Parameters.AddWithValue("@Region", _obj.Region);
            _cmd.Parameters.AddWithValue("@City", _obj.location);
            _cmd.Parameters.AddWithValue("@Login_Time", _obj.login);
            _cmd.ExecuteNonQuery();
        }
        public int Get_NoofCas_Bldng(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Srv_Id", _obj.srv);
            _cmd.Parameters.AddWithValue("@BLDG_ID", _obj.build_id);
            _cmd.Parameters.Add("@Count", SqlDbType.Int);
            _cmd.Parameters["@Count"].Direction = ParameterDirection.Output;
            try
            {
                _cmd.ExecuteNonQuery();
                if (_cmd.Parameters["@Count"].Value.ToString() != "")
                    return (int)_cmd.Parameters["@Count"].Value;
                else
                    return 1;
            }
            catch
            {
                throw;
            }
        }
        public DataSet load_dataset(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Mode", _obj.mode);
            _dta = new SqlDataAdapter(_cmd);
            DataSet _dtable = new DataSet();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public DataTable Get_User_Log(_clslog _obj, string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@LoggedInDate", _obj.login);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_CMS_Document(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.Doc_Id);
            _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@upload_date", _obj.upload_date);
            _cmd.Parameters.AddWithValue("@issue_date", _obj.issue_date);
            _cmd.Parameters.AddWithValue("@revision", Convert.ToInt32(_obj.revision));
            _cmd.Parameters.AddWithValue("@doc_status", _obj.doc_status);
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            //_cmd.Parameters.AddWithValue("@CMS_file", _obj.CMS_file);
            _cmd.Parameters.AddWithValue("@file_name", _obj.file_name);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@CarryOverComm", _obj.carry_comm);
            _cmd.ExecuteNonQuery();
        }
        public void SO_PhotoImage(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Id", _obj.so_itm_id);
            _cmd.Parameters.AddWithValue("@Photo", _obj.photo);
            _cmd.Parameters.AddWithValue("@PhotoImage", _obj.PhotoImage);
            _cmd.ExecuteNonQuery();
        }
        public void SaveTestPictureDB(string _sp, _clsuser _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Id", _obj.mode);
            _cmd.Parameters.AddWithValue("@DisplayName", _obj.uname);
            _cmd.Parameters.AddWithValue("@Picture", _obj.UserImage);
            _cmd.ExecuteNonQuery();
        }
        //JD Changes
        public void Update_CMS_Doc_Inline(string _sp, _clscmsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.Doc_Id);
            _cmd.Parameters.AddWithValue("@field_value", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@field_name", _obj.file_name);
            _cmd.ExecuteNonQuery();
        }
        public void Save_CMS_Comments(string _sp, _clscmscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.ExecuteNonQuery();
        }

        public DataTable Load_CP_Comments(string _sp, _clscmscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Delete_CMS_Comment(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.comm_id);
            _cmd.ExecuteNonQuery();
        }
        public void Clear_Comment_Basket(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.ExecuteNonQuery();
        }


        //JJ DR
        public string DR_Saved(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _cmd.Parameters.AddWithValue("@dr_reviewed", _obj.dr_reviewed);
            _cmd.Parameters.AddWithValue("@issued_date", _obj.issued_date);
            _cmd.Parameters.AddWithValue("@issued_to", _obj.issued_to);
            _cmd.Parameters.AddWithValue("@project_code", _obj.project_code);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.Parameters.AddWithValue("@service", _obj.service);
            _cmd.Parameters.AddWithValue("@LinkTo", _obj.Notes);

            _cmd.Parameters.Add("@dr_no", SqlDbType.VarChar, 15);

            _cmd.Parameters["@dr_no"].Direction = ParameterDirection.Output;
            _cmd.ExecuteNonQuery();
            return _cmd.Parameters["@dr_no"].Value.ToString();
        }

        public void DR_Saved_Details(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_itm_id", _obj.dr_itm_id);
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _cmd.Parameters.AddWithValue("@details", _obj.details);
            _cmd.Parameters.AddWithValue("@desc", _obj.desc);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.Parameters.AddWithValue("@LinkTo", _obj.Notes);
            _cmd.Parameters.AddWithValue("@AttchDocument", _obj.AttachDocument);
            _cmd.Parameters.AddWithValue("@Position", _obj.Position);
            _cmd.ExecuteNonQuery();
        }

        public void Update_Comment_Basket(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.comm_id);
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@page", _obj.page_no);
            _cmd.Parameters.AddWithValue("@section", _obj.sec_no);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Get_CMS_Settings(string _sp, _clscmssettings _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Module", _obj.module);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }

        public void Update_CMS_Settings(string _sp, _clscmssettings _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@Module", _obj.module);
            _cmd.Parameters.AddWithValue("@RevisionStyle", _obj.revision_style);
            _cmd.Parameters.AddWithValue("@AllowDR", _obj.allowDR);
            _cmd.Parameters.AddWithValue("@AllowComments", _obj.allowcomments);
            _cmd.Parameters.AddWithValue("@ResponsePeriod", _obj.responseperiod);
            _cmd.ExecuteNonQuery();
        }

        public void Update_CP_Comment(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.comm_id);
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@page", _obj.page_no);
            _cmd.Parameters.AddWithValue("@section", _obj.sec_no);
            _cmd.ExecuteNonQuery();
        }


        public void UpdateCPCommentStatus(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.comm_id);
            _cmd.Parameters.AddWithValue("@status", Convert.ToBoolean(_obj.status));
            _cmd.ExecuteNonQuery();
        }

        public void Update_Issue_Comment(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.comm_id);
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@page", _obj.page_no);
            _cmd.Parameters.AddWithValue("@section", _obj.sec_no);
            _cmd.ExecuteNonQuery();
        }
        public void Document_Review_Details_New(string _sp, _clsdocreview _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@dr_itm_id", _obj.dr_itm_id);
            _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
            _cmd.Parameters.AddWithValue("@details", _obj.details);
            _cmd.Parameters.AddWithValue("@response", _obj.response);
            _cmd.Parameters.AddWithValue("@desc", _obj.desc);
            _cmd.Parameters.AddWithValue("@date", _obj.issued_date);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.Parameters.AddWithValue("@mode", _obj.mode);
            _cmd.Parameters.AddWithValue("@AttchDocument", _obj.AttachDocument);
            _cmd.Parameters.AddWithValue("@Position", _obj.Position);
            _cmd.ExecuteNonQuery();
        }
        public void Delete_DMS_Document_New(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Generate_CAS_PKG_Summary(string _sp,_clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void InsertCommentBasket(string _sp, _clscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@comment", _obj.comment);
            _cmd.Parameters.AddWithValue("@page", _obj.page_no);
            _cmd.Parameters.AddWithValue("@sec", _obj.sec_no);
            _cmd.Parameters.AddWithValue("@uid", _obj.user_id);
            _cmd.Parameters.AddWithValue("@prj_code", _obj.prj_code);
            _cmd.Parameters.AddWithValue("@module", _obj.module);
            _cmd.Parameters.AddWithValue("@type", _obj.type);
            _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
            _cmd.Parameters.AddWithValue("@com_id", _obj.comm_id);
            _cmd.ExecuteNonQuery();
        }
        public DataTable Load_CP_Comments_All(string _sp, _clscmscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@userid", _obj.uid);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void Update_Comment_Response(string _sp, _clscmscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@com_id", _obj.com_id);
            _cmd.Parameters.AddWithValue("@response", _obj.resp);
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public void Issue_Unsaved_Comments(string _sp, _clscmscomment _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@uid", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        ////----------------------Jenne 09012016------------------------

        //public DataTable Load_MS_Register(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public void Update_MS_Register_Inline(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@system_id", _obj.Doc_Id);
        //    _cmd.Parameters.AddWithValue("@ms_comments", _obj.doc_name);
        //    _cmd.ExecuteNonQuery();
        //}

        //public DataTable Load_MS_File_Tree(string _sp, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public DataTable Load_MS_Services(string _sp, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public void AddMSTreeNode(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@ServiceID", _obj.module_name);
        //    _cmd.Parameters.AddWithValue("@NodeID", _obj.ms_nodeid);
        //    _cmd.Parameters.AddWithValue("@Position", _obj.pos);
        //    _cmd.Parameters.AddWithValue("@NodeText", _obj.mssys_name);
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.ExecuteNonQuery();
        //}
        //public void RenameMSTreeNode(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@ServiceID", _obj.srv_id);
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _cmd.Parameters.AddWithValue("@NodeID", _obj.file_name);
        //    _cmd.Parameters.AddWithValue("@NodeText", _obj.mssys_name);
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.ExecuteNonQuery();
        //}
        //public bool DeleteMSTreeNode(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@ServiceID", _obj.srv_id);
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _cmd.Parameters.AddWithValue("@NodeID", _obj.ms_nodeid);
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.Parameters.Add("@HasMS", SqlDbType.Bit);
        //    _cmd.Parameters["@HasMS"].Direction = ParameterDirection.Output;
        //    _cmd.ExecuteNonQuery();
        //    return Convert.ToBoolean(_cmd.Parameters["@HasMS"].Value.ToString());
        //}
        //public void ShiftMSTreeNode(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@ServiceID", _obj.srv_id);
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _cmd.Parameters.AddWithValue("@Position", _obj.pos);
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.ExecuteNonQuery();
        //}
        //public void SaveMSFileTree(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.ExecuteNonQuery();
        //}

        //public DataTable LoadMSFileTreeNav(string _sp, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public DataTable Load_MS_Documents(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@Project_code", _obj.project_code);
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public void Update_MS_Register(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _cmd.Parameters.AddWithValue("@SubDate", _obj.sub_date);
        //    _cmd.Parameters.AddWithValue("@TranNo", _obj.trans_no);
        //    _cmd.Parameters.AddWithValue("@Contractor", _obj.company);
        //    _cmd.ExecuteNonQuery();
        //}

        //public void Update_MS_Document(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@doc_id", _obj.Doc_Id);
        //    _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
        //    _cmd.Parameters.AddWithValue("@upload_date", _obj.upload_date);
        //    _cmd.Parameters.AddWithValue("@issue_date", _obj.issue_date);
        //    _cmd.Parameters.AddWithValue("@revision", Convert.ToInt32(_obj.revision));
        //    _cmd.Parameters.AddWithValue("@doc_status", _obj.doc_status);
        //    _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
        //    _cmd.Parameters.AddWithValue("@file_name", _obj.file_name);
        //    _cmd.Parameters.AddWithValue("@uid", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@CarryOverComm", _obj.carry_comm);
        //    _cmd.Parameters.AddWithValue("@ServiceID", _obj.srv_id);
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _cmd.ExecuteNonQuery();
        //}

        //public DataTable Load_MS_Comments(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@userid", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.folder);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public void Issue_MS_Comments(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@uid", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _cmd.Parameters.AddWithValue("@doc_id", _obj.Doc_Id);
        //    _cmd.ExecuteNonQuery();
        //}

        //public DataTable Get_Review_Document(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@module_name", _obj.module_name);
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _cmd.Parameters.AddWithValue("@DocID", _obj.Doc_Id);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public void ClearFileTreeBasket(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@Module", _obj.module_name);
        //    _cmd.ExecuteNonQuery();
        //}

        //public DataTable LoadMSStatusProgress(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@ServiceID", _obj.srv_id);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public void Update_Comment(string _sp, _clscomment _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@com_id", _obj.comm_id);
        //    _cmd.Parameters.AddWithValue("@comment", _obj.comment);
        //    _cmd.Parameters.AddWithValue("@page", _obj.page_no);
        //    _cmd.Parameters.AddWithValue("@section", _obj.sec_no);
        //    _cmd.ExecuteNonQuery();
        //}

        //public void Update_MM_Document(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@doc_id", _obj.Doc_Id);
        //    _cmd.Parameters.AddWithValue("@doc_name", _obj.doc_name);
        //    _cmd.Parameters.AddWithValue("@upload_date", _obj.upload_date);
        //    _cmd.Parameters.AddWithValue("@issue_date", _obj.issue_date);
        //    _cmd.Parameters.AddWithValue("@revision", Convert.ToInt32(_obj.revision));
        //    _cmd.Parameters.AddWithValue("@doc_status", _obj.doc_status);
        //    _cmd.Parameters.AddWithValue("@dr_id", _obj.dr_id);
        //    _cmd.Parameters.AddWithValue("@file_name", _obj.file_name);
        //    _cmd.Parameters.AddWithValue("@uid", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@CarryOverComm", _obj.carry_comm);
        //    _cmd.Parameters.AddWithValue("@folderID", _obj.folder);
        //    _cmd.Parameters.AddWithValue("@moduleID", _obj.module);
        //    _cmd.ExecuteNonQuery();
        //}

        //public DataTable Load_MM_Log(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@reff_no", _obj.reff_no);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public DataTable Load_MM_Comments(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@userid", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@FolderID", _obj.folder);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}

        //public void Issue_MM_Comments(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@uid", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@FolderID", _obj.mssys_id);
        //    _cmd.Parameters.AddWithValue("@doc_id", _obj.Doc_Id);
        //    _cmd.ExecuteNonQuery();
        //}
        //public DataTable LoadMMFileTreeNav(string _sp, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}
        //public string DeleteCMSDocument(string _sp, _clsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@doc_id", _obj.doc_id);
        //    _cmd.Parameters.Add("@DeleteFile", SqlDbType.VarChar, 50);
        //    _cmd.Parameters["@DeleteFile"].Direction = ParameterDirection.Output;
        //    _cmd.ExecuteNonQuery();
        //    return _cmd.Parameters["@DeleteFile"].Value.ToString();
        //}
        //public DataTable DeleteMSInfo(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@SystemID", _obj.mssys_id);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}
        //public void AddMMTreeNode(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@NodeID", _obj.ms_nodeid);
        //    _cmd.Parameters.AddWithValue("@Position", _obj.pos);
        //    _cmd.Parameters.AddWithValue("@NodeText", _obj.mssys_name);
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.ExecuteNonQuery();
        //}
        //public void RenameMMTreeNode(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@NodeID", _obj.ms_nodeid);
        //    _cmd.Parameters.AddWithValue("@NodeText", _obj.file_name);
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.ExecuteNonQuery();
        //}
        //public void DeleteMMTreeNode(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@NodeID", _obj.ms_nodeid);
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.ExecuteNonQuery();
        //}
        //public void ShiftMMTreeNode(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@NodeID", _obj.ms_nodeid); ;
        //    _cmd.Parameters.AddWithValue("@Position", _obj.pos);
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _cmd.ExecuteNonQuery();
        //}
        //public DataTable SaveMMFileTree(string _sp, _clscmsdocument _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@UserID", _obj.uid);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}
        ////-----------------------------------------------------------------------

        //public void Update_DR_CommentResponse(string _sp, _clsdocreview _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@dr_itm_id", _obj.dr_itm_id);
        //    _cmd.Parameters.AddWithValue("@comment", _obj.Comment);
        //    _cmd.Parameters.AddWithValue("@response", _obj.response);
        //    _cmd.ExecuteNonQuery();
        //}
        //public void Update_DR_Details_New(string _sp, _clsdocreview _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@dr_itm_id", _obj.dr_itm_id);
        //    _cmd.Parameters.AddWithValue("@details", _obj.details);
        //    _cmd.Parameters.AddWithValue("@desc", _obj.desc);
        //    _cmd.Parameters.AddWithValue("@comment", _obj.Comment);
        //    _cmd.Parameters.AddWithValue("@response", _obj.response);
        //    _cmd.Parameters.AddWithValue("@Status", _obj.dr_status);
        //    _cmd.Parameters.AddWithValue("@AttchDocument", _obj.AttachDocument);
        //    _cmd.ExecuteNonQuery();
        //}
        //public void Update_SO_Details_New(string _sp, _clsSO _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@so_itm_id", _obj.so_itm_id);
        //    _cmd.Parameters.AddWithValue("@details", _obj.details);
        //    _cmd.Parameters.AddWithValue("@response", _obj.response);
        //    _cmd.Parameters.AddWithValue("@cmlresp", _obj.comments);
        //    _cmd.Parameters.AddWithValue("@uid", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@Status", _obj.status);
        //    _cmd.Parameters.AddWithValue("@AttchDocument", _obj.photo);
        //    _cmd.ExecuteNonQuery();
        //}
        //public string SO_Saved(string _sp, _clsSO _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@So_id", _obj.so_id);
        //    _cmd.Parameters.AddWithValue("@Subjects", _obj.sub);
        //    _cmd.Parameters.AddWithValue("@issued_date", _obj.issued_date);
        //    _cmd.Parameters.AddWithValue("@issued_to", _obj.issued_to);
        //    _cmd.Parameters.AddWithValue("@project_code", _obj.project_code);
        //    _cmd.Parameters.AddWithValue("@uid", _obj.uid);
        //    _cmd.Parameters.AddWithValue("@mode", _obj.mode);
        //    _cmd.Parameters.AddWithValue("@service", _obj.package);
        //    _cmd.Parameters.AddWithValue("@LinkTo", _obj.doc_name);
        //    _cmd.Parameters.Add("@So_no", SqlDbType.VarChar, 15);
        //    _cmd.Parameters["@So_no"].Direction = ParameterDirection.Output;
        //    _cmd.ExecuteNonQuery();
        //    return _cmd.Parameters["@So_no"].Value.ToString();
        //}
        //public void SO_Saved_Details(string _sp, _clsSO _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@So_itm_id", _obj.so_itm_id);
        //    _cmd.Parameters.AddWithValue("@So_id", _obj.so_id);
        //    _cmd.Parameters.AddWithValue("@details", _obj.details);
        //    _cmd.Parameters.AddWithValue("@desc", _obj.comments);
        //    _cmd.Parameters.AddWithValue("@mode", _obj.mode);
        //    _cmd.Parameters.AddWithValue("@LinkTo", _obj.action);
        //    _cmd.Parameters.AddWithValue("@AttchDocument", _obj.photo);
        //    _cmd.Parameters.AddWithValue("@Position", _obj.Position);
        //    _cmd.ExecuteNonQuery();
        //}
        //public DataTable Load_DR_StatusGraph(string _sp, _clsdocreview _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@Service", _obj.service);
        //    _cmd.Parameters.AddWithValue("@issued_to", _obj.issued_to);
        //    _cmd.Parameters.AddWithValue("@dr_reviewed", _obj.dr_reviewed);
        //    _cmd.Parameters.AddWithValue("@drStatus", _obj.Notes);
        //    _cmd.Parameters.AddWithValue("@Due", _obj.desc);
        //    _dta = new SqlDataAdapter(_cmd);
        //    DataTable _dtable = new DataTable();
        //    _dta.Fill(_dtable);
        //    return _dtable;
        //}
        public void dml_SO_pdf(string _sp, _clsSO _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@So_id", _obj.so_id);
            _cmd.Parameters.AddWithValue("@SO_no", _obj.so_no);
            _cmd.Parameters.AddWithValue("@issue_date", _obj.cdate);
            _cmd.Parameters.AddWithValue("@issue_to", _obj.issued_to);
            _cmd.Parameters.AddWithValue("@service", _obj.package);
            _cmd.Parameters.AddWithValue("@subject", _obj.doc_name);
            _cmd.Parameters.AddWithValue("@created_by", _obj.issued_by);
            _cmd.Parameters.AddWithValue("@file", _obj.details);
            _cmd.Parameters.AddWithValue("@comment", _obj.comments);
            _cmd.Parameters.AddWithValue("@response", _obj.response);
            _cmd.Parameters.AddWithValue("@status", _obj.status);
            _cmd.Parameters.AddWithValue("@action", _obj.mode);
            _cmd.ExecuteNonQuery();
        }
        public DataTable LoadDataTable(string _sp, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }       
        public void Generate_CAS_Graph_Summary(string _sp, _clscassheet _obj, _database _objdb)   
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch);
            _cmd.Parameters.AddWithValue("@BZ", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@CATE", _obj.cate);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.Parameters.AddWithValue("@F_FROM", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@LOC", _obj.loca);
            _cmd.Parameters.AddWithValue("@BUILDING", _obj.build_id);
            _cmd.Parameters.AddWithValue("@TYPE", _obj.mode);
            _cmd.ExecuteNonQuery();

        }
        public DataSet Generate_ProgressComparison_Graph(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));    
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@sch_id", _obj.sch);
            _cmd.Parameters.AddWithValue("@BZ", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@CAT", _obj.cate);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.Parameters.AddWithValue("@F_FROM", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@LOC", _obj.loca);
            _cmd.Parameters.AddWithValue("@PcdRefdate", _obj.date);
            _cmd.Parameters.AddWithValue("@BUILDING", _obj.build_id);
            _dta = new SqlDataAdapter(_cmd);
            DataSet _ds = new DataSet();
            _dta.Fill(_ds);
            return _ds;
        }
        public void GENERATE_PROJECT_SUMMARY_PCD(string _sp, _clscassheet _obj, _database _objdb)   
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PcdRefdate", _obj.date);
            _cmd.Parameters.AddWithValue("@BZONE", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.ExecuteNonQuery();
        }
        //public void Get_Executive_Summary_pcd(string _sp, _clscassheet _obj, _database _objdb)
        //{
        //    _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
        //    _cmd.CommandType = CommandType.StoredProcedure;
        //    _cmd.Parameters.AddWithValue("@DATE_FRM", _obj.dtastart);
        //    _cmd.Parameters.AddWithValue("@DATE_TO", _obj.dtpstart);
        //    _cmd.Parameters.AddWithValue("@TYPE", _obj.mode);
        //    _cmd.Parameters.AddWithValue("@SERVICE_TYPE", _obj.cate);
        //    _cmd.ExecuteNonQuery();

        //}
        public void Get_Total_Executive_Summary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DATE_FRM", _obj.dtastart);
            _cmd.Parameters.AddWithValue("@DATE_TO", _obj.dtpstart);
            _cmd.Parameters.AddWithValue("@TYPE", _obj.mode);
            _cmd.Parameters.AddWithValue("@SERVICE_TYPE", _obj.cate);
            _cmd.ExecuteNonQuery();

        }
        //Dashboard
        public DataSet Get_Total_Executive_Summary_Dashboard(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@DATE_FRM", _obj.dtastart);
            _cmd.Parameters.AddWithValue("@DATE_TO", _obj.dtpstart);
            _cmd.Parameters.AddWithValue("@TYPE", _obj.mode);
            _cmd.Parameters.AddWithValue("@SERVICE_TYPE", _obj.cate);
            _dta = new SqlDataAdapter(_cmd);
            DataSet ds = new DataSet();
            _dta.Fill(ds);
            return ds;
        }
       

        public DataSet GenerateDashboardSummary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@PcdRefdate", _obj.date);
            _cmd.Parameters.AddWithValue("@BZONE", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _dta = new SqlDataAdapter(_cmd);
            DataSet ds = new DataSet();
            _dta.Fill(ds);
            return ds;
        }
        public DataSet GeneratePlannedServiceSummary(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName))
            {
                CommandType = CommandType.StoredProcedure
            };
            _cmd.Parameters.AddWithValue("@SRV_ID", _obj.srv);
            _cmd.Parameters.AddWithValue("@PcdRefdate", _obj.date);
            _cmd.Parameters.AddWithValue("@BZ", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.Parameters.Add("@OVERALL", SqlDbType.Int);
            _cmd.Parameters["@OVERALL"].Direction = ParameterDirection.Output;
            _cmd.Parameters.Add("@P_OVERALL", SqlDbType.Int);
            _cmd.Parameters["@P_OVERALL"].Direction = ParameterDirection.Output;
            _dta = new SqlDataAdapter(_cmd);
            DataSet ds = new DataSet();
            _dta.Fill(ds);
            return ds;
        }
        public DataTable Generate_CAS_Graph_Summary1(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@SCH_ID", _obj.sch);
            _cmd.Parameters.AddWithValue("@BZ", _obj.b_zone);
            _cmd.Parameters.AddWithValue("@CATE", _obj.cate);
            _cmd.Parameters.AddWithValue("@FLVL", _obj.f_level);
            _cmd.Parameters.AddWithValue("@F_FROM", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@LOC", _obj.loca);
            _cmd.Parameters.AddWithValue("@BUILDING", _obj.build_id);
            _cmd.Parameters.AddWithValue("@TYPE", _obj.mode);
            _dta = new SqlDataAdapter(_cmd);
            DataTable _dtable = new DataTable();
            _dta.Fill(_dtable);
            return _dtable;
        }
        public void SaveCableLog(string _sp, _clscassheet _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_id", _obj.cas_id);
            _cmd.Parameters.AddWithValue("@cable_reference", _obj.reff);
            _cmd.Parameters.AddWithValue("@panel_reference", _obj.panel_ref);
            _cmd.Parameters.AddWithValue("@fed_from", _obj.fed_from);
            _cmd.Parameters.AddWithValue("@power_to", _obj.p_power_to);
            _cmd.Parameters.AddWithValue("@document_name", _obj.p10);
            _cmd.Parameters.AddWithValue("@created_by", _obj.uid);
            _cmd.ExecuteNonQuery();
        }
        public void DeleteDocuments(string _sp, _clsdocument _obj, _database _objdb)
        {
            _cmd = new SqlCommand(_sp, _objcon.con_open(_objdb.DBName));
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@doc_ids", _obj.doc_name);
            _cmd.ExecuteNonQuery();
        }        
    }
}
