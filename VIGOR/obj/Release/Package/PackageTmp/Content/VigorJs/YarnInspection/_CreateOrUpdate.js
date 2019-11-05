function OpenAttachmentModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#AttachmentModal').html(data);
            $('#AttachmentModal').modal('show');
        }
    });
}

function SubmitYarnInspection() {
    var formData = new FormData($('#YarnInspectionForm')[0]);
    var url = $('#YarnInspectionForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#AttachmentModal').modal('hide');

            } else {
                $('#AttachmentModal').html(data);
                $('#AttachmentModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}
function SubmitAttechmentFile() {
    var formData = new FormData($('#AttachmentsForm')[0]);
    var url = $('#AttachmentsForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#AttachmentModal').modal('hide');

            } else {
                $('#AttachmentModal').html(data);
                $('#AttachmentModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}