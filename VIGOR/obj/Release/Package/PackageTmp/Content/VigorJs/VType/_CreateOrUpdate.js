
function OpenfnVTypeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#fnVTypeModal').html(data);
            $('#fnVTypeModal').modal('show');
        }
    });
}

function DeletefnVType() {
    alert("fnVType Deleted");
    $('#DeletefnVType').modal('show');
}

var fnVTypeId = 0;
function DeletefnVTypeModal(id) {
    fnVTypeId = id;

    $('#DeletefnVType').modal('show');
}
function DeletefnVTypeConfirm() {
    $.ajax({
        type: "POST",
        url: "/GL/fnVType/Delete?id=" + fnVTypeId,
        success: function (data) {
            LoadfnVTypeTable();
            $('#DeletefnVType').modal('hide');
        }
    });
}
function SubmitfnVTypeForm() {
    var formData = new FormData($('#fnVTypeForm')[0]);
    var url = $('#fnVTypeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#fnVTypeModal').modal('hide');
                LoadfnVTypeTable();
            } else {
                $('#fnVTypeModal').html(data);
                $('#fnVTypeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}