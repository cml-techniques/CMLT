<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="casinitialdata.aspx.cs" Inherits="CmlTechniques.casinitialdata" %>

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
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />        
        <table style="font-family: verdana; font-size: x-small; width: 100%; height: 100%">
            <tr>
                <td valign="top">
                    <asp:ListView ID="my_in_view" runat="server" DataKeyNames="cas_id,itm_no" 
                        InsertItemPosition="LastItem" style="width:100%" 
                        onitemcommand="my_in_view_ItemCommand" 
                        oniteminserting="my_in_view_ItemInserting1" 
                        ondatabound="my_in_view_DataBound" GroupItemCount="3">
                        <ItemTemplate>
                            <tr style="background-color: #F7F6F3;color: #333333;">
                                <%--<td>
                                    <asp:Label ID="cas_idLabel" runat="server" Text='<%# Eval("cas_id") %>' />
                                </td>--%>
                                <td>
                                    <asp:Label ID="itm_noLabel" runat="server" Text='<%# Eval("itm_no") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sys_idLabel" runat="server" Text='<%# Eval("sys_name") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="reff_Label" runat="server" Text='<%# Eval("reff_") %>' />
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
                                <%--<td>
                                    <asp:Label ID="power_onLabel" runat="server" Text='<%# Eval("power_on") %>' />
                                </td>--%>
                                <td>
                                    <asp:Label ID="devicesLabel" runat="server" Text='<%# Eval("devices") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #FFFFFF;color: #284775;">
                                <%--<td>
                                    <asp:Label ID="cas_idLabel" runat="server" Text='<%# Eval("cas_id") %>' />
                                </td>--%>
                                <td>
                                    <asp:Label ID="itm_noLabel" runat="server" Text='<%# Eval("itm_no") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="sys_idLabel" runat="server" Text='<%# Eval("sys_name") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="reff_Label" runat="server" Text='<%# Eval("reff_") %>' />
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
                                <%--<td>
                                    <asp:Label ID="power_onLabel" runat="server" Text='<%# Eval("power_on") %>' />
                                </td>--%>
                                <td>
                                    <asp:Label ID="devicesLabel" runat="server" Text='<%# Eval("devices") %>' />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
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
                            <tr style="background-color:#5D7B9D">
                                <td>
                                    <asp:Button ID="InsertButton1" runat="server" CommandName="Insert" 
                                        Text="Add" style="cursor:pointer" />                                    
                                </td>
                                <%--<td>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="itm_noTextBox" runat="server" Text='<%# Bind("itm_no") %>' />
                                </td>--%>
                                <td>
                                    <%--<asp:TextBox ID="sys_idTextBox" runat="server" Text='<%# Bind("sys_id") %>' />--%>
                                    <asp:DropDownList ID="drsrv" runat="server" DataTextField="sys_name" DataValueField="sys_id" AppendDataBoundItems="true" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox ID="reff_TextBox" runat="server" Text='<%# Bind("reff_") %>' Width="50px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="cate_TextBox" runat="server" Text='<%# Bind("cate_") %>' Width="50px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="b_zoneTextBox" runat="server" Text='<%# Bind("b_zone") %>' Width="50px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="f_levelTextBox" runat="server" Text='<%# Bind("f_level") %>' Width="50px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="seq_noTextBox" runat="server" Text='<%# Bind("seq_no") %>' Width="50px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="desc_TextBox" runat="server" Text='<%# Bind("desc_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="loca_TextBox" runat="server" Text='<%# Bind("loca_") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="p_power_toTextBox" runat="server" 
                                        Text='<%# Bind("p_power_to") %>' Width="50px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="fed_fromTextBox" runat="server" 
                                        Text='<%# Bind("fed_from") %>' Width="50px" />
                                </td>
                                <%--<td>
                                    <asp:TextBox ID="power_onTextBox" runat="server" 
                                        Text='<%# Bind("power_on") %>' />
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="devicesTextBox" runat="server" Text='<%# Bind("devices") %>' Width="50px" />
                                </td>
                                <%--<td>
                                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                        Text="Add" style="cursor:pointer" />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                        Text="Clear" />
                                </td>--%>
                            </tr>
                        </InsertItemTemplate>
                        <LayoutTemplate>
                       
                            <table runat="server">
                            <tr runat="server" >
                                    <td runat="server">
                                        <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                            style="background-color: #5D7B9D;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            <%--<tr runat="server" style="background-color: #E0FFFF;color: #333333;">--%>
                                                <%--<th runat="server">
                                                    cas_id</th>
                                                <th runat="server">
                                                    itm_no</th>--%>
                                                <%--<th runat="server">
                                                    sys_id</th>
                                                <th runat="server">
                                                    reff_</th>
                                                <th runat="server">
                                                    desc_</th>
                                                <th runat="server">
                                                    loca_</th>
                                                <th runat="server">
                                                    p_power_to</th>
                                                <th runat="server">
                                                    fed_from</th>--%>
                                                <%--<th runat="server">
                                                    power_on</th>--%>
                                                <%--<th runat="server">
                                                    devices</th>
                                            </tr>
                                            <tr ID="itemPlaceholder" runat="server">
                                            </tr>--%>
                                            <tr runat="server">
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
                                NO. OF DEVICES</td>
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
                        </tr>
                        <tr ID="itemPlaceholder" runat="server">
                                            </tr>
                                            <tr id="groupPlaceholder" runat="server"></tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" 
                                        style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                    </td>
                                </tr>
                                
                            </table>
                            
 
           

                        </LayoutTemplate>
                        <EditItemTemplate>
                            <tr style="background-color: #999999;">
                                <td>
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                                        Text="Update" />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                        Text="Cancel" />
                                </td>
                                <td>
                                    <asp:Label ID="cas_idLabel1" runat="server" Text='<%# Eval("cas_id") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="itm_noLabel1" runat="server" Text='<%# Eval("itm_no") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="sys_idTextBox" runat="server" Text='<%# Bind("sys_id") %>' />
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
                                    <asp:TextBox ID="devicesTextBox" runat="server" Text='<%# Bind("devices") %>' />
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
                                    <asp:Label ID="sys_idLabel" runat="server" Text='<%# Eval("sys_id") %>' />
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
                                    <asp:Label ID="devicesLabel" runat="server" Text='<%# Eval("devices") %>' />
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                        <GroupTemplate  >
                        <tr>
 
                        <td ID="itemPlaceholder" runat="server">
 
 
 
                        </td>
 
                    </tr>


                        </GroupTemplate>
                    </asp:ListView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>" 
                        SelectCommand="SELECT [cas_id], [itm_no], [sys_id], [reff_], [desc_], [loca_], [p_power_to], [fed_from], [power_on], [devices] FROM [cas_main_tbl]">
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
