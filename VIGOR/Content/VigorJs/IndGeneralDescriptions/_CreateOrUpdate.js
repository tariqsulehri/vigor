function OpenIndGeneralDescriptionsModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndGeneralDescriptionsModal').html(data);
            $('#IndGeneralDescriptionsModal').modal('show');
        }
    });
}

function DeleteIndGeneralDescriptions() {
    alert("IndGeneralDescriptions Deleted");
    $('#DeleteIndGeneralDescriptions').modal('show');
}

var IndGeneralDescriptionsId = 0;
function DeleteIndGeneralDescriptions(id) {
    IndGeneralDescriptionsId = id;
    var url = "/Indent/IndGeneralDescriptions/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndGeneralDescriptionsTable();
        }
    });
}
function DeleteIndGeneralDescriptionsConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/IndGeneralDescriptions/Delete?id=" + IndGeneralDescriptionsId,
        success: function (data) {
            LoadIndGeneralDescriptionsTable();
            $('#DeleteIndGeneralDescriptions').modal('hide');
        }
    });
}
function SubmitIndGeneralDescriptionsForm() {
    var formData = new FormData($('#IndGeneralDescriptionsForm')[0]);
    var url = $('#IndGeneralDescriptionsForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndGeneralDescriptionsModal').modal('hide');
                LoadIndGeneralDescriptionsTable();
            } else {
                $('#IndGeneralDescriptionsModal').html(data);
                $('#IndGeneralDescriptionsModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}
var clickCount = 0;
var timeoutID = 0;
var name;
var uniqueName;
function IndGeneralDescriptionsList(tabename) {
    name = tabename;

    if (tabename.includes('CommoditySpecification'))
    {
        uniqueName = parseInt(name.match(/[0-9]+/)[0], 10);
    }
    else
    {
        uniqueName = -1;
    }

    clickCount++;
    if (clickCount >= 2) {
        clickCount = 0;
        clearTimeout(timeoutID);
        var url = '/Indent/IndGeneralDescriptions/LookUpIndGeneralDescriptions';
        $.ajax({
            type: "Get",
            url: url,
            success: function (data) {
                $('#IndGeneralDescriptionsModal').html(data);
                $('#IndGeneralDescriptionsModal').modal('show');
            }
        });
    } else if (clickCount === 1) {
        var callBack = function () {
            if (clickCount == 1) {
                clickCount = 0;

            }
        };

        timeoutID = setTimeout(callBack, 500);
    }
}

$("#VoucherTable").on('click', '.btnSelect', function () {
    debugger;
    var currentRow = $(this).closest("tr");
   
    var col2 = currentRow.find("td:eq(0)").text();
    var Existingvalue = $('#' + name + '').text();
    if (uniqueName !== -1)
    {
        var ExistingVal = $('input[name="det[' + uniqueName + '][CommoditySpecification]"]').val();
        $('input[name="det[' + uniqueName + '][CommoditySpecification]"]').val(ExistingVal + ' ' + col2);
    }
    else if (Existingvalue === '' || null) {
        $('#' + name + '').append(col2);
    } else {
        $('#' + name + '').append('\n' + col2);
    }
    
    $('#IndGeneralDescriptionsModal').modal('hide');
});
