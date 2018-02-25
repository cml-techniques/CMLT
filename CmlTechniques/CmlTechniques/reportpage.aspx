<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportpage.aspx.cs" Inherits="CmlTechniques.reportpage" Debug="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    
    <script type="text/javascript">
    //www.findandsecure
      function pageLoad() {
      }
    
    </script>
   
    <%--<script language="javascript" type="text/javascript">
        function onCancel() {
           var lblMsg = $get('<%=lblMessage.ClientID%>');
                       lblMsg.innerHTML = "You clicked the <b>Cancel</b> button of AJAX confirm.";
            

        }
      </script>--%>
      <style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
</style>
<title>CML Interactive</title>
    </head>
     <script language="javascript" type="text/javascript">
    function CallPrint(strid)
{ 

var headstr = "<html><head><title>CML Techniques Reports</title></head><body>";

var footstr = "</body></html>"

var WinPrint = window.open('','','left=150,top=150,width=1024,height=600,menubar=1,toolbar=0,scrollbars=1,status=0'); 

WinPrint.document.write(headstr + strid.innerHTML + footstr); 

WinPrint.document.close(); 

WinPrint.focus(); 

WinPrint.print(); 
}
    
    </script>
    <script type="text/javascript">
        function ShowTime() {
            var dt = new Date();
            document.getElementById('time').innerHTML = dt.toLocaleDateString() + ' , ' + dt.toLocaleTimeString();
            window.setTimeout("ShowTime()", 1000);
        }             
    </script>
