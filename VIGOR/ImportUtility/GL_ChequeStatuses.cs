namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_ChequeStatuses
    {
        [Key]
        public int ChequeStatusID { get; set; }

        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        public bool isActive { get; set; }
    }
}
