
function OpenEmployeeNCRModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeNCRModal').html(data);
            $('#EmployeeNCRModal').modal('show');
        }
    });
}
function OpenEmployeeNCRCreateModal(url) {
    debugger;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeNCRCreateModal').html(data);
            $('#EmployeeNCRCreateModal').modal('show');
        }
    });
}

function SubmitNCForm() {
    var formData = new FormData($('#NCform')[0]);
    var url = $('#NCform').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeNCRCreateModal').modal('hide');
                LoadNCRTable();
            } else {
                $('#EmployeeNCRCreateModal').html(data);
                $('#EmployeeNCRCreateModal').modal('show');
                LoadNCRTable();
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}