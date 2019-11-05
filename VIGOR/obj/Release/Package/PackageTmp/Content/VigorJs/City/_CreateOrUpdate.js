
function OpenCityModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#CityModal').html(data);
            $('#CityModal').modal('show');
        }
    });
}

function DeleteCity() {
    alert("City Deleted");
    $('#DeleteCity').modal('show');
}

var CityId = 0;
function DeleteCity(id) {
    CityId = id;
    var url = "/General/City/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadCityTable();
        }
    });
}
function DeleteCityConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/City/Delete?id=" + CityId,
        success: function (data) {
            LoadCityTable();
            $('#DeleteCity').modal('hide');
        }
    });
}
function SubmitCityForm() {
    var formData = new FormData($('#CityForm')[0]);
    var url = $('#CityForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#CityModal').modal('hide');
                LoadCityTable();
            } else {
                $('#CityModal').html(data);
                $('#CityModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

