$(function () {
    LoadIndentSizeGroupTable();
});
var LoadIndentSizeGroupTable = function () {
    var url = "/Indent/IndentSizeGroup/GetIndentSizeGroup";
    var table = $('#IndentSizeGroupTable').DataTable({
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
                    var formateurl = "/Indent/IndentSizeGroup/Edit/";
                  
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenIndentSizeGroupModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndentSizeGroup(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
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

function OpenIndentSizeGroupModal(url) {
    
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndentSizeGroupModel').html(data);
            $('#IndentSizeGroupModel').modal('show');
        }
    });
}

function DeleteIndentSizeGroup(id) {
  
    var url = "/Indent/IndentSizeGroup/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndentSizeGroupTable();
        }
    });
}

function SubmitIndentSizeGroupForm() {
    var formData = new FormData($('#IndentSizeGroupForm')[0]);
    var url = $('#IndentSizeGroupForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndentSizeGroupModel').modal('hide');
                LoadIndentSizeGroupTable();
            } else {
                $('#IndentSizeGroupModel').html(data);
                $('#IndentSizeGroupModel').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

