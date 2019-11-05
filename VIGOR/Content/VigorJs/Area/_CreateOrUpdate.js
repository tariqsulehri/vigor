
function OpenAreaModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#AreaModal').html(data);
            $('#AreaModal').modal('show');
        }
    });
}

function DeleteArea() {
    alert("Area Deleted");
    $('#DeleteArea').modal('show');
}

var AreaId = 0;
function DeleteAreaModal(id) {
    AreaId = id;

    $('#DeleteArea').modal('show');
}
function DeleteAreaConfirm() {
    $.ajax({
        type: "POST",
        url: "/Countries/Delete?id=" + AreaId,
        success: function (data) {
            LoadAreasTable();
            $('#DeleteArea').modal('hide');
        }
    });
}
function SubmitAreaForm() {
    var formData = new FormData($('#AreaForm')[0]);
    var url = $('#AreaForm').attr('action')
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data == null || data == undefined || data == '') {
                $('#AreaModal').modal('hide');
                LoadAreasTable();
            } else {
                $('#AreaModal').html(data);
                $('#AreaModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false,
    });
}

