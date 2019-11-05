namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HRUpdatesFromSirNusrat : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HR_Degree");
            DropPrimaryKey("dbo.HR_Designation");
            AddColumn("dbo.HR_Degree", "DegreeID", c => c.String(nullable: false, maxLength: 2));
            AddColumn("dbo.HR_EmployeeAllowances", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeAllowances", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeAllowances", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeAllowances", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeExperience", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeExperience", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeExperience", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeExperience", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeLeaveBalance", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLeaveBalance", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeLeaveBalance", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLeaveBalance", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeLoanAdvanceBalance", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLoanAdvanceBalance", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeLoanAdvanceBalance", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLoanAdvanceBalance", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeQualification", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeQualification", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeQualification", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeQualification", "ModifiedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeType", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeType", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.HR_EmployeeType", "ModifiedBy", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeType", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HR_AttendanceTimings", "AttendanceDate", c => c.DateTime());
            AlterColumn("dbo.HR_AttendanceTimings", "Checkin", c => c.DateTime());
            AlterColumn("dbo.HR_CINCR", "EmpDept", c => c.String(maxLength: 4));
            AlterColumn("dbo.HR_CINCR", "ReportedBy", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_DayStatus", "Abbreviation", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.HR_DayStatus", "CountAs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HR_Designation", "DesignationId", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.HR_EmployeeQualification", "Grade", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_EmployeeQualification", "Division", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_EmployeeQualification", "Status", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.HR_EmployeeQualification", "DegreeSession", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.HR_History", "psBasic", c => c.Double());
            AlterColumn("dbo.HR_History", "psAllowance", c => c.Double());
            AlterColumn("dbo.HR_History", "psCurrent", c => c.Double());
            AlterColumn("dbo.HR_History", "nsBasic", c => c.Double());
            AlterColumn("dbo.HR_History", "nsAllowance", c => c.Double());
            AlterColumn("dbo.HR_History", "nsCurrent", c => c.Double());
            AddPrimaryKey("dbo.HR_Degree", "DegreeID");
            AddPrimaryKey("dbo.HR_Designation", "DesignationId");
            DropColumn("dbo.HR_Degree", "AllowanceMode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HR_Degree", "AllowanceMode", c => c.String(nullable: false, maxLength: 2));
            DropPrimaryKey("dbo.HR_Designation");
            DropPrimaryKey("dbo.HR_Degree");
            AlterColumn("dbo.HR_History", "nsCurrent", c => c.Double(nullable: false));
            AlterColumn("dbo.HR_History", "nsAllowance", c => c.Double(nullable: false));
            AlterColumn("dbo.HR_History", "nsBasic", c => c.Double(nullable: false));
            AlterColumn("dbo.HR_History", "psCurrent", c => c.Double(nullable: false));
            AlterColumn("dbo.HR_History", "psAllowance", c => c.Double(nullable: false));
            AlterColumn("dbo.HR_History", "psBasic", c => c.Double(nullable: false));
            AlterColumn("dbo.HR_EmployeeQualification", "DegreeSession", c => c.String(maxLength: 15));
            AlterColumn("dbo.HR_EmployeeQualification", "Status", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_EmployeeQualification", "Division", c => c.String(maxLength: 5));
            AlterColumn("dbo.HR_EmployeeQualification", "Grade", c => c.String(maxLength: 5));
            AlterColumn("dbo.HR_Designation", "DesignationId", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_DayStatus", "CountAs", c => c.Boolean(nullable: false));
            AlterColumn("dbo.HR_DayStatus", "Abbreviation", c => c.String(maxLength: 1));
            AlterColumn("dbo.HR_CINCR", "ReportedBy", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_CINCR", "EmpDept", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_AttendanceTimings", "Checkin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HR_AttendanceTimings", "AttendanceDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.HR_EmployeeType", "ModifiedOn");
            DropColumn("dbo.HR_EmployeeType", "ModifiedBy");
            DropColumn("dbo.HR_EmployeeType", "CreatedOn");
            DropColumn("dbo.HR_EmployeeType", "CreatedBy");
            DropColumn("dbo.HR_EmployeeQualification", "ModifiedOn");
            DropColumn("dbo.HR_EmployeeQualification", "ModifiedBy");
            DropColumn("dbo.HR_EmployeeQualification", "CreatedOn");
            DropColumn("dbo.HR_EmployeeQualification", "CreatedBy");
            DropColumn("dbo.HR_EmployeeLoanAdvanceBalance", "ModifiedOn");
            DropColumn("dbo.HR_EmployeeLoanAdvanceBalance", "ModifiedBy");
            DropColumn("dbo.HR_EmployeeLoanAdvanceBalance", "CreatedOn");
            DropColumn("dbo.HR_EmployeeLoanAdvanceBalance", "CreatedBy");
            DropColumn("dbo.HR_EmployeeLeaveBalance", "ModifiedOn");
            DropColumn("dbo.HR_EmployeeLeaveBalance", "ModifiedBy");
            DropColumn("dbo.HR_EmployeeLeaveBalance", "CreatedOn");
            DropColumn("dbo.HR_EmployeeLeaveBalance", "CreatedBy");
            DropColumn("dbo.HR_EmployeeExperience", "ModifiedOn");
            DropColumn("dbo.HR_EmployeeExperience", "ModifiedBy");
            DropColumn("dbo.HR_EmployeeExperience", "CreatedOn");
            DropColumn("dbo.HR_EmployeeExperience", "CreatedBy");
            DropColumn("dbo.HR_EmployeeAllowances", "ModifiedOn");
            DropColumn("dbo.HR_EmployeeAllowances", "ModifiedBy");
            DropColumn("dbo.HR_EmployeeAllowances", "CreatedOn");
            DropColumn("dbo.HR_EmployeeAllowances", "CreatedBy");
            DropColumn("dbo.HR_Degree", "DegreeID");
            AddPrimaryKey("dbo.HR_Designation", "DesignationId");
            AddPrimaryKey("dbo.HR_Degree", "AllowanceMode");
        }
    }
}
