using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentExport
{
    public class IndExportInquiryReviewQuestion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(150)]
        public string InquiryReviewQuestion { get; set; }
        public Boolean IsActive { get; set; }
        [MaxLength(1)]
        public string ForMarket { get; set; }

    }
}
