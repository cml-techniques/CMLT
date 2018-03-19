<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMS.aspx.cs" Inherits="CmlTechniques.CMS.CMS" %>

<HTML >
    <head>
    <meta http-equiv="X-UA-Compatible" content="IE=9" />
  <script language="javascript" type="text/javascript">
      function callcms(_id, type) {
          if (type == "0") {
              document.getElementById("content").src = "cassheet_master.aspx?id=" + _id;
          }
          else if (type == "1") {
              document.getElementById("content").src = "cmsdoclist.aspx?id=" + _id;
          }
          else if (type == "sub") {
              document.getElementById("content").src = "cmsdocreview_details.aspx";
          }
          else if (type == "3") {
              document.getElementById("content").src = "cmsdocreview.aspx?PRJ=" + _id + "&ACN=0";
          }
          else if (type == "4") {
              document.getElementById("content").src = "methodstatements.aspx?id=" + _id;

          }
          else if (type == "41") {
              document.getElementById("content").src = "ms12761.aspx?id=" + _id;

          }
          else if (type == "5") {
              location.replace("docview.aspx?" + _id);

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
            else if (_id == "NBO") {
                document.getElementById("content").src = "SOLog1.aspx?PRJ=" + _id + "&ACN=0";
            }
            else {
            //document.getElementById("content").src = "so.aspx?PRJ=" + _id + "&ACN=0";
                document.getElementById("content").src = "SOLog.aspx?PRJ=" + _id + "&ACN=0";
            }

          }
          else if (type == "9") {
              location.replace("../programview.aspx?" + _id);

          }
          else if (type == "10") {
              document.getElementById("content").src = _id;

          }
          else if (type == "11") {
              document.getElementById("content").src = "ms_schedule.aspx" + _id;
          }
          else if (type == "28") {
              document.getElementById("content").src = "Dashboard1.aspx?prj="+_id;
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
              document.getElementById("content").src = "Reports.aspx?" + _id;
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
              document.getElementById("content").src = "Doc_Summary.aspx?" + _id;
          }
          else if (type == "20") {
              //document.getElementById("content").src = "graph.aspx?id=" + _id;
              document.getElementById("content").src = "ms_schedule.aspx?" + _id;
          }
          else if (type == "201") {
              document.getElementById("content").src = "ms_schedule12761.aspx?" + _id;

          }
          else if (type == "21") {
              document.getElementById("content").src = "../cmsdocreviewadd.aspx?PRJ=" + _id;
          }
          else if (type == "22") {
              document.getElementById("content").src = "cmsmemo.aspx?id=" + _id;
              //              document.getElementById("content").src = "methodstatements1.aspx?id=" + _id;
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
          //else if (type == "28") {
          //    document.getElementById("content").src = "MechReview.aspx?id=" + _id;
          //}
          else if (type == "29") {
              document.getElementById("content").src = "CXIR_Schedule.aspx?id=" + _id;
          }
          else if (type == "30") {
              document.getElementById("content").src = "TestpackHome.aspx?id=" + _id;
          }
          else if (type == "31") {
              document.getElementById("content").src = "../CAS/SystemsList.aspx?PRJ=" + _id;
          }
          else if (type == "32") {
              document.getElementById("content").src = _id;
          }
          else if (type == "33") {
              document.getElementById("content").src = "MonthlyReports.aspx?id=" + _id;
          }
          else if (type == "34") {
              document.getElementById("content").src = "cmsdocreview1.aspx?PRJ=" + _id;
          }
          else if (type == "35") {
              document.getElementById("content").src = "FATestUploadsList.aspx?" + _id;
          }
          else if (type == "36") {
              location.replace("DocPdfView.aspx?" + _id);
          }
          else if (type == "37") {
              // location.replace("FactoryAcceptanceTestUploads1.aspx?" + _id);
              document.getElementById("content").src = "FATestUploadsEntry.aspx?" + _id;
          }
          else if (type == "38") {
              // location.replace("FactoryAcceptanceTestUploads1.aspx?" + _id);
              document.getElementById("content").src = "FATestUploadsList1.aspx?" + _id;
          }
          else if (type == "42") {
              document.getElementById("content").src = "TCEntry.aspx?" + _id;
          }

          else if (type == "39") {
              document.getElementById("content").src = "../cmsuploads1.aspx?" + _id;
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
              document.getElementById("content").src = "cmsreports.aspx?idx=0";
          }
//          else if (type == 4) {
//              document.getElementById("content").src = "Dashboard1.aspx?idx=0";
//          }          
      }
      function calldataentry(srv) {
          document.getElementById("content").src = "../cas_electrical_dataentry.aspx";
          
      }
      function CallReport(id) {
          document.getElementById("content").src = "cmsreports.aspx?prj=" + id;
      }
    </script>
  <title>CML Techniques | Commissioning Management System</title>
  <link rel="shortcut icon" href="../Images/favicon.ico"/> 
    <link href="../Stylesheet3.css" rel="stylesheet" type="text/css" />   
    </head>

    <FRAMESET cols="210px,100%" border="0" frameSpacing="0" frameBorder="0">
            
       <FRAMESET rows="300px,100%" border="0" frameSpacing="0" frameBorder="0">
            <frame id="menu" name="menu" src="" runat="server" scrolling="no"></frame>
            <frame id="tree" name="tree" src="" runat="server" ></frame>
        </FRAMESET>
         <FRAMESET rows="146px,100%" border="0" frameSpacing="0" frameBorder="0">
            <frame id="head" name="head" src="" scrolling="no" runat="server" ></frame>
            <frame id="content" name="content" src="" runat="server" ></frame>
        </FRAMESET>

    </FRAMESET>
</HTML>