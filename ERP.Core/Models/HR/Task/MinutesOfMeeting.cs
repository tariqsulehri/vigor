using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class MinutesOfMeeting
    {

        [Key]
        public int id { get; set; }

        [StringLength(9)]
        public string IdKey { get; set; }

        [ForeignKey("MeetingLogType")]
        [StringLength(2)]
        public string TypeId { get; set; }
        public virtual MeetingLogType MeetingLogType { get; set; }

        public DateTime? IDDATE { get; set; }

        [StringLength(500)]
        public string SUBJECT { get; set; }

        [StringLength(500)]
        public string Agenda { get; set; }

        [StringLength(100)]
        public string Venue { get; set; }

        [Column(TypeName = "text")]
        public string Minuts { get; set; }

        [StringLength(1000)]
        public string Participants { get; set; }
                
        [ForeignKey("HrEmployee")]
        public int ReportedById { get; set; }
        public virtual HrEmployee HrEmployee { get; set; }
        
        [ForeignKey("HrDepartment")]
        public int DepartmentId { get; set; }
        public virtual HrDepartment HrDepartment { get; set; }
        
        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }
    }
}
