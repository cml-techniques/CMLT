using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using DevExpress.Web.ASPxNavBar;

public partial class Demo : System.Web.UI.MasterPage {
    private bool isHomePage = false;
    private bool showTermsHeader = true;
    private string title = "";
    private string description = "";
    private string generalTerms = "";
    private HorizontalAlign horizontalAlign = HorizontalAlign.Center;
    private string titleImageUrl = "";
    private CodeRender fCodeRender = new CodeRender();

    public bool IsHomePage {
        get { return isHomePage; }
    }
    public string TitleImageUrl {
        get { return titleImageUrl; }
    }
    public string Title {
        get { return title; }
    }
    public string Description {
        get { return description; }
    }
    public string GeneralTerms {
        get { return generalTerms; }
    }
    public HorizontalAlign HorizontalAlign {
        get { return horizontalAlign; }
    }
    public bool ShowTermsHeader {
        get { return showTermsHeader; }
    }
    public string GroupName {
        get { return (nbMenu.SelectedItem != null) ? nbMenu.SelectedItem.Group.Name : "Demo Center"; }
    }
    public string Name {
        get { return (nbMenu.SelectedItem != null) ? nbMenu.SelectedItem.Name : "ASP.NET - Delivered!"; }
    }

    protected void Page_Load(object sender, EventArgs e) {
        //DemoSettings.LogDemo(Session, Request == null ? GetType().Name : Request.FilePath);
        nbMenu.DataBind();
        //Header
        string currentUrl = Request.AppRelativeCurrentExecutionFilePath.ToLower();
        if(IsHomePage || Logotype.NavigateUrl.ToLower() == currentUrl)
            Logotype.NavigateUrl = "";

        // Footer
        lblCurrentYear.Text = DateTime.Now.Year.ToString();

        if(phOnceContent.Controls.Count != 0)
            tdFooter.Style.Add(HtmlTextWriterStyle.PaddingLeft, "37px");

        // Scripts
        Page.ClientScript.RegisterClientScriptInclude("Utils", Page.ResolveUrl("~/Script/Utils.js"));

        if(!String.IsNullOrEmpty(Title))
            Page.Header.Title = Title + Page.Header.Title;

        if(phContent.Controls.Count == 0) {
            phContent.Visible = false;
            phContent.EnableViewState = false;
            tblTitle.Visible = false;
            tblTitle.EnableViewState = false;
            tblHeader.Visible = false;
            tblHeader.EnableViewState = false;
            tblFooter.Visible = false;
            tblFooter.EnableViewState = false;
            tblContent.Visible = false;
            tblContent.EnableViewState = false;
        }

        if (phOnceContent.Controls.Count == 0) {
            phOnceContent.Visible = false;
            phOnceContent.EnableViewState = false;
        }
        // general terms
        if(!string.IsNullOrEmpty(GeneralTerms)) {
            lGeneralTerms.Visible = true;
            lGeneralTerms.Text = GeneralTerms;
            //pDescription.Controls.Add(new LiteralControl(demoMaster.Description));
        }

        // SourceCode
        SetDescriptionTabVisibility();
        LoadActiveTabPageContent();
        pcSourceCode.TabPages.FindByName("JS").Visible = IsJSIncludeInCurrentPage();

        // Title
        lGroupName.Text = Name;// GroupName;
        //lName.Text = Name;
        if (string.IsNullOrEmpty(lName.Text)) {
            hName.Visible = false;
            hName.EnableViewState = false;
        }

        // Aligment
        if(HorizontalAlign == HorizontalAlign.Center)
            Page.Header.Controls.Add(new LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + Page.ResolveUrl("~/Css/CenterAligment.css") + "\" />"));
    }

    string GetUrl(string url) {
        int i = url.IndexOf("?");
        if(i != -1) return url.Substring(0, i);
        return url;
    }
    protected void nbMenu_ItemDataBound(object source, DevExpress.Web.ASPxNavBar.NavBarItemEventArgs e) {
        e.Item.Name = e.Item.Text;

        IHierarchyData itemHierarchyData = (e.Item.DataItem as IHierarchyData);
        XmlElement xmlElement = itemHierarchyData.Item as XmlElement;

        if (xmlElement.Attributes["Caption"] != null)
            e.Item.Name = xmlElement.Attributes["Caption"].Value;

        if (GetUrl(e.Item.NavigateUrl).ToLower() == Request.AppRelativeCurrentExecutionFilePath.ToLower()) {
            if(Request.QueryString["Section"] != null) {
                if(xmlElement.Attributes["Section"] == null ||
                     Request.QueryString["Section"] != xmlElement.Attributes["Section"].Value) return;
            }
            e.Item.Selected = true;
            e.Item.Group.Expanded = true;

            if (xmlElement.Attributes["Title"] != null)
                this.title = xmlElement.Attributes["Title"].Value;

            if (xmlElement.OwnerDocument.ChildNodes[1] != null && xmlElement.OwnerDocument.ChildNodes[1].Attributes["HorizontalAlign"] != null) {
                switch (xmlElement.OwnerDocument.ChildNodes[1].Attributes["HorizontalAlign"].Value) {
                    case "Left": {
                            this.horizontalAlign = HorizontalAlign.Left;
                            break;
                        }
                }
            }
            foreach (XmlNode itemNode in xmlElement.ChildNodes) {
                switch (itemNode.Name) {
                    case "Description": {
                            this.description = itemNode.InnerXml;
                            break;
                        }
                    case "GeneralTerms": {
                            this.generalTerms = itemNode.InnerXml;
                            if (itemNode.Attributes["ShowHeader"] != null &&
                                itemNode.Attributes["ShowHeader"].Value.ToLower() == "false")
                                this.showTermsHeader = false;
                            break;
                        }
                }
            }

        }
    }
    protected void nbMenu_GroupDataBound(object source, NavBarGroupEventArgs e) {
        IHierarchyData hierarchyData = (e.Group.DataItem as IHierarchyData);
        XmlElement xmlElement = hierarchyData.Item as XmlElement;
        XmlAttributeCollection attributes = xmlElement.Attributes;

        if (xmlElement.Attributes["Caption"] != null)
            e.Group.Name = xmlElement.Attributes["Caption"].Value;
        else
            e.Group.Name = xmlElement.Attributes["Text"].Value;

        if (xmlElement.Attributes["Visible"] != null && xmlElement.Attributes["Visible"].Value.ToLower() == "false")
            e.Group.Visible = false;

        if (e.Group.Expanded && TitleImageUrl == "") {
            this.titleImageUrl = xmlElement.Attributes["ImageUrl"] != null ? xmlElement.Attributes["ImageUrl"].Value : "";
        }
    }
    protected bool GetIsNewVisible(object dataItem) {
        bool isNew = false;
        IHierarchyData hierarchyData = (dataItem as IHierarchyData);
        XmlElement xmlElement = hierarchyData.Item as XmlElement;

        string value = GetAttributeValue(xmlElement, "IsNew");
        bool.TryParse(value, out isNew);
        return isNew;
    }
    protected bool GetIsUpdatedVisible(object dataItem) {
        bool isUpdated = false;
        IHierarchyData hierarchyData = (dataItem as IHierarchyData);
        XmlElement xmlElement = hierarchyData.Item as XmlElement;

        string value = GetAttributeValue(xmlElement, "IsUpdated");
        bool.TryParse(value, out isUpdated);
        return isUpdated;
    }
    protected bool IsCurrentPage(Page page, object oUrl) {
        if (oUrl == null)
            return false;

        bool result = false;
        string url = oUrl.ToString();
        if (url.ToLower() == page.Request.AppRelativeCurrentExecutionFilePath.ToLower())
            result = true;
        return result;
    }
    private string GetAttributeValue(XmlElement xmlElement, string name) {
        XmlAttributeCollection attributes = xmlElement.Attributes;
        if (attributes[name] != null)
            return attributes[name].Value;
        else
            return "";
    }

    protected void iTitleImage_Load(object sender, EventArgs e) {
        DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(TitleImageUrl);
        ip.Width = Unit.Pixel(45);
        ip.Height = Unit.Pixel(50);
        ip.AssignToControl(iTitleImage, DesignMode);

        iTitleImage.AlternateText = GroupName + " - " + Name;

        if (String.IsNullOrEmpty(TitleImageUrl)) {
            lGroupName.Style.Add(HtmlTextWriterStyle.MarginLeft, "11px");
            iTitleImage.Visible = false;
            iTitleImage.EnableViewState = false;
        }
    }
    protected void ImageNew_Load(object sender, EventArgs e) {
        Image image = sender as Image;
        if (image != null) {
            DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(image.ImageUrl);
            ip.Width = image.Width;
            ip.Height = image.Height;
            ip.AssignToControl(image, DesignMode);
        }
    }
    protected void ImageNew2_Load(object sender, EventArgs e) {
        Image image = sender as Image;
        if (image != null) {
            DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(image.ImageUrl);
            ip.Width = image.Width;
            ip.Height = image.Height;
            ip.AssignToControl(image, DesignMode);
        }
    }
    protected void ImageUpdated_Load(object sender, EventArgs e) {
        Image image = sender as Image;
        if (image != null) {
            DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(image.ImageUrl);
            ip.Width = image.Width;
            ip.Height = image.Height;
            ip.AssignToControl(image, DesignMode);
        }
    }
    protected void ImageUpdated2_Load(object sender, EventArgs e) {
        Image image = sender as Image;
        if (image != null) {
            DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(image.ImageUrl);
            ip.Width = image.Width;
            ip.Height = image.Height;
            ip.AssignToControl(image, DesignMode);
        }
    }
    protected void Image1_Load(object sender, EventArgs e) {
        DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(Image1.ImageUrl);
        ip.Width = Image1.Width;
        ip.Height = Image1.Height;
        ip.AssignToControl(Image1, DesignMode);
    }
    protected void Image2_Load(object sender, EventArgs e) {
        DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(Image2.ImageUrl);
        ip.Width = Image2.Width;
        ip.Height = Image2.Height;
        ip.AssignToControl(Image2, DesignMode);
    }
    protected void Image13_Load(object sender, EventArgs e) {
        DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(Image13.ImageUrl);
        ip.Width = Image13.Width;
        ip.Height = Image13.Height;
        ip.AssignToControl(Image13, DesignMode);
    }
    protected void Image14_Load(object sender, EventArgs e) {
        DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(Image14.ImageUrl);
        ip.Width = Image14.Width;
        ip.Height = Image14.Height;
        ip.AssignToControl(Image14, DesignMode);
    }
    protected void ImageCopyright_Load(object sender, EventArgs e) {
        DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(ImageCopyright.ImageUrl);
        ip.Width = ImageCopyright.Width;
        ip.Height = ImageCopyright.Height;
        ip.AssignToControl(ImageCopyright, DesignMode);
    }
    protected void ImageLogo_Load(object sender, EventArgs e) {
        DevExpress.Web.ASPxClasses.ImageProperties ip = new DevExpress.Web.ASPxClasses.ImageProperties(ImageLogo.ImageUrl);
        ip.Width = ImageLogo.Width;
        ip.Height = ImageLogo.Height;
        ip.AssignToControl(ImageLogo, DesignMode);
    }
    
    // SourceCode
    protected Control CreateNotAvailableTextControl() {
        return new LiteralControl("<div class=\"cr-div-description\">File is not available</div>");
    }
    protected Control CreateTabPageContentControl(string name) {
        switch (name) {
            case "Description":
                return GetDescriptionTextControl();
            case "C#":
                return GetCSharpLanguageCodeControl();
            case "VB":
                return GetVBLanguageCodeControl();
            case "ASPX":
                return GetASPXLanguageCodeControl();
            case "JS":
                return GetJSLanguageCodeControl();
            default:
                return null;
        }
    }
    protected Control GetJSLanguageCodeControl() {
        return fCodeRender.GetHTMLFormattedJSFileControl(GetPhisicalASPXFileName());
    }
    protected Control GetASPXLanguageCodeControl() {
        return fCodeRender.GetHTMLFormattedAspxFileControl(GetPhisicalASPXFileName());
    }
    protected Control GetCSharpLanguageCodeControl() {
        string codeFileName = GetCodeFileName("CS");

        if (!System.IO.File.Exists(codeFileName))
            return CreateNotAvailableTextControl();
        return fCodeRender.GetHTMLFormattedCSFileControl(codeFileName);
    }
    protected Control GetVBLanguageCodeControl() {
        string codeFileName = GetCodeFileName("VB");

        if (!System.IO.File.Exists(codeFileName))
            return CreateNotAvailableTextControl();
        return fCodeRender.GetHTMLFormattedVBFileControl(codeFileName);
    }
    protected Control GetDescriptionTextControl() {
        return fCodeRender.GetDescriptionTextControl(Description);
    }
    protected string GetRootLanguageDemo(string physicalDir, string language) {
        while (!System.IO.Directory.Exists(physicalDir + "\\" + language) &&
                 physicalDir != Path.GetPathRoot(physicalDir))
            physicalDir = System.IO.Directory.GetParent(physicalDir).ToString();
        return physicalDir + "\\" + language;
    }
    protected string GetCodeFileName(string language) {
        string physicalPath = GetPhisicalASPXFileName();

        string physicalDir = Path.GetDirectoryName(physicalPath);
        string fileExtension = language == "CS" ? ".cs" : ".vb";
        string physicalFile = Path.GetFileName(physicalPath) + fileExtension;

        string currentDirectory = System.IO.Directory.CreateDirectory(physicalDir).Name;

        if (System.IO.File.Exists(physicalDir + "\\" + physicalFile)) {
            return physicalDir + "\\" + physicalFile;
        } else {
            physicalDir = GetRootLanguageDemo(physicalDir, language);

            if (System.IO.File.Exists(physicalDir + "\\" + currentDirectory + "\\" + physicalFile)) {
                return physicalDir + "\\" + currentDirectory + "\\" + physicalFile;
            } else if (System.IO.Directory.Exists(physicalDir)) {
                foreach (string dir in System.IO.Directory.GetDirectories(physicalDir)) {
                    if (System.IO.File.Exists(dir + "\\" + currentDirectory + "\\" + physicalFile))
                        return dir + "\\" + currentDirectory + "\\" + physicalFile;
                }
            }
        }
        return "";
    }
    protected string GetPhisicalASPXFileName() {
        return MapPath(Request.AppRelativeCurrentExecutionFilePath.ToLower());
    }
    protected bool IsJSIncludeInCurrentPage() {
        return GetJSLanguageCodeControl() != null;
    }
    protected void LoadActiveTabPageContent() {
        Control contentControl = CreateTabPageContentControl(pcSourceCode.ActiveTabPage.Name);
        if ((contentControl != null) && 
            (pcSourceCode.ActiveTabPage.Controls.Count == 0))
            pcSourceCode.ActiveTabPage.Controls.Add(contentControl);
    }
    protected void pcSourceCode_ActiveTabChanged(object source, DevExpress.Web.ASPxTabControl.TabControlEventArgs e) {
        LoadActiveTabPageContent();
    }
    protected void SetDescriptionTabVisibility() {
        if (string.IsNullOrEmpty(Description)) {
            pcSourceCode.TabPages.FindByName("Description").Visible = false;
        }
    }
}
