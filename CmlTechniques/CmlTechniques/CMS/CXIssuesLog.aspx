<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CXIssuesLog.aspx.cs" Inherits="CmlTechniques.CMS.CXIssuesLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="../page.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .gvHeaderRow
    {
        /*background-image:url('../images/head_bg.png');*/
        background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
        /*height:40px;*/
    }
    .gvCell
    {
        padding-left:5px;
    }
    .HeaderFreez 
    {
    	position:relative;
    	top:expression(this.offsetParent.scrollTop); 
    	z-index:10;
    	font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="background-color:#000033;width:100%;position:fixed;height:32px;top:0">
        <div style="float:left;padding:5px">
            <asp:Label ID="Label1" runat="server" Text="CX Issues Log" Font-Bold="true" ForeColor="#FFFFFF" Font-Size="Large"></asp:Label>
        </div>
        <table style="float:right">
        <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:Button ID="btn_add" runat="server" Text="Add New" onclick="btn_add_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            <asp:Button ID="btnprint" runat="server" Text="Print" onclick="btnprint_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td ></td>
        </tr>
        </table>
        </div>
        <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden"></asp:Label>
        <div style="margin-top:32px" >
        <%--<div style="position:relative;top:0;width:3000px">
        <table style="font-family: Verdana;font-size:x-small;background-color:#9EB6CE;" cellspacing="1" border="0">
        <tr style="background-image: url('../images/head_bg.png'); background-repeat: repeat-x;">
        <td style="width:100px" align="center">Risk Number</td>
        <td style="width:100px" align="center">Source Document</td>
        <td style="width:150px" align="center">Source Document Ref.</td>
        <td style="width:150px" align="center">Zutec CX Issue</td>
        <td style="width:100px" align="center">Base Discipline</td>
        <td style="width:150px" align="center">System</td>
        <td style="width:200px" align="center">Issue Type</td>
        <td style="width:150px" align="center">Location</td>
        <td style="width:300px" align="center">Risk Description/ Risk Event Statement</td>
        <td style="width:100px" align="center">Responsible</td>
        <td style="width:100px" align="center">Date Reported</td>
        <td style="width:100px" align="center">Target Closure Date</td>
        <td style="width:100px" align="center">Last Update</td>
        <td style="width:100px" align="center">Date Closed</td>
        <td style="width:100px" align="center">Impact</td>
        <td style="width:100px" align="center">Impact Description</td>
        <td style="width:100px" align="center">Probability</td>
        <td style="width:100px" align="center">Timeline</td>
        <td style="width:100px" align="center">Status of Response</td>
        <td style="width:100px" align="center">Current Actions</td>
        <td style="width:100px" align="center">Planned Future Actions</td>
        <td style="width:100px" align="center">Risk Status</td>
        <td style="width:150px" align="center">Closure Date</td>
        <td style="width:100px" align="center">Resolution Status</td>
        </tr>
        </table>
        </div>--%>
        <asp:GridView ID="mygrid" runat="server" AutoGenerateColumns="False" 
                Width="2200px"  Font-Names="Verdana" 
                Font-Size="X-Small" 
                DataSourceID="ObjectDataSource1" onrowdatabound="mygrid_RowDataBound" 
                DataKeyNames="cx_log_id" onrowcreated="mygrid_RowCreated" >
                <Columns>
                <asp:BoundField HeaderText="Risk Number" >
                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Source Document" DataField="source_doc" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Source Document Ref #" DataField="source_doc_ref" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Zutec CX Issue #" DataField="zutec_cx_issue" >
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Base Discipline" DataField="Discipline" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="System" DataField="system" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Issue Type" DataField="issue_type" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Location" DataField="location" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Risk  Description / Risk Event Statement" 
                        DataField="description" >
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Responsible" DataField="responsible" >
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Date Reported (DR) dd/mm/yy" DataField="date_rep" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Target closure date (DR + 30d)" DataField="date_tc" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Last Update dd/mm/yy" DataField="last_update" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Date Closed dd/mm/yy" DataField="date_clsd" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#ff0000" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Impact H/M/L" DataField="impact" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#e46d0a" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Impact Description" DataField="description" >
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                    <HeaderStyle BackColor="#e46d0a" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Probability H/M/L" DataField="probability" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#e46d0a" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Timeline N/M/F" DataField="timeline" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#e46d0a" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Status of Response N/P/PE/EE" DataField="resp_status" >
                    <ItemStyle HorizontalAlign="Center" Width="75px" />
                    <HeaderStyle BackColor="#e46d0a" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Current Actions" DataField="c_action" >
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                    <HeaderStyle BackColor="#00b050" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Planned Future Actions" DataField="f_action" >
                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                    <HeaderStyle BackColor="#00b050" />
                    </asp:BoundField>
                <asp:BoundField HeaderText="Risk Status open/ closed/ pending/ moved to issue" DataField="r_status" >
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <HeaderStyle BackColor="#00b050" />
                    </asp:BoundField>
                </Columns>
                <HeaderStyle CssClass="HeaderFreez" />
                <RowStyle Height="25px"  />
                
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                
                TypeName="CmlTechniques.CMS.DataSet2TableAdapters.Load_Cx_Issues_LogTableAdapter" ></asp:ObjectDataSource>
        </div>
    </div>
    </form>
</body>
</html>
