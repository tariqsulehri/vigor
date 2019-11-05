namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_SIRDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string SIRDetailID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string SIRNo { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal StoreItemID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal RequiredQty { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal IssueQty { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(3)]
        public string Issueunit { get; set; }

        public virtual Store_SIR Store_SIR { get; set; }
    }
}
