//$(function () {
//    LoadRegionTable()
//});
//var LoadRegionTable = function () {
//    var url = "/Region/GetRegion"
//    var table = $('#RegionTable').DataTable({
//        serverSide: false,
//        destroy: true,
//        processing: true,
//        responsive: true,
//        autoWidth: false,
//        iDisplayLength: 10,
//        dateLimit: 15,
//        ajax: url,
//        columns: [
//                { "data": "Id", "orderable": true},
//                { "data": "Title", "orderable": true, "width": "80%" },
//        ],
//        columnDefs: [
//        {
//            "targets": 2,
//            "data": null,
//            "orderable": true,
//            "render": function (data, type, full, meta) {
//                var formateurl = "/Region/Edit/";
//                var editurl = '<button type="button" class="btn btn-sm btn-primary" onclick="OpenRegionModal(' + "'" + formateurl + full.Id + "'" + ')">Edit</button>';
//                editurl = editurl + ' | <button type="button" class="btn btn-sm btn-danger LeftMargin" onclick="DeleteRegionModal(' + full.Id + ')">Delete</button>';
//                editurl = editurl + '</div>';
//                return editurl;
//            }
//        },
    
//        ]
//    });
//    table.columns(0).visible(false)
//};
