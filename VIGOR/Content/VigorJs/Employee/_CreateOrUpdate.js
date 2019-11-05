function OpenEmployeeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeModal').html(data);
            $('#EmployeeModal').modal('show');
        }
    });
}

function DeleteEmployee() {
    alert("Employee Deleted");
    $('#DeleteEmployee').modal('show');
}

var EmployeeId = 0;
function DeleteEmployee(id) {
    EmployeeId = id;

    var url = "/General/Employee/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadEmployeeTable();
        }
    });
}
function DeleteEmployeeConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Employee/Delete?id=" + EmployeeId,
        success: function (data) {
            LoadEmployeeTable();
            $('#DeleteEmployee').modal('hide');
        }
    });
}
function SubmitEmployeeForm() {
    var formData = new FormData($('#EmployeeForm')[0]);
    var url = $('#EmployeeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeModal').modal('hide');
                LoadEmployeeTable();
            } else {
                $('#EmployeeModal').html(data);
                $('#EmployeeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}