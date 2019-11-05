//var S_KEY = 83;
//var R_KEY = 82;
//$(document).keydown(function (e) {
//    if (e.shiftKey  && e.which == S_KEY) {

//        var $myForm = $('#CompanyForm');
//        if ($myForm[0].checkValidity()) {
//            $(document.activeElement).closest("form").submit();
//            //$myForm.find(':submit').click();
//        }
//        else
//        {
//            return false;
//        }
//    }
//    if (e.shiftKey  && e.which == R_KEY) {
//        //$(document.activeElement).closest("form").submit();
//        location.href="/General/Company/Index";
//    }
//});
function OpenCompanyModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#CompanyModal').html(data);
            $('#CompanyModal').modal('show');
        }
    });
}

function DeleteCompany() {
    alert("Company Deleted");
    $('#DeleteCompany').modal('show');
}

var CompanyId = 0;
function DeleteCompany(id) {
    CompanyId = id;

    var url = "/General/Company/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadCompanyTable();
        }
    });
}

function DeleteCompanyConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/Company/Delete?id=" + CompanyId,
        success: function (data) {
            LoadCompanyTable();
            $('#DeleteCompany').modal('hide');
        }
    });
}
function SubmitCompanyForm() {
    var formData = new FormData($('#CompanyForm')[0]);
    var url = $('#CompanyForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#CompanyModal').modal('hide');
                LoadCompanyTable();
            } else {
                $('#CompanyModal').html(data);
                $('#CompanyModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

