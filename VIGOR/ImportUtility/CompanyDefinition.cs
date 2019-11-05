namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CompanyDefinition")]
    public partial class CompanyDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyDefinition()
        {
            UserCompanies = new HashSet<UserCompany>();
        }

        [Key]
        [StringLength(3)]
        public string CompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(250)]
        public string MailingAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(1)]
        public string isDefault { get; set; }

        [StringLength(50)]
        public string TelephoneNo { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string WebSite { get; set; }

        [StringLength(2)]
        public string BusinessID { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? InActiveSince { get; set; }

        [StringLength(250)]
        public string LetterHeadFile { get; set; }

        [StringLength(250)]
        public string LetterHeadLegalFile { get; set; }

        [StringLength(250)]
        public string CompanyLogoFile { get; set; }

        public byte[] LetterHead { get; set; }

        public byte[] LetterHeadLegal { get; set; }

        public byte[] CompanyLogo { get; set; }

        [StringLength(2)]
        public string Abbreviation { get; set; }

        [StringLength(3)]
        public string LocalCurrecyID { get; set; }

        [StringLength(3)]
        public string ForeignCurrencyID { get; set; }

        [StringLength(6)]
        public string CustomerAsLocalAgent { get; set; }

        [StringLength(100)]
        public string VoucherPostKey { get; set; }

        [StringLength(100)]
        public string VoucherUnpostKey { get; set; }

        public virtual CC_BusinessNature CC_BusinessNature { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}
