namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CC_City
    {
        [Key]
        [StringLength(4)]
        public string CityID { get; set; }

        [Required]
        [StringLength(100)]
        public string CityName { get; set; }

        [Required]
        [StringLength(4)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(4)]
        public string UserID_CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserID_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(1)]
        public string IsActive { get; set; }
    }
}
