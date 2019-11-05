function OpenExchangeRatesModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#ExchangeRatesModal').html(data);
            $('#ExchangeRatesModal').modal('show');
        }
    });
}

function DeleteExchangeRates() {
    alert("ExchangeRates Deleted");
    $('#DeleteExchangeRates').modal('show');
}

var ExchangeRatesId = 0;
function DeleteExchangeRates(id) {
    ExchangeRatesId = id;
    var url = "/Indent/ExchangeRates/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadExchangeRatesTable();
        }
    });
}
function DeleteExchangeRatesConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/ExchangeRates/Delete?id=" + ExchangeRatesId,
        success: function (data) {
            LoadExchangeRatesTable();
            $('#DeleteExchangeRates').modal('hide');
        }
    });
}
function SubmitExchangeRatesForm() {
    var formData = new FormData($('#ExchangeRatesForm')[0]);
    var url = $('#ExchangeRatesForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#ExchangeRatesModal').modal('hide');
                LoadExchangeRatesTable();
            } else {
                $('#ExchangeRatesModal').html(data);
                $('#ExchangeRatesModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

