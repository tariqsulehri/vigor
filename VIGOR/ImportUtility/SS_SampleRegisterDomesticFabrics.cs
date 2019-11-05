namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_SampleRegisterDomesticFabrics
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string SampleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [StringLength(6)]
        public string SalesContractDetail { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime SampleReceiveDate { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal Quantity { get; set; }

        public DateTime? SpecSheetOn { get; set; }

        [StringLength(20)]
        public string StorageNo { get; set; }

        [StringLength(5)]
        public string checkedby { get; set; }

        [StringLength(1)]
        public string Tally { get; set; }

        [StringLength(255)]
        public string Remarks { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(3)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_Modifiedby { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
