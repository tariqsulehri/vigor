
function OpenSocialModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#SocialModal').html(data);
            $('#SocialModal').modal('show');
        }
    });
}

function DeleteSocial() {
    alert("Social Deleted");
    $('#DeleteSocial').modal('show');
}

var SocialId = 0;
function DeleteSocial(id) {
    SocialId = id;

    var url = "/General/Social/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadSocialTable();
        }
    });
}
function DeleteSocialConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Social/Delete?id=" + SocialId,
        success: function (data) {
            LoadSocialTable();
            $('#DeleteSocial').modal('hide');
        }
    });
}
function SubmitSocialForm() {
    var formData = new FormData($('#SocialForm')[0]);
    var url = $('#SocialForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#SocialModal').modal('hide');
                LoadSocialTable();
            } else {
                $('#SocialModal').html(data);
                $('#SocialModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

