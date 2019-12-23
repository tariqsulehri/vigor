using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class ManualActionLog
    {

        [Key]
        public int id { get; set;}

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(1500)]
        public string ActionLog { get; set; }

    }
}
