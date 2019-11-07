
function OpenEmployeeTypeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeTypeModal').html(data);
            $('#EmployeeTypeModal').modal('show');
        }
    });
}

function SubmitEmpTypeForm() {
    var formData = new FormData($('#EmployeeTypeForm')[0]);
    var url = $('#EmployeeTypeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeTypeModal').modal('hide');
                LoadEmpTypeTable();
            } else {
                $('#EmployeeTypeModal').html(data);
                $('#EmployeeTypeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}