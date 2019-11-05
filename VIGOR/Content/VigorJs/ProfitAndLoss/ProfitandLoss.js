$("#btnSearch").on('click', function () { ProfitandLoss(); });
function ProfitandLoss() {
    var _frDate = $("#frDate").val();
    var _toDate = $("#toDate").val();
    var _glCode = $('#glCode :selected').val();
    var _depId = $('#depId :selected').val();
    var _locId = $('#LocId :selected').val();
    var _empId = $('#empId :selected').val();
    var _custId = $('#custId :selected').val();
    if (_frDate === '' || _toDate === '') { return; }
    var url = "/GL/fnProfitAndLoss/ProfitandLossCriteria";
    $.ajax({
        data: {
            frDateTime: _frDate, toDateTime: _toDate, glCode: _glCode, deptId: _depId, locId: _locId, empId: _empId, custId: _custId
        },
        type: "Get",
        url: url,
        success: function (data) {
            $("#ProfitandLoss").html(data);
        }, error: function (data) {
        }
    });
}
