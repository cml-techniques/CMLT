<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project_home.aspx.cs" Inherits="CmlTechniques.project_home" %>

<HTML >
    <head>
  <script language="javascript" type="text/javascript">
function click()
{
    document.getElementById("3").src = "userlogin.aspx";
}
function menu_click(type) {
    if (type == "1") {
        location.replace('logout.aspx');
    }
    else if (type == "2")
        location.replace('adminpage.aspx');
    else if (type == "3")
        location.replace('mailto:admin@cmlinternational.net');
}
function openFrame(_id, type) {
    //myframe.location.clear();
    if (type != 1) {
        //myframe.location = "load.aspx?id=" + _id;
        document.getElementById("content").src = "load.aspx?id=" + _id;
    }
    else {
        // myframe.location = "loadOM.aspx?id=" + _id;
        document.getElementById("content").src = "loadOM.aspx?id=" + _id;
    }
}
</script>
  <title>CML Techniques</title>
    </head>

    <FRAMESET cols="210px,100%" border="0" frameSpacing="0" frameBorder="0">
         <FRAMESET rows="314px,100%" border="1">
            <frame id="menu" name="menu" src="menu.aspx" scrolling="no"></frame>
            <frame id="tree" name="menu" src="tree.aspx" ></frame>
        </FRAMESET>
         <FRAMESET rows="151px,30px,100%">
            <frame id="head" name="head" src="head.aspx" scrolling="no"></frame>
            <frame id="title" name="title" src="title.aspx" scrolling="no"></frame>
            <frame id="content" name="content"  ></frame>
        </FRAMESET>

    </FRAMESET>
</HTML>