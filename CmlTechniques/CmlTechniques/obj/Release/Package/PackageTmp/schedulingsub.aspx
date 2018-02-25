<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="schedulingsub.aspx.cs" Inherits="CmlTechniques.schedulingsub" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>

        <link href="page.css" rel="stylesheet" type="text/css" />
        <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.MultiFile.js" type="text/javascript"></script> 
 
</head>
<body bgcolor="#ffffff">
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            Width="100%">
            <asp:TabPanel runat="server" HeaderText="Create Schedule" ID="TabPanel1">
            <ContentTemplate>
           
            <table style="font-family: verdana; font-size: small; width: 100%; height: 100%">
            <tr>
                <td>
                <div style="overflow: auto">
                    
                    <asp:Panel ID="Panel2" runat="server">
                        
                    <table style="font-family: Arial, Helvetica, sans-serif; font-size: small" 
                        border="0" cellpadding="1" cellspacing="3" width="100%" >
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="120">
                                Folder Name</td>
                            <td >
                                <asp:TextBox ID="txtfolder" runat="server" Width="280px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                        <table border="0" cellpadding="1" cellspacing="3" width="100%">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="manufctr" runat="server"></asp:Label>
                                </td>
                                <td>                                
                                    <asp:DropDownList ID="drpmanufacture" runat="server" Width="282px">
                                    </asp:DropDownList>                                   
                                            <asp:Button ID="cmdnew" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                                                ForeColor="Red" onclick="cmdnew_Click" Text="New" Width="40px" />
                                      
                                    <asp:Panel ID="Panel1" runat="server" Height="22px">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="280px">
                                                            <asp:TextBox ID="txtnewmanufacturer" runat="server" BackColor="#FFFFCC" 
                                                                Width="280px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="cmdadd" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                                                                ForeColor="Red" onclick="cmdadd_Click" Text="Add" Width="40px" />
                                                        </td>
                                                    </tr>
                                         </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td width="120px">
                                    <asp:Label ID="lbtitle" runat="server" Text="Document Title"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="title" runat="server" Width="281px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="120px">
                                    Document Name</td>
                                <td>
                                    <asp:TextBox ID="txtdocument" runat="server" Width="281px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="cmdaddtobasket" runat="server" 
                                                Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" ForeColor="Red" 
                                                onclick="cmdaddtobasket_Click" Text="Add to Schedule Basket" Width="135px" />
                                            <asp:Button ID="Save" runat="server" Font-Names="Arial,Helvetica,sans-serif" 
                                                Font-Size="X-Small" ForeColor="Red" onclick="Save_Click" Text="Save Schedule" 
                                                Width="148px" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td >
                                    <asp:Label ID="Label1" runat="server" Font-Names="Arial,Helvetica,sans-serif" 
                                        Font-Size="Small" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    
                    <div style="margin-left:5px;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                    
                     <asp:GridView ID="myschedule_basket" runat="server" AllowPaging="false" 
                                    AutoGenerateColumns="False" CellPadding="4" 
                                    DataKeyNames="id" DataSourceID="dataSource" ForeColor="#333333" 
                                    GridLines="None " Width="100%" 
                        Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                        Font-Strikeout="False" onrowcommand="myschedule_basket_RowCommand" 
                            onrowcreated="myschedule_basket_RowCreated" 
                            onrowdatabound="myschedule_basket_RowDataBound">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="false" ForeColor="White" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />                                    
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" 
                                            DeleteImageUrl="~/TreeLineImages/minus.gif" ShowDeleteButton="true">
                                            <ItemStyle Width="10px" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="Folder_Name" HeaderText="FOLDER NAME">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Folder_id" HeaderText="">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>     
                                        <asp:BoundField DataField="package" />                                  
                                        <asp:BoundField DataField="doctitle" HeaderText="MANUFACTURE">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="docname" HeaderText="DOC.NAME">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="service" />
                                        <asp:BoundField DataField="doctype" />
                                    </Columns>
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="false" ForeColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                                <asp:ObjectDataSource ID="dataSource" runat="server" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetData" TypeName="CmlTechniques.schedule_basket" UpdateMethod="Update"  >
                                    <DeleteParameters>
                                    <asp:Parameter Name="id" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                    <asp:Parameter Name="service" Type="String" />
                                    <asp:Parameter Name="package" Type="String" />
                                    <asp:Parameter Name="doctype" Type="String" /> 
                                    <asp:Parameter Name="doctitle" Type="String" /> 
                                    <asp:Parameter Name="docname" Type="String" /> 
                                    <asp:Parameter Name="Folder_name" Type="String" /> 
                                    <asp:Parameter Name="Folder_id" Type="String" />  
                                    </InsertParameters>
                                    </asp:ObjectDataSource>                 
                    
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading30.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>
                     </div>
                     </div>
                    &nbsp;</td>
            </tr>
        </table>
            </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="Import from Excel" ID="TabPanel2">
            <ContentTemplate>
             <center>
             <table>
             <tr>
             <td align="left"><h4>Select Schedule File</h4>
             </td>
             </tr>
             <tr>
             <td align="left" valign="top" height="75px">
             <input type="file" id="myupload" class="multi" runat="server" maxlength="1" accept="xls" />
             </td>
             </tr>
             <tr>
             <td>
                 <asp:Button ID="btnupload" runat="server" Text="Upload" 
                     onclick="btnupload_Click" />
             </td>
             </tr>
                 <tr>
                     <td>
                         <asp:GridView ID="GridView1" runat="server">
                         </asp:GridView>
                     </td>
                 </tr>
             </table>
            
            
            </center>
            </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="Schedule List" ID="TabPanel3">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:GridView ID="myschedule" runat="server" AutoGenerateColumns="False" Font-Names="Verdana" 
                    Font-Size="X-Small" Width="100%" CellPadding="5" 
                    onrowdatabound="myschedule_RowDataBound" 
                    onrowcommand="myschedule_RowCommand">
                    <Columns>
                   <asp:ButtonField ButtonType="Image" ImageUrl="~/images/delete_.jpg" >
                                        <ItemStyle HorizontalAlign="Center" Width="25px" />
                        </asp:ButtonField>
                                        <asp:BoundField DataField="Folder" HeaderText="FOLDER NAME">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="200px" />
                                        </asp:BoundField>     
                                        <asp:BoundField DataField="manufacture" HeaderText="MANUFACTURE">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="id" />
                    </Columns>                      
                    <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" />
                </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
             
            </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
        
        
    </div>
    </form>
</body>
</html>
