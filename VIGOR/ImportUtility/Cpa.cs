namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cpa
    {
        [Key]
        [StringLength(8)]
        public string CpaNo { get; set; }

        [Required]
        [StringLength(5)]
        public string ReportedBy { get; set; }

        [StringLength(4)]
        public string ReportByDepartment { get; set; }

        public DateTime ReportDate { get; set; }

        [Required]
        [StringLength(1)]
        public string CpaNcType { get; set; }

        [Required]
        [StringLength(1000)]
        public string Problem { get; set; }

        [Required]
        [StringLength(1)]
        public string CpaContain { get; set; }

        [StringLength(5)]
        public string CprAssignedTo { get; set; }

        [StringLength(4)]
        public string CprAssignedToDept { get; set; }

        [StringLength(1)]
        public string IsCpaRejected { get; set; }

        [StringLength(500)]
        public string CprRejected { get; set; }

        public DateTime? TargetDate { get; set; }

        [StringLength(5)]
        public string DeptManager { get; set; }

        [StringLength(1000)]
        public string RootCause { get; set; }

        [StringLength(2000)]
        public string CorrectiveAction { get; set; }

        [StringLength(1000)]
        public string PreventiveAction { get; set; }

        [StringLength(1)]
        public string cpataken { get; set; }

        [StringLength(1)]
        public string cpaEffective { get; set; }

        public DateTime? ActionCompletedDt { get; set; }

        [StringLength(2500)]
        public string Comments { get; set; }

        [StringLength(5)]
        public string CheckedBy { get; set; }

        public DateTime? CheckDate { get; set; }

        [StringLength(5)]
        public string ConfirmBy { get; set; }

        public DateTime? Confirmdate { get; set; }

        [StringLength(6)]
        public string Agentcode { get; set; }

        [StringLength(6)]
        public string BuyerCode { get; set; }

        [StringLength(6)]
        public string Sellercode { get; set; }

        [StringLength(10)]
        public string IndentNo { get; set; }

        [StringLength(1)]
        public string CpaClose { get; set; }

        public DateTime? CpaCloseDate { get; set; }

        [StringLength(1)]
        public string CpaProved { get; set; }

        [StringLength(1)]
        public string CpaType { get; set; }

        [StringLength(8)]
        public string ClaimId { get; set; }

        [StringLength(4)]
        public string Userid_as_CreatedBY { get; set; }

        public DateTime? CreatedOn { get; set; }

        public virtual CpaNcType CpaNcType1 { get; set; }

        public virtual CpaType CpaType1 { get; set; }
    }
}
