<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comm_RecordSheet.aspx.cs" Inherits="CmlTechniques.TP.Comm_RecordSheet" %>

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
        <table style="width:100%;background-color:#000000;position:relative"  cellspacing="2" >
        <tr style="background-color:#ffffff">
        <td colspan="2" rowspan="2" style="width:120px">
        <img src="../images/123logo.jpg" alt="" width="120" /></td>
        <td rowspan="2" align="center" valign="middle" style="width:100%" >
        <h1>COMMISSIONING RECORD SHEET <br /> FAN SET DATA</h1>
            </td>
        <td align="center" valign="middle" style="width:80px">
            <asp:Label ID="Label1" runat="server" Text="A1" Width="80px"></asp:Label>
                                </td>
        <td align="center" valign="middle" style="width:80px">
        <img src="../images/cmllogo_small.jpg" alt="" /></td>
        <td rowspan="2" align="center" valign="middle" style="width:120px" colspan="2">
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
        <td style="width:120px" colspan="2">
            <asp:TextBox ID="txt_sheet_ref" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td>System </td>
        <td colspan="3">
            <asp:TextBox ID="txt_system" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            </td>
        <td>Asset code</td>
        <td colspan="2">
            <asp:TextBox ID="txt_asset_code" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td>Location</td>
        <td colspan="2">
            <asp:TextBox ID="txt_location" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>Plant ref.</td>
        <td>
            <asp:TextBox ID="txt_plantref" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
            <td  style="width:30px">Rev.</td>
            <td>
            <asp:TextBox ID="txt_rev" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        <table style="width:100%;background-color:#000000;font-weight:normal;position:relative"  cellspacing="2" >
        <tr style="background-color:#ffffff">
        <td style="width:15%;background-color:Yellow;font-weight:bold">SYSTEM DATA</td>
        <td style="width:35%">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:100%">
            <asp:TextBox ID="TextBox13" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" align="right"><asp:Label ID="Label24" runat="server" Text="" Width="50px">m<sup>3</sup>/s</asp:Label></td>
        </tr>
        </table>
        </td>
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:100%">
            <asp:TextBox ID="TextBox14" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" align="right"><asp:Label ID="Label23" runat="server" Text="" Width="50px">m<sup>3</sup>/s</asp:Label></td>
        <td style="width:50px" align="right"><asp:Label ID="Label3" runat="server" Text="AINED" Width="50px" Font-Bold="true"></asp:Label></td>
        <td style="width:120px">
            <asp:TextBox ID="TextBox15" runat="server" Width="120px" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label2" runat="server" Text="System Volume" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="txt_location0" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </td>
        <td style="width:25%">&nbsp;</td>
        <td  style="width:25%">&nbsp;</td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label4" runat="server" Text="Fan static pressure*" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox1" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px"><asp:Label ID="Label5" runat="server" Text="Pa" Width="50px"></asp:Label></td>
        </tr>
        </table>
         </td>
        <td style="width:25%">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label6" runat="server" Text="Suction*" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox2" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label7" runat="server" Text="Pa" Width="50px"></asp:Label></td>
        </tr>
        </table>
        </td>
        <td  style="width:25%">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label8" runat="server" Text="Discharge" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox3" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label9" runat="server" Text="Pa" Width="50px"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label10" runat="server" Text="Fan speed" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox4" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label11" runat="server" Text="rev/m" Width="50px"></asp:Label></td>
        </tr>
        </table>
         </td>
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:100%">
            <asp:TextBox ID="TextBox5" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label13" runat="server" Text="rev/m" Width="50px"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label12" runat="server" Text="Motor speed" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox6" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label14" runat="server" Text="rev/m" Width="50px"></asp:Label></td>
        </tr>
        </table>
         </td>
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:100%">
            <asp:TextBox ID="TextBox7" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label15" runat="server" Text="rev/m" Width="50px"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label16" runat="server" Text="Filter P.d. (max)" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox8" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label17" runat="server" Text="Pa" Width="50px"></asp:Label></td>
        </tr>
        </table>
         </td>
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:100%">
            <asp:TextBox ID="TextBox9" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label18" runat="server" Text="Pa @ time of test" Width="100px"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label19" runat="server" Text="Setting of mixing damper" Width="150px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox10" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
         </td>
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:50px" ><asp:Label ID="Label21" runat="server" Text="Setting of main damper" Width="150px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox11" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="4">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:50px" ><asp:Label ID="Label20" runat="server" Text="Method used to obtain volume" Width="200px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox12" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td style="width:50px" ><asp:Label ID="Label22" runat="server" Text="" Width="200px">m<sup>3</sup>/s</asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:15%;background-color:Yellow;font-weight:bold">FAN DATA</td>
        <td style="width:35%">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:50px" ><asp:Label ID="Label25" runat="server" Text="Type" Width="50px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox16" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        
        </tr>
        </table>
        </td>
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:50px"><asp:Label ID="Label26" runat="server" Text="Ordered duty" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox17" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        
        <td style="width:50px"><asp:Label ID="Label27" runat="server" Text="Pa" Width="50px" ></asp:Label></td>
        
        </tr>
        </table>
        </td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label28" runat="server" Text="Manufacturer" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox19" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </td>
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label35" runat="server" Text="Model" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox18" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label36" runat="server" Text="Serial no." Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox23" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </td>
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label37" runat="server" Text="Pitch angle(s)" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox24" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </td>
        </tr>
       <tr style="background-color:#ffffff">
        <td style="width:15%;background-color:Yellow;font-weight:bold">MOTOR DATA</td>
        <td style="width:35%">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:50px" ><asp:Label ID="Label29" runat="server" Text="Type" Width="50px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox20" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        
        </tr>
        </table>
        </td>
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td style="width:50px"><asp:Label ID="Label30" runat="server" Text="Frame" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox21" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        
        
        </tr>
        </table>
        </td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label32" runat="server" Text="Manufacturer" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox22" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </td>
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label33" runat="server" Text="Serial no." Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox25" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label34" runat="server" Text="FLC." Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox26" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td  style="width:50px">
            <asp:Label ID="Label31" runat="server" Text="amps" Width="50px"></asp:Label></td>                        
        </tr>
        </table>
        </td>
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label38" runat="server" Text="Running Current" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox27" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
       <td  style="width:70px">
            <asp:Label ID="Label39" runat="server" Text="amps" Width="70px"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label40" runat="server" Text="Overload range" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox28" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td  style="width:50px">
            <asp:Label ID="Label41" runat="server" Text="amps" Width="50px"></asp:Label></td>                        
        </tr>
        </table>
        </td>
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label42" runat="server" Text="Setting" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox29" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
       <td  style="width:70px">
            <asp:Label ID="Label43" runat="server" Text="amps" Width="70px"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="2">
        <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label44" runat="server" Text="Rated power" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox30" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td  style="width:50px">
            <asp:Label ID="Label45" runat="server" Text="kW" Width="50px"></asp:Label></td>                        
        </tr>
        </table>
        </td>
        <td colspan="2">
         <table  border="0" cellpadding="0" cellspacing="0" style="width:100%">
        <tr>
        <td  style="width:120px">
            <asp:Label ID="Label46" runat="server" Text="Electrical Supply" Width="120px"></asp:Label></td>
        <td style="width:100%">
            <asp:TextBox ID="TextBox31" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
       <td  style="width:70px">
            <asp:Label ID="Label47" runat="server" Text="V/ph/Hz" Width="70px"></asp:Label></td>
        </tr>
        </table>
        </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:15%;background-color:Yellow;font-weight:bold">FAN DATA</td>
        <td style="width:35%">&nbsp;</td>
        <td style="width:25%">&nbsp;</td>
        <td  style="width:25%">&nbsp;</td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td style="width:15%;">&nbsp;</td>
        <td style="width:35%">&nbsp;</td>
        <td style="width:25%">&nbsp;</td>
        <td  style="width:25%">&nbsp;</td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td style="width:15%;">&nbsp;</td>
        <td style="width:35%">&nbsp;</td>
        <td style="width:25%">&nbsp;</td>
        <td  style="width:25%">&nbsp;</td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td style="width:15%;">&nbsp;</td>
        <td style="width:35%">&nbsp;</td>
        <td style="width:25%">&nbsp;</td>
        <td  style="width:25%">&nbsp;</td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td style="width:15%;">&nbsp;</td>
        <td style="width:35%">&nbsp;</td>
        <td style="width:25%">&nbsp;</td>
        <td  style="width:25%">&nbsp;</td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td style="width:15%;">&nbsp;</td>
        <td style="width:35%">&nbsp;</td>
        <td style="width:25%">&nbsp;</td>
        <td  style="width:25%">&nbsp;</td>
        </tr>
        
        <tr style="background-color:#ffffff">
        <td style="width:15%;">&nbsp;</td>
        <td style="width:35%">&nbsp;</td>
        <td style="width:25%">&nbsp;</td>
        <td  style="width:25%">&nbsp;</td>
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
        </div>
    </div>
    </form>
</body>
</html>
