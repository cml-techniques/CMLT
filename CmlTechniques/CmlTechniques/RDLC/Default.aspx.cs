using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _DefaultPage : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        DataBind();
        Demo demoMaster = Master as Demo;
        if (demoMaster != null) {
            lGeneralTerms.Text = demoMaster.GeneralTerms;
            pDescription.Controls.Add(new LiteralControl(demoMaster.Description));
        }
    }
    protected void Image1_Load(object sender, EventArgs e) {
        DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(Image1.ImageUrl);
        ip.Width = Image1.Width;
        ip.Height = Image1.Height;
        ip.AssignToControl(Image1, DesignMode);
        Image1.ImageAlign = ImageAlign.Right;
    }
    protected void Image2_Load(object sender, EventArgs e) {
        Image srcImage = sender as Image;
        if (srcImage != null) {
            DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(srcImage.ImageUrl);
            ip.Width = srcImage.Width;
            ip.Height = srcImage.Height;
            ip.AssignToControl(srcImage, DesignMode);
        }
    }
    public bool IsImageVisible(object visible) {
        if (visible != null)
            return bool.Parse(visible.ToString());
        return true;
    }
}
