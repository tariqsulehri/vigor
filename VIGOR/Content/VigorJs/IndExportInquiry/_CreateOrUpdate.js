
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
// Set Party Name in Header and Append Textbox when select Party
var Counter = 0;
var SelectPartySetInGrid = function (ele) {
    Counter = Counter + 1;
    var foundPartyIdAttr = $(ele).attr('id');
    var partyTitle = $('#' + foundPartyIdAttr).children().eq(0).text();
    $('#FinPartyModal').modal('hide');
    $('.ExportInquiryTable').find('tr').each(function () {

        $(this).find('th').eq(-2).after('<th>' + partyTitle + '</th>');
        $(this).find('td').eq(-2).after('<td><input type="number" name="det[0][OfferAmount' + Counter + ']" class="form-control"><input type="hidden" name="det[0][OfferCustomerId' + Counter + ']" value="' + foundPartyIdAttr + '"></td>');
        $('.summary').children().eq(-2).html(' ');
    });
};
