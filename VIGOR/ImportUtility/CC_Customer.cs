namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Customer
    {
        [Key]
        [StringLength(6)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(150)]
        public string CustomerFullName { get; set; }

        [Required]
        [StringLength(150)]
        public string CompanyName { get; set; }

        [StringLength(4)]
        public string ReferedBy { get; set; }

        [StringLength(250)]
        public string MailingAddress { get; set; }

        [StringLength(4)]
        public string City { get; set; }

        [StringLength(4)]
        public string Country { get; set; }

        [StringLength(250)]
        public string DispatchAddress { get; set; }

        [StringLength(250)]
        public string EmailAddress { get; set; }

        [StringLength(150)]
        public string WebPage { get; set; }

        public bool IsAgent { get; set; }

        public bool IsSupplier { get; set; }

        public bool IsBuyer { get; set; }

        public bool? IsDomesticCustomer { get; set; }

        public bool? IsInternationalCustomer { get; set; }

        [StringLength(25)]
        public string NTNNo { get; set; }

        [StringLength(25)]
        public string GSTNo { get; set; }

        public bool? IsActive { get; set; }

        [Required]
        [StringLength(4)]
        public string UserID_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserID_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
