<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsdocreview1.aspx.cs"
    Inherits="CmlTechniques.CMS.cmsdocreview1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/jquery-1.3.2.js" type="text/javascript"></script>

    <script src="../Scripts/jquery.MultiFile.js" type="text/javascript"></script>

    <script type="text/javascript">
        function Load_doc(_file) {
            parent.document.getElementById("content").src = _file;
        }  
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small; height: 100%; width: 100%">
        <asp:ToolkitScriptManager runat="server">
        </asp:ToolkitScriptManager>
        <div>
            <table style="background-color: #092443; color: White; width: 100%">
                <tr>
                    <td style="width: 110px">
                        Service
                    </td>
                    <td style="width: 110px">
                        <asp:DropDownList ID="drservice" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 110px">
                        &nbsp;
                    </td>
                    <td style="width: 300px">
                        &nbsp;
                    </td>
                    <td style="width: 110px">
                        &nbsp;
                    </td>
                    <td style="width: 250px">
                        <%--<asp:DropDownList ID="drissuedto" runat="server" Width="250px"></asp:DropDownList>--%>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnadd" runat="server" Text="add" OnClick="btnadd_Click" Width="100px"
                                    OnClientClick="ClearText()" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td style="font-size: xx-large; font-weight: bold;">
                        DR
                    </td>
                    <td style="width: 40px" align="center">
                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnprint" runat="server" Text="" Style="background: url('../images/print_icon.png');
                                    cursor: pointer" BorderStyle="None" Height="30px" Width="30px" OnClick="btnprint_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <%--<h1 style="margin:0; background-color: #092443; color: #FFFFFF;">Document Review Log:-&nbsp;<p></p>Document<asp:TextBox ID="txtreviewed" runat="server" Width="300px"></asp:TextBox></h1>--%>
            <%--<p style="margin:0; background-color: #092443; color: #FFFFFF;height:30px"><span style="font-size:x-large;font-weight:bold">Document Review</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Document Name" Height="20px"></asp:Label>&nbsp; <asp:TextBox ID="txtreviewed" runat="server" Width="300px"></asp:TextBox>&nbsp;<asp:Label 
                ID="Label2" runat="server" Text="Issued to" Height="20px"></asp:Label>&nbsp;<asp:DropDownList ID="drissuedto" runat="server" Width="300px">
                                </asp:DropDownList>&nbsp;<asp:Button ID="btnadd0" 
                runat="server" Text="add" onclick="btnadd_Click" Width="100px" />
                                                </p>--%>
        </div>
        <div style="height: 100%">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <%--<asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                Font-Bold="True" Width="100%" CellPadding="4" 
                onrowdatabound="mygrid_RowDataBound" onrowcommand="mygrid_RowCommand" 
                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" >
                <RowStyle BackColor="White" ForeColor="#003399" />
                <Columns>
                <asp:BoundField DataField="dr_no" HeaderText="DR.NO" />
                <asp:ButtonField DataTextField="dr_no" HeaderText="DR.NO" ButtonType="Button" >
                    <ControlStyle Font-Size="X-Small" Height="20px" Width="50px" />
                    <ItemStyle Width="50px" />
                    </asp:ButtonField>
                <asp:BoundField DataField="dr_reviewed" HeaderText="DOCUMENT REVIEWED" />
                <asp:BoundField DataField="issue_date" HeaderText="ISSUED DATE" 
                        DataFormatString="{0:dd/MM/yy}" >
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                <asp:BoundField DataField="uid" HeaderText="REVIEWED BY" />
                <asp:BoundField DataField="issued_to" HeaderText="ISSUED TO" />
                <asp:BoundField DataField="comments" HeaderText="NO.OF COMMENTS" >
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                <asp:BoundField DataField="response"    HeaderText="NO.OF RESPONSE" >
                    <ItemStyle Width="75px" />
                    </asp:BoundField>
                <asp:BoundField DataField="dr_status" HeaderText="STATUS" >
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                <asp:BoundField DataField="dr_id" />
                <asp:BoundField HeaderText="OVER DUE" />
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            </asp:GridView>--%>
                    <table border="1" style="border-collapse: collapse; border-color: #999999; border-style: none;
                        border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" width="100%">
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;">
                            <td style="width: 11%; height: 30px" align="center">
                                DR.NO
                            </td>
                            <td style="width: 8%" align="center">
                                SERVICE
                            </td>
                            <td style="width: 15%" align="center">
                                SUBJECT
                            </td>
                            <td style="width: 7%" align="center">
                                ISSUED DATE
                            </td>
                            <td style="width: 13%" align="center">
                                REVIEWED BY
                            </td>
                            <td style="width: 13%" align="center">
                                ISSUED TO
                            </td>
                            <td style="width: 12%" align="center">
                                COMMENTS
                            </td>
                            <td style="width: 12%" align="center">
                                RESPONSE
                            </td>
                            <td style="width: 6%" align="center">
                                STATUS
                            </td>
                            <%--<td style="width:6%" align="center">OVER DUE (days)</td>--%>
                            <td style="width: 5%" align="center">
                            </td>
                        </tr>
                        <tr style="background-color: #092443">
                            <td align="center" style="width: 11%;">
                                <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label><asp:Label
                                    ID="lblsrv" runat="server" Text="" CssClass="hidden"></asp:Label>
                            </td>
                            <td align="center" style="width: 8%">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="dr_service" runat="server" Width="100%" AutoPostBack="true"
                                            OnSelectedIndexChanged="dr_service_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="center" style="width: 15%">
                            </td>
                            <td align="center" style="width: 7%">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 13%">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="drreview" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drreview_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="center" style="width: 13%">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="drissue" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drissue_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="center" style="width: 12%">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 12%">
                                &nbsp;
                            </td>
                            <td align="center" style="width: 6%">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="drstatus" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drstatus_SelectedIndexChanged">
                                            <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="OPEN" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="CLOSED" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <%--<td align="center" style="width:6%">
                        &nbsp;</td>--%>
                            <td align="center" style="width: 5%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <%--<asp:ListView ID="myview" runat="server" 
                style="width:100%" onitemcanceling="myview_ItemCanceling" 
                onitemcommand="myview_ItemCommand" 
                onselectedindexchanging="myview_SelectedIndexChanging" onitemediting="myview_ItemEditing" 
                    onitemupdating="myview_ItemUpdating" 
                    onitemdatabound="myview_ItemDataBound">
                <ItemTemplate>
                    <tr  id="itm_tr" runat="server">
                        <td style="width:60px">
                           
                            <asp:Button ID="btndr_no" runat="server" Text='<%# Eval("dr_no") %>' CommandName="select" Width="60px" />
                            <asp:Label ID="dr_idLabel" runat="server" Text='<%# Eval("dr_id") %>' style="display:none" />
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="lbsrv" runat="server" 
                                Text='<%# Eval("service") %>' Width="100px" />
                        </td>
                        <td style="width:250px">
                            <asp:Label ID="dr_reviewedLabel" runat="server" 
                                Text='<%# Eval("dr_reviewed") %>' Width="250px" />
                        </td>
                        <td align="center" style="width:60px">
                            <asp:Label ID="issue_dateLabel" runat="server" Text='<%# Eval("issue_date","{0:dd-MM-yy}") %>' Width="60px"   />
                  <asp:Label ID="lbdate" runat="server" Text='<%# Eval("issue_date") %>' style="display:none"  />
                        </td>
                        <td align="center" style="width:180px">
                        <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' Width="180px"/>
                        </td>
                        <td align="center" style="width:180px">
                            <asp:Label ID="issued_toLabel" runat="server" Text='<%# Eval("issued_to") %>' Width="180px" />
                        </td>
                        <td align="center" style="width:70px">
                        <asp:Label ID="commentsLabel" runat="server" Text='<%# Eval("comments") %>' Width="70px" />
                            
                        </td>
                        <td align="center" style="width:70px">
                        <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' Width="70px" />
                            
                        </td>
                        <td align="center" style="width:50px">
                        <asp:Label ID="dr_statusLabel" runat="server" Text='<%# Eval("dr_status") %>' Width="50px" />
                            
                        </td>
                        <td align="center" style="width:60px">
                         <asp:Label ID="lbdue" runat="server"   />
                        </td>
                        <td style="width:60px">
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Edit" style="cursor:pointer" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr  id="itm_tr" runat="server">
                        <td style="width:60px">
                           
                            <asp:Button ID="btndr_no" runat="server" Text='<%# Eval("dr_no") %>' CommandName="select" Width="60px" />
                            <asp:Label ID="dr_idLabel" runat="server" Text='<%# Eval("dr_id") %>' style="display:none" />
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="lbsrv" runat="server" 
                                Text='<%# Eval("service") %>' Width="100px" />
                        </td>
                        <td style="width:250px">
                            <asp:Label ID="dr_reviewedLabel" runat="server" 
                                Text='<%# Eval("dr_reviewed") %>' Width="250px" />
                        </td>
                        <td align="center" style="width:60px">
                            <asp:Label ID="issue_dateLabel" runat="server" Text='<%# Eval("issue_date","{0:dd-MM-yy}") %>' Width="60px"   />
                  <asp:Label ID="lbdate" runat="server" Text='<%# Eval("issue_date") %>' style="display:none"  />
                        </td>
                        <td align="center" style="width:180px">
                        <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' Width="180px"/>
                        </td>
                        <td align="center" style="width:180px">
                            <asp:Label ID="issued_toLabel" runat="server" Text='<%# Eval("issued_to") %>' Width="180px" />
                        </td>
                        <td align="center" style="width:70px">
                        <asp:Label ID="commentsLabel" runat="server" Text='<%# Eval("comments") %>' Width="70px" />
                            
                        </td>
                        <td align="center" style="width:70px">
                        <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' Width="70px" />
                            
                        </td>
                        <td align="center" style="width:50px">
                        <asp:Label ID="dr_statusLabel" runat="server" Text='<%# Eval("dr_status") %>' Width="50px" />
                            
                        </td>
                        <td align="center" style="width:60px">
                         <asp:Label ID="lbdue" runat="server"   />
                        </td>
                        <td style="width:60px">
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" 
                                        Text="Edit" style="cursor:pointer" />
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
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                                Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                                Text="Clear" />
                        </td>
                        <td>
                            <asp:TextBox ID="dr_noTextBox" runat="server" Text='<%# Bind("dr_no") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" 
                                Text='<%# Eval("service") %>' Width="200px" />
                        </td>
                        <td>
                            <asp:TextBox ID="dr_reviewedTextBox" runat="server" 
                                Text='<%# Bind("dr_reviewed") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="issue_dateTextBox" runat="server" 
                                Text='<%# Bind("issue_date") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="issued_toTextBox" runat="server" 
                                Text='<%# Bind("issued_to") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="dr_statusTextBox" runat="server" 
                                Text='<%# Bind("dr_status") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="uidTextBox" runat="server" Text='<%# Bind("uid") %>' />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="commentsTextBox" runat="server" 
                                Text='<%# Bind("comments") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="responseTextBox" runat="server" 
                                Text='<%# Bind("response") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                    style="border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                   
                                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;">
                                        <th runat="server" height="30px">
                                            DR.NO</th>
                                            <th runat="server">SERVICE</th>
                                        <th runat="server">
                                            SUBJECT</th>
                                        <th runat="server">
                                            ISSUED DATE</th>
                                        <th runat="server">
                                            REVIEWED BY</th>
                                        <th runat="server">
                                            ISSUED TO</th>
                                        <th runat="server">
                                            COMMENTS</th>
                                        <th runat="server">
                                            RESPONSE</th>
                                        <th runat="server">
                                            STATUS</th>
                                            <th runat="server" width="70px">
                                            OVER DUE (days)</th>
                                        <th runat="server">
                                            </th>
                                    </tr>
                                    <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat;">
                                        <th></th>
                                        <th>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="dr_service" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="dr_service_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </th>
                                        <th></th>
                                        <th></th>
                                        <th>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="drreview" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drreview_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </th>
                                        <th>
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="drissue" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drissue_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </th>
                                        <th></th>
                                        <th></th>
                                        <th>
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="drstatus" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="drstatus_SelectedIndexChanged">
                                                <asp:ListItem Text="All" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="OPEN" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="CLOSE" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </th>
                                        <th></th>
                                        <th></th>
                                    </tr>
                                    <tr ID="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            
                        </tr>
                    </table>
                </LayoutTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #DEF6FE;" id="itm_tr" runat="server">
                        
                        <td>
                            <asp:Label ID="dr_noLabel" runat="server" Text='<%# Eval("dr_no") %>' />
                            <asp:Label ID="dr_idLabel" runat="server" Text='<%# Eval("dr_id") %>' style="display:none" />
                        </td>
                        <td>
                           
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("service") %>' />
                        </td>
                        <td>
                           
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("dr_reviewed") %>' />
                        </td>
                        <td>
                            
                              <asp:Label ID="Label6" runat="server" Text='<%# Eval("issue_date","{0:dd-MM-yy}") %>' />  
                              <asp:Label ID="lbdate" runat="server" Text='<%# Eval("issue_date") %>' style="display:none"  />
                        </td>
                        <td>
                            
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("uid") %>' />
                        </td>
                        
                        <td>
                            
                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("issued_to") %>' />   
                        </td>
                        <td>
                            
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("comments") %>' />
                        </td>
                        <td>
                            
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("response") %>' />
                        </td>
                        <td>
                            
                                <asp:Label ID="dr_statusLabel" runat="server" Text='<%# Eval("dr_status") %>' style="display:none" />
                            <asp:DropDownList ID="drstatus" runat="server" Width="70px" >
                            </asp:DropDownList>
                        </td>
                        
                        <td>
                          <asp:Label ID="lbdue" runat="server"   />  
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
                    <tr style="background-color: #E2DED6; font-weight: bold;color: #333333;">
                        <td>
                            <asp:Label ID="dr_noLabel" runat="server" Text='<%# Eval("dr_no") %>' />
                        </td>
                        <td>
                            <asp:Label ID="dr_reviewedLabel" runat="server" 
                                Text='<%# Eval("dr_reviewed") %>' />
                        </td>
                        <td>
                            <asp:Label ID="issue_dateLabel" runat="server" 
                                Text='<%# Eval("issue_date") %>' />
                        </td>
                        <td>
                            <asp:Label ID="issued_toLabel" runat="server" Text='<%# Eval("issued_to") %>' />
                        </td>
                        <td>
                            <asp:Label ID="dr_statusLabel" runat="server" Text='<%# Eval("dr_status") %>' />
                        </td>
                        <td>
                            <asp:Label ID="uidLabel" runat="server" Text='<%# Eval("uid") %>' />
                        </td>
                        <td>
                            <asp:Label ID="dr_idLabel" runat="server" Text='<%# Eval("dr_id") %>' />
                        </td>
                        <td>
                            <asp:Label ID="commentsLabel" runat="server" Text='<%# Eval("comments") %>' />
                        </td>
                        <td>
                            <asp:Label ID="responseLabel" runat="server" Text='<%# Eval("response") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>--%>
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="mygrid_dr" runat="server" AutoGenerateColumns="False" OnRowDataBound="mygrid_dr_RowDataBound"
                                Width="100%" ShowHeader="False" OnRowCommand="mygrid_dr_RowCommand">
                                <Columns>
                                    <asp:ButtonField ButtonType="Button" DataTextField="dr_no" CommandName="get">
                                        <ItemStyle Width="11%" HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="Service">
                                        <ItemStyle Width="8%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject">
                                        <ItemStyle Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Issue_date" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="created_By">
                                        <ItemStyle Width="13%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Issue_To">
                                        <ItemStyle Width="13%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Comments">
                                        <ItemStyle Width="12%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Response">
                                        <ItemStyle Width="12%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status">
                                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField  >
                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                        </asp:BoundField> --%>
                                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="status">
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="dr_no" />
                                    <asp:BoundField DataField="dr_id" />
                                    <asp:BoundField DataField="issue_to" />
                                    <asp:BoundField DataField="File_Name" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbCMLConnectionString %>"
                        SelectCommand="Load_doc_review_log" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="project_code" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Panel ID="pnlPopup1" runat="server" Width="250px" Height="110px" Style="padding: 10px;
                background-color: White; display: none">
                <table border="0" cellpadding="0" cellspacing="0" style="background-color: White"
                    id="Table1">
                    <tr>
                        <td align="left" bgcolor="White" valign="middle" width="100PX">
                            &nbsp;
                        </td>
                        <td align="left" bgcolor="White" valign="middle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" bgcolor="White" valign="middle" width="100PX">
                            STATUS
                        </td>
                        <td align="left" bgcolor="White" valign="middle">
                            <asp:DropDownList ID="drstatus1" runat="server" Width="150px">
                                <asp:ListItem Text="OPEN" Value="OPEN"></asp:ListItem>
                                <asp:ListItem Text="CLOSED" Value="CLOSED"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="footer" height="30px" colspan="2" align="center">
                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="Label2" runat="server" Text="" Style="display: none"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="footer" colspan="2" height="30px">
                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnupdate" runat="server" Height="26px" OnClick="btnupdate_Click"
                                        Text="Update" />
                                    <asp:Button ID="btncancel1" runat="server" OnClick="btncancel1_Click" Text="Cancel" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading30.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>--%>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Button ID="btnDummy1" runat="server" Text="Button" Style="display: none;" />
            <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender1" runat="server" TargetControlID="btnDummy1"
                PopupControlID="pnlPopup1" BackgroundCssClass="modal">
            </asp:ModalPopupExtender>
            <asp:Button ID="btndummy" runat="server" Text="" Style="display: none" />
            <asp:ModalPopupExtender ID="btndummy_ModalPopupExtender" runat="server" TargetControlID="btndummy"
                PopupControlID="upop" BackgroundCssClass="modal">
            </asp:ModalPopupExtender>
            <div style="width: 500px; height: 550px; background-color: #ECE1C3; border: solid 2px #063940;"
                id="upop">
                <div style="height: 25px; padding: 5px 10px; font-size: 18px; font-weight: bold;
                    background-color: #063940; color: #ECE1C3;">
                    Upload DR</div>
                <div style="padding: 5px 10px">
                    <table cellpadding="5">
                        <tr>
                            <td style="width: 100px">
                                DR. NO.
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblmode" runat="server" Text="1" Style="display: none"></asp:Label>
                                        <asp:TextBox ID="txt_drno" runat="server" Width="100px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="drgroup"
                                            ErrorMessage="*" ForeColor="Red" ControlToValidate="txt_drno"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                SUBJECT
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txt_subject" runat="server" Width="300px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="drgroup"
                                            ErrorMessage="*" ForeColor="Red" ControlToValidate="txt_subject"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                REVIEW BY
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txt_review" runat="server" Width="300px"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                ISSUED TO
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblfile" runat="server" Text="" Style="display: none"></asp:Label>
                                        <asp:TextBox ID="txt_issuedto" runat="server" Width="300px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="drgroup"
                                            ErrorMessage="*" ForeColor="Red" ControlToValidate="txt_issuedto"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                DATE OF ISSUE
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txt_issuedate" runat="server" Width="100px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender58" runat="server" ClearTime="true" Format="dd/MM/yyyy"
                                            PopupButtonID="txt_issuedate" TargetControlID="txt_issuedate">
                                        </asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="drgroup"
                                            ErrorMessage="*" ForeColor="Red" ControlToValidate="txt_issuedate"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 50px; vertical-align: top;">
                                SELECT DOCUMENT
                            </td>
                            <td style="height: 50px; vertical-align: top;">
                                <input type="file" id="myupload" class="multi" runat="server" accept="application/pdf" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="drgroup"
                                    ControlToValidate="myupload" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                UPLOADED FILE NAME
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblfilename" runat="server">
                                        </asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                COMMENTS
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txt_cmts" runat="server" Width="300px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                RESPONSE
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txt_resp" runat="server" Width="300px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                STATUS
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="dr_status" runat="server">
                                            <asp:ListItem Text="OPEN" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="CLOSED" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr id="tdemail" runat="server">
                            <td></td>
                            <td colspan="2">
                                  <asp:CheckBox ID="chk" runat="server" Text="Do Not Send Email Notification Upon Uploading" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnupload" runat="server" ValidationGroup="drgroup" OnClick="btnupload_Click"
                                                        OnClientClick="Validate()" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnupload" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click1"
                                                        OnClientClick="ClearText()" />
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
    </div>

         <asp:Panel ID="pnlPopup2" runat="server" Width="500px" Height="350px" BackColor="#83C8EE"
        Style="padding: 5px; display: none;">
        <div style="background-color: #fff; padding: 5px;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td colspan="2">
                                Select Users
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-left: 5px">
                                <asp:CheckBox ID="chkall" runat="server" Text="All" AutoPostBack="true" OnCheckedChanged="chkall_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="overflow: auto; height: 225px">
                                    <asp:CheckBoxList ID="chkprjusers" runat="server" Width="100%" RepeatDirection="Vertical"
                                        BackColor="Gainsboro">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Send Notification" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnexitwindows" runat="server" OnClick="btnexitwindows_Click" Text="Cancel" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 30%;
                        left: 35%">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="imgload" runat="server" ImageUrl="../images/loading.gif" Height="200px"
                                    Width="250px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    <asp:Button ID="btnDummy2" runat="server" Text="Button" Style="display: none;" />
    <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender2" runat="server" TargetControlID="btnDummy2"
        PopupControlID="pnlPopup2" BackgroundCssClass="model-background">
    </asp:ModalPopupExtender>

    </form>

    <script type="text/javascript">
        function Validate() {
            var div = document.getElementById("UpdatePanel5");
            var spans = div.getElementsByTagName("span");
            var mode = spans[0].innerHTML;
            if (mode == 1) {
                var ele = document.getElementById("lblfile").innerHTML;
                ValidatorEnable(ele, false);

            }
            else if (mode == 0) {
                var ele = document.getElementById("RequiredFieldValidator5");
                ValidatorEnable(ele, true);
                ele.innerHTML = "Please choose a file!";
            }
        }
        function ClearText() {
            var ele1 = document.getElementById("RequiredFieldValidator5");
            ele1.innerHTML = "";
        }     
    </script>

</body>
</html>
