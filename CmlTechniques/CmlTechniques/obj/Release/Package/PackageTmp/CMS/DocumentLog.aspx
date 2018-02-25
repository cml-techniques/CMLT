<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentLog.aspx.cs" Inherits="CmlTechniques.CMS.DocumentLog" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
         
    </title>
    <script src="../Assets/js/jquery-1.12.4.js"></script>
     <link href="../page.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/Style.css" rel="stylesheet" type="text/css" />
    <link href="../Assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script src="../Assets/js/jquery.dataTables.min.js"></script>
    <link href="../Assets/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="../Assets/js/dataTables.fixedHeader.min.js"></script>
    <link href="../Assets/css/fixedHeader.dataTables.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>   
    <script src="../Assets/js/bootstrap.min.js"></script>
    <script src="../Assets/js/dropzone.js"></script>
    <link href="../Assets/css/dropzone.css" rel="stylesheet" />
    <script src="../Assets/js/font-awesome.js"></script>
    <link href="../Assets/css/sweetalert.css" rel="stylesheet" />
  <script src="../Assets/js/sweetalert.min.js"></script>
    <link href="../Assets/css/Spinner.css" rel="stylesheet" />
    <style type="text/css">
        .font-error {
        color: #ed5565;
        }
        .font-success {
        color: #1ab394;
        }
        .hide{
        display:none;
        }
        .font-normal{
        font-weight:normal;
        }
        table{
            font-size:0.88rem;
        }
        table th{
        background-color: #fff;
        color: #9B9B9B;
        text-align:left;
        padding: 10px 12px!important;
        font-weight:400!important;
        }
        table tr td{  
        cursor: pointer;
        text-align:left;
        }
        table.dataTable.stripe tbody tr.odd,table.dataTable.display tbody tr.odd{
            background-color:transparent;
        }
        .gvHeaderRow
        {
        background-image: url('../images/head_bg.png');
        background-repeat: repeat;
        font-family: Verdana;
        font-size: x-small;
        font-weight: normal;
        }
        .gvCell
        {
        padding-left: 5px;
        }
        .fixedhead{
        position:relative;
        height:auto;
        }
        *, *:before, *:after {
        box-sizing: border-box;
        }
        html {
        font-size: 18px;
        font-family: 'Open Sans', Helvetica, Arial, sans-serif;
        }
        a.control, .modal-footer a {
        text-decoration: none!important;
        }
        .wrapper {
        position: relative;
        min-width: 1024px;
        }
        .header {
        padding: 0px;
        }
        .header--txt {
        color: #fff!important;
        font-weight: 600;
        font-size:18px;
        margin:0;
        padding:5px 10px;
        background-color:#263544;
        }
        #infobar .prjinfo{
            padding:0px 5px;
        }
        .controls {
        padding: 5px 10px 5px 20px;
        }
        .control {
        font-weight: 600;
        color: #263544;
        text-transform: uppercase;
        font-size:18px;
        }

        .control:nth-of-type(2) {
        padding: 0 40px;
        }
        .table {
        position: relative;
        width: 100%;
        border-collapse: collapse;
        }
        .row--selected, .row--normal:hover, table tbody tr:hover, 
        .row-selected .row--normal, .row-selected .cell--normal {
        background-color: #f3f3f4!important;
        }
        .cell, table tbody td, table tbody th {
        padding: 10px 12px;
        font-size: 0.88rem;
        border-top:0;
        cursor: pointer;
        }
        .cell--header {
        position: -webkit-sticky;
        position: sticky;
        top: 0px;
        z-index: 1;
        text-align: left;
        background-color: #fff;
        color: #9b9b9b;
        }
        .cell--header:after {
        content: '';
        position: absolute;
        left: 0;
        bottom: 0;
        width: 100%;
        border-bottom: 1px solid rgba(204, 204, 204, .5);
        }
        .cell--select {
        width: 35px;
        background-image: url(https://s3-us-west-2.amazonaws.com/s.cdpn.io/464211/ic_check_box_outline_blank_black_24px.svg)!important;
        background-repeat: no-repeat;
        background-position: center!important;
        background-size: 12px;
        }
        .cell--selected {
        background-image: url(https://s3-us-west-2.amazonaws.com/s.cdpn.io/464211/ic_check_box_black_24px.svg)!important;
        }
        .cell--upload {
        color: #148c74;
        }
        .sorting_1{
        background-color:inherit!important;
        }

        .modal{
        font-family:'Open Sans';
        }
        .modal-content{
        width:320px;
        }
        .modal-header {
        background-color: #F3F3F4;
        font-weight: 600;
        color: #263544;
        font-size:18px;
        }
        .modal-body, .modal-body h5{
        background-color: #F3F3F4;
        color: #9B9B9B;
        font-weight:bold;
        font-family:inherit;
        }
        .modal-body{
        padding:10px 15px;
        }
        .modal-body h5:first-child{
        margin-top:0px;
        }
        .modal-body h5{
        margin-bottom:5px;
        }
        .modal-body .form-control{
        font-weight:normal;
        }
        .modal-footer {
        background-color: #263544;
        font-size:18px;  
        border-top:0;
        padding:5px 10px;
        }
        .modal-footer a{
        color:#f3f3f4;
        }
        .modal-footer a:first-child{
        float:left;
        }
        .modal-body .dz-message{
        background-color:#c0c0c0;
        color:#f3f3f4;
        padding:3px 12px;
        font-weight:bold;
        height:27px;
        }
        .dz-details, .dz-preview,.dz-image{
        visibility:hidden;
        display:none!important;
        }
        .doc-details{
        display: flex;
        justify-content: space-between;
        }
        .dvDocument{
        width:250px;
        }
        .dropzone{
        padding: 0;
        min-height: 20px;
        height: 25px;
        width: 150px;
        border:0;
        margin-top:10px;
        }
        .dropzone .dz-message{
        margin:0;
        }
        .dropzone.dz-started .dz-message{
        display:block!important;
        background-color:#9B9B9B 
        }
        tbody tr td:first-child:not(.dataTables_empty){
        color:transparent;
        }
       
        table.dataTable thead th, table.dataTable thead td{
   
        border-bottom: 0.1px solid #9B9B9B!important;
        }
        table.dataTable.no-footer{
   
        border-bottom: 0;
        }
        table tbody tr:last-child td{
            border-bottom: 0.1px solid #ddd!important
        }
        table.dataTable.row-border tbody tr:not(:first-child) th, 
        table.dataTable.row-border tbody tr:not(:first-child) td, 
        table.dataTable.display tbody tr:not(:first-child) th, 
        table.dataTable.display tbody tr:not(:first-child) td {
        border-top: 0.1px solid #ddd!important;
        }
        .sweet-alert button{
        border-radius:0;
        }
        .sweet-alert h2{
        font-size:18px;
        color:#cc0000;
        font-weight:bold;
        line-height:normal;
        }
        .sweet-alert button.cancel {
        background-color: #1ab394;
}
        table.dataTable tbody th, 
        table.dataTable tbody td {
        padding: 8px 10px;        
        word-break: break-word;
    }
        table.dataTable tbody th:not(:first-child), 
        table.dataTable tbody td:not(:first-child) {
        width:19%;
    }
    </style>
    <script type="text/javascript">
        function calldoc(id, file) {
            debugger
            var _prj = document.getElementById("lblprj");

            var path = "viewdoc.aspx?prj=" + _prj.textContent + "&doc=" + id;
            parent.callcms(path, '10');
           
        }
        function Fullscreen() {
            var myFrameset = parent.document.getElementById("main");
            var value = myFrameset.getAttribute("cols");
            if (value == "210px,100%") {
                parent.document.getElementById("main").cols = "0px,100%";
                parent.document.getElementById("container").rows = "0px,100%";
            }
            else {
                parent.document.getElementById("main").cols = "210px,100%";
                parent.document.getElementById("container").rows = "115px,100%";
            }
        }
        
        $(document).ready(function () {
            var documentLog;
            var proj = document.getElementById("<%= lblProjectCode.ClientID %>").value;

            documentLog = $('#documentLog').DataTable({
                'ajax': {
                    "type": "POST",
                    "url": '../Services/LoadData.asmx/GetData?prj=' + proj,
                    "data": "",
                    "dataSrc": "d",
                    "dataType": "json",
                    "contentType": "application/json; charset=utf-8",
                },
                'columns': [
                    { "data": "documentId" },
                    { "data": "cableReference" },
                    { "data": "panelReference" },
                    { "data": "fedFrom" },
                    { "data": "powerTo" },
                    { "data": "documentName" }
                ],
                "paging": false,
                "bFilter": false,
                "bInfo": false,
                "language": {
                    "emptyTable": "No records to show"
                },
                "fixedHeader": {
                    header: true,
                },
                "columnDefs": [
                    {
                        "targets": [0],
                        "bSortable": false,
                        "class": "cell cell--normal cell--select",
                        "render": function (data, type, row) {
                            return data;
                        },
                    },
                    {
                        "targets": [1],
                        "class": "cell cell--normal",
                    },
                    {
                        "targets": [2],
                        "class": "cell cell--normal",
                    },
                    {
                        "targets": [3],
                        "class": "cell cell--normal",
                    },
                    {
                        "targets": [4],
                        "class": "cell cell--normal",
                    },
                    {
                        "targets": [5],
                        "class": "cell cell--normal clickable",
                        "render": function (data, type, row) {                           
                            return '<a class="font-success" href="viewdoc.aspx?prj=' + proj + '&doc=' + row["documentId"] + '&mod=CableLog")>' + data + ' </a>';
                        },
                    }
                ],
            });

            $('#documentLog tbody').on('click', 'tr', function () {
                $(this).find('.cell--select').toggleClass('cell--selected');
                $(this).toggleClass('row--selected');
               
                if ($(this).hasClass('row--selected')) {    
                    if ((documentLog.rows('.even').data().length + documentLog.rows('.odd').data().length) === documentLog.rows('.row--selected').data().length) {
                        $('th.cell--select').addClass('cell--selected');
                    }
                    else {
                        $('th.cell--select').removeClass('cell--selected');
                    }
                }
                else 
                {                    
                    $('th.cell--select').removeClass('cell--selected');
                }
            });

            $('#documentLog thead').on('click', '.cell--select', function () {
                $(this).toggleClass('cell--selected');
                if ($(this).hasClass('cell--selected'))
                {
                    $('#documentLog tbody').find('.cell--select').addClass('cell--selected');
                    $('#documentLog tbody').find('tr').addClass('row--selected');
                }
                else {
                    $('#documentLog tbody').find('.cell--select').removeClass('cell--selected');
                    $('#documentLog tbody').find('tr').removeClass('row--selected');
                }
            });

            $('#lnkAdd').on('click', function () {
                ClearModal();
                $('#modalLog .modal-header').html('MV Cable Test Item Add');
                $('#lnkSave').html('Add Item');
                $("#notifySave").removeClass('hide');
                $(".row--selected").click();
                $(".row--selected").removeClass('row--selected');
                $("#modalLog").modal('show');

            });

            $('#lnkEdit').on('click', function () {
                ClearModal();
                $('#modalLog .modal-header').html('MV Cable Test Item Edit');
                $('#lnkSave').html('Save Edit');

                if (documentLog.rows('.row--selected').data().length < 1) {
                    swal({
                        title: "Please select a item to edit.",
                        text: "",
                        showCancelButton: true,
                        showConfirmButton: false,
                        cancelButtonColor: '#1ab394',
                        cancelButtonText: "OK",
                        closeOnCancel: false,
                        imageUrl: "../images/warning.png"
                    })
                }
                else if (documentLog.rows('.row--selected').data().length > 1) {
                    swal({
                        title: "Please select only one item at a time to edit.",
                        text: "",
                        showCancelButton: true,
                        showConfirmButton: false,
                        cancelButtonColor: '#1ab394',
                        cancelButtonText: "OK",
                        closeOnCancel: false,
                        imageUrl: "../images/warning.png"
                    })
                }
                else {
                    $("#txtCableRef").val($('tr.row--selected').find('td').eq(1).html());
                    $("#txtPanelRef").val($('tr.row--selected').find('td').eq(2).html());
                    $("#txtFedFrom").val($('tr.row--selected').find('td').eq(3).html());
                    $("#txtPowerTo").val($('tr.row--selected').find('td').eq(4).html());
                    $("#dvDocName").html($('tr.row--selected').find('.clickable a').html());
                    $("#dvDocName").attr('prever', $("#dvDocName").html());
                    if ($.trim($("#dvDocName").html()) != '') {
                        $("#dvDocName").addClass('font-success');
                        $("#lnkRemove").addClass('font-success');
                        $('#lnkRemove').html('<i class="fa fa-check" aria-hidden="true"></i>');
                    }
                    else {
                        $('#lnkRemove').html('');
                    }

                    $("#modalLog").modal('show');
                }
            });

            $('#lnkDelete').on('click', function () {
                var count = documentLog.rows('.row--selected').data().length;
                var docids = '';
                var pdfDocs = '';

                $(".row--selected").each(function () {
                    docids = docids + $(this).find('td.cell--selected').html() + ',';
                    pdfDocs = pdfDocs + $(this).find('.clickable a').html() + ',';
                });

                if (count < 1) {
                    swal({
                        title: "Please select a item to delete.",
                        text: "",
                        showCancelButton: true,
                        showConfirmButton: false,
                        cancelButtonColor: '#1ab394',
                        cancelButtonText: "OK",
                        closeOnCancel: false,
                        imageUrl: "../images/warning.png"
                    })
                }
                else {

                    swal({
                        title: "Are you sure you want to delete the selected items? \n" + count + "No.",
                        text: "",
                        showCancelButton: true,
                        confirmButtonColor: '#cc0000',
                        cancelButtonColor: '#1ab394',
                        confirmButtonText: 'Delete',
                        cancelButtonText: "Cancel",
                        closeOnConfirm: true,
                        closeOnCancel: true,
                        imageUrl: "../images/warning.png"
                    }, function () {
                        $.ajax({
                            type: "Post",
                            url: "../Services/LoadData.asmx/DeleteLog",
                            data: JSON.stringify({
                                ids: docids,
                                pdfs: pdfDocs,
                                prj: document.getElementById("<%= lblProjectCode.ClientID %>").value
                            }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                            },
                            error: function (xhr, status, err) {
                                alert(xhr.responseText);
                            }
                        }).done(function () {
                            $('#documentLog').DataTable().ajax.reload();
                            if (documentLog.rows('cell--select').data().length === 0) {
                                $('.cell--select').removeClass('cell--selected');
                            }
                        });
                    })
                }
            });
          
            function SaveLog() {
                if ($.trim($("#txtCableRef").val()) === '') {
                    swal({
                        title: "Please enter Cable Reference.",
                        text: "",
                        showCancelButton: true,
                        showConfirmButton: false,
                        cancelButtonColor: '#1ab394',
                        cancelButtonText: "OK",
                        imageUrl: "../images/warning.png"
                    })
                }
                else {
                    var docid = 0;
                    if (documentLog.rows('.row--selected').data().length > 0) {
                        docid = $('#documentLog tbody').find('td.cell--selected').html();
                    }
                    var prever = $("#dvDocName").attr('prever');

                        $.ajax({
                            type: "Post",
                            url: "../Services/LoadData.asmx/SaveLog",
                            data: JSON.stringify({
                                id: docid,
                                cr: document.getElementById("<%= txtCableRef.ClientID %>").value,
                            pr: document.getElementById("<%= txtPanelRef.ClientID %>").value,
                            ff: document.getElementById("<%= txtFedFrom.ClientID %>").value,
                            pt: document.getElementById("<%= txtPowerTo.ClientID %>").value,
                            doc: document.getElementById("<%= dvDocName.ClientID %>").innerHTML,
                            preVer: prever,
                            prj: document.getElementById("<%= lblProjectCode.ClientID %>").value
                        }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                        },
                        error: function (xhr, status, err) {
                            alert(xhr.responseText);
                        }
                        }).done(function () {
                        $("#modalLog").modal('hide');
                        $('#documentLog').DataTable().ajax.reload();
                    });
                }
            };

            function ClearModal() {
                if ($("#notifySave").hasClass('hide') === false) {
                    $("#notifySave").addClass('hide');
                }   
                $("#dvDocName").removeClass('font-error');
                $("#lnkRemove").removeClass('font-error');
                $("#dvDocName").removeClass('font-success');
                $("#lnkRemove").removeClass('font-success');

                $("#txtCableRef").val('');
                $("#txtPanelRef").val('');
                $("#txtFedFrom").val('');
                $("#txtPowerTo").val('');
                $("#dvDocName").html('');
                $("#lnkRemove").html('');
            }

            ///Dropzone code
            Dropzone.autoDiscover = false;
            
             $("#dZUpload").dropzone({
                 url: "../Handlers/Uploader.ashx?prj=" + proj,
                 maxFiles: 1,
                 addRemoveLinks: true,
                 acceptedFiles: '.pdf',
                 autoProcessQueue: false,
                 init: function () {
                     var myDropzone = this; 
                     var uploadButton = document.querySelector("#lnkSave");
                     uploadButton.addEventListener("click", function () {
                         $(".loader-wrapper").removeClass('hide');
                         if (myDropzone.files[0] != null) {
                             myDropzone.processQueue();
                         }
                         else {
                             SaveLog();
                             $(".loader-wrapper").addClass('hide');
                         }
                         
                     });

                     this.on("addedfile", function (file) {
                         var myDropzone = this;

                         if (myDropzone.files[1] != null) {
                             myDropzone.removeFile(myDropzone.files[0]);
                         }
                        
                         if (file.type != 'application/pdf') {
                             myDropzone.removeFile(myDropzone.files[0]);
                             swal("Invalid file format!", "Please select a file in PDF format.", "warning");
                         }

                         $("#dvDocName").html(myDropzone.files[0].name); 
                         $("#dvDocName").removeClass('font-success');
                         $("#lnkRemove").removeClass('font-success');
                         $("#dvDocName").addClass('font-error');
                         $("#lnkRemove").addClass('font-error');
                         $('#lnkRemove').html('<i class="fa fa-times" aria-hidden="true"></i>');
                         $("#notifySave").removeClass('hide');

                         var submitButton = document.querySelector("#lnkRemove");
                         submitButton.addEventListener("click", function () {                           
                             myDropzone.removeFile(myDropzone.files[0]);
                             $("#dvDocName").html('');
                             $('#lnkRemove').html('');
                         });           
                     });
                 },
                 success: function (file, response) {     
                     $(".loader-wrapper").addClass('hide');
                     var myDropzone = this; 
                     if (response === "fail") {
                         myDropzone.removeFile(myDropzone.files[0]);
                         $("#dvDocName").html('');
                         $('#lnkRemove').html('');
                         swal({
                             title: "File already exists. Please rename the file to upload.",
                             text: "",
                             showCancelButton: true,
                             showConfirmButton: false,
                             cancelButtonColor: '#1ab394',
                             cancelButtonText: "OK",
                             closeOnCancel: false,
                             imageUrl: "../images/warning.png"
                         })
                     }
                     else {
                         SaveLog();
                     }
                 },
                 complete: function () {

                 },
                 error: function (file, response) {
                     file.previewElement.classList.add("dz-error");
                 }
             });
           
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="lblProjectCode" />
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
         <div class="fixedhead" runat="server" id="dvfixedhead">
        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
            <ContentTemplate>
                <div id="infobar">
                    <div class="prjinfo">
                        <div class="pullleft font-big">
                            <a href="#" onclick="Fullscreen();"><i class="fa fa-align-justify"></i></a>CMS :
                            <asp:Label ID="prj" runat="server" Style="color: #e6422c"></asp:Label></div>
                        <div class="pullright font-big">
                            <asp:Label ID="package" runat="server" Style="color: #e6422c" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        <header class="header">
    <h1 class="header--txt">
      <asp:Label ID="lblModuleName" runat="server"></asp:Label>
    </h1>
  </header>
  <div class="loader-wrapper hide">
  <div class="loader">
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
  </div>
</div>
  <div class="controls">
    <a href="#" class="control" id="lnkAdd">Add</a>
    <a href="#" class="control" id="lnkEdit">Edit</a>
    <a href="#" class="control" id="lnkDelete">Delete</a>
  </div>
     <table id="documentLog" class="display" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th class="cell cell--select"></th>
                <th>MV Cable Reference</th>
                <th>Panel Reference</th>
                <th>Fed From</th>
                <th>Power To</th>
                <th>Test Document</th>
            </tr>
        </thead>      
        <tbody>
          
        </tbody>
    </table>
     <div id="modalLog" class="modal fade" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header text-center">
                    MV Cable Test Item Edit
                 </div>
                <div class="modal-body">    
                    <div class="font-error hide" id="notifySave">Unsaved Changes!</div>
                    <h5>MV Cable Reference</h5>
                    <input type="text" class="form-control" runat="server" value="" id="txtCableRef"/>
                     <h5>Panel Reference</h5>
                    <input type="text" class="form-control" runat="server" value="" id="txtPanelRef"/>
                    <h5>Fed From</h5>
                    <input type="text" class="form-control" runat="server" value="" id="txtFedFrom"/>
                    <h5>Power To</h5>
                    <input type="text" class="form-control" runat="server" value="" id="txtPowerTo"/>
                    <h5>Test Document</h5>
                   <%-- <input type="text" class="form-control" value="" id="txtDocument"/>
                    <input type="button" class="btn" value="Select Document" id="btnUpload"/>    --%>   
                      <div id="dvDocument" class="doc-details form-control">
                        <div id="dvDocName" prever="" runat="server" ></div>
                        <a id="lnkRemove" class="dz-remove"></a>
                    </div>
                    <div id="dZUpload" class="dropzone" >
                    <div  class="dz-default dz-message"> Select Document
                    </div>
                    </div>         
                </div>
                <div class="modal-footer">
                    <a id="lnkSave">Save Edit</a>
                    <a data-dismiss="modal">Cancel</a>
            </div>
            </div>
        </div>
    </div>
    </form>
    
</body>   
</html>
