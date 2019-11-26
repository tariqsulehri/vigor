$(document).ready(function () {

    LoadIndDomesticDispatchScheduleTable();
    LoadIndDomesticDispatchPaymentTable();
    //HighlightReturnRows();

});
var HighlightReturnRows = function () {
    $("#IndDomesticDispatchScheduleTable tbody tr").each(function () {

        var UnitName = $('.Type', this).val();
        alert(UnitName);
    });
}

var LoadIndDomesticDispatchScheduleTable = function () {
    var id = $("#IndentID").val();

    var url = "/Indent/Dispatch/GetDispatches?id=" + id + "";
    var table = $('.IndDomesticDispatchScheduleTable').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
            { "data": "Id", "orderable": true },
            { "data": "Date", "orderable": true },
            { "data": "Commodity", "orderable": true },
            { "data": "Quantity", "orderable": true },
            { "data": "Balance", "orderable": true },
            { "data": "Name", "orderable": true },
            { "data": "IsDelayed", "orderable": true },
            { "data": "Type", "orderable": true },
            { "data": "Remarks", "orderable": true },
            { "data": "active", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 9,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = '/Indent/Dispatch/Edit/';
                    var attachurl = '/Indent/Dispatch/Attachment/';
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n  <a class="dropdown-item" href="#"onclick="OpenIndDomesticDispatchAttechmentModal(' + "'" + attachurl + full.Id + "'" + ')"><i class="flaticon-attachment"></i> E-file</a>\n<a class="dropdown-item" href="#"onclick="OpenIndDomesticDispatchScheduleModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndDomesticDispatchSchedule(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                    return editurl;
                }
            }
        ]
    });
    table.columns(0).visible(true);
};
var LoadIndDomesticDispatchPaymentTable = function () {
    var id = $("#IndentID").val();

    var url = "/Indent/Dispatch/GetPayments?id=" + id + "";
    var table = $('.IndDomesticDispatchPaymentTable').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
            { "data": "Id", "orderable": true },
            { "data": "Date", "orderable": true },
            { "data": "Quantity", "orderable": true },
            { "data": "Received", "orderable": true },
            { "data": "Remarks", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 5,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var attachurl = '/Indent/Dispatch/Attachment/';
                    var formateurl = '/Indent/IndDomesticDispatchPayment/Edit/';
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n  <a class="dropdown-item" href="#"onclick="OpenIndDomesticDispatchAttechmentModal(' + "'" + attachurl + full.Id + "'" + ')"><i class="flaticon-attachment"></i> E-file</a>\n<a class="dropdown-item" href="#"onclick="OpenIndDomesticDispatchScheduleModal(' + "'" + formateurl + full.Id + "'" + ')"><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteIndDomesticDispatchPayment(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                    return editurl;
                }
            }
        ]
    });
    table.columns(0).visible(true);
};

