$(function () {
    $('#m_table_1').on('click', 'tbody tr', function (event) {
        $(this).addClass('highlight').siblings().removeClass('highlight');
    });
});
function YarnInspOperation(btnId) {
    var rows = getHighlightRow();
    var indentId = rows.attr('id');
    if (indentId != undefined) {
        if (indentId !== '') {
            if (btnId === "btnDispatch") {
                var url = '@Url.Action("Details", "Dispatch", new { Id = "_id", Area = "Indent"})';
                url = url.replace('_id', indentId);
                url = url.replace(/\amp;/g, '');
                window.open(url, '_blank');
            }
            else if (btnId == "btnAttachment") {
                var url = '@Url.Action("Attachment", "YarnInspection", new { Id = "_id", Area = "Indent"})';
                url = url.replace('_id', indentId);
                url = url.replace(/\amp;/g, '');
                OpenAttachmentModal(url);
            }
            else if (btnId == "btnEdit") {
                var url = '@Url.Action("Edit", "YarnInspection", new { Id = "_id", Area = "Indent"})';
                url = url.replace('_id', indentId);
                url = url.replace(/\amp;/g, '');
                OpenAttachmentModal(url);
            }
        }
    }
}
var getHighlightRow = function () {
    return $('table > tbody > tr.highlight');
}
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