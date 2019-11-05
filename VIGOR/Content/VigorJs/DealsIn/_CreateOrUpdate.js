
function OpenDealsInModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#DealsInModal').html(data);
            $('#DealsInModal').modal('show');
        }
    });
}

function DeleteDealsIn() {
    alert("DealsIn Deleted");
    $('#DeleteDealsIn').modal('show');
}

var DealsInId = 0;
function DeleteDealsInModal(id) {
    DealsInId = id;

    $('#DeleteDealsIn').modal('show');
}
function DeleteDealsInConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/DealsIn/Delete?id=" + DealsInId,
        success: function (data) {
            LoadDealsInTable();
            $('#DeleteDealsIn').modal('hide');
        }
    });
}
function SubmitDealsInForm() {
    var formData = new FormData($('#DealsInForm')[0]);
    var url = $('#DealsInForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#DealsInModal').modal('hide');
                LoadDealsInTable();
            } else {
                $('#DealsInModal').html(data);
                $('#DealsInModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}