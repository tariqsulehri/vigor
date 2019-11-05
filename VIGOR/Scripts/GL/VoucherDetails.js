Grider = {
    defaults: {
        initCalc: true, // Tells if it should do the calculations when init
        addRow: true, // Allow adding rows
        addRowWithTab: true, // Allow addign rows with tab when you are focused on the delete Row
        delRow: true, // Allows to delete a row
        decimals: 2, // Decimals used to calculate formulas and summaries
        //addRowText: '<caption><a href="javascript:" class= "delete btn btn-info" ><i class="fa fa-plus"></i> Add New Row</a></caption>',
        delRowText: '<td class="tdpading"><a href="javascript:" class= "delete btn btn-danger calculateExpense" style="padding:0.35rem 1.0rem;color:#ffffff " ><i class="fa fa-trash"></i></a></td> ',
        // countRow: true,
        countRow: false, // Tells to count rows
        countRowCol: 0, // Tells to add the column for counting rows
        countRowText: '#', // The text in the header for the count column
        countRowAdd: false,
        addedRow: false
    }
}
$('#detailGrid,.detailGrid').grider({ countRow: true, countRowAdd: true });

function getDebitOrCredit(name) {
    var uniqueName = parseInt(name.match(/[0-9]+/)[0], 10);
    var nameDebit = "det[" + uniqueName + "][Debit]";
    var nameCredit = "det[" + uniqueName + "][Credit]";
    if (name === nameDebit && $('input[name="' + nameDebit + '"]').val() !== "") {
        $('input[name="' + nameCredit + '"]').val("");
        $('input[name="' + nameCredit + '"]').prop("disabled", true);
    }
    else if (name === nameDebit && $('input[name="' + nameDebit + '"]').val() === "") {
        $('input[name="' + nameCredit + '"]').prop("disabled", false);
    }
    else if (name === nameCredit && $('input[name="' + nameCredit + '"]').val() !== "") {
        $('input[name="' + nameDebit + '"]').val("");
        $('input[name="' + nameDebit + '"]').prop("disabled", true);
    }
    else if (name === nameCredit && $('input[name="' + nameCredit + '"]').val() === "") {
        $('input[name="' + nameDebit + '"]').prop("disabled", false);

    }
}

function CustomeMessage(messagetype,message) {
    if (messagetype === "error") {
        toastr.error(message);
    }
    else if (messagetype === "save") { toastr.success(message); }
}