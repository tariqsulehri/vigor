$(function () {
    LoadIndentDomesticTable();
});
var LoadIndentDomesticTable = function () {
    var url = "/General/IndentDomestic/GetIndentDomestic";
    var table = $('#LookUpContractsTable').DataTable({
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
                { "data": "Title", "orderable": true},
                { "data": "state", "orderable": true},
                { "data": "country", "orderable": true},
                { "data": "region", "orderable": true}
        ],
        columnDefs: [
        {
            "targets": 5,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/General/IndentDomestic/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenIndentDomesticModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndentDomestic(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                return editurl;
            }
        },
    
        ]
    });
    table.columns(0).visible(true);
};
