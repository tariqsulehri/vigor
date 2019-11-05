namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_Document
    {
        [Key]
        [StringLength(1)]
        public string StoreDocID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(1)]
        public string Nature { get; set; }

        [StringLength(4)]
        public string Abbrv { get; set; }
    }
}
