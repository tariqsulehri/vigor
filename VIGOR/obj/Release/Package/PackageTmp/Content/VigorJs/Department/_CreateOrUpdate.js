
function OpenDepartmentModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#DepartmentModal').html(data);
            $('#DepartmentModal').modal('show');
        }
    });
}

function DeleteDepartment() {
    alert("Department Deleted");
    $('#DeleteDepartment').modal('show');
}

var DepartmentId = 0;
function DeleteDepartment(id) {
    DepartmentId = id;

    var url = "/General/Department/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadDepartmentTable();
        }
    });
}
function DeleteDepartmentConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Department/Delete?id=" + DepartmentId,
        success: function (data) {
            LoadDepartmentTable();
            $('#DeleteDepartment').modal('hide');
        }
    });
}
function SubmitDepartmentForm() {
    var formData = new FormData($('#DepartmentForm')[0]);
    var url = $('#DepartmentForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#DepartmentModal').modal('hide');
                LoadDepartmentTable();
            } else {
                $('#DepartmentModal').html(data);
                $('#DepartmentModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}