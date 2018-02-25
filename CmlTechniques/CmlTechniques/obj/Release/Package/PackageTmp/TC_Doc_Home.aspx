<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TC_Doc_Home.aspx.cs" Inherits="CmlTechniques.TC_Doc_Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function openFrame(_id) {
            document.getElementById("right").src = "TC_Doc.aspx?id=" + _id;
        }
                
    </script>
</head>
  <FRAMESET cols="310px,100%" border="0" frameSpacing="0" frameBorder="0">
            <frame id="left" name="dms" src="" scrolling="yes" runat="server"></frame>
            <frame id="right" name="cms" src="" scrolling="yes"></frame>
    </FRAMESET>
</html>
