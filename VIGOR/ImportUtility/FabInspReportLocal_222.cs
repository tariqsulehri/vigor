namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FabInspReportLocal-222")]
    public partial class FabInspReportLocal_222
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string InspectionSerialNoID { get; set; }

        [StringLength(20)]
        public string InspReportNo { get; set; }

        [StringLength(1)]
        public string ForMarket { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string Company { get; set; }

        [StringLength(10)]
        public string SalesContractNo { get; set; }

        public int? FabInspStandard { get; set; }

        [StringLength(1)]
        public string InspTypePerformed { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LoomType { get; set; }

        [StringLength(2)]
        public string TypeofFabric { get; set; }

        [StringLength(1)]
        public string InspectionStatus { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime InspectionDate { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string QcInspCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RollsInspected { get; set; }

        public int? BuyerAcceptablePoints { get; set; }

        public int? bb_ends { get; set; }

        public int? bb_picks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bb_width { get; set; }

        public int? bb_gsm { get; set; }

        public int? ab_ends { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ab_picks { get; set; }

        public int? ab_width { get; set; }

        public int? ab_gsm { get; set; }

        [StringLength(1000)]
        public string Remarks { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? width { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QuantityInspected { get; set; }

        public int? rollsAvailable { get; set; }

        [StringLength(1)]
        public string HeadBands { get; set; }

        [StringLength(1)]
        public string ShadeVariation { get; set; }

        [StringLength(1)]
        public string Stamped { get; set; }

        [StringLength(1)]
        public string ReedMarks { get; set; }

        [StringLength(1)]
        public string RubbingMarks { get; set; }

        [StringLength(1)]
        public string PolyYarn { get; set; }

        [StringLength(1)]
        public string Contamination { get; set; }

        [StringLength(1)]
        public string other { get; set; }

        public DateTime? firstinline { get; set; }

        public DateTime? secondinline { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TearingSWarp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TearingSWeft { get; set; }

        [StringLength(3)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(3)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
