namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SupplierEvaluationForm
    {
        [Key]
        [StringLength(8)]
        public string EvaluationFormID { get; set; }

        public DateTime EvaluationDate { get; set; }

        [Required]
        [StringLength(6)]
        public string Customer { get; set; }

        [Required]
        [StringLength(4)]
        public string Department { get; set; }

        [StringLength(2)]
        public string SuppEvalform { get; set; }

        public DateTime? EvaluationConductedFrom { get; set; }

        public DateTime? EvaluationConductedTo { get; set; }

        public DateTime? NextReview { get; set; }

        [StringLength(50)]
        public string informationProvidedBy { get; set; }

        public DateTime? InformationprovidedDated { get; set; }

        [StringLength(5)]
        public string FormFilledBy { get; set; }

        [StringLength(500)]
        public string RemarksByDeptManager { get; set; }

        [StringLength(1)]
        public string IsApproved { get; set; }
    }
}
