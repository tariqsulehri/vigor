namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_DeparmentDealsIn
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string DepartmentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string CommodityType { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }
    }
}
