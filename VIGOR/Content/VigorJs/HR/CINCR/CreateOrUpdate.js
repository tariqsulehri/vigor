
function OpenEmployeeCINCRModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeCINCRModal').html(data);
            $('#EmployeeCINCRModal').modal('show');
        }
    });
}
function OpenEmployeeCINCRCreateModal(url) {
    debugger;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeCINCRCreateModal').html(data);
            $('#EmployeeCINCRCreateModal').modal('show');
        }
    });
}
function SubmitCIForm() {
    var formData = new FormData($('#CIform')[0]);
    var url = $('#CIform').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeCINCRCreateModal').modal('hide');
                LoadCINCRTable();
            } else {
                $('#EmployeeCINCRCreateModal').html(data);
                $('#EmployeeCINCRCreateModal').modal('show');
                LoadCINCRTable();
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}
