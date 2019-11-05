namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EFilingSystem")]
    public partial class EFilingSystem
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string EFilingID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string DocumentType { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TranType { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string FileDescription { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string FileAttached { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime CreatedOn { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(3)]
        public string Company { get; set; }

        [StringLength(20)]
        public string ReferenceID1 { get; set; }

        [StringLength(20)]
        public string ReferenceID2 { get; set; }
    }
}
