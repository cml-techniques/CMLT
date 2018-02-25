<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProjectModule.aspx.cs" Inherits="CmlTechniques.UserProjectModule" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="Stylesheet" href="page.css" />
    <link rel=Stylesheet href="Assets/css/font-awesome.min.css" />
    <style type="text/css">
        .style2
        {
            width: 90px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" >
    </telerik:RadScriptManager>
    
    <div style="width:98%;margin-left:auto;margin-right:auto;">
    <table style="width:100%">
    <tr>
   <%-- <td  style="width:100%;background-color:Black;color:White;font-weight:bold;font-size:16px;height:32px;">
    User Module Settings
    </td>--%>
    <td>
      <h1>User Modules</h1>
    </td>  
    </tr>
    </table>
    <table>
        <tr>
    <td style="height:10px"></td>
    </tr>
        <tr>
        <td style="width:50px">User</td>
    <td>
     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
            <telerik:RadDropDownList ID="druserid" runat="server" Width="300px" AutoPostBack="True" onselectedindexchanged="druserid_SelectedIndexChanged">
            </telerik:RadDropDownList>
            
            </ContentTemplate>
            </asp:UpdatePanel>
    </td>
    </table>
    
    <table style="width:100%">
    <tr>
    <td >Project </td>
    <td style="padding:4px">
    <asp:UpdatePanel ID="updatepanel4" runat="server">
    <ContentTemplate>
        <telerik:RadDropDownList ID="ddlproject" runat="server" 
            OnSelectedIndexChanged="ddlproject_SelectedIndexChanged" AutoPostBack="true" Width="300px">
        </telerik:RadDropDownList>
       </ContentTemplate>
       </asp:UpdatePanel>
    </td>
    <td style="width:10px"></td>
    <td>
    
     <asp:UpdatePanel ID="updatepanel6" runat="server">
    <ContentTemplate>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal" Width="200">
        </asp:CheckBoxList>
        </ContentTemplate>
        </asp:UpdatePanel>
    </td>
     <td style="width:10px"></td>
    <td>
    <asp:UpdatePanel ID="updatepanel3" runat="server">
    <ContentTemplate>
     <asp:Button ID="btnadd" Text="Add" runat="server" onclick="btnadd_Click" Width="80px" />
     </ContentTemplate>
     </asp:UpdatePanel>
    </td>
    <td  style="text-align:right;width:100%;">
      <table style="text-align:right;float:right"> 
                                            <tr>
                                            <td>
                                            <asp:UpdatePanel ID="updatepanel1" runat="server">
    <ContentTemplate>
                                              <asp:Button ID="btnsave" Text="Save"  Width="100px" runat="server" 
                                                    onclick="btnsave_Click" />
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                            </td>
                                            <td>
                                            <asp:UpdatePanel ID="updatepanel2" runat="server">
    <ContentTemplate>
                                              <asp:Button ID="btncancel" Text="Cancel" Width="100px" runat="server" onclick="btncancel_Click" 
                                                    />
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                            </td>
                                            </tr>
                                            </table>
    </td>
    </tr>
    <tr>
     <td style="height:5px" colspan="6"></td>
    </tr>
    </table>
      
    </div>
   <div style="width:98%;margin-left:auto;margin-right:auto;">
   <table border="0"  style="width:100%;background-color:#5D7B9D;height:32px;color:#ffffff;Font-Size:13px;font-weight:bold;margin:0px;padding:0px;"  >
   <tr>
    <td style="display:none;width:0px;"></td>
    <td style="width:79%">PROJECT</td>
    <td style="width:5%;text-align:center">CMS</td>
    <td style="width:5%;text-align:center">DMS</td>
    <td style="width:5%;text-align:center">TMS</td>
    <td style="width:2%;text-align:center"></td>
    <td style="width:2%;text-align:center"></td>
   </tr>
   </table>
             <asp:UpdatePanel ID="updatepanel7" runat="server">
    <ContentTemplate>
    <asp:GridView ID="myprojectgrid" runat="server"  ShowHeader="false" GridLines="None"
                                                Width="100%" AutoGenerateColumns="False" 
                                                ForeColor="#333333" PageSize="2" ShowFooter="false"  HeaderStyle-Font-Bold="false"
                                                OnRowCommand="myprojectgrid_RowCommand" OnRowDataBound="myprojectgrid_RowDataBound"  >
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  Height="32px"  />
                                                <Columns>
                                                     <asp:BoundField DataField="prj_id" ItemStyle-Width="0px"  />
                                                     <asp:BoundField DataField="prj_name"  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="77%"   />
                                                     
                                                 
                                                 <asp:checkboxfield datafield="cms"   ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="0"  /> 
                                                    <asp:checkboxfield datafield="dms"   ItemStyle-HorizontalAlign="Center"  ItemStyle-Width="0" /> 
                                                  <asp:checkboxfield datafield="ams"    ItemStyle-HorizontalAlign="Center"   ItemStyle-Width="0" /> 
                                                    
                                                     <asp:TemplateField   ItemStyle-HorizontalAlign="Center">
                                                  <ItemTemplate >
                                                  
                                                
                                               <asp:HyperLink ID="hcms" Visible="false" runat="server" class="fa fa-check"  />
                                                  
                                                  </ItemTemplate>
                                                   <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                  </asp:TemplateField>
                                                    
                                                     <asp:TemplateField   ItemStyle-HorizontalAlign="Center">
                                                  <ItemTemplate >
                                                  
                                                
                                               <asp:HyperLink ID="hdms" Visible="false" runat="server" class="fa fa-check"  />
                                                  
                                                  </ItemTemplate>
                                                   <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                  </asp:TemplateField>
                                               
                                                 
                                                     <asp:TemplateField   ItemStyle-HorizontalAlign="Center">
                                                  <ItemTemplate >
                                                  
                                                
                                               <asp:HyperLink ID="hams" Visible="false" runat="server" class="fa fa-check"  />
                                                  
                                                  </ItemTemplate>
                                                   <ItemStyle Width="5%" HorizontalAlign="Center" />
                                                  </asp:TemplateField>
                                                 
                                                    
                                              
                                               <asp:TemplateField   ItemStyle-HorizontalAlign="Center">
                                                  <ItemTemplate >
                                                 
                                                  
                                                  <asp:ImageButton ID="btnedit" runat="server" ImageUrl="~/images/edit-8-20.png" CommandName="edits" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"   /> 
                                        
                                                   </ItemTemplate>
                                                    <ItemStyle Width="2%" HorizontalAlign="Center" />
                                                   
                                               
                                                  </asp:TemplateField>
                                               
                                                 <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                                                  <ItemTemplate>
                                                 
                                                  
                                                  <asp:ImageButton ID="btndelete" runat="server" ImageUrl="~/images/delete_.png" CommandName="deletes" OnClientClick="return confirm('Are you sure to want to delete?');"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  /> 
                                        
                                                   </ItemTemplate>
                                                     <ItemStyle Width="2%" HorizontalAlign="Center" />
                                               
                                                  </asp:TemplateField>
                                                       
                                                    
                                                </Columns>
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                              
                                                <EditRowStyle BackColor="#999999" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                               
                                                
                                            </asp:GridView>

          
          </ContentTemplate>
          </asp:UpdatePanel>
          
   
                                            <br />
                                           
                                        
                                           
                                            
   </div>
    

     <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            </telerik:RadWindowManager>
                 <telerik:RadWindow ID="RadWindow2" runat="server" Modal="true" BorderStyle="None" Title="Information!" EnableShadow="true" Behaviors="Minimize, Maximize, Close, Move" Skin="Metro" Width="300px" Height="180px" VisibleStatusbar="false">
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <div style="padding: 20px;text-align:center">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblmessage" ForeColor="Red" Font-Size="15px" runat="server" Text=""></asp:Label>
                                       <%-- <asp:Label ID="lbldocid" runat="server" Text="0" Style="display: none;"></asp:Label>--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                    <center>
                                        <table>
                                            <tr>
                                                <td><asp:Button ID="btnno" runat="server" Text="Ok"  OnClick="btnno_Click" Width="100px" /></td>
                                            </tr>
                                        </table>
                                        </center>
                                        
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>

            </telerik:RadWindow>
                </form>
</body>
</html>