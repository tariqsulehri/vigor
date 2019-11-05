namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_Counter
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Regions { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PriceTerms { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PaymentTerms { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GeneralDesc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UnitOfMeasure { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UnitOfRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UnitOfSale { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Currency { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GoodsForwarder { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShippingLine { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DelayShipmentReason { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LeadTime { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CommodityType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Customers { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CustomerBrands { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Country { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? City { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Product { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Modules { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QualityControllers { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Designation { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Degree { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EmployeeNo { get; set; }
    }
}
