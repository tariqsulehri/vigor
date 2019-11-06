$(function () {
    if ($("#Switch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadNCRTable();
});
var PositionId = 0;
function DeleteNCR(id) {
    PositionId = id;
    var url = "/HR/EmpNonConfirmity/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadNCRTable();
        }
    });
}


var LoadNCRTable = function () {
    var empid = $("#empid").val();
    var url = "/HR/EmpNonConfirmity/GetEmpNCR?empId=" + empid + "";
    var table = $('.CINCR_Table').DataTable({
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
            { "data": "Employee", "orderable": true },
            { "data": "EmpName", "orderable": true },
            { "data": "Type", "orderable": true }

        ],
        columnDefs: [
            {
                "targets": 4,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/HR/EmpNonConfirmity/Edit/";
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenEmployeeNCRCreateModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteNCR(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                    return editurl;
                }
            }

        ]
    });
    table.columns(0).visible(true);
};