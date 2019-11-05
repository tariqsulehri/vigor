
function OpenSpecialInstructionModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#SpecialInstructionModal').html(data);
            $('#SpecialInstructionModal').modal('show');
        }
    });
}

function DeleteSpecialInstruction() {
    alert("SpecialInstruction Deleted");
    $('#DeleteSpecialInstruction').modal('show');
}

var SpecialInstructionId = 0;
function DeleteSpecialInstruction(id) {
    SpecialInstructionId = id;

    var url = "/General/SpecialInstruction/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
                LoadSpecialInstructionTable();
        }
    });
}
function DeleteSpecialInstructionConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/SpecialInstruction/Delete?id=" + SpecialInstructionId,
        success: function (data) {
                LoadSpecialInstructionTable();
            $('#DeleteSpecialInstruction').modal('hide');
        }
    });
}
function SubmitSpecialInstructionForm() {
    var formData = new FormData($('#SpecialInstructionForm')[0]);
    var url = $('#SpecialInstructionForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#SpecialInstructionModal').modal('hide');
                LoadSpecialInstructionTable();
            } else {
                $('#SpecialInstructionModal').html(data);
                $('#SpecialInstructionModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

