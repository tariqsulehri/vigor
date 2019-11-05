
$(function () {
    var ComdID = $("#ComdID").val();
    GetDealsInDepartment(ComdID, 1);
});
function GetDealsInDepartment(comodityID, DealsInId) {
    
    if (comodityID !== '') {
        $("#Dept").empty();
        $("#Dept").append($("<option></option>"));
        $.ajax({
            type: "Get",
            url: "/CommonIndent/GetDealsinDepartment", //?comodityID=" + comodityID + "
            data: { comodityID: comodityID, DealsInId: DealsInId },
            success: function(data) {
                //$("#Dept").empty();
                $("#Dept").append($("<option></option>"));
                $.each(data,
                    function(key, value) {
                        $('#Dept').append($("<option> </option>").val(value.Id).html(value.Title));
                    });
            }
        });
        
    }

}


function OpenInquieryReviewModal(url) {
   
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#ReviewModal').html(data);
            $('#ReviewModal').modal('show');
        }
    });
}
function SubmitInquieryReviewForm() {
    var formData = new FormData($('#IndPriceTermsForm')[0]);
    var url = $('#IndPriceTermsForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndPriceTermsModal').modal('hide');
                LoadIndPriceTermsTable();
            } else {
                $('#IndPriceTermsModal').html(data);
                $('#IndPriceTermsModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}