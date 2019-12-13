using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class KnittedFabricInspection
    {
        public KnittedFabricInspection()
        {
            this.KnittedFabricInspGrey = new HashSet<KnittedFabricInspGrey>();
            this.KnittedFabricInspDyed = new HashSet<KnittedFabricInspDyed>();
            this.KnittedFabricInspBleached = new HashSet<KnittedFabricInspBleached>();
            this.KnittedFabricInspectionAttachment = new HashSet<KnittedFabricInspectionAttachment>();
        }
        [Key]
        [StringLength(9)]
        public string InspectionID { get; set; }

        public DateTime InsepctionDate { get; set; }


        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }


        [ForeignKey("IndDomesticDispatchSchedule")]
        public int ShipmentScheduleId { get; set; }
        public virtual IndDomesticDispatchSchedule IndDomesticDispatchSchedule { get; set; }

        [Required]
        [StringLength(13)]
        public string ShipmentScheduleKey { get; set; }

        [ForeignKey("IndDomesticDetail")]
        public int SalesContractDetailId { get; set; }
        public virtual IndDomesticDetail IndDomesticDetail { get; set; }

        [Required]
        [StringLength(13)]
        public string SalesContractDetailKey { get; set; }

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

        public int CompyanyID { get; set; }

        [Required]
        [StringLength(3)]
        public string CompanyKey { get; set; }

        public virtual ICollection<KnittedFabricInspGrey> KnittedFabricInspGrey { get; set; }
        public virtual ICollection<KnittedFabricInspDyed> KnittedFabricInspDyed { get; set; }
        public virtual ICollection<KnittedFabricInspBleached> KnittedFabricInspBleached { get; set; }
        public virtual ICollection<KnittedFabricInspectionAttachment> KnittedFabricInspectionAttachment { get; set; }
    }
}
