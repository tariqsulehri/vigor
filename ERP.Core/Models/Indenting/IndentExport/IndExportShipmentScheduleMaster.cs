﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Core.Models.Indenting.IndentExport
{
    public class IndExportShipmentScheduleMaster
    {
        public int Id { get; set; }

        [Required]
        [StringLength(13)]
        public string ShipmentScheduleKey { get; set; }
        
        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractKey { get; set; }

        [StringLength(13)]
        public string SalesContractDetailKey { get; set; }

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

        public bool IsCancel { get; set; }

        public int companyid { get; set; }

        public DateTime? FabricSampleReadyDate { get; set; }

        [StringLength(7)]
        public string FollowupSheetRefNo { get; set; }

        public DateTime? EInspectionDate { get; set; }

        public DateTime? InlineOneInspectionDate { get; set; }

        public DateTime? InlinetwoInspectionDate { get; set; }

        public DateTime? FinalInspectionDate { get; set; }

        public DateTime? TentativeExmill { get; set; }

        public DateTime? TentativeETA { get; set; }
        
        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }


        public int UpdatedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime UpdatedOn { get; set; }


        public virtual ICollection<IndExportShipmentScheduleDetail> IndExportShipmentScheduleDetails { get; set; }

    }
}