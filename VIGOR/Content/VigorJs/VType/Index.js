$(function () {
    LoadfnVTypeTable();
});
var LoadfnVTypeTable = function () {
    var url = "/GL/fnVType/GetfnVType";
    var table = $('#fnVTypeTable').DataTable({
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
            { "data": "Title", "orderable": true, "width": "80%" }

        ],
        columnDefs: [
        {
            "targets":2,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/GL/fnVType/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenfnVTypeModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n</div>\n</span>\n';
                return editurl;
            }
        }
    
        ]
    });
    table.columns(0).visible(true);
};
