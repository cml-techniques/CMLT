<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectmaster.aspx.cs" Inherits="CmlTechniques.projectmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CML Interactive</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
 <link href="page.css" rel="stylesheet" type="text/css" /> 
 <link href="../StyleSheet1.css" rel="stylesheet" type="text/css" />  
 <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('images/head_bg.png');
         background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
        height:30px;
    }
    .btnstyle
    {
    	font-size:xx-small;
    	cursor:pointer;
    	color:Red;
    }
    </style> 
 </head>
<body bgcolor="White">
    <form id="form1" runat="server">
    <div style="height:100%;width:100%;font-family:verdana;font-size: x-small;" >
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
            Width="100%">
                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Project">
                <ContentTemplate>
                <div > 
          <p style="margin:0">
              <asp:Button ID="btnnew" runat="server" Text="Create New Project"  
                  style="background-color:Transparent;border:none;cursor:pointer" 
                  Font-Size="X-Small" onclick="btnnew_Click" /></p>  
              <asp:GridView ID="prjgrid" runat="server" AutoGenerateColumns="False" 
                  Width="100%" onrowdatabound="prjgrid_RowDataBound" Font-Size="X-Small" 
                  onrowcommand="prjgrid_RowCommand">
                  <HeaderStyle CssClass="gvHeaderRow" />
                            <Columns>
                            <asp:ButtonField Text="Edit" ButtonType="Button" CommandName="change" />
                            <asp:BoundField DataField="prj_code" HeaderText="PROJECT CODE" >
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="15%" />
                                </asp:BoundField>
                            <asp:BoundField DataField="prj_name" HeaderText="PROJECT NAME" >
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="35%" />
                                </asp:BoundField>
                            <asp:BoundField DataField="company" HeaderText="COMPANY" >                           
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dms" HeaderText="DMS" >
                                <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cms" HeaderText="CMS" >
                                <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ams" HeaderText="TMS" >
                                <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="description" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                <asp:Panel ID="pnlPopup" runat="server" Width="600px" Height="375px" style="padding:20px;" BackColor="White"  >
        
                    <table width="600px">
                        <tr>
                            <td width="200px">
                                PROJECT CODE&nbsp;</td>
                            <td width="350px" >
                                <asp:TextBox ID="prjcode" runat="server" BorderColor="Silver" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                PROJECT NAME</td>
                            <td >
                                <asp:TextBox ID="prjname" runat="server" BorderColor="Silver" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                LOCATION</td>
                            <td >
                                <asp:TextBox ID="txt_loc" runat="server" BorderColor="Silver" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                MAIN CONTRACTOR</td>
                            <td>
                                <asp:DropDownList ID="dr_maincom" runat="server" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                COMPANIES</td>
                            <td>
                                <asp:CheckBoxList ID="chkcom" runat="server" BorderColor="#F0F0F0" 
                                    BorderStyle="Solid" BorderWidth="1px" Height="100px" RepeatLayout="Flow" 
                                    style="overflow:auto" Width="300px">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                PROJECT DESCRIPTION</td>
                            <td>
                                <asp:TextBox ID="description" runat="server" BorderColor="Silver" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                MODULES</td>
                            <td>
                                <asp:CheckBox ID="chkdms" runat="server" 
                                    Text="DMS - Document Management System" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chkcms" runat="server" 
                                    Text="CMS - Commissioning Management System" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chktms" runat="server" 
                                    Text="AMS - Asset Management System" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chksns" runat="server" Text="SNS - Snagging System" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chktis" runat="server" 
                                    Text="TIS - Tenancy Information System" />
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
                                <asp:Button ID="cmdcreate" runat="server" Font-Names="Verdana" 
                                    Font-Size="Small" OnClick="cmdcreate_Click" Text="Save" />
                                <asp:Button ID="cmdcancel" runat="server" Font-Names="Verdana" 
                                    Font-Size="Small" OnClick="cmdcancel_Click" Text="Cancel" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
      
                        
                  </asp:Panel>
                  <asp:Button ID="btnDummy" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="btnDummy_ModalPopupExtender" runat="server" 
                  TargetControlID="btnDummy"  PopupControlID="pnlPopup"
                  BackgroundCssClass="modal"
                  DropShadow="True" DynamicServicePath="" Enabled="True">
                  </asp:ModalPopupExtender> 
                
         </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Company">
                <ContentTemplate>
                <div > 
          <p style="margin:0">
              <asp:Button ID="btn_newcom" runat="server" Text="Create New Company" 
                  style="background-color:Transparent;border:none;cursor:pointer" 
                  Font-Size="X-Small" onclick="btn_newcom_Click" /></p>  
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:GridView ID="comgrid" runat="server" AutoGenerateColumns="False" 
                        Font-Size="X-Small" Width="600px" onrowdatabound="comgrid_RowDataBound" 
                        onrowcommand="comgrid_RowCommand" >
                        <HeaderStyle CssClass="gvHeaderRow" />
                            <Columns>
                            <asp:ButtonField Text="Edit" ButtonType="Button" CommandName="change" >
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                </asp:ButtonField>
                            <asp:BoundField DataField="Com_code" HeaderText="COMPANY CODE" >
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                </asp:BoundField>
                            <asp:BoundField DataField="Com_name" HeaderText="COMPANY NAME" >
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="400px" HorizontalAlign="Left" />
                                </asp:BoundField>
                            <asp:BoundField DataField="Com_id" />
                            <asp:BoundField DataField="Status" />   
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                
                <asp:Panel ID="pnlPopup1" runat="server" Width="600px" Height="150px" style="padding:20px;display:none" BackColor="White"  >
        
                    <table width="600px">
                        <tr>
                            <td width="200px">
                                COMPANY CODE</td>
                            <td width="350px" >
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                <asp:TextBox ID="txt_comcd" runat="server" BorderColor="Silver" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:TextBox>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                COMPANY NAME</td>
                            <td >
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                <asp:TextBox ID="txt_comname" runat="server" BorderColor="Silver" 
                                    BorderStyle="Solid" BorderWidth="1px" Width="300px"></asp:TextBox>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                <asp:CheckBox ID="chkactive" runat="server" Text="Active" Checked="True" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                                
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
                            <table>
                            <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="btnsave1" runat="server" Font-Names="Verdana" Font-Size="Small" 
                                        Text="Save" onclick="btnsave1_Click" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                <asp:Button ID="btncancel1" runat="server" Font-Names="Verdana" Font-Size="Small" 
                                        Text="Cancel" onclick="btncancel1_Click" />
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            </tr>
                            </table>
                                
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
      
                        
                  </asp:Panel>
                  <asp:Button ID="btnDummy1" runat="server" Text="Button" style="display:none;" />
                  <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" 
                  TargetControlID="btnDummy1"  PopupControlID="pnlPopup1"
                  BackgroundCssClass="modal"
                  DropShadow="True" DynamicServicePath="" Enabled="True">
                  </asp:ModalPopupExtender> 
                
         </div>
                </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
    </div>
    </form>
</body>
</html>
