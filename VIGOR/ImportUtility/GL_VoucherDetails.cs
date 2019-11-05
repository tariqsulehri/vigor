namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_VoucherDetails
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SerialNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(18)]
        public string VoucherID { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal AccountID { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime VoucherDate { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(800)]
        public string Narration { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal Debit { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal Credit { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool VoucherStatus { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(3)]
        public string CompanyId { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal VouchertypeId { get; set; }

        [StringLength(4)]
        public string Department { get; set; }

        [StringLength(4)]
        public string Location { get; set; }

        [StringLength(6)]
        public string Employee { get; set; }

        [StringLength(6)]
        public string Customer { get; set; }

        public virtual GL_COA GL_COA { get; set; }
    }
}
