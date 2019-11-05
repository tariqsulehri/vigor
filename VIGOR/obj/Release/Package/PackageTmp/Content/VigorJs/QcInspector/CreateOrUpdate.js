
function OpenQcInspectorModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#QcInspectorModal').html(data);
            $('#QcInspectorModal').modal('show');
        }
    });
}
function SubmitQCIForm() {
     var formData = new FormData($('#QCForm')[0]);
     var url = $('#QCForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#QcInspectorModal').modal('hide');
                LoadQCTable();
            } else {
                $('#QcInspectorModal').html(data);
                $('#QcInspectorModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}
