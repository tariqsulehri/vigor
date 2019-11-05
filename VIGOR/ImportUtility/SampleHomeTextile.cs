namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SampleHomeTextile
    {
        [Key]
        [StringLength(12)]
        public string SampleID { get; set; }

        public DateTime SampleReceiveDate { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Required]
        [StringLength(13)]
        public string SalesContractDetailID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Required]
        [StringLength(30)]
        public string StoredAt { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }

        [Required]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_Modifiedby { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
