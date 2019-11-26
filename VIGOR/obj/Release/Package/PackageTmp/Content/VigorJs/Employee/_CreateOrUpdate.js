function OpenEmployeeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeModal').html(data);
            $('#EmployeeModal').modal('show');
        }
    });
}

function OpenEmployeeEfileModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeModal').html(data);
            $('#EmployeeModal').modal('show');
        }
    });
}
function OpenEmployeeDegreeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#EmployeeDegreeModal').html(data);
            $('#EmployeeDegreeModal').modal('show');
        }
    });
}
function AttenDanceSheetModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#AttenDanceModal').html(data);
            $('#AttenDanceModal').modal('show');
        }
    });
}
function DeleteEmployee() {
    alert("Employee Deleted");
    $('#DeleteEmployee').modal('show');
}

var EmployeeId = 0;
function DeleteEmployeeModal(id) {
    EmployeeId = id;

    $('#DeleteEmployee').modal('show');
}
function DeleteEmployeeConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Employee/Delete?id=" + EmployeeId,
        success: function (data) {
            LoadEmployeeTable();
            $('#DeleteEmployee').modal('hide');
        }
    });
}
function SubmitEmployeeForm() {
    var formData = new FormData($('#EmployeeForm')[0]);
    var url = $('#EmployeeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#EmployeeModal').modal('hide');
                LoadEmployeeTable();
            } else {
                $('#EmployeeModal').html(data);
                $('#EmployeeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}
$(document).ready(function () {

    $("#AllowanceAmount").change(function () {
        SumOfTotalPrices();
    });



    $("#BasicSalary").change(function () {
        if (!($('#BasicSalary').val() != '' && (parseInt($('#BasicSalary').val()) || 0)) && !($('#TotalEmpAllowance').val() != '' && (parseInt($('#TotalEmpAllowance').val()) || 0))) {
            isValid = false;
        } else {
            var getTotal = (parseInt($('#BasicSalary').val()) + (parseFloat($('#TotalEmpAllowance').val())));
            $('#GrossSalary').val(getTotal);
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
    //var lineDiscTotalArray = $('.PUR_DIS').map(function () {
    //    return this.value;
    //}).get();
    var i = parseInt(0);
    for (i = 0; i < lineTotalArray.length; i++) {
        var singlePrice = parseFloat(lineTotalArray[i]);
        if (!isNaN(singlePrice)) {
            totalAmount = totalAmount + singlePrice;
        }
    }
    grossTotal = totalAmount;
    $("#TotalEmpAllowance").val(grossTotal);

    //calculateValue();
    //getAgentAmount();
    //var j = parseInt(0);
    //totalAmount = 0;
    //grossTotal = 0;
    //for (j = 0; j < lineDiscTotalArray.length; j++) {
    //    var singlePrice = parseFloat(lineDiscTotalArray[j]);
    //    totalAmount = totalAmount + singlePrice;
    //}
    //grossTotal = totalAmount;
    //$("#TDiscount").val(grossTotal);

}