
function OpenEmployeeLAdvApplicationModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#LAdvApplicationModal').html(data);
            $('#LAdvApplicationModal').modal('show');
        }
    });
}
function OpenEmployeeLAdvApplicationCreateModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#LAdvApplicationCreateModal').html(data);
            $('#LAdvApplicationCreateModal').modal('show');
        }
    });
}
function SubmitLAdvApplicationForm() {
    var formData = new FormData($('#LAdvApplicationform')[0]);
    var url = $('#LAdvApplicationform').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#LAdvApplicationCreateModal').modal('hide');
                LoadLoanAppTable();
            } else {
                $('#LAdvApplicationCreateModal').html(data);
                $('#LAdvApplicationCreateModal').modal('show');
                LoadLoanAppTable();
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}