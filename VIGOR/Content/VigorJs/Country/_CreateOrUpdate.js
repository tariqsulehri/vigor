
function OpenCountryModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#CountryModal').html(data);
            $('#CountryModal').modal('show');
        }
    });
}

function DeleteCountry() {
    alert("Country Deleted");
    $('#DeleteCountry').modal('show');
}

var CountryId = 0;
function DeleteCountry(id) {
    CountryId = id;
    var url = "/General/Country/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadCountryTable();
        }
    });
}
function DeleteCountryConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Country/Delete?id=" + CountryId,
        success: function (data) {
            LoadCountryTable();
            $('#DeleteCountry').modal('hide');
        }
    });
}
function SubmitCountryForm() {
    debugger;
    var formData = new FormData($('#CountryForm')[0]);
    var url = $('#CountryForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#CountryModal').modal('hide');
                LoadCountryTable();
            } else {
                $('#CountryModal').html(data);
                $('#CountryModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

