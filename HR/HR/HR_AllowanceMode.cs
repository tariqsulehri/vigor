using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_AllowanceModes
    {
        [Key]
        [StringLength(1)]
        public string AllowanceMode { get; set; }

        [Required]
        [StringLength(10)]
        public string Description { get; set; }
    }

}

