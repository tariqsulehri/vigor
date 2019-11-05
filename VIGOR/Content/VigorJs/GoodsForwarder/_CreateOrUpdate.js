function OpenGoodsForwarderModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#GoodsForwarderModal').html(data);
            $('#GoodsForwarderModal').modal('show');
        }
    });
}

function DeleteGoodsForwarder() {
    alert("GoodsForwarder Deleted");
    $('#DeleteGoodsForwarder').modal('show');
}

var GoodsForwarderId = 0;
function DeleteGoodsForwarder(id) {
    GoodsForwarderId = id;
    var url = "/Indent/GoodsForwarder/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadGoodsForwarderTable();
        }
    });
}
function DeleteGoodsForwarderConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/GoodsForwarder/Delete?id=" + GoodsForwarderId,
        success: function (data) {
            LoadGoodsForwarderTable();
            $('#DeleteGoodsForwarder').modal('hide');
        }
    });
}
function SubmitGoodsForwarderForm() {
    var formData = new FormData($('#GoodsForwarderForm')[0]);
    var url = $('#GoodsForwarderForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#GoodsForwarderModal').modal('hide');
                LoadGoodsForwarderTable();
            } else {
                $('#GoodsForwarderModal').html(data);
                $('#GoodsForwarderModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

