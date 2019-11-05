using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.viewModels
{
    public class CommInvoice_VM
    {
        public string SaleContractNo { get; set; }
        public int CommodityId { get; set;}
        public string Commodity { get; set; }
        public decimal Quantity { get; set; }
        public string UOS { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }

    }
}
