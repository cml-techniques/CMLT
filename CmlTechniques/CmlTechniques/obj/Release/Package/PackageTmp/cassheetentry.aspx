<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cassheetentry.aspx.cs" Inherits="CmlTechniques.cassheetentry" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
 <telerik:RadCodeBlock runat="server" ID="radCodeBlock">
            <script type="text/javascript">
                function showFilterItem(){
                    $find('<%=mygrid.ClientID %>').get_masterTableView().showFilterItem();
                } 
                function hideFilterItem(){
                    $find('<%=mygrid.ClientID %>').get_masterTableView().hideFilterItem();
                } 
            </script>
        </telerik:RadCodeBlock>

    <form id="form1" runat="server">
     <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
         </asp:ToolkitScriptManager>
        <%--<div style="height:100%;width:100%">--%>
        <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td width="100px" >
            <asp:Label ID="Label1" runat="server" Text="Select Package" Width="100px"></asp:Label>
            </td>
        <td width="250px" >
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList ID="drpackage" runat="server" 
                Width="250px" AutoPostBack="True" 
                onselectedindexchanged="drpackage_SelectedIndexChanged">
                                </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
                                
                                </td>
        <td width="100%" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        </table>
         <div style="float:left;width:98.5%">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;width:100%;" cellspacing="1" border="0">
       <tr  style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;">
       
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                &nbsp;</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="6%">
                                ITM.NO</td>
       
                            <td align="center" rowspan="2" valign="middle"   width="10%">
                                ENG.REF</td>
                            <td align="center" colspan="4" valign="middle"  >
                                ASSET CODE</td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbloc" runat="server" Text="LOCATION"></asp:Label>
                            </td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbl1" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbl3" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbl2" runat="server"></asp:Label></td>
                            <td align="center" rowspan="2" valign="middle" width="10%" >
                                <asp:Label ID="lbnum" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr style="background-image: url('images/head_bg.png'); background-repeat: repeat-x;">
                            <td align="center" valign="middle"  width="7%"  >
                                BUILDING/ ZONE</td>
                            <td align="center" valign="middle" width="7%"  >
                                CATEGORY</td>
                            <td align="center" valign="middle" width="7%"  >
                                FLOOR LEVEL</td>
                            <td align="center" valign="middle" width="7%"  >
              SEQ.NO</td>
                        </tr>
                        <tr bgcolor="#092443">
            <td>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnadd" runat="server" Text="add" onclick="btnadd_Click" 
                                                    Width="100%" />
                </ContentTemplate>
                </asp:UpdatePanel>
                                                
                                                </td>
            <td>
                &nbsp;</td>
            <td>
                                <asp:TextBox ID="txtengref" runat="server" Width="94%"></asp:TextBox>
                                            </td>
            <td>
                                <asp:TextBox ID="txtzone" runat="server" Width="92%"></asp:TextBox>
                                            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtcate" runat="server" Width="92%"></asp:TextBox>
                </ContentTemplate>
                </asp:UpdatePanel>
                                
                                </td>
            <td>
                                <asp:TextBox ID="txtlevel" runat="server" Width="92%"></asp:TextBox>
                                            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtseq" runat="server" Width="92%"></asp:TextBox>
                </ContentTemplate>
                </asp:UpdatePanel>
                                
                                            </td>
            <td>
                                <asp:TextBox ID="txtloca" runat="server" Width="94%" ></asp:TextBox>
                                            </td>
            <td>
                                <asp:TextBox ID="txtpprovideto" runat="server" Width="94%" 
                                    ></asp:TextBox>
                                            </td>
            <td>
                                <asp:TextBox ID="txtfedfr" runat="server" Width="94%" 
                                    ></asp:TextBox>
                                            </td>
            <td>
                                <asp:TextBox ID="txtdesc" runat="server" Width="94%"></asp:TextBox>
                                            </td>
            <td>
                                <asp:TextBox ID="txtnoof" runat="server" Width="94%"></asp:TextBox>
                                            </td>
        </tr>
        <tr bgcolor="#092443" >
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                
            </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drcategory" runat="server" Width="100%" OnSelectedIndexChanged="drcategory_SelectedIndexChanged" AutoPostBack="true" >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
               </td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true"  >
                </asp:DropDownList>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <div style="position:relative; height:70%;overflow:scroll;float:left;width:100%;">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
            <asp:GridView ID="mygrid"  runat="server" AutoGenerateColumns="False" 
                onpageindexchanging="mygrid_PageIndexChanging" onsorting="mygrid_Sorting" 
                    onrowdatabound="mygrid_RowDataBound" Width="100%" 
                     ShowHeader="False" Font-Names="Verdana" 
                    Font-Size="X-Small" onrowcommand="mygrid_RowCommand" 
                    onrowupdating="mygrid_RowUpdating" >
                <Columns>
                
                <asp:ButtonField ButtonType="Button" Text="Update" CommandName="Update"
                        ItemStyle-Width="6%" >
                    <ItemStyle Width="6%"  />
                    </asp:ButtonField>
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="6%" >
                    <ItemStyle Width="6%" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" />
                    </asp:BoundField>
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" />
                    </asp:BoundField>
                
                <asp:BoundField DataField="F_lvl" HeaderText="Floor Level" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Seq_No" HeaderText="Seq.No" ItemStyle-Width="7%" >
                    <ItemStyle Width="7%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Loc" HeaderText="Location" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="P_P_to" HeaderText="Provides Power To" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="F_from" HeaderText="Fed From" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="Substation" HeaderText="Substation" 
                        ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="10%" >
                    <ItemStyle Width="10%" />
                    </asp:BoundField>
                <asp:BoundField DataField="C_id" />
                <asp:BoundField DataField="Sys_Id" />
                </Columns>
            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
         <asp:Panel ID="pnlPopup" runat="server" Width="720px" Height="300px" style="padding:20px" BackColor="#d1def1"  >
            <div>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                
                <div>
                <table style="width:720px">
                <tr>
                <td width="250px">Engg.Reff</td>
                    <td>
                        <asp:TextBox ID="upreff" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td width="150px">
                            Building/Zone</td>
                        <td>
                            <asp:TextBox ID="upzone" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Category</td>
                        <td>
                            <asp:TextBox ID="upcate" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Floor Level</td>
                        <td>
                            <asp:TextBox ID="upfloor" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Seq.No</td>
                        <td>
                            <asp:TextBox ID="upseq" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            Location</td>
                        <td>
                            <asp:TextBox ID="uploc" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <asp:Label ID="lb1" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb1" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <asp:Label ID="lb3" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb3" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <asp:Label ID="lb2" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb2" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            <asp:Label ID="lb4" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="uplb4" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td width="150px">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnupdate" runat="server" Text="Update" 
                                onclick="btnupdate_Click" />
                                <asp:Button ID="btndelete" runat="server" Text="Delete" onclick="btndelete_Click" 
                                 />
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                                onclick="btncancel_Click" />
                        </td>
                    </tr>
                </table>
               
                </div>
             </ContentTemplate>
                </asp:UpdatePanel>
            </div>
                        
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal"
                  DropShadow="true">
                  </asp:ModalPopupExtender> 
        <%--</div>--%>
       <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" >
 
            <AjaxSettings>
 
                <telerik:AjaxSetting AjaxControlID="mygrid" >
 
                    <UpdatedControls > 

                        <telerik:AjaxUpdatedControl ControlID="mygrid"  UpdatePanelHeight="100%" LoadingPanelID="RadAjaxLoadingPanel1"  />
 
                     </UpdatedControls>
                     
 
                 </telerik:AjaxSetting>
 
             </AjaxSettings>
 
    </telerik:RadAjaxManager> --%>
         <%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">--%>
         <%--<img alt="Loading..." src='<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading.gif") %>' style="border:0; position:relative;" />--%> 
         <%--</telerik:RadAjaxLoadingPanel>
        --%>
    
           
            <%--<div style="margin-top:5px;height:75%" align="center">
            <telerik:RadGrid ID="mygrid" runat="server" CellSpacing="0" Skin="Office2007" Height="100%"
              GridLines="None" Margin="10"   VerticalAlignment="Top" 
                RowHeight="30" MinHeight="100"
                AutoGenerateColumns="False" onitemcreated="mygrid_ItemCreated" 
                onitemdatabound="mygrid_ItemDataBound" onprerender="mygrid_PreRender" 
                AllowFilteringByColumn="true" ondatabound="mygrid_DataBound">
            
