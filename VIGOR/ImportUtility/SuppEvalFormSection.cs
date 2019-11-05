namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuppEvalFormSection
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string SuppEvalSectionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string SuppEvalformCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(15)]
        public string SectionDescription { get; set; }
    }
}
