namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApprovedSupplier
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string ASID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string Department { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string Commodity { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(3)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(6)]
        public string Customer { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IsApproved { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime ApprovedOn { get; set; }

        public DateTime? EvaluationConductedOn { get; set; }

        public DateTime? NextEvaluation { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(4)]
        public string UserId_CreatedBy { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime CreatedOn { get; set; }
    }
}
