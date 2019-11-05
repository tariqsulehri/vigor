namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_DomesticSaleEFiling
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string EfilingCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string DocumentType { get; set; }

        [StringLength(3)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string SaleContractNo { get; set; }

        [StringLength(13)]
        public string LocalDispatchNo { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string FileDescription { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string FileAttached { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(1)]
        public string DocFileType { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime CreatedOn { get; set; }
    }
}
