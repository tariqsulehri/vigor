
function OpenMachineryModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#MachineryModal').html(data);
            $('#MachineryModal').modal('show');
        }
    });
}

function DeleteMachinery() {
    alert("Machinery Deleted");
    $('#DeleteMachinery').modal('show');
}

var MachineryId = 0;
function DeleteMachinery(id) {
    MachineryId = id;

    var url = "/General/Machinery/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadMachineryTable();
        }
    });
}
function DeleteMachineryConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Machinery/Delete?id=" + MachineryId,
        success: function (data) {
            LoadMachineryTable();
            $('#DeleteMachinery').modal('hide');
        }
    });
}
function SubmitMachineryForm() {
    var formData = new FormData($('#MachineryForm')[0]);
    var url = $('#MachineryForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#MachineryModal').modal('hide');
                LoadMachineryTable();
            } else {
                $('#MachineryModal').html(data);
                $('#MachineryModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

