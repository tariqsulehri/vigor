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
function OpenLocationsModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#LocationsModal').html(data);
            $('#LocationsModal').modal('show');
        }
    });
}

function DeleteLocations() {
    alert("Locations Deleted");
    $('#DeleteLocations').modal('show');
}

var LocationsId = 0;
function DeleteLocations(id) {
    LocationsId = id;
    var url = "/General/Locations/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadLocationsTable();
        }
    });
}
function DeleteLocationsConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Locations/Delete?id=" + LocationsId,
        success: function (data) {
            LoadLocationsTable();
            $('#DeleteLocations').modal('hide');
        }
    });
}
function SubmitLocationsForm() {
    var formData = new FormData($('#LocationsForm')[0]);
    var url = $('#LocationsForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#LocationsModal').modal('hide');
                LoadLocationsTable();
            } else {
                $('#LocationsModal').html(data);
                $('#LocationsModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

