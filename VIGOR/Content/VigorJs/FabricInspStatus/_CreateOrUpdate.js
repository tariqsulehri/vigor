function OpenFabricInspStatusModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#FabricInspStatusModal').html(data);
            $('#FabricInspStatusModal').modal('show');
        }
    });
}

function DeleteFabricInspStatus() {
    alert("FabricInspStatus Deleted");
    $('#DeleteFabricInspStatus').modal('show');
}

var FabricInspStatusId = 0;
function DeleteFabricInspStatus(id) {
    FabricInspStatusId = id;
    var url = "/Indent/FabricInspStatus/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadFabricInspStatusTable();
        }
    });
}
function DeleteFabricInspStatusConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/FabricInspStatus/Delete?id=" + FabricInspStatusId,
        success: function (data) {
            LoadFabricInspStatusTable();
            $('#DeleteFabricInspStatus').modal('hide');
        }
    });
}
function SubmitFabricInspStatusForm() {
    var formData = new FormData($('#FabricInspStatusForm')[0]);
    var url = $('#FabricInspStatusForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#FabricInspStatusModal').modal('hide');
                LoadFabricInspStatusTable();
            } else {
                $('#FabricInspStatusModal').html(data);
                $('#FabricInspStatusModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

