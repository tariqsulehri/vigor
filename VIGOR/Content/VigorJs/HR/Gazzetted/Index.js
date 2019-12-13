$(function () {
    if ($("#Switch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadGazzettedDayTable();
});
var PositionId = 0;
function DeletePosition(id) {
    PositionId = id;
    var url = "/HR/GazzettedDay/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadGazzettedDayTable();
        }
    });
}
var LoadGazzettedDayTable = function () {
    var url = "/HR/GazzettedDay/GetGazzettedDay?active=" + switchStatus + "";
    var table = $('.GazzettedTable').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
            { "data": "Id", "orderable": true, "width": "10%" },
            { "data": "From", "orderable": true, "width": "15%" },
            { "data": "To", "orderable": true, "width": "15%" },
            { "data": "Descp", "orderable": true, "width": "60%" }

        ],
        columnDefs: [
            {
                "targets": 4,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/HR/GazzettedDay/Edit/";
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenEmployeeGazzettedModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> Edit</a>\n</div>\n</span>\n';
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
    LoadGazzettedDayTable();

};