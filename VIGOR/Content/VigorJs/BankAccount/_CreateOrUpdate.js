$(document).ready(function () {
            GeneralInfo();
});
function OpenBankAccountModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#BankAccountModal').html(data);
            $('#BankAccountModal').modal('show');
        }
    });
}

function GeneralInfo() {
    var url = "/General/BankAccount/GeneralInfo";
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $("#GeneralInfo").html(data);
        }, error: function (data) {

        }
    });    
}

var BankAccountId = 0;
function DeleteBankAccountModal(id) {
    BankAccountId = id;
    $('#DeleteBankAccount').modal('show');
}
function DeleteBankAccountConfirm() {
    $.ajax({
        type: "POST",
        url: "/Countries/Delete?id=" + BankAccountId,
        success: function (data) {
            LoadBankAccountTable();
            $('#DeleteBankAccount').modal('hide');
        }
    });
}
function SubmitBankAccountForm() {
    var formData = new FormData($('#BankAccountForm')[0]);
    var url = $('#BankAccountForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#BankAccountModal').modal('hide');
                LoadBankAccountTable();
            } else {
                $('#BankAccountModal').html(data);
                $('#BankAccountModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

