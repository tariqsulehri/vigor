namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UMProfile")]
    public partial class UMProfile
    {
        [Key]
        [StringLength(4)]
        public string UserID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(25)]
        public string ContactNumber { get; set; }

        [StringLength(5)]
        public string EmpCode { get; set; }

        public virtual UMUser UMUser { get; set; }
    }
}
