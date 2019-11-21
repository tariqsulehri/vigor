using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;

namespace ERP.Core.Models.HR
{
    public class HrEmployee
    {
        public HrEmployee()
        {
            this.HR_AttendanceTimings = new HashSet<HR_AttendanceTimings>();
            this.HR_CINCR = new HashSet<HR_CINCR>();
            this.HR_EmployeeAllowances = new HashSet<HR_EmployeeAllowances>();
            this.HR_EmployeeExperience = new HashSet<HR_EmployeeExperience>();
            this.HR_EmployeeLeaveBalance = new HashSet<HR_EmployeeLeaveBalance>();
            this.HR_EmployeeLoanAdvanceBalance = new HashSet<HR_EmployeeLoanAdvanceBalance>();
            this.HR_EmployeeQualification = new HashSet<HR_EmployeeQualification>();
            this.HR_History = new HashSet<HR_History>();
            this.HR_HistoryDetails = new HashSet<HR_HistoryDetails>();
            this.HR_LoanAdvance = new HashSet<HR_LoanAdvance>();
            this.HR_LeaveRequest = new HashSet<HR_LeaveRequest>();
            this.HR_Photo = new HashSet<HR_Photo>();
            this.HR_SalaryMaster = new HashSet<HR_SalaryMaster>();
            this.HR_ShortLeaves = new HashSet<HR_ShortLeaves>();
        }
        public int Id { get; set; }   //Old Field
         
        [StringLength(5)]
        public string EmployeeID { get; set; }

        [Required]
        public string Title { get; set; }  //Old Fields

        [StringLength(15)]
        public string AttendanceCardNo { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string FatherHusbandName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? dob { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Age { get; set; }

        [StringLength(6)]
        public string Gender { get; set; }

        [StringLength(5)]
        public string Salutation { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        [StringLength(20)]
        public string NICNumber { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime? NICExpiry { get; set; }

        [StringLength(15)]
        public string DrivingLiecenseNo { get; set; }

        [StringLength(50)]
        public string LiesenceIssueBy { get; set; }

        [StringLength(25)]
        public string NTNNumber { get; set; }

        [StringLength(15)]
        public string PassportNo { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime? PassportExpiry { get; set; }

        [StringLength(100)]
        public string PersonalEmailAddress { get; set; }

        [StringLength(15)]
        public string MaritalStatus { get; set; }

        [StringLength(20)]
        public string Religion { get; set; }

        [StringLength(400)]
        public string PermanentAddress { get; set; }

        [Required]
        //[ForeignKey("City")]
        public int PermanentCityId { get; set; }
        //public virtual City City { get; set;}

        [Required]
        [StringLength(4)]
        public string PermanentCityIdKey { get; set; }

        [StringLength(400)]
        public string TemporaryAddress { get; set; }


        [Required]
        public int TemporaryCityId { get; set; }
        [Required]
        [StringLength(4)]
        public string TemporaryCityKey { get; set; }

        [StringLength(50)]
        public string LandLine1 { get; set; }

        [StringLength(50)]
        public string LandLine2 { get; set; }

        [StringLength(15)]
        public string Mobile1 { get; set; }

        [StringLength(15)]
        public string Mobile2 { get; set; }

        [StringLength(5)]
        public string BloodGroup { get; set; }

        [StringLength(50)]
        public string PhotoPath { get; set; }

        [StringLength(50)]
        public string SignaturePath { get; set; }

        public bool IsSeenOriginalDoc { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime? JoiningDate { get; set; }

        [Required]
        [StringLength(2)]
        [ForeignKey("HR_EmployeeType")]
        public string EmployeeType { get; set; }
        public virtual HR_EmployeeType HR_EmployeeType { get; set; }


        [ForeignKey("HrDepartment")]
        [Required]
        public int DeptId { get; set;}
        public virtual HrDepartment HrDepartment { get; set; }  
        
        [Required]
        [StringLength(4)]
        public string Department { get; set; }
        

        [Required]
        [StringLength(2)]
        [ForeignKey("HrDesignation")]
        public string  Designation { get; set; }
        public virtual HR_Designation HrDesignation { get; set;} 


        [StringLength(100)]
        public string CompanyEmailAddress { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CurrentBasicSalary { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CurrentAllowances { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CurrentGrossSalary { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IncomeTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal HealthInsurance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LunchPayment { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ProfessionalTax { get; set; }

        [StringLength(10)]
        public string RestDay { get; set; }

        public bool isActive { get; set; }
        [Column(TypeName = "datetime2")]

        public DateTime? TerminatedOn { get; set; }

        [StringLength(1)]
        public string TerminateStatus { get; set; }

        [StringLength(200)]
        public string TerminateReason { get; set; }

        [StringLength(4)]
        public string Userid_as_TerminatedBy { get; set; }

        public bool IsLeaveQuotaImplement { get; set; }

        public int YearlyLeavesAllowed { get; set; }

        public bool isSettled { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? SettledOn { get; set; }


//        [ForeignKey("Company")]
        [Required]
        public int companyID { get; set;} 
//        public virtual Company Company { get; set; }
        

        [Required]
        [StringLength(3)]
        public string CompanyKey { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public bool BioMetricAttendance { get; set; }

        [StringLength(5)]
        public string OfficeTimeIn { get; set; }

        [StringLength(5)]
        public string OfficeTimeOut { get; set; }

        [Required]
        [StringLength(1)]
        public string SalaryMode { get; set; }

        [StringLength(30)]
        public string BankAccountNumber { get; set; }

        [StringLength(150)]
        public string BankAccountTitle { get; set; }

        public bool IsEOBIMember { get; set; }

        [StringLength(25)]
        public string EOBINumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EOBIMemberSince { get; set; }

        [StringLength(500)]
        public string Reference1 { get; set; }

        [StringLength(500)]
        public string Reference2 { get; set; }

        public bool IsConductedOrientation { get; set; }

        [StringLength(50)]
        public string OreintationConductedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OrientationConductedOn { get; set; }


        [Column(TypeName = "image")]
        public byte[] ImageEmp { get; set; }


        public virtual ICollection<HR_AttendanceTimings> HR_AttendanceTimings { get; set; }
        public virtual ICollection<HR_CINCR> HR_CINCR { get; set;}
        public virtual ICollection<HR_EmployeeExperience> HR_EmployeeExperience { get; set;}
        public virtual ICollection<HR_EmployeeAllowances> HR_EmployeeAllowances { get; set;}
        public virtual ICollection<HR_EmployeeLeaveBalance> HR_EmployeeLeaveBalance { get; set;}
        public virtual ICollection<HR_EmployeeLoanAdvanceBalance> HR_EmployeeLoanAdvanceBalance { get; set; }
        public virtual ICollection<HR_EmployeeQualification> HR_EmployeeQualification { get; set; }
        public virtual ICollection<HR_History> HR_History { get; set;}
        public virtual ICollection<HR_HistoryDetails> HR_HistoryDetails { get; set; }
        public virtual ICollection<HR_LeaveRequest> HR_LeaveRequest { get; set; }
        public virtual ICollection<HR_LoanAdvance> HR_LoanAdvance { get; set; }
        public virtual ICollection<HR_LoanAdvanceApplication> HR_LoanAdvanceApplication { get; set; }
        public virtual ICollection<HR_MonthlyAttendance> HR_MonthlyAttendance { get; set; }
        public virtual ICollection<HR_Photo> HR_Photo { get; set;}
        public virtual ICollection<HR_SalaryMaster> HR_SalaryMaster { get; set; }
        public virtual ICollection<HR_ShortLeaves> HR_ShortLeaves { get; set; }


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
