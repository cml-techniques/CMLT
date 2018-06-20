<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="CmlTechniques.CMS.Dashboard" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <!-- Required meta tags -->
    <title>Dashboard</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href="../Assets/css/fonts/bootstrap.css" rel="stylesheet" />
    <link href="../Assets/css/style1.css" rel="stylesheet" />
    <link href="../Assets/css/Dashboard.css" rel="stylesheet" />
    <link href="../Assets/css/jquery-ui.min.css" rel="stylesheet" />
    <script src="../Assets/js/jquery.min.js"></script>
    <script src="../Assets/js/jquery-ui.min.js"></script>
    <script src="../Assets/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script src="../Scripts/jspdf.debug.js"></script>

    <style type="text/css" media="print">
        @page {
            margin: 0mm;
        }
      
    </style>
    <style  type="text/css">
          #btnPdf{
            margin-right:5px;
        }
    </style>
    <script> 
        var chartData; // holds chart data
        var chartData1;
        var chartData2;
        var chartData3;
        var chartData4;
        var chartData5;
        var chartData6;
        var detailData;
        google.load("visualization", "1", { packages: ['corechart'] });
         
       

        //fill chart data
        $(document).ready(function () {



            $("#btnPrint").click(function (event) {

                var _url = "Dashboard_Print.aspx?prj=" + $("#lblprj").text();;
                window.open(_url);

            });
          
          

             var columnchart = new google.visualization.ColumnChart(document.getElementById('chartdiv'));
            var columnchart1 = new google.visualization.ColumnChart(document.getElementById('chartdiv1'));
            var columnchart2 = new google.visualization.ColumnChart(document.getElementById('chartdiv2'));
            var columnchart4 = new google.visualization.ColumnChart(document.getElementById('chartdiv4'));
            //var columnchart5 = new google.visualization.ColumnChart(document.getElementById('chartdiv5'));
            var columnchart6 = new google.visualization.ColumnChart(document.getElementById('chartdiv6'));
            var detailchart = new google.visualization.ColumnChart(document.getElementById('detailchart'));

               var columnchart7 = new google.visualization.ColumnChart(document.getElementById('chartdiv7'));

            var btnSave = document.getElementById('btnPdf');

            google.visualization.events.addListener(columnchart, 'ready', function () {
                btnSave.disabled = false;
              });
             google.visualization.events.addListener(columnchart1, 'ready', function () {
                btnSave.disabled = false;
            });
             google.visualization.events.addListener(columnchart2, 'ready', function () {
                btnSave.disabled = false;
            });
             google.visualization.events.addListener(columnchart4, 'ready', function () {
                btnSave.disabled = false;
            });
            // google.visualization.events.addListener(columnchart5, 'ready', function () {
            //    btnSave.disabled = false;
            //});
             google.visualization.events.addListener(columnchart6, 'ready', function () {
                btnSave.disabled = false;
            });   

              google.visualization.events.addListener(columnchart7, 'ready', function () {
                btnSave.disabled = false;
            }); 
           
              btnSave.addEventListener('click', function () {
                var doc = new jsPDF();
                
                var width = doc.internal.pageSize.width;    
                var height = (doc.internal.pageSize.height - 50)/2;

                var fontSize = doc.internal.getFontSize();          
                var title = $("#lblproject").html() + " | Dashboard";
                var txtWidth = doc.getStringUnitWidth(title)*fontSize/doc.internal.scaleFactor;       
          
                doc.text(( width - txtWidth ) / 2, 10, title);
                doc.addImage(columnchart.getImageURI(), 0, 20, width, height);
                doc.addImage(columnchart1.getImageURI(), 0, height + 20, width, height);
                doc.addPage();
                doc.addImage(columnchart2.getImageURI(), 0, 20, width, height);
                doc.addImage(columnchart4.getImageURI(), 0, height + 20, width, height);
                doc.addPage();
                //doc.addImage(columnchart5.getImageURI(), 0, 20, width, height);
                  doc.addImage(columnchart6.getImageURI(), 0, height + 20, width, height); 
                  doc.addImage(columnchart7.getImageURI(), 0, height, width, height); 
                doc.save('Dashboard.pdf');                
            }, false);

            function drawChart(chartData) {
            var data = new google.visualization.DataTable(chartData);
            var options = {
            fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            title: "Overall System Summary",
            legend: { position: 'none', maxLines: 3, textStyle: { fontSize: 10 } },
            series: { 0: { color: '#C98E33' } },
            //series: [{ color: 'blue', visibleInLegend: true }, { color: 'red', visibleInLegend: false }],
            animation: { startup: true, duration: 2000, easing: 'out' },
            vAxis: {
                title: "Progress %",
                width: '50%',
                height: '50%',
                viewWindowMode: 'maximized',
                viewWindow: {
                    max: 100,
                    min: 0
                },
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                },
                gridlines: {
                    count: 10
                },
                format: '#\'%\''
            },
            hAxis: {
                title: "",
                textStyle: {
                    fontSize: 9,
                    bold: true,
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                }
            },
            is3D: true
            };
            data.addColumn('string', 'Label');
            data.addColumn('number', 'Actual Progress');
            data.addColumn({ type: 'string', role: 'style' });



            for (var i = 0; i < chartData.length; i++) {
            if (i == (chartData.length - 1)) {
                data.addRow([chartData[i].Label, chartData[i].GraphActualData, 'color:#050505']);
            }
            else {
                data.addRow([chartData[i].Label, chartData[i].GraphActualData, 'color:#C10843']);
            }
            }

           
            var formatter = new google.visualization.NumberFormat({ pattern: '#\'%\'', fractionDigits: 2 });
            formatter.format(data, 1);
            formatter.format(data, 2);
            columnchart.draw(data, options);
             
            }
            function drawServiceChart() {
            var data1 = new google.visualization.DataTable(chartData1);
            var data2 = new google.visualization.DataTable(chartData2);
            var data4 = new google.visualization.DataTable(chartData6);
            var data7 = new google.visualization.DataTable(chartData7);

            var dataview1 = new google.visualization.DataView(data1);
            var dataview2 = new google.visualization.DataView(data2);
            var dataview4 = new google.visualization.DataView(data4);
            var dataview7 = new google.visualization.DataView(data7);

            var options1 = {
            fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            title: "Electrical Systems",
            legend: { position: 'none', maxLines: 1, textStyle: { fontSize: 10 } },
            animation: { startup: true, duration: 2000, easing: 'out' },
            series: { 0: { color: '#800080' } },
            vAxis: {
                title: "Progress %",
                viewWindowMode: 'maximized',
                viewWindow: {
                    max: 100,
                    min: 0
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                },
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                gridlines: {
                    count: 10
                },
                format: '#\'%\''
            },
            hAxis: {
                title: "",
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                }
            }
            };
            var options2 = {
            // backgroundColor: '#f1f1f1',
            fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            title: "Mechanical Systems",
            legend: { position: 'none', maxLines: 3, textStyle: { fontSize: 9 } },
            animation: { startup: true, duration: 5000, easing: 'out' },
            series: { 0: { color: '#D0EA11' }, 1: { color: '#1144EA' } },
            vAxis: {
                title: "Progress %",
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                },
                viewWindowMode: 'maximized',
                viewWindow: {
                    max: 100,
                    min: 0
                },
                gridlines: {
                    count: 10
                },
                format: '#\'%\''
            },
            hAxis: {
                title: "",
                textStyle: {
                    fontSize: 9,
                    bold: true,
                    color: '#282c35'
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                }
            }
            };
            var options4 = {
            fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            title: "Fire Protection and Public Health Services",
            legend: { position: 'none', maxLines: 3, textStyle: { fontSize: 10 } },
            animation: { startup: true, duration: 2000, easing: 'out' },
            series: { 0: { color: '#3399ff' }, 1: { color: '#2F262F' } },
            vAxis: {
                title: "Progress %",
                viewWindowMode: 'maximized',
                viewWindow: {
                    max: 100,
                    min: 0
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                },
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                gridlines: {
                    count: 10
                },
                format: '#\'%\''
            },
            hAxis: {
                title: "",
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                }
            }
                };


            var options7 = {
            fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            title: "ELV Systems",
            legend: { position: 'none', maxLines: 3, textStyle: { fontSize: 10 } },
            animation: { startup: true, duration: 2000, easing: 'out' },
            series: { 0: { color: '#3399ff' }, 1: { color: '#2F262F' } },
            vAxis: {
                title: "Progress %",
                viewWindowMode: 'maximized',
                viewWindow: {
                    max: 100,
                    min: 0
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                },
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                gridlines: {
                    count: 10
                },
                format: '#\'%\''
            },
            hAxis: {
                title: "",
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                }
            }
                };

            data1.addColumn('string', 'Label');
            //data1.addColumn('number', 'Planned Progress')
            //data1.addColumn({ type: 'string', role: 'style' });
            data1.addColumn('number', 'Actual Progress');
            data1.addColumn({ type: 'string', role: 'style' });
            data1.addColumn('number', 'ID');

            data2.addColumn('string', 'Label');
            //data2.addColumn('number', 'Planned Progress')
            //data2.addColumn({ type: 'string', role: 'style' });
            data2.addColumn('number', 'Actual Progress');
            data2.addColumn({ type: 'string', role: 'style' });
            data2.addColumn('number', 'ID');
            data4.addColumn('string', 'Label');
            //data4.addColumn('number', 'Planned Progress')
            //data4.addColumn({ type: 'string', role: 'style' });
            data4.addColumn('number', 'Actual Progress');
            data4.addColumn({ type: 'string', role: 'style' });
             data4.addColumn('number', 'ID');

            data7.addColumn('string', 'Label');
            //data1.addColumn('number', 'Planned Progress')
            //data1.addColumn({ type: 'string', role: 'style' });
            data7.addColumn('number', 'Actual Progress');
            data7.addColumn({ type: 'string', role: 'style' });
            data7.addColumn('number', 'ID');

            for (var i = 0; i < chartData1.length; i++) {
            if (i != (chartData1.length - 1))
                data1.addRow([chartData1[i].Label, chartData1[i].Progress, 'color: #800080', chartData1[i].ID]);
            else
                data1.addRow([chartData1[i].Label, chartData1[i].Progress, 'color: #000080', chartData1[i].ID]);
            }

            for (var i = 0; i < chartData2.length; i++) {
            if (i != (chartData2.length - 1))
                data2.addRow([chartData2[i].Label, chartData2[i].Progress, 'color: #1144EA', chartData2[i].ID]);
            else
                data2.addRow([chartData2[i].Label, chartData2[i].Progress, 'color: #066CC9', chartData2[i].ID]);
            }
            for (var i = 0; i < chartData6.length; i++) {
            if (i != (chartData6.length - 1))
                data4.addRow([chartData6[i].Label, chartData6[i].Progress, 'color: #2F262F', chartData6[i].ID]);
            else
                data4.addRow([chartData6[i].Label, chartData6[i].Progress, 'color: #E8193B', chartData6[i].ID]);
                }

            for (var i = 0; i < chartData7.length; i++) {
            if (i != (chartData7.length - 1))
            data7.addRow([chartData7[i].Label, chartData7[i].Progress, 'color: #2F262F', chartData7[i].ID]);
            else
            data7.addRow([chartData7[i].Label, chartData7[i].Progress, 'color: #E8193B', chartData7[i].ID]);
            }
          
            var formatter = new google.visualization.NumberFormat({ pattern: '#\'%\'', fractionDigits: 2 });
            formatter.format(data1, 1);
            formatter.format(data1, 2);
            formatter.format(data2, 1);
            formatter.format(data2, 2);
            formatter.format(data4, 1);
            formatter.format(data4, 2);

            formatter.format(data7, 1);
            formatter.format(data7, 2);

            //dataview1 = new google.visualization.DataView(data1);
            dataview1.setColumns([0, 1, 2]);
            //dataview2 = new google.visualization.DataView(data2);
            dataview2.setColumns([0, 1, 2]);
            //dataview4 = new google.visualization.DataView(data4);
            dataview4.setColumns([0, 1, 2]);
            dataview7.setColumns([0, 1, 2]);

            columnchart1.draw(dataview1, options1);
            columnchart2.draw(dataview2, options2);
            columnchart6.draw(dataview4, options4);
            columnchart7.draw(dataview7, options7);

            google.visualization.events.addListener(columnchart1, 'select', selecthandler);
            google.visualization.events.addListener(columnchart2, 'select', selecthandler1);
            google.visualization.events.addListener(columnchart6, 'select', selecthandler4);
            google.visualization.events.addListener(columnchart7, 'select', selecthandler5);

            google.visualization.events.addListener(columnchart1, 'onmouseover', handler1);
            google.visualization.events.addListener(columnchart1, 'onmouseout', handler2);
            google.visualization.events.addListener(columnchart2, 'onmouseover', handler1);
            google.visualization.events.addListener(columnchart2, 'onmouseout', handler2);
            google.visualization.events.addListener(columnchart6, 'onmouseover', handler1);
            google.visualization.events.addListener(columnchart6, 'onmouseout', handler2);

            google.visualization.events.addListener(columnchart7, 'onmouseover', handler1);
            google.visualization.events.addListener(columnchart7, 'onmouseout', handler2);
            function handler1() {
            $('#chartdiv1').css('cursor', 'pointer');
            $('#chartdiv2').css('cursor', 'pointer');
            $('#chartdiv6').css('cursor', 'pointer');
            $('#chartdiv7').css('cursor', 'pointer');
            }
            function handler2() {
            $('#chartdiv1').css('cursor', 'default');
            $('#chartdiv2').css('cursor', 'default');
            $('#chartdiv6').css('cursor', 'default');
            $('#chartdiv7').css('cursor', 'pointer');
            }
            var label;
            function selecthandler() {
            var id = data1.getValue(columnchart1.getSelection()[0].row, 3);
            label = data1.getValue(columnchart1.getSelection()[0].row, 0);

            if (id != 100) {
                //$('#loader7').show();
                modalOpen(id, label);
            }
            }
            function selecthandler1() {
            var id1 = data2.getValue(columnchart2.getSelection()[0].row, 3);
            label = data2.getValue(columnchart2.getSelection()[0].row, 0);
            if (id1 != 100) {
                //$('#loader8').show();
                modalOpen(id1, label);
            }
            }
            function selecthandler4() {
            var id2 = data4.getValue(columnchart6.getSelection()[0].row, 3);
            label = data4.getValue(columnchart6.getSelection()[0].row, 0);
            if (id2 != 100) {
                //$('#loader9').show();
                modalOpen(id2, label);
            }
                }

                function selecthandler5() {
 
            var id4 = data7.getValue(columnchart7.getSelection()[0].row, 3);
            label = data7.getValue(columnchart7.getSelection()[0].row, 0);
            if (id4 != 100) {
                //$('#loader9').show();
                modalOpen(id4, label);
            }
            }
            }
            function drawCassheetChart(chartData4) {
            var data1 = new google.visualization.DataTable(chartData4);
            //var data2 = new google.visualization.DataTable(chartData5);
            var options1 = {
            fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            title: "Fire & Voice Alarm Services",
            legend: { position: 'none', maxLines: 3, textStyle: { fontSize: 10 } },
            animation: { startup: true, duration: 5000, easing: 'out' },
            series: { 0: { color: '#E8396E' } },
            vAxis: {
                title: "Progress %",
                viewWindowMode: 'maximized',
                viewWindow: {
                    max: 100,
                    min: 0
                },
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                },
                gridlines: {
                    count: 10
                },
                format: '#\'%\''
            },
            hAxis: {
                title: "",
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                }
            }
            };
            //var options2 = {
            //fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            //title: "BMS",
            //legend: { position: 'none', maxLines: 3, textStyle: { fontSize: 10 } },
            //animation: { startup: true, duration: 7000, easing: 'out' },
            //series: { 0: { color: '#FF5733' }, 1: { color: '#00FF00' } },
            //vAxis: {
            //    title: "Progress %",
            //    viewWindowMode: 'maximized',
            //    viewWindow: {
            //        max: 100,
            //        min: 0
            //    },
            //    textStyle: {
            //        fontSize: 9,
            //        bold: true
            //    },
            //    titleTextStyle: {
            //        fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            //        fontSize: 11,
            //        italic: false,
            //        bold: true
            //    },
            //    gridlines: {
            //        count: 10
            //    },
            //    format: '#\'%\''
            //},
            //hAxis: {
            //    title: "",
            //    textStyle: {
            //        fontSize: 9,
            //        bold: true
            //    },
            //    titleTextStyle: {
            //        fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            //        fontSize: 11,
            //        italic: false,
            //        bold: true
            //    }
            //}
            //};

            data1.addColumn('string', 'Label');
            data1.addColumn('number', 'Actual Progress');
            data1.addColumn({ type: 'string', role: 'style' });

            //data2.addColumn('string', 'Label');
            //data2.addColumn('number', 'Actual Progress');
            //data2.addColumn({ type: 'string', role: 'style' });

            for (var i = 0; i < chartData4.length; i++) {
            if (i != (chartData4.length - 1))
                data1.addRow([chartData4[i].Label, chartData4[i].GraphActualData, 'color: #C0C0C0']);
            else
                data1.addRow([chartData4[i].Label, chartData4[i].GraphActualData, 'color: #FF0000']);
            }
            //for (var i = 0; i < chartData5.length; i++) {
            //if (i != (chartData5.length - 1))
            //    data2.addRow([chartData5[i].Label, chartData5[i].GraphActualData, 'color:#00FF00'])
            //else
            //    data2.addRow([chartData5[i].Label, chartData5[i].GraphActualData, 'color:#0000FF'])
            //}
          
            var formatter = new google.visualization.NumberFormat({ pattern: '#\'%\'', fractionDigits: 2 });
            formatter.format(data1, 1);
            formatter.format(data1, 2);
            //formatter.format(data2, 1);
            //formatter.format(data2, 2);
            columnchart4.draw(data1, options1);
            //columnchart5.draw(data2, options2);
            }
          
          

              var xhr1 = $.ajax({
                url: "Dashboard.aspx/GetChartData",
                data: JSON.stringify({ prj: document.getElementById("<%= lblprj.ClientID %>").innerHTML }),
                dataType: "json",
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                success: function (data) {
                    chartData = data.d;
                },
                error: function () {
                    xhr1.abort();
                }
            }).done(function () {
                //after complete data load
                drawChart(chartData);
            });

            var xhr2 = $.ajax({
                url: "Dashboard.aspx/GetServiceData",
                data: JSON.stringify({ prj: document.getElementById("<%= lblprj.ClientID %>").innerHTML }),
                dataType: "json",
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                success: function (data) {
                    chartData1 = data.d[0];
                    chartData2 = data.d[1];
                    chartData6 = data.d[3];
                    chartData7 = data.d[2];
                },
                error: function (data) {
                    xhr2.abort();
                }
            }).done(function () {
                drawServiceChart();
            });

            var xhr3 = $.ajax({
                url: "Dashboard.aspx/GetCasDetails",
                data: JSON.stringify({ prj: document.getElementById("<%= lblprj.ClientID %>").innerHTML }),
                dataType: "json",
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                success: function (data) {
                    chartData4 = data.d[0];
                    //chartData5 = data.d[1];
                },
                error: function (data) {
                    xhr3.abort();
                }
            }).done(function () {
                drawCassheetChart(chartData4);
            });
        });


       

       
       
   <%--     function modalOpen1(id1, label) {
            $.ajax({
                url: "Dashboard.aspx/GetModalDetails",
                data: JSON.stringify({ casid: id1, prj: document.getElementById("<%= lblprj.ClientID %>").innerHTML }),
                dataType: "json",
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                success: function (data) {
                    detailData = data.d;
                },
                error: function () {
                    $('#loader8').hide();
                    alert("Error loading page! Please try again");
                }
            }).done(function () {
                $('#modal1').modal('show').on('shown.bs.modal', function () {
                    drawDetailsChart(detailData, label);
                    $('#loader8').hide();
                });
            });
        }--%>
        function modalOpen(id, label) {
            $.ajax({
                url: "Dashboard.aspx/GetModalDetails",
                data: JSON.stringify({ casid: id, prj: document.getElementById("<%= lblprj.ClientID %>").innerHTML }),
                dataType: "json",
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                success: function (data) {
                    detailData = data.d;
                },
                error: function () {
                    //$('#loader7').hide();
                    alert("Error loading page! Please try again");
                }
            }).done(function () {
                $('#modal1').modal('show').on('shown.bs.modal', function () {
                      drawDetailsChart(detailData, label);
                    //if (id != 7)
                    //    drawDetailsChart(detailData, label);
                    //else if (id == 7)
                    //    drawDetailsChart1(detailData, label);
                    //$('#loader7').hide();
                });
            });
        }
      <%--  function modalOpen2(id2, label) {
            $.ajax({
                url: "Dashboard.aspx/GetModalDetails",
                data: JSON.stringify({ casid: id2, prj: document.getElementById("<%= lblprj.ClientID %>").innerHTML }),
                dataType: "json",
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                success: function (data) {
                    detailData = data.d;
                },
                error: function () {
                    $('#loader9').hide();
                    alert("Error loading page! Please try again");
                }
            }).done(function () {
                $('#modal1').modal('show').on('shown.bs.modal', function () {
                    drawDetailsChart(detailData, label);
                    $('#loader9').hide();
                });
            });
        }--%>
      
        
        $(window).resize(function () {
            drawChart(chartData);
            drawServiceChart();
            //drawExecutiveChart(chartData3);
            drawCassheetChart(chartData4);
            //drawDetailsChart(detailData, label);
            //drawDetailsChart1(detailData, label);
        });





        //        $('modal-content').resizable({
        //            minHeight: 300,
        //            minWidth: 300
        //        });
        //        $('.modal-dialog').draggable();

        //        $('#myModal').on('show.bs.modal', function () {
        //            $(this).find('.modal-body').css({
        //                'max-height': '100%'
        //            });
        //        });
        //function myfunct() {
        //    window.print();
        //}
       
        function clearData() {
            var charts = document.getElementById("detailchart");
            charts.innerHTML = "";
        }
        function getsrc() {

            var path = 'LoadImage.ashx?id=' + $("#lblprj").text();;

            $("#imglogo").attr("src", path);

        }
          function drawDetailsChart(detailData, label) {
            var data = new google.visualization.DataTable(detailData);
            var options = {
            fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
            title: label,
            legend: { position: 'none', maxLines: 3, textStyle: { fontSize: 10 } },
            colors: ['#ff6666'],
            //series: [{ color: 'blue', visibleInLegend: true }, { color: 'red', visibleInLegend: false }],
            animation: { startup: true, duration: 2000, easing: 'out' },
            vAxis: {
                title: "Progress %",
                width: '50%',
                height: '50%',
                viewWindowMode: 'maximized',
                viewWindow: {
                    max: 100,
                    min: 0
                },
                textStyle: {
                    fontSize: 9,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                },
                gridlines: {
                    count: 10
                },
                format: '#\'%\''
            },
            hAxis: {
                title: "",
                textStyle: {
                    fontSize: 8,
                    bold: true
                },
                titleTextStyle: {
                    fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
                    fontSize: 11,
                    italic: false,
                    bold: true
                },
                textPosition: 'out',
                slantedText: true,
                slantedTextAngle: 30,
                maxTextLines: 4
            },
            is3D: true
            };
            data.addColumn('string', 'Label');
            data.addColumn('number', 'Actual Progress');
            data.addColumn({ type: 'string', role: 'style' });
            if (detailData != null) {
            for (var i = 0; i < detailData.length; i++) {
                if (i == (detailData.length - 1)) {
                    data.addRow([detailData[i].Label, detailData[i].Progress, 'color: #993366']);
                }
                else {
                    data.addRow([detailData[i].Label, detailData[i].Progress, 'color: #ff6666']);
                }
            }
            }


            var detailschart=new google.visualization.ColumnChart(document.getElementById('detailchart'));
            var formatter = new google.visualization.NumberFormat({ pattern: '#\'%\'', fractionDigits: 2 });
            formatter.format(data, 1);
            detailschart.draw(data, options);
        }
          //function drawDetailsChart1(detailData, label) {
          //  var data = new google.visualization.DataTable(detailData);
          //  var options = {
          //  fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
          //  title: label,
          //  legend: { position: 'none', maxLines: 3, textStyle: { fontSize: 10 } },
          //  colors: ['#ff6666'],
          //  //series: [{ color: 'blue', visibleInLegend: true }, { color: 'red', visibleInLegend: false }],
          //  animation: { startup: true, duration: 2000, easing: 'out' },
          //  vAxis: {
          //      title: "Progress %",
          //      width: '50%',
          //      height: '50%',
          //      viewWindowMode: 'maximized',
          //      viewWindow: {
          //          max: 100,
          //          min: 0
          //      },
          //      textStyle: {
          //          fontSize: 9,
          //          bold: true
          //      },
          //      titleTextStyle: {
          //          fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
          //          fontSize: 11,
          //          italic: false,
          //          bold: true
          //      },
          //      gridlines: {
          //          count: 10
          //      },
          //      format: '#\'%\''
          //  },
          //  hAxis: {
          //      title: "",
          //      textStyle: {
          //          fontSize: 8,
          //          bold: true
          //      },
          //      titleTextStyle: {
          //          fontName: 'Segoe UI, Frutiger, Frutiger Linotype, Dejavu Sans, Helvetica Neue, Arial, sans-serif',
          //          fontSize: 11,
          //          italic: false,
          //          bold: true
          //      },
          //      textPosition: 'out',
          //      slantedText: true,
          //      slantedTextAngle: 30,
          //      maxTextLines: 4
          //  },
          //  is3D: true
          //  };
          //  data.addColumn('string', 'Label');
          //  data.addColumn('number', 'Actual Progress');
          //  data.addColumn({ type: 'string', role: 'style' });
          //  if (detailData != null) {
          //  for (var i = 0; i < detailData.length; i++) {
          //      if (i == (detailData.length - 1)) {
          //          data.addRow([detailData[i].Label, detailData[i].Progress, 'color: #993366']);
          //      }
          //      else {
          //          data.addRow([detailData[i].Label, detailData[i].Progress, 'color: #ff6666']);
          //      }
          //  }
          //  }

           
          //  var formatter = new google.visualization.NumberFormat({ pattern: '#\'%\'', fractionDigits: 2 });
          //  formatter.format(data, 1);
          //      detailchart.draw(data, options);

          //  }
    </script>
