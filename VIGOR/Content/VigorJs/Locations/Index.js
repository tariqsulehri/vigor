﻿$(function () {
    LoadLocationsTable();
});
var LoadLocationsTable = function () {
    var url = "/General/Locations/GetLocations";
    var table = $('#LocationsTable').DataTable({
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
                "targets": 2,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/General/Locations/Edit/";
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenLocationsModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteLocations(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                    return editurl;
                }
            }
        ]
    });
    table.columns(0).visible(true);
};

function LocationsPrint() {
    window.location.href = "/General/Locations/PrintLocations?active=" + switchStatus;
};