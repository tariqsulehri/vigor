function SelectionChanged() {
    var dropdown = document.getElementById('drop');
    var textbox = document.getElementById('customerName');
    textbox.value = dropdown.options[dropdown.selectedIndex].text;
}

$(document).ready(function () {
            GeneralInfo();
});
function OpenCustomerModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#CustomerModal').html(data);
            $('#CustomerModal').modal('show');
        }
    });
}

function GeneralInfo() {
    var url = "/General/Customer/GeneralInfo";
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $("#GeneralInfo").html(data);
        }, error: function (data) {

        }
    });    
}

var CustomerId = 0;
function DeleteCustomer(id) {
    debugger;
    CustomerId = id;
    var url = "/General/Customer/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadCustomerTable();
        }
    });
}
function DeleteCustomerConfirm() {
    $.ajax({
        type: "POST",
        url: "/Countries/Delete?id=" + CustomerId,
        success: function (data) {
            LoadCustomerTable();
            $('#DeleteCustomer').modal('hide');
        }
    });
}
function SubmitCustomerForm() {
    var formData = new FormData($('#CustomerForm')[0]);
    var url = $('#CustomerForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#CustomerModal').modal('hide');
                LoadCustomerTable();
            } else {
                $('#CustomerModal').html(data);
                $('#CustomerModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

