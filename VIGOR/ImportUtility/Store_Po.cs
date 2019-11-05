namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_Po
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store_Po()
        {
            Store_PoDetails = new HashSet<Store_PoDetails>();
        }

        [Key]
        [StringLength(12)]
        public string PoNo { get; set; }

        public DateTime PoDate { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string PaymentTerm { get; set; }

        [Required]
        [StringLength(100)]
        public string DeliveryTerm { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(1)]
        public string isClosed { get; set; }

        [StringLength(1)]
        public string isApproved { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TotalAmount { get; set; }

        public DateTime? CompletedOn { get; set; }

        [Required]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_modifiedon { get; set; }

        public DateTime? modifiedOn { get; set; }

        public virtual GL_COA GL_COA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_PoDetails> Store_PoDetails { get; set; }
    }
}
