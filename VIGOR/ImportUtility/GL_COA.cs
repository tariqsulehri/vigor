namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_COA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GL_COA()
        {
            Gl_InvoiceBalances = new HashSet<Gl_InvoiceBalances>();
            GL_VoucherDetails = new HashSet<GL_VoucherDetails>();
            PNLTemplates = new HashSet<PNLTemplate>();
            Store_Po = new HashSet<Store_Po>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        public decimal AccountID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [StringLength(2)]
        public string BookTypeID { get; set; }

        public int AccountFamilyID { get; set; }

        [Required]
        [StringLength(50)]
        public string AccountCode { get; set; }

        [Required]
        [StringLength(120)]
        public string AccountTitle { get; set; }

        public int? ParentID { get; set; }

        [StringLength(50)]
        public string ParentAccount { get; set; }

        public int LevelOfAccount { get; set; }

        public bool IsTransectionLevel { get; set; }

        public bool IsActive { get; set; }

        public bool? isLinked { get; set; }

        [Required]
        [StringLength(4)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ChildAccounts { get; set; }

        public bool? MustAttachLocation { get; set; }

        public bool? MustAttachDepartment { get; set; }

        public bool? MustAttachEmployee { get; set; }

        public bool? MustAttachCustomer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gl_InvoiceBalances> Gl_InvoiceBalances { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GL_VoucherDetails> GL_VoucherDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PNLTemplate> PNLTemplates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Store_Po> Store_Po { get; set; }
    }
}
