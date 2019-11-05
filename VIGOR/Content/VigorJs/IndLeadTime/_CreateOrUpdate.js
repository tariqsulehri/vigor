function OpenIndLeadTimeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndLeadTimeModal').html(data);
            $('#IndLeadTimeModal').modal('show');
        }
    });
}

function DeleteIndLeadTime() {
    alert("IndLeadTime Deleted");
    $('#DeleteIndLeadTime').modal('show');
}

var IndLeadTimeId = 0;
function DeleteIndLeadTime(id) {
    IndLeadTimeId = id;
    var url = "/Indent/IndLeadTime/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndLeadTimeTable();
        }
    });
}
function DeleteIndLeadTimeConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/IndLeadTime/Delete?id=" + IndLeadTimeId,
        success: function (data) {
            LoadIndLeadTimeTable();
            $('#DeleteIndLeadTime').modal('hide');
        }
    });
}
function SubmitIndLeadTimeForm() {
    var formData = new FormData($('#IndLeadTimeForm')[0]);
    var url = $('#IndLeadTimeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndLeadTimeModal').modal('hide');
                LoadIndLeadTimeTable();
            } else {
                $('#IndLeadTimeModal').html(data);
                $('#IndLeadTimeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

