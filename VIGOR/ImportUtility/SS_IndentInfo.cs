namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_IndentInfo
    {
        [Key]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        [StringLength(25)]
        public string SellerContractNo { get; set; }

        public DateTime? SellerContractDate { get; set; }

        [StringLength(25)]
        public string PurchaseOrderNo { get; set; }

        [StringLength(20)]
        public string BuyerReferenceNo { get; set; }

        [StringLength(20)]
        public string foreignIndentNo { get; set; }

        public DateTime? foreignIndentDate { get; set; }

        [StringLength(4)]
        public string BrandCode { get; set; }

        [StringLength(250)]
        public string BasicFabric { get; set; }

        [StringLength(250)]
        public string BlendRatio { get; set; }

        [StringLength(250)]
        public string LoomType { get; set; }

        [StringLength(250)]
        public string FinishedWeight { get; set; }

        [StringLength(4)]
        public string PriceTermCode { get; set; }

        [StringLength(1000)]
        public string GoodsDes { get; set; }

        [StringLength(200)]
        public string ProductionSource { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GsmWeight { get; set; }

        [StringLength(3)]
        public string GsmUnit { get; set; }

        public DateTime? SampleSwatchDate { get; set; }

        public bool? SampleReceived { get; set; }

        public DateTime? FabricSampleReadyDate { get; set; }
    }
}
