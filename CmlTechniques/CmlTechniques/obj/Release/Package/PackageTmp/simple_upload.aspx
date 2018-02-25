<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simple_upload.aspx.cs" Inherits="CmlTechniques.simple_upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <%@ import Namespace="System.IO" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
   
<script runat="server" language="C#">

void Page_Load( Object sender, EventArgs e)
{
  if( Request.ContentType.IndexOf( "multipart/form-data" ) < 0 )
    return;

  string strUploadPath = "c:\\upload";

  Response.Write( Request.Files.Count.ToString() + " file(s) have been uploaded:\r\n\r\n" );

  for( int i = 0; i < Request.Files.Count; i++ )
  {
    HttpPostedFile objFile = Request.Files[i];
    String strPath = strUploadPath + "\\" + Path.GetFileName( objFile.FileName );
    objFile.SaveAs( strPath );

    Response.Write( strPath + "\r\n" );
  }
}

</script> 

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
