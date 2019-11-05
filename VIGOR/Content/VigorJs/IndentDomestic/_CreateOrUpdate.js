
function OpenIndentDomesticModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndentDomesticModal').html(data);
            $('#IndentDomesticModal').modal('show');
        }
    });
}
function OpenLookUpContractsModal(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#IndentLookUpModal').html(data);
            $('#IndentLookUpModal').modal('show');
        }
    });
}
function LoadLookUpContracts() {
    var fromdate = $("#fromDate").val();
    var todate = $("#toDate").val();
    var indentNo = $("#indentNo").val();
    var dptID = $("#dptID").val();
    var scno = $("#SCNO").val();
    var url = "/Indent/IndentDomestic/LookUp?FromDate=" + fromdate + "&ToDate=" + todate + "&IndentNO=" + indentNo + "&DeptID=" + dptID + "&SCNO=" + scno +"";//&ToDate=" + todate + "&IndentNO=" + indentNo + "&DeptID=" + dptID + "&SCNO=" + scno+"
    var table = $('#ContractTable').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
            { "data": "Id", "orderable": true },
            { "data": "IndentDate", "orderable": true},
            { "data": "IndentKey", "orderable": true },
            { "data": "Saller", "orderable": true },
            { "data": "CustomerBuyerName", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 5,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "";
                    var editurl = '\n <button type="button" class="btn btn-success" onclick="LoadContract(' + full.Id + ')">Load</button >\n';
                    return editurl;
                }
            },

        ]
    });
    table.columns(0).visible(true);
}
function LoadContract(id) {
    var url = "/Indent/IndentDomestic/LoadContract?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $("#CommodityId").val(data.CommodityId);
            $("#Commodity").val(data.CommodityName);
            $("#IndentId").val(data.IndId);
            $("#IndentKey").val(data.ContractKey);

            $("#CustomerIDasSeller").val(data.SellerId);
            $("#CustomerSellerName").val(data.SellerName);
            $("#CustomerIDasBuyer").val(data.BuyerId);
            $("#CustomerBuyerName").val(data.BuyerName);

            $('#IndentLookUpModal').modal('hide');

        }
    });
}

function ContractSelectionChanged() {
    debugger;
    var dropdown = document.getElementById('IndentId');
    var url = "/Indent/FabricInspection/GetDispatches?id=" + dropdown.value;
    var table = $('#DispatchesTable').DataTable({
        serverSide: false,
        destroy: true,
        processing: true,
        responsive: true,
        autoWidth: false,
        iDisplayLength: 10,
        dateLimit: 15,
        ajax: url,
        columns: [
            { "data": "date", "orderable": true },
            { "data": "quantity", "orderable": true },
            { "data": "commodity", "orderable": true }
        ],
        columnDefs: [
            {
                "targets": 3,
                "data": null,
                "orderable": true,
                "render": function (data, type, full, meta) {
                    var formateurl = "";
                    var editurl = '\n <button type="button" class="btn btn-success" onclick="LoadContract(' + full.Id + ')">Load</button >\n';
                    return editurl;
                }
            },

        ]
    });
    table.columns(0).visible(true);
    //var table = $('#DispatchesTable').DataTable({
    //    serverSide: false,
    //    destroy: true,
    //    processing: true,
    //    responsive: true,
    //    autoWidth: false,
    //    iDisplayLength: 10,
    //    dateLimit: 15,
    //    ajax: url,
    //    columns: [
    //        { "data": "date", "orderable": true },
    //        { "data": "quantity", "orderable": true },
    //        { "data": "commodity", "orderable": true }
    //    ],
    //    columnDefs: [
    //        {
    //            "targets": 3,
    //            "data": null,
    //            "orderable": true,
    //            "render": function (data, type, full, meta) {
    //                var formateurl = "/General/Brand/Edit/";
    //                var editurl = ' \n <span class="dropdown">\n <a href="#" class="btn btn-sm btn-danger dropdown-toggle" data-toggle="dropdown" aria-expanded="true"  >\n                              Action\n                            </a>\n                            <div class="dropdown-menu dropdown-menu-right">\n                                <a class="dropdown-item" href="#" onclick="OpenBrandModal(' + "'" + formateurl + full.Id + "'" + ')"  ><i class="la la-edit"></i> Edit</a>\n<a class="dropdown-item" href="#" onclick="DeleteBrand(' + full.Id + ')"  ><i class="la la-trash"></i> Delete</a>\n</div>\n</span>\n';
    //                return editurl;
    //            }
    //        }
    //    ]
    //});
    //table.columns(0).visible(true);
}
function DeleteIndentDomestic() {
    alert("IndentDomestic Deleted");
    $('#DeleteIndentDomestic').modal('show');
}

var IndentDomesticId = 0;
function DeleteIndentDomestic(id) {
    IndentDomesticId = id;
    var url = "/General/IndentDomestic/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndentDomesticTable();
        }
    });
}
function DeleteIndentDomesticConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/IndentDomestic/Delete?id=" + IndentDomesticId,
        success: function (data) {
            LoadIndentDomesticTable();
            $('#DeleteIndentDomestic').modal('hide');
        }
    });
}
function SubmitIndentDomesticForm() {
    var formData = new FormData($('#IndentDomesticForm')[0]);
    var url = $('#IndentDomesticForm').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                $('#IndentDomesticModal').modal('hide');
                LoadIndentDomesticTable();
            } else {
                $('#IndentDomesticModal').html(data);
                $('#IndentDomesticModal').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}

