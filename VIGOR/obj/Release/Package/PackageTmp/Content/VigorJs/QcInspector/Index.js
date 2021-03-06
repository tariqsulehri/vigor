﻿$(function () {
    LoadQCTable();
});
var PositionId = 0;
function DeleteQCI(id) {
    PositionId = id;
    var url = "/General/QcInspectors/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadQCTable();
        }
    });
}
var LoadQCTable = function () {
    var url = "/General/QcInspectors/GetQcInspector?active=" + switchStatus + "";
    var table = $('.QcInspectorTable').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
            { "data": "Id", "orderable": true },
            { "data": "Title", "orderable": true, "width": "80%" }

        ],
        columnDefs: [
        {
            "targets":2,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/General/QcInspectors/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenQcInspectorModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteQCI(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                return editurl; 
            }
        }
    
        ]
    });
    table.columns(0).visible(true);
};
var switchStatus = true;
function ChangeSwitch() {
    if ($("#Switch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadQCTable();

};
