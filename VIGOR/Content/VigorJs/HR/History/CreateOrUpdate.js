
function OpenEmployeeHistoryModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeHistoryModal').html(data);
            $('#EmployeeHistoryModal').modal('show');
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
                LoadLoanApprovalTable();
                LoadLoanAppTable();
            } else {
                $('#LAdvApplicationCreateModal').html(data);
                $('#LAdvApplicationCreateModal').modal('show');
                LoadLoanApprovalTable();
                LoadLoanAppTable();
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}


