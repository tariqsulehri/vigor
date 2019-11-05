function OpenIndUnitOfMeasureModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndUnitOfMeasureModal').html(data);
            $('#IndUnitOfMeasureModal').modal('show');
        }
    });
}

function DeleteIndUnitOfMeasure() {
    alert("IndUnitOfMeasure Deleted");
    $('#DeleteIndUnitOfMeasure').modal('show');
}

var IndUnitOfMeasureId = 0;
function DeleteIndUnitOfMeasure(id) {
    IndUnitOfMeasureId = id;
    var url = "/Indent/IndUnitOfMeasure/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndUnitOfMeasureTable();
        }
    });
}
function DeleteIndUnitOfMeasureConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/IndUnitOfMeasure/Delete?id=" + IndUnitOfMeasureId,
        success: function (data) {
            LoadIndUnitOfMeasureTable();
            $('#DeleteIndUnitOfMeasure').modal('hide');
        }
    });
}
function SubmitIndUnitOfMeasureForm() {
    var formData = new FormData($('#IndUnitOfMeasureForm')[0]);
    var url = $('#IndUnitOfMeasureForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndUnitOfMeasureModal').modal('hide');
                LoadIndUnitOfMeasureTable();
            } else {
                $('#IndUnitOfMeasureModal').html(data);
                $('#IndUnitOfMeasureModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

