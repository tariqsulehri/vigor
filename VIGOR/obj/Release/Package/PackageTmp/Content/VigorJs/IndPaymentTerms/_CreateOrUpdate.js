function OpenIndPaymentTermsModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndPaymentTermsModal').html(data);
            $('#IndPaymentTermsModal').modal('show');
        }
    });
}

function DeleteIndPaymentTerms() {
    alert("IndPaymentTerms Deleted");
    $('#DeleteIndPaymentTerms').modal('show');
}

var IndPaymentTermsId = 0;
function DeleteIndPaymentTerms(id) {
    IndPaymentTermsId = id;
    var url = "/Indent/IndPaymentTerms/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndPaymentTermsTable();
        }
    });
}
function DeleteIndPaymentTermsConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/IndPaymentTerms/Delete?id=" + IndPaymentTermsId,
        success: function (data) {
            LoadIndPaymentTermsTable();
            $('#DeleteIndPaymentTerms').modal('hide');
        }
    });
}
function SubmitIndPaymentTermsForm() {
    var formData = new FormData($('#IndPaymentTermsForm')[0]);
    var url = $('#IndPaymentTermsForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndPaymentTermsModal').modal('hide');
                LoadIndPaymentTermsTable();
            } else {
                $('#IndPaymentTermsModal').html(data);
                $('#IndPaymentTermsModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

