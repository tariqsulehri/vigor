$("#btnSearch").on('click', function () { TrailBalance(); });

function TrailBalance() {
    var _frDate = $("#frDate").val();
    var _toDate = $("#toDate").val();
    var levelofAccount = $('#levelofAccount option:selected').val();
   
    var zeroValue = false;
    if ($("#zerovalue").is(':checked')) {
        zeroValue = true;
    }
    if (_frDate === '' || _toDate === '') { return; }
    var url = "/GL/fnTrailBalance/TrailBalanceCriteria";
    $.ajax({
        data: {
            frDateTime: _frDate, toDateTime: _toDate, level: levelofAccount, includezero: zeroValue
        },
        type: "Get",
        url: url,
        success: function (data) {
            $("#GernalLedger").html(data);
        }, error: function (data) {
        }
    });
}
