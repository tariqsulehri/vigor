function SelectionChanged() {
    var dropdown = document.getElementById('drop');
    var textbox = document.getElementById('IndDomesticDispatchScheduleName');
    textbox.value = dropdown.options[dropdown.selectedIndex].text;
}

$(document).ready(function () {
    GeneralInfo();
});
function OpenIndDomesticDispatchAttechmentModal(url) {

    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#FollowUpSheetModal').html(data);
            $('#FollowUpSheetModal').modal('show');
        }
    });
}
function OpenIndDomesticDispatchScheduleModal(url) {

    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndDomesticDispatchScheduleModal').html(data);
            $('#IndDomesticDispatchScheduleModal').modal('show');
        }
    });
}

function GeneralInfo() {
    var url = "/Indent/IndDomesticDispatchSchedule/GeneralInfo";
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $("#GeneralInfo").html(data);
        }, error: function (data) {

        }
    });
}

var IndDomesticDispatchScheduleId = 0;
function DeleteIndDomesticDispatchSchedule(id) {
    deleteOrder(id);
}
function DeleteIndDomesticDispatchPayment(id) {
    deletePayment(id);
}
function deleteOrder(OrderID) {
    swal({
        title: "Are you sure you want to delete this dispatch ?",
        text: "",
        icon: "success",
        confirmButtonText: "<span><a href='javascript:' style='color:white' id='delete'><i class='la la-unlock'></i>DELETE</a></span>",
        confirmButtonClass: "btn btn-danger m-btn m-btn--pill m-btn--air m-btn--icon",
        showCancelButton: !0,
        cancelButtonText: " <a href='javascript:'  style='color:black' id='dtview'><i class='flaticon-cancel'></i> CANCEL</a>",
        cancelButtonClass: "btn btn-secondary m-btn m-btn--pill m-btn--icon"
    });
    $('#delete').click(function (e) {
            $.ajax({
                url: "/Indent/Dispatch/Delete?id=" + OrderID,
                type: "DELETE"
            }).done(function (data) {
                    LoadIndDomesticDispatchScheduleTable();
                    sweetAlert
                        ({
                            title: "Deleted!",
                            text: "Your file was successfully deleted!",
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


function deletePayment(PaymentID) {
    swal({
        title: "Are you sure you want to delete this Payment ?",
        text: "",
        icon: "success",
        confirmButtonText: "<span><a href='javascript:' style='color:white' id='deletePayment'><i class='la la-unlock'></i>DELETE</a></span>",
        confirmButtonClass: "btn btn-danger m-btn m-btn--pill m-btn--air m-btn--icon",
        showCancelButton: !0,
        cancelButtonText: " <a href='javascript:'  style='color:black' id='dtview'><i class='la la-eye'></i> CANCEL</a>",
        cancelButtonClass: "btn btn-secondary m-btn m-btn--pill m-btn--icon"
    });
    $('#deletePayment').click(function (e) {
        $.ajax({
            url: "/Indent/IndDomesticDispatchPayment/Delete?id=" + PaymentID,
                type: "DELETE"
            }).done(function (data) {
                LoadIndDomesticDispatchPaymentTable();
                sweetAlert
                ({
                        title: "Deleted!",
                        text: "Your file was successfully deleted!",
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

function SubmitIndDomesticDispatchScheduleForm() {
    var formData = new FormData($('#IndDomesticDispatchScheduleForm')[0]);
    var url = $('#IndDomesticDispatchScheduleForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndDomesticDispatchScheduleModal').modal('hide');
                LoadIndDomesticDispatchScheduleTable();
            } else {
                $('#IndDomesticDispatchScheduleModal').html(data);
                $('#IndDomesticDispatchScheduleModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

