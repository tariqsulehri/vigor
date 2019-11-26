$(function () {
    LoadAttendanceTable();
    
});
var LoadAttendanceTable = function () {

    var empid = $("#empid").val();
    var url = "/HR/EmpHistory/GetAttendance?empId=" + empid+"";
    var table = $('.Attendance_Table').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
            { "data": "formonth", "orderable": true },
            { "data": "Tmonthdays", "orderable": true },
            { "data": "Tworkdays", "orderable": true },
            { "data": "wop", "orderable": true },
            { "data": "leave", "orderable": true },
            { "data": "visit", "orderable": true },
            { "data": "d1", "orderable": true },
            { "data": "d2", "orderable": true },
            { "data": "d3", "orderable": true },
            { "data": "d4", "orderable": true },
            { "data": "d5", "orderable": true },
            { "data": "d6", "orderable": true },
            { "data": "d7", "orderable": true },
            { "data": "d8", "orderable": true },
            { "data": "d9", "orderable": true },
            { "data": "d10", "orderable": true },
            { "data": "d11", "orderable": true },
            { "data": "d12", "orderable": true },
            { "data": "d13", "orderable": true },
            { "data": "d14", "orderable": true },
            { "data": "d15", "orderable": true },
            { "data": "d16", "orderable": true },
            { "data": "d17", "orderable": true },
            { "data": "d18", "orderable": true },
            { "data": "d19", "orderable": true },
            { "data": "d20", "orderable": true },
            { "data": "d21", "orderable": true },
            { "data": "d22", "orderable": true },
            { "data": "d23", "orderable": true },
            { "data": "d24", "orderable": true },
            { "data": "d25", "orderable": true },
            { "data": "d26", "orderable": true },
            { "data": "d27", "orderable": true },
            { "data": "d28", "orderable": true },
            { "data": "d29", "orderable": true },
            { "data": "d30", "orderable": true },
            { "data": "d31", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 37,
                "data": null,
                "orderable": true
                //"render": function (data, type, full, meta) {
                //    var formateurl = "/HR/EmpLoanAdvApplication/Edit/";
                //    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenEmployeeLAdvApplicationCreateModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteLoanApp(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                //    return editurl;
                //}
            }

        ]
    });
    table.columns(0).visible(true);
};

var LoadLoanApprovalTable = function () {
    var url = "/HR/EmpLoanAdvApplication/GetLoanApprovals";
    var table = $('.LoanApprovalTable').DataTable({
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
            { "data": "Date", "orderable": true },
            { "data": "Name", "orderable": true },
            { "data": "ReqAmount", "orderable": true },
            { "data": "ReqInstallment", "orderable": true },
            { "data": "ApproveAmount", "orderable": true },
            { "data": "ApproveLoan", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 7,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/HR/EmpLoanAdvApplication/DetailApprove/";
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenEmployeeLAdvApplicationCreateModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-check"></i> View</a>\n</div>\n</span>\n';
                    return editurl;
                }
            }

        ]
    });
    table.columns(0).visible(true);
};
