//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VIGOR.ViewsModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class view_IndDomestic_inquiry_sheet
    {
        public string InquiryKey { get; set; }
        public int InquiryID { get; set; }
        public string Delivery { get; set; }
        public string Remarks { get; set; }
        public int PaymenTermsId { get; set; }
        public string Description { get; set; }
        public int InqReviewQuestionId { get; set; }
        public string InquiryReviewQuestion { get; set; }
        public bool Status { get; set; }
        public string IndentKey { get; set; }
        public System.DateTime IndentDate { get; set; }
        public decimal Rate { get; set; }
        public int CustomerIDasBuyer { get; set; }
        public string buyer { get; set; }
        public int CustomerIDasSeller { get; set; }
        public string seller { get; set; }
        public System.DateTime InquiryDate { get; set; }
        public string InquiryStatus { get; set; }
        public string IsClosed { get; set; }
        public Nullable<System.DateTime> InquiryClosedDate { get; set; }
        public string Product { get; set; }
        public string UOS { get; set; }
        public decimal Quantity { get; set; }
    }
}
