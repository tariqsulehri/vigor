function OpenEmployeeAllowanceModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeAllowanceModal').html(data);
            $('#EmployeeAllowanceModal').modal('show');
        }
    });
}
function SubmitAllowanceForm() {
    var formData = new FormData($('#AllowanceForm')[0]);
    var url = $('#AllowanceForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeAllowanceModal').modal('hide');
                LoadEmpAllowanceTable();
            } else {
                $('#EmployeeAllowanceModal').html(data);
                $('#AllowanceModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

