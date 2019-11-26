$(function () {
    
    
    LoadLoanAppTable();
    LoadLoanApprovalTable();
});
var PositionId = 0;
function DeleteLoanApp(id) {
    PositionId = id;
    var url = "/HR/EmpLoanAdvApplication/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadLoanAppTable();
        }
    });
}
var LoadLoanAppTable = function () {

    var empid = $("#empid").val();
    var url = "/HR/EmpLoanAdvApplication/GetLApplication?empId=" + empid+"";
    var table = $('.LoanApp_Table').DataTable({
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
            { "data": "type", "orderable": true },
            { "data": "Amount", "orderable": true },
            { "data": "Instalment", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 5,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/HR/EmpLoanAdvApplication/Edit/";
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenEmployeeLAdvApplicationCreateModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteLoanApp(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                    return editurl;
                }
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
var switchStatus = true;
function ChangeSwitch() {
    if ($("#Switch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadLoanApprovalTable();

};
