$(function () {
    LoadLoanApprovalTable();
});
var LoadLoanApprovalTable = function () {
    debugger;
    var url = "/HR/LoanAdvApproval/GetLoanApprovals";
    var table = $('.LoanApproval_Table').DataTable({
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
            { "data": "ReqInstallment", "orderable": true }
            { "data": "ApproveAmount", "orderable": true },
            { "data": "ApproveLoan", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 7,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/HR/LoanAdvApproval/Edit/";
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenEmployeeLAdvApplicationCreateModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> View</a>';
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
