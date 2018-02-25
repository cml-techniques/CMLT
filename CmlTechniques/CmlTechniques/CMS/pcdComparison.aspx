<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pcdComparison.aspx.cs" Inherits="CmlTechniques.CMS.pcdComparison" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery.js" type="text/javascript"></script>
      <link href="CrystalStyle.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color:#d1d1d1">
    <form id="form1" runat="server">

       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="lblprj" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lbldiv" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblsch" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblzone" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblfl" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblfd" runat="server" Text="Label" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblcat" runat="server" Text="Label" CssClass="hidden"></asp:Label>
           <input id="hdnpcd" type="hidden" name="hdnpcd"  runat="server">  
     <div class="rpthead">
            <div class="rptfilter">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 150px">
                            Building/ Zone
                        </td>
                        <td style="width: 150px">
                            Category
                        </td>
                        <td style="width: 150px">
                            Floor Level
                        </td>
                        <td style="width: 150px">
                         
                              Location
                        </td>
                        <td style="width: 150px">
                             Fed From
                        </td>
                      <td style="width: 150px">
                          Planned reference date
                        </td>
                        <td rowspan="2" width="70px"  align="left" valign="bottom">
                            <asp:Button ID="btngenerate" runat="server" Text="Generate" Width="70px" Height="30px"  OnClick="btngenerate_Click"
                                CssClass="comment-btn" ToolTip="View Summary" OnClientClick="setGen()" />
                        </td>
                        <td rowspan="2" width="70px" align="right" id="tdback" runat="server" valign="bottom">
                            <%--<asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                            <asp:Button ID="btnback" runat="server" Text="Back" Width="70px" Height="30px"
                                CssClass="comment-btn" ToolTip="Back to Previous" onclick="btnback_Click"  />
                                 
                            </ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                                    <asp:DropDownList ID="drbuilding" runat="server" Width="100%" >
                                       
                                    </asp:DropDownList>
                        </td>
                        <td>
                                    <asp:DropDownList ID="drcategory" runat="server" Width="100%" >
                                    </asp:DropDownList>
                        </td>
                        <td>
                                    <asp:DropDownList ID="drflevel" runat="server" Width="100%" >
                                    </asp:DropDownList>
                        </td>
                        <td>
                                              <asp:DropDownList ID="drloc" runat="server" Width="100%" >
                                    </asp:DropDownList>
                        </td>
                        <td>

                        
                                      <asp:DropDownList ID="drfed" runat="server" Width="100%" >
                                    </asp:DropDownList>
                        </td>
                        <td>
                        <asp:TextBox ID="txtpcddate" runat="server" Text="" Width="90px" ReadOnly="true">
                            </asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender391" runat="server" ClearTime="true" 
                                    Format="dd/MM/yyyy" PopupButtonID="txtpcddate" TargetControlID="txtpcddate">
                                </asp:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
      
           <div   >
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                        HasCrystalLogo="False" HasToggleGroupTreeButton="False" ToolPanelView="None" />
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="CrystalReportViewer1" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
          <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 30%;
        left: 35%">
        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
            <ProgressTemplate>
                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                    Width="250px" />
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    </form>
      <script type="text/javascript">
    $( document ).ready(function() {
  SetCurrentDate();
});
   function SetCurrentDate()
      {
    var tdate = new Date();
   var dd = tdate.getDate(); //yields day
   var MM = tdate.getMonth(); //yields month
   var yyyy = tdate.getFullYear(); //yields year
   var xxx = dd + "/" +( MM+1) + "/" + yyyy;
      document.getElementById("txtpcddate").value=xxx;
      }
      function setGen()
      {
      var mvalue= document.getElementById("txtpcddate").value;
       document.getElementById("hdnpcd").value=mvalue;
//       alert(document.getElementById("hdnpcd").value);
       }
 </script>
</body>
</html>
