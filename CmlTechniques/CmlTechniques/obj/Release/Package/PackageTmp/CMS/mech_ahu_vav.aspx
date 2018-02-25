<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mech_ahu_vav.aspx.cs" Inherits="CmlTechniques.CMS.mech_ahu_vav" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div style="width:100%">
        <h3 style="margin:0">Commissioning Record Sheet - AHU-VAV</h3>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                Width="1050px">
                <asp:TabPanel runat="server" HeaderText="V.A.V. UNIT TEST / CALIBRATION" ID="TabPanel1">
                <ContentTemplate>
                <div>
        
        <h4 style="margin:0">V.A.V. UNIT TEST / CALIBRATION</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="lblprj" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="lblsys" runat="server" Text=""></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td >
            <asp:Label ID="lblreff" runat="server" Text=""></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td >
            <asp:Label ID="lblcode" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        </table>
        <hr />
        
            <table border="1" cellpadding="0" cellspacing="0" >
                <tr>
                    <td rowspan="3" width="75px" align="center">
                        Terminal Reff</td>
                    <td colspan="2" width="150px" align="center">
                        Design</td>
                    <td colspan="6" width="450px" align="center">
                        Test Readings</td>
                    <td rowspan="3" width="200px" align="center">
                        Comments</td>
                    <td rowspan="3"  align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td rowspan="2" width="75px" align="center">
                        Vol m&sup3;/s</td>
                    <td rowspan="2" width="75px" align="center">
                        Signal Pa</td>
                    <td colspan="2" width="150px" align="center">
                        Initial</td>
                    <td colspan="2" width="150px" align="center">
                        Final</td>
                    <td colspan="2" width="150px" align="center">
                        Check</td>
                </tr>
                <tr>
                    <td width="75px" align="center">
                        Pa</td>
                    <td width="75px" align="center">
                        % Vol</td>
                    <td width="75px" align="center">
                        Pa</td>
                    <td width="75px" align="center">
                        % Vol</td>
                    <td width="75px" align="center">
                        Pa</td>
                    <td width="75px" align="center">
                        % Vol</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txttreff" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdes1" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdes2" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtini1" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtini2" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfin1" runat="server" Width="75px" 
                            ontextchanged="TextBox6_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtfin2" runat="server" Width="75px" 
                            ontextchanged="TextBox7_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtchk1" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtchk2" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcommt" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="cmdadd" runat="server" Text="Button" onclick="cmdadd_Click"  />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="PROPORTIONAL AIR BALANCE" ID="TabPanel2">
                <HeaderTemplate>
                    PROPORTIONAL AIR BALANCE
                </HeaderTemplate>
                <ContentTemplate>
                <div>
        <h4 style="margin:0">PROPORTIONAL AIR BALANCE</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td >
            <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td >
            <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        <hr />
        
            <table border="1" cellpadding="0" cellspacing="0" >
                <tr>
                    <td width="75px" align="center" rowspan="2">
                        Terminal Reff</td>
                    <td rowspan="2" width="75px" align="center">
                        Factor c.s.a (m²)</td>
                    <td align="center" colspan="2" width="150px">
                        Design</td>
                    <td width="150px" align="center" colspan="2" >
                        Initial</td>
                    <td align="center" colspan="2"  width="150px">
                        Final</td>
                    <td align="center" colspan="2" width="150px">
                        Check</td>
                    <td rowspan="2"  align="center" width="75px">
                        Hood</td>
                    <td align="center" rowspan="2" width="150px">
                        Comments</td>
                    <td align="center" rowspan="2">
                        Design&nbsp;</td>
                </tr>
                <tr>
                    <td width="75px" align="center">
                        Volume (m&sup3;/s)</td>
                    <td width="75px" align="center">
                        Velocity (m/s)</td>
                    <td width="75px" align="center" >
                        Velocity (m/s)</td>
                    <td width="75px" align="center" >
                        % Design</td>
                    <td width="75px" align="center" >
                        Velocity (m/s)</td>
                    <td align="center"  width="75px">
                        % Design</td>
                    <td align="center"  width="75px">
                        Velocity (m/s)</td>
                    <td align="center" width="75px">
                        % Design</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox21" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" Width="75px" 
                            ontextchanged="TextBox6_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" Width="75px" 
                            OnTextChanged="TextBox7_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox22" runat="server" Width="50px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server" Width="100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="cmdadd_Click" Text="Button" />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="DEFINITIVE AIR BALANCE" ID="TabPanel3">
                <ContentTemplate>
                <div>
        <h4 style="margin:0">DEFINITIVE AIR BALANCE</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td >
            <asp:Label ID="Label7" runat="server"></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td >
            <asp:Label ID="Label8" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        <hr />
        
            <table border="1" cellpadding="0" cellspacing="0" >
                <tr>
                    <td rowspan="3" width="75px" align="center">
                        Terminal Reff</td>
                    <td width="75px" align="center">
                        Design</td>
                    <td colspan="6" width="450px" align="center">
                        Test Readings</td>
                    <td rowspan="3" width="200px" align="center">
                        Comments</td>
                    <td rowspan="3"  align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td rowspan="2" width="75px" align="center">
                        Vol m&sup3;/s</td>
                    <td width="150px" align="center" colspan="2">
                        Initial</td>
                    <td colspan="2" width="150px" align="center">
                        Final</td>
                    <td colspan="2" width="150px" align="center">
                        Check</td>
                </tr>
                <tr>
                    <td width="75px" align="center">
                        Volume (m&sup3;/s)</td>
                    <td width="75px" align="center">
                        % Design</td>
                    <td width="75px" align="center">
                        Volume (m&sup3;/s)</td>
                    <td width="75px" align="center">
                        % Design</td>
                    <td width="75px" align="center">
                        Volume (m&sup3;/s)</td>
                    <td width="75px" align="center">
                        % Design</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox11" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox12" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox14" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox15" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox16" runat="server" Width="75px" 
                            OnTextChanged="TextBox6_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox17" runat="server" Width="75px" 
                            ontextchanged="TextBox7_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox18" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox19" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox20" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" OnClick="cmdadd_Click" Text="Button" />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </div>
        
    </div>
    </form>
</body>
</html>
