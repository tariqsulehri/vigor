using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Finance;
using ERP.Core.Models.HR;

namespace ERP.Core.Models.Common
{
    public class Company
    {
        #region Class Property Declarations 

        public int Id { get; set; }
        [StringLength(3)]
        public string RefId { get; set; }
        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Name { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [MaxLength(100)]
        public string MailAddress { get; set; }

        //[ForeignKey("Country")]
        //public int ContId { get; set; }
        //public virtual Country Country { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        [MaxLength(30)]
        public string Phone { get; set; }

        [MaxLength(30)]
        public string Fax { get; set; }

        [MaxLength(40)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string WebAddress { get; set; }

        [ForeignKey("BusinessTypes")]
        public int BusId { get; set; }
        public virtual BusinessTypes BusinessTypes { get; set; }
//        public virtual ICollection<HrEmployee> HrEmployees { get; set;}
        public virtual ICollection<HR_AttendanceTimings> HR_AttendanceTimings { get; set; }
        public virtual ICollection<HR_EmployeeLeaveBalance> HR_EmployeeLeaveBalance { get; set; }
        public virtual ICollection<HR_EmployeeLoanAdvanceBalance> HR_EmployeeLoanAdvanceBalance { get; set; }
        public virtual ICollection<HR_GazzettedDays> HR_GazzettedDays { get; set;}
        public virtual ICollection<HR_History> HR_History { get; set;}
        public virtual ICollection<HR_LeaveRequest> HR_LeaveRequest { get; set; }
        public virtual ICollection<HR_LoanAdvanceApplication> HR_LoanAdvanceApplication { get; set; }
        public virtual ICollection<HR_MonthlyAttendance> HR_MonthlyAttendance { get; set; }
        public virtual ICollection<HR_SalaryMaster> HR_SalaryMaster { get; set; }
        public virtual ICollection<HR_ShortLeaves> HR_ShortLeaves { get; set; }


        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime LastUpDate { get; set; }

        public Boolean IsActive { get; set; }

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


        #endregion Class Property Declarations





    }
}
