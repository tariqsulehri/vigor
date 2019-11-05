$(function () {
    LoadIndPriceTermsTable();
});
var LoadIndPriceTermsTable = function () {
    var url = "/Indent/IndPriceTerms/GetIndPriceTerms";
    var table = $('#IndPriceTermsTable').DataTable({
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
                { "data": "Abbrivation", "orderable": true }
        ],
        columnDefs: [
        {
            "targets": 3,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/Indent/IndPriceTerms/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenIndPriceTermsModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndPriceTerms('  + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
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
        LoadIndPriceTermsTable();
        //LoadIndPriceTermsTable(switchStatus);
    }
    else {
        switchStatus = $("#Switch1").is(':checked');
        LoadIndPriceTermsTable();
        //LoadIndPriceTermsTable(switchStatus);
    }
}