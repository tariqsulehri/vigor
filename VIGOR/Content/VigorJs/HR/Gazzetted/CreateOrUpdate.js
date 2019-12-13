
function OpenEmployeeGazzettedModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeGazzettedModal').html(data);
            $('#EmployeeGazzettedModal').modal('show');
        }
    });
}

function SubmitGazzettedDayForm() {
    var formData = new FormData($('#GazzettedDayForm')[0]);
    var url = $('#GazzettedDayForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeGazzettedModal').modal('hide');
                LoadGazzettedDayTable();
            } else {
                $('#EmployeeGazzettedModal').html(data);
                $('#EmployeeGazzettedModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}