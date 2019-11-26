
function OpenDegreeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#DegreeModal').html(data);
            $('#DegreeModal').modal('show');
        }
    });
}

function SubmitDegreeForm() {
    var formData = new FormData($('#DegreeForm')[0]);
    var url = $('#DegreeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#DegreeModal').modal('hide');
                LoadEmpIntimationTable();
            } else {
                $('#DegreeModal').html(data);
                $('#DegreeModal').modal('show');
                LoadDegreeTable();
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}