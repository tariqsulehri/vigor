namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserCompany
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string UserID { get; set; }

        public bool? Allowed { get; set; }

        public virtual CompanyDefinition CompanyDefinition { get; set; }

        public virtual UMUser UMUser { get; set; }
    }
}
