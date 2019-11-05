namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CpaNcType")]
    public partial class CpaNcType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CpaNcType()
        {
            Cpas = new HashSet<Cpa>();
        }

        [Key]
        [Column("CPaNcType")]
        [StringLength(1)]
        public string CPaNcType1 { get; set; }

        [Required]
        [StringLength(150)]
        public string CpaNcName { get; set; }

        public int? CPAFindingID { get; set; }

        public int? CPAFindingNatureID { get; set; }

        public int? CPAFindingNCTypeID { get; set; }

        public int? CPAFindingNCTypeSubID { get; set; }

        [StringLength(1)]
        public string isCustomerComplaint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cpa> Cpas { get; set; }
    }
}
