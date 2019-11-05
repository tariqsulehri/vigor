function OpenIndPriceTermsModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndPriceTermsModal').html(data);
            $('#IndPriceTermsModal').modal('show');
        }
    });
}

function DeleteIndPriceTerms() {
    alert("IndPriceTerms Deleted");
    $('#DeleteIndPriceTerms').modal('show');
}

var IndPriceTermsId = 0;
function DeleteIndPriceTerms(id) {
    IndPriceTermsId = id;
    var url = "/Indent/IndPriceTerms/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndPriceTermsTable();
        }
    });
}
function DeleteIndPriceTermsConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/IndPriceTerms/Delete?id=" + IndPriceTermsId,
        success: function (data) {
            LoadIndPriceTermsTable();
            $('#DeleteIndPriceTerms').modal('hide');
        }
    });
}
function SubmitIndPriceTermsForm() {
    var formData = new FormData($('#IndPriceTermsForm')[0]);
    var url = $('#IndPriceTermsForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndPriceTermsModal').modal('hide');
                LoadIndPriceTermsTable();
            } else {
                $('#IndPriceTermsModal').html(data);
                $('#IndPriceTermsModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

