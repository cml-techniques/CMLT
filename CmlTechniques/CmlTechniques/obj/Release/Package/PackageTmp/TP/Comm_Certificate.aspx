<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comm_Certificate.aspx.cs" Inherits="CmlTechniques.TP.Comm_Certificate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body style="background:#c1c1c1">
    <form id="form1" runat="server">
    <div id="page">
        <asp:Label ID="lbl_casid" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div id="content_block">
        <div class="content">
        <div >
        <table style="width:100%;background-color:#000000;"  cellspacing="2" >
        <tr style="background-color:#ffffff">
        <td colspan="2" rowspan="2" style="width:120px">
        <img src="../images/123logo.jpg" alt="" width="120" /></td>
        <td rowspan="2" align="center" valign="middle" style="width:100%" >
        <h1>COMMISSIONING <br /> CERTIFICATE</h1>
            </td>
        <td align="center" valign="middle" style="width:80px">
            <asp:Label ID="Label1" runat="server" Text="C1" Width="80px"></asp:Label>
                                </td>
        <td align="center" valign="middle" style="width:80px">
        <img src="../images/cmllogo_small.jpg" alt="" /></td>
        <td rowspan="2" align="center" valign="middle" style="width:120px">
        <img src="../images/123logo.jpg" alt="" width="120" /></td>
        </tr>
        <tr style="background-color:#ffffff">
        <td align="center" valign="middle">3.13</td>
        <td align="center" valign="middle">
        <img src="../images/pm_logo.jpg" alt="" /></td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:80px">Project </td>
        <td colspan="3" >
            <asp:TextBox ID="txt_project" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            </td>
        <td style="width:80px">Sheet ref.</td>
        <td style="width:120px">
            <asp:TextBox ID="txt_sheet_ref" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td>System </td>
        <td colspan="3">
            <asp:TextBox ID="txt_system" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            </td>
        <td>Asset code</td>
        <td>
            <asp:TextBox ID="txt_asset_code" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        <table style="width:100%;background-color:#000000;position:relative"  cellspacing="2" >
        <tr style="background-color:#ffffff">
        <td style="padding:20px 50px;" align="center" valign="middle">
        <h2>This certifies that the following works have been<br />tested in accordance with the specification or the<br /> relevant C.I.B.S.E code of practice as defined below.</h2>
        <div class="inner_block">
        <table style="width:100%;background-color:#000000"  cellspacing="1">
        <tr style="background-color:#ffffff">
        <td style="width:120px;padding-left:5px" align="left">Type of work :</td>
        <td style="width:575px">
            <asp:TextBox ID="txt_type_work" runat="server" TextMode="MultiLine" Height="50px" Width="99%" CssClass="txtbox"></asp:TextBox>
        </td>
        </tr>
        </table>
        </div>
        <div class="inner_block">
        <table style="width:100%;background-color:#000000"  cellspacing="1">
        <tr style="background-color:#ffffff">
        <td style="width:120px;padding-left:5px" align="left">Location :</td>
        <td style="width:575px">
            <asp:TextBox ID="txt_location" runat="server" TextMode="MultiLine" 
                Height="50px" Width="99%" CssClass="txtbox"></asp:TextBox>
                                                </td>
        </tr>
        </table>
        </div>
        <div class="inner_block">
        <table style="width:100%;background-color:#000000"  cellspacing="1">
        <tr style="background-color:#ffffff">
        <td style="width:120px;padding-left:5px" align="left">Type of test :</td>
        <td style="width:575px">
            <asp:TextBox ID="txt_test_type" runat="server" TextMode="MultiLine" 
                Height="80px" Width="99%" CssClass="txtbox"></asp:TextBox>
                                                </td>
        </tr>
        </table>
        </div>
        <div class="inner_block">
        <table style="width:100%;background-color:#000000"  cellspacing="1">
        <tr style="background-color:#ffffff">
        <td style="width:120px;padding-left:5px" align="left">Comments :</td>
        <td style="width:575px">
            <asp:TextBox ID="txt_comments" runat="server" TextMode="MultiLine" 
                Height="100px" Width="99%" CssClass="txtbox"></asp:TextBox>
                                                </td>
        </tr>
        </table>
        </div>
            </td>
        </tr>
        </table>
        <table style="width:100%;background-color:#000000;"  cellspacing="2" >
        <tr style="background-color:#ffffff">
        <td style="width:80px">Tested by :</td>
        <td >
            <asp:TextBox ID="txt_tested_by" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:120px">Witnessed by (CML) :</td>
        <td>
            <asp:TextBox ID="txt_witnessed" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:160px">Accepted by (&lt; authority &gt;) :</td>
        <td >
            <asp:TextBox ID="txt_accepted" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td>Date of test :</td>
        <td>
            <asp:TextBox ID="txt_dttest" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
             <asp:CalendarExtender ID="txt_dttest_CalendarExtender" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_dttest" TargetControlID="txt_dttest">
                            </asp:CalendarExtender>
                                </td>
        <td>Date :</td>
        <td>
            <asp:TextBox ID="txt_dtwitness" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_dtwitness" TargetControlID="txt_dtwitness">
                            </asp:CalendarExtender>
                                </td>
        <td>Date :</td>
        <td>
            <asp:TextBox ID="txt_dtaccept" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_dtaccept" TargetControlID="txt_dtaccept">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="2">Instruments used :</td>
        <td colspan="4">
            <asp:TextBox ID="txt_instr_used" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </div>
        </div>
        </div>
        <div id="task_block">
        <div class="controls">
        <table>
        <tr>
        <td>
            <asp:Button ID="btnsubmit" runat="server" Text="Submit" Width="75px" 
                onclick="btnsubmit_Click" /></td>
        <td>
        <asp:Button ID="btnpreview" runat="server" Text="Preview" Width="75px" 
                onclick="btnpreview_Click" />
        </td>
        </tr>
        </table>
        </div>
        <div class="controls">
        <table>
        <tr>
        <td>
        <asp:Button ID="btnnext" runat="server" Text="Pre Commissioning Checklist" 
                onclick="btnnext_Click"  />
        </td>
        </tr>
        </table>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
