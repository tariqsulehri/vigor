namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_IndentInspection
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(11)]
        public string InspSrno { get; set; }

        [StringLength(13)]
        public string SalesContractDetail { get; set; }

        [StringLength(2)]
        public string CommodityType { get; set; }

        [StringLength(13)]
        public string LocalDispatchNo { get; set; }
    }
}
