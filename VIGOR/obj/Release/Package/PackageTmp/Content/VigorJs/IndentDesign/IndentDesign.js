$(function () {
    LoadIndentDesignTable();
});
var LoadIndentDesignTable = function () {
    var url = "/Indent/IndentDesign/GetIndDesign";
    var table = $('#IndentDesignTable').DataTable({
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
            { "data": "Symbol", "orderable": true },
            { "data": "Title", "orderable": true }
          

        ],
        columnDefs: [
            {
                "targets": 3,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/Indent/IndentDesign/Edit/";

                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenIndentDesignModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndentDesign(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
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

function OpenIndentDesignModal(url) {

    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndentDesignModel').html(data);
            $('#IndentDesignModel').modal('show');
        }
    });
}

function DeleteIndentDesign(id) {

    var url = "/Indent/IndentDesign/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndentDesignTable();
        }
    });
}

function SubmitIndentDesignForm() {
    var formData = new FormData($('#IndentDesignForm')[0]);
    var url = $('#IndentDesignForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndentDesignModel').modal('hide');
                LoadIndentDesignTable();
            } else {
                $('#IndentDesignModel').html(data);
                $('#IndentDesignModel').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

