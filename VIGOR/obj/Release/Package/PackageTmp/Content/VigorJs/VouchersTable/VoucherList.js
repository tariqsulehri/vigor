
var LoadVoucherListTable = function () {
    var vType = $('#vType :selected').val();
    var Status = $('#vStatus :selected').val();
    var url = "/Gl/fnVoucherList/GetVouchers?type=" + vType + " &status=" + Status + "";
    var table = $('#fnVoucherList').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
            { "data": "", "orderable": true },

            { "data": "VoucherNo", "orderable": true },
            { "data": "VKey", "orderable": true },
            { "data": "VoucherDate", "orderable": true },
            { "data": "TotalDebit", "TotalDebit": true },
            { "data": "TotalCredit", "orderable": true },
            { "data": "Detail", "orderable": true },
            { "data": "Vtype", "orderable": true },
            { "data": "IsPosted", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 9,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var editurl = '';
                    if (full.IsPosted === 'Posted') {

                        editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="unpostVoucher(' + "'" + full.VKey + "'" + ')"  ><i class="la la-unlock-alt"></i> Un-Post</a>\n</div>\n</span>\n';
                    } else {
                        var posturl = "/GL/fnVoucherList/PostVoucher/";
                        editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="postVoucher(' + "'" + full.VKey + "'" + ')"  ><i class="flaticon-lock"></i> Post</a>\n</div>\n</span>\n';
                    }
                    return editurl;
                }
            },
            {
                "targets": 0,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var editurl = '';
                    editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                        '\n<input name="vKey" type="checkbox" id="' + full.VKey + '" class="m-checkable">\n' +
                        '\n<span></span></label>\n';

                    return editurl;
                }
            }
        ]
    });
    table.columns(0).visible(true);
};
$(function () {
    LoadVoucherListTable();
});

$("#btnSearch").on('click', function () {
    LoadVoucherListTable();
});
$("#btnPostVoucher").click(function () {
    $('#Postimg').show();
    var vType = $('#vType :selected').val();
    var Status = $('#vStatus :selected').val();
    var url = "/Gl/fnVoucherList/PostVoucher";
    var SelectedVoucher = [];
    SelectedVoucher = GetSelectedVoucher();
    if (SelectedVoucher !== null && SelectedVoucher.length > 0 && Status === "0") {
        var title = "Are you sure you want to Post Selected Vouchers ?";
        VoucherOperation(url, title, SelectedVoucher);
        $('#Postimg').hide();
    }
    else {
        $('#Postimg').hide();
    }
});
$("#btnUnPostVoucher").click(function () {
    $('#UnPostimg').show();
    var vType = $('#vType :selected').val();
    var Status = $('#vStatus :selected').val();
    var url = "/Gl/fnVoucherList/UnPostVoucher";
    var SelectedVoucher = [];
    SelectedVoucher = GetSelectedVoucher();
    if (SelectedVoucher !== null && SelectedVoucher.length > 0 && Status === "1") {
        var title = "Are you sure you want to UnPost Selected Vouchers ?";
        VoucherOperation(url, title, SelectedVoucher);
        $('#UnPostimg').hide();
    }
    else {
        $('#UnPostimg').hide();
    }
});

function GetSelectedVoucher() {
    var SelectedVoucher = [];
    $.each($("input[name='vKey']:checked"), function () {
        SelectedVoucher.push($(this).attr("id"));
    });
    return SelectedVoucher;
}

function VoucherOperation(url, title, SelectedVoucher) {

    $.ajax({
        type: "Get",
        url: "/GL/CommonGL/AuthenticationKey",
        success: function (data) {
            $('#AuthenticationKeyForm').html(data);
            $('#AuthenticationKeyForm').modal('show');
            $("#Question").text(title);
            $('#Yes').click(function (e) {
                var authKey = $("#authKey").val();
                $("#AuthenticationKeyForm").modal('hide');
                $.ajax({
                    url: url,
                    type: "post",
                    data: { SelectedVoucher: SelectedVoucher, authKey: authKey }
                }).done(function (data) {
                    if (data !== "Authentication Security Key is InValid") {
                        LoadVoucherListTable();
                        sweetAlert
                            ({
                                title: "Status of Vouchers!",
                                text: data,
                                type: "success"
                            },
                            function () {
                            });
                    }
                    else {
                        swal("Oops", data);
                    }

                })
                    .error(function (data) {
                        swal("Oops", "We couldn't connect to the server!", "error");
                    });
            });


        }
    });




}