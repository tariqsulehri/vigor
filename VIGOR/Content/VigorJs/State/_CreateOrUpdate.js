
function OpenStateModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#StateModal').html(data);
            $('#StateModal').modal('show');
        }
    });
}

function DeleteState() {
    alert("State deleted");
    $('#DeleteState').modal('show');
}

var StateId = 0;
function DeleteState(id) {
    StateId = id;

    var url = "/General/State/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadStateTable();
        }
    });
}
function DeleteStateConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/State/Delete?id=" + StateId,
        success: function (data) {
            LoadStateTable();
            $('#DeleteState').modal('hide');
        }
    });
}
function SubmitStateForm() {
    var formData = new FormData($('#StateForm')[0]);
    var url = $('#StateForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#StateModal').modal('hide');
                LoadStateTable();
            } else {
                $('#StateModal').html(data);
                $('#StateModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

