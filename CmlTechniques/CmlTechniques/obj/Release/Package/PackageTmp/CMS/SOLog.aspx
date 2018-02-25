<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SOLog.aspx.cs" Inherits="CmlTechniques.CMS.SOLog" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../CasSheet/Grid.CML.css" rel="stylesheet" type="text/css" />  
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1" />    
    <script type="text/javascript">
    function pageLoad() {
    }
    function Fullscreen() {
        var myFrameset = parent.document.getElementById("main");
        var value = myFrameset.getAttribute("cols");
        if (value == "210px,100%") {
            parent.document.getElementById("main").cols = "0px,100%";
            parent.document.getElementById("container").rows = "0px,100%";
        }
        else {
            parent.document.getElementById("main").cols = "210px,100%";
            parent.document.getElementById("container").rows = "115px,100%";
        }
    }
    </script>  
    <style type="text/css">
    body {
    overflow:hidden;
    }    
    div.RadComboBox_Default .rcbInputCell INPUT.rcbInput
    {
	    font-style: normal;
	    font-family: verdana;
	    font-size: 11px;
	    font-weight: normal;
	    vertical-align: middle;
    }
         .aTableCol 
    {
        border-top-width: 1pt;
        border-right-width: 1pt;    
        border-bottom-width: 1pt;    
        border-color: #FFFFFF;
        border-top-style: solid;
        border-right-style: solid;
        border-bottom-style: solid;
        padding: 5px;
    }
    
    .aTableColLast
    {
    	border-top-width: 1pt;  
        border-color: #FFFFFF;
        border-top-style: solid;
        border-bottom-style: solid;
        border-bottom-width: 1pt; 
    }
