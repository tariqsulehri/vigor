namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_CINCR
    {
        [StringLength(8)]
        public string Id { get; set; }

        [Required]
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [StringLength(4)]
        public string EmpDept { get; set; }

        [Required]
        [StringLength(5)]
        public string ReportedBY { get; set; }

        public DateTime Reportdate { get; set; }

        [Required]
        [StringLength(2000)]
        public string Incident { get; set; }

        [Required]
        [StringLength(2)]
        public string TypeofIncident { get; set; }

        [Required]
        [StringLength(4)]
        public string Userid_as_CreatedBY { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsActive { get; set; }
    }
}
