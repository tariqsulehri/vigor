$(function () {
    LoadIndentSizeTable();
});
var LoadIndentSizeTable = function () {
    var url = "/Indent/IndentSize/GetIndentSize";
    var table = $('#IndentSizeTable').DataTable({
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
                "targets": 2,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/Indent/IndentSize/Edit/";

                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenIndentSizeModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndentSize(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                    return editurl;
                }
            }
        ]
    });
    table.columns(0).visible(true);
};
var switchStatus = false;
function ChangeSwitch() {
    if ($("#Switch1").is(':checked')) {
        switchStatus = $("#Switch1").is(':checked');
        LoadGoodsForwarderTable();
        //LoadGoodsForwarderTable(switchStatus);
    }
    else {
        switchStatus = $("#Switch1").is(':checked');
        LoadGoodsForwarderTable();
        //LoadGoodsForwarderTable(switchStatus);
    }
}

function OpenIndentSizeModal(url) {

    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndentSizeModel').html(data);
            $('#IndentSizeModel').modal('show');
        }
    });
}

function DeleteIndentSize(id) {

    var url = "/Indent/IndentSize/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndentSizeTable();
        }
    });
}

function SubmitIndentSizeForm() {
    var formData = new FormData($('#IndentSizeForm')[0]);
    var url = $('#IndentSizeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndentSizeModel').modal('hide');
                LoadIndentSizeTable();
            } else {
                $('#IndentSizeModel').html(data);
                $('#IndentSizeModel').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

