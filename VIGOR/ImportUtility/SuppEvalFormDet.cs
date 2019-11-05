namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuppEvalFormDet")]
    public partial class SuppEvalFormDet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string SuppEvalformDetID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string SuppEvalformCode { get; set; }

        [StringLength(4)]
        public string SuppEvalformSection { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string SuppEvalQuestionType { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal SequenceID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(350)]
        public string QuestionDescription { get; set; }
    }
}
