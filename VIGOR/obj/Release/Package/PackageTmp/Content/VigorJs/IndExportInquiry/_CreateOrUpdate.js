
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
