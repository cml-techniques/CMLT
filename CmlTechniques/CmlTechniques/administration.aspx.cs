using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CmlTechniques
{
    public partial class administration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            btnDummy_ModalPopupExtender.Show();
            //ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callpage(1);", true);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callpage(2);", true);

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callpage(3);", true);

        }
        protected void btnCont_Click(object sender, EventArgs e)
        {
            if (drmodules.SelectedItem.Value == "0")
            {
                Session["module"] = "DMS";
                ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callpage(1);", true);
            }
            else if (drmodules.SelectedItem.Value == "1")
            {
                Session["module"] = "CMS";
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "parent.callpage(4);", true);
                //ScriptManager.RegisterStartupScript(this, typeof(string), "", "alert('Not Available!');", true);
            }
            
            else if (drmodules.SelectedItem.Value == "2")
            {
                Session["module"] = "AMS";
                ScriptManager.RegisterStartupScript(this, typeof(string), "", "parent.callpage(6);", true);
            }

        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Hide();
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callpage(5);", true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            btnDummy_ModalPopupExtender.Show();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callpage(2);", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callpage(3);", true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(string), "close", "parent.callpage(5);", true);
        }

       
    }
}
