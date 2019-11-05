namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_IndentMaster
    {
        [Key]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        public DateTime SalesContractDate { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyId { get; set; }

        public DateTime? OfferDate { get; set; }

        public DateTime? ConfirmDate { get; set; }

        [Required]
        [StringLength(1)]
        public string IndentTypeId { get; set; }

        [Required]
        [StringLength(2)]
        public string CommodityType { get; set; }

        public bool? IsSample { get; set; }

        [StringLength(13)]
        public string InquiryNo { get; set; }

        [Required]
        [StringLength(4)]
        public string DepartmentID { get; set; }

        public int? CommodityGroups { get; set; }

        [Required]
        [StringLength(6)]
        public string CustomerIDasSeller { get; set; }

        [Required]
        [StringLength(6)]
        public string CustomerIDasBuyer { get; set; }

        [Required]
        [StringLength(6)]
        public string CustomerIDasLocalAgent { get; set; }

        [StringLength(4)]
        public string PaymentTermID { get; set; }

        [Required]
        [StringLength(3)]
        public string CurrencyID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExchangeRate { get; set; }

        [StringLength(10)]
        public string QuantityVariance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TotalValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalValueOnCommRate { get; set; }

        [StringLength(1500)]
        public string PackingRemarks { get; set; }

        [StringLength(1500)]
        public string DeliveryRemarks { get; set; }

        [StringLength(1000)]
        public string DeliveryRemarksBuyer { get; set; }

        [StringLength(2000)]
        public string GeneralRemarks { get; set; }

        [StringLength(1500)]
        public string SpecialConditions { get; set; }

        [StringLength(1000)]
        public string SpecialConditionsForSeller { get; set; }

        [StringLength(1000)]
        public string SpecialConditionsForBuyer { get; set; }

        [StringLength(1500)]
        public string PieceLength { get; set; }

        [StringLength(1500)]
        public string QualityRemarks { get; set; }

        [StringLength(1500)]
        public string FinancialRemarks { get; set; }

        [StringLength(1500)]
        public string Specificatiions { get; set; }

        [StringLength(200)]
        public string PriceTerm { get; set; }

        [StringLength(150)]
        public string Destination { get; set; }

        [StringLength(1)]
        public string IndentStatus { get; set; }

        [StringLength(200)]
        public string CottonSource { get; set; }

        [StringLength(50)]
        public string CostingSheetRef { get; set; }

        public bool Nodespatch { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(4)]
        public string UserID_as_CreatedBy { get; set; }

        [StringLength(1)]
        public string isUpdated { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_UpdatedBy { get; set; }

        public int? RevisionNo { get; set; }

        [StringLength(1000)]
        public string ClosingRemarks { get; set; }

        [StringLength(1)]
        public string IsClosed { get; set; }

        public DateTime? ClosedDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExecutedTotalValue { get; set; }

        public bool? IsScheduleGenerated { get; set; }

        public DateTime? DelDateValidUpto { get; set; }

        [StringLength(1)]
        public string IsApproved { get; set; }

        public DateTime? LastApprovedOn { get; set; }

        [StringLength(4)]
        public string ApprovedBy { get; set; }

        [StringLength(5)]
        public string MarketedBy { get; set; }

        [StringLength(1)]
        public string IsSubmitForApproval { get; set; }
    }
}
