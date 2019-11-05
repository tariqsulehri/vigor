
function OpenBusinessTypesModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#BusinessTypesModal').html(data);
            $('#BusinessTypesModal').modal('show');
        }
    });
}

function DeleteBusinessTypes() {
    alert("BusinessTypes Deleted");
    $('#DeleteBusinessTypes').modal('show');
}

var BusinessTypesId = 0;
function DeleteBusinessTypes(id) {
    BusinessTypesId = id;

    var url = "/General/BusinessTypes/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
                LoadBusinessTypesTable($("#BusinessTypesSwitch1").is(':checked'));
        }
    });
}
function DeleteBusinessTypesConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/BusinessTypes/Delete?id=" + BusinessTypesId,
        success: function (data) {
                LoadBusinessTypesTable($("#BusinessTypesSwitch1").is(':checked'));
            $('#DeleteBusinessTypes').modal('hide');
        }
    });
}
function SubmitBusinessTypesForm() {
    var formData = new FormData($('#BusinessTypesForm')[0]);
    var url = $('#BusinessTypesForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#BusinessTypesModal').modal('hide');
                LoadBusinessTypesTable($("#BusinessTypesSwitch1").is(':checked'));
            } else {
                $('#BusinessTypesModal').html(data);
                $('#BusinessTypesModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

