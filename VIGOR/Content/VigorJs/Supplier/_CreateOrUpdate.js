$(document).ready(function () {
            GeneralInfo();
});
function OpenSupplier(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#Supplier').html(data);
            $('#Supplier').modal('show');
        }
    });
}

function GeneralInfo() {
    var url = "/General/Supplier/GeneralInfo";
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $("#GeneralInfo").html(data);
        }, error: function (data) {

        }
    });    
}

var SupplierId = 0;
function DeleteSupplier(id) {
    SupplierId = id;
    $('#DeleteSupplier').modal('show');
}
function DeleteSupplierConfirm() {
    $.ajax({
        type: "POST",
        url: "/Countries/Delete?id=" + SupplierId,
        success: function (data) {
            LoadSupplierTable();
            $('#DeleteSupplier').modal('hide');
        }
    });
}
function SubmitSupplierForm() {
    var formData = new FormData($('#SupplierForm')[0]);
    var url = $('#SupplierForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#Supplier').modal('hide');
                LoadSupplierTable();
            } else {
                $('#Supplier').html(data);
                $('#Supplier').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