<body >
    <form id="form1" runat="server">
    <div  >
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        
        
                                    
        
        
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%;">
        
            <tr >
                <td   valign="top" width="100%" height="77%" >
              <div style="width: 100%; height: 100%; overflow: auto; vertical-align: top;">   
              <%--<iframe id="myframe" runat="server" frameborder="0" width="100%" name="myframe" height="100%"  ></iframe>  --%>    
               <div id="mydiv" runat="server" name="mydiv">  
                  <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td bgcolor="#092443">
                                    &nbsp;</td>
                                <td bgcolor="#092443" height="25px" valign="middle" width="124px">
                                    <asp:Button ID="cmdreturn" runat="server" 
                                        Font-Names="Verdana" Font-Size="X-Small" ForeColor="Red" 
                                         Text="Return to Main Menu" Width="130px" onclick="cmdreturn_Click" />
                                </td>
                                <td align="center" bgcolor="#092443" height="25px" valign="middle" 
                                    width="100%"  >
                                    <asp:Label ID="heading" runat="server" Font-Bold="False" 
                                        Font-Names="Verdana" Font-Size="Medium" 
                                        ForeColor="White"></asp:Label>
                                </td>
                                <td bgcolor="#092443" height="25px" valign="middle" 
                                    width="124px" align="right">
                                    <asp:Button ID="cmdprint" runat="server" Width="81px"
                                        Font-Names="Verdana" Font-Size="X-Small" ForeColor="Red" 
                                        OnClientClick ="javascript:CallPrint(forPrint);" Text="Print Report" 
                                        onclick="cmdprint_Click" />
                                <%--<a href="#" onclick="javascript:CallPrint(forPrint);">Click here to Print</a>--%>    
                                </td>
                                
                                <%--<asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="cmdprint" 
                                    ConfirmText="Do you want to change the status?" 
                                    ondatabinding="ConfirmButtonExtender1_DataBinding"  >
                                </asp:ConfirmButtonExtender>--%>
                                <td bgcolor="#092443">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td colspan="3" width="100%" valign="top" height="100%">
                                    <asp:Panel ID="pnlmenu" runat="server" BorderColor="#CCCCCC" BorderStyle="None" 
                                        Width="100%">
                                        <table style="font-family:Verdana; font-size: small">
                                        <tr>
                                                <td valign="middle" colspan="2" align="left">
                                                    <%--Select Package
                                                    <asp:DropDownList ID="drpackage" runat="server" Width="400px">
                                                    </asp:DropDownList>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" width="81">
                                                    <asp:Button ID="view1" runat="server" Font-Names="Verdana" 
                                                        Font-Size="X-Small" ForeColor="Red" onclick="view1_Click" Text="Run Report" />
                                                </td>
                                                <td>
                                                    &nbsp;Manual QUICKVIEW (Summary of O &amp; M Mannuals uploaded,comments tally and current 
                                                    status with links to view the document)&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="view2" runat="server" Font-Names="Verdana" 
                                                        Font-Size="X-Small" ForeColor="Red" Text="Run Report" 
                                                        onclick="view2_Click" />
                                                </td>
                                                <td>
                                                    &nbsp;Summary of all documents uploaded by package&nbsp;</td>
                                            </tr>
                                            <%--<tr>
                                                <td>
                                                    <asp:Button ID="view3" runat="server" Font-Names="Verdana" 
                                                        Font-Size="X-Small" ForeColor="Red" Text="Run Report" onclick="view3_Click" 
                                                         />
                                                         </td>
                                                <td>
                                                    &nbsp;Document List&nbsp;</td>
                                            </tr>--%>
                                        </table>
                                        <br />
                                    </asp:Panel>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td  valign="top" align="left"  width="100%" colspan="3">
                                <div id="forPrint" runat="server" name="mydiv1">
                                    <asp:Label ID="rpthead" runat="server" Font-Names="Verdana" 
                                        Font-Size="Medium" ForeColor="Blue"></asp:Label> 
                                <%--<asp:GridView ID="mydocgrid" runat="server" CellPadding="4" Width="100%"
                                        Font-Names="Verdana" Font-Size="X-Small"  AutoGenerateColumns="False" 
                                        ForeColor="#333333" PageSize="20" 
                                        onselectedindexchanged="mydocgrid_SelectedIndexChanged2" HorizontalAlign="Left" 
                                        
                                        >
                                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" 
                                            HorizontalAlign="Left" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                        <asp:BoundField DataField="package" HeaderText="PACKAGE" >
                                            <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME" >
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="350px" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="uploaded_date" HeaderText="UPLOADED DATE" DataFormatString="{0:dd/MM/yyyy}"
                                                ItemStyle-Width="250px" >
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="250px" />
                                            </asp:BoundField>
                                        
                                                                                
                                        </Columns>
                                    </asp:GridView>--%> 
                                    
                                    <asp:GridView ID="mygridom" runat="server" CellPadding="4" Width="100%"
                                        Font-Names="Verdana" Font-Size="X-Small"  AutoGenerateColumns="False" 
                                        ForeColor="#333333" PageSize="20" 
                                        HorizontalAlign="Left" onrowcommand="mygridom_RowCommand" 
                                        onrowdatabound="mygridom_RowDataBound" GridLines="None" 
                                        
                                        >
                                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="false" ForeColor="White" 
                                            HorizontalAlign="Left" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                        <asp:BoundField DataField="Folder_Description" HeaderText="PACKAGE" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            <ItemStyle Font-Names="Verdana" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="doc_name" HeaderText="DOCUMENT NAME" ItemStyle-Width="250px" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            <ItemStyle Width="250px" />
                                            </asp:BoundField>                                 
                                        <asp:BoundField DataField="uploaded_date"  HeaderText="UPLOADED DATE" DataFormatString="{0:dd/MM/yyyy}"  >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="version" HeaderText="VERSION" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="comments" HeaderText="TOTAL COMMENTS" >
                                            <HeaderStyle Font-Bold="False" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           <asp:ButtonField ButtonType="Button" Text="view" ItemStyle-HorizontalAlign="Right" 
                                                ItemStyle-Width="40px" ControlStyle-Font-Names="Verdana" ControlStyle-Font-Size="XX-Small" ControlStyle-ForeColor="Red"  >                                            
                                            <ControlStyle Font-Names="Arial,Helvetica,sans-serif" Font-Size="XX-Small" 
                                                ForeColor="Red" />
                                            <ItemStyle HorizontalAlign="Left" Width="30px"  />
                                           
                                            </asp:ButtonField> 
                                        <asp:BoundField DataField="comments_out" HeaderText="OUTSTANDING COMMENTS" >
                                            <HeaderStyle HorizontalAlign="Right" Font-Bold="False" />
                                            
                                            <ItemStyle HorizontalAlign="Center" />
                                            
                                            </asp:BoundField>
                                            
                                        <asp:ButtonField ButtonType="Button" Text="view" ItemStyle-HorizontalAlign="Right" 
                                                ItemStyle-Width="50px" ControlStyle-Font-Names="Verdana" ControlStyle-Font-Size="XX-Small" ControlStyle-ForeColor="Red"  >                                            
                                            <ControlStyle Font-Names="Arial,Helvetica,sans-serif" Font-Size="XX-Small" 
                                                ForeColor="Red" />
                                            <ItemStyle HorizontalAlign="Left" Width="30px"  />
                                           
                                            </asp:ButtonField>
                                            
                                        <asp:BoundField DataField="status" HeaderText="STATUS" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="doc_id"  />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:GridView ID="mygridsummary" runat="server" CellPadding="4" Width="100%"
                                        Font-Names="Verdana" Font-Size="X-Small"  AutoGenerateColumns="False" 
                                        ForeColor="#333333" PageSize="20" 
                                        HorizontalAlign="Left" onrowdatabound="mygridsummary_RowDataBound" >
                                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="false" ForeColor="White" 
                                            HorizontalAlign="Left" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                        <asp:BoundField DataField="package" HeaderText="PACKAGE" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="manual" HeaderText="MANUAL UPLOADED" ItemStyle-Width="75px">
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />

<ItemStyle Width="75px"></ItemStyle>
                                            </asp:BoundField>
                                        <asp:BoundField DataField="uploaded_date" HeaderText="UPLOADED DATE" 
                                                DataFormatString="{0:dd/MM/yyyy}" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="status" HeaderText="STATUS" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="document_type" HeaderText="DOCUMENT" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="scheduled" HeaderText="TOTAL SCHEDULED" >
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="uploaded" HeaderText="TOTAL UPLOADED" >
                                        
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="percentage" HeaderText="% OF UPLOADED" >                        
                                            <HeaderStyle HorizontalAlign="Left" Font-Bold="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="folder_id" />
                                        </Columns>
                                    </asp:GridView>
                                </div>                                       
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td  valign="top" colspan="3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td  valign="top" align="left" colspan="3">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                </div>
                </div>
                    </td>
            </tr>
        </table>
    
    </div>
                                    
                                     
    </form>
</body>
</html>
