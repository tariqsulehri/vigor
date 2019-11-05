$(function () {
    if ($("#InstructionsSwitch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadSpecialInstructionTable();
});
var LoadSpecialInstructionTable = function () {
    var url = "/General/SpecialInstruction/GetSpecialInstruction?active=" + switchStatus+"";
    var table = $('#SpecialInstructionTable').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
                { "data": "Id", "orderable": true},
                { "data": "Title", "orderable": true, "width": "80%" },
                { "data": "active", "orderable": true}
        ],
        columnDefs: [
        {
            "targets": 3,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/General/SpecialInstruction/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenSpecialInstructionModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteSpecialInstruction(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                return editurl;
            }
        }
        ]
    });
    table.columns(0).visible(true);
};

var switchStatus = true;
function InstructionsChangeSwitch() {

    if ($("#InstructionsSwitch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
        LoadSpecialInstructionTable();
};
function SpecialInstructionPrint() {
    window.location.href = "/General/SpecialInstruction/PrintSpecialInstruction?active=" + switchStatus;
};