<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" ></HeaderContextMenu>

<MasterTableView Width="100%"  >
    
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>
    <Columns >
        
        <telerik:GridTemplateColumn HeaderText="Itm.No" ItemStyle-Width="50px" AllowFiltering="false">
        <ItemTemplate>
        
            <asp:Label ID="itm" runat="server" ></asp:Label>
        </ItemTemplate>
        
            <HeaderStyle Width="50px" />

<ItemStyle Width="50px"></ItemStyle>
        
        </telerik:GridTemplateColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column1 column" DataField="e_b_ref"
            UniqueName="column1" HeaderText="Eng.Ref" AllowFiltering="false">
            <HeaderStyle HorizontalAlign="Center" Width="120px" />
            <ItemStyle HorizontalAlign="Left" Width="120px" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" DataField="B_Z"
            UniqueName="column2" HeaderText="Building/Zone" AllowFiltering="true">
            <HeaderStyle HorizontalAlign="Center" />
            <FilterTemplate>
               
                <asp:DropDownList ID="drbuilding" runat="server" Width="100%" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>   
                
                            
            </FilterTemplate>
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn FilterControlAltText="Filter column2 column" DataField="Cat"
            UniqueName="column3" HeaderText="Category" AllowFiltering="true">
                <HeaderStyle HorizontalAlign="Center" />
                <FilterTemplate>
                <asp:DropDownList ID="drcategory" runat="server" Width="100%" OnSelectedIndexChanged="drcategory_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>               
            </FilterTemplate>
            </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column4 column" 
            UniqueName="column4" DataField="F_lvl" HeaderText="Floor Level" AllowFiltering="true">
            <HeaderStyle HorizontalAlign="Center" />
            <FilterTemplate>
                <asp:DropDownList ID="drflevel" runat="server" Width="100%" OnSelectedIndexChanged="drflevel_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>               
            </FilterTemplate>

        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column5 column" 
            UniqueName="column5" DataField="Sq_no" HeaderText="Seq.No" AllowFiltering="false">
            <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column6 column" 
            UniqueName="column6" DataField="Loc" HeaderText="Location" AllowFiltering="false">
            <HeaderStyle HorizontalAlign="Center" Width="150px" />
            <ItemStyle HorizontalAlign="Left" Width="150px" />
            
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column7 column" 
            UniqueName="column7" DataField="p_p_to" HeaderText="Power Provides To" AllowFiltering="false">
            <HeaderStyle HorizontalAlign="Center" Width="120px" />
            <ItemStyle HorizontalAlign="Left" Width="120px" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column8 column" 
            UniqueName="column8" DataField="F_from" HeaderText="Fed From" AllowFiltering="true">
            <HeaderStyle HorizontalAlign="Center" Width="120px" />
            <ItemStyle HorizontalAlign="Left" Width="120px" />
            <FilterTemplate>
                <asp:DropDownList ID="drfed" runat="server" Width="100%" OnSelectedIndexChanged="drfed_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>               
            </FilterTemplate>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column9 column" 
            UniqueName="column9" DataField="Substation" HeaderText="Substation" AllowFiltering="false">
            <HeaderStyle HorizontalAlign="Center" />
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column10 column" 
            UniqueName="column10" DataField="devices1" AllowFiltering="false">
            <HeaderStyle HorizontalAlign="Center" Width="50px" />
            <ItemStyle Width="50px" />
        </telerik:GridBoundColumn>
        
        
        <telerik:GridBoundColumn FilterControlAltText="Filter column column" 
            UniqueName="column" DataField="C_id" AllowFiltering="false" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn FilterControlAltText="Filter column11 column" 
            UniqueName="column11" DataField="E_b_ref" AllowFiltering="false">
        </telerik:GridBoundColumn>
        
        
    </Columns>
<GroupByExpressions>
                    <telerik:GridGroupByExpression >
                        <SelectFields >
                            <telerik:GridGroupByField  FieldName="Sys_name" FormatString="{0:D}" 
                                HeaderValueSeparator=" : " SortOrder="None" ></telerik:GridGroupByField>
                                
                        </SelectFields>
                        <GroupByFields>
                            <telerik:GridGroupByField FieldName="Sys_id" SortOrder="None" HeaderText=""  ></telerik:GridGroupByField>
                        </GroupByFields>
                    </telerik:GridGroupByExpression>
                </GroupByExpressions>
              

    

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

                <HeaderStyle BorderColor="#9EB6CE" BorderStyle="Solid" BorderWidth="1px" />

           <ClientSettings>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="True" ScrollHeight="95%">
                </Scrolling>
            </ClientSettings>


<FilterMenu EnableImageSprites="False"></FilterMenu>

        </telerik:RadGrid>
        </div>--%>
        
            
            
        
    </div>
    </form>
</body>
</html>
