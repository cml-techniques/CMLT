<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMS1.aspx.cs" Inherits="CmlTechniques.CMS.CMS1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
 <FRAMESET cols="210px,100%" border="0" frameSpacing="0" frameBorder="0">
       <FRAMESET rows="300px,100%" border="0" frameSpacing="0" frameBorder="0" >
            <frame id="menu" name="menu" src="caslvreport.aspx" ></frame>
            <frame id="tree" name="tree" src="casmvreport.aspx" ></frame>
        </FRAMESET>
         <%--<FRAMESET rows="146px,100%">
            <frame id="head" name="head" src="../head.aspx?id=CMS" scrolling="no"></frame>
            <frame id="content" name="content" src="" ></frame>
        </FRAMESET>--%>

    </FRAMESET>
</html>
