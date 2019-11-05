$(function () {
    LoadUnitRateTable();
});
var LoadUnitRateTable = function () {
    var url = "/Indent/UnitOfRate/GetIndUnitOfRate";
    var table = $('#IndUnitOfRateTable').DataTable({
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
            { "data": "Title", "orderable": true }


        ],
        columnDefs: [
            {
                "targets": 2,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/Indent/UnitOfRate/Edit/";

                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="IndUnitOfRateModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteUnitRate(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
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

function IndUnitOfRateModal(url) {

    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndUnitOfRateModal').html(data);
            $('#IndUnitOfRateModal').modal('show');
        }
    });
}

function DeleteUnitRate(id) {

    var url = "/Indent/UnitOfRate/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadUnitRateTable();
        }
    });
}

function SubmitUnitRateForm() {
    var formData = new FormData($('#IndUnitOfRateForm')[0]);
    var url = $('#IndUnitOfRateForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndUnitOfRateModal').modal('hide');
                LoadUnitRateTable();
            } else {
                $('#IndUnitOfRateModal').html(data);
                $('#IndUnitOfRateModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

