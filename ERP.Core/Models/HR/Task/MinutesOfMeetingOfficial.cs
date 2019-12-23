using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class MinutesOfMeetingOfficial
    {
        [Key]
        [StringLength(9)]
        public string MeetingCode { get; set; }

        [StringLength(5)]
        public string CompanyOfficial { get; set; }

    }
}
