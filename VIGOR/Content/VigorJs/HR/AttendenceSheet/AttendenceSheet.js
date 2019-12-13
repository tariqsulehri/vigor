
//function OpenCountryModal(url) {

//    var Forthemonth=   $("#Forthemonth").val();
//    var Fortheyear = $("#Fortheyear").val();
//    var Department = $("#Department").val();
//    $.ajax({
//        type: "Post",
//        data: {
//            Department: Department,
//            Fortheyear: Fortheyear,
//            Forthemonth: Forthemonth,
//        },
//        url: "/Countries/AttendenceSheetList",,
//        success: function (data) {
//            $('#CountryModal').html(data);
//            $('#CountryModal').modal('show');
//        }
//    });
//}
var statusValue = "";
var day = 0;
var EmployeeId = 0;
var EmployeeAttendanceId = 0;
function OpenMenuCountry(ele, days) {
    statusValue = $(ele).text();
    EmployeeId = $(ele).closest('tr').attr("data-EmployeeId");
    EmployeeAttendanceId = $(ele).closest('tr').attr("data-EmployeeAttendanceId");
    day = days;
    $('#OpenMenuCountry').modal('show');
}
function DeleteCountryConfirm() {
    $.ajax({
        type: "POST",
        url: "/Countries/AttendenceSheetList?id=" + CountryId,
        success: function (data) {
            $('#OpenMenuCountry').modal('hide');
        }
    });
}

function ChangeStatusForm() {
    $.ajax({
        type: "Get",
        url: "/hr/AttendanceSheet/ChangeStatus",
        data: {
            EmployeeId: EmployeeId,
            EmployeeAttendanceId: EmployeeAttendanceId,
            days: day,
            statusValue: statusValue
        },
        success: function (data) {
            $('#AttenDanceModal').html(data);
            $('#AttenDanceModal').modal('show');
        }
    });
}
function SubmitChangeStatusForm() {
    var formData = new FormData($('#ChangeStatusForm')[0]);
    var url = $('#ChangeStatusForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data == null || data == undefined || data == '') {
                $('#AttenDanceModal').modal('hide');
                location.reload(true);
            } else {
                $('#AttenDanceModal').html(data);
                $('#AttenDanceModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false,
    });
}

function ChangeTime() {
    $.ajax({
        type: "Get",
        url: "/hr/AttendanceSheet/AttendanceTime",
        data: {
            EmployeeId: EmployeeId,
            EmployeeAttendanceId: EmployeeAttendanceId,
            days: day,
        },
        success: function (data) {
            $('#AttenDanceModal').html(data);
            $('#AttenDanceModal').modal('show');
        }
    });
}
function SubmitChangeTime() {
    var ForTheMonth = $("#ForTheMonth").val();
    var ForTheYear = $("#ForTheYear").val();
    var EmployeeId = $("#EmployeeId").val();
    var EmployeeAttendanceID = $("#EmployeeAttendanceID").val();
    var TimeIn = new Date();
     TimeIn = $("#TimeIn").val();
    var TimeOut = new Date();
     TimeOut = $("#TimeOut").val();
    $.ajax({
        url: "/hr/AttendanceSheet/AttendanceTimeAddEdit",
        type: "Get",
        data: {
            EmployeeId: EmployeeId,
            EmployeeAttendanceID: EmployeeAttendanceID,
            TimeIn: TimeIn,
            TimeOut: TimeOut,
            ForTheMonth: ForTheMonth,
            ForTheYear: ForTheYear,
            Day: day
        },
        success: function (data) {
            debugger;
            $('#AttenDanceModal').html(data);
            $('#AttenDanceModal').modal('hide');
        }
    });
}
