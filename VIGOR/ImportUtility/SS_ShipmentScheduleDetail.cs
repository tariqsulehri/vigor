namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_ShipmentScheduleDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string ShipmentScheduleId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string SalesContractDetailID { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        [StringLength(3)]
        public string UOSID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QuantityDispatched { get; set; }

        public int? Bale_RoleNo { get; set; }

        [StringLength(1)]
        public string InspStatus { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ShipmentAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalWeight { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WeightDiff { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetWeight { get; set; }
    }
}
