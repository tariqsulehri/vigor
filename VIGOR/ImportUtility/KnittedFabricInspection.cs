namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KnittedFabricInspection")]
    public partial class KnittedFabricInspection
    {
        [Key]
        [StringLength(9)]
        public string InspectionID { get; set; }

        public DateTime InsepctionDate { get; set; }

        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [StringLength(13)]
        public string ShipmentScheduleId { get; set; }

        [StringLength(13)]
        public string SalesContractDetailID { get; set; }

        [StringLength(6)]
        public string FCL { get; set; }

        [StringLength(10)]
        public string Lotno { get; set; }

        public DateTime? SampleRequiredOn { get; set; }

        public DateTime? BabyConesReceivedOn { get; set; }

        public DateTime? GreyReceivedOn { get; set; }

        public DateTime? DyedReceivedOn { get; set; }

        [StringLength(3000)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string ContainGrey { get; set; }

        [StringLength(1)]
        public string ContainDyed { get; set; }

        [StringLength(1)]
        public string ContainBleached { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [StringLength(4)]
        public string userid_as_CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(4)]
        public string Userid_as_ModifiedBy { get; set; }

        public DateTime? Modifiedon { get; set; }
    }
}
