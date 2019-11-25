using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentExport
{
    public class IndExportShipmentScheduleDetail
    {

        public int Id { get; set; }

        [ForeignKey("IndExportShipmentScheduleMaster")]
        public int ShipmentScheduleId { get; set; }
        public virtual IndExportShipmentScheduleMaster IndExportShipmentScheduleMaster { get; set; }


        [StringLength(13)]
        public string ShipmentScheduleKey { get; set; }

        [StringLength(13)]
        public string SalesContractDetailID { get; set; }

        public int srno { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("UnitOfSale")]
        [Required(ErrorMessage = "Field is required....")]
        public int UosID { get; set; }
        public virtual UnitOfSale UnitOfSale { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QuantityDispatched { get; set; }
        public int? Bale_RoleNo { get; set; }

        [StringLength(1)]
        public string InspStatus { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate { get; set; } 

        [Column(TypeName = "numeric")]
        public decimal? ShipmentAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalWeight { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WeightDiff { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NetWeight { get; set; }
    }
}
