using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using App_Properties;
namespace CmlTechniques
{
    public partial class managetreeSub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _ReadCookies();
            if (!IsPostBack)
            {
                Get_details();
                Panel1.Visible = false;
               chkdoc.Visible = false;
            }
        }
        void _ReadCookies()
        {
            if (Request.Browser.Cookies)
            {
                if (Request.Cookies["project"] != null)
                {
                    Session["project"] = Server.HtmlEncode(Request.Cookies["project"].Value);
                }
                if (Request.Cookies["projectname"] != null)
                {
                    Session["projectname"] = Server.HtmlEncode(Request.Cookies["projectname"].Value);
                }
                if (Request.Cookies["fid"] != null)
                {
                    Session["fid"] = Server.HtmlEncode(Request.Cookies["fid"].Value);
                }
                if (Request.Cookies["pos"] != null)
                {
                    Session["pos"] = Server.HtmlEncode(Request.Cookies["pos"].Value);
                }
                if (Request.Cookies["folder"] != null)
                {
                    Session["folder"] = Server.HtmlEncode(Request.Cookies["folder"].Value);
                }
                if (Request.Cookies["level"] != null)
                {
                    Session["level"] = Server.HtmlEncode(Request.Cookies["level"].Value);
                }
                if (Request.Cookies["parent"] != null)
                {
                    Session["parent"] = Server.HtmlEncode(Request.Cookies["parent"].Value);
                }
            }
        }
        private void Get_details()
        {
            if (Request.QueryString[0].ToString() != "0")
            {
                string _str = Request.QueryString[0].ToString();
                Session["fid"] = _str.Substring(0, _str.IndexOf("_L"));
                Session["pos"] = _str.Substring(_str.IndexOf("_L") + 2, _str.IndexOf("_N") - (_str.IndexOf("_L") + 2));
                string _fol = _str.Substring(_str.IndexOf("_N") + 2, _str.IndexOf("_P") - (_str.IndexOf("_N") + 2));
                Session["folder"] = _fol.Replace("<>", "&");
                Session["parent"] = _str.Substring(_str.IndexOf("_P") + 2, _str.IndexOf("_D") - (_str.IndexOf("_P") + 2));
                Session["level"] = _str.Substring(_str.IndexOf("_D") + 2);
                lblpath.Text = (string)Session["parent"];
                Session["new"] = "false";
            }
            else
            {
                Session["level"] = "1";
                Session["pos"] = "0";
                Session["parent"] = "0";
                Session["new"] = "true";
            }

            _CreateCookie();
        }
        private void _CreateCookie()
        {
            if (Request.Browser.Cookies)
            {
                HttpCookie _Ckifid = new HttpCookie("fid");
                _Ckifid.Value = (string)Session["fid"];
                _Ckifid.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckifid);
                HttpCookie _Ckipos = new HttpCookie("pos");
                _Ckipos.Value = (string)Session["pos"];
                _Ckipos.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckipos);
                HttpCookie _Ckifol = new HttpCookie("folder");
                _Ckifol.Value = (string)Session["folder"];
                _Ckifol.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckifol);
                HttpCookie _Ckilev = new HttpCookie("level");
                _Ckilev.Value = (string)Session["level"];
                _Ckilev.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckilev);
                HttpCookie _Ckipar = new HttpCookie("parent");
                _Ckipar.Value = (string)Session["parent"];
                _Ckipar.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(_Ckipar);
                
            }
            else
                return;
        }
        protected void continue_Click(object sender, EventArgs e)
        {
            Continue_();
        }
   
        protected void mygrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idx = int.Parse(e.CommandArgument.ToString());
            //Label2.Text = idx.ToString();
            Session["doc_id"] = mygrid.Rows[idx].Cells[2].Text;
            Session["possition"] = mygrid.Rows[idx].Cells[3].Text;
            if (e.CommandName == "up")
            {
                Move_Document(e.CommandName);
                mygrid.Rows[idx - 1].BackColor = System.Drawing.Color.LightBlue;
            }
            else if (e.CommandName == "down")
            {
                Move_Document(e.CommandName);
                mygrid.Rows[idx + 1].BackColor = System.Drawing.Color.LightBlue;
            }
            else if (e.CommandName == "delete")
            {
                //mygrid.Rows[idx].BackColor = System.Drawing.Color.LightBlue;
                BLL_Dml _objbll = new BLL_Dml();
                _database _objdb = new _database();
                _objdb.DBName = "dbCML";
                _clsdocument _objcls = new _clsdocument();
                _objcls.doc_id = Convert.ToInt32((string)Session["doc_id"]);
                if (lbltype.Text == "10")
                    _objbll.Delete_dms_upload(_objcls, _objdb);
                else
                    _objbll.Delete_Doc(_objcls, _objdb);
                mygrid.DataBind();
            }
        }

        protected void mygrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void mygrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["doc_id"] = mygrid.SelectedRow.Cells[2].Text;
            Session["possition"] = mygrid.SelectedRow.Cells[3].Text;
            Session["index"] = mygrid.SelectedIndex;
        }

        protected void mygrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            if (lbltype.Text == "10")
            {
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ (string)Session["level"] +"');", true);
            
            if ((string)Session["folder"] != null)
                txtfolder.Text = (string)Session["pos"];
            //else
            txtfolder.Text = "";
            switch (draction.SelectedItem.Value)
            {
                case "1": Panel1.Visible = true; pnledit.Visible = false; txtrename.Visible = false; chkdoc.Visible = false; break;
                case "2":
                    {

                        chkdoc.Visible = true;
                        if ((string)Session["new"] != "true")
                        {
                            Panel1.Visible = true;
                            pnledit.Visible = false;
                            txtrename.Visible = false;
                            break;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Parent Folder');", true);
                            break;
                        }

                    }

                case "3":
                    {
                        chkdoc.Visible = false;
                        if ((string)Session["new"] != "true")
                        {
                            Panel1.Visible = true;
                            pnledit.Visible = true;
                            txtfolder.Text = (string)Session["folder"];
                            txtrename.Visible = false;
                            break;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Select Folder');", true);
                            break;
                        }
                    }
                case "4":
                    {
                        chkdoc.Visible = false;
                        Panel1.Visible = false;
                        load_documents();
                        break;                        
                    }


            }
            
        }
        void Continue_()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clstreefolder _objcls = new _clstreefolder();
            int chk = 0;
            if (chkdoc.Visible == true)
            {
                if (chkdoc.Checked == true)
                    chk = 1;
                else
                    chk = 0;
            }
            try
            {
                string _menu = draction.SelectedItem.Value;
                int _level = Convert.ToInt32((string)Session["level"]);
                string _possition = (string)Session["pos"];
                if (_possition != "0")
                {
                    //if (mytree.Nodes.Count > 0)
                    //{
                    //    _level = Convert.ToInt32(mytree.SelectedNode.Depth.ToString()) + 1;
                    //}
                }
                if (_menu == "1")//create new folder
                {
                    try
                    {
                        //if (mytree.Nodes.Count == 0)
                        //{
                        //    _possition = "0";
                        //    _level = 1;
                        //}
                        _objcls.Folder_description = txtfolder.Text;
                        _objcls.Folder_type = _level;
                        _objcls.Folder_possition = Convert.ToInt32(_possition);
                        _objcls.Enabled = true;
                        _objcls.Project_code = (string)Session["project"];
                        _objcls.Parent_folder = (string)Session["parent"];
                        _objcls.auto = chk;
                        _objbll.Create_TreeFolder(_objcls,_objdb);
                        ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('New Folder Created!');", true);

                    }
                    catch (Exception ex)
                    {
                        //Label1.Text = ex.ToString();
                    }

                }
                else if (_menu == "2")//create sub folder
                {
                   // ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('"+ chk.ToString() +"');", true);
                    //if (mytree.Nodes.Count == 0) return;
                    
                    _objcls.Folder_description = txtfolder.Text;
                    _objcls.Folder_type = _level + 1;
                    _objcls.Folder_possition = 0;
                    _objcls.Enabled = true;
                    _objcls.Project_code = (string)Session["project"];
                    _objcls.Parent_folder = (string)Session["fid"];
                    _objcls.auto = chk;
                    _objbll.Create_TreeFolder(_objcls,_objdb);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Sub Folder Created!');", true);

                }
                else if (_menu == "3")//edit folder
                {
                    //string _value = mytree.SelectedNode.Value.ToString();
                    //int _id = Convert.ToInt32(_value.Substring(0, _value.IndexOf("#")));
                   // _objcls.Folder_id = _id;
                    //string _id = (string)Session["fid"];
                    _objcls.Folder_id = Convert.ToInt32((string)Session["fid"]);
                    string _mode = draction0.SelectedItem.Text;
                    if (_mode != "Move to")
                    {
                        _objcls.Folder_description = txtrename.Text;
                        _objcls.mode = _mode;
                        _objbll.Edit_Tree_Folder(_objcls,_objdb);
                    }
                    else
                    {
                        _objcls.Folder_possition = Convert.ToInt32(txtrename.Text);
                        _objbll.Move_Tree_Folder(_objcls,_objdb);
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(string), "close", "alert('Folder has been Changed');", true);

                }
            }
            catch (Exception ex)
            {
                //Label1.Text = ex.ToString();
            }
            
            //txtfolder.Text = "";

        }

        protected void draction0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (draction0.SelectedItem.Value != "3")
                txtrename.Visible = true;
            else
                txtrename.Visible = false;

        }
        void load_documents()
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.folder_id = Convert.ToInt32((string)Session["fid"]);
            int _folder_type = _objbll.Get_FolderType(_objcls, _objdb);
            if (_folder_type == 10)
            {
                lbltype.Text = _folder_type.ToString();
                int _type = _objbll.Get_FolderType_Type(_objcls, _objdb);
                _objcls.folder_id = _type;
                _objcls.project_code = (string)Session["project"];
                mygrid.DataSource = _objbll.load_dms_doc_upload(_objcls, _objdb);
                mygrid.DataBind();
            }
            else
            {
                _objcls.enabled = true;
                mygrid.DataSource = _objbll.load_document(_objcls, _objdb);
                mygrid.DataBind();
            }
        }
        void Move_Document(string _move)
        {
            BLL_Dml _objbll = new BLL_Dml();
            _database _objdb = new _database();
            _objdb.DBName = "dbCML";
            _clsdocument _objcls = new _clsdocument();
            _objcls.doc_id = Convert.ToInt32((string)Session["doc_id"]);
            _objcls.folder_id = Convert.ToInt32((string)Session["fid"]);
            _objcls.possition = Convert.ToInt32((string)Session["possition"]);
            _objcls.move = _move;
            _objbll.Move_document(_objcls,_objdb);
            load_documents();
            //set_select(_move);
            //_objbll.load_document(_objcls);
        }
    }
}
