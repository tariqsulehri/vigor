$("#m_tabs_1_6").on('click', function () {
    $('#img').show();
    var tabID = this.id;
    OpenTabContent(tabID)
})
function OpenTabContent(tabContent) {
    var url = '';
    if (tabContent === 'm_tabs_1_6') {
        url = '/Misc/BusinessVolume/Approvals'
    }
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#img').hide();
            $('#tabContent').html(data);

        }
    });
}

function OpenBusinessVolumeModule(url) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (data) {
            $('#BusinessVolumeModel').html(data);
            $('#BusinessVolumeModel').modal('show');
        }
    });
}

function SubmitContractApprovedForm() {
    var formData = new FormData($('#ContractApproved')[0]);
    var url = $('#ContractApproved').attr('action');
    $.ajax({
        url: url,
        type: "POST",
        data: formData,
        async: false,
        success: function (data) {
            if (data === null || data === undefined || data === '') {
                OpenTabContent('m_tabs_1_6');
                $('#BusinessVolumeModel').modal('hide');
                
            } else {
                $('#BusinessVolumeModel').html(data);
                $('#BusinessVolumeModel').modal('show');
            }
        },
        cache: false,
        contentType: false,
        processData: false
    });
}