namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_EmployeeType
    {
        [Key]
        [StringLength(2)]
        public string EmployeeTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
