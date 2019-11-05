var DatatablesBasicPaginations = {
    init: function () {
        $("#VoucherTable").DataTable({
            responsive: !0,
            pagingType: "full_numbers",
            columnDefs: [{
                targets: -1,
                title: "Actions",
                orderable: !1,
                render: function (a, e, n, t) {
                    return '\n <span class="dropdown">\n <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">\n                              <i class="la la-ellipsis-h"></i>\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#"><i class="la la-edit"></i> Edit Details</a>\n                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i> Update Status</a>\n                                <a class="dropdown-item" href="#"><i class="la la-print"></i> Generate Report</a>\n                            </div>\n                        </span>\n                        <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">\n                          <i class="la la-edit"></i>\n                        </a>'
                }
            }
                , {
                targets: 15,
                render: function (a, e, n, t) {
                    var s = {
                        False: {
                            title: "Un Post",
                            class: "m-badge--brand"
                        },
                        2: {
                            title: "Delivered",
                            class: " m-badge--metal"
                        },
                        3: {
                            title: "Canceled",
                            class: " m-badge--primary"
                        },
                        4: {
                            title: "Success",
                            class: " m-badge--success"
                        },
                        5: {
                            title: "Info",
                            class: " m-badge--info"
                        },
                        True: {
                            title: "Posted",
                            class: " m-badge--success"
                        },
                        7: {
                            title: "Warning",
                            class: " m-badge--warning"
                        }
                    };
                    return void 0 === s[a] ? a : '<span class="m-badge ' + s[a].class + ' m-badge--wide">' + s[a].title + "</span>"
                }
            }

            ]
        });
    }
};
jQuery(document).ready(function () {
    //  DatatablesBasicPaginations.init();
});


function voucherList(url) {
    
    getVoucherList(url);
    $("#VoucherTable_length").hide();
    $("#VoucherTable_filter").hide();

}
var getVoucherList = function (url) {
    var dateFrom = $("#dateFrom").val();
    var dateTo = $("#dateTo").val();
    var GlCode = $("#GlCode").val();
    var Detail = $("#Detail").val();
    var table = $('#VoucherTable').DataTable({
        "ajax": {
            "url": url,
            "type": "get",
            "data": { dateFrom: dateFrom, dateTo: dateTo, GlCode: GlCode, Detail: Detail },
            "datatype": "json"
        },
        "columns": [
            { "data": "VKey", "name": "VKey" },
            { "data": "VoucherDate", "name": "VoucherDate" },
            { "data": "TotalDebit", "name": "TotalDebit" },
            { "data": "TotalCredit", "name": "TotalCredit" },
            { "data": "Detail", "name": "Detail" },
            { "data": "IsPosted", "name": "IsPosted" },
            { "data": "Action", "name": "non" }
        ],
        "columnDefs": [
            {
                "targets": 6,
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


var GetCOA = function (url) {

    var GlCode = $("#GlCode").val();
    var Detail = $("#GLCOATitle").val();

    var table = $('#VoucherTable').DataTable({
        "ajax": {
            "url": url,
            "type": "get",
            "data": { GlCode: GlCode, Detail: Detail },
            "datatype": "json"
        },
        "columns": [
            { "data": "L5Code", "name": "L5Code" },
            { "data": "Title", "name": "Title" },
            { "data": "IsDept", "name": "IsDept" },
            { "data": "IsLoc", "name": "IsLoc" },
            { "data": "IsEmp", "name": "IsEmp" },
            { "data": "IsCust", "name": "IsCust" },
            { "data": "Action", "name": "non" }
        ],
        "columnDefs": [
            {
                "targets": 6,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var editurl = '<button class="btn btn-focus btn-sm btnSelect">Select</button>\n'
                    return editurl;
                }
            },
            {
                "targets": 2,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var editurl = '';
                    if (full.IsDept) {
                        editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                            '\n<input type="checkbox" class="m-checkable" checked="checked" disabled="disabled">\n' +
                            '\n<span></span></label>\n'
                    } else {
                        editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                            '\n<input type="checkbox" class="m-checkable" disabled="disabled">\n' +
                            '\n<span></span></label>\n'
                    }
                    return editurl;
                }
            }, {
                "targets": 3,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var editurl = '';
                    if (full.IsLoc) {
                        editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                            '\n<input type="checkbox" class="m-checkable" checked="checked" disabled="disabled">\n' +
                            '\n<span></span></label>\n'
                    } else {
                        editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                            '\n<input type="checkbox" class="m-checkable" disabled="disabled">\n' +
                            '\n<span></span></label>\n'
                    }
                    return editurl;
                }
            }, {
                "targets": 4,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                 
                    var editurl = '';
                    if (full.IsEmp) {
                        editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                            '\n<input type="checkbox" class="m-checkable" checked="checked" disabled="disabled">\n' +
                            '\n<span></span></label>\n'
                    } else {
                        editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                            '\n<input type="checkbox" class="m-checkable" disabled="disabled">\n' +
                            '\n<span></span></label>\n'
                    }
                    return editurl;
                }
            }, {
                "targets": 5,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var editurl = '';
                    if (full.IsCust) {
                        editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                            '\n<input type="checkbox" class="m-checkable" checked="checked" disabled="disabled">\n' +
                            '\n<span></span></label>\n'
                    } else {
                        editurl = ' <label class="m-checkbox m-checkbox--single m-checkbox--solid">\n' +
                            '\n<input type="checkbox" class="m-checkable" disabled="disabled">\n' +
                            '\n<span></span></label>\n'
                    }
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
    $("#VoucherTable_length").hide();
    $("#VoucherTable_filter").hide();
    //table.columns(0).visible(false)
}

