namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gender
    {
        [StringLength(1)]
        public string GenderID { get; set; }

        [StringLength(10)]
        public string Description { get; set; }
    }
}
