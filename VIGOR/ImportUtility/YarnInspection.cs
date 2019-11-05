namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YarnInspection
    {
        [Key]
        [StringLength(11)]
        public string InspectionSerialID { get; set; }

        [StringLength(1)]
        public string InspReportType { get; set; }

        [Required]
        [StringLength(1)]
        public string InspectionForMarket { get; set; }

        [StringLength(1)]
        public string InspectionGrade { get; set; }

        [StringLength(13)]
        public string ShipmentScheduleId { get; set; }

        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [StringLength(13)]
        public string SalesContractDetailID { get; set; }

        [Required]
        [StringLength(15)]
        public string RegisterNo { get; set; }

        public DateTime InspectionDate { get; set; }

        [StringLength(6)]
        public string CustomerID_as_Seller { get; set; }

        [StringLength(6)]
        public string CustomerID_as_Buyer { get; set; }

        [StringLength(6)]
        public string CommodityId { get; set; }

        [StringLength(10)]
        public string MillUnit { get; set; }

        [StringLength(6)]
        public string FCL { get; set; }

        [StringLength(4)]
        public string QcInspector { get; set; }

        public decimal? AvgBagWeight { get; set; }

        public DateTime? ProductionStartDate { get; set; }

        public DateTime? ProductionDate { get; set; }

        [StringLength(20)]
        public string PConeColour { get; set; }

        public decimal? tm { get; set; }

        public decimal? CrPolyester { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CrCotton { get; set; }

        [StringLength(15)]
        public string PolyFiber { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PolyDenier { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PolyLength { get; set; }

        [StringLength(15)]
        public string PolyColour { get; set; }

        [StringLength(25)]
        public string CottonArea { get; set; }

        [StringLength(25)]
        public string CottonCountry { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CottonSlength { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CottonUr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CottonFFi { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CottonStrength { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CottonMic { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CottonMicRange { get; set; }

        [StringLength(15)]
        public string CottonGrade { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CottonLots { get; set; }

        [StringLength(15)]
        public string CottonColour { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CottonTrash { get; set; }

        [Required]
        [StringLength(1)]
        public string ResultInputType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingActualCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingCv { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingStr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingCvStr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingClsp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingRkm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingCvbOfU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingThin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingThick { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingNeps { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingIPI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingHairiness { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RingElongation { get; set; }

        public bool? ContainAutoConeResult { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeActualCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeCV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeStr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? aconeCvStr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeClsp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeRkm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeCvbOfU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeThin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeThick { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeNeps { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeIPI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeHairiness { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AconeElongation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedActualCount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedCv { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedStr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedCvStr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedClsp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedRkm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedCvbOfU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedThin { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedThick { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedNeps { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedIPI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedHairiness { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PackedElongation { get; set; }

        [StringLength(20)]
        public string Lotno { get; set; }

        [StringLength(10)]
        public string Shade { get; set; }

        [StringLength(10)]
        public string bstrips { get; set; }

        [StringLength(10)]
        public string moisture { get; set; }

        [StringLength(10)]
        public string yarnlength { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        public bool? ContainAttachments { get; set; }

        public bool? ContainDispatches { get; set; }

        [StringLength(4)]
        public string userid_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? Modifiedon { get; set; }
    }
}
