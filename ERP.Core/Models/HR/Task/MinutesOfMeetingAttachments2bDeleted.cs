using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class MinutesOfMeetingAttachments2bDeleted
    {
        [Key]
        [StringLength(9)]
        public string MeetingID { get; set; }

        [StringLength(250)]
        public string FileDescription { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

    }
}
