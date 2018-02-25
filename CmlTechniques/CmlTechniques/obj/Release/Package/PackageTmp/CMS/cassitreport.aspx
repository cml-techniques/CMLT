<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cassitreport.aspx.cs" Inherits="CmlTechniques.CMS.cassitreport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('../images/head_bg.png');
        background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
    }
    .gvFooetRow
    {
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
        height:30px;
        background-color:#C8ECFB;
    }
    </style>
        <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: verdana; font-size: x-small;height:100%;position:fixed;width:100%">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table style="width:100%;color:White" bgcolor="#092443">
        <tr>
        <td style="background-color: #D2F1FC" >
            <asp:Label ID="lblhead" runat="server" Font-Bold="True" Font-Size="Small" 
                ForeColor="Black" Text=""></asp:Label>
            </td>
        </tr>
        </table>
        <div style="width:1031px;float:left;position:relative;">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;" cellspacing="1" border="0"  id="tbl" runat="server" >
                        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;height:30px" >
       
                            <td align="center" valign="middle"   width="100px">
                                ITEM NO</td>
       
                            <td align="center" valign="middle"   width="100px">
                                <asp:Label ID="lbl1" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center" valign="middle" width="100px" id="op1" runat="server"  >
                                <asp:Label ID="lbl2" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center" valign="middle" width="100px" id="op2" runat="server"  >
                                <asp:Label ID="lbl3" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center" valign="middle" width="100px"  >
                                <asp:Label ID="lbl4" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="center" valign="middle" width="100px" id="op3" runat="server" >
                                NO. OF INTERFACES COMPLETED</td>
                            <td align="center" valign="middle" width="100px"  >
                                COMPLETE DATE</td>
                            <td align="center" valign="middle" width="100px" id="op4" runat="server" >
                                INTERFACES/ TESTS SIGNED OFF</td>
                            <td align="center" valign="middle" width="100px"  >
                                SIGNED OFF</td>
                            <td align="center" valign="middle" width="100px"  >
                                OVERALL %</td>
                        </tr>
        <tr bgcolor="#092443" >
            <td>
                <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden" ></asp:Label>
                <asp:Label ID="lblsch" runat="server" Text="" CssClass="hidden" ></asp:Label>
             </td>
            <td>
                &nbsp;</td>
            <td id="op1_3" runat="server">
                &nbsp;</td>
            <td id="op2_3" runat="server">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td id="op3_3" runat="server">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td id="op4_3" runat="server">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
                        </table>
        </div>
        <%--<div style="position:relative; height:67%;width:1000px;overflow-y:scroll;float:left" id="_div" runat="server">--%>
        <div style="position:relative; height:100%;float:left" id="_div" runat="server">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
            
                <asp:GridView ID="mydetails" runat="server" ShowHeader="false" 
                    AutoGenerateColumns="false" OnRowDataBound="mydetails_RowDataBound" Font-Names="Verdana" 
                    Font-Size="X-Small" Width="1031px" ShowFooter="True" >
                <Columns>
                
                <%--<asp:ButtonField ButtonType="Button" Text="Update" CommandName="Get"
                        ItemStyle-Width="100px" >
                    <ItemStyle Width="100px"  />
                    </asp:ButtonField>--%>
                <%--<asp:TemplateField >
                <ItemTemplate>
                    <asp:CheckBox ID="chkrow" runat="server" OnCheckedChanged="chkrow_CheckedChanged" AutoPostBack="true" />
                </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center"  />
                </asp:TemplateField>--%>    
                
                <asp:BoundField HeaderText="Itm.No" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField ="E_b_ref" HeaderText="Engg.Reff" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="B_Z" HeaderText="Building/Zone" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>  
                <asp:BoundField DataField="cat" HeaderText="Category" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField DataField="devices1" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test3" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test1" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test4" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="test2" ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                <asp:BoundField ItemStyle-Width="100px" FooterStyle-HorizontalAlign="Center" >
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <FooterStyle CssClass="gvFooetRow" />
                </asp:GridView>
           
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
      
           
    </div>
    </form>
    <p>
        ......</p>
</body>
</html>
