<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comm_Checklist.aspx.cs" Inherits="CmlTechniques.TP.Comm_Checklist" %>

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
        <tr style="background-color:#ffffff;font-weight:bold">
        <td style="width:100%; text-align: center;">Check That</td>
        <td style="text-align: center;width:100px">Status *</td>
        <td style="text-align: center;width:100px">Signature</td>
        <td style="text-align: center;width:100px">Date</td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test1" runat="server" Text="All terminals are fitted and dampers are open"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status1" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            <asp:TextBox ID="txt_sig1" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt1" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
             <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt1" TargetControlID="txt_statusdt1">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test2" runat="server" Text="Branch dampers are open and accessible"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status2" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig2" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt2" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt2" TargetControlID="txt_statusdt2">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test3" runat="server" Text="Ductwork, chambers and components are cleared internally"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status3" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig3" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt3" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt3" TargetControlID="txt_statusdt3">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test4" runat="server" Text="Air leackage tests are successfully completed"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status4" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig4" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt4" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender5" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt4" TargetControlID="txt_statusdt4">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test5" runat="server" Text="All AHU components are correctly fitted"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status5" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig5" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt5" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender6" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt5" TargetControlID="txt_statusdt5">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test6" runat="server" Text="Air filter cells are correctly fitted"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status6" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig6" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt6" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender7" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt6" TargetControlID="txt_statusdt6">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test7" runat="server" Text="Al fire dampers are open"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status7" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig7" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt7" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender8" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt7" TargetControlID="txt_statusdt7">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test8" runat="server" Text="All terminal units are correctly located, fitted and powered up"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status8" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig8" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt8" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender9" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt8" TargetControlID="txt_statusdt8">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test9" runat="server" Text="All electrical panels/ switchgear is site tested and pre-commissioned"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status9" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig9" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt9" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender10" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt9" TargetControlID="txt_statusdt9">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test10" runat="server" Text="Motor insulation tests are OK"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status10" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig10" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt10" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender11" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt10" TargetControlID="txt_statusdt10">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test11" runat="server" Text="Fitted fuse rating is correct"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status11" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig11" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt11" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender12" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt11" TargetControlID="txt_statusdt11">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test12" runat="server" Text="Overloads are correctly set"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status12" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig12" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt12" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender13" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt12" TargetControlID="txt_statusdt12">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test13" runat="server" Text="Holding down bolts and AV mounts are OK, Transit brackets etc. are removed"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status13" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig13" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt13" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender14" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt13" TargetControlID="txt_statusdt13">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test14" runat="server" Text="Fan shaft and motor are level and correctly aligned"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status14" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig14" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt14" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender15" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt14" TargetControlID="txt_statusdt14">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test15" runat="server" Text="Drive guards are securely fitted"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status15" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig15" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt15" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender16" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt15" TargetControlID="txt_statusdt15">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test16" runat="server" Text="Correct drive is fitted and properly aligned. Belt tension is correct"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status16" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig16" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt16" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender17" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt16" TargetControlID="txt_statusdt16">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test17" runat="server" Text="Fans and motors are properly lubricated"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status17" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig17" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt17" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender18" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt17" TargetControlID="txt_statusdt17">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test18" runat="server" Text="Access doors are securely fitted"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status18" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig18" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt18" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender19" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt18" TargetControlID="txt_statusdt18">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test19" runat="server" Text="Fan rotates freely"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status19" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig19" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt19" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender20" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt19" TargetControlID="txt_statusdt19">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test20" runat="server" Text="Fan rotates in the correct direction"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status20" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig20" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt20" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender21" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt20" TargetControlID="txt_statusdt20">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test21" runat="server" Text="Motor running current does not exceed f.l.c. and is balanced betwen phases"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status21" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig21" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt21" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender22" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt21" TargetControlID="txt_statusdt21">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px"><asp:Label ID="lbl_test22" runat="server"  Text="Motor, fan and drive are free from undue noise"></asp:Label></td>
        <td>
            <asp:RadioButtonList ID="rd_status22" runat="server" 
                RepeatDirection="Horizontal">
            <asp:ListItem Text="&#10003;" Value="1"></asp:ListItem>
            <asp:ListItem Text="X" Value="2"></asp:ListItem>
            <asp:ListItem Text="na" Value="3"></asp:ListItem>
            </asp:RadioButtonList>
                                </td>
        <td>
            <asp:TextBox ID="txt_sig22" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
                                </td>
        <td>
            <asp:TextBox ID="txt_statusdt22" runat="server" Width="99%" CssClass="txtbox"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender23" runat="server" 
                                ClearTime="true" Format="dd/MM/yyyy" PopupButtonID="txt_statusdt22" TargetControlID="txt_statusdt22">
                            </asp:CalendarExtender>
                                </td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr style="background-color:#ffffff">
        <td style="width:575px">&nbsp;</td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="" Width="110px"></asp:Label>
                                </td>
        <td><asp:Label ID="Label3" runat="server" Text="" Width="90px"></asp:Label></td>
        <td><asp:Label ID="Label4" runat="server" Text="" Width="70px"></asp:Label></td>
        </tr>
        <tr style="background-color:#ffffff">
        <td colspan="4">
        <div style="width:100%">
        <div style="float:left">* <span style="font-family: Arial Unicode MS, Lucida Grande">&#10003;</span> = satisfactory, X = unsatisfactory, na = not applicable</div>
    <div style="float:right;padding:0 20px"><i>See also final inspection checklist</i></div>
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
