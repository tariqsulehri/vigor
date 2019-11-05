namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_IndentCommission
    {
        [Key]
        [StringLength(13)]
        public string SalesContractCommID { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Required]
        [StringLength(6)]
        public string CustomerIdCommPaidTo { get; set; }

        [Required]
        [StringLength(6)]
        public string CustomerIdCommPaidFrom { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CommissionRate { get; set; }

        [Required]
        [StringLength(1)]
        public string CommissionType { get; set; }

        public bool IsinLocalCurrecncy { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CommissionValue { get; set; }

        [Required]
        [StringLength(20)]
        public string Remarks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CalculatedCommissionValue { get; set; }

        [StringLength(3)]
        public string CompanyId { get; set; }

        [StringLength(500)]
        public string TTRoutingInstructions { get; set; }

        public bool? IsPrintable { get; set; }
    }
}
