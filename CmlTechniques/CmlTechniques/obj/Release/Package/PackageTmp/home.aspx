<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="CmlTechniques.home" %>
<HTML >
    <head>
  <script language="javascript" type="text/javascript">
function click()
{
    document.getElementById("3").src = "userlogin.aspx";
}
function menu_click(type) {
    if (type == "1") {
        location.replace('https://cmltechniques.com');
    }
    else if (type == "2") {
       location.replace('adminpage.aspx');
        // location.replace('Management.aspx?Uauth=#2@%s14HGnj0Ol');
    }
    else if (type == "3") {
        location.replace('mailto:admin@cmlinternational.net');
        //var uri = "http://www.cmlinternational.co.uk/#/contact-us/4556971903";
        //window.open("http://cmlinternational.co.uk" + encodeURIComponent("#") + "/contact-us/4556971903"); 
    }
}
</script>
  <title>CML Techniques</title>
  <link rel="shortcut icon" href="Images/favicon.ico"/> 
  <script type="text/javascript">
      function call(mod,prj) {
          if (mod == "1") {
              location.replace("DMS.aspx?PRJ=" + prj);
              //location.replace("project_home.aspx");
          }
          else if (mod == "2") {
              //location.replace("cmsnew.aspx");
              location.replace("CMS/CMS.aspx?PRJ=" + prj);
          }
          else if (mod == "3") {
              location.replace("SNS/SnaggingSystem.aspx");
          }
          else if (mod == "4") {
              location.replace("AMS/AMS.aspx");
          }
          else if (mod == "5") {
              location.replace("TIS/TIS.aspx?PRJ=" + prj);
          }
      }
    </script>
    </head>

    <FRAMESET cols="210px,100%" border="0" frameSpacing="0" frameBorder="0">
         <!--<FRAMESET rows="100%,100%">-->
            <frame id="menu" name="menu" src="menu.aspx" scrolling="no"></frame>
            
        <!--</FRAMESET>-->
         <FRAMESET rows="146px,100%" border="0" frameSpacing="0" frameBorder="0">
            <frame id="head" name="head" src="head.aspx?id=0&prj=0" scrolling="no"></frame>
            <frame id="content" name="content" src="welcome.aspx" ></frame>
        </FRAMESET>

    </FRAMESET>
</HTML>

