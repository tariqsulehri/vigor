
function OpenTransferModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeModal').html(data);
            $('#EmployeeModal').modal('show');
        }
    });
}
function SubmitTransforForm() {
    var formData = new FormData($('#TransferForm')[0]);
    var url = $('#TransferForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeModal').modal('hide');
                LoadEmpIntimationTable();
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