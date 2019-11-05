using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Core.Models.Indenting.InspExport
{
    public class FabricInspReportExport
    {
        [Key]
        [StringLength(8)]
        public string InspectionSerialNoID { get; set; }

        public DateTime InspectionDate { get; set; }

        [Required]
        [StringLength(3)]
        public string company { get; set; }

        [ForeignKey("FabricType")]
        public int FabricTypeId { get; set; }
        public virtual FabricType FabricType { get; set; }

        //        [StringLength(2)]
        //        public string TypeofFabric { get; set; }

        [ForeignKey("FabricInspLoomType")]
        public int LoomTypeId { get; set; }
        public virtual FabricInspLoomType FabricInspLoomType { get; set; }

        [StringLength(20)]
        public string InspReportNo { get; set; }

        [Required]
        [StringLength(1)]
        public string ForMarket { get; set; }

        //[ForeignKey("IndentDomestic")]
        //public int IndentId { get; set; }
        //public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentExportKey { get; set; }

        [ForeignKey("IndDomesticDispatchSchedule")]
        public int ShipmentScheduleId { get; set; }
        public virtual IndDomesticDispatchSchedule IndDomesticDispatchSchedule { get; set; }

        [Required]
        [StringLength(13)]
        public string ShipmentScheduleKey { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? sr_no { get; set; }

        [ForeignKey("FabricInspStandard")]
        public int FabInspStandardId { get; set; }
        public virtual FabricInspStandard FabricInspStandard { get; set; }

        [StringLength(1)]
        public string FabInspRepFormat { get; set; }

        [StringLength(1)]
        public string InspCalculationBasedOn { get; set; }

        [ForeignKey("FabInspTypePerformed")]
        [StringLength(1)]
        public string InspTypePerformed { get; set;}
        public virtual FabInspTypePerformed FabInspTypePerformed { get; set;}

        [ForeignKey("FabricInspStatus")]
        public int InspectionStatusId { get; set; }
        public virtual FabricInspStatus FabricInspStatus { get; set; }

        public int? BuyerAcceptablePoints { get; set; }

        [Required]
        [StringLength(4)]
        public string QcInspCode { get; set; }

        public int RollsInspected { get; set; }

        public int? bb_ends { get; set; }

        public int? bb_picks { get; set; }

        public double? bb_width { get; set; }

        public int? bb_gsm { get; set; }

        public int? ab_ends { get; set; }

        public double? ab_picks { get; set; }

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

        [Column(TypeName = "numeric")]
        public decimal? Shrinkage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PieceRatioLong { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PieceRatioShort { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PolyPropline { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Cockled { get; set; }

        [StringLength(1)]
        public string BuyerSampleStatus { get; set; }

        [StringLength(1)]
        public string BuyerSampleDesign { get; set; }

        [StringLength(10)]
        public string SelvedgeWeave { get; set; }

        [StringLength(20)]
        public string SelvedgeIdentify { get; set; }

        [StringLength(20)]
        public string SelvedgeBindingWith { get; set; }

        [StringLength(10)]
        public string SelvedgeSize { get; set; }

        [StringLength(50)]
        public string YarnSupplyWarp { get; set; }

        [StringLength(50)]
        public string YarnSupplyWeft { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalEnds { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReedCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReedSapce { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EndsPerDent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PickInsertion { get; set; }

        [StringLength(1)]
        public string PackingList { get; set; }

        [StringLength(1)]
        public string Marking { get; set; }

        [StringLength(1)]
        public string FaceMarking { get; set; }

        [StringLength(1)]
        public string PackingCondition { get; set; }

        [StringLength(50)]
        public string WrappingDirection { get; set; }

        [StringLength(1)]
        public string ShipmentSample { get; set; }

        [StringLength(50)]
        public string CamDirection { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NumberofLooms { get; set; }
    }
}
