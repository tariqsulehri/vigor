  function SubmitAllowanceForm() {
        
}

  $(document).ready(function() {
      $('#btnSave').click(function() {
          var formData = new FormData($('#AllowanceForm')[0]);
          var url = $('#AllowanceForm').attr('action');
          $.ajax({
              url: url,
              type: "POST",
              data: formData,
              async: false,
              success: function (data) {
                  if (data === null || data === undefined || data === '') {
                      $('#AllowanceModal').modal('hide');
                      LoadCityTable();
                  } else {
                      $('#AllowanceModal').html(data);
                      $('#AllowanceModal').modal('show');
                  }
              },
              cache: false,
              contentType: false,
              processData: false
          });
      });
      
  });
