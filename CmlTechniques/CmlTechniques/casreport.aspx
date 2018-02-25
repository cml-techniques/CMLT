<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="casreport.aspx.cs" Inherits="CmlTechniques.casreport" %>
<%@ Register Assembly="BasicFrame.WebControls.BasicDatePicker" Namespace="BasicFrame.WebControls"
    TagPrefix="BDP" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
        <link href="page.css" rel="stylesheet" type="text/css" />
</head>
<script language="javascript" type="text/javascript">
    function CallPrint(strid) {

        var headstr = "<html><head><title>CML Techniques Reports</title></head><body>";

        var footstr = "</body></html>"

        var WinPrint = window.open('', '', 'left=150,top=150,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0');

        WinPrint.document.write(headstr + strid.innerHTML + footstr);

        WinPrint.document.close();

        WinPrint.focus();

        WinPrint.print();
    }
    
    </script>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <table style="font-family: verdana; font-size: x-small; width: 100%; height: 100%">
            <tr>
                <td valign="top">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Button ID="export" runat="server" Text="Export to Excel" 
                        Font-Names="Verdana" Font-Size="X-Small" onclick="export_Click" />
                    <asp:Button ID="print" runat="server" Text="Print" Font-Names="Verdana" 
                        Font-Size="X-Small" OnClientClick ="javascript:CallPrint(forPrint);" 
                        onclick="print_Click"/>                           </td>
            </tr>
            <tr>
                <td valign="top">
                <div id="forPrint" runat="server">
                    <asp:ListView ID="myview" runat="server" style="width:100%" 
                        DataKeyNames="cas_id,itm_no"  >
                        <ItemTemplate>
                            <tr style="background-color: #F7F6F3;color: #333333;">
                                <td>
                                    <asp:Label ID="cas_idLabel" runat="server" Text='<%# Eval("cas_id") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="itm_noLabel" runat="server" Text='<%# Eval("itm_no") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("sys_name") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="reff_Label" runat="server" Text='<%# Eval("reff_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("cate_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("b_zone") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("f_level") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("seq_no") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="desc_Label" runat="server" Text='<%# Eval("desc_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="loca_Label" runat="server" Text='<%# Eval("loca_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="p_power_toLabel" runat="server" Text='<%# Eval("p_power_to") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="fed_fromLabel" runat="server" Text='<%# Eval("fed_from") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="power_onLabel" runat="server" Text='<%# Eval("power_on") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="torque_Label" runat="server" Text='<%# Eval("torque_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ir_Label" runat="server" Text='<%# Eval("ir_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="pressure_Label" runat="server" Text='<%# Eval("pressure_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sec_injection_Label" runat="server" 
                                        Text='<%# Eval("sec_injection_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="con_resistance_Label" runat="server" 
                                        Text='<%# Eval("con_resistance_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="functional_Label" runat="server" 
                                        Text='<%# Eval("functional_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="devicesLabel" runat="server" Text='<%# Eval("devices") %>' />
                                </td>
                                
                                
                                <td>
                                    <asp:Label ID="ttl_cold_testedLabel" runat="server" 
                                        Text='<%# Eval("ttl_cold_tested") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="cold_completeLabel" runat="server" 
                                        Text='<%# Eval("cold_complete") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ttl_live_testedLabel" runat="server" 
                                        Text='<%# Eval("ttl_live_tested") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="live_completeLabel" runat="server" 
                                        Text='<%# Eval("live_complete") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="con_acceLabel" runat="server" Text='<%# Eval("con_acce") %>' />
                                </td>
                                <td>
                                   <%-- <asp:CheckBox ID="filedCheckBox" runat="server" Checked='<%# Eval("filed") %>' 
                                        Enabled="false" />--%>
                                </td>
                                <td>
                                    <asp:Label ID="comm_Label" runat="server" Text='<%# Eval("comm_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="act_byLabel" runat="server" Text='<%# Eval("act_by") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="act_dateLabel" runat="server" Text='<%# Eval("act_date") %>' />
                                </td>
                                                        
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #FFFFFF;color: #284775;">
                            <td>
                                    <asp:Label ID="cas_idLabel" runat="server" Text='<%# Eval("cas_id") %>' />
                                </td>
                            <td>
                                    <asp:Label ID="itm_noLabel" runat="server" Text='<%# Eval("itm_no") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("sys_name") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="reff_Label" runat="server" Text='<%# Eval("reff_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("cate_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("b_zone") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("f_level") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("seq_no") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="desc_Label" runat="server" Text='<%# Eval("desc_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="loca_Label" runat="server" Text='<%# Eval("loca_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="p_power_toLabel" runat="server" Text='<%# Eval("p_power_to") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="fed_fromLabel" runat="server" Text='<%# Eval("fed_from") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="power_onLabel" runat="server" Text='<%# Eval("power_on") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="torque_Label" runat="server" Text='<%# Eval("torque_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ir_Label" runat="server" Text='<%# Eval("ir_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="pressure_Label" runat="server" Text='<%# Eval("pressure_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sec_injection_Label" runat="server" 
                                        Text='<%# Eval("sec_injection_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="con_resistance_Label" runat="server" 
                                        Text='<%# Eval("con_resistance_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="functional_Label" runat="server" 
                                        Text='<%# Eval("functional_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="devicesLabel" runat="server" Text='<%# Eval("devices") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ttl_cold_testedLabel" runat="server" 
                                        Text='<%# Eval("ttl_cold_tested") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="cold_completeLabel" runat="server" 
                                        Text='<%# Eval("cold_complete") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ttl_live_testedLabel" runat="server" 
                                        Text='<%# Eval("ttl_live_tested") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="live_completeLabel" runat="server" 
                                        Text='<%# Eval("live_complete") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="con_acceLabel" runat="server" Text='<%# Eval("con_acce") %>' />
                                </td>
                                <td>
                                    <%--<asp:CheckBox ID="filedCheckBox" runat="server" Checked='<%# Eval("filed") %>' 
                                        Enabled="false" />--%>
                                </td>
                                <td>
                                    <asp:Label ID="comm_Label" runat="server" Text='<%# Eval("comm_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="act_byLabel" runat="server" Text='<%# Eval("act_by") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="act_dateLabel" runat="server" Text='<%# Eval("act_date") %>' />
                                </td>
                                
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table id="Table1" runat="server" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                <tr>
                                    <td>
                                        No data was returned.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <InsertItemTemplate>
                            <tr style="">
                                <td>
                                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                        Text="Insert" />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                        Text="Clear" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="itm_noTextBox" runat="server" Text='<%# Bind("itm_no") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="reff_TextBox" runat="server" Text='<%# Bind("reff_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="desc_TextBox" runat="server" Text='<%# Bind("desc_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="loca_TextBox" runat="server" Text='<%# Bind("loca_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="p_power_toTextBox" runat="server" 
                                        Text='<%# Bind("p_power_to") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="fed_fromTextBox" runat="server" 
                                        Text='<%# Bind("fed_from") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="power_onTextBox" runat="server" 
                                        Text='<%# Bind("power_on") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="comm_TextBox" runat="server" Text='<%# Bind("comm_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="act_byTextBox" runat="server" Text='<%# Bind("act_by") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="act_dateTextBox" runat="server" 
                                        Text='<%# Bind("act_date") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="uidTextBox" runat="server" Text='<%# Bind("uid") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="date_TextBox" runat="server" Text='<%# Bind("date_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="srv_idTextBox" runat="server" Text='<%# Bind("srv_id") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="sch_idTextBox" runat="server" Text='<%# Bind("sch_id") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="prj_codeTextBox" runat="server" 
                                        Text='<%# Bind("prj_code") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="con_acceTextBox" runat="server" 
                                        Text='<%# Bind("con_acce") %>' />
                                </td>
                                <td>
                                    <asp:CheckBox ID="filedCheckBox" runat="server" 
                                        Checked='<%# Bind("filed") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="des_volTextBox" runat="server" Text='<%# Bind("des_vol") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="des_flow_rateTextBox" runat="server" 
                                        Text='<%# Bind("des_flow_rate") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="devicesTextBox" runat="server" Text='<%# Bind("devices") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="sys_monitoredTextBox" runat="server" 
                                        Text='<%# Bind("sys_monitored") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="fa_interfacesTextBox" runat="server" 
                                        Text='<%# Bind("fa_interfaces") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="cate_TextBox" runat="server" Text='<%# Bind("cate_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="b_zoneTextBox" runat="server" Text='<%# Bind("b_zone") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="f_levelTextBox" runat="server" Text='<%# Bind("f_level") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="seq_noTextBox" runat="server" Text='<%# Bind("seq_no") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="sys_idTextBox" runat="server" Text='<%# Bind("sys_id") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="sys_nameTextBox" runat="server" 
                                        Text='<%# Bind("sys_name") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="torque_TextBox" runat="server" Text='<%# Bind("torque_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ir_TextBox" runat="server" Text='<%# Bind("ir_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="pressure_TextBox" runat="server" 
                                        Text='<%# Bind("pressure_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="sec_injection_TextBox" runat="server" 
                                        Text='<%# Bind("sec_injection_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="con_resistance_TextBox" runat="server" 
                                        Text='<%# Bind("con_resistance_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="functional_TextBox" runat="server" 
                                        Text='<%# Bind("functional_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="completed_TextBox" runat="server" 
                                        Text='<%# Bind("completed_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ttl_cold_testedTextBox" runat="server" 
                                        Text='<%# Bind("ttl_cold_tested") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="cold_completeTextBox" runat="server" 
                                        Text='<%# Bind("cold_complete") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ttl_live_testedTextBox" runat="server" 
                                        Text='<%# Bind("ttl_live_tested") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="live_completeTextBox" runat="server" 
                                        Text='<%# Bind("live_complete") %>' />
                                </td>
                            </tr>
                        </InsertItemTemplate>
                        <LayoutTemplate>
                            <table id="Table2" runat="server">
                                <tr id="Tr1" runat="server">
                                    <td id="Td1" runat="server">
                                        <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                            style="background-color: #5D7B9D;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            <tr id="Tr2" runat="server" >
                                            <td align="center" rowspan="2" valign="middle" style="width:50px" >
                                </td>
                                            <td align="center" rowspan="2" valign="middle" style="width:50px" >
                                ITM_NO</td>
                            <td align="center" rowspan="2" valign="middle">
                                PACKAGE</td>
                            <td align="center" rowspan="2" valign="middle" style="width:50px">
                                ENGG.REFF</td>
                            <td align="center" colspan="4" valign="middle">
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle">
                                DESCRIPTION</td>
                            <td align="center" rowspan="2" valign="middle">
                                LOCATION</td>
                            <td align="center" rowspan="2" valign="middle">
                                PROVIDE POWER TO</td>
                            <td align="center" rowspan="2" valign="middle">
                                FED FROM</td>
                            <td align="center" rowspan="2" valign="middle">
                                ACTUAL POWER ON</td>                            
                            <td align="center" valign="middle" colspan="6">
                                PLANT/EQUIPMENT TESTING</td>                            
                            <td align="center" valign="middle" colspan="5">
                                OUTGOING CIRCUITS TESTING</td>                            
                            <td align="center" valign="middle" colspan="2">
                                FINAL TEST SHEETS</td>                            
                            <td align="center" valign="middle" rowspan="2">
                                COMMENTS</td>                            
                            <td align="center" valign="middle" rowspan="2">
                                ACTION BY</td>                            
                            <td align="center" valign="middle" rowspan="2">
                                ACTION DATE</td>                            
                        </tr>
                        <tr>
                            <td align="center" valign="middle" style="width:50px">
                                CATEGORY</td>
                            <td align="center" valign="middle" style="width:50px">
                                BUILDING/ ZONE</td>
                            <td align="center" valign="middle" style="width:50px">
                                FLOOR LEVEL</td>
                            <td align="center" valign="middle" style="width:50px">
                                SEQ.NO</td>
                            <td align="center" valign="middle">
                                TORQUE TEST</td>                            
                            <td align="center" valign="middle">
                                IR TEST</td>                            
                            <td align="center" valign="middle">
                                PRESSURE TEST</td>                            
                            <td align="center" valign="middle" >
                                SECONDARY INJECTIONTEST</td>                            
                            <td align="center" valign="middle">
                                CONTACT RESISTANCE</td>                            
                            <td>
                                FUNCTIONAL TEST</td>
                            <td>
                                TOTAL NO.OF CIRCUITS</td>
                            <td>
                                TOTAL COLD TESTED</td>
                            <td>
                                COLD TEST COMPLETE</td>
                            <td>
                                TOTAL LIVE TESTED</td>
                            <td>
                                LIVE TEST COMPLETE</td>
                            <td>
                                CONSULTANT ACCEPTED</td>
                            <td>
                                TEST SHEETS FILED</td>
                        </tr>
                                            
                                            <tr ID="itemPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="Tr3" runat="server">
                                    <td id="Td2" runat="server" 
                                        style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                    </td>
                                </tr>
                                
                            </table>
                        </LayoutTemplate>
                        <EditItemTemplate>
                            <tr style="background-color: #999999;">
                            <td>
                                    <asp:Label ID="cas_idLabel" runat="server" Text='<%# Eval("cas_id") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="itm_noLabel1" runat="server" Text='<%# Eval("itm_no") %>' />
                                </td>
                                <td>
                                    <%--<asp:Label ID="cas_idLabel1" runat="server" Text='<%# Eval("cas_id") %>' />--%>
                                    <asp:DropDownList ID="drsrv" runat="server" DataSourceID="SqlDataSource2" DataTextField="sys_name" DataValueField="sys_id" SelectedValue= '<%# Eval("sys_id") %>'
  >
                                    </asp:DropDownList>
                                </td>
                                <td >
                                    <asp:TextBox ID="reff_TextBox" runat="server" Text='<%# Bind("reff_") %>' Width="50px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="cate_TextBox" runat="server" Text='<%# Bind("cate_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="b_zoneTextBox" runat="server" Text='<%# Bind("b_zone") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="f_levelTextBox" runat="server" Text='<%# Bind("f_level") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="seq_noTextBox" runat="server" Text='<%# Bind("seq_no") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="desc_TextBox" runat="server" Text='<%# Bind("desc_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="loca_TextBox" runat="server" Text='<%# Bind("loca_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="p_power_toTextBox" runat="server" 
                                        Text='<%# Bind("p_power_to") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="fed_fromTextBox" runat="server" 
                                        Text='<%# Bind("fed_from") %>' />
                                </td>
                                <td>
                                        <BDP:BasicDatePicker ID="dt_power_on" runat="server" SelectedDate='<%# Eval("power_on") %>' ></BDP:BasicDatePicker>
                                </td>
                                <td>
                                    <BDP:BasicDatePicker ID="dt_torque" runat="server" SelectedDate='<%# Eval("torque_") %>' ></BDP:BasicDatePicker>
                                </td>
                                <td>
                                    <BDP:BasicDatePicker ID="dt_ir" runat="server" SelectedDate='<%# Eval("ir_") %>' ></BDP:BasicDatePicker>
                                </td>
                                <td>
                                        <BDP:BasicDatePicker ID="dt_pressure" runat="server" SelectedDate='<%# Eval("pressure_") %>' ></BDP:BasicDatePicker>
                                </td>
                                <td>
                                <BDP:BasicDatePicker ID="dt_sec" runat="server" SelectedDate='<%# Eval("sec_injection_") %>' ></BDP:BasicDatePicker>
                                </td>
                                <td>
                                        <BDP:BasicDatePicker ID="dt_con" runat="server" SelectedDate='<%# Eval("con_resistance_") %>' ></BDP:BasicDatePicker>
                                </td>
                                <td>
                                        <BDP:BasicDatePicker ID="dt_fun" runat="server" SelectedDate='<%# Eval("functional_") %>' ></BDP:BasicDatePicker>
                                </td>
                                <td>
                                    <asp:TextBox ID="devicesTextBox" runat="server" Text='<%# Bind("devices") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ttl_cold_testedTextBox" runat="server" 
                                        Text='<%# Bind("ttl_cold_tested") %>' />
                                </td>
                                <td>
                                        <BDP:BasicDatePicker ID="dt_c_c" runat="server" SelectedDate='<%# Eval("cold_complete") %>' ></BDP:BasicDatePicker>
                                        
                                </td>
                                <td>
                                    <asp:TextBox ID="ttl_live_testedTextBox" runat="server" 
                                        Text='<%# Bind("ttl_live_tested") %>' />
                                        
                                </td>
                                <td>
                                        <BDP:BasicDatePicker ID="dt_l_c" runat="server" SelectedDate='<%# Eval("live_complete") %>' ></BDP:BasicDatePicker>
                                </td>
                                <td>
                                        <BDP:BasicDatePicker ID="dt_con_acc" runat="server" SelectedDate='<%# Eval("con_acce") %>' ></BDP:BasicDatePicker>
                                        
                                </td>
                                <td>
                                    <asp:CheckBox ID="filedCheckBox" runat="server" 
                                        Checked='<%# Bind("filed") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="comm_TextBox" runat="server" Text='<%# Bind("comm_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="act_byTextBox" runat="server" Text='<%# Bind("act_by") %>' />
                                </td>
                                <td>
                                        <BDP:BasicDatePicker ID="dt_act" runat="server" SelectedDate='<%# Eval("act_date") %>' ></BDP:BasicDatePicker>
                                </td>                           
                                <td>
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                        Text="Update" />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                        Text="Cancel" />
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <SelectedItemTemplate>
                            <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                                <td>
                                    <asp:Label ID="cas_idLabel" runat="server" Text='<%# Eval("cas_id") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="itm_noLabel" runat="server" Text='<%# Eval("itm_no") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="reff_Label" runat="server" Text='<%# Eval("reff_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="desc_Label" runat="server" Text='<%# Eval("desc_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="loca_Label" runat="server" Text='<%# Eval("loca_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="p_power_toLabel" runat="server" 
                                        Text='<%# Eval("p_power_to") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="fed_fromLabel" runat="server" Text='<%# Eval("fed_from") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="power_onLabel" runat="server" Text='<%# Eval("power_on") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="comm_Label" runat="server" Text='<%# Eval("comm_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="act_byLabel" runat="server" Text='<%# Eval("act_by") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="act_dateLabel" runat="server" Text='<%# Eval("act_date") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="date_Label" runat="server" Text='<%# Eval("date_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="srv_idLabel" runat="server" Text='<%# Eval("srv_id") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sch_idLabel" runat="server" Text='<%# Eval("sch_id") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="prj_codeLabel" runat="server" Text='<%# Eval("prj_code") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="con_acceLabel" runat="server" Text='<%# Eval("con_acce") %>' />
                                </td>
                                <%--<td>
                                    <asp:CheckBox ID="filedCheckBox" runat="server" Checked='<%# Eval("filed") %>' 
                                        Enabled="false" />
                                </td>--%>
                                <td>
                                    <asp:Label ID="des_volLabel" runat="server" Text='<%# Eval("des_vol") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="des_flow_rateLabel" runat="server" 
                                        Text='<%# Eval("des_flow_rate") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="devicesLabel" runat="server" Text='<%# Eval("devices") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sys_monitoredLabel" runat="server" 
                                        Text='<%# Eval("sys_monitored") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="fa_interfacesLabel" runat="server" 
                                        Text='<%# Eval("fa_interfaces") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="cate_Label" runat="server" Text='<%# Eval("cate_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="b_zoneLabel" runat="server" Text='<%# Eval("b_zone") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="f_levelLabel" runat="server" Text='<%# Eval("f_level") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="seq_noLabel" runat="server" Text='<%# Eval("seq_no") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sys_idLabel" runat="server" Text='<%# Eval("sys_id") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sys_nameLabel" runat="server" Text='<%# Eval("sys_name") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="torque_Label" runat="server" Text='<%# Eval("torque_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ir_Label" runat="server" Text='<%# Eval("ir_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="pressure_Label" runat="server" Text='<%# Eval("pressure_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sec_injection_Label" runat="server" 
                                        Text='<%# Eval("sec_injection_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="con_resistance_Label" runat="server" 
                                        Text='<%# Eval("con_resistance_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="functional_Label" runat="server" 
                                        Text='<%# Eval("functional_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="completed_Label" runat="server" 
                                        Text='<%# Eval("completed_") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ttl_cold_testedLabel" runat="server" 
                                        Text='<%# Eval("ttl_cold_tested") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="cold_completeLabel" runat="server" 
                                        Text='<%# Eval("cold_complete") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="ttl_live_testedLabel" runat="server" 
                                        Text='<%# Eval("ttl_live_tested") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="live_completeLabel" runat="server" 
                                        Text='<%# Eval("live_complete") %>' />
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                        
 
                    </asp:ListView>
                 </div>   
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                        SelectCommand="load_casMain" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="4" Name="sch_id" Type="Int32" />
                            <asp:Parameter DefaultValue="1" Name="prj_code" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                        SelectCommand="load_cms_cas_sys" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="4" Name="sch" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
