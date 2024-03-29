﻿$(function () {
    if ($("#BusinessTypesSwitch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadBusinessTypesTable();

});
var LoadBusinessTypesTable = function () {
        var url = "/General/BusinessTypes/GetBusinessTypes?active=" + switchStatus + "";
    var table = $('#BusinessTypesTable').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
                { "data": "Id", "orderable": true},
                { "data": "Title", "orderable": true, "width": "80%" },
                { "data": "Active", "orderable": true}
        ],
        columnDefs: [
        {
            "targets": 3,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/General/BusinessTypes/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenBusinessTypesModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteBusinessTypes(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                return editurl;
            }
        }
        ]
    });
    table.columns(0).visible(true);
};

var switchStatus = true;
function BusinessTypesChangeSwitch() {
    if ($("#BusinessTypesSwitch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadBusinessTypesTable();
    //if ($("#BusinessTypesSwitch1").is(':checked')) {
    //    switchStatus = $("#BusinessTypesSwitch1").is(':checked');
    //    LoadBusinessTypesTable(switchStatus);
    //}
    //else {
    //    switchStatus = $("#BusinessTypesSwitch1").is(':checked');
    //    LoadBusinessTypesTable(switchStatus);
    //}
};
function BusinessTypesPrint() {
    window.location.href = "/General/BusinessTypes/PrintBusinessTypes?active=" + switchStatus;
};