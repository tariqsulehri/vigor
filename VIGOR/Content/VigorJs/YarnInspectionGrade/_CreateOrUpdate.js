function OpenYarnInspectionGradeModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#YarnInspectionGradeModal').html(data);
            $('#YarnInspectionGradeModal').modal('show');
        }
    });
}

function DeleteYarnInspectionGrade() {
    alert("YarnInspectionGrade Deleted");
    $('#DeleteYarnInspectionGrade').modal('show');
}

var YarnInspectionGradeId = 0;
function DeleteYarnInspectionGrade(id) {
    YarnInspectionGradeId = id;
    var url = "/Indent/YarnInspectionGrade/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadYarnInspectionGradeTable();
        }
    });
}
function DeleteYarnInspectionGradeConfirm() {
    $.ajax({
        type: "POST",
        url: "/Indent/YarnInspectionGrade/Delete?id=" + YarnInspectionGradeId,
        success: function (data) {
            LoadYarnInspectionGradeTable();
            $('#DeleteYarnInspectionGrade').modal('hide');
        }
    });
}
function SubmitYarnInspectionGradeForm() {
    var formData = new FormData($('#YarnInspectionGradeForm')[0]);
    var url = $('#YarnInspectionGradeForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#YarnInspectionGradeModal').modal('hide');
                LoadYarnInspectionGradeTable();
            } else {
                $('#YarnInspectionGradeModal').html(data);
                $('#YarnInspectionGradeModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

