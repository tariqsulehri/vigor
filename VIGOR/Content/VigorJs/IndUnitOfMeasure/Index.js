$(function () {
    LoadIndUnitOfMeasureTable();
});
var LoadIndUnitOfMeasureTable = function () {
    var url = "/Indent/IndUnitOfMeasure/GetIndUnitOfMeasure";
    var table = $('#IndUnitOfMeasureTable').DataTable({
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
                { "data": "Title", "orderable": true, "width": "80%" }
        ],
        columnDefs: [
        {
            "targets": 2,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/Indent/IndUnitOfMeasure/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenIndUnitOfMeasureModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndUnitOfMeasure('  + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                return editurl;
            }
        }
        ]
    });
    table.columns(0).visible(true);
};

var switchStatus = false;
function ChangeSwitch () {
    if ($("#Switch1").is(':checked')) {
        switchStatus = $("#Switch1").is(':checked');
        LoadIndUnitOfMeasureTable();
        //LoadIndUnitOfMeasureTable(switchStatus);
    }
    else {
        switchStatus = $("#Switch1").is(':checked');
        LoadIndUnitOfMeasureTable();
        //LoadIndUnitOfMeasureTable(switchStatus);
    }
}