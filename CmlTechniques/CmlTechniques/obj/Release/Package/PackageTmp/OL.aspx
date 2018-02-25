<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OL.aspx.cs" Inherits="CmlTechniques.OL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table>
        <tr>
        <td style="width:150px">
            Subject</td>
        <td style="width:250px">
            <asp:TextBox ID="txt_subject" runat="server" width="250px"></asp:TextBox>
                    </td>
        </tr>
        <tr>
        <td style="width:150px">
            Location</td>
        <td style="width:250px">
            <asp:TextBox ID="txt_location" runat="server" width="250px"></asp:TextBox>
                    </td>
        </tr>
        <tr>
        <td style="width:150px">
            Start Time</td>
        <td style="width:250px">
        <table>
        <tr>
        <td style="width:200px">
            <asp:TextBox ID="txt_start" runat="server" Width="200px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_start" PopupButtonID="txt_start" ClearTime="true" >
        </asp:CalendarExtender>
            </td>
        <td style="width:200px"></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr>
        <td style="width:150px">
            End Time</td>
        <td style="width:250px">
        <table>
        <tr>
        <td style="width:200px"><asp:TextBox ID="txt_end" runat="server" Width="200px"></asp:TextBox>
        <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_end" PopupButtonID="txt_end" ClearTime="true" >
        </asp:CalendarExtender>
        </td>
        <td style="width:200px"></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr>
        <td style="width:150px">
            &nbsp;</td>
        <td style="width:250px">
        
                    <asp:CheckBox ID="chk_eventtype" runat="server" Text="All Day Event" />
        
                    </td>
        </tr>
        <tr>
        <td style="width:150px">
            Content</td>
        <td style="width:250px">
            <asp:TextBox ID="txt_content" runat="server" width="250px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    </td>
        </tr>
        <tr>
        <td style="width:150px">
            &nbsp;</td>
        <td style="width:250px">
            &nbsp;</td>
        </tr>
        <tr>
        <td style="width:150px">
            &nbsp;</td>
        <td style="width:250px">
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
            <asp:Button ID="btn_create" runat="server" Text="Add Appointment" 
                    onclick="btn_create_Click" />
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
