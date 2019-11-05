namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_IndentDetails
    {
        [Key]
        [StringLength(13)]
        public string SalesContractDetailID { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Required]
        [StringLength(6)]
        public string CommodityId { get; set; }

        [StringLength(500)]
        public string CommoditySpecification { get; set; }

        [Required]
        [StringLength(3)]
        public string UOSID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CommRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Stuffing { get; set; }

        [StringLength(4)]
        public string SizeCode { get; set; }

        [StringLength(5)]
        public string ColorCode { get; set; }

        [StringLength(20)]
        public string SupplierCode { get; set; }

        [StringLength(500)]
        public string SizeSpecifications { get; set; }

        [StringLength(4)]
        public string Design { get; set; }

        [StringLength(30)]
        public string DesignNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GSM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PerPieceWeight { get; set; }

        [StringLength(3)]
        public string PerPieceUnitWeight { get; set; }

        [StringLength(20)]
        public string Labdip { get; set; }

        [StringLength(5)]
        public string Lab_dip_option { get; set; }

        [StringLength(10)]
        public string LabdipDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WeightDispatched { get; set; }

        [StringLength(1)]
        public string TypeColor { get; set; }

        [StringLength(30)]
        public string FabricWidth { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QuantityReq { get; set; }

        [StringLength(2)]
        public string UnitQuantityReq { get; set; }

        [StringLength(20)]
        public string BarCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalValueOnCommRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExecutedQuantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ExecutedValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QtyPerFCL { get; set; }
    }
}
