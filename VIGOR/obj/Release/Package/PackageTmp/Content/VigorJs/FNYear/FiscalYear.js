$(function () {
    LoadYearTable();
});
var LoadYearTable = function () {
    var url = "/GL/fnYear/GetYears";
    var table = $('#YearTable').DataTable({
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
            { "data": "Title", "orderable": true, "width": "80%" },
            { "data": "StartDate", "orderable": true },
            { "data": "EndDate", "orderable": true },
            { "data": "Active", "orderable": true },
        ],
        columnDefs: [
            {
                "targets": 5,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/GL/fnYear/Edit/";
                    var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenYearModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n  <a class="dropdown-item" href="#" onclick="MonthList(' + "'" + full.Id + "'" + ')"  ><i class="la la-List"></i> Month List</a>\n</div>\n</span>\n';
                    return editurl;
                }

            },

        ]
    });
    table.columns(0).visible(false);
};




var MonthList = function (id) {
    var url = "/GL/fnMonth/Details?Id=" + id+"";
    var table = $('#MonthTable').DataTable({
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
            { "data": "Title", "orderable": true, "width": "80%" },
            { "data": "StartDate", "orderable": true },
            { "data": "EndDate", "orderable": true },
            { "data": "Active", "orderable": true },
        ],
        columnDefs: [
            {
                "targets": 5,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "/GL/fnYear/Edit/";
                    var editurl = ''
                    return editurl;
                }

            },

        ]
    });
    table.columns(0).visible(false);
};




function OpenYearModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#Year').html(data);
            $('#Year').modal('show');
        }
    });
}
function SubmitYearForm() {
    var formData = new FormData($('#YearForm')[0]);
    var url = $('#YearForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#Year').modal('hide');
                LoadYearTable();
            } else {
                $('#Year').html(data);
                $('#Year').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false,
    });
}