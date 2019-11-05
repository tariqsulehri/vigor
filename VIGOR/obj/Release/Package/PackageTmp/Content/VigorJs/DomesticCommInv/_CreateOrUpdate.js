
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
function GetDetails(isclosed,contractNo) {
    var dateFrom = $("#fromDate").val();
    var dateTo = $("#toDate").val();
    var url = "/Indent/DomesticCommInv/GetDetails?isClosed=" + isclosed + "&contractNo=" + contractNo + "&dateFrom=" + dateFrom + "&dateTo=" + dateTo;

    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#commDiv').html(data); 
            $('#commDivvvv').remove(); 
        }
    });
}
function OpenLookUpModal(url) {
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
    var status = $("#status").val();
    var url = "/Indent/DomesticCommInv/LookUp?FromDate=" + fromdate + "&ToDate=" + todate + "&IndentNO=" + indentNo + "&DeptID=" + dptID + "&SCNO=" + scno +"&status="+status+"";//&ToDate=" + todate + "&IndentNO=" + indentNo + "&DeptID=" + dptID + "&SCNO=" + scno+"
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
                    var editurl = '\n <button type="button" class="btn btn-success" onclick="LoadData(' + full.Id + ')">Select</button >\n';
                    return editurl;
                }
            }
        ]
    });
    table.columns(0).visible(true);
}
function SalesTaxChanged() {
    
    var SalesTaxRate = document.getElementById('SalesTaxRate');
    var total = document.getElementById('total');
    var sales = document.getElementById('sales');
    var CalculatedCommissionValue = document.getElementById('CalculatedCommissionValue');
    var NetCalculatedCommissionValue = document.getElementById('NetCalculatedCommissionValue');
    //var cartItems = [];
    //$("#m_table_Inv_2 tbody tr").each(function () {
    //    var cartTableItemList = {
    //        salesTax: $('.salesTax', this).val()
    //    };
    //    cartItems.push(cartTableItemList);
    //});
    //cartItems[0].salesTax = (total.value * SalesTaxRate.value / 100);
    sales.value = (Number(CalculatedCommissionValue.value) * SalesTaxRate.value / 100);
    NetCalculatedCommissionValue.value = Number(sales.value) + Number(CalculatedCommissionValue.value);
}
function LoadData(id) {
    var url = "/Indent/DomesticCommInv/LoadData?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
          
            $('#IndentLookUpModal').modal('hide');
            $('#commissionInv').html(data);
        }
    });
}



function DeleteIndentDomestic() {
    alert("IndentDomestic Deleted");
    $('#DeleteIndentDomestic').modal('show');
}

var IndentDomesticId = 0;
function DeleteIndentDomestic(id) {
    IndentDomesticId = id;
    var url = "/General/DomesticCommInv/Delete?id=" + id;
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            LoadIndentDomesticTable();
        }
    });LoadIndentDomesticTable
}
function DeleteIndentDomesticConfirm() {
    $.ajax({
        type: "POST",
        url: "/General/DomesticCommInv/Delete?id=" + IndentDomesticId,
        success: function (data) {
            
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

