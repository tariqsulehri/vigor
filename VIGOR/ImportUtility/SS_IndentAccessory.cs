namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_IndentAccessory
    {
        [Key]
        [StringLength(13)]
        public string AccessorySeqNo { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Required]
        [StringLength(5)]
        public string AccessoryCode { get; set; }

        [StringLength(200)]
        public string descriptionValue { get; set; }
    }
}
