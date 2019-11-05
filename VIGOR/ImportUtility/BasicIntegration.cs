namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BasicIntegration")]
    public partial class BasicIntegration
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(250)]
        public string TransectionDescription { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal IntegrationID { get; set; }
    }
}
