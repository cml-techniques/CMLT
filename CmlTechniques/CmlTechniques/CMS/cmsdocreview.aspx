<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cmsdocreview.aspx.cs" Inherits="CmlTechniques.CMS.cmsdocreview" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
  
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" /> 
     <link href="../CasSheet/Grid.CML.css" rel="stylesheet" type="text/css" /> 
     <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
     <meta http-equiv="X-UA-Compatible" content="IE=Edge,chrome=1" />  
    <script type="text/javascript">
        function callpop(id) {
            document.getElementById("drstatus1").SelectedText = "CLOSE";
        }
    </script>
    <style type="text/css">
    body { overflow:hidden;  }
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
        border-color: #FFFFFF;
        border-top-style: solid;
        border-right-style: solid;
        border-left-style: none;
        padding: 5px;
    }

    .aTableColLast
    {
        border-top-width: 1pt; 
        border-color: #FFFFFF;
        border-top-style: solid;
        border-right-style: none;
        border-left-style:none;
        padding: 5px;
    }
    .ddlFilters
    {
        font-family:Verdana;
        font-size:x-small;
        height:20px;
        width:100%;
    }
    .centerAlignItem
    {
    	text-align:center;
    	border-style: solid;
    	border-color: #003366;
    	border-width: 1px;
    	padding:0;   
    	text-decoration:underline; 	
    }
      .aGrid
    {
    	table-layout:fixed;
    }
    </style>
     <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />
         <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body style="height:100%; margin:0px;">
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManagerDocReview" />
    <div class="fixedhead" runat="server" id="dvfixedhead">
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>
                <div id="infobar">
                    <div class="prjinfo">
                        <div class="pullleft font-big">
                            <a href="#" onclick="Fullscreen();"><i class="fa fa-align-justify"></i></a> CMS :
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c" ></asp:Label></div>
                        <div class="pullright font-big">
                            <asp:Label ID="package" runat="server" Style="color: #e6422c" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <%--<div id="pagetitle" runat="server">
                    <asp:Label ID="phead" runat="server" test="hi"></asp:Label>
                </div>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="border-style: none solid solid solid; display:block; top:31px; left:0px; right:0px; bottom:0; position:absolute; border-right-width: thin; border-bottom-width: thin; border-left-width: thin; border-right-color: #FFFFFF; border-bottom-color: #FFFFFF; border-left-color: #FFFFFF;" runat="server" id="dvfixedcontent"   >
    <div style="font-family: verdana; font-size: x-small;height:100%;width:100%">       
        <asp:Label ID="lblid" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblaccess" runat="server" Text="" style="display:none"></asp:Label>
        <asp:Label ID="lblNewProject" runat="server" Text="" style="display:none"></asp:Label>
        <div>
        <table style="background-color:#040F1C; color:White; width:100%;" cellspacing="0" >
        <tr>
        <td style="font-size: xx-large; font-weight: bold; border-right-style: solid; border-right-width: 1px; border-right-color: #FFFFFF; width:7%;" align="center">DR</td>
        <td style="width:83%;border-right-style: solid; border-right-width: 1px; border-right-color: #FFFFFF;">
            <table style="width:100%;" id="tblAddDR" runat="server"><tr>
            <td style="width:13%;" align="center">                           
            <telerik:RadComboBox ID="rcbPackage" runat="server" EmptyMessage="Service" Width="90%" markfirstmatch="True" allowcustomtext="false" Skin="WebBlue"></telerik:RadComboBox>
            </td>   
            <td style="width:15%;" align="center" id="tdBuildingAdd" runat="server">                           
                <telerik:RadComboBox ID="rcbBuilding" runat="server" EmptyMessage="Building" Width="100%" markfirstmatch="True" allowcustomtext="false" Skin="WebBlue"></telerik:RadComboBox>
            </td>                      
            <td style="width:40%;" align="center">                           
            <telerik:RadTextBox ID="rtxtDocuments" Width="96%" runat="server" Height="22px" EmptyMessage="Document(s)" Skin="WebBlue" EnableEmbeddedSkins="false" HoveredStyle-Font-Italic="false" EmptyMessageStyle-Font-Italic="false" EmptyMessageStyle-ForeColor="GrayText"></telerik:RadTextBox>
            </td>                    
            <td style="width:19%;" align="center">           
            <telerik:RadComboBox ID="rcbIssued" runat="server" DataTextField="uid" Width="100%"  
            EmptyMessage="Issue To"  markfirstmatch="True" allowcustomtext="false" Skin="WebBlue"></telerik:RadComboBox>          
            </td>     
           
            <td style="width:13%;" align="center">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <asp:Button ID="btnadd" runat="server" Text="Create DR" onclick="btnadd_Click" Width="90px" CssClass="Button_WebBlue"/>
            </ContentTemplate>
                </asp:UpdatePanel>
            </td>
       </tr></table></td>
        <td style="width:10%;" align="center">
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnprint" runat="server" Text="Print Log" CssClass="Button_WebBlue" width="90px" onclick="btnprint_Click"/>
            </ContentTemplate>
            </asp:UpdatePanel>
       </td>
        </tr>
        </table>    
        </div>
        <div style="height:100%;width:100%;">
            <div style="overflow:scroll; overflow-x:hidden; padding-right:1px;">
            <table  border="0" style="margin: 0px; border-collapse: collapse; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF; font-size: 11px; border-top-style: solid; border-top-width: 1px; border-top-color: #FFFFFF; border-left-style: none; border-right-style: none;"  width="100%">
            <tr style="background-color:#13264F;">
            <td style="width:4.5%;height:30px; border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF; padding:5px;"  align="center" >DR.No</td>
            <td style="width:7.5%" align="left" class="aTableCol">Service</td>
            <td id="tdBuildingHeader" class="aTableCol" width="7%" runat="server">Building</td>
            <td style="width:20%" align="left" class="aTableCol">Document(s)</td>
            <td style="width:7%" align="center" class="aTableCol">Issue Date</td>
            <td style="width:12%" align="left" class="aTableCol">Recorded By</td>
            <td style="width:12%" align="left" class="aTableCol">Issued To</td>
            <td style="width:8%" colspan="2" align="center" class="aTableCol">Comments / Responses</td>
            <td style="width:7%" align="center" class="aTableCol">Status</td>
            <td style="width:7%" align="center" class="aTableCol" id="tdCloseDateHeader" runat="server">Close Date</td>
            <td style="width:6%" align="center" class="aTableCol">Overdue Days</td>
            <td style="width:2%" align="center" class="aTableColLast" id="tdEditDRHeader" runat="server"></td>          
            </tr>
            </table>  
            </div>          
            <div runat="server" id="dvGrid" style="overflow:scroll; overflow-x:hidden; top: 82px; position:absolute; bottom:0px; right: 0px; left: 0px;width:100%;">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
                <table border="0" style="border-collapse: collapse; border-top-style: solid; border-top-width: 1px; border-top-color: #FFFFFF; border-left-style: none; border-right-style: none;" width="100%">
                 <tr style="background-color:#040F1C; border-color:#040F1C;">
                    <td align="center" style="width:4.5%;">
                        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label><asp:Label ID="lblsrv" runat="server" Text="" CssClass="hidden"></asp:Label>
                    </td>
                    <td align="center" style="padding: 1px 1px 1px 3px; width:7.5%;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="dr_service" runat="server" CssClass="ddlFilters" AutoPostBack="true" OnSelectedIndexChanged="dr_service_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                     <td id="tdBuildingFilter" runat="server" style="padding: 1px 0px 1px 3px;width:7%;">
                    <asp:UpdatePanel runat="server" ID="UpdatePanel17">
                        <ContentTemplate>                          
                             <asp:DropDownList ID="drbuilding" runat="server" CssClass="ddlFilters" AutoPostBack="true" OnSelectedIndexChanged="drbuilding_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td align="center" style="width:20%">    &nbsp;                
                    </td>
                    <td align="center" style="width:7%">
                        &nbsp;</td>
                    <td align="center" style="padding: 1px 3px 1px 1px; width:12%">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="drreview" runat="server" CssClass="ddlFilters" AutoPostBack="true" OnSelectedIndexChanged="drreview_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="center" style="width:12%; padding: 1px 3px 1px 1px;">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="drissue" runat="server" CssClass="ddlFilters" AutoPostBack="true" OnSelectedIndexChanged="drissue_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                    </td>
                    <td align="center"  colspan="2" style="width:8%"></td>
                    <td align="center" style="width:7%; padding: 2px 4px 2px 0px;">
                     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="drstatus" runat="server" CssClass="ddlFilters" AutoPostBack="true" OnSelectedIndexChanged="drstatus_SelectedIndexChanged">                                             
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                    </td>                    
                     <td align="center" style="width:7%"  id="tdCloseDateFilter" runat="server"></td>
                    <td align="center" style="width:6%">
                    <asp:Button ID="btnResetFilters" runat="server" Text="Reset"   Width ="100%"  Font-Names="verdana" Font-Size="X-Small" Font-Bold="True" OnClick="btnResetFilters_Click"/>
                    </td>
                   <td id="tdEditDRFilter" runat="server" style="width:2%;"></td>
                </tr>
                </table>
                    <asp:GridView ID="mygrid_dr" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-BackColor="#F3F3F4" 
                        onrowdatabound="mygrid_dr_RowDataBound" Width="100%" GridLines="None" CellSpacing="1" CellPadding="5" ShowHeader="false" 
                        onrowcommand="mygrid_dr_RowCommand" EmptyDataText="No records to display" CssClass="aGrid" >
                    <Columns>                    
                    <asp:ButtonField ButtonType="Link" DataTextField="dr_no" CommandName="get" >
                        <ItemStyle Width="4.5%" ForeColor="#0099CC" CssClass="centerAlignItem"/>
                        </asp:ButtonField>
                    <asp:BoundField DataField="service">
                        <ItemStyle Width="7.5%" HorizontalAlign="Left"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                   <asp:BoundField DataField="building" >
                    <ItemStyle Width="7%" HorizontalAlign="Left"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="dr_reviewed" >
                        <ItemStyle Width="20%" HorizontalAlign="Left" BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                    <asp:BoundField DataField="issue_date" >
                        <ItemStyle Width="7%" HorizontalAlign="Center"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                    <asp:BoundField DataField="userid" >
                        <ItemStyle Width="12%" HorizontalAlign="Left"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="issued" >
                        <ItemStyle Width="12%" HorizontalAlign="Left"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                    <asp:BoundField DataField="comments" >
                        <ItemStyle Width="4%" HorizontalAlign="Center"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                    <asp:BoundField DataField="response" >
                        <ItemStyle Width="4%" HorizontalAlign="Center"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                    <asp:BoundField DataField="drstatus" >
                        <ItemStyle Width="7%" HorizontalAlign="Center"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                       <asp:BoundField DataField="Closeout_Date" >
                        <ItemStyle Width="7%" HorizontalAlign="Center"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>
                     <asp:BoundField  DataField="due">
                        <ItemStyle Width="6%" HorizontalAlign="Center"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>
                        </asp:BoundField>              
                        <asp:TemplateField>
                            <ItemTemplate>
                            <asp:LinkButton ID="btnEditStatus" runat="server" CommandName="status" ><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                            </ItemTemplate>  
                             <ItemStyle Width="2%" HorizontalAlign="Center"  BorderStyle="Solid" BorderColor="#003366" BorderWidth="1px"/>                      
                        </asp:TemplateField>
                    <asp:BoundField DataField="dr_no" />
                    <asp:BoundField DataField="dr_id" />
                    <asp:BoundField DataField="issued_to" />
                    <asp:BoundField DataField="uid" />
                    </Columns>
                    </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            
        <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" BorderStyle="Solid" KeepInScreenBounds="true" DestroyOnClose="true" 
        Title="" EnableShadow="true" Behaviors="Close, Move" VisibleStatusbar="false" Skin="WebBlue" Width="470px" Height="310px">
        <ContentTemplate>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>                
                   <div style="padding: 10px;">
           <table border="0" cellpadding="1"  style="font-family: verdana; font-size: 11px; width:100%;">           
            <tr>
                <td style="width: 120px">SERVICE </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                        <ContentTemplate>
                            <telerik:RadComboBox ID="rcbService_Edit" runat="server" Width="150px" Font-Names="Verdana" Font-Size="11px" EmptyMessage="Select Service" ></telerik:RadComboBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                </tr>
                 <tr id="trBuildingEdit" runat="server">
                <td  style="width: 120px">BUILDING </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>                                            
                            <telerik:RadComboBox ID="rcbBuilding_Edit" runat="server" Width="150px" Font-Names="Verdana" Font-Size="11px" EmptyMessage="Select Building" >                                                                                        
                            </telerik:RadComboBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                </tr>      
            <tr>
              <td style="width:120px">SUBJECT</td>
              <td>
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                  <ContentTemplate>
                  <asp:TextBox ID="txt_subject" runat="server" Width="300px" TextMode="MultiLine" Height="75px" Font-Names="Verdana" Font-Size="11px"></asp:TextBox>
                  </ContentTemplate>
                  </asp:UpdatePanel>      
              </td>
            </tr>
            <tr>
                <td align="left" valign="middle" width="120px">STATUS</td>
                <td align="left"  valign="middle">
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
            <tr id="trCloseDate" runat="server">
            <td align="left" valign="middle" width="120px" >CLOSE-OUT DATE</td>
            <td>
                 <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                <ContentTemplate>                                    
                  <telerik:RadDatePicker ID="RadDatePicker_CloseDate" runat="server"  >
                  <DateInput ID="DateInput1" runat="server" DateInput-DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"> </DateInput> </telerik:RadDatePicker>
                </ContentTemplate>
                </asp:UpdatePanel> 
            </td>
            </tr>
            <tr>
                <td class="footer" height="20px" colspan="2" align="center" >
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                    <asp:Label ID="Label2" runat="server" Text="" style="display:none"></asp:Label>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>           
        </table>
        </div>                   
            <table width="100%"  style="position:absolute;bottom:20px;left:30px;">
            <tr>
            <td >
            <div style="float:left;padding-left:10px;">              
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                    <asp:Button ID="btnupdate" runat="server" Height="25px" onclick="btnupdate_Click" Text="Update" />&nbsp;&nbsp;
                    <asp:Button ID="btncancel1" Height="25px"  runat="server" onclick="btncancel1_Click" Text="Cancel" />
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
        
    </div>
    </div>
    </form>
</body>
</html>
