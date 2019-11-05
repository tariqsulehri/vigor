namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HR_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HR_AllowanceMode",
                c => new
                    {
                        AllowanceMode = c.String(nullable: false, maxLength: 2),
                        Description = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AllowanceMode);
            
            CreateTable(
                "dbo.HR_Allowances",
                c => new
                    {
                        AllowanceID = c.String(nullable: false, maxLength: 4),
                        Description = c.String(nullable: false, maxLength: 100),
                        Type = c.String(nullable: false, maxLength: 2),
                        SubType = c.String(nullable: false, maxLength: 2),
                        TaxStatus = c.String(maxLength: 2),
                        ApplyOn = c.String(maxLength: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AllowanceID);
            
            CreateTable(
                "dbo.HR_AttendanceTimings",
                c => new
                    {
                        EmployeeAttendanceID = c.String(nullable: false, maxLength: 9),
                        CompanyID = c.String(),
                        EmployeeNo = c.String(maxLength: 9),
                        AttendanceMonth = c.Long(nullable: false),
                        AttendanceYear = c.Long(nullable: false),
                        AttendanceDate = c.DateTime(nullable: false),
                        InputType = c.String(maxLength: 9),
                        IsLate = c.String(maxLength: 2),
                        Checkin = c.DateTime(nullable: false),
                        TimeCheckIn = c.String(maxLength: 8),
                        CheckOut = c.DateTime(nullable: false),
                        TimeCheckout = c.String(maxLength: 8),
                        Hours = c.Int(nullable: false),
                        Minutes = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeAttendanceID);
            
            CreateTable(
                "dbo.HR_CINCR",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 9),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        EmpDept = c.String(nullable: false, maxLength: 4),
                        ReportedBy = c.String(nullable: false, maxLength: 4),
                        ReportedDate = c.DateTime(nullable: false),
                        Incident = c.String(nullable: false, maxLength: 2000),
                        TypeOfIncident = c.String(nullable: false, maxLength: 2),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.HR_DayStatus",
                c => new
                    {
                        DayStatusID = c.Long(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 9),
                        Abbreviation = c.String(maxLength: 2),
                        WorkingDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeductDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AllowedInAttendance = c.Boolean(nullable: false),
                        isActive = c.DateTime(nullable: false),
                        CountAs = c.Boolean(nullable: false),
                        ListedAsLeave = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DayStatusID);
            
            CreateTable(
                "dbo.HR_Degree",
                c => new
                    {
                        AllowanceMode = c.String(nullable: false, maxLength: 2),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AllowanceMode);
            
            CreateTable(
                "dbo.HR_Designation",
                c => new
                    {
                        DesignationId = c.String(nullable: false, maxLength: 2),
                        Description = c.String(nullable: false, maxLength: 200),
                        RequiredEducation = c.String(nullable: false, maxLength: 200),
                        Experience = c.String(maxLength: 500),
                        SkillsRequired = c.String(maxLength: 1000),
                        Remarks = c.String(maxLength: 1000),
                        HirarchyPriority = c.Long(nullable: false),
                        isactive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.HR_EmployeeAllowances",
                c => new
                    {
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        AllowanceID = c.String(nullable: false, maxLength: 4),
                        Amount = c.Long(nullable: false),
                        Mode = c.Boolean(nullable: false),
                        AllowanceValue = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeNo);
            
            CreateTable(
                "dbo.HR_EmployeeExperience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        Organization = c.String(maxLength: 200),
                        Designation = c.String(maxLength: 200),
                        JoiningDate = c.DateTime(nullable: false),
                        ResignedOn = c.DateTime(nullable: false),
                        ReasonToLeave = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HR_EmployeeLeaveBalance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        Company = c.String(nullable: false, maxLength: 3),
                        TransactionYear = c.String(maxLength: 4),
                        LeavespenBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeavesConsumed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LeavesInBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HR_EmployeeLoanAdvanceBalance",
                c => new
                    {
                        LoanAdvanceID = c.Long(nullable: false, identity: true),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        Company = c.String(nullable: false, maxLength: 3),
                        LoanOpenBalance = c.Double(nullable: false),
                        AdvanceOpenBalance = c.Double(nullable: false),
                        LoanAmountBalance = c.Double(nullable: false),
                        AdvanceAmountBalance = c.Double(nullable: false),
                        LoanInstalment = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LoanAdvanceID);
            
            CreateTable(
                "dbo.HR_EmployeeQualification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        DegreeId = c.String(maxLength: 2),
                        Institution = c.String(maxLength: 100),
                        Marks_GPA = c.String(maxLength: 10),
                        Grade = c.String(maxLength: 5),
                        Division = c.String(maxLength: 5),
                        Status = c.String(maxLength: 2),
                        DegreeSession = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HR_EmployeeType",
                c => new
                    {
                        EmployeeTypeID = c.String(nullable: false, maxLength: 2),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EmployeeTypeID);
            
            CreateTable(
                "dbo.HR_GazzettedDays",
                c => new
                    {
                        GazzettedDateId = c.String(nullable: false, maxLength: 6),
                        GazzettedDateFrom = c.DateTime(nullable: false),
                        GazzettedDateTo = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        TranYear = c.String(maxLength: 4),
                        Company = c.String(maxLength: 3),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GazzettedDateId);
            
            CreateTable(
                "dbo.HR_History",
                c => new
                    {
                        HistoryID = c.String(nullable: false, maxLength: 8),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        Company = c.String(nullable: false, maxLength: 3),
                        PromotionType = c.String(nullable: false, maxLength: 2),
                        Dated = c.DateTime(nullable: false),
                        psBasic = c.Double(nullable: false),
                        psAllowance = c.Double(nullable: false),
                        psCurrent = c.Double(nullable: false),
                        nsBasic = c.Double(nullable: false),
                        nsAllowance = c.Double(nullable: false),
                        nsCurrent = c.Double(nullable: false),
                        PreviousDepartment = c.String(nullable: false, maxLength: 4),
                        PreviousDesignation = c.String(nullable: false, maxLength: 3),
                        PreviousCompany = c.String(nullable: false, maxLength: 3),
                        NewDepartment = c.String(nullable: false, maxLength: 4),
                        NewDesignation = c.String(nullable: false, maxLength: 3),
                        NewCompany = c.String(nullable: false, maxLength: 3),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HR_History");
            DropTable("dbo.HR_GazzettedDays");
            DropTable("dbo.HR_EmployeeType");
            DropTable("dbo.HR_EmployeeQualification");
            DropTable("dbo.HR_EmployeeLoanAdvanceBalance");
            DropTable("dbo.HR_EmployeeLeaveBalance");
            DropTable("dbo.HR_EmployeeExperience");
            DropTable("dbo.HR_EmployeeAllowances");
            DropTable("dbo.HR_Designation");
            DropTable("dbo.HR_Degree");
            DropTable("dbo.HR_DayStatus");
            DropTable("dbo.HR_CINCR");
            DropTable("dbo.HR_AttendanceTimings");
            DropTable("dbo.HR_Allowances");
            DropTable("dbo.HR_AllowanceMode");
        }
    }
}
