namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_SIR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store_SIR()
        {
            Store_SIRDetail = new HashSet<Store_SIRDetail>();
        }

        [Key]
        [StringLength(12)]
        public string SIRNo { get; set; }

        public DateTime SIRDate { get; set; }

        [StringLength(4)]
        public string FiscalYear { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }

        [Required]
        [StringLength(4)]
        public string Department { get; set; }

        [Required]
        [StringLength(5)]
        public string RequiredBy { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [Required]
        [StringLength(150)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string isApproved { get; set; }

        [Required]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(1)]
        public string IsClosed { get; set; }

        public DateTime? ClosedOn { get; set; }

        [StringLength(150)]
        public string ClosingRemarks { get; set; }

        public virtual HR_Employee HR_Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_SIRDetail> Store_SIRDetail { get; set; }
    }
}
