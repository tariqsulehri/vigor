namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_PaymentTerms
    {
        [Key]
        [StringLength(4)]
        public string PaymentTermID { get; set; }

        [Required]
        [StringLength(200)]
        public string PaymentTermDescription { get; set; }

        public int MaturityDays { get; set; }

        [Required]
        [StringLength(4)]
        public string UserID_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserID_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
