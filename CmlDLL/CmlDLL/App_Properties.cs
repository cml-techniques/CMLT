using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App_Properties
{
    public class _clsuser
    {
        string _uid;
        string _pwd;
        string _uname;
        string _user_group;
        bool _CMS;
        bool _DMS;
        bool _TMS;
        bool _CU;
        bool _CP;
        bool _PM;
        int _mode;
        string _project_code;
        string _service;
        string _access;
        string _permission;
        string _company;
        byte[] _userImage;

        public byte[] UserImage
        {
            get { return _userImage; }
            set { _userImage = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        public string uname
        {
            get { return _uname; }
            set { _uname = value; }
        }
        public string user_group
        {
            get { return _user_group; }
            set { _user_group = value; }
        }
        public bool CMS
        {
            get { return _CMS; }
            set { _CMS = value; }
        }
        public bool DMS
        {
            get { return _DMS; }
            set { _DMS = value; }
        }
        public bool TMS
        {
            get { return _TMS; }
            set { _TMS = value; }
        }
        public bool CU
        {
            get { return _CU; }
            set { _CU = value; }
        }
        public bool CP
        {
            get { return _CP; }
            set { _CP = value; }
        }
        public bool PM
        {
            get { return _PM; }
            set { _PM = value; }
        }
        public string project_code
        {
            get { return _project_code; }
            set { _project_code = value; }
        }
        public string service
        {
            get { return _service; }
            set { _service = value; }
        }
        public string access
        {
            get { return _access; }
            set { _access = value; }
        }
        public string permission
        {
            get { return _permission; }
            set { _permission = value; }
        }
        public string company
        {
            get { return _company; }
            set { _company = value; }
        }
        bool _notification;
        public bool notification
        {
            get { return _notification; }
            set { _notification = value; }
        }

    }
    public class _clsdocument
    {
        int _service_code;
        int _package_code;
        int _doctype_code;
        string _doc_title;
        string _doc_name;
        Boolean _uploaded;
        DateTime _uploaded_date;
        string _file_size;
        int _schid;
        int _folder_id;
        string _project_code;
        string _move;
        int _doc_id;
        int _possition;
        string _status;
        string _type;
        bool _enabled;
        string _uid;
        public int service_code
        {
            get { return _service_code; }
            set { _service_code = value; }
        }
        public int package_code
        {
            get { return _package_code; }
            set { _package_code = value; }
        }
        public int doctype_code
        {
            get { return _doctype_code; }
            set { _doctype_code = value; }
        }
        public string doc_title
        {
            get { return _doc_title; }
            set { _doc_title = value; }
        }
        public string doc_name
        {
            get { return _doc_name; }
            set { _doc_name = value; }
        }
        public Boolean uploaded
        {
            get { return _uploaded; }
            set { _uploaded = value; }
        }
        public DateTime uploaded_date
        {
            get { return _uploaded_date; }
            set { _uploaded_date = value; }
        }
        public string file_size
        {
            get { return _file_size; }
            set { _file_size = value; }
        }
        public int schid
        {
            get { return _schid; }
            set { _schid = value; }
        }
        public int folder_id
        {
            get { return _folder_id; }
            set { _folder_id = value; }
        }
        public string project_code
        {
            get { return _project_code; }
            set { _project_code = value; }
        }
        public string move
        {
            get { return _move; }
            set { _move = value; }
        }
        public int doc_id
        {
            get { return _doc_id; }
            set { _doc_id = value; }
        }
        public int possition
        {
            get { return _possition; }
            set { _possition = value; }
        }
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string type
        {
            get { return _type ; }
            set { _type  = value; }
        }
        public bool enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
                
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        byte[] _logo;
        public byte[] logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        string _version;
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
        string _Mtitle;
        public string Manual_title
        {
            get { return _Mtitle; }
            set { _Mtitle = value; }
        }
        bool _review;
        string _displayVersion;
        int _docStyleId;
        bool _docStyleChange;

        public bool Review
        {
            get { return _review; }
            set { _review = value; }
        }
        
        public string DisplayVersion
        {
            get { return _displayVersion; }
            set { _displayVersion = value; }
        }


        public int DocStyleId
        {
            get { return _docStyleId; }
            set { _docStyleId = value; }
        }


        public bool DocStyleChange
        {
            get { return _docStyleChange; }
            set { _docStyleChange = value; }
        }
        int _party_id;
        public int party_id
        {
            get { return _party_id; }
            set { _party_id = value; }
        }
        int _action;
        public int action
        {
            get { return _action; }
            set { _action = value; }
        }
        string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set { _party_name = value; }
        }
        bool _submit;
        public bool submit
        {
            get { return _submit; }
            set { _submit = value; }
        }
        string _reff;
        public string reff
        {
            get { return _reff; }
            set { _reff = value; }
        }
        string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
    public class _clsschedule
    {
        int _service_code;
        int _package_code;
        int _doctype_code;
        string _doc_title;
        string _doc_name;
        DateTime _uploaded_date;
        public int service_code
        {
            get { return _service_code; }
            set { _service_code = value; }
        }
        public int package_code
        {
            get { return _package_code; }
            set { _package_code = value; }
        }
        public int doctype_code
        {
            get { return _doctype_code; }
            set { _doctype_code = value; }
        }
        public string doc_title
        {
            get { return _doc_title; }
            set { _doc_title = value; }
        }
        public string doc_name
        {
            get { return _doc_name; }
            set { _doc_name = value; }
        }
        public DateTime uploaded_date
        {
            get { return _uploaded_date; }
            set { _uploaded_date = value; }
        }
    }
    public class _clscomment
    {
        int _comm_id;
        string _sec_no;
        string _page_no;
        string _comment;
        DateTime _com_date;
        string _user_id;
        string _docname;
        string _status;
        string _resp;
        int _doc_id;
        string _prj_code;
        string _module;
        int _type;
        public int comm_id
        {
            get { return _comm_id; }
            set { _comm_id = value; }
        }
        public string sec_no
        {
            get { return _sec_no; }
            set { _sec_no = value; }
        }
        public string page_no
        {
            get { return _page_no; }
            set { _page_no = value; }
        }
        public string comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public DateTime com_date
        {
            get { return _com_date; }
            set { _com_date = value; }
        }
        public string user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        public string docname
        {
            get { return _docname; }
            set { _docname = value; }
        }
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string resp
        {
            get { return _resp; }
            set { _resp = value; }
        }
        public int doc_id
        {
            get { return _doc_id; }
            set { _doc_id = value; }
        }
        public string prj_code
        {
            get { return _prj_code; }
            set { _prj_code = value; }
        }
        public string module
        {
            get { return _module; }
            set { _module = value; }
        }
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        string image_name;

        public string Image_name
        {
            get { return image_name; }
            set { image_name = value; }
        }
    }
    public class _clsproject
    {
        string _prjcode;
        string _prjname;
        string _company;
        string _description;
        string _user;
        bool _dms;
        bool _cms;
        bool _ams;
        bool _sns;
        bool _tis;
        int _mode;
        int _com_id;
        int _action;
        bool _status;
        string _comcd;
        public string prjcode
        {
            get { return _prjcode; }
            set { _prjcode = value; }
        }
        public string prjname
        {
            get { return _prjname; }
            set { _prjname = value; }
        }
        public string company
        {
            get { return _company; }
            set { _company = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }
        public bool dms
        {
            get { return _dms; }
            set { _dms = value; }
        }
        public bool cms
        {
            get { return _cms; }
            set { _cms = value; }
        }
        public bool tms
        {
            get { return _ams; }
            set { _ams = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public bool sns
        {
            get { return _sns; }
            set { _sns = value; }
        }
        public int com_id
        {
            get { return _com_id; }
            set { _com_id = value; }
        }
        public int action
        {
            get { return _action; }
            set { _action = value; }
        }
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string comcd
        {
            get { return _comcd; }
            set { _comcd = value; }
        }
        byte[] _logo;
        public byte[] logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        public bool tis
        {
            get { return _tis; }
            set { _tis = value; }
        }
        string _loc;
        public string loc
        {
            get { return _loc; }
            set { _loc = value; }
        }
        string _module;
        public string module
        {
            get { return _module; }
            set { _module = value; }
        }
        int _prj_id;
        public int prj_id
        {
            get { return _prj_id; }
            set { _prj_id = value; }
        }
    }
    public class _clsManageTree
    {
        string _desciption;
        string _service;
        int _possition;
        string _code;
        int _mode;
        public string desciption
        {
            get { return _desciption; }
            set { _desciption = value; }
        }
        public string service
        {
            get { return _service; }
            set { _service = value; }
        }
        public int possition
        {
            get { return _possition; }
            set { _possition = value; }
        }
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

    }
    public class _clstreefolder
    {
        string _Folder_code;
        string _Folder_description;
        int _Folder_type;
        int _Folder_possition;
        string _Parent_folder;
        string _Project_code;
        bool _Enabled;
        int _Folder_id;
        string _mode;
        int _auto;
        string _userid;

        public string Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public string Folder_code
        {
            get { return _Folder_code; }
            set { _Folder_code = value; }
        }
        public string Folder_description
        {
            get { return _Folder_description; }
            set { _Folder_description = value; }
        }
        public int Folder_type
        {
            get { return _Folder_type; }
            set { _Folder_type = value; }
        }
        public int Folder_possition
        {
            get { return _Folder_possition; }
            set { _Folder_possition = value; }
        }
        public string Parent_folder
        {
            get { return _Parent_folder; }
            set { _Parent_folder = value; }
        }
        public string Project_code
        {
            get { return _Project_code; }
            set { _Project_code = value; }
        }
        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }
        public int Folder_id
        {
            get { return _Folder_id; }
            set { _Folder_id = value; }
        }
        public string mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public int auto
        {
            get { return _auto; }
            set { _auto = value; }
        }
      
    }
    public class _clsmanufacture
    {
        string _man_name;
        string _project_code;
        public string man_name
        {
            get { return _man_name; }
            set { _man_name = value; }
        }
        public string project_code
        {
            get{return _project_code;}
            set{_project_code=value;}
        }
    }
    public class _clsdocduration
    {
        int _Folder_id;
        int _Duration;
        int _First;
        int _Second;
        int _Third;
        int _Remind;
        string _prj_code;
        public int Folder_id
        {
            get { return _Folder_id; }
            set { _Folder_id = value; }
        }
        public int Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }
        public int First
        {
            get { return _First; }
            set { _First = value; }
        }
        public int Second
        {
            get { return _Second; }
            set { _Second = value; }
        }
        public int Third
        {
            get { return _Third; }
            set { _Third = value; }
        }
        public int Remind
        {
            get { return _Remind; }
            set { _Remind = value; }
        }
        public string prj_code
        {
            get { return _prj_code; }
            set { _prj_code = value; }
        }

    }
    public class _clscassheet
    {
        int _cas_id;
        int _sch;
        int _sys;
        string _reff;
        string _desc;
        string _loca;
        string _fed_from;
        string _power_on;
        string _comm;
        string _act_by;
        string _act_date;
        string _uid;
        DateTime _date;
        int _srv;
        string _con_acce;
        string _ts_filed;
        string _prj_code;
        string _des_vol;
        string _des_flow_rate;
        string _sys_mon;
        int _dev;
        int _fa_int;
        string _p_power_to;
        int _mode;
        string _cate;
        string _b_zone;
        string _f_level;
        int _seq_no;
        int _c_s_id;
        string _sub_st;
        string _s_c_m;
        string _dev1;
        string _dev2;
        string _dev3;
        string _test_sheet;

        string _test1;
        string _test2;
        string _test3;
        string _test4;
        string _test5;
        string _test6;
        string _test7;
        string _test8;
        string _test9;
        string _test10;
        string _test11;
        string _test12;
        string _test13;
        string _test14;
        string _test15;
        string _compl;
        string _tested1;
        string _tested2;
        decimal _per_com1;
        decimal _per_com2;
        decimal _per_com3;
        decimal _per_com4;
        int _filter;
        string _accept1;
        string _accept2;
        string _filed1;
        string _filed2;
        int _build_id;
        string _build_name;
        int _Position;
        string _qty;
        decimal _per_com5;
        decimal _per_com6;
        decimal _per_com7;
        decimal _per_com8;
        decimal _per_com9;
        decimal _per_com10;
        public string cate
        {
            get { return _cate; }
            set { _cate = value; }
        }
        public string b_zone
        {
            get { return _b_zone; }
            set { _b_zone = value; }
        }
        public string f_level
        {
            get { return _f_level; }
            set { _f_level = value; }
        }
        public int seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; }
        }
        public int c_s_id
        {
            get { return _c_s_id; }
            set { _c_s_id = value; }
        }
        public int sch
        {
            get { return _sch; }
            set { _sch = value; }
        }
        public int sys
        {
            get { return _sys; }
            set { _sys = value; }
        }
        public string reff
        {
            get { return _reff; }
            set { _reff = value; }
        }
        public string desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        public string loca
        {
            get { return _loca; }
            set { _loca = value; }
        }
        public string fed_from
        {
            get { return _fed_from; }
            set { _fed_from = value; }
        }
        public string power_on
        {
            get { return _power_on; }
            set { _power_on = value; }
        }
        public string comm
        {
            get { return _comm; }
            set { _comm = value; }
        }
        public string act_by
        {
            get { return _act_by; }
            set { _act_by = value; }
        }
        public string act_date
        {
            get { return _act_date; }
            set { _act_date = value; }
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }
        public int srv
        {
            get { return _srv; }
            set { _srv = value; }
        }
        public string prj_code
        {
            get { return _prj_code; }
            set { _prj_code = value; }
        }
        public string con_acce
        {
            get { return _con_acce; }
            set { _con_acce = value; }
        }
        public string ts_filed
        {
            get { return _ts_filed; }
            set { _ts_filed = value; }
        }
        public string des_vol
        {
            get { return _des_vol; }
            set { _des_vol = value; }
        }
        public string des_flow_rate
        {
            get { return _des_flow_rate; }
            set { _des_flow_rate = value; }
        }
        public string sys_mon
        {
            get { return _sys_mon; }
            set { _sys_mon = value; }                
        }
        public int dev
        {
            get { return _dev; }
            set { _dev = value; }
        }
        public int fa_int
        {
            get { return _fa_int; }
            set { _fa_int = value; }
        }
        public string p_power_to
        {
            get { return _p_power_to; }
            set { _p_power_to = value; }
        }
        public int cas_id
        {
            get { return _cas_id; }
            set { _cas_id = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public string sub_st
        {
            get { return _sub_st; }
            set { _sub_st = value; }
        }
        public string s_c_m
        {
            get { return _s_c_m; }
            set { _s_c_m = value; }                
        }
        public string dev1
        {
            get { return _dev1; }
            set { _dev1 = value; }
        }
        public string dev2
        {
            get { return _dev2; }
            set { _dev2 = value; }
        }
        public string dev3
        {
            get { return _dev3; }
            set { _dev3 = value; }
        }
        public string test1
        {
            get { return _test1; }
            set { _test1 = value; }                
        }
        public string test2
        {
            get { return _test2; }
            set { _test2 = value; }
        }
        public string test3
        {
            get { return _test3; }
            set { _test3 = value; }
        }
        public string test4
        {
            get { return _test4; }
            set { _test4 = value; }
        }
        public string test5
        {
            get { return _test5; }
            set { _test5 = value; }
        }
        public string test6
        {
            get { return _test6; }
            set { _test6 = value; }
        }
        public string test7
        {
            get { return _test7; }
            set { _test7 = value; }
        }
        public string test8
        {
            get { return _test8; }
            set { _test8 = value; }
        }
        public string test9
        {
            get { return _test9; }
            set { _test9 = value; }
        }
        public string test10
        {
            get { return _test10; }
            set { _test10 = value; }
        }
        public string test11
        {
            get { return _test11; }
            set { _test11 = value; }
        }
        public string test12
        {
            get { return _test12; }
            set { _test12 = value; }
        }
        public string test13
        {
            get
            {
                return _test13;
            }
            set { _test13 = value; }
        }
        public string test14
        {
            get { return _test14; }
            set { _test14 = value; }
        }
        public string test15
        {
            get { return _test15; }
            set { _test15 = value; }
        }
        public string compl
        {
            get { return _compl; }
            set { _compl = value; }
        }
        public string tested1
        {
            get { return _tested1; }
            set { _tested1 = value; }
        }
        public string tested2
        {
            get { return _tested2; }
            set { _tested2 = value; }
        }
        public decimal per_com1
        {
            get { return _per_com1; }
            set { _per_com1 = value; }
        }
        public decimal per_com2
        {
            get { return _per_com2; }
            set { _per_com2 = value; }
        }
        public decimal per_com3
        {
            get { return _per_com3; }
            set { _per_com3 = value; }
        }
        public decimal per_com4
        {
            get { return _per_com4; }
            set { _per_com4= value; }
        }
        public int filter
        {
            get { return _filter; }
            set { _filter = value; }
        }
        string _element;
        public string element
        {
            get { return _element; }
            set { _element = value; }
        }
        public string testsheet
        {
            get { return _test_sheet; }
            set { _test_sheet = value; }
        }
        public string accept1
        {
            get { return _accept1; }
            set { _accept1 = value; }
        }
        public string accept2
        {
            get { return _accept2; }
            set { _accept2 = value; }
        }
        public string filed1
        {
            get { return _filed1; }
            set { _filed1 = value; }
        }
        public string filed2
        {
            get { return _filed2; }
            set { _filed2 = value; }
        }
        public int build_id
        {
            get { return _build_id; }
            set { _build_id = value; }
        }
        public string build_name
        {
            get { return _build_name; }
            set { _build_name = value; }

        }
        public int Position
        {
            get { return _Position; }
            set { _Position = value; }
        }
        public string qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        public decimal _total;
        public decimal total
        {
            get { return _total; }
            set { _total = value; }
        }
        public decimal per_com5
        {
            get { return _per_com5; }
            set { _per_com5= value; }
        }
        public decimal per_com6
        {
            get { return _per_com6; }
            set { _per_com6 = value; }
        }
        public decimal per_com7
        {
            get { return _per_com7; }
            set { _per_com7 = value; }
        }
        public decimal per_com8
        {
            get { return _per_com8; }
            set { _per_com8 = value; }
        }
        public decimal per_com9
        {
            get { return _per_com9; }
            set { _per_com9 = value; }
        }
        public decimal per_com10
        {
            get { return _per_com10; }
            set { _per_com10 = value; }
        }
        int _quantity;
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        int _compl1;
        public int compl1
        {
            get { return _compl1; }
            set { _compl1 = value; }
        }
        int _compl2;
        public int compl2
        {
            get { return _compl2; }
            set { _compl2 = value; }
        }
        int _compl3;
        public int compl3
        {
            get { return _compl3; }
            set { _compl3 = value; }
        }
        int _compl4;
        public int compl4
        {
            get { return _compl4; }
            set { _compl4 = value; }
        }
        string _sys_name;
        public string sys_name
        {
            get { return _sys_name; }
            set { _sys_name = value; }
        }
        string _sch_name;
        public string sch_name
        {
            get { return _sch_name; }
            set { _sch_name = value; }
        }
        int _pre_com;
        public int pre_com
        {
            get { return _pre_com; }
            set { _pre_com = value; }
        }
        int _com;
        public int com
        {
            get { return _com; }
            set { _com = value; }
        }
        int _witne;
        public int witne
        {
            get { return _witne; }
            set { _witne = value; }
        }
        int _insta;
        public int insta
        {
            get { return _insta; }
            set { _insta = value; }
        }
        int _panel_id;
        public int panel_id
        {
            get { return _panel_id; }
            set { _panel_id = value; }
        }
        string _panel_ref;
        public string panel_ref
        {
            get { return _panel_ref; }
            set { _panel_ref = value; }
        }
        int _parent;
        public int parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        int _action;
        public int action
        {
            get { return _action; }
            set { _action = value; }
        }
        decimal _quaty;
        public decimal quaty
        {
            get { return _quaty; }
            set { _quaty = value; }
        }
        decimal _testd;
        public decimal testd
        {
            get { return _testd; }
            set { _testd = value; }
        }
        decimal _qty1;
        public decimal qty1
        {
            get { return _qty1; }
            set { _qty1 = value; }
        }
        decimal _testd1;
        public decimal testd1
        {
            get { return _testd1; }
            set { _testd1 = value; }
        }
        decimal _qty2;
        public decimal qty2
        {
            get { return _qty2; }
            set { _qty2 = value; }
        }
        decimal _testd2;
        public decimal testd2
        {
            get { return _testd2; }
            set { _testd2 = value; }
        }
        decimal _qty3;
        public decimal qty3
        {
            get { return _qty3; }
            set { _qty3 = value; }
        }
        decimal _testd3;
        public decimal testd3
        {
            get { return _testd3; }
            set { _testd3 = value; }
        }
        decimal _qty4;
        public decimal qty4
        {
            get { return _qty4; }
            set { _qty4 = value; }
        }
        decimal _testd4;
        public decimal testd4
        {
            get { return _testd4; }
            set { _testd4 = value; }
        }
        decimal _per_com11;
        public decimal per_com11
        {
            get { return _per_com11; }
            set { _per_com11 = value; }
        }
        decimal _per_com12;
        public decimal per_com12
        {
            get { return _per_com12; }
            set { _per_com12 = value; }
        }
        decimal _per_com13;
        public decimal per_com13
        {
            get { return _per_com13; }
            set { _per_com13 = value; }
        }
        string _doc;
        public string doc
        {
            get { return _doc; }
            set { _doc = value; }
        }
        string _cx_issue;
        public string cx_issue
        {
            get { return _cx_issue; }
            set { _cx_issue = value; }
        }
        string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        string _responsible;
        public string responsible
        {
            get { return _responsible; }
            set { _responsible = value; }
        }
        string _dt_rep;
        public string dt_rep
        {
            get { return _dt_rep; }
            set { _dt_rep = value; }
        }
        string _dt_tc;
        public string dt_tc
        {
            get { return _dt_tc; }
            set { _dt_tc = value; }
        }
        string _last_update;
        public string last_update
        {
            get { return _last_update; }
            set { _last_update = value; }
        }
        string _dt_closed;
        public string dt_closed
        {
            get { return _dt_closed; }
            set { _dt_closed = value; }
        }
        string _dt_closure;
        public string dt_closure
        {
            get { return _dt_closure; }
            set { _dt_closure = value; }
        }
        string _resol_status;
        public string resol_status
        {
            get { return _resol_status; }
            set { _resol_status = value; }
        }
        string _disci;
        public string disci
        {
            get { return _disci; }
            set { _disci = value; }
        }
        string _impact;
        public string impact
        {
            get { return _impact; }
            set { _impact = value; }
        }
        string _prob;
        public string prob
        {
            get { return _prob; }
            set { _prob = value; }
        }
        string _timeline;
        public string timeline
        {
            get { return _timeline; }
            set { _timeline = value; }
        }
        string _rstatus;
        public string rstatus
        {
            get { return _rstatus; }
            set { _rstatus = value; }
        }
        string _caction;
        public string caction
        {
            get { return _caction; }
            set { _caction = value; }
        }
        string _faction;
        public string faction
        {
            get { return _faction; }
            set { _faction = value; }
        }
        int _iss_raised;
        public int iss_raised
        {
            get { return _iss_raised; }
            set { _iss_raised = value; }
        }
        string _iss_period;
        public string iss_period
        {
            get { return _iss_period; }
            set { _iss_period = value; }
        }
        int _iss_total;
        public int iss_total
        {
            get { return _iss_total; }
            set { _iss_total = value; }
        }
        int _iss_open;
        public int iss_open
        {
            get { return _iss_open; }
            set { _iss_open = value; }
        }
        string _hi_p_close;
        public string hi_p_close
        {
            get { return _hi_p_close; }
            set { _hi_p_close = value; }
        }
        string _hi_p_open;
        public string hi_p_open
        {
            get { return _hi_p_open; }
            set { _hi_p_open = value; }
        }
        int _resp1;
        public int resp1
        {
            get { return _resp1; }
            set { _resp1 = value; }
        }
        int _resp2;
        public int resp2
        {
            get { return _resp2; }
            set { _resp2 = value; }
        }
        int _resp3;
        public int resp3
        {
            get { return _resp3; }
            set { _resp3 = value; }
        }
        int _resp4;
        public int resp4
        {
            get { return _resp4; }
            set { _resp4 = value; }
        }
        int _resp5;
        public int resp5
        {
            get { return _resp5; }
            set { _resp5 = value; }
        }
        int _ir_rev;
        public int ir_rev
        {
            get { return _ir_rev; }
            set { _ir_rev = value; }
        }
        string _am_pm;
        public string am_pm
        {
            get { return _am_pm; }
            set { _am_pm = value; }
        }
        int _flevel;
        public int flevel
        {
            get { return _flevel; }
            set { _flevel = value; }
        }
        string _ir_chkd;
        public string ir_chkd
        {
            get { return _ir_chkd; }
            set { _ir_chkd = value; }
        }
        string _advise;
        public string advise
        {
            get { return _advise; }
            set { _advise = value; }
        }
        DateTime _dtpstart;
        public DateTime dtpstart
        {
            get { return _dtpstart; }
            set { _dtpstart = value; }
        }
        DateTime _dtastart;
        public DateTime dtastart
        {
            get { return _dtastart; }
            set { _dtastart = value; }
        }
        string _dtcomp;
        public string dtcomp
        {
            get { return _dtcomp; }
            set { _dtcomp = value; }
        }
        int _visit;
        public int visit
        {
            get { return _visit; }
            set { _visit = value; }
        }
        string _ir_status;
        public string ir_status
        {
            get { return _ir_status; }
            set { _ir_status = value; }
        }
        string _doc_status;
        public string doc_status
        {
            get { return _doc_status; }
            set { _doc_status = value; }
        }
        string _svr_no;
        public string svr_no
        {
            get { return _svr_no; }
            set { _svr_no = value; }
        }
        string _witness;
        public string witness
        {
            get { return _witness; }
            set { _witness = value; }
        }
        bool _Critical;
        public bool Critical
        {
            get { return _Critical; }
            set { _Critical = value; }
        }
        string _p7;
        public string p7
        {
            get { return _p7; }
            set { _p7 = value; }
        }
        string _p8;
        public string p8
        {
            get { return _p8; }
            set { _p8 = value; }
        }
        string _p9;
        public string p9
        {
            get { return _p9; }
            set { _p9 = value; }
        }
        string _p10;
        public string p10
        {
            get { return _p10; }
            set { _p10 = value; }
        }
        string _p11;
        public string p11
        {
            get { return _p11; }
            set { _p11 = value; }
        }
        string _p12;
        public string p12
        {
            get { return _p12; }
            set { _p12 = value; }
        }
        string _p13;
        public string p13
        {
            get { return _p13; }
            set { _p13 = value; }
        }
        string _p14;
        public string p14
        {
            get { return _p14; }
            set { _p14 = value; }
        }
        string _planned1;
        public string planned1
        {
            get { return _planned1; }
            set { _planned1 = value; }
        }
        string _planned2;
        public string planned2
        {
            get { return _planned2; }
            set { _planned2 = value; }
        }
        string _planned3;
        public string planned3
        {
            get { return _planned3; }
            set { _planned3 = value; }
        }
        string _planned4;
        public string planned4
        {
            get { return _planned4; }
            set { _planned4 = value; }

        }
        string _planned5;
        public string planned5
        {
            get { return _planned5; }
            set { _planned5 = value; }
        }
        string _planned6;   
        public string planned6
        {
            get { return _planned6; }
            set { _planned6 = value; }
        }
        string _planned7;
        public string planned7
        {
            get { return _planned7; }
            set { _planned7 = value; }
        }
        string _planned8;
        public string planned8
        {
            get { return _planned8; }
            set { _planned8 = value; }  
        }
    }
    public class _clsassetcode
    {
        string _cate;
        string _b_zone;
        string _f_level;
        string _seq_no;
        int _cas_id;
        public string cate
        {
            get { return _cate; }
            set { _cate = value; }
        }
        public string b_zone
        {
            get { return _b_zone; }
            set { _b_zone = value; }
        }
        public string f_level
        {
            get { return _f_level; }
            set { _f_level = value; }
        }
        public string seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; }
        }
        public int cas_id
        {
            get { return _cas_id; }
            set { _cas_id = value; }
        }
    }
    public class _cls_ele_testing
    {
        int _cas_id;
        string _torque;
        string _ir;
        string _pressure;
        string _sec_injection;
        string _con_resistance;
        string _functional;
        decimal _completed;
        int _ttl_circuits;
        int _ttl_cold_tested;
        string _cold_complete;
        int _ttl_live_tested;
        string _live_complete;
        string _pre_com;
        string _c_f;
        string _load;
        string _full_run;
        string _wir_test;
        string _ratio_test;
        string _wr_test;
        string _vg_test;
        string _hv_test;
        string _lv_ir_test_gen;
        public string torque
        {
            get { return _torque; }
            set { _torque = value; }
        }
        public string ir
        {
            get { return _ir; }
            set { _ir = value; }
        }
        public string pressure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }
        public string sec_injection
        {
            get { return _sec_injection; }
            set { _sec_injection = value; }
        }
        public string con_resistance
        {
            get { return _con_resistance; }
            set { _con_resistance = value; }
        }
        public string functional
        {
            get { return _functional; }
            set { _functional = value; }
        }
        public decimal completed
        {
            get { return _completed; }
            set { _completed = value; }
        }
        public int ttl_circuits
        {
            get { return _ttl_circuits; }
            set { _ttl_circuits = value; }
        }
        public int ttl_cold_tested
        {
            get { return _ttl_cold_tested; }
            set { _ttl_cold_tested = value; }
        }
        public string cold_complete
        {
            get { return _cold_complete; }
            set { _cold_complete = value; }
        }
        public int ttl_live_tested
        {
            get { return _ttl_live_tested; }
            set { _ttl_live_tested = value; }
        }
        public string live_complete
        {
            get { return _live_complete; }
            set { _live_complete = value; }
        }
        public int cas_id
        {
            get { return _cas_id; }
            set { _cas_id = value; }
        }
        public string pre_com
        {
            get { return _pre_com; }
            set { _pre_com = value; }
        }
        public string c_f
        {
            get { return _c_f; }
            set { _c_f = value; }
        }
        public string load
        {
            get { return _load; }
            set { _load = value; }
        }
        public string full_run
        {
            get { return _full_run; }
            set { _full_run = value; }
        }
        public string wir_test
        {
            get { return _wir_test; }
            set { _wir_test = value; }
        }
        public string ratio_test
        {
            get { return _ratio_test; }
            set { _ratio_test = value; }
        }
        public string wr_test
        {
            get { return _wr_test; }
            set { _wr_test = value; }
        }
        public string vg_test
        {
            get { return _vg_test; }
            set { _vg_test = value; }
        }
        public string hv_test
        {
            get { return _hv_test; }
            set { _hv_test = value; }
        }
        public string lv_ir_test_gen
        {
            get { return _lv_ir_test_gen; }
            set { _lv_ir_test_gen = value; }
        }
    }
    public class _clslog
    {
        string _uid;
        string _ipaddr;
        string _location;
        string  _login;
        string  _logout;
        bool _status;
        string _module;
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string ipaddr
        {
            get { return _ipaddr; }
            set { _ipaddr = value; }
        }
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string  login
        {
            get { return _login; }
            set { _login = value; }
        }
        public string  logout
        {
            get { return _logout; }
            set { _logout = value; }
        }
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }
        string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        string _region;

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        public string module
        {
            get { return _module; }
            set { _module = value; }
        }
    }
    public class _clscmsdocument
    {
        string _doc_name;
        string _file_name;
        string _module_name;
        string _uid;
        string _project_code;
        DateTime _upload_date;
        int _doc_id;
        int _folder;
        int _module;
        string _reff_no;
        bool _status;
        public string doc_name
        {
            get { return _doc_name; }
            set { _doc_name = value; }
        }
        public string file_name
        {
            get { return _file_name; }
            set { _file_name = value; }
        }
        public string module_name
        {
            get { return _module_name; }
            set { _module_name = value; }
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public DateTime upload_date
        {
            get { return _upload_date; }
            set { _upload_date = value; }
        }
        public string project_code
        {
            get { return _project_code; }
            set { _project_code = value; }
        }
        public int folder
        {
            get { return _folder; }
            set { _folder = value; }
        }
        public int module
        {
            get { return _module; }
            set { _module = value; }
        }
        public string reff_no
        {
            get { return _reff_no; }
            set { _reff_no = value; }
        }
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }
        int _srv_id;
        public int srv_id
        {
            get { return _srv_id; }
            set { _srv_id = value; }
        }
        string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        int _Comment_By;
        public int Comment_By
        {
            get { return _Comment_By; }
            set { _Comment_By = value; }
        }
        int _Response_By;
        public int Response_By
        {
            get { return _Response_By; }
            set { _Response_By = value; }
        }
        public int Doc_Id
        {
            get { return _doc_id; }
            set { _doc_id = value; }
        }
        int _Review_Days;
        public int Review_Days
        {
            get { return _Review_Days; }
            set { _Review_Days = value; }
        }
        int _mssys_id;
        public int mssys_id
        {
            get { return _mssys_id; }
            set { _mssys_id = value; }
        }
        string _mssys_name;
        public string mssys_name
        {
            get { return _mssys_name; }
            set { _mssys_name = value; }
        }
        //MS - Start - Jenevieve
        string _ms_nodeid;
        public string ms_nodeid
        {
            get { return _ms_nodeid; }
            set { _ms_nodeid = value; }
        }
        string _trans_no;
        public string trans_no
        {
            get { return _trans_no; }
            set { _trans_no = value; }
        }
        //MS - End
        int _pos;
        public int pos
        {
            get { return _pos; }
            set { _pos = value; }
        }
        int _action;
        public int action
        {
            get { return _action; }
            set { _action = value; }
        }
        string _doc_status;
        public string doc_status
        {
            get { return _doc_status; }
            set { _doc_status = value; }
        }
        bool _rev_cml;
        public bool rev_cml
        {
            get { return _rev_cml; }
            set { _rev_cml = value; }
        }
        string _sub_date;
        public string sub_date
        {
            get { return _sub_date; }
            set { _sub_date = value; }
        }
        int _msid;
        public int msid
        {
            get { return _msid; }
            set { _msid = value; }
        }
        DateTime _rev_date;
        public DateTime rev_date
        {
            get { return _rev_date; }
            set { _rev_date = value; }
        }
        string _company;
        public string company
        {
            get { return _company; }
            set { _company = value; }
        }
        string _sbdate;
        public string sbdate
        {
            get { return _sbdate; }
            set { _sbdate = value; }
        }
        string _rvdate;
        public string rvdate
        {
            get { return _rvdate; }
            set { _rvdate = value; }
        }
        bool build1;
        bool build2;
        bool build3;
        public bool Build3
        {
            get { return build3; }
            set { build3 = value; }
        }
        public bool Build2
        {
            get { return build2; }
            set { build2 = value; }
        }
        public bool Build1
        {
            get { return build1; }
            set { build1 = value; }
        }
        string _revision;
        byte[] _cms_file;
        DateTime _issue_date;
        int _dr_id;
        bool _carryComm;
        public string revision
        {
            get { return _revision; }
            set { _revision = value; }
        }
        public byte[] CMS_file
        {
            get { return _cms_file; }
            set { _cms_file = value; }
        }
        public DateTime issue_date
        {
            get { return _issue_date; }
            set { _issue_date = value; }
        }
        public int dr_id
        {
            get { return _dr_id; }
            set { _dr_id = value; }
        }
        public bool carry_comm
        {
            get { return _carryComm; }
            set { _carryComm = value; }
        }

    }
    public class _clscmscomment
    {
        string _comment;
        string _module;
        string _uid;
        string _project;
        string _resp;
        int _doc_id;
        int _com_id;
        DateTime _com_date;
        DateTime _resp_date;
        string _sec;
        string _page;
        public string comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public string module
        {
            get { return _module; }
            set { _module = value; }
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string project
        {
            get { return _project; }
            set { _project = value; }
        }
        public string resp
        {
            get { return _resp; }
            set { _resp = value; }
        }
        public int doc_id
        {
            get { return _doc_id; }
            set { _doc_id = value; }
        }
        public int com_id
        {
            get { return _com_id; }
            set { _com_id = value; }
        }
        public DateTime com_date
        {
            get { return _com_date; }
            set { _com_date = value; }
        }
        public DateTime resp_date
        {
            get { return _resp_date; }
            set { _resp_date = value; }
        }
        public string sec
        {
            get { return _sec; }
            set { _sec = value; }
        }
        public string page
        {
            get { return _page; }
            set { _page = value; }
        }
        

    }
    public class _clsdocreview
    {
        string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        int position;

        public int Position
        {
            get { return position; }
            set { position = value; }
        }
        string _AttachDocument;
        public string AttachDocument
        {
            get { return _AttachDocument; }
            set { _AttachDocument = value; }
        }
        int _building;
        public int building
        {
            get { return _building; }
            set { _building = value; }
        }
        int _dr_id;
        string _dr_no;
        string _dr_reviewed;
        DateTime _issued_date;
        string _issued_to;
        string _reviewed_by;
        bool _dr_status;
        string _response;
        string _project_code;
        string _uid;
        string _descr;
        string _detail;
        int _mode;
        int _dr_itm_id;
        string _service;
        string _desc;
        byte[] _logo;
        public int dr_id
        {
            get { return _dr_id; }
            set { _dr_id = value; }
        }
        public string dr_no
        {
            get { return _dr_no; }
            set { _dr_no = value; }
        }
        public string dr_reviewed
        {
            get { return _dr_reviewed; }
            set { _dr_reviewed = value; }
        }
        public DateTime issued_date
        {
            get { return _issued_date; }
            set { _issued_date = value; }
        }
        public string issued_to
        {
            get { return _issued_to; }
            set { _issued_to = value; }
        }
        public bool dr_status
        {
            get { return _dr_status; }
            set { _dr_status = value; }
        }
        public string response
        {
            get { return _response; }
            set { _response = value; }
        }
        public string project_code
        {
            get { return _project_code; }
            set { _project_code = value; }
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string reviewed_by
        {
            get { return _reviewed_by; }
            set { _reviewed_by = value; }
        }
        public string descr
        {
            get { return _descr; }
            set { _descr = value; }
        }
        public string details
        {
            get { return _detail; }
            set { _detail = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public int dr_itm_id
        {
            get { return _dr_itm_id; }
            set { _dr_itm_id = value; }
        }
        public string service
        {
            get { return _service; }
            set { _service = value; }
        }
        public string desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        public byte[] logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        string _ddate;
        public string ddate
        {
            get { return _ddate; }
            set { _ddate = value; }
        }
        string _closeout_date;
        public string closeout_date
        {
            get { return _closeout_date; }
            set { _closeout_date = value; }
        }
    }
    public class _clsSO
    {
        int _so_building;
        public int so_building
        {
            get { return _so_building; }
            set { _so_building = value; }
        }
        byte[] photoImage;

        public byte[] PhotoImage
        {
            get { return photoImage; }
            set { photoImage = value; }
        }
        int _so_id;
        string _so_no;
        DateTime _so_date;
        string _package;
        string _doc_name;
        DateTime _issued_date;
        string _issued_to;
        bool _status;
        string _remarks;
        string _project_code;
        string _uid;
        string _details;
        string _img1;
        string _img2;
        string _img3;
        string _response;
        int _so_itm_id;
        string _photo;
        int _mode;
        byte[] _logo;
        public int so_id
        {
            get { return _so_id; }
            set { _so_id = value; }
        }
        public string so_no
        {
            get { return _so_no; }
            set { _so_no = value; }
        }
        public DateTime so_date
        {
            get { return _so_date; }
            set { _so_date = value; }
        }
        public string package
        {
            get { return _package; }
            set { _package = value; }
        }
        public string doc_name
        {
            get { return _doc_name; }
            set { _doc_name = value; }
        }
        public DateTime issued_date
        {
            get { return _issued_date; }
            set { _issued_date = value; }
        }
        public string issued_to
        {
            get { return _issued_to; }
            set { _issued_to = value; }
        }
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        public string project_code
        {
            get { return _project_code; }
            set { _project_code = value; }
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string details
        {
            get { return _details; }
            set { _details = value; }
        }
        public string img1
        {
            get { return _img1; }
            set { _img1 = value; }
        }
        public string img2
        {
            get { return _img2; }
            set { _img2 = value; }
        }
        public string img3
        {
            get { return _img3; }
            set { _img3 = value; }
        }
        public string response
        {
            get { return _response; }
            set { _response = value; }
        }
        public int so_itm_id
        {
            get { return _so_itm_id; }
            set { _so_itm_id = value; }
        }
        public string photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public byte[] logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        int _srv_id;
        public int srv_id
        {
            get { return _srv_id; }
            set { _srv_id = value; }
        }
        string _idate;
        public string idate
        {
            get { return _idate; }
            set { _idate = value; }
        }
        string _sub;
        public string sub
        {
            get { return _sub; }
            set { _sub = value; }
        }
        string _issued_by;
        public string issued_by
        {
            get { return _issued_by; }
            set { _issued_by = value; }
        }
        string _comments;
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        string _action;
        public string action
        {
            get { return _action; }
            set { _action = value; }
        }
        string _cdate;
        public string cdate
        {
            get { return _cdate; }
            set { _cdate = value; }
        }
        int _position;
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

   }
    public class _clscassheet_updating
    {
        int _cas_id;
        DateTime _test1;
        DateTime _test2;
        DateTime _test3;
        DateTime _test4;
        DateTime _test5;
        DateTime _test6;
        DateTime _test7;
        DateTime _test8;
        DateTime _test9;
        DateTime _test10;

    }
    public class _database
    {
        string _DBName;
        string _BAkname;
        string _Dataname;
        string _Datapath;
        string _Logname;
        string _Logpath;
        string _project;
        byte[] _photo_rpt;
        int _rpt;
        string _cas;
        public string DBName
        {
            get { return _DBName; }
            set { _DBName = value; }
        }
        public string Bakname
        {
            get { return _BAkname; }
            set { _BAkname = value; }
        }
        public string Dataname
        {
            get { return _Dataname; }
            set { _Dataname = value; }
        }
        public string Datapath
        {
            get { return _Datapath; }
            set { _Datapath = value; }
        }
        public string Logname
        {
            get { return _Logname; }
            set { _Logname = value; }
        }
        public string Logpath
        {
            get { return _Logpath; }
            set { _Logpath = value; }
        }
        public string project
        {
            get { return _project; }
            set { _project = value; }
        }
        public byte[] photo_rpt
        {
            get { return _photo_rpt; }
            set { _photo_rpt = value; }
        }
        public int rpt
        {
            get { return _rpt; }
            set { _rpt = value; }
        }
        public string cas
        {
            get { return _cas; }
            set { _cas = value; }
        }
        int _div;

        public int Div
        {

            get { return _div; }

            set { _div = value; }

        }

    }
    public class _clspackage
    {
        string _package;
        string _category;
        string _project;
        int _sch_id;
        int _record_sheet;
        int _mode;
        int _sys_id;
        public string package
        {
            get { return _package; }
            set{_package=value;}
        }
        public string category
        {
            get { return _category; }
            set { _category = value; }
        }
        public string project
        {
            get { return _project; }
            set { _project = value; }
        }
        public int sch_id
        {
            get { return _sch_id; }
            set { _sch_id = value; }
        }
        public int record_sheet
        {
            get { return _record_sheet; }
            set { _record_sheet = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public int sys_id
        {
            get { return _sys_id; }
            set { _sys_id = value; }
        }

    }
    public class _clsFolderTree
    {
        string _Folder_code;
        string _Folder_description;
        int _Folder_type;
        int _Folder_possition;
        int _Parent_folder;
        string _Project_code;
        bool _Enabled;
        int _Folder_id;
        string _mode;
        int _type;
        int _master_id;
        public string Folder_code
        {
            get { return _Folder_code; }
            set { _Folder_code = value; }
        }
        public string Folder_description
        {
            get { return _Folder_description; }
            set { _Folder_description = value; }
        }
        public int Folder_type
        {
            get { return _Folder_type; }
            set { _Folder_type = value; }
        }
        public int Folder_possition
        {
            get { return _Folder_possition; }
            set { _Folder_possition = value; }
        }
        public int Parent_folder
        {
            get { return _Parent_folder; }
            set { _Parent_folder = value; }
        }
        public string Project_code
        {
            get { return _Project_code; }
            set { _Project_code = value; }
        }
        public bool Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }
        public int Folder_id
        {
            get { return _Folder_id; }
            set { _Folder_id = value; }
        }
        public string mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int master_id
        {
            get { return _master_id; }
            set { _master_id = value; }
        }
    }
    public class _clsMaster
    {
        int _ser_id;
        int _sys_id;
        int _cas_id;
        bool _enabled;
        string _ser_name;
        string _sys_name;
        string _sys_type;
        string _sys_reff;
        public int ser_id
        {
            get { return _ser_id; }
            set { _ser_id = value; }
        }
        public int sys_id
        {
            get { return _sys_id; }
            set { _sys_id = value; }
        }
        public bool enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        public string ser_name
        {
            get { return _ser_name; }
            set { _ser_name = value; }
        }
        public string sys_name
        {
            get { return _sys_name; }
            set { _sys_name = value; }
        }
        public string sys_reff
        {
            get { return _sys_reff; }
            set { _sys_reff = value; }
        }
        public string sys_type
        {
            get { return _sys_type; }
            set { _sys_type = value; }
        }
            
    }
    public class _sysconfig
    {
        int _ser_id;
        int _sys_id;
        int _cas_id;
        bool _enabled;
        string _ser_name;
        string _sys_name;
        string _sys_type;
        string _sys_reff;
        string _cas_name;
        public int ser_id
        {
            get { return _ser_id; }
            set { _ser_id = value; }
        }
        public int sys_id
        {
            get { return _sys_id; }
            set { _sys_id = value; }
        }
        public bool enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }
        public string ser_name
        {
            get { return _ser_name; }
            set { _ser_name = value; }
        }
        public string sys_name
        {
            get { return _sys_name; }
            set { _sys_name = value; }
        }
        public string sys_reff
        {
            get { return _sys_reff; }
            set { _sys_reff = value; }
        }
        public string sys_type
        {
            get { return _sys_type; }
            set { _sys_type = value; }
        }
        public string cas_name
        {
            get { return _cas_name; }
            set { _cas_name = value; }
        }
        public int cas_id
        {
            get { return _cas_id; }
            set { _cas_id = value; }
        }
    }
    public class _clsCRS
    {
        int _crs_id;
        int _sys_id;
        int _rs_id;
        int _pkg_cate_id;
        int _sys_cas_id;
        string _eng_reff;
        string _ter_reff;
        string _asset_code;
        string _tested_by;
        string _instru_used;
        DateTime _date_comm;
        DateTime _date_comp;
        string _witnsd_by;
        DateTime _date_witnsd;
        string _factor;
        string _design1;
        string _design2;
        string _initial1;
        string _initial2;
        string _final1;
        string _final2;
        string _check1;
        string _check2;
        string _hood;
        string _comments;
        string _uid;
        public int crs_id
        {
            get { return _crs_id; }
            set { _crs_id = value; }
        }
        public int sys_id
        {
            get { return _sys_id; }
            set { _sys_id = value; }
        }
        public int rs_id
        {
            get { return _rs_id; }
            set { _rs_id = value; }
        }
        public int pkg_cate_id
        {
            get { return _pkg_cate_id; }
            set { _pkg_cate_id = value; }
        }
        public int sys_cas_id
        {
            get { return _sys_cas_id; }
            set { _sys_cas_id = value; }
        }
        public string eng_reff
        {
            get { return _eng_reff; }
            set { _eng_reff = value; }
        }
        public string ter_reff
        {
            get { return _ter_reff; }
            set { _ter_reff = value; }
        }
        public string asset_code
        {
            get { return _asset_code; }
            set { _asset_code = value; }
        }
        public string tested_by
        {
            get { return _tested_by; }
            set { _tested_by = value; }
        }
        public string instru_used
        {
            get { return _instru_used; }
            set { _instru_used = value; }
        }
        public DateTime date_comm
        {
            get { return _date_comm; }
            set { _date_comm = value; }
        }
        public DateTime date_comp
        {
            get { return _date_comp; }
            set { _date_comp = value; }
        }
        public string witnsd_by
        {
            get { return _witnsd_by; }
            set { _witnsd_by = value; }
                
        }
        public DateTime date_witnsd
        {
            get { return _date_witnsd; }
            set { _date_witnsd = value; }
        }
        public string factor
        {
            get { return _factor; }
            set { _factor = value; }
        }
        public string design1
        {
            get { return _design1; }
            set { _design1 = value; }
        }
        public string design2
        {
            get { return _design2; }
            set { _design2 = value; }
        }
        public string initial1
        {
            get { return _initial1; }
            set { _initial1 = value; }
        }
        public string initial2
        {
            get { return _initial2; }
            set { _initial2 = value; }
        }
        public string final1
        {
            get { return _final1; }
            set { _final1 = value; }
        }
        public string final2
        {
            get { return _final2; }
            set { _final2 = value; }
        }
        public string check1
        {
            get { return _check1; }
            set { _check1 = value; }
        }
        public string check2
        {
            get { return _check2; }
            set { _check2 = value; }
        }
        public string hood
        {
            get { return _hood; }
            set { _hood = value; }
        }
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
    }
    public class _clsSnag
    {
        int _snag_id;
        int _snag_sub_id;
        int _package;
        string _project;
        string _status;
        string _area;
        string _description;
        string _img;
        string _service;
        string _ref_no;
        string _created_by;
        DateTime _date_created;
        string _issued_to;
        DateTime _date_issued;
        int _type;
        int _mode;
        string _room;
        string _response;
        string _pkg_name;
        int _com_id;
        int _pkg_id;
        string _userid;
        byte[] _photo_rpt;
        public int snag_id
        {
            get { return _snag_id; }
            set { _snag_id = value; }
        }
        public int snag_sub_id
        {
            get { return _snag_sub_id; }
            set { _snag_sub_id = value; }
        }
        public int package
        {
            get { return _package; }
            set { _package = value; }
        }
        public string project
        {
            get { return _project; }
            set { _project = value; }
        }
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string area
        {
            get { return _area; }
            set { _area = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string img
        {
            get { return _img; }
            set { _img = value; }
        }
        public string service
        {
            get { return _service; }
            set { _service = value; }
        }
        public string ref_no
        {
            get { return _ref_no; }
            set { _ref_no = value; }
        }
        public string created_by
        {
            get { return _created_by; }
            set { _created_by = value; }
        }
        public DateTime date_created
        {
            get { return _date_created; }
            set { _date_created = value; }
        }
        public string issued_to
        {
            get { return _issued_to; }
            set { _issued_to = value; }
        }
        public DateTime date_issued
        {
            get { return _date_issued; }
            set { _date_issued = value; }

        }
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string room
        {
            get { return _room; }
            set { _room = value; }
        }
        public string response
        {
            get { return _response; }
            set { _response = value; }
        }
        public string pkg_name
        {
            get { return _pkg_name; }
            set { _pkg_name = value; }
        }
        public int com_id
        {
            get { return _com_id; }
            set { _com_id = value; }
        }
        public int pkg_id
        {
            get { return _pkg_id; }
            set { _pkg_id = value; }
        }
        public string userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public int mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public byte[] photo_rpt
        {
            get { return _photo_rpt; }
            set { _photo_rpt = value; }
        }
        string _Floor;
        public string Floor
        {
            get { return _Floor; }
            set { _Floor = value; }
        }
    }
    public class _clsams
    {
        int _manufId;
        public int manufId
        {
            get { return _manufId; }
            set { _manufId = value; }
        }
        int _action;
        public int action
        {
            get { return _action; }
            set { _action = value; }
        }
        string _manufName;
        public string manufName
        {
            get { return _manufName; }
            set { _manufName = value; }
        }
        int _supId;
        public int supId
        {
            get { return _supId; }
            set { _supId = value; }
        }
        string _supName;
        public string supName
        {
            get { return _supName; }
            set { _supName = value; }
        }
        int _adId;
        public int adId
        {
            get { return _adId; }
            set { _adId = value; }
        }
        int _casId;
        public int casId
        {
            get { return _casId; }
            set { _casId = value; }
        }
        string _eqpNo;
        public string eqpNo
        {
            get { return _eqpNo; }
            set { _eqpNo = value; }
        }
        string _model;
        public string model
        {
            get { return _model; }
            set { _model = value; }
        }
        string _srlno;
        public string srlno
        {
            get { return _srlno; }
            set { _srlno = value; }
        }
        string _partner;
        public string partner
        {
            get { return _partner; }
            set { _partner = value; }
        }
        string _pono;
        public string pono
        {
            get { return _pono; }
            set { _pono = value; }
        }
        decimal _pprice;
        public decimal pprice
        {
            get { return _pprice; }
            set { _pprice = value; }
        }
        string _cur;
        public string cur
        {
            get { return _cur; }
            set { _cur = value; }
        }
        string _cdate;
        public string cdate
        {
            get { return _cdate; }
            set { _cdate = value; }
        }
        string _edate;
        public string edate
        {
            get { return _edate; }
            set { _edate = value; }
        }
        decimal _rcost;
        public decimal rcost
        {
            get { return _rcost; }
            set { _rcost = value; }
        }
        string _rpby;
        public string rpby
        {
            get { return _rpby; }
            set { _rpby = value; }
        }
        int _contrId;
        public int contrId
        {
            get { return _contrId; }
            set { _contrId = value; }
        }
        string _contrName;
        public string contrName
        {
            get { return _contrName; }
            set { _contrName = value; }
        }
        int _mcId;
        public int mcId
        {
            get { return _mcId; }
            set { _mcId = value; }
        }
        int _eId;
        public int eId
        {
            get { return _eId; }
            set { _eId = value; }
        }
        string _phase;
        public string phase
        {
            get { return _phase; }
            set { _phase = value; }
        }
        string _voltage;
        public string voltage
        {
            get { return _voltage; }
            set { _voltage = value; }
        }
        string _amp;
        public string amp
        {
            get { return _amp; }
            set { _amp = value; }
        }
        string _other;
        public string other
        {
            get { return _other; }
            set { _other = value; }
        }
        int _mId;
        public int mId
        {
            get { return _mId; }
            set { _mId = value; }
        }
        string _wtemp;
        public string wtemp
        {
            get { return _wtemp; }
            set { _wtemp = value; }
        }
        string _rpm;
        public string rpm
        {
            get { return _rpm; }
            set { _rpm = value; }
        }
        int _cId;
        public int cId
        {
            get { return _cId; }
            set { _cId = value; }
        }
        bool _bArea;
        public bool bArea
        {
            get { return _bArea; }
            set { _bArea = value; }
        }
        bool _aOccupied;
        public bool aOccupied
        {
            get { return _aOccupied; }
            set { _aOccupied = value; }
        }
        string _Comm_SOD;
        public string Comm_SOD
        {
            get { return _Comm_SOD; }
            set { _Comm_SOD = value; }
        }
        string _DailyChk;
        public string DailyChk
        {
            get { return _DailyChk; }
            set { _DailyChk = value; }
        }
        string _WeeklyChk;
        public string WeeklyChk
        {
            get { return _WeeklyChk; }
            set { _WeeklyChk = value; }
        }
        string _MonthlyChk;
        public string MonthlyChk
        {
            get { return _MonthlyChk; }
            set { _MonthlyChk = value; }
        }
        string _TMonthsChk;
        public string TMonthsChk
        {
            get { return _TMonthsChk; }
            set { _TMonthsChk = value; }
        }
        string _SMonthsChk;
        public string SMonthsChk
        {
            get { return _SMonthsChk; }
            set { _SMonthsChk = value; }
        }
        string _YearlyChk;
        public string YearlyChk
        {
            get { return _YearlyChk; }
            set { _YearlyChk = value; }
        }
        int _ACD_id;
        public int ACD_id
        {
            get { return _ACD_id; }
            set { _ACD_id = value; }
        }
        string _task;
        public string task
        {
            get { return _task; }
            set { _task = value; }
        }
        string _type;
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        string _dbname;
        public string dbname
        {
            get { return _dbname; }
            set { _dbname = value; }
        }
        int _task_id;
        public int task_id
        {
            get { return _task_id; }
            set { _task_id = value; }
        }
        int _sys_id;
        public int sys_id
        {
            get { return _sys_id; }
            set { _sys_id = value; }
        }
        int _sp_id;
        public int sp_id
        {
            get { return _sp_id; }
            set { _sp_id = value; }
        }
        string _sp_name;
        public string sp_name
        {
            get { return _sp_name; }
            set { _sp_name = value; }
        }
        string _chkdate;
        public string chkdate
        {
            get { return _chkdate; }
            set { _chkdate = value; }
        }
        DateTime _signoff;
        public DateTime signoff
        {
            get { return _signoff; }
            set { _signoff = value; }
        }
        string _uid;
        public string uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        int _qty;
        public int qty
        {
            get { return _qty; }
            set { _qty = value; }
        }
        decimal _manpower;
        public decimal manpower
        {
            get { return _manpower; }
            set { _manpower = value; }
        }
        string _comments;
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        int _task_compl_id;
        public int task_compl_id
        {
            get { return _task_compl_id; }
            set { _task_compl_id = value; }
        }
        string _compl_date;
        public string compl_date
        {
            get { return _compl_date; }
            set { _compl_date = value; }
        }
        int _ams_reg_id;
        public int ams_reg_id
        {
            get { return _ams_reg_id; }
            set { _ams_reg_id = value; }
        }
        int _sch_id;
        public int sch_id
        {
            get { return _sch_id; }
            set { _sch_id = value; }
        }
        string _prj_reff;
        public string prj_reff
        {
            get { return _prj_reff; }
            set { _prj_reff = value; }
        }
        string _bzone;
        public string bzone
        {
            get { return _bzone; }
            set { _bzone = value; }
        }
        string _cat;
        public string cat
        {
            get { return _cat; }
            set { _cat = value; }
        }
        string _flvl;
        public string flvl
        {
            get { return _flvl; }
            set { _flvl = value; }
        }
        string _seq_no;
        public string seq_no
        {
            get { return _seq_no; }
            set { _seq_no = value; }
        }
        bool _parent;
        public bool parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        int _position;
        public int position
        {
            get { return _position; }
            set { _position = value; }
        }
        string _location;
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }
        int _parent_id;
        public int parent_id
        {
            get { return _parent_id; }
            set { _parent_id = value; }
        }
        string _sp_code;
        public string sp_code
        {
            get { return _sp_code; }
            set { _sp_code = value; }
        }
        int _wqty;
        public int wqty
        {
            get { return _wqty; }
            set { _wqty = value; }
        }
        decimal _sp_cost;
        public decimal sp_cost
        {
            get { return _sp_cost; }
            set { _sp_cost = value; }
        }
        int _srv_id;
        public int srv_id
        {
            get { return _srv_id; }
            set { _srv_id = value; }
        }
        decimal _man_hrs;
        public decimal man_hrs
        {
            get { return _man_hrs; }
            set { _man_hrs = value; }
        }
        string _pdate;
        public string pdate
        {
            get { return _pdate; }
            set { _pdate = value; }
        }
        decimal _depreciation;
        public decimal depreciation
        {
            get { return _depreciation; }
            set { _depreciation = value; }
        }
        int _ams_doc_id;
        public int ams_doc_id
        {
            get { return _ams_doc_id; }
            set { _ams_doc_id = value; }
        }
        int _dms_doc_id;
        public int dms_doc_id
        {
            get { return _dms_doc_id; }
            set { _dms_doc_id = value; }
        }
        string _doc_name;
        public string doc_name
        {
            get { return _doc_name; }
            set { _doc_name = value; }
        }
        int _doc_type;
        public int doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; }
        }
        string _doc_package;
        public string doc_package
        {
            get { return _doc_package; }
            set { _doc_package = value; }
        }
        int _ams_sys_id;
        public int ams_sys_id
        {
            get { return _ams_sys_id; }
            set { _ams_sys_id = value; }
        }
        string _ams_sys_name;
        public string ams_sys_name
        {
            get { return _ams_sys_name; }
            set { _ams_sys_name = value; }
        }
        string _descri;
        public string descri
        {
            get { return _descri; }
            set { _descri = value; }
        }
        int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
    public class _clstis
    {
        string _prj_code;
        public string prj_code
        {
            get { return _prj_code; }
            set { _prj_code = value; }
        }
        int _bldg_id;
        public int bldg_id
        {
            get { return _bldg_id; }
            set { _bldg_id = value; }
        }
        int _flr_id;
        public int flr_id
        {
            get { return _flr_id; }
            set { _flr_id = value; }
        }
        int _zn_id;
        public int zn_id
        {
            get { return _zn_id; }
            set { _zn_id = value; }
        }
        string _tnc_name;
        public string tnc_name
        {
            get { return _tnc_name; }
            set { _tnc_name = value; }
        }
        DateTime _update;
        public DateTime update
        {
            get { return _update; }
            set { _update = value; }
        }
        string _filename;
        public string filename
        {
            get { return _filename; }
            set { _filename = value; }
        }
        DateTime _fdate;
        public DateTime fdate
        {
            get { return _fdate; }
            set { _fdate = value; }
        }
        DateTime _tdate;
        public DateTime tdate
        {
            get { return _tdate; }
            set { _tdate = value; }
        }
        DateTime _rdate;
        public DateTime rdate
        {
            get { return _rdate; }
            set { _rdate = value; }
        }
        decimal _tvalue;
        public decimal tvalue
        {
            get { return _tvalue; }
            set { _tvalue = value; }
        }
        string _cur;
        public string cur
        {
            get { return _cur; }
            set { _cur = value; }
        }
        int _tnts_id;
        public int tnts_id
        {
            get { return _tnts_id; }
            set { _tnts_id = value; }
        }
        int _action;
        public int action
        {
            get { return _action; }
            set { _action = value; }
        }
        bool _status;
        public bool status
        {
            get { return _status; }
            set { _status = value; }
        }
        string _letter;
        public string letter
        {
            get { return _letter; }
            set { _letter = value; }
        }
        string _subject;
        public string subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        string _from;
        public string from
        {
            get { return _from; }
            set { _from = value; }
        }
        string _service;
        public string service
        {
            get { return _service; }
            set { _service = value; }
        }
        string _eng_ref;
        public string eng_ref
        {
            get { return _eng_ref; }
            set { _eng_ref = value; }
        }
        string _cate;
        public string cate
        {
            get { return _cate; }
            set { _cate = value; }
        }
        string _flevel;
        public string flevel
        {
            get { return _flevel; }
            set { _flevel = value; }
        }

    }
    public class _clstestpack
    {
        int _cc_id;
        public int cc_id
        {
            get { return _cc_id; }
            set { _cc_id = value; }
        }
        int _cas_id;
        public int cas_id
        {
            get { return _cas_id; }
            set { _cas_id = value; }
        }
        string _system;
        public string system
        {
            get { return _system; }
            set { _system = value; }
        }
        string _sheet_ref;
        public string sheet_ref
        {
            get { return _sheet_ref; }
            set { _sheet_ref = value; }
        }
        string _asset_code;
        public string asset_code
        {
            get { return _asset_code; }
            set { _asset_code = value; }
        }
        string _type_work;
        public string type_work
        {
            get { return _type_work; }
            set { _type_work = value; }
        }
        string _location;
        public string location
        {
            get { return _location; }
            set { _location = value; }
        }
        string _test_type;
        public string test_type
        {
            get { return _test_type; }
            set { _test_type = value; }
        }
        string _comments;
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        string _tested_by;
        public string tested_by
        {
            get { return _tested_by; }
            set { _tested_by = value; }
        }
        string _tested_date;
        public string tested_date
        {
            get { return _tested_date; }
            set { _tested_date = value; }
        }
        string _witnessed_by;
        public string witnessed_by
        {
            get { return _witnessed_by; }
            set { _witnessed_by = value; }
        }
        string _wit_date;
        public string wit_date
        {
            get { return _wit_date; }
            set { _wit_date = value; }
        }
        string _accepted_by;
        public string accepted_by
        {
            get { return _accepted_by; }
            set { _accepted_by = value; }
        }
        string _acce_date;
        public string acce_date
        {
            get { return _acce_date; }
            set { _acce_date = value; }
        }
        string _instru_used;
        public string instru_used
        {
            get { return _instru_used; }
            set { _instru_used = value; }
        }
        int _action = 0;
        public int action
        {
            get { return _action; }
            set { _action = value; }
        }
        string _plant_ref;
        public string plant_ref
        {
            get { return _plant_ref; }
            set { _plant_ref = value; }
        }
        int _rev;
        public int rev
        {
            get { return _rev; }
            set { _rev = value; }
        }
        int _list_id;
        public int list_id
        {
            get { return _list_id; }
            set { _list_id = value; }
        }
        string _chk_list;
        public string chk_list
        {
            get { return _chk_list; }
            set { _chk_list = value; }
        }
        string _status;
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        string _signature;
        public string signature
        {
            get { return _signature; }
            set { _signature = value; }
        }


    }
    public class _clscommunication
    {
        string _userid;
        public string userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        string _mailid;
        public string mailid
        {
            get { return _mailid; }
            set { _mailid = value; }
        }
        DateTime _maildate;
        public DateTime maildate
        {
            get { return _maildate; }
            set { _maildate = value; }
        }
        string _subj;
        public string subj
        {
            get { return _subj; }
            set { _subj = value; }
        }
        string _message;
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        int _item_id;
        public int item_id
        {
            get { return _item_id; }
            set { _item_id = value; }
        }
        int _type;
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        string _attachment;
        public string attachment
        {
            get { return _attachment; }
            set { _attachment = value; }
        }
        string _project_code;
        public string project_code
        {
            get { return _project_code; }
            set { _project_code = value; }
        }
    }
    public class _clsProgressTracking
    {
        int _progress_id;

        public int Progress_id
        {
            get { return _progress_id; }
            set { _progress_id = value; }
        }
        int _folder_id;

        public int Folder_id
        {
            get { return _folder_id; }
            set { _folder_id = value; }
        }
        decimal _section1;

        public decimal Section1
        {
            get { return _section1; }
            set { _section1 = value; }
        }
        decimal _section2;

        public decimal Section2
        {
            get { return _section2; }
            set { _section2 = value; }
        }
        decimal _section3;

        public decimal Section3
        {
            get { return _section3; }
            set { _section3 = value; }
        }
        decimal _section4;

        public decimal Section4
        {
            get { return _section4; }
            set { _section4 = value; }
        }
        decimal _section5;

        public decimal Section5
        {
            get { return _section5; }
            set { _section5 = value; }
        }
        decimal _section6;

        public decimal Section6
        {
            get { return _section6; }
            set { _section6 = value; }
        }
        decimal _section7;

        public decimal Section7
        {
            get { return _section7; }
            set { _section7 = value; }
        }
        decimal _section8;

        public decimal Section8
        {
            get { return _section8; }
            set { _section8 = value; }
        }
        decimal _section9;

        public decimal Section9
        {
            get { return _section9; }
            set { _section9 = value; }
        }
        decimal _section10;

        public decimal Section10
        {
            get { return _section10; }
            set { _section10 = value; }
        }
        string _draftIssuedate;

        public string DraftIssuedate
        {
            get { return _draftIssuedate; }
            set { _draftIssuedate = value; }
        }
        string _remarks;

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
        string _userid;

        public string Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        string _entrydate;

        public string Entrydate
        {
            get { return _entrydate; }
            set { _entrydate = value; }
        }
        string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        int _type;

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
    public class _clscmssettings
    {
        string _module;
        int _revisionStyle;
        int _statusStyle;
        bool _allowDR;
        bool _allowComments;
        int _responsePeriod;

        public string module
        {
            get { return _module; }
            set { _module = value; }
        }
        public int revision_style
        {
            get { return _revisionStyle; }
            set { _revisionStyle = value; }
        }
        public int status_style
        {
            get { return _statusStyle; }
            set { _statusStyle = value; }
        }
        public bool allowDR
        {
            get { return _allowDR; }
            set { _allowDR = value; }
        }
        public bool allowcomments
        {
            get { return _allowComments; }
            set { _allowComments = value; }
        }
        public int responseperiod
        {
            get { return _responsePeriod; }
            set { _responsePeriod = value; }
        }
    }
    #region Dashboard
    public class ChartDetails
    {
        public decimal GraphPlannedData { get; set; }
        public decimal GraphActualData { get; set; }
        public string Label { get; set; }
    }
    public class ServiceDetails
    {
        public decimal PlannedProgress { get; set; }
        public decimal Progress { get; set; }
        public string Label { get; set; }
        public int ID { get; set; }

    }
    public class CasSheetDetails
    {
        public decimal Progress { get; set; }
        public string Label { get; set; }

    }
    public class ExecutiveDetails
    {
        public string Label { get; set; }
        public decimal? ActualProgress { get; set; }
        public decimal? PlannedProgress { get; set; }
    }
    #endregion
}
