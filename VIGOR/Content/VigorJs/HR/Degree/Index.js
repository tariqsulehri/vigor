$(function () {
    if ($("#Switch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadDegreeTable();
});
var PositionId = 0;
function DeleteIntimation(id) {
    PositionId = id;
    var url = "/HR/Degree/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadDegreeTable();
        }
    });
}



var LoadDegreeTable = function () {
    var empid = $("#empid").val();
    var url = "/HR/Degree/GetDegree?empId=" + empid + "";
    var table = $('.DegreeTable').DataTable({
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
            { "data": "Employee", "orderable": true }

        ],
        columnDefs: [
        {
            "targets":5,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/HR/Degree/Edit/";
                debugger;
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenIntimationCreateModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIntimation(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
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
    LoadDegreeTable();

};
