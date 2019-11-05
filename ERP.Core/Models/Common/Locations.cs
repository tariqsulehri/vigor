using ERP.Core.Models.Finance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Common
{
    public class Locations
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This required field...")]
        [StringLength(4)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This required field...")]
        [StringLength(50)]
        public string LocationDescription { get; set; }

        [Required(ErrorMessage = "This required field...")]
        [StringLength(3)]
        public string Company { get; set; }
        public ICollection<FinVoucherDetail> FinVoucherDetails { get; set; }
    }
}
