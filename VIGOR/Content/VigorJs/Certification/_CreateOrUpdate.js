
function OpenCertificationModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#CertificationModal').html(data);
            $('#CertificationModal').modal('show');
        }
    });
}

function DeleteCertification() {
    alert("Certification Deleted");
    $('#DeleteCertification').modal('show');
}

var CertificationId = 0;
function DeleteCertification(id) {
    CertificationId = id;
    var url = "/General/Certification/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
                LoadCertificationTable();
        }
    });
}
function DeleteCertificationConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Certification/Delete?id=" + CertificationId,
        success: function (data) {
                LoadCertificationTable();
            $('#DeleteCertification').modal('hide');
        }
    });
}
function SubmitCertificationForm() {
    var formData = new FormData($('#CertificationForm')[0]);
    var url = $('#CertificationForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#CertificationModal').modal('hide');
                LoadCertificationTable();
            } else {
                $('#CertificationModal').html(data);
                $('#CertificationModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

