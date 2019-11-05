namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_LcDetails
    {
        [Key]
        [StringLength(12)]
        public string LcSerialNo { get; set; }

        [StringLength(3)]
        public string CompanyId { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Required]
        [StringLength(20)]
        public string LcNo { get; set; }

        public DateTime LcDate { get; set; }

        public DateTime? LastShipmentDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LcAmount { get; set; }

        [Required]
        [StringLength(3)]
        public string CurrencyID { get; set; }

        public bool IsCommissionDeducted { get; set; }

        public bool? LCContainedExcessAmount { get; set; }

        [StringLength(4)]
        public string userid_as_CreatedBy { get; set; }

        public DateTime? createdon { get; set; }

        [StringLength(4)]
        public string userid_as_modifiedby { get; set; }

        public DateTime? modifiedon { get; set; }
    }
}
