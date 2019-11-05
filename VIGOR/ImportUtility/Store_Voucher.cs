namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_Voucher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store_Voucher()
        {
            Store_VoucherDetails = new HashSet<Store_VoucherDetails>();
        }

        [Key]
        [StringLength(15)]
        public string DocumentID { get; set; }

        [Required]
        [StringLength(9)]
        public string DocNo { get; set; }

        public DateTime DocDate { get; set; }

        [Required]
        [StringLength(1)]
        public string StoreDocID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [StringLength(12)]
        public string PoNo { get; set; }

        [StringLength(11)]
        public string SIRNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Freight { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SalesTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CustomerID { get; set; }

        [StringLength(6)]
        public string EmployeeId { get; set; }

        [StringLength(4)]
        public string Departmentid { get; set; }

        [Required]
        [StringLength(4)]
        public string userid_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        [StringLength(1)]
        public string IsPosted { get; set; }

        [StringLength(4)]
        public string Userid_as_PostedBy { get; set; }

        public DateTime? PostedOn { get; set; }

        [StringLength(18)]
        public string VoucherId { get; set; }

        [StringLength(1)]
        public string IsCashPurchase { get; set; }

        [StringLength(200)]
        public string Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_VoucherDetails> Store_VoucherDetails { get; set; }
    }
}
