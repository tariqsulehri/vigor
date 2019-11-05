namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Allowances
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string AllowanceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string SubType { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string TaxStatus { get; set; }

        [StringLength(1)]
        public string ApplyOn { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(3)]
        public string Userid_as_CreatedBy { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime CreatedOn { get; set; }

        [StringLength(3)]
        public string UserID_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
