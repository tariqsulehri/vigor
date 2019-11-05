namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FCTTExportSaleInvoice
    {
        [Key]
        [StringLength(13)]
        public string ESInvoiceID { get; set; }

        [Required]
        [StringLength(8)]
        public string FCTTAccountCode { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(1)]
        public string IsActive { get; set; }
    }
}
