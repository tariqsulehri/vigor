$(function () {
    tree();
});
function tree() {
    var url = "/fnCOA/Tree";
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $("#Tree").html(data);
        }, error: function (data) {

        }
    });
}
var clickCount = 0;
var timeoutID = 0;
function showForm(code, Level) {
    clickCount++;
    var url;
    if (clickCount >= 2) {
        clickCount = 0;
        clearTimeout(timeoutID);
        url = "/fnCOA/Edit?AccountCode=" + code + "&Level=" + Level;
        $.ajax({
            type: "Get",
            url: url,
            success: function (data) {
                $("#COAForm").html(data);
                if (Level === "L1") { $('input[name="L1Title"]').focus(); }
                else if (Level === "L2") { $('input[name="L2Title"]').focus(); }
                else if (Level === "L3") { $('input[name="L3Title"]').focus(); }
                else if (Level === "L4") { $('input[name="L4Title"]').focus(); }
                else if (Level === "L5") { $('input[name="L5Title"]').focus(); }
            }, error: function (data) {
                alert("error");
            }
        });
    }
    else if (clickCount === 1) {
        var callBack = function () {
            if (clickCount == 1) {
                clickCount = 0;
                if (Level === "L5")
                    url = "/fnCOA/Edit?AccountCode=" + code + "&Level=" + Level;
                else url = "/fnCOA/Create?AccountCode=" + code + "&Level=" + Level;
                $.ajax({
                    type: "Get",
                    url: url,
                    success: function (data) {
                        $("#COAForm").html(data);
                        if (Level === "L1") { $('input[name="L2Title"]').focus(); }
                        else if (Level === "L2") { $('input[name="L3Title"]').focus(); }
                        else if (Level === "L3") { $('input[name="L4Title"]').focus(); }
                        else if (Level === "L4") { $('input[name="L5Title"]').focus(); }
                        else if (Level === "L5") { $('input[name="L5Title"]').focus(); }
                    }, error: function (data) {
                        alert("error");
                    }
                });
            }
        };
        //if (value.leveltype === "2") { $('input[name="L2Title"]').focus(); }
        //This will call the callBack function in 500 milliseconds (1/2 second).
        //If by that time they haven't clicked the LinkButton again
        //We will perform the single click action. You can adjust the
        //Time here to control how quickly the user has to double click.
        timeoutID = setTimeout(callBack, 500);
    }

}
$(document).on("click", '[data-main_control]', function (event) {
    event.preventDefault();
    var $current = $(this);

    alert($current);
    var url = "/fnCOA/Create?AccountCode=" + $current + "";
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $("#COAForm").html(data);
        }, error: function (data) {
            alert("error");
        }
    });

});

$(document).on('click', '#btnSave', function (event) {
    event.preventDefault();
    var formData = new FormData($('#COAF')[0]);
    var url = "/GL/fnCOA/Create";
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            ResetForm();
            tree();
        },
        cache: false,
        contentType: false,
        processData: false
    });

});

$(document).on('click', '#btnUpdate', function (event) {
    event.preventDefault();
    var formData = new FormData($('#COAF')[0]);
    var url = "/GL/fnCOA/Edit";
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            ResetForm();
            tree();
        },
        cache: false,
        contentType: false,
        processData: false
    });

});

$(document).on('click', '#btnDelete', function (event) {
    event.preventDefault();
    var formData = new FormData($('#COAF')[0]);
    var url = "/GL/fnCOA/Delete";
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            ResetForm();
            tree();
        },
        cache: false,
        contentType: false,
        processData: false
    });

});
$('#btnexpand').click(function () {
    $('ul', $(this).parent()).eq(0).toggle();
});

function ResetForm() {

    $('input[name="L1Code"]').val('');
    $('input[name="L1Title"]').val('');
    $('input[name="L2Code"]').val('');
    $('input[name="L2Title"]').val('');
    $('input[name="L3Code"]').val('');
    $('input[name="L3Title"]').val('');
    $('input[name="L4Code"]').val('');
    $('input[name="L4Title"]').val('');
    $('input[name="L5Code"]').val('');
    $('input[name="L5Title"]').val('');
    $('input[name="leveltype"]').val('');
    $('input[name="Active"]').prop("checked", true);
    $('input[name="IsDept"]').prop("checked", false);
    $('input[name="IsLoc"]').prop("checked", false);
    $('input[name="IsEmp"]').prop("checked", false);
    $('input[name="IsCust"]').prop("checked", false);
}