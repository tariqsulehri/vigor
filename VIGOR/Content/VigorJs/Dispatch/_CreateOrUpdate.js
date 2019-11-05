$(document).ready(function () {
           
});

function CommSelectionChanged() {
    var dropdown = document.getElementById('drop');
    var cartItems = [];

    $("#m_table_1 tbody tr").each(function () {
        var cartTableItemList = {
            UnitName: $('.UosID option:selected', this).text(),
            ID: $('.UosID option:selected', this).val(),
            Rate: $('.Rate', this).val(),
        }
        cartItems.push(cartTableItemList);
    });
    var textbox = document.getElementById('UoS');
    var UnitOsSaleID = document.getElementById('UnitOsSaleID');
    var Rate = document.getElementById('Rate');

    if (dropdown.selectedIndex > 0) {
        textbox.value =
            cartItems[dropdown.selectedIndex - 1].UnitName;
        UnitOsSaleID.value =
            cartItems[dropdown.selectedIndex - 1].ID;
        Rate.value =
            cartItems[dropdown.selectedIndex - 1].Rate;
    } else {
        textbox.value = "";
        UnitOsSaleID.value = "";
        Rate.value = "";
    }

}
function QuantityChanged() {
   
    var dropdown = document.getElementById('CommDrop');
    var cartItems = [];
    $("#m_table_1 tbody tr").each(function () {
        var cartTableItemList = {
            UoSID: $('.UosID option:selected', this).val(),
            UnitName: $('.Rate', this).val()
        }
        cartItems.push(cartTableItemList);
    });


    var UOS = cartItems[dropdown.selectedIndex - 1].UoSID;

    var quantity = document.getElementById('Quantity');
    var rate = cartItems[dropdown.selectedIndex - 1].UnitName;
    var amount = document.getElementById('Amount');
    var netAmount = document.getElementById('netAmount');
    var tax = document.getElementById('tax');
    var totalAmount = document.getElementById('totalAmount');
    var taxAmount = document.getElementById('taxAmount');

    $.ajax({
        type: "Get",
        url: '/Indent/CommonIndent/GetFactorUnitOfSale?unitID=' + UOS + '',
        success: function (data) {
            $.each(data,
                function(k, v) {
                    amount.value = v * quantity.value * rate;
                    document.getElementById('netAmount').value = amount.value;
                    //  $('input[name="det[a][TotalValue]"]').val(Number(v * quantity.value * amount.value).toFixed(2));
                });
        }
    });
}


function CalculatePayment() {
    var netAmount = document.getElementById('netAmount').value;
    var tax = document.getElementById('tax').value;
    var taxAmount = document.getElementById('taxAmount');
    taxAmount.value = netAmount * tax / 100;

    document.getElementById('totalAmount').value = netAmount - taxAmount.value;
}
function CalculateYarnPayment() {

    var Amount = document.getElementById('Amount').value;

    var netTotal = Number(Amount);

    var netAmount = document.getElementById('netAmount').value;
    var tax = document.getElementById('tax').value;
    var taxAmount = document.getElementById('taxAmount');

    var cartItems = [];

    $("#yarnTable tbody tr").each(function () {

        var cartTableItemList = {
            AddOn: $('.AddOnId option:selected', this).text(),
            AddOnType: $('.AddOnType option:selected', this).val(),
            AddOnEffect: $('.AddOnEffect option:selected', this).val(),
            AddOnAmmount: $('.AddOnAmmount', this).val()
        };
        cartItems.push(cartTableItemList);

        if (cartTableItemList.AddOn !== "Select") {
            if (cartTableItemList.AddOnType === "1") {
                $('.TotaValue', this).val(Amount * cartTableItemList.AddOnAmmount / 100);

                netTotal = netTotal+ Number(Amount * cartTableItemList.AddOnAmmount / 100);
            }
            else {
                $('.TotaValue', this).val(cartTableItemList.AddOnAmmount);
                netTotal = netTotal+ Number(cartTableItemList.AddOnAmmount);
            }
        }
    });

    document.getElementById('netAmount').value = netTotal;
    taxAmount.value = netTotal * tax / 100;

    document.getElementById('totalAmount').value = netTotal - taxAmount.value;
}