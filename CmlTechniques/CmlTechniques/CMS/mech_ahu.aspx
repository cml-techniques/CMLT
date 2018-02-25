<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mech_ahu.aspx.cs" Inherits="CmlTechniques.CMS.mech_ahu" %>

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
        <h3 style="margin:0">Commissioning Record Sheet - AHU</h3>
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
                Width="1050px">
                <asp:TabPanel runat="server" HeaderText="FAN SET DATA" ID="TabPanel1">
                    <HeaderTemplate>
                        FAN SET DATA
                    </HeaderTemplate>
                <ContentTemplate>
                <div>
        
        <h4 style="margin:0">FAN SET DATA</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="lblprj" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="lblsys" runat="server"></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td>
            <asp:Label ID="lblreff" runat="server"></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td>
            <asp:Label ID="lblcode" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        <hr />
        <table style="border: 1px solid #C0C0C0; width:100%" cellpadding="1" cellspacing="1" 
                        frame="border">
        <tr>
        <td style="width:23%; color: #FFFFFF;" align="center" bgcolor="#5D7B9D" >SYSTEM DATA</td>
        <td style="width:23%" align="center">DESIGN</td>
        <td style="width:4%"></td>
        <td colspan="3" align="center">OBTAINED</td>
        <td style="width:4%"></td>
        </tr>
        <tr>
        <td style="width:23%" >System Volume</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox67" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">m³/s</td>
        <td style="width:20%">
            <asp:TextBox ID="TextBox80" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td style="width:3%">
                m³/s</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox81" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">%</td>
        </tr>
        <tr>
        <td style="width:23%" >Fan Static Pressure*</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox68" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">Pa</td>
        <td style="width:23%" colspan="2">Suction*</td>
        <td style="width:23%">Discharge*</td>
        <td style="width:4%">Pa&nbsp;</td>
        </tr>
        <tr>
        <td style="width:23%" >Fan Speed</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox69" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">rev/m</td>
        <td colspan="3">
            <asp:TextBox ID="TextBox82" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">rev/m</td>
        </tr>
        <tr>
        <td style="width:23%" >Motor Speed</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox70" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">rev/m</td>
        <td colspan="3">
            <asp:TextBox ID="TextBox83" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">rev/m</td>
        </tr>
        <tr>
        <td style="width:23%" >Filter P.d(max)</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox71" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">Pa</td>
        <td style="width:23%" colspan="2">
            <asp:TextBox ID="TextBox84" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td align="right" colspan="2">Pa @time of test</td>
        </tr>
        <tr>
        <td style="width:23%" >Setting of mixing damper</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox72" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%"></td>
        <td style="width:23%" colspan="2">Setting of main damper</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox85" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%"></td>
        </tr>
        <tr>
        <td style="width:23%" >Method used to obtain volume</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox73" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%"></td>
        <td style="width:23%" colspan="2"></td>
        <td style="width:23%"></td>
        <td style="width:4%"></td>
        </tr>
        <tr>
        <td style="width:23%; color: #FFFFFF;" align="center" bgcolor="#5D7B9D" >FAN DATA</td>
        <td style="width:23%">Type</td>
        <td style="width:4%">&nbsp;</td>
        <td style="width:20%" >Ordered duty</td>
        <td style="width:3%">m³/s</td>
        <td style="width:23%">&nbsp;</td>
            <td style="width:4%">
                Pa</td>
        </tr>
            <tr>
                <td style="width:23%">
                    Manufacturer</td>
                <td style="width:23%">
                    <asp:TextBox ID="TextBox74" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width:4%">
                    &nbsp;</td>
                <td style="width:20%">
                    Modal<asp:TextBox ID="TextBox86" runat="server" Width="100%"></asp:TextBox></td>
                <td style="width:3%">
                    m³/s</td>
                <td style="width:23%">
                    <asp:TextBox ID="TextBox87" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width:4%">
                    %</td>
            </tr>
        <tr>
        <td style="width:23%" >Serial No.</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox75" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">&nbsp;</td>
        <td style="width:23%" colspan="2">Pitch angle(s)</td>
            <td style="width:23%">
                <asp:TextBox ID="TextBox88" runat="server" Width="100%"></asp:TextBox>
                </td>
        <td style="width:4%"></td>
        </tr>
        <tr>
        <td style="width:23%; color: #FFFFFF;" align="center" bgcolor="#5D7B9D" >MOTOR DATA</td>
        <td style="width:23%"></td>
        <td style="width:4%">&nbsp;</td>
        <td style="width:20%">Frame</td>
        <td style="width:3%">&nbsp;</td>
        <td style="width:23%">Type&nbsp;</td>
        <td style="width:4%">&nbsp;</td>
        </tr>
            <tr>
                <td style="width:23%; ">
                    Manufacturer</td>
                <td style="width:23%">
                    <asp:TextBox ID="TextBox76" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width:4%">
                    &nbsp;</td>
                <td style="width:20%">
                    Serial No.</td>
                <td style="width:3%">
                    &nbsp;</td>
                <td style="width:23%">
                </td>
                <td style="width:4%">
                    &nbsp;</td>
            </tr>
        <tr>
        <td >Rated power</td>
        <td >
            <asp:TextBox ID="TextBox77" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td >kW</td>
        <td colspan="2" >Electrical Supply</td>
            <td >
                <asp:TextBox ID="TextBox89" runat="server" Width="100%"></asp:TextBox>
                </td>
        <td >v/ph/hz</td>
        </tr>
        <tr>
        <td style="width:23%" >FLC</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox78" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">amps</td>
        <td style="width:23%" colspan="2">Running current</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox90" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">amps</td>
        </tr>
        <tr>
        <td style="width:23%" >Overload range</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox79" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">amps</td>
        <td style="width:23%" colspan="2">Settings</td>
        <td style="width:23%">
            <asp:TextBox ID="TextBox91" runat="server" Width="100%"></asp:TextBox>
            </td>
        <td style="width:4%">amps</td>
        </tr>
        <tr>
        <td style="width:23%; color: #FFFFFF;" align="center" bgcolor="#5D7B9D" >DRIVE DATA</td>
        <td style="width:23%"></td>
        <td style="width:4%">&nbsp;</td>
        <td style="width:20%">Belt size</td>
        <td style="width:3%">&nbsp;</td>
        <td style="width:23%">No.of Belts<asp:TextBox ID="TextBox92" runat="server" 
                Width="100%"></asp:TextBox></td>
        <td style="width:4%">&nbsp;</td>
        </tr>
            <tr>
                <td style="width:23%; ">
                    Motor pulley</td>
                <td style="width:23%">
                    <asp:TextBox ID="TextBox93" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td style="width:4%">
                    mm</td>
                <td style="width:20%">
                </td>
                <td style="width:3%">
                    &nbsp;</td>
                <td style="width:23%">
                </td>
                <td style="width:4%">
                    mm</td>
            </tr>
        <tr>
        <td style="color: #FFFFFF;" align="center" bgcolor="#5D7B9D" >COMMENTS</td>
        <td align="left" colspan="6">*Pressures taken externally to packaged air handling 
            units</td>
        </tr>
        <tr>
        <td colspan="7" >
            <asp:TextBox ID="TextBox94" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
            <asp:TabPanel runat="server" HeaderText="DUCT TRAVERSE" ID="TabPanel2">
                
                <ContentTemplate>
                <div>
        <h4 style="margin:0">DUCT TRAVERSE</h4>
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
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" Width="75px" 
                            ></asp:TextBox>
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
                        <asp:Button ID="Button1" runat="server"  Text="Button" />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="CIRCULAR DUCT TRAVERSE" ID="TabPanel3">
                <ContentTemplate>
                <div>
        <h4 style="margin:0">CIRCULAR DUCT TRAVERSE</h4>
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
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox17" runat="server" Width="75px" 
                            ></asp:TextBox>
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
                        <asp:Button ID="Button2" runat="server"  Text="Button" />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="AIR HANDLING SYSTEM-A5" ID="TabPanel4">
                <ContentTemplate>
                <div>
        <h4 style="margin:0">AIR HANDLING SYSTEM-A5</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="Label9" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="Label10" runat="server"></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td >
            <asp:Label ID="Label11" runat="server"></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td >
            <asp:Label ID="Label12" runat="server"></asp:Label>
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
                        <asp:TextBox ID="TextBox13" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox23" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox24" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox25" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox26" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox27" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox28" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox29" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox30" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server"  Text="Button" />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="AIR HANDLING SYSTEM-A5a" ID="TabPanel5">
                <ContentTemplate>
                <div>
        <h4 style="margin:0">AIR HANDLING SYSTEM-A5a</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="Label13" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="Label14" runat="server"></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td >
            <asp:Label ID="Label15" runat="server"></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td >
            <asp:Label ID="Label16" runat="server"></asp:Label>
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
                        <asp:TextBox ID="TextBox31" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox32" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox33" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox34" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox35" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox36" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox37" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox38" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox39" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button4" runat="server"  Text="Button" />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="AIR HANDLING SYSTEM-A5b" ID="TabPanel6">
                <ContentTemplate>
                <div>
        <h4 style="margin:0">AIR HANDLING SYSTEM-A5b</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="Label17" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="Label18" runat="server"></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td >
            <asp:Label ID="Label19" runat="server"></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td >
            <asp:Label ID="Label20" runat="server"></asp:Label>
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
                        <asp:TextBox ID="TextBox40" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox41" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox42" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox43" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox44" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox45" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox46" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox47" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox48" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button5" runat="server"  Text="Button" />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="PROPORTIONAL AIR BALANCE" ID="TabPanel7">
                <ContentTemplate>
                <div>
        <h4 style="margin:0">PROPORTIONAL AIR BALANCE</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="Label21" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="Label22" runat="server"></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td >
            <asp:Label ID="Label23" runat="server"></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td >
            <asp:Label ID="Label24" runat="server"></asp:Label>
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
                        <asp:TextBox ID="TextBox49" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox50" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox51" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox52" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox53" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox54" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox55" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox56" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox57" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button6" runat="server"  Text="Button" />
                    </td>
                </tr>
            </table>
        
        </div>
                </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel runat="server" HeaderText="DEFINITIVE AIR BALANCE" ID="TabPanel8">
                <ContentTemplate>
                <div>
        <h4 style="margin:0">DEFINITIVE AIR BALANCE</h4>
        <hr />
        <table style="width:100%">
        <tr>
        <td width="100px" >Project:</td><td colspan="5" >
            <asp:Label ID="Label25" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td width="100px" >System:</td><td >
            <asp:Label ID="Label26" runat="server"></asp:Label>
            </td>
            <td width="100px" >Refference:</td>
            <td >
            <asp:Label ID="Label27" runat="server"></asp:Label>
            </td>
            <td width="100px" >Asset Code:</td>
            <td >
            <asp:Label ID="Label28" runat="server"></asp:Label>
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
                        <asp:TextBox ID="TextBox58" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox59" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox60" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox61" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox62" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox63" runat="server" Width="75px" 
                            ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox64" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox65" runat="server" Width="75px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox66" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button7" runat="server"  Text="Button" />
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
