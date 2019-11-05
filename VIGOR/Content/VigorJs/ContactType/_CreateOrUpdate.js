
function OpenContactTypeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#ContactTypeModal').html(data);
            $('#ContactTypeModal').modal('show');
        }
    });
}

function DeleteContactType() {
    alert("ContactType Deleted");
    $('#DeleteContactType').modal('show');
}

var ContactTypeId = 0;
function DeleteContactType(id) {
    ContactTypeId = id;

    var url = "/General/ContactType/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadContactTypeTable();
        }
    });
}
function DeleteContactTypeConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/ContactType/Delete?id=" + ContactTypeId,
        success: function (data) {
            LoadContactTypeTable();
            $('#DeleteContactType').modal('hide');
        }
    });
}
function SubmitContactTypeForm() {
    var formData = new FormData($('#ContactTypeForm')[0]);
    var url = $('#ContactTypeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#ContactTypeModal').modal('hide');
                LoadContactTypeTable();
            } else {
                $('#ContactTypeModal').html(data);
                $('#ContactTypeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

