using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class MeetingLogType
    {
        [Key]
        [StringLength(2)]
        public string Type { get; set; }

        [StringLength(25)]
        public string MeetingDesc { get; set; }
        public ICollection<MinutesOfMeeting> MinutesOfMeeting { get; set;}

    }
}
