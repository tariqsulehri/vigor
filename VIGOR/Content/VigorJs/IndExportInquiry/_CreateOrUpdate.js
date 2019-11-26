
function ExportInquieryReview(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#ExportInquieryReviewModel').html(data);
            $('#ExportInquieryReviewModel').modal('show');
        }
    });
}
function EportInquieryAttechment(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndentLookUpModal').html(data);
            $('#IndentLookUpModal').modal('show');
        }
    });
}
// Abusafyan
// Open Parties Model For Add Dynamic Column in Grid By Party Selection
var AddDynamicColByPartySelection = function (url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#FinPartyModal').html(data);
            $('#FinPartyModal').modal('show');
        }
    });
};
// Abusafyan
// Insert record for IndExportInquiryReview and Update IndExportInquiryOffer is Finalized
function SubmitExportInquieryReview() {
    var formData = new FormData($('#IndExportInquiryReviewForm')[0]);
    var url = $('#IndExportInquiryReviewForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#ExportInquieryReviewModel').modal('hide');

            } else {
                $('#ExportInquieryReviewModel').html(data);
                $('#ExportInquieryReviewModel').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

function OpenContractForm(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#ExportInquieryContractModel').html(data);
            $('#ExportInquieryContractModel').modal('show');
        }
    });
}

