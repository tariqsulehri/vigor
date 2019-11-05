function PostVoucher(url, vKey) {
   
    $.ajax({
        type: "get",
        url: url,
        data: { vKey: vKey},
        success: function(data) {
            location.reload(true);
        }, error: function(data) {
            location.reload(false);
        }
    })
}

function UnPostVoucher(url, vKey) {
    
    $.ajax({
        type: "get",
        url: url,
        data: { vKey: vKey },
        success: function (data) {
            location.reload(true);
        }, error: function (data) {
            location.reload(false);
        }
    })
}

function OpenReport(vKey) {
   
    var url ='/GL/fnGeneralLedger/VoucherPrint'
    $.ajax({
        type: "Get",
        url: url,
        data: { vKey: vKey},
        success: function (data) {
            $('#GLCOA').html(data);
            $('#GLCOA').modal('show');
        }
    });
}



