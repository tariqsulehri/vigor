namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_DomesticPaymentAddonTemplate
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string DeparmentCode { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal SerialNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string DomesticPaymentAddon { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal Amount { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string AddonType { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(1)]
        public string AddonEffect { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal TotalValue { get; set; }

        [StringLength(2)]
        public string DomesticPaymentAddonCalculatedOn { get; set; }
    }
}
