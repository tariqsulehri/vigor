using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class IndentInspection
    {
        public int Id { get; set;}

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [StringLength(10)]
        public string IndentKey { get; set; }

        [StringLength(11)]
        public string InspSrno { get; set; }

        [StringLength(13)]
        public string SalesContractDetail { get; set; }

        [ForeignKey("CommodityType")]
        public int CommodityTypeId { get; set; }
        public virtual CommodityType CommodityType { get; set; }


        [ForeignKey("IndDomesticDispatchSchedule")]
        public int DispatchId { get; set; }
        public virtual IndDomesticDispatchSchedule IndDomesticDispatchSchedule { get; set; }

        [StringLength(13)]
        public string LocalDispatchKey { get; set; }

    }
}
