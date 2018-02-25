<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Management.aspx.cs" Inherits="CmlTechniques.Management" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<script language="javascript" type="text/javascript">
      function callmodule(_id, type) {
          if (type == "0") {
              document.getElementById("head").src = "Manage_Head.aspx?id=" + _id;
              document.getElementById("content").src = "";
          }
          else if (type == "1") {
          document.getElementById("content").src = "UploadTree.aspx";
          }
          else if (type == "sub") {
          document.getElementById("content").src = "scheduling.aspx";
          }
          else if (type == "3") {
              document.getElementById("content").src = "cmsdocreview.aspx?PRJ=" + _id;

          }
          else if (type == "4") {
              document.getElementById("content").src = "methodstatements.aspx?id=" + _id;

          }
          else if (type == "5") {
              location.replace("docview.aspx");

          }
          else if (type == "6") {
              document.getElementById("content").src = "../cmsminutes.aspx?id=" + _id;

          }
          else if (type == "7") {
              document.getElementById("content").src = "../cmsprogrammes.aspx?id=" + _id;

          }
          else if (type == "8") {
              if (_id == "Trial" || _id == "ASAO") {
                  document.getElementById("content").src = "siteObservation.aspx?PRJ=" + _id;
              }
              else {
                  document.getElementById("content").src = "so.aspx?PRJ=" + _id;
              }

          }
          else if (type == "9") {
              location.replace("../programview.aspx");

          }
          else if (type == "10") {
              document.getElementById("content").src = _id;

          }
          else if (type == "11") {
              document.getElementById("content").src = "ms_schedule.aspx";

          }
          else if (type == "12") {
              document.getElementById("content").src = "caslvreport.aspx";
          }
          else if (type == "13") {
              document.getElementById("content").src = "../tcdocumentation.aspx?id=" + _id;
          }
          else if (type == "14") {
              document.getElementById("content").src = "mech_ahu.aspx?id=" + _id;
          }
          else if (type == "15") {
              document.getElementById("content").src = "cmstraining.aspx?id=" + _id;
          }
          else if (type == "16") {
              document.getElementById("content").src = "Reports.aspx?id=" + _id;
          }
          else if (type == "17") {
              //document.getElementById("content").src = "graph.aspx?id=" + _id;
              document.getElementById("content").src = "Summary.aspx?id=1" + _id;
          }
          else if (type == "18") {
              //document.getElementById("content").src = "graph.aspx?id=" + _id;
              document.getElementById("content").src = "Service_Summary.aspx?id=" + _id;
          }
          else if (type == "19") {
              //document.getElementById("content").src = "graph.aspx?id=" + _id;
              document.getElementById("content").src = "Doc_Summary.aspx?id=" + _id;
          }
          else if (type == "20") {
              //document.getElementById("content").src = "graph.aspx?id=" + _id;
              document.getElementById("content").src = "ms_schedule.aspx";
          }
          else if (type == "21") {
              document.getElementById("content").src = "../cmsdocreviewadd.aspx?PRJ=" + _id;
          }
          else if (type == "22") {
              document.getElementById("content").src = "cmsmemo.aspx?id=" + _id;
          }
          else if (type == "23") {
              document.getElementById("content").src = "cmsletters.aspx?id=" + _id;
          }
          else if (type == "24") {
              document.getElementById("content").src = "cmswircmlcmnts.aspx?id=" + _id;
          }
          else if (type == "25") {
              //document.getElementById("content").src = "graph.aspx?id=" + _id;
              document.getElementById("content").src = "Cas_SummaryAll.aspx?id=" + _id;
          }
          else if (type == "26") {
              //document.getElementById("content").src = "graph.aspx?id=" + _id;
              document.getElementById("content").src = "../CAS/Cassheet_Summary.aspx?id=" + _id;
          }
          else if (type == "27") {
              //document.getElementById("content").src = "graph.aspx?id=" + _id;
              document.getElementById("content").src = "cxissue_master.aspx?id=" + _id;
          }
          else if (type == "28") {
              document.getElementById("content").src = "MechReview.aspx?id=" + _id;
          }
          else if (type == "29") {
              document.getElementById("content").src = "CXIR_Schedule.aspx?id=" + _id;
          }
      }
      function MenuClick(type) {
          if (type == 1) {
              //location.replace("../cmlhome.aspx");
              location.replace("../home.aspx?id=0");
          }
          else if (type == 2) {
              location.replace('https://cmltechniques.com');
          }
          else if (type == 3) {
              document.getElementById("content").src = "cmsreports.aspx";
          }
      }
      function calldataentry(srv) {
          document.getElementById("content").src = "../cas_electrical_dataentry.aspx";
      }
      
    </script>
  <title>CML Techniques | Commissioning Management System</title>
    <link href="../Stylesheet3.css" rel="stylesheet" type="text/css" />   
    </head>
    <FRAMESET cols="210px,100%" border="0" frameSpacing="0" frameBorder="0">
         <frame id="menu" name="menu" src="Manage_Nav.aspx" scrolling="no"></frame>
         <FRAMESET rows="80px,100%" border="0" frameSpacing="0" frameBorder="0">
            <frame id="head" name="head" src="" scrolling="no"></frame>
            <frame id="content" name="content" src="Manage_Banner.htm" runat="server" ></frame>
        </FRAMESET>

    </FRAMESET>
</html>
