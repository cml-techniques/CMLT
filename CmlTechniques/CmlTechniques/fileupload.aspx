<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fileupload.aspx.cs" Inherits="CmlTechniques.fileupload" %>

<%@ Register Assembly="com.flajaxian.FileUploader" Namespace="com.flajaxian" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Interactive</title>
    
    <script type="text/javascript">
    
      function pageLoad() {
  
      }
    
    </script>
    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.MultiFile.js" type="text/javascript"></script>   
    <style type="text/css">
    .divScroll { height:36%; 
overflow:auto;width:100%;
        }  
    
    
        .style1
        {
            height: 23px;
        }
    .Flajaxian_FileBox
{
    font-family:Arial,Verdana,sans-serif;
    font-size:12px;
    z-index:900;
    position:absolute;
    left:0px;
    top:0px;
    background-color:White;
    display:none;
}
    
        </style>
        

        <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
       </style> 
       <style type="text/css">
       .fancy .ajax__tab_body .ajax__tab_tab

{

font-family: Arial;
font-size: 10pt;
border-top: 0;
border:1px solid red;
padding: 8px;
background-color: #ffffff;

}
       </style>
   
</head>
<body bgcolor="#ffffff">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    <div style="width: 100%; height: 90%; overflow: auto; ">
       <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>

        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <Triggers>
        <asp:PostBackTrigger ControlID="cmdupload" />
        </Triggers>
        <ContentTemplate>--%>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                                                    </asp:ScriptManager>--%>
        <%--<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
                                                    
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    
                                                    <ContentTemplate>--%>
        <asp:Label ID="Label1" runat="server" Text="" style="display:none"></asp:Label>
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
            Width="100%" BorderColor="White" ScrollBars="Auto" BorderStyle="None">
            <asp:TabPanel runat="server" HeaderText="Document Upload" ID="TabPanel1">
            <ContentTemplate>
            <table style="width: 100%; height: 100%; font-family: verdana; font-size: small;" 
                border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" height="100%">
                    
                    
                        <table>
                        <tr>
                        <td>Package</td>
                        <td>
                            <asp:TextBox ID="txtdoc" runat="server" Width="400px"></asp:TextBox></td>
                        </tr>
                        <tr>
                        <td></td>
                        <td>
                        
                            <asp:Button ID="show" runat="server" Font-Names="Arial,Helvetica,sans-serif" 
                                Font-Size="X-Small" ForeColor="Red" onclick="show_Click" Text="Show Schedule" />
                            <asp:Button ID="cmdupload" runat="server" 
                                Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" ForeColor="Red" 
                                onclick="cmdupload_Click" Text="Upload All" />
                            </td>
                        </tr>
                        </table>
                        <div  >
                            
                        <asp:GridView ID="myschedule_basket" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" 
                             PageSize="5" 
                                onrowdatabound="myschedule_basket_RowDataBound" 
                                onrowcommand="myschedule_basket_RowCommand" 
                                onrowediting="myschedule_basket_RowEditing" 
                                onselectedindexchanged="myschedule_basket_SelectedIndexChanged" 
                                onrowupdating="myschedule_basket_RowUpdating" 
                                onselectedindexchanging="myschedule_basket_SelectedIndexChanging" 
                                Font-Names="Verdana" Font-Size="X-Small" >
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                
                                <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server"  AutoPostBack="false"   />   
                                </ItemTemplate>
                                </asp:TemplateField>
                                        <asp:BoundField DataField="package" HeaderText="PACKAGE"  >
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="217px" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="Folder" HeaderText="FOLDER" >
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="217px" />
                                            </asp:BoundField>
                                        <asp:BoundField DataField="manufacture" HeaderText="MANUFACTURE" >  
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="217px" />
                                            </asp:BoundField>  
                                        <asp:BoundField DataField="doc_name" HeaderText="DOC.NAME" >  
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="218px" />
                                            </asp:BoundField>  
                                        <asp:BoundField DataField="Folder_id" >  
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="218px" />
                                            </asp:BoundField>                                             
                                        <asp:TemplateField>
                                        <ItemTemplate >
                                            <%--<asp:FileUpload ID="myupload" runat="server" class="multi" maxlength="1" accept="pdf" /> --%>
                                            <input type="file" id="myupload" class="multi" runat="server" />                                    
                                            <%--<asp:AsyncFileUpload ID="myupload" runat="server" UploaderStyle="Modern" PersistFile="True" />--%>
                                        </ItemTemplate>
                                        
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="id" >
                                                                  
                                            <ItemStyle Width="0px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="srv" />
                                  <asp:BoundField DataField="possition" />                                
                            </Columns> 
                        </asp:GridView>
                     </div>   
                    <br />
                    <asp:Panel ID="pnlPopup" runat="server" Width="350px" style="display:none" >
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" id="tblPopup">
                            <tr>
                                <td class="heading" style="background-image: url('images/headingbg_13.gif'); background-repeat: repeat-x;">
                                    &nbsp;TIME LIMIT FOR DOC.REVIEW&nbsp;</td>
                            </tr>
                            
                            <tr>
                                <td align="center" >
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                    
                                    <table style="font-family: Arial, Helvetica, sans-serif; font-size: small; color: #FFFFFF" width="300px"  >
                                        <tr>
                                            <td align="left" width="200px">
                                                Time Limit (in days)</td>
                                            <td align="left"><asp:TextBox ID="time" runat="server" 
                                                    Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                                                     Width="38px">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                First Reminder after</td>
                                            <td align="left">
                                                <asp:TextBox ID="remind1" runat="server" 
                                                    Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                                                     Width="38px">0</asp:TextBox>&nbsp;Days
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Second Reminder after</td>
                                            <td align="left">
                                                <asp:TextBox ID="remind2" runat="server" 
                                                    Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                                                     Width="38px">0</asp:TextBox>&nbsp;Days
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" >
                                                Third Reminder after</td>
                                            <td align="left" >
                                                <asp:TextBox ID="remind3" runat="server" 
                                                    Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" 
                                                     Width="38px">0</asp:TextBox>&nbsp;Days
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="footer"  >
                                <asp:Button ID="btnCont" runat="server" Text="Continue.." />
                                
                                </td>
                            </tr>
                       </table>
                  </asp:Panel>
                  
                    <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal"
                  OkControlID="btnCont"
                  DropShadow="True" DynamicServicePath="" Enabled="True"                   
                  >
                  </asp:ModalPopupExtender>
                </td>
            </tr>
            
        </table>
            </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="Multi Upload" ID="TabPanel2">
            <ContentTemplate>
            <div style="width:100%">
            <div style="float:left;width:40%">
            <iframe runat="server" id="myframe" frameborder="0" width="100%" height="500px" src="MultiUpload.aspx" ></iframe>
            </div>
            <div style="float:right;width:60%;height:50%;overflow:auto">
                <asp:GridView ID="myschedule" runat="server" CellPadding="4" 
                    ForeColor="#333333" AutoGenerateColumns="False" Font-Names="Verdana" 
                    Font-Size="X-Small" GridLines="None" Width="100%" Height="50%">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                    
                                        <asp:BoundField DataField="doc_name" HeaderText="FILES TO BE UPLOADED" >  
                                            <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>  
                                         
                     </Columns>                      
                </asp:GridView>
            </div>    
            </div>    
            </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
        
        
       <%-- </ContentTemplate>
                                                    </asp:UpdatePanel>   --%>
        <%--<asp:FileUpload ID="myupload" runat="server" class="multi" maxlength="1" accept="pdf" /> --%>
        <%--<asp:CommandField ShowSelectButton="True" />--%>
        <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>
    </form>
</body>
</html>
