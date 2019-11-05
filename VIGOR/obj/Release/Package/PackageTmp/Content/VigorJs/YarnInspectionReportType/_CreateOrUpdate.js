function OpenYarnInspectionReportTypeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#YarnInspectionReportTypeModal').html(data);
            $('#YarnInspectionReportTypeModal').modal('show');
        }
    });
}

function DeleteYarnInspectionReportType() {
    alert("YarnInspectionReportType Deleted");
    $('#DeleteYarnInspectionReportType').modal('show');
}

var YarnInspectionReportTypeId = 0;
function DeleteYarnInspectionReportType(id) {
    YarnInspectionReportTypeId = id;
    var url = "/Indent/YarnInspectionReportType/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadYarnInspectionReportTypeTable();
        }
    });
}
function DeleteYarnInspectionReportTypeConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/YarnInspectionReportType/Delete?id=" + YarnInspectionReportTypeId,
        success: function (data) {
            LoadYarnInspectionReportTypeTable();
            $('#DeleteYarnInspectionReportType').modal('hide');
        }
    });
}
function SubmitYarnInspectionReportTypeForm() {
    var formData = new FormData($('#YarnInspectionReportTypeForm')[0]);
    var url = $('#YarnInspectionReportTypeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#YarnInspectionReportTypeModal').modal('hide');
                LoadYarnInspectionReportTypeTable();
            } else {
                $('#YarnInspectionReportTypeModal').html(data);
                $('#YarnInspectionReportTypeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

