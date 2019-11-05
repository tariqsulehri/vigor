
function OpenGroupModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#GroupModal').html(data);
            $('#GroupModal').modal('show');
        }
    });
}

function DeleteGroup() {
    alert("Group Deleted");
    $('#DeleteGroup').modal('show');
}

var GroupId = 0;
function DeleteGroupModal(id) {
    GroupId = id;

    $('#DeleteGroup').modal('show');
}
function DeleteGroupConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/Group/Delete?id=" + GroupId,
        success: function (data) {
            LoadGroupTable();
            $('#DeleteGroup').modal('hide');
        }
    });
}
function SubmitGroupForm() {
    var formData = new FormData($('#GroupForm')[0]);
    var url = $('#GroupForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#GroupModal').modal('hide');
                LoadGroupTable();
            } else {
                $('#GroupModal').html(data);
                $('#GroupModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}