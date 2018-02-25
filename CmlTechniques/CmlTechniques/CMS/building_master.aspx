<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="building_master.aspx.cs" Inherits="CmlTechniques.CMS.building_master" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                  <asp:ListView ID="my_view" runat="server" InsertItemPosition="FirstItem" 
            style="height:350px"  onitemediting="my_view_ItemEditing" 
            onitemcommand="my_view_ItemCommand" onitemupdating="my_view_ItemUpdating" 
            onitemcanceling="my_view_ItemCanceling" 
            oniteminserting="my_view_ItemInserting"  >
                        <ItemTemplate>
                            <tr style="background-color: #F7F6F3;color: #333333;">
                                <td>
                                    <asp:Label ID="lbitemname" runat="server" Text='<%# Eval("Build_Name") %>' Width="300px" />
                                    <asp:Label ID="lbid" runat="server" Text='<%# Eval("Build_Id") %>' style="display:none"  />
                                </td>
                                <td>
                                <asp:Button ID="btnselect" runat="server" CommandName="Edit" 
                                        Text="Edit" Width="75px" style="border:0;cursor:pointer" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr style="background-color: #FFFFFF;color: #284775;">
                                <td>
                                    <asp:Label ID="lbitemname" runat="server" Text='<%# Eval("Build_Name") %>' Width="300px" />
                                    <asp:Label ID="lbid" runat="server" Text='<%# Eval("Build_Id") %>' style="display:none"  />
                                </td>
                                <td>
                                <asp:Button ID="btnselect" runat="server" CommandName="Edit" 
                                        Text="Edit" Width="75px" style="border:0;cursor:pointer" />
                                </td>
                                
                            </tr>
                        </AlternatingItemTemplate>
                        <EmptyDataTemplate>
                            <table id="Table1"  runat="server" 
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
                                    <asp:TextBox ID="txtbuilding" runat="server"  Width="300px" Font-Size="Small" />
                                </td>
                               <td>
                                    <asp:Button ID="btninsert" runat="server" CommandName="Insert" 
                                        Text="Create" style="cursor:pointer" Width="75px" />                                    
                                </td>
                            </tr>
                        </InsertItemTemplate>
                        <LayoutTemplate>
                       
                            <table   runat="server">
                            <tr   runat="server" >
                                    <td  runat="server">
                                        <table ID="itemPlaceholderContainer" runat="server" border="0" 
                                            style="background-color: #5D7B9D;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            
                            <tr   runat="server" >
                            <td height="30px"  align="center">BUILDING NAME</td> 
                            <td></td>
                            </tr>
                        <tr ID="itemPlaceholder" runat="server">
                                            </tr>
                                           
                                        </table>
                                    </td>
                                </tr>
                               
                                
                            </table>
                        </LayoutTemplate>
                        <EditItemTemplate>
                            <tr style="background-color: #999999;">
                                <td>
                                <asp:TextBox ID="txtbuilding" runat="server" 
                                 Width="300px" Text='<%# Eval("Build_Name") %>' Font-Size="Small" />
                                    <asp:Label ID="lbid" runat="server" Text='<%# Eval("Build_Id") %>' style="display:none"  />
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
                                    <asp:Label ID="lbitemname" runat="server" Text='<%# Eval("Build_Name") %>' Width="300px" />
                                    <asp:Label ID="lbtype" runat="server" Text='<%# Eval("Build_Id") %>' style="display:none"  />
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                    </asp:ListView>

    </div>
    </form>
</body>
</html>
