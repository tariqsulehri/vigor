function OpenCurrencyModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#CurrencyModal').html(data);
            $('#CurrencyModal').modal('show');
        }
    });
}

function DeleteCurrency() {
    alert("Currency Deleted");
    $('#DeleteCurrency').modal('show');
}

var CurrencyId = 0;
function DeleteCurrency(id) {
    CurrencyId = id;
    var url = "/Indent/Currency/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadCurrencyTable();
        }
    });
}
function DeleteCurrencyConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/Currency/Delete?id=" + CurrencyId,
        success: function (data) {
            LoadCurrencyTable();
            $('#DeleteCurrency').modal('hide');
        }
    });
}
function SubmitCurrencyForm() {
    var formData = new FormData($('#CurrencyForm')[0]);
    var url = $('#CurrencyForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#CurrencyModal').modal('hide');
                LoadCurrencyTable();
            } else {
                $('#CurrencyModal').html(data);
                $('#CurrencyModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

