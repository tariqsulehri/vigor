
function GetProdects(comodityID)
{
    $("#Product").empty();
    $("#Product").append($("<option></option>"));
    $.ajax({
        type: "Get",
        url: "/CommonIndent/GetProductByCommodity",
        data: { comodityID: comodityID },
        success: function (data) {
            $("#Product").empty();
            $("#Product").append($("<option></option>"));
            $.each(data,
                function (key, value) {
                    $('#Product').append($("<option> </option>").val(value.Id).html(value.Title));
                });
        }
    });
}
function GetDealsInDepartment(comodityID, DealsInId) {
    
    $("#Dept").empty();
   // $("#Dept").append($("<option></option>"));
    $.ajax({
        type: "Get",
        url: "/CommonIndent/GetDealsinDepartment",//?comodityID=" + comodityID + "
        data: { comodityID: comodityID, DealsInId: DealsInId },
        success: function (data) {
            $("#Dept").empty();
           // $("#Dept").append($("<option></option>"));
            $.each(data,
                function (key, value) {
                    $('#Dept').append($("<option> </option>").val(value.Id).html(value.Title));
                });
        }
    });
   
}

$("#Dept").on('change', function () {
   
    var DeptID = $(this).val();
    GetAuthorisedDepatment(DeptID);
})
function GetAuthorisedDepatment(DeptID) {
    $.ajax({
        type: "Get",
        url: "/DepartmentDealsINCommodity/GetDealsinDepartment",
        data: { DeptID: DeptID},
        success: function (data) {
            $("#dealindept").html(data);
        }
    });
}