namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuppEvalQuestionType")]
    public partial class SuppEvalQuestionType
    {
        [Key]
        [Column("SuppEvalQuestionType", Order = 0)]
        [StringLength(2)]
        public string SuppEvalQuestionType1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string SuppEvalQuestionTypeDesc { get; set; }
    }
}
