$(function () {
    if ($("#CustomerSwitch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
    LoadCustomerTable();
});
var LoadCustomerTable = function () {
    var url = "/General/Customer/GetCustomer?active="+switchStatus+"";
    var table = $('.CustomerTable').DataTable({
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
                { "data": "Title", "orderable": true, "width": "50%" },
                { "data": "company", "orderable": true },
                { "data": "active", "orderable": true }
        ],
        columnDefs: [
        {
            "targets": 4,
            "data": null,
            "orderable": true,
            "render": function (data, type, full, meta) {
                var formateurl = "/General/Customer/Edit/";
                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="' + formateurl + full.Id + '"><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteCustomer(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
                return editurl;
            }
        }
        ]
    });
    table.columns(0).visible(true);
};

var switchStatus = true;
function CustomerChangeSwitch() {
    if ($("#CustomerSwitch1").is(':checked')) {
        switchStatus = true;
    }
    else {
        switchStatus = false;
    }
        LoadCustomerTable();
};
function CustomerPrint() {
    window.location.href = "/General/Customer/PrintCustomer?active=" + switchStatus;
};
function GetCities(Id) {
    $("#CityID").empty();
    $("#CityID").append($("<option></option>"));
    $.ajax({
        type: "Get",
        url: "/City/GetAllCityOfCountry",
        data: { countryID: Id },
        success: function (data) {
            $("#CityID").empty();
            $("#CityID").append($("<option></option>"));
            $.each(data,
                function (key, value) {
                    $('#CityID').append($("<option> </option>").val(value.Id).html(value.Title));
                });
        }
    });
}