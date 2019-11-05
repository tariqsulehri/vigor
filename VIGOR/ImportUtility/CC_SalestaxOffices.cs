namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_SalestaxOffices
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string SalesTaxOfficeID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string SalesTaxOffice { get; set; }

        [StringLength(3)]
        public string SalesTaxOfficeAbbrv { get; set; }
    }
}
