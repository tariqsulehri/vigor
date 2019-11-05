var clickCount = 0;
var timeoutID = 0;
function SingleOrDoubleclick() {
    clickCount++;

    if (clickCount >= 2) {
        clickCount = 0;          //reset clickCount
        clearTimeout(timeoutID); //stop the single click callback from being called
        alert("double clicked");   //perform your double click action
    }
    else if (clickCount == 1) {
        var callBack = function () {
            if (clickCount == 1) {
                clickCount = 0;         //reset the clickCount
                alert("single clicked");  //perform your single click action
            }
        };
        timeoutID = setTimeout(callBack, 500);
    }
}
function OpenBrandModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#BrandModal').html(data);
            $('#BrandModal').modal('show');
        }
    });
}

function DeleteBrand() {
    alert("Brand Deleted");
    $('#DeleteBrand').modal('show');
}

var BrandId = 0;
function DeleteBrand(id) {
    BrandId = id;
    var url = "/General/Brand/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadBrandTable();
        }
    });
}
function DeleteBrandConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Brand/Delete?id=" + BrandId,
        success: function (data) {
            LoadBrandTable();
            $('#DeleteBrand').modal('hide');
        }
    });
}
function SubmitBrandForm() {
    var formData = new FormData($('#BrandForm')[0]);
    var url = $('#BrandForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#BrandModal').modal('hide');
                LoadBrandTable();
            } else {
                $('#BrandModal').html(data);
                $('#BrandModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

