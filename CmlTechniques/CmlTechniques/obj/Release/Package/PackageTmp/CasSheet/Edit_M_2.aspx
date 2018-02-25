<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit_M_2.aspx.cs" Inherits="CmlTechniques.CasSheet.Edit_M_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="../page.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div id="container">
        <div class="box">
        <table style="width:100%;background-color:#e4e4e4;">
        <tr>
        <td style="background-color: #26405E;color:#fff;padding:5px;font-size:14px;font-weight:bold;">CAS E1 Electrical Services. HV-MV Switchgear & RMU Commissioning Activity Schedule </td>
        </tr>
        </table>
        </div>
        <div class="box">
           <div style="width:380px;padding:10px;float:left">
           <table style="width:380px">
           <tr>
           <td style="width:150px">Building Zone</td>
           <td>
               <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                 </td>
           </tr>
           <tr>
           <td style="width:150px">Floor Level</td>
           <td>
               <asp:DropDownList ID="DropDownList1" runat="server">
               </asp:DropDownList>
                                 </td>
           </tr>
           <tr>
           <td style="width:150px">Location</td>
           <td>
               <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                 </td>
           </tr>
           <tr>
           <td style="width:150px">Fed From</td>
           <td>
               <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                 </td>
           </tr>
           <tr>
           <td style="width:150px">Provides Power To</td>
           <td>
               <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                 </td>
           </tr>
           <tr>
           <td style="width:150px">Substation</td>
           <td>
               <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                 </td>
           </tr>
           <tr>
           <td style="width:150px">&nbsp;</td>
           <td>&nbsp;</td>
           </tr>
           <tr>
           <td colspan="2">
           <table>
           <tr>
           <td>
               <asp:Button ID="btnupdate" runat="server" Text="Update" Width="75px" 
                   onclick="btnupdate_Click" /></td>
           <td><asp:Button ID="btnback" runat="server" Text="Back" Width="75px" /></td>
           </tr>
           </table>
           </td>
           </tr>
           </table>
           </div>
        <div style="float:left">
            <asp:GridView ID="GridView1" runat="server" Width="100%">
            </asp:GridView>
        </div>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
