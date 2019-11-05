namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HRTableUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HR_AllowanceMode", newName: "HR_AllowanceModes");
            DropPrimaryKey("dbo.HR_AllowanceModes");
            DropPrimaryKey("dbo.HR_CINCR");
            DropPrimaryKey("dbo.HR_Designation");
            DropPrimaryKey("dbo.HR_EmployeeLoanAdvanceBalance");
            CreateTable(
                "dbo.HR_HistoryDetails",
                c => new
                    {
                        HistoryID = c.String(nullable: false, maxLength: 8),
                        EmployeeNo = c.String(maxLength: 5),
                        AllowanceID = c.String(maxLength: 4),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mode = c.String(maxLength: 1),
                        AllowanceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.HistoryID);
            
            CreateTable(
                "dbo.HR_LeaveRequest",
                c => new
                    {
                        LeaveRequestMasterID = c.String(nullable: false, maxLength: 8),
                        FortheYear = c.Int(nullable: false),
                        CompanyID = c.String(maxLength: 3),
                        EmployeeNo = c.String(maxLength: 5),
                        ApplicationDate = c.DateTime(nullable: false),
                        LeaveRequiredFrom = c.DateTime(nullable: false),
                        LeaveRequestedTo = c.DateTime(nullable: false),
                        LeaveType = c.Int(nullable: false),
                        Reason = c.String(maxLength: 500),
                        Userid_as_ApprovedBy = c.Int(nullable: false),
                        ApprovedOn = c.DateTime(nullable: false),
                        IsPending = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ApplicationType = c.String(maxLength: 1),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LeaveRequestMasterID);
            
            CreateTable(
                "dbo.HR_LoanAdvance",
                c => new
                    {
                        LoanAdvLedID = c.String(nullable: false, maxLength: 8),
                        EmployeeNo = c.String(maxLength: 5),
                        TransectionDate = c.DateTime(nullable: false),
                        Type = c.String(nullable: false, maxLength: 1),
                        Amount = c.Double(nullable: false),
                        IsDeduction = c.String(maxLength: 1),
                        LoanAdvanceApplicationNo = c.Double(nullable: false),
                        SalarySlipNo = c.String(maxLength: 11),
                        BonusMasterID = c.String(maxLength: 10),
                        VoucherNo = c.String(maxLength: 18),
                        Remarks = c.String(maxLength: 100),
                        Company = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.LoanAdvLedID);
            
            CreateTable(
                "dbo.HR_LoanAdvanceApplication",
                c => new
                    {
                        LoanAdvanceID = c.String(nullable: false, maxLength: 8),
                        ApplicationDate = c.DateTime(nullable: false),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        CompanyId = c.String(nullable: false, maxLength: 3),
                        Reason = c.String(maxLength: 250),
                        Type = c.String(nullable: false, maxLength: 1),
                        RequiredAmount = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        LoanInstalment = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        ApprovedAmount = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        ApprovedLoanInstalment = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                        isActive = c.String(maxLength: 1),
                        UserId_as_CreatedBy = c.String(maxLength: 4),
                        CreatedOn = c.DateTime(nullable: false),
                        Userid_as_ModifiedBy = c.String(maxLength: 4),
                        ModifiedOn = c.DateTime(nullable: false),
                        UserId_as_ApprovedBy = c.String(maxLength: 4),
                        ApprovedOn = c.DateTime(),
                        IsPending = c.String(nullable: false, maxLength: 1),
                        IsApproved = c.String(nullable: false, maxLength: 1),
                        IsPosted = c.String(nullable: false, maxLength: 1),
                        PostedOn = c.DateTime(nullable: false),
                        UserId_as_PostedBy = c.String(maxLength: 4),
                        oldAppId = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LoanAdvanceID);
            
            CreateTable(
                "dbo.HR_MonthlyAttendance",
                c => new
                    {
                        EmployeeAttendanceId = c.String(nullable: false, maxLength: 11),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        CompanyId = c.String(nullable: false, maxLength: 3),
                        AttendanceMonth = c.DateTime(nullable: false),
                        Forthemonth = c.Int(nullable: false),
                        Fortheyear = c.Int(nullable: false),
                        Department = c.String(nullable: false, maxLength: 4),
                        Designation = c.String(nullable: false, maxLength: 3),
                        ValidDateStart = c.DateTime(nullable: false),
                        ValidDateEnd = c.DateTime(nullable: false),
                        IsSeparated = c.Boolean(nullable: false),
                        TotalMonthDays = c.Int(nullable: false),
                        TotalWorkingDays = c.Int(nullable: false),
                        WithPay = c.Int(nullable: false),
                        WithOutPay = c.Int(nullable: false),
                        Leaves = c.Int(nullable: false),
                        Visits = c.Int(nullable: false),
                        Day01 = c.String(maxLength: 2),
                        Day02 = c.String(maxLength: 2),
                        Day03 = c.String(maxLength: 2),
                        Day04 = c.String(maxLength: 2),
                        Day05 = c.String(maxLength: 2),
                        Day06 = c.String(maxLength: 2),
                        Day07 = c.String(maxLength: 2),
                        Day08 = c.String(maxLength: 2),
                        Day09 = c.String(maxLength: 2),
                        Day10 = c.String(maxLength: 2),
                        Day11 = c.String(maxLength: 2),
                        Day12 = c.String(maxLength: 2),
                        Day13 = c.String(maxLength: 2),
                        Day14 = c.String(maxLength: 2),
                        Day15 = c.String(maxLength: 2),
                        Day16 = c.String(maxLength: 2),
                        Day17 = c.String(maxLength: 2),
                        Day18 = c.String(maxLength: 2),
                        Day19 = c.String(maxLength: 2),
                        Day20 = c.String(maxLength: 2),
                        Day21 = c.String(maxLength: 2),
                        Day22 = c.String(maxLength: 2),
                        Day23 = c.String(maxLength: 2),
                        Day24 = c.String(maxLength: 2),
                        Day25 = c.String(maxLength: 2),
                        Day26 = c.String(maxLength: 2),
                        Day27 = c.String(maxLength: 2),
                        Day28 = c.String(maxLength: 2),
                        Day29 = c.String(maxLength: 2),
                        Day30 = c.String(maxLength: 2),
                        Day31 = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.EmployeeAttendanceId);
            
            CreateTable(
                "dbo.HR_SalaryDetail",
                c => new
                    {
                        EmployeeSalaryMasterId = c.String(nullable: false, maxLength: 11),
                        EmployeeAllowanceID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mode = c.String(maxLength: 1),
                        LoanAdvanceID = c.Int(nullable: false),
                        DeductedAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeductionType = c.String(maxLength: 1),
                        IsDeductedBySystem = c.String(maxLength: 1),
                        Deduction_ChangedBy = c.String(maxLength: 3),
                        ChangedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeSalaryMasterId);
            
            CreateTable(
                "dbo.HR_SalaryMaster",
                c => new
                    {
                        EmployeeSalaryMasterId = c.String(nullable: false, maxLength: 11),
                        Company = c.String(nullable: false, maxLength: 3),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        SalaryMonth = c.DateTime(nullable: false),
                        ForTheYear = c.Int(nullable: false),
                        fortheMonth = c.Int(nullable: false),
                        DepartmentCode = c.String(nullable: false, maxLength: 4),
                        DesignationCode = c.String(nullable: false, maxLength: 3),
                        Isterminated = c.String(maxLength: 1),
                        CurrentMonthGrossSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentMonthBasicSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentMonthAllowances = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentMonthNetSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanAdjusted = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdvanceAdjusted = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(maxLength: 200),
                        IncomeTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HealthInsurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalaryMode = c.String(maxLength: 1),
                        Arrears = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiscDeductions = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EOBIEmployerContribution = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EOBIEmployeeContribution = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NoticePeriod = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsHold = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeSalaryMasterId);
            
            CreateTable(
                "dbo.HR_ShortLeaves",
                c => new
                    {
                        EmployeeAttendanceID = c.String(nullable: false, maxLength: 9),
                        CompanyID = c.String(maxLength: 3),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        AttendanceYear = c.Int(nullable: false),
                        AttendanceMonth = c.Int(nullable: false),
                        AttendanceDate = c.DateTime(nullable: false),
                        TimeCheckin = c.String(maxLength: 8),
                        TimeCheckout = c.String(maxLength: 8),
                        Hours = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                        Remarks = c.String(maxLength: 200),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeAttendanceID);
            
            AddColumn("dbo.Users", "RefId", c => c.String(maxLength: 4));
            AddColumn("dbo.HR_EmployeeExperience", "JoinigDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "EmployeeID", c => c.String(maxLength: 5));
            AddColumn("dbo.HrEmployees", "AttendanceCardNo", c => c.String(maxLength: 15));
            AddColumn("dbo.HrEmployees", "FirstName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.HrEmployees", "FatherHusbandName", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.HrEmployees", "dob", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "Age", c => c.Decimal(precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.HrEmployees", "Gender", c => c.String(maxLength: 6));
            AddColumn("dbo.HrEmployees", "Salutation", c => c.String(maxLength: 5));
            AddColumn("dbo.HrEmployees", "Nationality", c => c.String(maxLength: 50));
            AddColumn("dbo.HrEmployees", "NICNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.HrEmployees", "NICExpiry", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "DrivingLiecenseNo", c => c.String(maxLength: 15));
            AddColumn("dbo.HrEmployees", "LiesenceIssueBy", c => c.String(maxLength: 50));
            AddColumn("dbo.HrEmployees", "NTNNumber", c => c.String(maxLength: 25));
            AddColumn("dbo.HrEmployees", "PassportNo", c => c.String(maxLength: 15));
            AddColumn("dbo.HrEmployees", "PassportExpiry", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "PersonalEmailAddress", c => c.String(maxLength: 100));
            AddColumn("dbo.HrEmployees", "MaritalStatus", c => c.String(maxLength: 15));
            AddColumn("dbo.HrEmployees", "Religion", c => c.String(maxLength: 20));
            AddColumn("dbo.HrEmployees", "PermanentAddress", c => c.String(maxLength: 400));
            AddColumn("dbo.HrEmployees", "PermanentCityId", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.HrEmployees", "TemporaryAddress", c => c.String(maxLength: 400));
            AddColumn("dbo.HrEmployees", "TemporaryCityId", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.HrEmployees", "LandLine1", c => c.String(maxLength: 50));
            AddColumn("dbo.HrEmployees", "LandLine2", c => c.String(maxLength: 50));
            AddColumn("dbo.HrEmployees", "Mobile1", c => c.String(maxLength: 15));
            AddColumn("dbo.HrEmployees", "Mobile2", c => c.String(maxLength: 15));
            AddColumn("dbo.HrEmployees", "BloodGroup", c => c.String(maxLength: 5));
            AddColumn("dbo.HrEmployees", "PhotoPath", c => c.String(maxLength: 50));
            AddColumn("dbo.HrEmployees", "SignaturePath", c => c.String(maxLength: 50));
            AddColumn("dbo.HrEmployees", "IsSeenOriginalDoc", c => c.Boolean(nullable: false));
            AddColumn("dbo.HrEmployees", "JoiningDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "EmployeeType", c => c.String(nullable: false, maxLength: 2));
            AddColumn("dbo.HrEmployees", "Department", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.HrEmployees", "Designation", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HrEmployees", "CompanyEmailAddress", c => c.String(maxLength: 100));
            AddColumn("dbo.HrEmployees", "CurrentBasicSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.HrEmployees", "CurrentAllowances", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.HrEmployees", "CurrentGrossSalary", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.HrEmployees", "IncomeTax", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.HrEmployees", "HealthInsurance", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.HrEmployees", "LunchPayment", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.HrEmployees", "ProfessionalTax", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
            AddColumn("dbo.HrEmployees", "RestDay", c => c.String(maxLength: 10));
            AddColumn("dbo.HrEmployees", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.HrEmployees", "TerminatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "TerminateStatus", c => c.String(maxLength: 1));
            AddColumn("dbo.HrEmployees", "TerminateReason", c => c.String(maxLength: 200));
            AddColumn("dbo.HrEmployees", "Userid_as_TerminatedBy", c => c.String(maxLength: 4));
            AddColumn("dbo.HrEmployees", "IsLeaveQuotaImplement", c => c.Boolean(nullable: false));
            AddColumn("dbo.HrEmployees", "YearlyLeavesAllowed", c => c.Int(nullable: false));
            AddColumn("dbo.HrEmployees", "isSettled", c => c.Boolean(nullable: false));
            AddColumn("dbo.HrEmployees", "SettledOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "Companyid", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HrEmployees", "Remarks", c => c.String(maxLength: 250));
            AddColumn("dbo.HrEmployees", "BioMetricAttendance", c => c.Boolean(nullable: false));
            AddColumn("dbo.HrEmployees", "OfficeTimeIn", c => c.String(maxLength: 5));
            AddColumn("dbo.HrEmployees", "OfficeTimeOut", c => c.String(maxLength: 5));
            AddColumn("dbo.HrEmployees", "SalaryMode", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.HrEmployees", "BankAccountNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.HrEmployees", "BankAccountTitle", c => c.String(maxLength: 150));
            AddColumn("dbo.HrEmployees", "IsEOBIMember", c => c.Boolean(nullable: false));
            AddColumn("dbo.HrEmployees", "EOBINumber", c => c.String(maxLength: 25));
            AddColumn("dbo.HrEmployees", "EOBIMemberSince", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "Reference1", c => c.String(maxLength: 500));
            AddColumn("dbo.HrEmployees", "Reference2", c => c.String(maxLength: 500));
            AddColumn("dbo.HrEmployees", "IsConductedOrientation", c => c.Boolean(nullable: false));
            AddColumn("dbo.HrEmployees", "OreintationConductedBy", c => c.String(maxLength: 50));
            AddColumn("dbo.HrEmployees", "OrientationConductedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HrEmployees", "ImageEmp", c => c.Binary(storeType: "image"));
            AlterColumn("dbo.HR_AllowanceModes", "AllowanceMode", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.HR_Allowances", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.HR_Allowances", "Type", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_Allowances", "SubType", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_Allowances", "TaxStatus", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_Allowances", "ApplyOn", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_AttendanceTimings", "CompanyID", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_AttendanceTimings", "EmployeeNo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_AttendanceTimings", "AttendanceMonth", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            AlterColumn("dbo.HR_AttendanceTimings", "AttendanceYear", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            AlterColumn("dbo.HR_AttendanceTimings", "InputType", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_AttendanceTimings", "IsLate", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_AttendanceTimings", "CheckOut", c => c.DateTime());
            AlterColumn("dbo.HR_AttendanceTimings", "Hours", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            AlterColumn("dbo.HR_AttendanceTimings", "Minutes", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            AlterColumn("dbo.HR_CINCR", "id", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.HR_CINCR", "ReportedBy", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_DayStatus", "Abbreviation", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_Designation", "DesignationId", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_EmployeeAllowances", "AllowanceID", c => c.String(maxLength: 4));
            AlterColumn("dbo.HR_EmployeeAllowances", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HR_EmployeeAllowances", "Mode", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_EmployeeAllowances", "AllowanceValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HR_EmployeeLoanAdvanceBalance", "LoanAdvanceID", c => c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"));
            AlterColumn("dbo.HR_EmployeeQualification", "EmployeeNo", c => c.String(maxLength: 5));
            AlterColumn("dbo.HR_EmployeeQualification", "Status", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_GazzettedDays", "GazzettedDateFrom", c => c.DateTime());
            AlterColumn("dbo.HR_GazzettedDays", "GazzettedDateTo", c => c.DateTime());
            AlterColumn("dbo.HR_GazzettedDays", "Description", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.HR_History", "PromotionType", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.HR_History", "PreviousDepartment", c => c.String(maxLength: 4));
            AlterColumn("dbo.HR_History", "PreviousDesignation", c => c.String(maxLength: 3));
            AlterColumn("dbo.HR_History", "PreviousCompany", c => c.String(maxLength: 3));
            AlterColumn("dbo.HR_History", "NewDepartment", c => c.String(maxLength: 4));
            AlterColumn("dbo.HR_History", "NewDesignation", c => c.String(maxLength: 3));
            AlterColumn("dbo.HR_History", "NewCompany", c => c.String(maxLength: 3));
            AddPrimaryKey("dbo.HR_AllowanceModes", "AllowanceMode");
            AddPrimaryKey("dbo.HR_CINCR", "id");
            AddPrimaryKey("dbo.HR_Designation", "DesignationId");
            AddPrimaryKey("dbo.HR_EmployeeLoanAdvanceBalance", "LoanAdvanceID");
            DropColumn("dbo.HR_EmployeeExperience", "JoiningDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HR_EmployeeExperience", "JoiningDate", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.HR_EmployeeLoanAdvanceBalance");
            DropPrimaryKey("dbo.HR_Designation");
            DropPrimaryKey("dbo.HR_CINCR");
            DropPrimaryKey("dbo.HR_AllowanceModes");
            AlterColumn("dbo.HR_History", "NewCompany", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_History", "NewDesignation", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_History", "NewDepartment", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_History", "PreviousCompany", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_History", "PreviousDesignation", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_History", "PreviousDepartment", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_History", "PromotionType", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.HR_GazzettedDays", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.HR_GazzettedDays", "GazzettedDateTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HR_GazzettedDays", "GazzettedDateFrom", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HR_EmployeeQualification", "Status", c => c.String(maxLength: 2));
            AlterColumn("dbo.HR_EmployeeQualification", "EmployeeNo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_EmployeeLoanAdvanceBalance", "LoanAdvanceID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.HR_EmployeeAllowances", "AllowanceValue", c => c.Long(nullable: false));
            AlterColumn("dbo.HR_EmployeeAllowances", "Mode", c => c.Boolean(nullable: false));
            AlterColumn("dbo.HR_EmployeeAllowances", "Amount", c => c.Long(nullable: false));
            AlterColumn("dbo.HR_EmployeeAllowances", "AllowanceID", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_Designation", "DesignationId", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.HR_DayStatus", "Abbreviation", c => c.String(maxLength: 2));
            AlterColumn("dbo.HR_CINCR", "ReportedBy", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_CINCR", "id", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.HR_AttendanceTimings", "Minutes", c => c.Int(nullable: false));
            AlterColumn("dbo.HR_AttendanceTimings", "Hours", c => c.Int(nullable: false));
            AlterColumn("dbo.HR_AttendanceTimings", "CheckOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HR_AttendanceTimings", "IsLate", c => c.String(maxLength: 2));
            AlterColumn("dbo.HR_AttendanceTimings", "InputType", c => c.String(maxLength: 9));
            AlterColumn("dbo.HR_AttendanceTimings", "AttendanceYear", c => c.Long(nullable: false));
            AlterColumn("dbo.HR_AttendanceTimings", "AttendanceMonth", c => c.Long(nullable: false));
            AlterColumn("dbo.HR_AttendanceTimings", "EmployeeNo", c => c.String(maxLength: 9));
            AlterColumn("dbo.HR_AttendanceTimings", "CompanyID", c => c.String());
            AlterColumn("dbo.HR_Allowances", "ApplyOn", c => c.String(maxLength: 2));
            AlterColumn("dbo.HR_Allowances", "TaxStatus", c => c.String(maxLength: 2));
            AlterColumn("dbo.HR_Allowances", "SubType", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.HR_Allowances", "Type", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.HR_Allowances", "Description", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.HR_AllowanceModes", "AllowanceMode", c => c.String(nullable: false, maxLength: 2));
            DropColumn("dbo.HrEmployees", "ImageEmp");
            DropColumn("dbo.HrEmployees", "OrientationConductedOn");
            DropColumn("dbo.HrEmployees", "OreintationConductedBy");
            DropColumn("dbo.HrEmployees", "IsConductedOrientation");
            DropColumn("dbo.HrEmployees", "Reference2");
            DropColumn("dbo.HrEmployees", "Reference1");
            DropColumn("dbo.HrEmployees", "EOBIMemberSince");
            DropColumn("dbo.HrEmployees", "EOBINumber");
            DropColumn("dbo.HrEmployees", "IsEOBIMember");
            DropColumn("dbo.HrEmployees", "BankAccountTitle");
            DropColumn("dbo.HrEmployees", "BankAccountNumber");
            DropColumn("dbo.HrEmployees", "SalaryMode");
            DropColumn("dbo.HrEmployees", "OfficeTimeOut");
            DropColumn("dbo.HrEmployees", "OfficeTimeIn");
            DropColumn("dbo.HrEmployees", "BioMetricAttendance");
            DropColumn("dbo.HrEmployees", "Remarks");
            DropColumn("dbo.HrEmployees", "Companyid");
            DropColumn("dbo.HrEmployees", "SettledOn");
            DropColumn("dbo.HrEmployees", "isSettled");
            DropColumn("dbo.HrEmployees", "YearlyLeavesAllowed");
            DropColumn("dbo.HrEmployees", "IsLeaveQuotaImplement");
            DropColumn("dbo.HrEmployees", "Userid_as_TerminatedBy");
            DropColumn("dbo.HrEmployees", "TerminateReason");
            DropColumn("dbo.HrEmployees", "TerminateStatus");
            DropColumn("dbo.HrEmployees", "TerminatedOn");
            DropColumn("dbo.HrEmployees", "isActive");
            DropColumn("dbo.HrEmployees", "RestDay");
            DropColumn("dbo.HrEmployees", "ProfessionalTax");
            DropColumn("dbo.HrEmployees", "LunchPayment");
            DropColumn("dbo.HrEmployees", "HealthInsurance");
            DropColumn("dbo.HrEmployees", "IncomeTax");
            DropColumn("dbo.HrEmployees", "CurrentGrossSalary");
            DropColumn("dbo.HrEmployees", "CurrentAllowances");
            DropColumn("dbo.HrEmployees", "CurrentBasicSalary");
            DropColumn("dbo.HrEmployees", "CompanyEmailAddress");
            DropColumn("dbo.HrEmployees", "Designation");
            DropColumn("dbo.HrEmployees", "Department");
            DropColumn("dbo.HrEmployees", "EmployeeType");
            DropColumn("dbo.HrEmployees", "JoiningDate");
            DropColumn("dbo.HrEmployees", "IsSeenOriginalDoc");
            DropColumn("dbo.HrEmployees", "SignaturePath");
            DropColumn("dbo.HrEmployees", "PhotoPath");
            DropColumn("dbo.HrEmployees", "BloodGroup");
            DropColumn("dbo.HrEmployees", "Mobile2");
            DropColumn("dbo.HrEmployees", "Mobile1");
            DropColumn("dbo.HrEmployees", "LandLine2");
            DropColumn("dbo.HrEmployees", "LandLine1");
            DropColumn("dbo.HrEmployees", "TemporaryCityId");
            DropColumn("dbo.HrEmployees", "TemporaryAddress");
            DropColumn("dbo.HrEmployees", "PermanentCityId");
            DropColumn("dbo.HrEmployees", "PermanentAddress");
            DropColumn("dbo.HrEmployees", "Religion");
            DropColumn("dbo.HrEmployees", "MaritalStatus");
            DropColumn("dbo.HrEmployees", "PersonalEmailAddress");
            DropColumn("dbo.HrEmployees", "PassportExpiry");
            DropColumn("dbo.HrEmployees", "PassportNo");
            DropColumn("dbo.HrEmployees", "NTNNumber");
            DropColumn("dbo.HrEmployees", "LiesenceIssueBy");
            DropColumn("dbo.HrEmployees", "DrivingLiecenseNo");
            DropColumn("dbo.HrEmployees", "NICExpiry");
            DropColumn("dbo.HrEmployees", "NICNumber");
            DropColumn("dbo.HrEmployees", "Nationality");
            DropColumn("dbo.HrEmployees", "Salutation");
            DropColumn("dbo.HrEmployees", "Gender");
            DropColumn("dbo.HrEmployees", "Age");
            DropColumn("dbo.HrEmployees", "dob");
            DropColumn("dbo.HrEmployees", "FatherHusbandName");
            DropColumn("dbo.HrEmployees", "FirstName");
            DropColumn("dbo.HrEmployees", "AttendanceCardNo");
            DropColumn("dbo.HrEmployees", "EmployeeID");
            DropColumn("dbo.HR_EmployeeExperience", "JoinigDate");
            DropColumn("dbo.Users", "RefId");
            DropTable("dbo.HR_ShortLeaves");
            DropTable("dbo.HR_SalaryMaster");
            DropTable("dbo.HR_SalaryDetail");
            DropTable("dbo.HR_MonthlyAttendance");
            DropTable("dbo.HR_LoanAdvanceApplication");
            DropTable("dbo.HR_LoanAdvance");
            DropTable("dbo.HR_LeaveRequest");
            DropTable("dbo.HR_HistoryDetails");
            AddPrimaryKey("dbo.HR_EmployeeLoanAdvanceBalance", "LoanAdvanceID");
            AddPrimaryKey("dbo.HR_Designation", "DesignationId");
            AddPrimaryKey("dbo.HR_CINCR", "id");
            AddPrimaryKey("dbo.HR_AllowanceModes", "AllowanceMode");
            RenameTable(name: "dbo.HR_AllowanceModes", newName: "HR_AllowanceMode");
        }
    }
}
