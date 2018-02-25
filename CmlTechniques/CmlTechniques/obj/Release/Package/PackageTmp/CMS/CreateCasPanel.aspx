<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCasPanel.aspx.cs" Inherits="CmlTechniques.CMS.CreateCasPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="box1 silver">
        <div class="uplevel">
        <a href="#" onclick="javascript:history.go(-1);">Up Level</a>
        </div>
        <div style="clear:both" ></div>
        </div>
        <div style="width:500px;margin:0 auto">
        <div class="box1 blue_dark">
        <h1 class="title_class">CAS System Panels</h1>
        <table>
        <tr>
        <td style="width:150px">Service</td>
        <td style="width:330px">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="dr_service" runat="server" Width="100%" 
                    onselectedindexchanged="dr_service_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>    
        </tr>
        <tr>
        <td style="width:150px">Cas Sheet</td>
        <td style="width:330px">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="dr_cas" runat="server" Width="100%" AutoPostBack="true" 
                    onselectedindexchanged="dr_cas_SelectedIndexChanged" >
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
        <td style="width:150px">Panel Reference</td>
        <td style="width:330px">
            <asp:TextBox ID="txt_name" runat="server" Width="330px"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:150px">&nbsp;</td>
        <td style="width:330px">
            <asp:CheckBox ID="chkparent" runat="server" Text="Parent Panel" />
            </td>
        </tr>
        <tr>
        <td style="width:150px">Parent Panel</td>
        <td style="width:330px">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="dr_parent" runat="server" Width="100%" >
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
        <td style="width:150px">&nbsp;</td>
        <td style="width:250px">
            <asp:Label ID="lbl_prj" runat="server" Text="" CssClass="hidden"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
        <td style="width:150px">
            <asp:Label ID="lblprj" runat="server" Text="" style="display:none"></asp:Label>
            </td>
        <td style="width:250px">
        <table>
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnadd" runat="server" Text="Save" Width="75px" 
                    onclick="btnadd_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
            <asp:Button ID="btncancel" runat="server" Text="Cancel" Width="75px" 
                    onclick="btncancel_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        </tr>
        </table>
        
        </td>
        </tr>
        </table>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
