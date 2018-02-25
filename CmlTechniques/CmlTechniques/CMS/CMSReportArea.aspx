<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMSReportArea.aspx.cs" Inherits="CmlTechniques.CMS.CMSReportArea" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                Height="400px" Width="100%">
                <asp:TabPanel runat="server" HeaderText="Cas Sheet" ID="TabPanel1">
                <ContentTemplate>
                <div style="padding:20px">
        <asp:Accordion ID="Accordion1" runat="server">
        <Panes>
        <asp:AccordionPane ID="AccordionPane3" runat="server">
        <Header >Cas Sheet Report</Header>
        <Content>
        
        </Content>
        </asp:AccordionPane>
        <asp:AccordionPane ID="AccordionPane1" runat="server">
        <Header >Cas Sheet Project Summary</Header>
        <Content>
        </Content>
        </asp:AccordionPane>
        <asp:AccordionPane ID="AccordionPane2" runat="server">
        <Header>Cas Sheet Project Summary</Header>
        <Content>testing panel 1</Content>
        </asp:AccordionPane>
        </Panes>
        </asp:Accordion>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Commissioning Plans" ID="TabPanel2">
                <ContentTemplate>
               <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                    <div style="padding:20px">
                <table>
                <tr>
                <td >
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                     <asp:Button ID="btncp" runat="server" Text="Commissioning Plans Report" 
                        Width="400px" 
                         />
                    </ContentTemplate>
                    </asp:UpdatePanel>
               
                    </td>
                <td>
                    </td>
                </tr>
                    <tr>
                        <td align="center" >
                       
                          
                          </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Document Review" ID="TabPanel3">
                    <HeaderTemplate>
                        Document Review
                    </HeaderTemplate>
                <ContentTemplate>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                    <div style="padding:20px">
                <table>
                <tr>
                <td >
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                     <asp:Button ID="btndrl" runat="server" Text="Document Review Log Report" 
                        Width="400px" 
                         />
                    </ContentTemplate>
                    </asp:UpdatePanel>
               
                    </td>
                <td>
                    </td>
                </tr>
                <tr>
                <td ><asp:Button ID="btndrd" runat="server" Text="Document Review Details Report" 
                        Width="400px" />
                    </td>
                <td></td>
                </tr>
                    <tr>
                        <td align="center" >
                          <table id="dr" runat="server" >
                          <tr id="Tr1" runat="server">
                          <td id="Td1" runat="server">Select DR No.</td>
                          <td id="Td2" runat="server">
                              <asp:DropDownList ID="drdrno" runat="server" Width="150px">
                              </asp:DropDownList>
                              </td>
                          </tr>
                          <tr id="Tr2" runat="server">
                          <td id="Td3" runat="server"></td>
                          <td id="Td4" align="left" runat="server">
                              <asp:Button ID="btndrview" runat="server" Text="View" 
                               /></td>
                          </tr>
                          </table>
                          
                          
                          </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                
                 
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Method Statements" ID="TabPanel4">
                <ContentTemplate>
                <div style="padding:20px">
                <table>
                <tr>
                <td ><asp:Button ID="btnmss" runat="server" Text="Method Statement Schedule Report" 
                        Width="400px" 
                         />
                    </td>
                <td></td>
                </tr>
                    <tr>
                        <td>
                           <asp:Button ID="btnms" runat="server" Text="Method Statement Comments Report" 
                        Width="400px" 
                         /></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Site Observation" ID="TabPanel5">
                <ContentTemplate>
                <div style="padding:20px">
                <table>
                <tr>
                <td ><asp:Button ID="btnsol" runat="server" Text="Site Observation Log Report" 
                        Width="400px" 
                         />
                   </td>
                <td></td>
                </tr>
                <tr>
                <td >
                 <asp:Button ID="btnsod" runat="server" Text="Site Observation Details Report" 
                        Width="400px" 
                         />
                </td>
                <td></td>
                </tr>
                    <tr>
                        <td align="center">
                            <table ID="so" runat="server">
                                <tr id="Tr3" runat="server">
                                    <td id="Td5" runat="server">
                                        Select SO No.</td>
                                    <td id="Td6" runat="server">
                                        <asp:DropDownList ID="drsono" runat="server" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="Tr4" runat="server">
                                    <td id="Td7" runat="server">
                                    </td>
                                    <td id="Td8" runat="server" align="left">
                                        <asp:Button ID="btnsoview" runat="server" 
                                            Text="View"  />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="Programmes" ID="TabPanel6">
                <ContentTemplate>
                <div style="padding:20px">
                <table>
                <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                     <asp:Button ID="btnpr" runat="server" Text="Programmes Report" Width="400px" 
                         />
                         
                    </ContentTemplate>
                  
                    </asp:UpdatePanel>
                   </td>
                <td></td>
                </tr>
                </table>
                </div>
                </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer> 
        
    </div>
    </form>
</body>
</html>
