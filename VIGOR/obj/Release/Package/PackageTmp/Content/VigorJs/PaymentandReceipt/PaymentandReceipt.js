$("#btnSearch").on('click',
    function () {
        PaymentandReceipt();
    });

function PaymentandReceipt() {
    var _frDate = $("#frDate").val();
    var _toDate = $("#toDate").val();
    var _glCode = $('#glCode :selected').val();
    var _depId = $('#depId :selected').val();
    var _locId = $('#LocId :selected').val();
    var _empId = $('#empId :selected').val();
    var _custId = $('#custId :selected').val();
    if (_frDate === '' || _toDate === '' || _glCode === '') {
        return;
    }
    DatatablesBasicPaginations.init();
    _glCode = "";
    $('#glCode option:selected').each(function () {

        _glCode += this.value + ",";

    });
   
    var url = "/GL/PaymentAndReceipt/PaymentAndReceiptCriteria";
    $.ajax({
        data: {
            frDateTime: _frDate, toDateTime: _toDate, glCode: _glCode, deptId: _depId, locId: _locId, empId: _empId, custId: _custId
        },
        type: "Get",
        url: url,
        success: function (data) {
            $("#PaymentandReceipt").html(data);
        }, error: function (data) {
        }
    });
}




var DatatablesBasicPaginations = {
    init: function () {
        $(".gl").DataTable({
            responsive: !0,
            pagingType: "full_numbers",
            columnDefs: [{
                targets: -1,
                title: "Actions",
                orderable: !1,
            }]
        });
    }
};
jQuery(document).ready(function () {

    // DatatablesBasicPaginations.init();
});