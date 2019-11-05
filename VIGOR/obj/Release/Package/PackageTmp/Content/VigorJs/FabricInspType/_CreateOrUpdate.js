function OpenFabricInspTypeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#FabricInspTypeModal').html(data);
            $('#FabricInspTypeModal').modal('show');
        }
    });
}

function DeleteFabricInspType() {
    alert("FabricInspType Deleted");
    $('#DeleteFabricInspType').modal('show');
}

var FabricInspTypeId = 0;
function DeleteFabricInspType(id) {
    FabricInspTypeId = id;
    var url = "/Indent/FabricInspType/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadFabricInspTypeTable();
        }
    });
}
function DeleteFabricInspTypeConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/FabricInspType/Delete?id=" + FabricInspTypeId,
        success: function (data) {
            LoadFabricInspTypeTable();
            $('#DeleteFabricInspType').modal('hide');
        }
    });
}
function SubmitFabricInspTypeForm() {
    var formData = new FormData($('#FabricInspTypeForm')[0]);
    var url = $('#FabricInspTypeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#FabricInspTypeModal').modal('hide');
                LoadFabricInspTypeTable();
            } else {
                $('#FabricInspTypeModal').html(data);
                $('#FabricInspTypeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

