
function OpenEmployeeDegreeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeDegreeModal').html(data);
            $('#EmployeeDegreeModal').modal('show');
        }
    });
}

function SubmitPositionForm() {
    var formData = new FormData($('#PositionForm')[0]);
    var url = $('#PositionForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeDegreeModal').modal('hide');
                LoadEmpPositionTable();
            } else {
                $('#EmployeeDegreeModal').html(data);
                $('#EmployeeDegreeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}