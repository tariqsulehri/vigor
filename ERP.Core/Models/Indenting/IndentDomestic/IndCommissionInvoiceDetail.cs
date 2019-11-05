using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndCommissionInvoiceDetail
    {
        public int Id { get; set; }

        [StringLength(13)]
        public string SalesContractDetailID_RefKey { get; set; }

        [ForeignKey("IndCommissionInvoice")]
        public int CommissionInvoiceNo { get; set; }
        public virtual IndCommissionInvoice IndCommissionInvoice { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string CommissionInvoiceKey { get; set; }


        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }

        public decimal Quantity { get; set; }

        [ForeignKey("UnitOfSales")]
        public int UnitOfSaleId { get; set; }
        public virtual UnitOfSale UnitOfSales { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }

        [StringLength(3)]
        public string CompanyId { get; set; }

    }
}
