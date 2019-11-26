
function OpenIncrementModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IncreamentModal').html(data);
            $('#IncreamentModal').modal('show');
        }
    });
}

function SubmitIntimationForm() {
    var formData = new FormData($('#IncrementForm')[0]);
    var url = $('#IncrementForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IncreamentModal').modal('hide');
            } else {
                $('#IncreamentModal').html(data);
                $('#IncreamentModal').modal('show');
                LoadEmpIntimationTable();
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}




$(document).ready(function () {

    $(".SI_GrandType").change(function () {
        SumOfTotalPrices();
    });



    $("#nsBasicSalary").change(function () {
        if (!($('#nsBasicSalary').val() != '' && (parseInt($('#nsBasicSalary').val()) || 0)) && !($('#nsTotalAllowance').val() != '' && (parseInt($('#TotalEmpAllowance').val()) || 0))) {
            isValid = false;
        } else {
            var getTotal = (parseInt($('#nsBasicSalary').val()) + (parseFloat($('#nsTotalAllowance').val())));
            $('#nsGrossSalary').val(getTotal);
        }
    });



});

function SumOfTotalPrices() {

    var totalAmount = parseFloat(0);
    var grossTotal = parseFloat(0);
    var totalSubAmount = parseFloat(0);

    var lineTotalArray = $('.SI_GrandTotal').map(function () {
        return this.value;
    }).get();
    var lineTotalArray1 = $('.SI_GrandType').map(function () {
        return this.value;
    }).get();
    var i = parseInt(0);
    for (i = 0; i < lineTotalArray.length; i++) {
        var singlePrice = parseFloat(lineTotalArray[i]);
        var signleType = parseFloat(lineTotalArray1[i]);
        if (!isNaN(singlePrice) || !isNaN(signleType)) {

            if (signleType == 'f') {
                totalAmount = totalAmount + singlePrice;
            } else {
                if (!($('#nsBasicSalary').val() != '') && (parseInt($('#nsBasicSalary').val()))) {
                    alert("Enter Basic Sallary First");
                } else {
                    var nsBasic = $('#nsBasicSalary').val();
                    totalAmount = totalAmount + (nsBasic * singlePrice) / 100;
                }

            }

        }
    }
    grossTotal = totalAmount;
    $("#nsTotalAllowance").val(totalAmount);
    
}