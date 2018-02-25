<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CasData_New.aspx.cs" Inherits="CmlTechniques.CasData_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
     <link href="page.css" rel="stylesheet" type="text/css" />
     <%--<link rel="stylesheet" id="shortcodescss" href="CMLT/Styles/accordin.css" type="text/css" media="all" />--%>
     <link rel="stylesheet" href="Accordion/fonts/font-awesome.css" type="text/css" />
     <link rel="stylesheet" href="Accordion/jquery.accordion.css" type="text/css" />
      <link rel="stylesheet" href="Acordion1/demo.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div>
            <asp:Repeater ID="main_" runat="server" onitemdatabound="main__ItemDataBound">
            <ItemTemplate>
                <%--<div  >
                <table>
                <tr>
                <td>
                    <asp:CheckBox ID="chk" runat="server" /></td>
                <td><asp:Label ID="lblsys_name" runat="server" Text='<%# Eval("sys_name") %>' /><asp:Label ID="lblsys_id" runat="server" Text='<%# Eval("sys_id") %>' CssClass="hidden" /></td>
                </tr>
                </table>
                </div>--%>
                <div >
                <div >
                    <asp:ListView ID="sub_" runat="server">
                    <ItemTemplate>
                    <tr style="background-color:#DCDCDC;color: #000000;">
                        <td>
                            <asp:Label ID="Cas_scheduleLabel" runat="server" 
                                Text='<%# Eval("Cas_schedule") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UidLabel" runat="server" Text='<%# Eval("Uid") %>' />
                        </td>
                        <td>
                            <asp:Label ID="C_idLabel" runat="server" Text='<%# Eval("C_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Sys_idLabel" runat="server" Text='<%# Eval("Sys_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="sys_nameLabel" runat="server" Text='<%# Eval("sys_name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="E_b_refLabel" runat="server" Text='<%# Eval("E_b_ref") %>' />
                        </td>
                        <td>
                            <asp:Label ID="B_ZLabel" runat="server" Text='<%# Eval("B_Z") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CatLabel" runat="server" Text='<%# Eval("Cat") %>' />
                        </td>
                        <td>
                            <asp:Label ID="F_LvlLabel" runat="server" Text='<%# Eval("F_Lvl") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DesLabel" runat="server" Text='<%# Eval("Des") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Sq_NoLabel" runat="server" Text='<%# Eval("Sq_No") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LocLabel" runat="server" Text='<%# Eval("Loc") %>' />
                        </td>
                        <td>
                            <asp:Label ID="P_P_toLabel" runat="server" Text='<%# Eval("P_P_to") %>' />
                        </td>
                        <td>
                            <asp:Label ID="F_fromLabel" runat="server" Text='<%# Eval("F_from") %>' />
                        </td>
                        <td>
                            <asp:Label ID="SubstationLabel" runat="server" 
                                Text='<%# Eval("Substation") %>' />
                        </td>
                        <td>
                            <asp:Label ID="S_c_mLabel" runat="server" Text='<%# Eval("S_c_m") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Pwr_onLabel" runat="server" Text='<%# Eval("Pwr_on") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Con_AcceLabel" runat="server" Text='<%# Eval("Con_Acce") %>' />
                        </td>
                        <td>
                            <asp:Label ID="T_S_FiledLabel" runat="server" Text='<%# Eval("T_S_Filed") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CommLabel" runat="server" Text='<%# Eval("Comm") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Act_byLabel" runat="server" Text='<%# Eval("Act_by") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Act_DateLabel" runat="server" Text='<%# Eval("Act_Date") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Seq_NoLabel" runat="server" Text='<%# Eval("Seq_No") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PositionLabel" runat="server" Text='<%# Eval("Position") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TestSheetLabel" runat="server" Text='<%# Eval("TestSheet") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices1Label" runat="server" Text='<%# Eval("devices1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices2Label" runat="server" Text='<%# Eval("devices2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices3Label" runat="server" Text='<%# Eval("devices3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test1Label" runat="server" Text='<%# Eval("test1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test2Label" runat="server" Text='<%# Eval("test2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test3Label" runat="server" Text='<%# Eval("test3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test4Label" runat="server" Text='<%# Eval("test4") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test5Label" runat="server" Text='<%# Eval("test5") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test6Label" runat="server" Text='<%# Eval("test6") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test7Label" runat="server" Text='<%# Eval("test7") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test8Label" runat="server" Text='<%# Eval("test8") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test9Label" runat="server" Text='<%# Eval("test9") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test10Label" runat="server" Text='<%# Eval("test10") %>' />
                        </td>
                        <td>
                            <asp:Label ID="tested1Label" runat="server" Text='<%# Eval("tested1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="completeLabel" runat="server" Text='<%# Eval("complete") %>' />
                        </td>
                        <td>
                            <asp:Label ID="tested2Label" runat="server" Text='<%# Eval("tested2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com1Label" runat="server" Text='<%# Eval("per_com1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com2Label" runat="server" Text='<%# Eval("per_com2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com3Label" runat="server" Text='<%# Eval("per_com3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test11Label" runat="server" Text='<%# Eval("test11") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test12Label" runat="server" Text='<%# Eval("test12") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test13Label" runat="server" Text='<%# Eval("test13") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test14Label" runat="server" Text='<%# Eval("test14") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test15Label" runat="server" Text='<%# Eval("test15") %>' />
                        </td>
                        <td>
                            <asp:Label ID="accept1Label" runat="server" Text='<%# Eval("accept1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="accept2Label" runat="server" Text='<%# Eval("accept2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="filed1Label" runat="server" Text='<%# Eval("filed1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="filed2Label" runat="server" Text='<%# Eval("filed2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com4Label" runat="server" Text='<%# Eval("per_com4") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com5Label" runat="server" Text='<%# Eval("per_com5") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com6Label" runat="server" Text='<%# Eval("per_com6") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com7Label" runat="server" Text='<%# Eval("per_com7") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com8Label" runat="server" Text='<%# Eval("per_com8") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com9Label" runat="server" Text='<%# Eval("per_com9") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com10Label" runat="server" Text='<%# Eval("per_com10") %>' />
                        </td>
                        <td>
                            <asp:Label ID="possitionLabel" runat="server" Text='<%# Eval("possition") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr style="background-color:#FFF8DC;">
                        <td>
                            <asp:Label ID="Cas_scheduleLabel" runat="server" 
                                Text='<%# Eval("Cas_schedule") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UidLabel" runat="server" Text='<%# Eval("Uid") %>' />
                        </td>
                        <td>
                            <asp:Label ID="C_idLabel" runat="server" Text='<%# Eval("C_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Sys_idLabel" runat="server" Text='<%# Eval("Sys_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="sys_nameLabel" runat="server" Text='<%# Eval("sys_name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="E_b_refLabel" runat="server" Text='<%# Eval("E_b_ref") %>' />
                        </td>
                        <td>
                            <asp:Label ID="B_ZLabel" runat="server" Text='<%# Eval("B_Z") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CatLabel" runat="server" Text='<%# Eval("Cat") %>' />
                        </td>
                        <td>
                            <asp:Label ID="F_LvlLabel" runat="server" Text='<%# Eval("F_Lvl") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DesLabel" runat="server" Text='<%# Eval("Des") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Sq_NoLabel" runat="server" Text='<%# Eval("Sq_No") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LocLabel" runat="server" Text='<%# Eval("Loc") %>' />
                        </td>
                        <td>
                            <asp:Label ID="P_P_toLabel" runat="server" Text='<%# Eval("P_P_to") %>' />
                        </td>
                        <td>
                            <asp:Label ID="F_fromLabel" runat="server" Text='<%# Eval("F_from") %>' />
                        </td>
                        <td>
                            <asp:Label ID="SubstationLabel" runat="server" 
                                Text='<%# Eval("Substation") %>' />
                        </td>
                        <td>
                            <asp:Label ID="S_c_mLabel" runat="server" Text='<%# Eval("S_c_m") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Pwr_onLabel" runat="server" Text='<%# Eval("Pwr_on") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Con_AcceLabel" runat="server" Text='<%# Eval("Con_Acce") %>' />
                        </td>
                        <td>
                            <asp:Label ID="T_S_FiledLabel" runat="server" Text='<%# Eval("T_S_Filed") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CommLabel" runat="server" Text='<%# Eval("Comm") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Act_byLabel" runat="server" Text='<%# Eval("Act_by") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Act_DateLabel" runat="server" Text='<%# Eval("Act_Date") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Seq_NoLabel" runat="server" Text='<%# Eval("Seq_No") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PositionLabel" runat="server" Text='<%# Eval("Position") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TestSheetLabel" runat="server" Text='<%# Eval("TestSheet") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices1Label" runat="server" Text='<%# Eval("devices1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices2Label" runat="server" Text='<%# Eval("devices2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices3Label" runat="server" Text='<%# Eval("devices3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test1Label" runat="server" Text='<%# Eval("test1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test2Label" runat="server" Text='<%# Eval("test2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test3Label" runat="server" Text='<%# Eval("test3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test4Label" runat="server" Text='<%# Eval("test4") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test5Label" runat="server" Text='<%# Eval("test5") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test6Label" runat="server" Text='<%# Eval("test6") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test7Label" runat="server" Text='<%# Eval("test7") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test8Label" runat="server" Text='<%# Eval("test8") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test9Label" runat="server" Text='<%# Eval("test9") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test10Label" runat="server" Text='<%# Eval("test10") %>' />
                        </td>
                        <td>
                            <asp:Label ID="tested1Label" runat="server" Text='<%# Eval("tested1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="completeLabel" runat="server" Text='<%# Eval("complete") %>' />
                        </td>
                        <td>
                            <asp:Label ID="tested2Label" runat="server" Text='<%# Eval("tested2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com1Label" runat="server" Text='<%# Eval("per_com1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com2Label" runat="server" Text='<%# Eval("per_com2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com3Label" runat="server" Text='<%# Eval("per_com3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test11Label" runat="server" Text='<%# Eval("test11") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test12Label" runat="server" Text='<%# Eval("test12") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test13Label" runat="server" Text='<%# Eval("test13") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test14Label" runat="server" Text='<%# Eval("test14") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test15Label" runat="server" Text='<%# Eval("test15") %>' />
                        </td>
                        <td>
                            <asp:Label ID="accept1Label" runat="server" Text='<%# Eval("accept1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="accept2Label" runat="server" Text='<%# Eval("accept2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="filed1Label" runat="server" Text='<%# Eval("filed1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="filed2Label" runat="server" Text='<%# Eval("filed2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com4Label" runat="server" Text='<%# Eval("per_com4") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com5Label" runat="server" Text='<%# Eval("per_com5") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com6Label" runat="server" Text='<%# Eval("per_com6") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com7Label" runat="server" Text='<%# Eval("per_com7") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com8Label" runat="server" Text='<%# Eval("per_com8") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com9Label" runat="server" Text='<%# Eval("per_com9") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com10Label" runat="server" Text='<%# Eval("per_com10") %>' />
                        </td>
                        <td>
                            <asp:Label ID="possitionLabel" runat="server" Text='<%# Eval("possition") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                    </asp:ListView>
                </div>
                </div>
            </ItemTemplate>
            </asp:Repeater>
            <%--<asp:ListView ID="ListView1" runat="server" DataKeyNames="C_id" 
                DataSourceID="ObjectDataSource1">
                
                <EmptyDataTemplate>
                    <table runat="server" 
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
                            <asp:TextBox ID="Cas_scheduleTextBox" runat="server" 
                                Text='<%# Bind("Cas_schedule") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="UidTextBox" runat="server" Text='<%# Bind("Uid") %>' />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="Sys_idTextBox" runat="server" Text='<%# Bind("Sys_id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="sys_nameTextBox" runat="server" 
                                Text='<%# Bind("sys_name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="E_b_refTextBox" runat="server" Text='<%# Bind("E_b_ref") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="B_ZTextBox" runat="server" Text='<%# Bind("B_Z") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CatTextBox" runat="server" Text='<%# Bind("Cat") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="F_LvlTextBox" runat="server" Text='<%# Bind("F_Lvl") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DesTextBox" runat="server" Text='<%# Bind("Des") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Sq_NoTextBox" runat="server" Text='<%# Bind("Sq_No") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="LocTextBox" runat="server" Text='<%# Bind("Loc") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="P_P_toTextBox" runat="server" Text='<%# Bind("P_P_to") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="F_fromTextBox" runat="server" Text='<%# Bind("F_from") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="SubstationTextBox" runat="server" 
                                Text='<%# Bind("Substation") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="S_c_mTextBox" runat="server" Text='<%# Bind("S_c_m") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Pwr_onTextBox" runat="server" Text='<%# Bind("Pwr_on") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Con_AcceTextBox" runat="server" 
                                Text='<%# Bind("Con_Acce") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="T_S_FiledTextBox" runat="server" 
                                Text='<%# Bind("T_S_Filed") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CommTextBox" runat="server" Text='<%# Bind("Comm") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Act_byTextBox" runat="server" Text='<%# Bind("Act_by") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Act_DateTextBox" runat="server" 
                                Text='<%# Bind("Act_Date") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Seq_NoTextBox" runat="server" Text='<%# Bind("Seq_No") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PositionTextBox" runat="server" 
                                Text='<%# Bind("Position") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TestSheetTextBox" runat="server" 
                                Text='<%# Bind("TestSheet") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="devices1TextBox" runat="server" 
                                Text='<%# Bind("devices1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="devices2TextBox" runat="server" 
                                Text='<%# Bind("devices2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="devices3TextBox" runat="server" 
                                Text='<%# Bind("devices3") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test1TextBox" runat="server" Text='<%# Bind("test1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test2TextBox" runat="server" Text='<%# Bind("test2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test3TextBox" runat="server" Text='<%# Bind("test3") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test4TextBox" runat="server" Text='<%# Bind("test4") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test5TextBox" runat="server" Text='<%# Bind("test5") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test6TextBox" runat="server" Text='<%# Bind("test6") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test7TextBox" runat="server" Text='<%# Bind("test7") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test8TextBox" runat="server" Text='<%# Bind("test8") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test9TextBox" runat="server" Text='<%# Bind("test9") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test10TextBox" runat="server" Text='<%# Bind("test10") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="tested1TextBox" runat="server" Text='<%# Bind("tested1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="completeTextBox" runat="server" 
                                Text='<%# Bind("complete") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="tested2TextBox" runat="server" Text='<%# Bind("tested2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com1TextBox" runat="server" 
                                Text='<%# Bind("per_com1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com2TextBox" runat="server" 
                                Text='<%# Bind("per_com2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com3TextBox" runat="server" 
                                Text='<%# Bind("per_com3") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test11TextBox" runat="server" Text='<%# Bind("test11") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test12TextBox" runat="server" Text='<%# Bind("test12") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test13TextBox" runat="server" Text='<%# Bind("test13") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test14TextBox" runat="server" Text='<%# Bind("test14") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test15TextBox" runat="server" Text='<%# Bind("test15") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="accept1TextBox" runat="server" Text='<%# Bind("accept1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="accept2TextBox" runat="server" Text='<%# Bind("accept2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="filed1TextBox" runat="server" Text='<%# Bind("filed1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="filed2TextBox" runat="server" Text='<%# Bind("filed2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com4TextBox" runat="server" 
                                Text='<%# Bind("per_com4") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com5TextBox" runat="server" 
                                Text='<%# Bind("per_com5") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com6TextBox" runat="server" 
                                Text='<%# Bind("per_com6") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com7TextBox" runat="server" 
                                Text='<%# Bind("per_com7") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com8TextBox" runat="server" 
                                Text='<%# Bind("per_com8") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com9TextBox" runat="server" 
                                Text='<%# Bind("per_com9") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com10TextBox" runat="server" 
                                Text='<%# Bind("per_com10") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="possitionTextBox" runat="server" 
                                Text='<%# Bind("possition") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                        <th runat="server">
                                            Cas_schedule</th>
                                        <th runat="server">
                                            Uid</th>
                                        <th runat="server">
                                            C_id</th>
                                        <th runat="server">
                                            Sys_id</th>
                                        <th runat="server">
                                            sys_name</th>
                                        <th runat="server">
                                            E_b_ref</th>
                                        <th runat="server">
                                            B_Z</th>
                                        <th runat="server">
                                            Cat</th>
                                        <th runat="server">
                                            F_Lvl</th>
                                        <th runat="server">
                                            Des</th>
                                        <th runat="server">
                                            Sq_No</th>
                                        <th runat="server">
                                            Loc</th>
                                        <th runat="server">
                                            P_P_to</th>
                                        <th runat="server">
                                            F_from</th>
                                        <th runat="server">
                                            Substation</th>
                                        <th runat="server">
                                            S_c_m</th>
                                        <th runat="server">
                                            Pwr_on</th>
                                        <th runat="server">
                                            Con_Acce</th>
                                        <th runat="server">
                                            T_S_Filed</th>
                                        <th runat="server">
                                            Comm</th>
                                        <th runat="server">
                                            Act_by</th>
                                        <th runat="server">
                                            Act_Date</th>
                                        <th runat="server">
                                            Seq_No</th>
                                        <th runat="server">
                                            Position</th>
                                        <th runat="server">
                                            TestSheet</th>
                                        <th runat="server">
                                            devices1</th>
                                        <th runat="server">
                                            devices2</th>
                                        <th runat="server">
                                            devices3</th>
                                        <th runat="server">
                                            test1</th>
                                        <th runat="server">
                                            test2</th>
                                        <th runat="server">
                                            test3</th>
                                        <th runat="server">
                                            test4</th>
                                        <th runat="server">
                                            test5</th>
                                        <th runat="server">
                                            test6</th>
                                        <th runat="server">
                                            test7</th>
                                        <th runat="server">
                                            test8</th>
                                        <th runat="server">
                                            test9</th>
                                        <th runat="server">
                                            test10</th>
                                        <th runat="server">
                                            tested1</th>
                                        <th runat="server">
                                            complete</th>
                                        <th runat="server">
                                            tested2</th>
                                        <th runat="server">
                                            per_com1</th>
                                        <th runat="server">
                                            per_com2</th>
                                        <th runat="server">
                                            per_com3</th>
                                        <th runat="server">
                                            test11</th>
                                        <th runat="server">
                                            test12</th>
                                        <th runat="server">
                                            test13</th>
                                        <th runat="server">
                                            test14</th>
                                        <th runat="server">
                                            test15</th>
                                        <th runat="server">
                                            accept1</th>
                                        <th runat="server">
                                            accept2</th>
                                        <th runat="server">
                                            filed1</th>
                                        <th runat="server">
                                            filed2</th>
                                        <th runat="server">
                                            per_com4</th>
                                        <th runat="server">
                                            per_com5</th>
                                        <th runat="server">
                                            per_com6</th>
                                        <th runat="server">
                                            per_com7</th>
                                        <th runat="server">
                                            per_com8</th>
                                        <th runat="server">
                                            per_com9</th>
                                        <th runat="server">
                                            per_com10</th>
                                        <th runat="server">
                                            possition</th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" 
                                style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <EditItemTemplate>
                    <tr style="background-color:#008A8C;color: #FFFFFF;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                Text="Cancel" />
                        </td>
                        <td>
                            <asp:TextBox ID="Cas_scheduleTextBox" runat="server" 
                                Text='<%# Bind("Cas_schedule") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="UidTextBox" runat="server" Text='<%# Bind("Uid") %>' />
                        </td>
                        <td>
                            <asp:Label ID="C_idLabel1" runat="server" Text='<%# Eval("C_id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Sys_idTextBox" runat="server" Text='<%# Bind("Sys_id") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="sys_nameTextBox" runat="server" 
                                Text='<%# Bind("sys_name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="E_b_refTextBox" runat="server" Text='<%# Bind("E_b_ref") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="B_ZTextBox" runat="server" Text='<%# Bind("B_Z") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CatTextBox" runat="server" Text='<%# Bind("Cat") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="F_LvlTextBox" runat="server" Text='<%# Bind("F_Lvl") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="DesTextBox" runat="server" Text='<%# Bind("Des") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Sq_NoTextBox" runat="server" Text='<%# Bind("Sq_No") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="LocTextBox" runat="server" Text='<%# Bind("Loc") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="P_P_toTextBox" runat="server" Text='<%# Bind("P_P_to") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="F_fromTextBox" runat="server" Text='<%# Bind("F_from") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="SubstationTextBox" runat="server" 
                                Text='<%# Bind("Substation") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="S_c_mTextBox" runat="server" Text='<%# Bind("S_c_m") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Pwr_onTextBox" runat="server" Text='<%# Bind("Pwr_on") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Con_AcceTextBox" runat="server" 
                                Text='<%# Bind("Con_Acce") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="T_S_FiledTextBox" runat="server" 
                                Text='<%# Bind("T_S_Filed") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="CommTextBox" runat="server" Text='<%# Bind("Comm") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Act_byTextBox" runat="server" Text='<%# Bind("Act_by") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Act_DateTextBox" runat="server" 
                                Text='<%# Bind("Act_Date") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="Seq_NoTextBox" runat="server" Text='<%# Bind("Seq_No") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="PositionTextBox" runat="server" 
                                Text='<%# Bind("Position") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TestSheetTextBox" runat="server" 
                                Text='<%# Bind("TestSheet") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="devices1TextBox" runat="server" 
                                Text='<%# Bind("devices1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="devices2TextBox" runat="server" 
                                Text='<%# Bind("devices2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="devices3TextBox" runat="server" 
                                Text='<%# Bind("devices3") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test1TextBox" runat="server" Text='<%# Bind("test1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test2TextBox" runat="server" Text='<%# Bind("test2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test3TextBox" runat="server" Text='<%# Bind("test3") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test4TextBox" runat="server" Text='<%# Bind("test4") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test5TextBox" runat="server" Text='<%# Bind("test5") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test6TextBox" runat="server" Text='<%# Bind("test6") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test7TextBox" runat="server" Text='<%# Bind("test7") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test8TextBox" runat="server" Text='<%# Bind("test8") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test9TextBox" runat="server" Text='<%# Bind("test9") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test10TextBox" runat="server" Text='<%# Bind("test10") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="tested1TextBox" runat="server" Text='<%# Bind("tested1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="completeTextBox" runat="server" 
                                Text='<%# Bind("complete") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="tested2TextBox" runat="server" Text='<%# Bind("tested2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com1TextBox" runat="server" 
                                Text='<%# Bind("per_com1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com2TextBox" runat="server" 
                                Text='<%# Bind("per_com2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com3TextBox" runat="server" 
                                Text='<%# Bind("per_com3") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test11TextBox" runat="server" Text='<%# Bind("test11") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test12TextBox" runat="server" Text='<%# Bind("test12") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test13TextBox" runat="server" Text='<%# Bind("test13") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test14TextBox" runat="server" Text='<%# Bind("test14") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="test15TextBox" runat="server" Text='<%# Bind("test15") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="accept1TextBox" runat="server" Text='<%# Bind("accept1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="accept2TextBox" runat="server" Text='<%# Bind("accept2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="filed1TextBox" runat="server" Text='<%# Bind("filed1") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="filed2TextBox" runat="server" Text='<%# Bind("filed2") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com4TextBox" runat="server" 
                                Text='<%# Bind("per_com4") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com5TextBox" runat="server" 
                                Text='<%# Bind("per_com5") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com6TextBox" runat="server" 
                                Text='<%# Bind("per_com6") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com7TextBox" runat="server" 
                                Text='<%# Bind("per_com7") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com8TextBox" runat="server" 
                                Text='<%# Bind("per_com8") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com9TextBox" runat="server" 
                                Text='<%# Bind("per_com9") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="per_com10TextBox" runat="server" 
                                Text='<%# Bind("per_com10") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="possitionTextBox" runat="server" 
                                Text='<%# Bind("possition") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                        <td>
                            <asp:Label ID="Cas_scheduleLabel" runat="server" 
                                Text='<%# Eval("Cas_schedule") %>' />
                        </td>
                        <td>
                            <asp:Label ID="UidLabel" runat="server" Text='<%# Eval("Uid") %>' />
                        </td>
                        <td>
                            <asp:Label ID="C_idLabel" runat="server" Text='<%# Eval("C_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Sys_idLabel" runat="server" Text='<%# Eval("Sys_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="sys_nameLabel" runat="server" Text='<%# Eval("sys_name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="E_b_refLabel" runat="server" Text='<%# Eval("E_b_ref") %>' />
                        </td>
                        <td>
                            <asp:Label ID="B_ZLabel" runat="server" Text='<%# Eval("B_Z") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CatLabel" runat="server" Text='<%# Eval("Cat") %>' />
                        </td>
                        <td>
                            <asp:Label ID="F_LvlLabel" runat="server" Text='<%# Eval("F_Lvl") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DesLabel" runat="server" Text='<%# Eval("Des") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Sq_NoLabel" runat="server" Text='<%# Eval("Sq_No") %>' />
                        </td>
                        <td>
                            <asp:Label ID="LocLabel" runat="server" Text='<%# Eval("Loc") %>' />
                        </td>
                        <td>
                            <asp:Label ID="P_P_toLabel" runat="server" Text='<%# Eval("P_P_to") %>' />
                        </td>
                        <td>
                            <asp:Label ID="F_fromLabel" runat="server" Text='<%# Eval("F_from") %>' />
                        </td>
                        <td>
                            <asp:Label ID="SubstationLabel" runat="server" 
                                Text='<%# Eval("Substation") %>' />
                        </td>
                        <td>
                            <asp:Label ID="S_c_mLabel" runat="server" Text='<%# Eval("S_c_m") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Pwr_onLabel" runat="server" Text='<%# Eval("Pwr_on") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Con_AcceLabel" runat="server" Text='<%# Eval("Con_Acce") %>' />
                        </td>
                        <td>
                            <asp:Label ID="T_S_FiledLabel" runat="server" Text='<%# Eval("T_S_Filed") %>' />
                        </td>
                        <td>
                            <asp:Label ID="CommLabel" runat="server" Text='<%# Eval("Comm") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Act_byLabel" runat="server" Text='<%# Eval("Act_by") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Act_DateLabel" runat="server" Text='<%# Eval("Act_Date") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Seq_NoLabel" runat="server" Text='<%# Eval("Seq_No") %>' />
                        </td>
                        <td>
                            <asp:Label ID="PositionLabel" runat="server" Text='<%# Eval("Position") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TestSheetLabel" runat="server" Text='<%# Eval("TestSheet") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices1Label" runat="server" Text='<%# Eval("devices1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices2Label" runat="server" Text='<%# Eval("devices2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="devices3Label" runat="server" Text='<%# Eval("devices3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test1Label" runat="server" Text='<%# Eval("test1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test2Label" runat="server" Text='<%# Eval("test2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test3Label" runat="server" Text='<%# Eval("test3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test4Label" runat="server" Text='<%# Eval("test4") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test5Label" runat="server" Text='<%# Eval("test5") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test6Label" runat="server" Text='<%# Eval("test6") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test7Label" runat="server" Text='<%# Eval("test7") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test8Label" runat="server" Text='<%# Eval("test8") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test9Label" runat="server" Text='<%# Eval("test9") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test10Label" runat="server" Text='<%# Eval("test10") %>' />
                        </td>
                        <td>
                            <asp:Label ID="tested1Label" runat="server" Text='<%# Eval("tested1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="completeLabel" runat="server" Text='<%# Eval("complete") %>' />
                        </td>
                        <td>
                            <asp:Label ID="tested2Label" runat="server" Text='<%# Eval("tested2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com1Label" runat="server" Text='<%# Eval("per_com1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com2Label" runat="server" Text='<%# Eval("per_com2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com3Label" runat="server" Text='<%# Eval("per_com3") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test11Label" runat="server" Text='<%# Eval("test11") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test12Label" runat="server" Text='<%# Eval("test12") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test13Label" runat="server" Text='<%# Eval("test13") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test14Label" runat="server" Text='<%# Eval("test14") %>' />
                        </td>
                        <td>
                            <asp:Label ID="test15Label" runat="server" Text='<%# Eval("test15") %>' />
                        </td>
                        <td>
                            <asp:Label ID="accept1Label" runat="server" Text='<%# Eval("accept1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="accept2Label" runat="server" Text='<%# Eval("accept2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="filed1Label" runat="server" Text='<%# Eval("filed1") %>' />
                        </td>
                        <td>
                            <asp:Label ID="filed2Label" runat="server" Text='<%# Eval("filed2") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com4Label" runat="server" Text='<%# Eval("per_com4") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com5Label" runat="server" Text='<%# Eval("per_com5") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com6Label" runat="server" Text='<%# Eval("per_com6") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com7Label" runat="server" Text='<%# Eval("per_com7") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com8Label" runat="server" Text='<%# Eval("per_com8") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com9Label" runat="server" Text='<%# Eval("per_com9") %>' />
                        </td>
                        <td>
                            <asp:Label ID="per_com10Label" runat="server" Text='<%# Eval("per_com10") %>' />
                        </td>
                        <td>
                            <asp:Label ID="possitionLabel" runat="server" Text='<%# Eval("possition") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                TypeName="CmlTechniques.CAS.casdataASAOTableAdapters.Load_CasDataTableAdapter">
            </asp:ObjectDataSource>--%>
        </div>
    </div>
        <SCRIPT src="Acordion1/jquery.min.js" type="text/javascript"></SCRIPT>
 
