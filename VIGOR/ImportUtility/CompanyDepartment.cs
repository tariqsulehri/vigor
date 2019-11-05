namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyDepartment
    {
        [Key]
        [StringLength(4)]
        public string DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string DeptDescription { get; set; }

        [StringLength(50)]
        public string DeptHead { get; set; }

        [StringLength(100)]
        public string DeptEmailAddress { get; set; }

        [StringLength(1)]
        public string isActve { get; set; }

        [StringLength(1)]
        public string DeptNature { get; set; }

        [StringLength(1)]
        public string MarketNature { get; set; }

        [StringLength(1)]
        public string ScheduleType { get; set; }

        [StringLength(2)]
        public string ContractAbbreviation { get; set; }

        public DateTime? DeptCreatedOn { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        public DateTime? DeptInActiveSince { get; set; }

        [StringLength(1)]
        public string RequireAllColumns { get; set; }

        public int? SalesCommissionAccount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FCSalesCommissionAccount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BadDebtAccount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ClaimAccount { get; set; }

        [StringLength(1)]
        public string ShowQtyinBVolume { get; set; }

        [StringLength(2)]
        public string StandardUnit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValidShipmentDelayDays { get; set; }
    }
}