</style>  
</head>
<body>
    <form id="form1" runat="server" style="overflow:visible;">
    <telerik:RadScriptManager runat="server" ID="RadScriptManagerSOLog" />
     <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>           
            <telerik:AjaxSetting AjaxControlID="btnUpdate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdSOLog" LoadingPanelID="RadAjaxLoadingPanel1"/>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" IsSticky="true" Style="position: absolute; top: 0; left: 0; height: 100%; width: 100%;"/>
    <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" DecorationZoneID="dvGrid" EnableRoundedCorners="false" DecoratedControls="All" />
     <div runat="server" id="dvfixedhead" style="height:30px;">
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>
                <div id="infobar">
                    <div class="prjinfo">
                        <div class="pullleft font-big">
                            <a href="#" onclick="Fullscreen();"><i class="fa fa-align-justify"></i></a> CMS :
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c"></asp:Label></div>
                        <div class="pullright font-big">
                            <asp:Label ID="package" runat="server" Style="color: #e6422c" Text=""></asp:Label>
                        </div>
                    </div>
                </div>             
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div  >  
        <div  style="border-width: 0px thin thin thin; width: 100%; font-family: verdana; font-size: x-small; border-right-color: #FFFFFF; border-bottom-color: #FFFFFF; border-left-color: #FFFFFF; border-right-style: solid; border-bottom-style: solid; border-left-style: solid;">    
        <asp:Label ID="lblid" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblprj" runat="server" Text="" Style="display: none"></asp:Label>
        <asp:Label ID="lblaccess" runat="server" Text="" Style="display: none"></asp:Label>
         <asp:Label ID="lblNewProject" runat="server" Text="" Style="display: none"></asp:Label>
        <div style="height:40px;width: 100%;">
        <table cellspacing="0" style="padding: 0px; margin: 0px; background-color: #040F1C; color: White; width: 100%; " >
            <tr>
                <td align="center" style="font-size: xx-large; font-weight: bold;border-right-style: solid; border-right-width: 1pt; border-right-color: #FFFFFF; width:7%;">
                    SO
                </td>
                <td style="width:83%;" align="center"> 
                    <table id="tblAdd" runat="server" style="width:100%;"><tr><td align="center"  style="width:13%;">            
                    <telerik:RadComboBox ID="rcbPackage" runat="server"  EmptyMessage="Service"  Width="90%" markfirstmatch="True" allowcustomtext="false" Skin="WebBlue"></telerik:RadComboBox>
                    </td> 
                    <td style="width:15%;" align="center" id="tdBuildingAdd" runat="server">                           
                    <telerik:RadComboBox ID="rcbBuilding" runat="server" EmptyMessage="Building" Width="100%" markfirstmatch="True" allowcustomtext="false" Skin="WebBlue"></telerik:RadComboBox>
                    </td>                      
                    <td style="width:40%;" align="center">                           
                    <telerik:RadTextBox ID="rtxtSubject" Width="98%" runat="server" Height="22px" EmptyMessage="Subject(s)" Skin="WebBlue" EnableEmbeddedSkins="false" HoveredStyle-Font-Italic="false" EmptyMessageStyle-Font-Italic="false" EmptyMessageStyle-ForeColor="GrayText" ></telerik:RadTextBox>
                    </td>                    
                    <td style="width:19%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>                                
                            <telerik:RadComboBox ID="rcbIssued" runat="server" DataTextField="uid" Width="100%"  Skin="WebBlue" 
                             EmptyMessage="Issue To"  markfirstmatch="True" allowcustomtext="false"></telerik:RadComboBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td style="width:13%;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnadd" runat="server" Text="Create SO" OnClick="btnadd_Click" Width="90%" Font-Bold="True" CssClass="Button_WebBlue" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>    
                    </tr></table>   
                </td>       
                <td style="width: 10%; border-left-style: solid; border-left-width: 1px; border-left-color: #FFFFFF;" align="center">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnprint" runat="server" Text="Print Log" Style="cursor: pointer;" CssClass="Button_WebBlue" Width="80%" OnClick="btnprint_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>    
        </div>    
    <div style="width: 100%; background-color:#13264F;">
     <div style="overflow:scroll; padding-left:0px;padding-right:1px; overflow-x:hidden;height:40px;">
        <table runat="server" id="tblSOLohHeader" width="100%" style="margin: 0px; height:40px; font-family: Verdana; font-size: 11px; line-height: 13px; background-color:#13264F; color: #FFFFFF; float:left; display:inline-table;" cellpadding="0" cellspacing="0">
            <tr runat="server" id="tblCloseDate">
            <td class="aTableCol" width="5.5%"  align="center">SO No.</td>
            <td class="aTableCol" width="7%">Service</td>
            <td id="tdBuildingHeader" class="aTableCol" width="7%">Building</td>
            <td class="aTableCol" width="20%">Subject(s)</td>
            <td class="aTableCol" align="center" width="6.5%">Issue Date</td>
            <td class="aTableCol" width="12%">Recorded By</td>
            <td class="aTableCol" width="12%">Issued To</td>
            <td class="aTableCol" width="8%" align="center">Comments / Responses</td>
            <td class="aTableCol" width="7%"  align="center">Status</td>
            <td id="tdCloseDateHeader" class="aTableCol"  align="center" width="7%" >Close Date</td>
            <td class="aTableCol" width="6%"  align="center">Overdue Days</td>
            <td class="aTableColLast"  id="tdEditSOHeader" width="2%" ></td> 
          </tr>          
      </table>
     </div>
    </div>
        <div runat="server" id="dvGrid" style="width: 100%;position:absolute; overflow: scroll; overflow-x:hidden; bottom: 0px; right: 0px; left: 0px;top:81px;">
            <table width="100%" style="border-style: none solid none solid; border-width: 0px 1px 0px 2px; border-color: #FFFFFF; background-color: #040F1C;" cellspacing="0">
            <tr >
                <td width="5.5%">&nbsp;</td>
                <td style="padding: 2px 2px 2px 0px; vertical-align: middle;" width="7%">
                <asp:UpdatePanel runat="server" ID="upServiceList">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="RadComboBoxService"  MaxHeight="200" Skin="WebBlue"  AppendDataBoundItems="true" runat="server" OnClientSelectedIndexChanged="ServiceFilterChanged" Width="100%"  >     
                            <Items>
                                <telerik:RadComboBoxItem Text="All" />
                            </Items>                                     
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                <td id="tdBuildingFilter" runat="server" style="padding: 2px 0px 2px 0px; vertical-align: middle;" width="7%">
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="RadComboBoxBuilding" MaxHeight="200" AppendDataBoundItems="true" runat="server" Skin="WebBlue" OnClientSelectedIndexChanged="BuildingFilterChanged" Width="100%"  >     
                            <Items>
                                <telerik:RadComboBoxItem Text="All" />
                            </Items>         
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                <td width="20%"></td>
                <td width="6.5%"></td>
                <td  style="padding: 2px 3px 2px 0px;" width="12%">
                <asp:UpdatePanel runat="server" ID="upUserList">
                <ContentTemplate>
                    <telerik:RadComboBox ID="RadComboBoxRecordedBy"  MaxHeight="200" AppendDataBoundItems="true" Skin="WebBlue" runat="server" OnClientSelectedIndexChanged="RecordedByFilterChanged"  Width="100%">  
                        <Items>
                            <telerik:RadComboBoxItem Text="All" />
                        </Items>             
                    </telerik:RadComboBox>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                <td  style="padding: 2px 1px 2px 1px;" width="12%">
                <asp:UpdatePanel runat="server" ID="upIssuedList">
                <ContentTemplate>
                    <telerik:RadComboBox ID="RadComboBoxIssuedTo" MaxHeight="200" AppendDataBoundItems="true" Skin="WebBlue" Width="100%" runat="server" OnClientSelectedIndexChanged="IssuedToFilterChanged" >
                        <Items>
                            <telerik:RadComboBoxItem Text="All" />
                        </Items>
                    </telerik:RadComboBox>
                </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                <td  width="8%"></td>
                <td style="padding: 2px 2px 2px 0px; " width="7%">
                <asp:UpdatePanel runat="server" ID="upStatusList">
                  <ContentTemplate>
                  <telerik:RadComboBox ID="RadComboBoxStatus" MaxHeight="150" AppendDataBoundItems="true" Skin="WebBlue" Width="100%" runat="server" OnClientSelectedIndexChanged="StatusFilterChanged"  >
                    <Items>
                        <telerik:RadComboBoxItem Text="All" />
                    </Items>
                  </telerik:RadComboBox>
                  </ContentTemplate>
                </asp:UpdatePanel>
                </td>
                <td id="tdCloseDateFilter" runat="server" style="padding: 5px 5px 5px 5px;" width="7%">&nbsp;</td>
                <td align="center" style="padding: 0;font-weight:bold;"  width="6%">
                <asp:Button ID="btnResetFilters" runat="server" Text="Reset"  OnClick="btnResetFilters_Click" Width ="100%" CssClass="boxbutton"  Font-Names="verdana" Font-Size="X-Small" Font-Bold="true" Height="20px" />
                </td > 
                <td  id="tdEditSOFilter" width="2%" runat="server" ></td> 
            </tr>
            </table>  
            <asp:UpdatePanel ID="upGrid" runat="server">
            <ContentTemplate>
            <telerik:RadGrid runat="server" Width="100%" ID="grdSOLog" AllowFilteringByColumn="true" AllowPaging="false" OnItemDataBound="grdSOLog_ItemDataBound" AutoGenerateColumns="false"
            CssClass="RadGrid_WebBlue" BorderStyle="None" EnableEmbeddedBaseStylesheet="false"  EnableEmbeddedSkins="false" EnableLinqExpressions="false" GridLines="None" 
             OnItemCommand="grdSOLog_ItemCommand">   
            <MasterTableView CommandItemDisplay="None"  GridLines="None" TableLayout="Fixed">   
            <Columns>               
                <telerik:GridButtonColumn HeaderText="sono" UniqueName="so_no" Resizable="false" DataTextField="so_no" ItemStyle-Font-Underline="true" 
                ItemStyle-ForeColor="#0066ff" CommandName="SOEdit" ItemStyle-HorizontalAlign="Center">  
                <HeaderStyle Width="5.5%" />  
                </telerik:GridButtonColumn>
                <telerik:GridBoundColumn HeaderText="package"  DataField="package" Resizable="false" UniqueName="package" >
                 <FilterTemplate>         
                    <telerik:RadScriptBlock ID="RadScriptBlock_Service" runat="server">
                        <script type="text/javascript">
                            function ServiceFilterChanged(sender, args) 
                            {
                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");                        
                                tableView.filter("package", args.get_item().get_value(), "EqualTo");                                           
                            }
                        </script>
                    </telerik:RadScriptBlock>
                </FilterTemplate> 
                <HeaderStyle Width="7%" />         
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn HeaderText="Building"  DataField="Building" Resizable="false" UniqueName="Building" >
                 <FilterTemplate>         
                    <telerik:RadScriptBlock ID="RadScriptBlock_Building" runat="server">
                        <script type="text/javascript">
                            function BuildingFilterChanged(sender, args) 
                            {
                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");                        
                                tableView.filter("Building", args.get_item().get_value(), "EqualTo");                                           
                            }
                        </script>
                    </telerik:RadScriptBlock>
                </FilterTemplate> 
                <HeaderStyle Width="7%" />         
                </telerik:GridBoundColumn>              
                <telerik:GridTemplateColumn AllowFiltering="false" DataField="doc_name" UniqueName="doc_name" HeaderText="Subject(s)">
                <HeaderStyle Width="20%" /> 
                <ItemTemplate >
                <table style="border-style:none; border:0; table-layout: fixed;" width="100%" cellpadding="0"  ><tr>                
                <td align="left" style="text-align: left; width:100%; word-wrap:break-word;border-style:none; border:0; padding:0;">
                <asp:Label id="lblSubject" runat="server" Text='<%# Eval("doc_name") %>'   />
                </td>
                </tr></table>                      
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderText="Issue Date" DataField="issued_date" Resizable="false" AllowFiltering="false" ItemStyle-HorizontalAlign="Center">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderStyle Width="6.5%" />  
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="userid" DataField="userid" Resizable="false" UniqueName="userid"  >
                <FilterTemplate>           
                    <telerik:RadScriptBlock ID="RadScriptBlock_RecordedBy" runat="server">
                        <script type="text/javascript">
                            function RecordedByFilterChanged(sender, args) 
                            {
                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                tableView.filter("userid", args.get_item().get_value(), "EqualTo");
                            }
                        </script>
                    </telerik:RadScriptBlock>
                </FilterTemplate>    
                <HeaderStyle Width="12%" />           
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="issued" DataField="issued" Resizable="false" UniqueName="issued" >
                 <FilterTemplate>          
                    <telerik:RadScriptBlock ID="RadScriptBlock_IssuedTo" runat="server">
                        <script type="text/javascript">
                            function IssuedToFilterChanged(sender, args) 
                            {
                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                tableView.filter("issued", args.get_item().get_value(), "EqualTo");
                            }
                        </script>
                    </telerik:RadScriptBlock>
                </FilterTemplate> 
                <HeaderStyle Width="12%" />        
                </telerik:GridBoundColumn>        
                 <telerik:GridBoundColumn UniqueName="comment"  DataField="comment" Resizable="false" AllowFiltering="false" ItemStyle-HorizontalAlign="Center" >
                 <HeaderStyle Width="4%" />  
                 </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="response"  DataField="response" Resizable="false" AllowFiltering="false"  ItemStyle-HorizontalAlign="Center">
                <HeaderStyle Width="4%" />  
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="drstatus" DataField="drstatus" Resizable="false" UniqueName="drstatus" ItemStyle-HorizontalAlign="Center">
                <FilterTemplate>            
                    <telerik:RadScriptBlock ID="RadScriptBlock_Status" runat="server">
                        <script type="text/javascript">
                            function StatusFilterChanged(sender, args) 
                            {
                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                tableView.filter("drstatus", args.get_item().get_value(), "EqualTo");
                            }
                        </script>
                    </telerik:RadScriptBlock>
                </FilterTemplate> 
                <HeaderStyle Width="7%" />  
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Close Date" UniqueName="Closeout_Date" Resizable="false" DataField="Closeout_Date" AllowFiltering="false" ItemStyle-HorizontalAlign="Center" >
                <HeaderStyle Width="7%" />  
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="due" DataField="due" UniqueName="due" Resizable="false" ItemStyle-HorizontalAlign="Center">        
                <HeaderStyle Width="6%" />  
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="so_id"  AllowFiltering="false" UniqueName="so_id" Resizable="false" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEditSO" runat="server" CommandName="StatusEdit" ><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                    </ItemTemplate>  
                    <ItemStyle HorizontalAlign="Center" /> 
                     <HeaderStyle Width="2%" />          
                </telerik:GridTemplateColumn>        
            </Columns>
            </MasterTableView>
            </telerik:RadGrid>
            </ContentTemplate></asp:UpdatePanel>  
        </div> 
        <div>
         <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" BorderStyle="Solid" KeepInScreenBounds="true" DestroyOnClose="true"  
            Title="" EnableShadow="true" Behaviors="Close, Move" VisibleStatusbar="false" Skin="WebBlue" Width="460px" Height="310px">
            <ContentTemplate>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>                
                       <div style="padding: 10px;">
                            <table border="0" cellpadding="0" cellspacing="5" style="font-family: verdana; font-size: 11px; width:100%;">
                                <tr>
                                <td style="width: 120px">Service </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadComboBox ID="rcbService_Edit" runat="server" Width="150px" Font-Names="Verdana" Font-Size="11px" EmptyMessage="Select Service" ></telerik:RadComboBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                </tr>
                                 <tr id="trBuildingEdit" runat="server">
                                <td  style="width: 120px">Building </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>                                            
                                            <telerik:RadComboBox ID="rcbBuilding_Edit" runat="server" Width="150px" Font-Names="Verdana" Font-Size="11px" EmptyMessage="Select Building" >                                                                                        
                                            </telerik:RadComboBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                </tr>
                                <tr>
                                <td style="width: 120px">Subject</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txt_subject" runat="server" Width="300px" TextMode="MultiLine" Height="75px" Font-Size="11px" Font-Names="Verdana"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                </tr>
                                <tr>
                                <td align="left" valign="middle" width="120PX">Status</td>
                                <td align="left" valign="middle">
                                    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                        <ContentTemplate>
                                        <telerik:RadComboBox ID="sostatus1" AutoPostBack="true" runat="server" Width="150px" Font-Names="Verdana" Font-Size="11px" 
                                        OnSelectedIndexChanged="sostatus1_SelectedIndexChanged" >
                                        <Items>
                                           <telerik:RadComboBoxItem Text="OPEN" Value="OPEN" />
                                            <telerik:RadComboBoxItem Text="CLOSED" Value="CLOSED" />
                                        </Items>
                                        </telerik:RadComboBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                </tr>
                                <tr id="trcdate" runat="server">
                                <td align="left" valign="middle" width="120PX" id="tdLabelClose">Close-Out Date</td>
                                <td >
                                    <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                    <ContentTemplate>                                    
                                      <telerik:RadDatePicker ID="RadDatePicker_CloseDate" runat="server"  >
                                      <DateInput ID="DateInput1" runat="server" DateInput-DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"> </DateInput> </telerik:RadDatePicker>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>                                    
                                </td>
                                </tr>                       
                            </table>
                        </div>                   
                        <table width="100%" style="position:absolute;bottom:20px;left:30px;">
                        <tr>
                        <td >
                        <div style="float:left;padding-left:10px;">
                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnupdate" runat="server" Height="25px" OnClick="btnupdate_Click"
                                    Text="Update" />&nbsp;&nbsp;
                                <asp:Button ID="btncancel1" Height="25px" runat="server" OnClick="btncancel1_Click"
                                    Text="Cancel" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                        </td>
                        </tr>
                        </table>  
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate>
        </telerik:RadWindow>
        </div>
        <div id="Div2" runat="server" style="position:absolute; z-index:40;top:30%;left: 35%">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upGrid">
        <ProgressTemplate>
        <asp:Image ID="imgload1" runat="server" ImageUrl="../images/loading.gif" Height="200px" Width="250px" />
        </ProgressTemplate>
        </asp:UpdateProgress>
        </div> 
        </div> 
    </div>     
</form>
</body>
</html>