<SCRIPT src="Acordion1/highlight.pack.js" type="text/javascript"></SCRIPT>
 
<SCRIPT src="Acordion1/jquery.cookie.js" type="text/javascript"></SCRIPT>
 
<%--<SCRIPT src="Acordion1/jquery.accordion.js" type="text/javascript"></SCRIPT>--%>
 <script type="text/javascript" src="Acordion1/jquery.collapsible.js"></script>
<script type="text/javascript">

    $(document).ready(function() {

        //syntax highlighter
        hljs.tabReplace = '    ';
        hljs.initHighlightingOnLoad();

        $.fn.slideFadeToggle = function(speed, easing, callback) {
            return this.animate({ opacity: 'toggle', height: 'toggle' }, speed, easing, callback);
        };

        //collapsible management
        $('.collapsible').collapsible({
            defaultOpen: 'section1',
            cookieName: 'nav',
            speed: 'slow',
            animateOpen: function(elem, opts) { //replace the standard slideUp with custom function
                elem.next().slideFadeToggle(opts.speed);
            },
            animateClose: function(elem, opts) { //replace the standard slideDown with custom function
                elem.next().slideFadeToggle(opts.speed);
            },
            loadOpen: function(elem) { //replace the standard open state with custom function
                elem.next().show();
            },
            loadClose: function(elem, opts) { //replace the close state with custom function
                elem.next().hide();
            }
        });
        $('.page_collapsible').collapsible({
            defaultOpen: 'body_section1',
            cookieName: 'body2',
            speed: 'slow',
            animateOpen: function(elem, opts) { //replace the standard slideUp with custom function
                elem.next().slideFadeToggle(opts.speed);
            },
            animateClose: function(elem, opts) { //replace the standard slideDown with custom function
                elem.next().slideFadeToggle(opts.speed);
            },
            loadOpen: function(elem) { //replace the standard open state with custom function
                elem.next().show();
            },
            loadClose: function(elem, opts) { //replace the close state with custom function
                elem.next().hide();
            }

        });

        //assign open/close all to functions
        function openAll() {
            $('.collapsible').collapsible('openAll');
        }
        function closeAll() {
            $('.collapsible').collapsible('closeAll');
        }

        //listen for close/open all
        $('#closeAll').click(function(event) {
            event.preventDefault();
            closeAll();

        });
        $('#openAll').click(function(event) {
            event.preventDefault();
            openAll();
        });

    });
</SCRIPT>
    </form>
</body>
</html>
