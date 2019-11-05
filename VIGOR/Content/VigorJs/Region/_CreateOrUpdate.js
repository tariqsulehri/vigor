
function OpenRegionModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#RegionModal').html(data);
            $('#RegionModal').modal('show');
        }
    });
}
//function DelRegionModal(url) {
//    $.ajax({
//        type: "Get",
//        url: url,
//        success: function (data) {
//            $('#RegionModal').html(data);
//            $('#RegionModal').modal('show');
//        }
//    });
//}
function DeleteRegion() {
    alert("Region Deleted");
    $('#DeleteRegion').modal('show');
}

function DeleteRegion(id) {
    var url = "/General/Region/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadRegionTable();
        }
    });
}
function DeleteRegionConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Region/Delete?id=" + RegionId,
        success: function (data) {
            LoadRegionTable();
            $('#DeleteRegion').modal('hide');
        }
    });
}
function SubmitRegionForm() {
    var formData = new FormData($('#RegionForm')[0]);
    var url = $('#RegionForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#RegionModal').modal('hide');
                LoadRegionTable();
            } else {
                $('#RegionModal').html(data);
                $('#RegionModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}