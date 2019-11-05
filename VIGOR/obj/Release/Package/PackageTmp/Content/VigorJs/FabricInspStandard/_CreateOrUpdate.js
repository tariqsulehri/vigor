function OpenFabricInspStandardModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#FabricInspStandardModal').html(data);
            $('#FabricInspStandardModal').modal('show');
        }
    });
}

function DeleteFabricInspStandard() {
    alert("FabricInspStandard Deleted");
    $('#DeleteFabricInspStandard').modal('show');
}

var FabricInspStandardId = 0;
function DeleteFabricInspStandard(id) {
    FabricInspStandardId = id;
    var url = "/Indent/FabricInspStandard/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadFabricInspStandardTable();
        }
    });
}
function DeleteFabricInspStandardConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/FabricInspStandard/Delete?id=" + FabricInspStandardId,
        success: function (data) {
            LoadFabricInspStandardTable();
            $('#DeleteFabricInspStandard').modal('hide');
        }
    });
}
function SubmitFabricInspStandardForm() {
    var formData = new FormData($('#FabricInspStandardForm')[0]);
    var url = $('#FabricInspStandardForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#FabricInspStandardModal').modal('hide');
                LoadFabricInspStandardTable();
            } else {
                $('#FabricInspStandardModal').html(data);
                $('#FabricInspStandardModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

