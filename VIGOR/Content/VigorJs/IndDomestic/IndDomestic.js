$(document).on('keyup', '.comRate', function (e) {

    //var Amount = 0;
    //var Quantity = parseFloat($(this).closest('tr').find('.DPO_QTY').val());
    //var InvoiceRate = parseFloat($(this).closest('tr').find('.InvoiceRate').val());
    //var ConvertedRate = parseFloat($('.Converted_PR').val());
    //var Rate = parseFloat(InvoiceRate * ConvertedRate)/*parseFloat($(this).closest('tr').find('.DPO_RATE').val());*/
    //if (!isNaN(Quantity) && !isNaN(Rate)) {
    //    Amount = Quantity * Rate;
    //    $(this).closest('tr').find('.DPO_RATE').val(Rate.toFixed(2));
    //    $(this).closest('tr').find('.DPO_AMT').val(Amount.toFixed(2));
    //    getExpenseTotal();
    //} else {
    //    $(this).closest('tr').find('.DPO_AMT').val("");
    //    getExpenseTotal();
    //}

});

function calculateComission(name) {

    var uniqueName = parseInt(name.match(/[0-9]+/)[0], 10);
    var comissionRate = $('input[name="det[' + uniqueName + '][CommissionRate]"]').val();
    var comtypeValue = $('select[name="det[' + uniqueName + '][CommissionType]"]').find(':selected').val();
    var UOS = $('select[name="det[' + uniqueName + '][UosID]"]').find(':selected').val();
    var Qty = $('input[name="det[' + uniqueName + '][Quantity]"]').val();
    var Rate = $('input[name="det[' + uniqueName + '][Rate]"]').val();

    $.ajax({
        type: "Get",
        url: '/Indent/CommonIndent/GetFactorUnitOfSale?unitID=' + UOS + '',
        success: function (data) {
            $.each(data, function (k, v) {
                $('input[name="det[' + uniqueName + '][TotalValue]"]').val(Number(v * Qty * Rate).toFixed(2));
            })
        }
    });


    var totalcomission = 0;
    if (comtypeValue === "0") {
        totalcomission = Qty * comissionRate;
        $('input[name="det[' + uniqueName + '][CalculatedCommissionValue]"]').val(Number(totalcomission).toFixed(2));
    } else {
        totalcomission = (comissionRate * Qty * Rate) / 100;
        $('input[name="det[' + uniqueName + '][CalculatedCommissionValue]"]').val(Number(totalcomission).toFixed(2));
    }
    $("#CommBalance").val(Number(totalcomission).toFixed(2));
};


function Dispatch(parameters) {
    var SalerID = $("#seller").val();
    var url = '/Customer/CustomerDispatch';
    $.ajax({
        type: "Get",
        url: url,
        data: { SalerID: SalerID },
        success: function (data) {
            $('#' + parameters + '').append('\n' + data);
        }
    });
}

function SendToForApprovel(url) {
    var title = "Are you sure you want to send for approvel ?";
    ApprovelOperation(url, title);
}

function Approved(url) {
    var title = "Are you sure you want to send for Approved ?";
    ApprovelOperation(url, title);
}
function ApprovelOperation(url, title) {
    swal({
        title: title,
        text: "",
        icon: "success",
        confirmButtonText: "<a href='javascript:' style='color:white' id='sendForApprovel'><i class='fa fa-flag'></i>Send</a>",
        confirmButtonClass: "btn btn-danger m-btn m-btn--pill m-btn--air m-btn--icon",
        showCancelButton: !0,
        cancelButtonText: " <a href='javascript:'  style='color:black' id='dtview'><i class='flaticon-cancel'></i> CANCEL</a>",
        cancelButtonClass: "btn btn-secondary m-btn m-btn--pill m-btn--icon"
    });
    $('#sendForApprovel').click(function (e) {
        $.ajax({
            url: url,
            type: "get"
        }).done(function (data) {
            sweetAlert
                ({
                    title: "Status of Contract !",
                    text: data,
                    type: "success"
                },
                function () {

                });
        })
            .error(function (data) {
                swal("Oops", "We couldn't connect to the server!", "error");
            });
    });
}
function Print(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndGeneralDescriptionsModal').html(data);
            $('#IndGeneralDescriptionsModal').modal('show');
        }
    });
}
function OK(url) {
    $('#IndGeneralDescriptionsModal').modal('hide');
    var type = $("input[type='radio']:checked").val();
    $.ajax({
        type: "get",
        url: url,
        data: { type: type },
        success: function (data) {
            $('#ReportView').html(data);
            $('#ReportView').modal('show');
        }
    });
}

$("#btnSearch").on('click',
    function () {

        var url = "/Indent/IndentDomestic/GetList";
        getContractList(url);
        $("#VoucherTable_length").hide();
        $("#VoucherTable_filter").hide();
    });

var getContractList = function (url) {
    var FromDate = $("#FromDate").val();
    var Todate = $("#Todate").val();
    var CommodityTypeId = $("#ComdID").val();
    var DepartmentID = $("#Dept").val();
    var IndentKey = $("#IndentKey").val();


    var table = $('#VoucherTable').DataTable({
        "ajax": {
            "url": url,
            "type": "get",
            "data": { FromDate: FromDate, Todate: Todate, CommodityTypeId: CommodityTypeId, DepartmentID: DepartmentID, IndentKey: IndentKey },
            "datatype": "json"
        },
        "columns": [
            { "data": "InquiryKey", "name": "InquiryKey" },
            { "data": "IndentKey", "name": "IndentKey" },
            { "data": "IndentDate", "name": "IndentDate" },
            { "data": "CommodityTitle", "name": "CommodityTitle" },
            { "data": "Department", "name": "Department" },
            { "data": "PaymentTerm", "name": "PaymentTerm" },
            { "data": "PriceTerm", "name": "PriceTerms" },
            { "data": "IndentStatus", "name": "IndentStatus" },
            { "data": "isClosed", "name": "isClosed" },
            { "data": "IsSubmitForApproval", "name": "IsSubmitForApproval" },
            { "data": "IsApproved", "name": "IsApproved" },
            { "data": "Action", "name": "non" }
        ],
        "columnDefs": [
            {
                "targets": 11,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var editurl = '<a class="dropdown-item" href = "' + full.ViewURL + '" id = "view" >\n<i class="la la-street-view"></i>\n View</a >\n'
                    return editurl;
                }
            }
        ],
        "responsive": "true",
        "serverSide": "true",
        "order": [0, "asc"],
        "processing": "true",
        "destroy": "true",
        "searching": "false",
        "language": {
            "processing": "processing.....please wait"
        }
    });

    //table.columns(0).visible(false)
}