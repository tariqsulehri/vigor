namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_BusinessNature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CC_BusinessNature()
        {
            CompanyDefinitions = new HashSet<CompanyDefinition>();
        }

        [Key]
        [StringLength(2)]
        public string BusinessID { get; set; }

        [Required]
        [StringLength(50)]
        public string BusinessDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyDefinition> CompanyDefinitions { get; set; }
    }
}
