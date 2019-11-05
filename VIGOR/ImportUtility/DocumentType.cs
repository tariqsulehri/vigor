namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DocumentType")]
    public partial class DocumentType
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string DOCTYPE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DOCNAME { get; set; }
    }
}
