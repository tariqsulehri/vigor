function OpenShipingLineModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#ShipingLineModal').html(data);
            $('#ShipingLineModal').modal('show');
        }
    });
}

function DeleteShipingLine() {
    alert("ShipingLine Deleted");
    $('#DeleteShipingLine').modal('show');
}

var ShipingLineId = 0;
function DeleteShipingLine(id) {
    ShipingLineId = id;
    var url = "/Indent/ShipingLine/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadShipingLineTable();
        }
    });
}
function DeleteShipingLineConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/ShipingLine/Delete?id=" + ShipingLineId,
        success: function (data) {
            LoadShipingLineTable();
            $('#DeleteShipingLine').modal('hide');
        }
    });
}
function SubmitShipingLineForm() {
    var formData = new FormData($('#ShipingLineForm')[0]);
    var url = $('#ShipingLineForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#ShipingLineModal').modal('hide');
                LoadShipingLineTable();
            } else {
                $('#ShipingLineModal').html(data);
                $('#ShipingLineModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

