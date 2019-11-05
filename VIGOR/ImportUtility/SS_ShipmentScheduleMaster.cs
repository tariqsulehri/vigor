namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_ShipmentScheduleMaster
    {
        [Key]
        [StringLength(13)]
        public string ShipmentScheduleId { get; set; }

        [StringLength(13)]
        public string SalesContractDetailID { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Required]
        [StringLength(2)]
        public string Fcl { get; set; }

        [StringLength(2)]
        public string TotalFcls { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShippedQuantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShippedWeight { get; set; }

        [StringLength(10)]
        public string InspSrNo { get; set; }

        [StringLength(12)]
        public string LcSerialNo { get; set; }

        public bool DocumentReceived { get; set; }

        public bool DocumentConfirmed { get; set; }

        public bool DocumentFaxed { get; set; }

        public DateTime? SellerContractedShipmentDate { get; set; }

        [StringLength(40)]
        public string SellerContractedShipmentDateRemarks { get; set; }

        public DateTime? BuyerContractedShipmentDate { get; set; }

        [StringLength(40)]
        public string BuyerContractedShipmentDateRemarks { get; set; }

        public DateTime? ExmillDate1 { get; set; }

        public DateTime? ExmillDate2 { get; set; }

        public DateTime? ExmillDate3 { get; set; }

        public DateTime? ETDate1 { get; set; }

        public DateTime? ETDate2 { get; set; }

        public DateTime? ETDate3 { get; set; }

        public DateTime? ActualExMillDate { get; set; }

        public DateTime? ActualETADate { get; set; }

        public DateTime? ActualETDate { get; set; }

        [StringLength(4)]
        public string ShippingLineId { get; set; }

        [StringLength(50)]
        public string ContainerNo { get; set; }

        [StringLength(50)]
        public string DestinationPort { get; set; }

        [StringLength(50)]
        public string VesselName { get; set; }

        [StringLength(2)]
        public string ShipmentStatus { get; set; }

        [StringLength(500)]
        public string ShipmentRemarks { get; set; }

        [StringLength(1)]
        public string ComplaintCode { get; set; }

        [StringLength(500)]
        public string ComplaintRemarks { get; set; }

        public bool Reject { get; set; }

        [StringLength(1)]
        public string InspectionRemarks { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        public int? TransentPeriod { get; set; }

        [StringLength(10)]
        public string InvoiceNo { get; set; }

        public DateTime? duedate { get; set; }

        public DateTime? InspectionDateFab { get; set; }

        [StringLength(2)]
        public string LeadTimeDescriptionID { get; set; }

        [StringLength(2)]
        public string DelayShipmentReasonID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShortPiece { get; set; }

        [StringLength(1)]
        public string ProductionStatus { get; set; }

        [StringLength(255)]
        public string ProductionRemarks { get; set; }

        [StringLength(30)]
        public string BLNo { get; set; }

        public DateTime? BLDate { get; set; }

        [StringLength(30)]
        public string SuplierReferenceNo { get; set; }

        [Required]
        [StringLength(4)]
        public string UserID_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_RevisedBy { get; set; }

        public DateTime? Revisedon { get; set; }

        [StringLength(4)]
        public string UserId_as_UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool IsCancel { get; set; }

        [StringLength(3)]
        public string companyid { get; set; }

        public DateTime? FabricSampleReadyDate { get; set; }

        [StringLength(7)]
        public string FollowupSheetRefNo { get; set; }

        public DateTime? EInspectionDate { get; set; }

        public DateTime? InlineOneInspectionDate { get; set; }

        public DateTime? InlinetwoInspectionDate { get; set; }

        public DateTime? FinalInspectionDate { get; set; }

        public DateTime? TentativeExmill { get; set; }

        public DateTime? TentativeETA { get; set; }
    }
}
