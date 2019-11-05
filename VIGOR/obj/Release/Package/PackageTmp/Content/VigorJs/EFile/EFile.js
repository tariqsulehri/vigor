function SubmitEFile() {
    var formData = new FormData($('#Efilling')[0]);
    var url = $('#Efilling').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#FollowUpSheetModal').modal('hide');

            } else {
                $('#FollowUpSheetModal').html(data);
                $('#FollowUpSheetModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}