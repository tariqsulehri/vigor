
function OpenIntimationModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IntimationModal').html(data);
            $('#IntimationModal').modal('show');
        }
    });
}
function OpenIntimationCreateModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IntimationCreateModal').html(data);
            $('#IntimationCreateModal').modal('show');
        }
    });
}


function SubmitIntimationForm() {
    var formData = new FormData($('#Intimationform')[0]);
    var url = $('#Intimationform').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IntimationModal').modal('hide');
                LoadEmpIntimationTable();
            } else {
                $('#IntimationModal').html(data);
                $('#IntimationModal').modal('show');
                LoadEmpIntimationTable();
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}