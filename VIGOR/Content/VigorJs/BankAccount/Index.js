$(function () {
    LoadBankAccountTable();
});
var LoadBankAccountTable = function () {
    var url = "/General/BankAccount/GetBankAccount";
    var table = $('.BankAccountTable').DataTable({
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
                var formateurl = "/General/BankAccount/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="' + formateurl + full.Id + '"><i class="la la-edit"></i> Edit</a>\n</div>\n</span>\n';
                return editurl;
            }
        }
        ]
    });
    table.columns(0).visible(true);
};