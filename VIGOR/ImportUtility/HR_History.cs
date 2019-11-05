namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_History
    {
        [Key]
        [StringLength(8)]
        public string HistoryID { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }

        [Required]
        [StringLength(1)]
        public string PromotionType { get; set; }

        public DateTime Dated { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? psBasic { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? psAllowance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? psCurrent { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? nsBasic { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? nsAllowance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? nsCurrent { get; set; }

        [StringLength(4)]
        public string PreviousDepartment { get; set; }

        [StringLength(3)]
        public string PreviousDesignation { get; set; }

        [StringLength(3)]
        public string PreviousCompany { get; set; }

        [StringLength(4)]
        public string NewDepartment { get; set; }

        [StringLength(3)]
        public string NewDesignation { get; set; }

        [StringLength(3)]
        public string NewCompany { get; set; }

        [Required]
        [StringLength(4)]
        public string Userid_as_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
