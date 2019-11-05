using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.ViewModels
{
    public class HR_EmployeeViewModel
    {
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

        public DateTime dob { get; set; }

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

        public DateTime NICExpiry { get; set; }

        [StringLength(15)]
        public string DrivingLiecenseNo { get; set; }

        [StringLength(50)]
        public string LiesenceIssueBy { get; set; }

        [StringLength(25)]
        public string NTNNumber { get; set; }

        [StringLength(15)]
        public string PassportNo { get; set; }

        public DateTime PassportExpiry { get; set; }

        [StringLength(100)]
        public string PersonalEmailAddress { get; set; }

        [StringLength(15)]
        public string MaritalStatus { get; set; }

        [StringLength(20)]
        public string Religion { get; set; }

        [StringLength(400)]
        public string PermanentAddress { get; set; }

        [Required]
        [StringLength(4)]
        public string PermanentCityId { get; set; }

        [StringLength(400)]
        public string TemporaryAddress { get; set; }

        [Required]
        [StringLength(4)]
        public string TemporaryCityId { get; set; }

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

        public DateTime JoiningDate { get; set; }

        [Required]
        [StringLength(2)]
        public string EmployeeType { get; set; }

        [Required]
        [StringLength(4)]
        public string Department { get; set; }

        [Required]
        [StringLength(3)]
        public string Designation { get; set; }

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

        public DateTime TerminatedOn { get; set; }

        [StringLength(1)]
        public string TerminateStatus { get; set; }

        [StringLength(200)]
        public string TerminateReason { get; set; }

        [StringLength(4)]
        public string Userid_as_TerminatedBy { get; set; }

        public bool IsLeaveQuotaImplement { get; set; }

        public int YearlyLeavesAllowed { get; set; }

        public bool isSettled { get; set; }

        public DateTime SettledOn { get; set; }

        [Required]
        [StringLength(3)]
        public string Companyid { get; set; }

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

        public DateTime EOBIMemberSince { get; set; }

        [StringLength(500)]
        public string Reference1 { get; set; }

        [StringLength(500)]
        public string Reference2 { get; set; }

        public bool IsConductedOrientation { get; set; }

        [StringLength(50)]
        public string OreintationConductedBy { get; set; }

        public DateTime OrientationConductedOn { get; set; }


        [Column(TypeName = "image")]
        public byte[] ImageEmp { get; set; }

        //qualification fields
        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [StringLength(2)]
        public string DegreeId { get; set; }

        [StringLength(100)]
        public string Institution { get; set; }

        [StringLength(10)]
        public string Marks_gpa { get; set; }

        [StringLength(5)]
        public string Grade { get; set; }

        [StringLength(5)]
        public string Division { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(15)]
        public string DegreeSession { get; set; }


        //experience
        [StringLength(5)]
        [Required(ErrorMessage = "Field is required....")]
        public string ExpEmployeeNo { get; set; }
        
        [StringLength(200)]
        public string Organization { get; set; }

        [StringLength(200)]
        public string ExpDesignation { get; set; }

        public DateTime JoinigDate { get; set; }

        public DateTime ResignedOn { get; set; }

        [StringLength(200)]
        public string ReasonToLeave { get; set; }

        //emp Allowance Info
        public string AllowanceID { get; set; }

        public decimal Amount { get; set; }

        [StringLength(1)]
        public string Mode { get; set; }

    }
}
