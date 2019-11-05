$(function () {
    var ComdID = $("#ComdID").val();
    GetDealsInDepartment(ComdID, 1);
});
function GetDealsInDepartment(comodityID, DealsInId) {
    $("#Dept").empty();
   // $("#Dept").append($("<option></option>"));
    $.ajax({
        type: "Get",
        url: "/CommonIndent/GetDealsinDepartment",//?comodityID=" + comodityID + "
        data: { comodityID: comodityID, DealsInId: DealsInId },
        success: function (data) {
            $("#Dept").empty();
          //  $("#Dept").append($("<option></option>"));
            $.each(data,
                function (key, value) {
                    $('#Dept').append($("<option> </option>").val(value.Id).html(value.Title));
                });
        }
    });
}
function OpenFollowUpSheetModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#FollowUpSheetModal').html(data);
            $('#FollowUpSheetModal').modal('show');
        }
    });
}

function OpenInspViewModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#InspViewModal').html(data);
            $('#InspViewModal').modal('show');
        }
    });
}