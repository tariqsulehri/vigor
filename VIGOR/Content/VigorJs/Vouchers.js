$(document).on('keydown', '#VoucherTable_filter [type="search"]', function (e) {
    if (e.shiftKey) {
        var lister = $('.btnSelect');
        var thiser = $(this);
        $.each(lister, function (e) {
            thiser = this;
            myonfunction(thiser);
            return false;
        });
    }
    else return true;

});
function myonfunction(e) {
    var uniqueName = parseInt(Index.match(/[0-9]+/)[0], 10);
    var currentRow = $(e).closest("tr");
    var col1 = newFunction(currentRow);
    var col2 = currentRow.find("td:eq(1)").text();
    var Account = "det[" + uniqueName + "][Account]";
    var AccountCode = "det[" + uniqueName + "][GlCode]";
    var department = "det[" + uniqueName + "][DeptId]";
    var Location = "det[" + uniqueName + "][LocId]";
    var employee = "det[" + uniqueName + "][EmpId]";
    var customer = "det[" + uniqueName + "][CustomerId]";
    var credit = "det[" + uniqueName + "][Credit]";
    var debit = "det[" + uniqueName + "][Debit]";
    $('input[name="' + AccountCode + '"]').val(col1);
    $('input[name="' + Account + '"]').val(col2);
    var url = '/GL/CommonGL/GetGlAccount?glcode=' + col1 + '';
    $.ajax({
        type: "post",
        url: url,
        success: function (data) {
            if (!data.IsDept) { $('select[name="' + department + '"]').prop("disabled", true); $('select[name="' + department + '"]').val(""); } else { $('select[name="' + department + '"]').prop("disabled", false); }
            if (!data.IsLoc) { $('select[name="' + Location + '"]').prop("disabled", true); $('select[name="' + Location + '"]').val(""); } else { $('select[name="' + Location + '"]').prop("disabled", false); }
            if (!data.IsEmp) { $('select[name="' + employee + '"]').prop("disabled", true); $('select[name="' + employee + '"]').val(""); } else { $('select[name="' + employee + '"]').prop("disabled", false); }
            if (!data.IsCust) { $('select[name="' + customer + '"]').prop("disabled", true); $('select[name="' + customer + '"]').val(""); } else { $('select[name="' + customer + '"]').prop("disabled", false); }
            $('input[name="' + credit + '"]').focus();
            $('input[name="' + debit + '"]').focus();
        }, error: function (data) {
        }
    });
    $('#GLCOA').modal('hide');
}
function MonthSelected() {
    var dropdown = document.getElementById('fiscalMonth');
    var fDate = document.getElementById('fiscalDate');

    var s = dropdown.options[dropdown.selectedIndex].text;
    var a = s.split('-');
    a[0] = a[0].replace(" ", "");
    a[1] = a[1].replace(" ", "");
    var year = a[1].trim();
    var month = a[0].trim();

    var mm = "01";
    var min = "01";
    var max = "30";

    var words = new Array();
    words[1] = 'Jan';
    words[2] = 'Feb';
    words[3] = 'Mar';
    words[4] = 'Apr';
    words[5] = 'May';
    words[6] = 'Jun';
    words[7] = 'Jul';
    words[8] = 'Aug';
    words[9] = 'Sep';
    words[10] = 'Oct';
    words[11] = 'Nov';
    words[12] = 'Dec';
    var finder = words.indexOf(month);
    finder -= 1;
    var firstDay = new Date(year, finder, 1).toString("yyyy-MM-dd");
    var lastDay = new Date(year, finder + 1, 0).toString("yyyy-MM-dd");
    var currentdate = new Date().toString("yyyy-MM-dd");

    var az = firstDay.split(" ");
    var bz = lastDay.split(" ");
    var cd = currentdate.split(" ");
    min = az[2];
    max = bz[2];

    if (month == "Jan") {
        mm = "01";
    }
    else if (month == "Feb") {
        mm = "02";
    }
    else if (month == "Mar") {
        mm = "03";
    }
    else if (month == "Apr") {
        mm = "04";
    }
    else if (month == "May") {
        mm = "05";
    }
    else if (month == "Jun") {
        mm = "06";
    }
    else if (month == "Jul") {
        mm = "07";
    }
    else if (month == "Aug") {
        mm = "08";
    }
    else if (month == "Sep") {
        mm = "09";
    }
    else if (month == "Oct") {
        mm = "10";
    }
    else if (month == "Nov") {
        mm = "11";
    }
    else if (month == "Dec") {
        mm = "12";
    }
    var ar = fDate.value.toString("yyyy-MM-dd");
    var srd = ar.split("-");
    if (cd[1] == az[1] && cd[3] == az[3]) {
        if (srd[0] == cd[3] && srd[1] == mm) {
            fDate.value = ar;
        }
        else
            fDate.value = "" + year + "-" + mm + "-" + cd[2] + "";
    }
    else {
        fDate.value = "" + year + "-" + mm + "-" + min + "";
    }
    fDate.min = "" + year + "-" + mm + "-" + min + "";
    fDate.max = "" + year + "-" + mm + "-" + max + "";
}
var Index;
function OpenTrCOAModal(name, type) {
    Index = name;
    var url = '/GL/CommonGL/TrCOA';
    $.ajax({
        type: "Get",
        url: url,
        data: { type: type },
        success: function (data) {
            $('#GLCOA').html(data);
            $('#GLCOA').modal('show');
            $("#GLCOA").on('shown.bs.modal', function () {
                $(this).find('#VoucherTable_filter [type="search"]').focus();
                var uniqueName = parseInt(Index.match(/[0-9]+/)[0], 10);
                var Detail = "det[" + uniqueName + "][Detail]";
                var serch = $('input[name="' + Detail + '"]').val();
                $('#VoucherTable_filter [type="search"]').val(serch);
            });
        }
    });
}
var F_KEY = 70;
function CheckingButtonClick(e, name, type) {
    if (e.shiftKey && e.which == F_KEY) {
        OpenTrCOAModal(name, type);
    }
    else {
        return true;
    }
}
$("#VoucherTable").on('click', '.btnSelect', function () {
    var uniqueName = parseInt(Index.match(/[0-9]+/)[0], 10);
    var currentRow = $(this).closest("tr");
    var col1 = newFunction(currentRow);
    var col2 = currentRow.find("td:eq(1)").text();
    var Account = "det[" + uniqueName + "][Account]";
    var AccountCode = "det[" + uniqueName + "][GlCode]";
    var department = "det[" + uniqueName + "][DeptId]";
    var Location = "det[" + uniqueName + "][LocId]";
    var employee = "det[" + uniqueName + "][EmpId]";
    var customer = "det[" + uniqueName + "][CustomerId]";
    var credit = "det[" + uniqueName + "][Credit]";
    var debit = "det[" + uniqueName + "][Debit]";
    $('input[name="' + AccountCode + '"]').val(col1);
    $('input[name="' + Account + '"]').val(col2);
    var url = '/GL/CommonGL/GetGlAccount?glcode=' + col1 + '';
    $.ajax({
        type: "post",
        url: url,
        success: function (data) {
            if (!data.IsDept) { $('select[name="' + department + '"]').prop("disabled", true); $('select[name="' + department + '"]').val(""); } else { $('select[name="' + department + '"]').prop("disabled", false); }
            if (!data.IsLoc) { $('select[name="' + Location + '"]').prop("disabled", true); $('select[name="' + Location + '"]').val(""); } else { $('select[name="' + Location + '"]').prop("disabled", false); }
            if (!data.IsEmp) { $('select[name="' + employee + '"]').prop("disabled", true); $('select[name="' + employee + '"]').val(""); } else { $('select[name="' + employee + '"]').prop("disabled", false); }
            if (!data.IsCust) { $('select[name="' + customer + '"]').prop("disabled", true); $('select[name="' + customer + '"]').val(""); } else { $('select[name="' + customer + '"]').prop("disabled", false); }
            $('input[name="' + credit + '"]').focus();
            $('input[name="' + debit + '"]').focus();
        }, error: function (data) {
        }
    });
    $('#GLCOA').modal('hide');

});
$(document).ready(function () {
    LoadCOAList();
    MonthSelected();
    arrowTable();
    $(".allow_decimal").on("input", function (evt) {
        var self = $(this);
        self.val(self.val().replace(/[^0-9\.]/g, ''));
        if ((evt.which !== 46 || self.val().indexOf('.') !== -1) && (evt.which < 48 || evt.which > 57)) {
            evt.preventDefault();
        }
    });
});

