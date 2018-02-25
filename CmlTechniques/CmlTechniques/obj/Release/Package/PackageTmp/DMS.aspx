<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DMS.aspx.cs" Inherits="CmlTechniques.DMS" %>


<html >
<head runat="server">
  <script language="javascript" type="text/javascript">
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
      function openView(_id) {
          document.getElementById("content").src = "dmsuploads.aspx?id=" + _id;
      }
      function _view(_id) {
          //        myframe.location = "viewdocument.aspx";
          document.getElementById("content").src = "viewdocument.aspx?id=" + _id;
      }
      function doc_list() {
          //        myframe.location = "viewdocument.aspx";
          document.getElementById("content").src = "doclist_all.aspx";
      }
      function call(id) {
          location.replace("viewmanual.aspx?id=" + id);
      }
      function MenuClick(type,_id) {
          if (type == 1) {
              //location.replace("../cmlhome.aspx");
              location.replace("../home.aspx?id=0");
          }
          else if (type == 2) {
              location.replace('https://cmltechniques.com');
          }
          else if (type == 3) {
              document.getElementById("content").src = "reportpage.aspx";
          }
          else if (type == 4) {
              document.getElementById("content").src = "OMIndex.aspx?PRJ=" + _id;
          }
          else if (type == 5) {
              document.getElementById("content").src = "Scripts/search.html?zoom_query=" + _id;
          }
          else if (type == 6) {
          document.getElementById("content").src = "DMSReportViewer.aspx?PRJ=" + _id;
          }
      }
    </script>
  <title>CML Techniques | Document Management System</title>
  <link rel="shortcut icon" href="Images/favicon.ico"/> 
    <style type="text/css"> 
body { 
scrollbar-face-color:#0066FF; 
scrollbar-highlight-color:#CEE7FF; 
scrollbar-3dlight-color:#0057AE; 
scrollbar-darkshadow-color:#000000; 
scrollbar-shadow-color:#808080; 
scrollbar-arrow-color:#00FFFF; 
scrollbar-track-color:#BFDFFF; 
} 
</style>  
    </head>
    <FRAMESET cols="210px,100%" border="0" frameSpacing="0" frameBorder="0">
       <FRAMESET rows="350px,100%" border="0" frameSpacing="0" frameBorder="0">
            <frame id="menu" name="menu" src="dmsmenu.aspx" scrolling="no"></frame>
            <frame id="tree" name="tree" src="" runat="server" scrolling="auto"  ></frame>
        </FRAMESET>
         <FRAMESET rows="146px,100%" border="0" frameSpacing="0" frameBorder="0">
            <frame id="head" name="head" src="" scrolling="no" runat="server"></frame>
            <frame id="content" name="content" src="" runat="server" style="padding-left:5px"  ></frame>
        </FRAMESET>
    </FRAMESET>
</html>
