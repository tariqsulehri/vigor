function OpenProductModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#ProductModal').html(data);
            $('#ProductModal').modal('show');
        }
    });
}

function DeleteProduct() {
    alert("Product Deleted");
    $('#DeleteProduct').modal('show');
}

var ProductId = 0;
function DeleteProduct(id) {
    ProductId = id;
    var url = "/Indent/Product/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadProductTable();
        }
    });
}
function DeleteProductConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/Product/Delete?id=" + ProductId,
        success: function (data) {
            LoadProductTable();
            $('#DeleteProduct').modal('hide');
        }
    });
}
function SubmitProductForm() {
    var formData = new FormData($('#ProductForm')[0]);
    var url = $('#ProductForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#ProductModal').modal('hide');
                LoadProductTable();
            } else {
                $('#ProductModal').html(data);
                $('#ProductModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

