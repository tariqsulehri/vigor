function OpenUnitOfSaleModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#UnitOfSaleModal').html(data);
            $('#UnitOfSaleModal').modal('show');
        }
    });
}

function DeleteUnitOfSale() {
    alert("UnitOfSale Deleted");
    $('#DeleteUnitOfSale').modal('show');
}

var UnitOfSaleId = 0;
function DeleteUnitOfSale(id) {
    UnitOfSaleId = id;
    var url = "/Indent/UnitOfSale/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadUnitOfSaleTable();
        }
    });
}
function DeleteUnitOfSaleConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/UnitOfSale/Delete?id=" + UnitOfSaleId,
        success: function (data) {
            LoadUnitOfSaleTable();
            $('#DeleteUnitOfSale').modal('hide');
        }
    });
}
function SubmitUnitOfSaleForm() {
    var formData = new FormData($('#UnitOfSaleForm')[0]);
    var url = $('#UnitOfSaleForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#UnitOfSaleModal').modal('hide');
                LoadUnitOfSaleTable();
            } else {
                $('#UnitOfSaleModal').html(data);
                $('#UnitOfSaleModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

