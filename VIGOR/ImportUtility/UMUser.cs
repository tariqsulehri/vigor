namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UMUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UMUser()
        {
            UserCompanies = new HashSet<UserCompany>();
        }

        [Key]
        [StringLength(4)]
        public string UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string UserDescription { get; set; }

        [Required]
        [StringLength(15)]
        public string LoginID { get; set; }

        [Required]
        [StringLength(40)]
        public string LoginPassword { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(1)]
        public string IsFirstLogin { get; set; }

        [StringLength(1)]
        public string UserMustChangePassword { get; set; }

        [StringLength(1)]
        public string PasswordNeverExpire { get; set; }

        public DateTime? PasswordExipreDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? Modifiedon { get; set; }

        public DateTime? DeactivateSince { get; set; }

        public DateTime? SuspendedSince { get; set; }

        public DateTime? PasswordLastModified { get; set; }

        [StringLength(2)]
        public string RoleId { get; set; }

        public bool? IsAdmin { get; set; }

        [StringLength(1)]
        public string IncludeCEO { get; set; }

        public bool? isMR { get; set; }

        public virtual UMRole UMRole { get; set; }

        public virtual UMProfile UMProfile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}