</head>
<body style="background-color: #f1f1f1">
    <div class="container-fluid">
        <div class="row sec-head">
            <div class="col-lg-12 text-center">             
                    <strong class="check-link  font-weight-bold">
                        <asp:Label runat="server" ID="lblproject"></asp:Label><span> | Dashboard</span>
                    </strong>
               
                 <button type="button" id="btnPrint" class="btn btn-basic btn-primary pull-right">Print</button>
                <button type="button" id="btnPdf" class="btn btn-basic btn-primary pull-right">PDF</button>
            </div>
           
                
        </div>

        <div class="row">
            <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 col-m-t box sum1">
                <div id="chartdiv" class="chart border-rad" style="position: relative">
                    <div id="loader2" class="loader"></div>
                </div>
            </div>
            <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12 col-m-t box sum1">
                <div id="chartdiv1" class="chart border-rad">
                <div id="loader3" class="loader"></div>
                <div id="loader7" class="loader"></div>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-lg-4 col-md-5 col-sm-12 col-xs-12 sum1">
                <div id="chartdiv2" class="chart border-rad">
                <div id="loader4" class="loader"></div>
                <div id="loader8" class="loader"></div>
                </div>

            </div>
            <div class="col-lg-8 col-md-7 col-sm-12 col-xs-12 sum1">
                <div id="chartdiv7" class="chart border-rad">
                 <div id="loader5" class="loader"></div>
                </div>

            </div>
        </div>
        <div class="row">
            <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 sum1">
                <div id="chartdiv6" class="chart border-rad">
                 <div id="loader9" class="loader"></div>
                <div id="loader10" class="loader"></div>
                </div>

                <asp:Label ID="lblprj" runat="server" Text="Label" Style="display: none"></asp:Label>
            </div>
            <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12 sum1" style="margin-bottom: 20px;">
              <%--  <div id="chartdiv5" class="chart border-rad">--%>
                   <div id="chartdiv4" class="chart border-rad">
                      <div id="loader6" class="loader"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modal1" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-lg">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-body">
                    <div id="detailchart" class="chart border-rad"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" data-dismiss="modal" onclick="clearData();">Close</button>
                </div>
            </div>
        </div>
    </div>
    <canvas id="canvasGraph" style="display:none;"></canvas>
</body>
</html>

