<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="load.aspx.cs" Inherits="CmlTechniques.load" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
   <link href="page.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <style type="text/css">
    .gvHeaderRow
    {
        background-image:url('images/head_bg.png');
         background-repeat: repeat;
        font-family:Verdana;
        font-size:x-small;
        font-weight:normal;
        height:25px;
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
    
</head>
<body>
    <form id="form1" runat="server">
    
    <div >
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        
        <table style="width: 100%; height: 100%;" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td  style="width: 100%; height: 100%" valign="top">
                    <asp:Label ID="lblprj" runat="server" Text="" CssClass="hidden" ></asp:Label>
                <%--<div style="width: 100%; height: 100%">  --%>  
                 <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red" 
                        Font-Names="Verdana"></asp:Label>
                 <iframe id="myframe" runat="server" frameborder="0" width="100%" name="myframe" height="100%" ></iframe> 
                 <div id="mydiv" runat="server" name="mydiv" style="vertical-align:top;"  >   
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: medium; " 
                            width="100%" border="0" cellpadding="0" cellspacing="0" >
                            <tr>
                            <td>
                            <table style="width:100%;background-color:#9EB6CE;" cellspacing="1" border="0"">
                            <tr>
                            <td style="background-color: #D2F1FC">Total No.Documents Scheduled for Upload</td>
                            <td bgcolor="White" align="center">
                                <asp:Label ID="lbl_schedule" runat="server" Text="" Width="50px"></asp:Label>
                                                </td>
                            <td style="background-color: #D2F1FC">Total No.Documents Currently Uploaded</td>
                            <td bgcolor="White" align="center">
                                <asp:Label ID="lbl_upload" runat="server" Width="50px" ForeColor="Black"></asp:Label>
                                                </td>
                            <td style="background-color: #D2F1FC">Total Percentage of Document Uploaded</td>
                            <td bgcolor="White" align="center">
                                <asp:Label ID="lbl_percentage" runat="server" Text="" Width="50px"></asp:Label>
                                                </td>
                            </tr>
                            </table>
                            </td>
                            </tr>
                            <tr>
                            <td align="center" style="background-color: #092443; color: #ffffff;height:25px">Uploaded Documents</td>
                            </tr>
                            <tr>
                                <td  valign="top" align="left" >
                                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>--%>
                    <asp:GridView ID="mydocgrid" runat="server" 
                                        AutoGenerateColumns="False" 
                                        Font-Names="Verdana" Font-Size="X-Small" 
                                        Width="100%" onrowcommand="mydocgrid_RowCommand" 
                                        onrowdatabound="mydocgrid_RowDataBound" 
                                        onrowcreated="mydocgrid_RowCreated" >
                                        <HeaderStyle CssClass="gvHeaderRow" />
                <Columns>
                <asp:BoundField DataField="doc_name" />
                                        <asp:BoundField DataField="doc_title" > 
                                         <HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
                                        </asp:BoundField>
                                        
                                        <%--<asp:hyperlinkfield datanavigateurlfields="doc_name" datanavigateurlformatstring="viewdocument.aspx?{0}" datatextfield="doc_name" navigateurl="~/viewdocument.aspx"    headertext="document name" headerstyle-horizontalalign="left" ItemStyle-Width="0px" Visible="true" Target="myframe" ><headerstyle horizontalalign="left"></headerstyle>
                                        </asp:hyperlinkfield>--%> 
                                            <asp:TemplateField>
                                            <ItemTemplate >
                                                <asp:Image ID="Image1" runat="server"  />
                                            </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="5px" />
                                            </asp:TemplateField>
                                            
                                        <asp:ButtonField DataTextField="doc_name"  HeaderText="FILE NAME"   > 
                                            <HeaderStyle HorizontalAlign="Center" />
                                            </asp:ButtonField>
                                        <%--<asp:HyperLinkField DataNavigateUrlFields="doc_name" 
                                                DataNavigateUrlFormatString="viewdocument.aspx?{0}" DataTextField="doc_name" 
                                                HeaderStyle-HorizontalAlign="Left" HeaderText="DOCUMENT NAME" 
                                                NavigateUrl="~/viewdocument.aspx" >
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:HyperLinkField>  --%>
                                        <asp:BoundField DataField="uploaded_date"  HeaderText="UPLOADED DATE">                              
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>                                            
                                        <asp:BoundField DataField="file_size" HeaderText="FILE SIZE"    >  
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="type" />
                                        <%--<asp:TemplateField >
                                        <ItemTemplate >
                                        <a href='viewdocument.aspx?file=<%#DataBinder.Eval(Container.DataItem ,"doc_name") %>' target="myframe" onmouseover ="load_document();" onclick="Hide()"   >    <%#DataBinder.Eval(Container.DataItem ,"doc_name") %></a>
                                        </ItemTemplate>                                        
                                        </asp:TemplateField> --%> 
                                        </Columns>
                
            </asp:GridView>
                    
                    <br />
                    </td>
 
                                    
                                    
  <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                                    
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                            <td align="center" style="background-color: #092443; color: #ffffff;height:25px">Documents to be Uploaded</td>
                            </tr>
                            <tr>
                            <td>
                            <asp:GridView ID="mygriddr" runat="server" 
                                        Font-Names="Arial,Helvetica,sans-serif" Font-Size="X-Small" Width="100%" 
                                        AutoGenerateColumns="False" onrowdatabound="mygriddr_RowDataBound" 
                                    onrowcreated="mygriddr_RowCreated" >
                                        <HeaderStyle CssClass="gvHeaderRow" />
                                        <Columns>
                                        <asp:BoundField DataField="doc_title"  
                                        HeaderStyle-HorizontalAlign="Left" >
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            <ItemStyle Width="45%" />
                                        </asp:BoundField>
                                            <asp:TemplateField>
                                            <ItemTemplate >
                                                <asp:Image ID="Image1" runat="server"  />
                                            </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" Width="5px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="doc_name" HeaderText="FILE NAME" >

                                                <HeaderStyle HorizontalAlign="Center" />

                                                <ItemStyle Width="45%" />
                                            </asp:BoundField>

                                        <asp:BoundField DataField="date_tobeuploaded"  HeaderText="DATE SCHEDULED" 
                                                DataFormatString="{0:dd/MM/yyyy}"  >
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                            </td>
                            <td></td>
                            </tr>
                            <%--<tr>
                                <td>
                                    &nbsp;</td>
                                <td  valign="top">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>--%>
                            <tr>
                                <td  valign="top" align="left">
                                    &nbsp;</td>
                                <td>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                     <div id="myprogress" runat="server" style="position: absolute; z-index: 40; top: 50%; left: 50%">
                                            <asp:Image ID="myimage" runat="server" ImageUrl="~/images/loading30.gif" />
                                            </div>
                                            </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    &nbsp;</td>
                            </tr>
                        </table>
                  
                 </div>
                 
                 <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                
                <%--</div>--%>
                    </td>
            </tr>
        </table>
        
        
    </div>
    </form>
</body>
</html>
