$(function () {
    LoadIndentColourTable();
});
var LoadIndentColourTable = function () {
    var url = "/Indent/IndColour/GetIndColour";
    var table = $('#IndentColourTable').DataTable({
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
            { "data": "ColourID", "orderable": true },
            { "data": "ColourCode", "orderable": true },
            { "data": "Title", "orderable": true },
            { "data": "Description", "orderable": true }

        ],
        columnDefs: [
            {
                "targets": 5,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/Indent/IndColour/Edit/";

                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenIndentColourModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndentColour(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
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

function OpenIndentColourModal(url) {

    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndentColourModel').html(data);
            $('#IndentColourModel').modal('show');
        }
    });
}

function DeleteIndentColour(id) {

    var url = "/Indent/IndColour/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndentColourTable();
        }
    });
}

function SubmitIndentColourForm() {
    var formData = new FormData($('#IndentColourForm')[0]);
    var url = $('#IndentColourForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndentColourModel').modal('hide');
                LoadIndentColourTable();
            } else {
                $('#IndentColourModel').html(data);
                $('#IndentColourModel').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

