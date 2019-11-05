namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_ShippingLines
    {
        [Key]
        [StringLength(4)]
        public string ShippingLineId { get; set; }

        [Required]
        [StringLength(100)]
        public string ShippingLineFullName { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
