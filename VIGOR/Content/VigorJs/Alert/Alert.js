var SweetAlert2Demo = {
    init: function () {
       $('.m_sweetalert_demo_5').click(function (e) {
            //  var pageURL = $("#view").attr("href");
            // var key = pageURL.substring(pageURL.lastIndexOf('=') + 1);
            // var PostURL = '/GL/CommonGL/PostVoucher?PostURL"' + key+'"';
            swal({
                title: "Are you sure to post this voucher!",
                text: "Please clicked View button for view voucher!",
                icon: "success",
                confirmButtonText: "<span><a href='' style='color:white'><i class='la la-unlock'></i>Post</a></span>",
                confirmButtonClass: "btn btn-danger m-btn m-btn--pill m-btn--air m-btn--icon",
                showCancelButton: !0,
                cancelButtonText: " <a href=''  style='color:black' id='dtview'><i class='la la-eye'></i> View</a>",
                cancelButtonClass: "btn btn-secondary m-btn m-btn--pill m-btn--icon"
            });
        });
    }
};
jQuery(document).ready(function () {
    SweetAlert2Demo.init();
});

function postdialogue() {
    //  var pageURL = $("#view").attr("href");
    // var key = pageURL.substring(pageURL.lastIndexOf('=') + 1);
    // var PostURL = '/GL/CommonGL/PostVoucher?PostURL"' + key+'"';
    swal({
        title: "Are you sure to post this voucher!",
        text: "Please clicked View button for view voucher!",
        icon: "success",
        confirmButtonText: "<span><a href='' style='color:white'><i class='la la-unlock'></i>Post</a></span>",
        confirmButtonClass: "btn btn-danger m-btn m-btn--pill m-btn--air m-btn--icon",
        showCancelButton: !0,
        cancelButtonText: " <a href=''  style='color:black' id='dtview'><i class='la la-eye'></i> View</a>",
        cancelButtonClass: "btn btn-secondary m-btn m-btn--pill m-btn--icon"
    });
};