var availableCOA;

//LoadMenuItemsList();
function LoadCOAList() {
    var url = '/GL/CommonGL/COAList';
    var data;
    $.getJSON(url, function (data) {
       
        availableCOA = data;
        });
    $('body').on('focus', '.Account', function (event) {
        $('.Account').devbridgeAutocomplete({
            lookup: availableCOA,
            minChars: 1,
            onSelect: function (suggestion) {

                var isAvailableItem = true;
                var str = suggestion.value;
                var res = str.split(" - ");
                if (isAvailableItem) {
                    AddItemInTable(res[0]);
                }
               
            },
            showNoSuggestionNotice: true,
            noSuggestionNotice: 'Sorry, no matching results'
        })
    });


    $('body').on('blur', '.Account', function (ev) {
        var tag = SearchTag1($(this).val());
        if (tag) {
            $("#blur-count").text("");
            $(this).removeClass('highlight');
        }
        else {
            //$(this).val("");
            $(this).val('');
            $("#blur-count").text("--");
        }
        //$(".numeric").numeric();
    });
    var SearchTag1 = function (tagName) {
        var i = null;
        for (i = 0; availableCOA.length > i; i += 1) {
            if (availableCOA[i] === tagName) {
                return availableCOA[i];
            }
        }
        return null;
    };

     
}




$("#fiscalMonth").change(function () {
    var MonthId = $("#fiscalMonth").val();
    var url = '/GL/CommonGL/GetFiscalPeriod?MonthId=' + MonthId + '';
    $.ajax({
        type: "post",
        url: url,
        success: function (data) {
            $('#datetimepicker').datepicker({
                startDate: data.StartDate,
                endDate: data.EndDate
            });
            $('#datetimepicker').val(data.StartDate);
        }, error: function (data) {

        }
    });
});
function newFunction(currentRow) {
    return currentRow.find("td:eq(0)").text();
}




$('#detailGrid').arrowTable({
    enabledKeys: ['left', 'right', 'up', 'down']
});
$('#detailGrid').arrowTable({
    listenTarget: 'input'
});
$('#detailGrid').arrowTable({
    focusTarget: 'input'
});
$('#detailGrid').arrowTable({
    namespace: 'arrowtable'
});
$('#detailGrid').arrowTable({
    continuousDelay: 50
});
$('#detailGrid').arrowTable({
    beforeMove: function (input, targetFinder, direction) {
    },
    afterMove: function (input, targetFinder, direction) {
    },
});
