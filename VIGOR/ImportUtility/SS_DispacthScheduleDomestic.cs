namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_DispacthScheduleDomestic
    {
        [Key]
        [StringLength(13)]
        public string LocalDispatchNo { get; set; }

        public DateTime TranDate { get; set; }

        public DateTime? ContractedDeliveryDate { get; set; }

        [StringLength(1)]
        public string TypeOfTransection { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [StringLength(13)]
        public string SalesContractDetail { get; set; }

        [StringLength(3)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [StringLength(4)]
        public string GoodsForwarder { get; set; }

        [StringLength(20)]
        public string BiltyNo { get; set; }

        [StringLength(20)]
        public string VehicleNo { get; set; }

        [StringLength(1)]
        public string IsReceivedStinv { get; set; }

        [StringLength(255)]
        public string SalestaxInvoiceNo { get; set; }

        public DateTime? SalestaxInvoiceDate { get; set; }

        [StringLength(1)]
        public string Isdelayed { get; set; }

        [StringLength(2)]
        public string DelayShipmentReason { get; set; }

        [StringLength(250)]
        public string DelayShipmentReasonDescription { get; set; }

        [StringLength(1)]
        public string IsComplaint { get; set; }

        [StringLength(1)]
        public string isFirstDispatch { get; set; }

        public bool? IsActive { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GrossAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GovtTaxes { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReceivableAfterTaxes { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IncomeTaxPercent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IncomeTaxAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetReceivable { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [StringLength(2)]
        public string LeadTimeDescription { get; set; }

        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ModfiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? IsInvoiced { get; set; }
    }
}
