namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class YarnInspectionsUsterSetting
    {
        [Key]
        [StringLength(11)]
        public string InspectionSerialID { get; set; }

        [StringLength(2)]
        public string UsterResultTypeId { get; set; }

        public decimal? Value { get; set; }
    }
}
