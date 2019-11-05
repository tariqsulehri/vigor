function OpenFabricInspLoomTypeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#FabricInspLoomTypeModal').html(data);
            $('#FabricInspLoomTypeModal').modal('show');
        }
    });
}

function DeleteFabricInspLoomType() {
    alert("FabricInspLoomType Deleted");
    $('#DeleteFabricInspLoomType').modal('show');
}

var FabricInspLoomTypeId = 0;
function DeleteFabricInspLoomType(id) {
    FabricInspLoomTypeId = id;
    var url = "/Indent/FabricInspLoomType/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadFabricInspLoomTypeTable();
        }
    });
}
function DeleteFabricInspLoomTypeConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/FabricInspLoomType/Delete?id=" + FabricInspLoomTypeId,
        success: function (data) {
            LoadFabricInspLoomTypeTable();
            $('#DeleteFabricInspLoomType').modal('hide');
        }
    });
}
function SubmitFabricInspLoomTypeForm() {
    var formData = new FormData($('#FabricInspLoomTypeForm')[0]);
    var url = $('#FabricInspLoomTypeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#FabricInspLoomTypeModal').modal('hide');
                LoadFabricInspLoomTypeTable();
            } else {
                $('#FabricInspLoomTypeModal').html(data);
                $('#FabricInspLoomTypeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

