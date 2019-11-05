namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_LinkCustomers
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string CustomerID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal AccountID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string CompanyID { get; set; }
    }
}
