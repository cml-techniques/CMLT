
 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tcuploadmulti.aspx.cs" Inherits="CmlTechniques.tcuploadmulti" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Multi Upload</title>
        <link href="page.css" rel="stylesheet" type="text/css" />
    <link href="Stylesheet1.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="Scripts/jquery.MultiFile.js" type="text/javascript"></script>
    <style type="text/css">
    .leftpadd
    {
    	padding-left:10px;
    }
    </style>
    
    <script type="text/javascript">
    
    
    function clears(obj)
    {
    
    
    
    var row = obj.parentNode.parentNode; 
var index = row.rowIndex;

var grid = document.getElementById('<%=gvupload.ClientID %>');

if (grid.rows[index].cells[1].childNodes[1].type=="file")
{
grid.rows[index].cells[1].childNodes[1].value="";
grid.rows[index].cells[2].children[0].innerHTML="";

}
    
  }

function Fileselect(obj)
{


var row = obj.parentNode.parentNode; 
var index = row.rowIndex;

var grid = document.getElementById('<%=gvupload.ClientID %>');

if (grid.rows[index].cells[1].childNodes[1].type=="file")
{
document.getElementById(grid.rows[index].cells[1].childNodes[1].id).click();
}

}

function Getfilename(obj)
{

var row = obj.parentNode.parentNode; 
var rowIndex = row.rowIndex; 


var grid = document.getElementById('<%=gvupload.ClientID %>');


if (grid.rows[rowIndex].cells[1].childNodes[1].type=="file")
{
var value=document.getElementById(grid.rows[rowIndex].cells[1].childNodes[1].id).value;

            var i = value.lastIndexOf("\\");
            var _filename = value.substring(i+1);



grid.rows[rowIndex].cells[2].children[0].innerHTML=_filename;
}


}
    </script>
</head>
<body style="background-color:#d1def1">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="position:absolute;left:15%;top:20%;width:750px">
    
                <table style="width:100%" border="0">
            <tr>
            <td   valign="middle" align="left"  style="font-family: Verdana; font-size: 14px;font-weight:600; color: #FFFFFF;padding-left:10px;background-color:#999999" 
                                    height="30px"> Multi Document Uploader</td>
            </tr>
            </table>

 <asp:GridView ID="gvupload" runat="server" AutoGenerateColumns="False" GridLines="None" 
                        Width="100%" onrowdatabound="gvupload_RowDataBound" ShowHeader="False" 
                        UseAccessibleHeader="False">
 <RowStyle BackColor="White" Height="30px" />
 <AlternatingRowStyle BackColor="#cccccc" ForeColor="White"  Height="30px"  />
                            <Columns> 
                                    <asp:TemplateField ItemStyle-CssClass="leftpadd" > 
                                        <ItemTemplate   >
                                        <asp:Label ID="lblid"  runat="server" style="font-size:13px" Text='<%# DataBinder.Eval(Container.DataItem,"E_b_ref") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>                                                
                                        <asp:TemplateField>
                                        <ItemTemplate  >
                                            <asp:FileUpload  id="fupload" style="display:none"  runat="server"  maxlength="1" accept="application/pdf"  onchange="Getfilename(this);" />
                                      <%--      <input type="file" id="fupload" style="display:none" runat="server" onchange="Getfilename(this)" accept="application/pdf" />--%>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate> 
                                            <asp:Label ID="lblfname" ForeColor="#073763"  Text="" runat="server" Width="400px"  style="text-align:right;font-size:13px"  />
                                        </ItemTemplate>

                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>

                                       <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate > 
                                       <input type="button" id="btnselect"    runat="server" value="Select File" onclick="Fileselect(this);" />
                                      </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                        <ItemTemplate >
                                       <img alt="" src="images/delete_.png" runat="server" id="imgdelete" onclick="clears(this);" />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="C_Id" />
                                                                                                 
                            </Columns> 
                        </asp:GridView>


             <table border="0" style="width:100%;font-family: Verdana; font-size: small;  color: #FFFFFF; background-color:#999999" >
            <tr>
            <td   valign="middle" align="left"  width ="90%" height="30px"  > &nbsp;</td>
                                    <td align="right">
                                    <table>
                                    <tr>
               <td><asp:Button ID="btnsave" runat="server" Text="Upload" onclick="btnsave_Click"  /></td>
              <td><asp:Button ID="brncancel" runat="server" Text="Cancel" onclick="brncancel_Click" /></td>
                                    </tr>
                                    </table>
                                    </td>

            </tr>
            </table>
            
            
        
    
    </div>
                      
    </form>
  
</body>
</html>
