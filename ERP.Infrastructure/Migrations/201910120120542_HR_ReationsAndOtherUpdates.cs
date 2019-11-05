﻿namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HR_ReationsAndOtherUpdates : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HR_EmployeeAllowances");
            DropPrimaryKey("dbo.HR_SalaryDetail");
            CreateTable(
                "dbo.HR_Photo",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        EmployeeNo = c.String(nullable: false, maxLength: 5),
                        filePatch = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HrEmployees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.EmployeeId);
            
            AddColumn("dbo.HrDepartments", "DepartmentKey", c => c.String(maxLength: 4));
            AddColumn("dbo.Cities", "CityKey", c => c.String(maxLength: 4));
            AddColumn("dbo.Companies", "Company_Key", c => c.String(maxLength: 3));
            AddColumn("dbo.HR_AttendanceTimings", "CompanyKey", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_AttendanceTimings", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_CINCR", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeAllowances", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.HR_EmployeeAllowances", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeExperience", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLeaveBalance", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLeaveBalance", "companyID", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLeaveBalance", "CompanyKey", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_EmployeeLoanAdvanceBalance", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLoanAdvanceBalance", "companyID", c => c.Int(nullable: false));
            AddColumn("dbo.HR_EmployeeLoanAdvanceBalance", "CompanyKey", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_EmployeeQualification", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_GazzettedDays", "companyID", c => c.Int(nullable: false));
            AddColumn("dbo.HR_GazzettedDays", "CompanyKey", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_History", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_History", "companyID", c => c.Int(nullable: false));
            AddColumn("dbo.HR_History", "CompanyKey", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_HistoryDetails", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_LeaveRequest", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_LeaveRequest", "CompanyKey", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_LoanAdvance", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_LoanAdvanceApplication", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_MonthlyAttendance", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_SalaryDetail", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.HR_SalaryMaster", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_SalaryMaster", "companyID", c => c.Int(nullable: false));
            AddColumn("dbo.HR_SalaryMaster", "DeptId", c => c.Int(nullable: false));
            AddColumn("dbo.HR_ShortLeaves", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.HrEmployees", "PermanentCityIdKey", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.HrEmployees", "TemporaryCityKey", c => c.String(nullable: false, maxLength: 4));
            AddColumn("dbo.HrEmployees", "DeptId", c => c.Int(nullable: false));
            AddColumn("dbo.HrEmployees", "CompanyKey", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_AttendanceTimings", "companyID", c => c.Int(nullable: false));
            AlterColumn("dbo.HR_EmployeeAllowances", "AllowanceID", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_EmployeeQualification", "EmployeeNo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_HistoryDetails", "EmployeeNo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_HistoryDetails", "AllowanceID", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_LeaveRequest", "companyID", c => c.Int(nullable: false));
            AlterColumn("dbo.HR_LeaveRequest", "EmployeeNo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_LoanAdvance", "EmployeeNo", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.HR_LoanAdvanceApplication", "companyID", c => c.Int(nullable: false));
            AlterColumn("dbo.HR_MonthlyAttendance", "companyID", c => c.Int(nullable: false));
            AlterColumn("dbo.HR_SalaryDetail", "EmployeeSalaryMasterId", c => c.String(maxLength: 11));
            AlterColumn("dbo.HR_SalaryMaster", "DesignationCode", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.HR_ShortLeaves", "companyID", c => c.Int(nullable: false));
            AlterColumn("dbo.HrEmployees", "PermanentCityId", c => c.Int(nullable: false));
            AlterColumn("dbo.HrEmployees", "TemporaryCityId", c => c.Int(nullable: false));
            AlterColumn("dbo.HrEmployees", "Designation", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.HrEmployees", "companyID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.HR_EmployeeAllowances", "id");
            AddPrimaryKey("dbo.HR_SalaryDetail", "Id");
            CreateIndex("dbo.HR_SalaryMaster", "EmployeeId");
            CreateIndex("dbo.HR_SalaryMaster", "companyID");
            CreateIndex("dbo.HR_SalaryMaster", "DeptId");
            CreateIndex("dbo.HR_SalaryMaster", "DesignationCode");
            CreateIndex("dbo.HR_AttendanceTimings", "companyID");
            CreateIndex("dbo.HR_AttendanceTimings", "EmployeeId");
            CreateIndex("dbo.HrEmployees", "EmployeeType");
            CreateIndex("dbo.HrEmployees", "DeptId");
            CreateIndex("dbo.HrEmployees", "Designation");
            CreateIndex("dbo.HR_CINCR", "EmployeeId");
            CreateIndex("dbo.HR_EmployeeAllowances", "EmployeeId");
            CreateIndex("dbo.HR_EmployeeAllowances", "AllowanceID");
            CreateIndex("dbo.HR_HistoryDetails", "EmployeeId");
            CreateIndex("dbo.HR_HistoryDetails", "AllowanceID");
            CreateIndex("dbo.HR_EmployeeExperience", "EmployeeId");
            CreateIndex("dbo.HR_EmployeeLeaveBalance", "EmployeeId");
            CreateIndex("dbo.HR_EmployeeLeaveBalance", "companyID");
            CreateIndex("dbo.HR_EmployeeLoanAdvanceBalance", "EmployeeId");
            CreateIndex("dbo.HR_EmployeeLoanAdvanceBalance", "companyID");
            CreateIndex("dbo.HR_EmployeeQualification", "EmployeeId");
            CreateIndex("dbo.HR_EmployeeQualification", "DegreeId");
            CreateIndex("dbo.HR_History", "EmployeeId");
            CreateIndex("dbo.HR_History", "companyID");
            CreateIndex("dbo.HR_LeaveRequest", "EmployeeId");
            CreateIndex("dbo.HR_LeaveRequest", "companyID");
            CreateIndex("dbo.HR_LoanAdvance", "EmployeeId");
            CreateIndex("dbo.HR_LoanAdvanceApplication", "EmployeeId");
            CreateIndex("dbo.HR_LoanAdvanceApplication", "companyID");
            CreateIndex("dbo.HR_MonthlyAttendance", "EmployeeId");
            CreateIndex("dbo.HR_MonthlyAttendance", "companyID");
            CreateIndex("dbo.HR_ShortLeaves", "EmployeeId");
            CreateIndex("dbo.HR_ShortLeaves", "companyID");
            CreateIndex("dbo.HR_GazzettedDays", "companyID");
            CreateIndex("dbo.HR_SalaryDetail", "EmployeeSalaryMasterId");
            AddForeignKey("dbo.HR_AttendanceTimings", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_CINCR", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_HistoryDetails", "AllowanceID", "dbo.HR_Allowances", "AllowanceID", cascadeDelete: false);
            AddForeignKey("dbo.HR_HistoryDetails", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_EmployeeAllowances", "AllowanceID", "dbo.HR_Allowances", "AllowanceID", cascadeDelete: false);
            AddForeignKey("dbo.HR_EmployeeAllowances", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_EmployeeExperience", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_EmployeeLeaveBalance", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_EmployeeLeaveBalance", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_EmployeeLoanAdvanceBalance", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_EmployeeLoanAdvanceBalance", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_EmployeeQualification", "DegreeId", "dbo.HR_Degree", "DegreeID");
            AddForeignKey("dbo.HR_EmployeeQualification", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HrEmployees", "EmployeeType", "dbo.HR_EmployeeType", "EmployeeTypeID", cascadeDelete: false);
            AddForeignKey("dbo.HR_History", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_History", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_LeaveRequest", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_LeaveRequest", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_LoanAdvance", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_LoanAdvanceApplication", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_LoanAdvanceApplication", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_MonthlyAttendance", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_MonthlyAttendance", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_ShortLeaves", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_ShortLeaves", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HrEmployees", "DeptId", "dbo.HrDepartments", "id", cascadeDelete: false);
            AddForeignKey("dbo.HrEmployees", "Designation", "dbo.HR_Designation", "DesignationId", cascadeDelete: false);
            AddForeignKey("dbo.HR_AttendanceTimings", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_GazzettedDays", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_SalaryMaster", "companyID", "dbo.Companies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HR_SalaryMaster", "DesignationCode", "dbo.HR_Designation", "DesignationId", cascadeDelete: false);
            AddForeignKey("dbo.HR_SalaryDetail", "EmployeeSalaryMasterId", "dbo.HR_SalaryMaster", "EmployeeSalaryMasterId");
            AddForeignKey("dbo.HR_SalaryMaster", "DeptId", "dbo.HrDepartments", "id", cascadeDelete: false);
            AddForeignKey("dbo.HR_SalaryMaster", "EmployeeId", "dbo.HrEmployees", "Id", cascadeDelete: false);
            DropColumn("dbo.HrDepartments", "DepartmentID_Key");
            DropColumn("dbo.Companies", "CompanyId_Key");
            DropColumn("dbo.HR_EmployeeLeaveBalance", "Company");
            DropColumn("dbo.HR_EmployeeLoanAdvanceBalance", "Company");
            DropColumn("dbo.HR_GazzettedDays", "Company");
            DropColumn("dbo.HR_History", "Company");
            DropColumn("dbo.HR_SalaryMaster", "Company");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HR_SalaryMaster", "Company", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_History", "Company", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_GazzettedDays", "Company", c => c.String(maxLength: 3));
            AddColumn("dbo.HR_EmployeeLoanAdvanceBalance", "Company", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.HR_EmployeeLeaveBalance", "Company", c => c.String(nullable: false, maxLength: 3));
            AddColumn("dbo.Companies", "CompanyId_Key", c => c.String(maxLength: 3));
            AddColumn("dbo.HrDepartments", "DepartmentID_Key", c => c.String(maxLength: 4));
            DropForeignKey("dbo.HR_SalaryMaster", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_SalaryMaster", "DeptId", "dbo.HrDepartments");
            DropForeignKey("dbo.HR_SalaryDetail", "EmployeeSalaryMasterId", "dbo.HR_SalaryMaster");
            DropForeignKey("dbo.HR_SalaryMaster", "DesignationCode", "dbo.HR_Designation");
            DropForeignKey("dbo.HR_SalaryMaster", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HR_GazzettedDays", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HR_AttendanceTimings", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HrEmployees", "Designation", "dbo.HR_Designation");
            DropForeignKey("dbo.HrEmployees", "DeptId", "dbo.HrDepartments");
            DropForeignKey("dbo.HR_ShortLeaves", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_ShortLeaves", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HR_Photo", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_MonthlyAttendance", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_MonthlyAttendance", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HR_LoanAdvanceApplication", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_LoanAdvanceApplication", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HR_LoanAdvance", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_LeaveRequest", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_LeaveRequest", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HR_History", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_History", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HrEmployees", "EmployeeType", "dbo.HR_EmployeeType");
            DropForeignKey("dbo.HR_EmployeeQualification", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_EmployeeQualification", "DegreeId", "dbo.HR_Degree");
            DropForeignKey("dbo.HR_EmployeeLoanAdvanceBalance", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_EmployeeLoanAdvanceBalance", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HR_EmployeeLeaveBalance", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_EmployeeLeaveBalance", "companyID", "dbo.Companies");
            DropForeignKey("dbo.HR_EmployeeExperience", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_EmployeeAllowances", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_EmployeeAllowances", "AllowanceID", "dbo.HR_Allowances");
            DropForeignKey("dbo.HR_HistoryDetails", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_HistoryDetails", "AllowanceID", "dbo.HR_Allowances");
            DropForeignKey("dbo.HR_CINCR", "EmployeeId", "dbo.HrEmployees");
            DropForeignKey("dbo.HR_AttendanceTimings", "companyID", "dbo.Companies");
            DropIndex("dbo.HR_SalaryDetail", new[] { "EmployeeSalaryMasterId" });
            DropIndex("dbo.HR_GazzettedDays", new[] { "companyID" });
            DropIndex("dbo.HR_ShortLeaves", new[] { "companyID" });
            DropIndex("dbo.HR_ShortLeaves", new[] { "EmployeeId" });
            DropIndex("dbo.HR_Photo", new[] { "EmployeeId" });
            DropIndex("dbo.HR_MonthlyAttendance", new[] { "companyID" });
            DropIndex("dbo.HR_MonthlyAttendance", new[] { "EmployeeId" });
            DropIndex("dbo.HR_LoanAdvanceApplication", new[] { "companyID" });
            DropIndex("dbo.HR_LoanAdvanceApplication", new[] { "EmployeeId" });
            DropIndex("dbo.HR_LoanAdvance", new[] { "EmployeeId" });
            DropIndex("dbo.HR_LeaveRequest", new[] { "companyID" });
            DropIndex("dbo.HR_LeaveRequest", new[] { "EmployeeId" });
            DropIndex("dbo.HR_History", new[] { "companyID" });
            DropIndex("dbo.HR_History", new[] { "EmployeeId" });
            DropIndex("dbo.HR_EmployeeQualification", new[] { "DegreeId" });
            DropIndex("dbo.HR_EmployeeQualification", new[] { "EmployeeId" });
            DropIndex("dbo.HR_EmployeeLoanAdvanceBalance", new[] { "companyID" });
            DropIndex("dbo.HR_EmployeeLoanAdvanceBalance", new[] { "EmployeeId" });
            DropIndex("dbo.HR_EmployeeLeaveBalance", new[] { "companyID" });
            DropIndex("dbo.HR_EmployeeLeaveBalance", new[] { "EmployeeId" });
            DropIndex("dbo.HR_EmployeeExperience", new[] { "EmployeeId" });
            DropIndex("dbo.HR_HistoryDetails", new[] { "AllowanceID" });
            DropIndex("dbo.HR_HistoryDetails", new[] { "EmployeeId" });
            DropIndex("dbo.HR_EmployeeAllowances", new[] { "AllowanceID" });
            DropIndex("dbo.HR_EmployeeAllowances", new[] { "EmployeeId" });
            DropIndex("dbo.HR_CINCR", new[] { "EmployeeId" });
            DropIndex("dbo.HrEmployees", new[] { "Designation" });
            DropIndex("dbo.HrEmployees", new[] { "DeptId" });
            DropIndex("dbo.HrEmployees", new[] { "EmployeeType" });
            DropIndex("dbo.HR_AttendanceTimings", new[] { "EmployeeId" });
            DropIndex("dbo.HR_AttendanceTimings", new[] { "companyID" });
            DropIndex("dbo.HR_SalaryMaster", new[] { "DesignationCode" });
            DropIndex("dbo.HR_SalaryMaster", new[] { "DeptId" });
            DropIndex("dbo.HR_SalaryMaster", new[] { "companyID" });
            DropIndex("dbo.HR_SalaryMaster", new[] { "EmployeeId" });
            DropPrimaryKey("dbo.HR_SalaryDetail");
            DropPrimaryKey("dbo.HR_EmployeeAllowances");
            AlterColumn("dbo.HrEmployees", "companyID", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HrEmployees", "Designation", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HrEmployees", "TemporaryCityId", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HrEmployees", "PermanentCityId", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.HR_ShortLeaves", "companyID", c => c.String(maxLength: 3));
            AlterColumn("dbo.HR_SalaryMaster", "DesignationCode", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_SalaryDetail", "EmployeeSalaryMasterId", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.HR_MonthlyAttendance", "companyID", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_LoanAdvanceApplication", "companyID", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.HR_LoanAdvance", "EmployeeNo", c => c.String(maxLength: 5));
            AlterColumn("dbo.HR_LeaveRequest", "EmployeeNo", c => c.String(maxLength: 5));
            AlterColumn("dbo.HR_LeaveRequest", "companyID", c => c.String(maxLength: 3));
            AlterColumn("dbo.HR_HistoryDetails", "AllowanceID", c => c.String(maxLength: 4));
            AlterColumn("dbo.HR_HistoryDetails", "EmployeeNo", c => c.String(maxLength: 5));
            AlterColumn("dbo.HR_EmployeeQualification", "EmployeeNo", c => c.String(maxLength: 5));
            AlterColumn("dbo.HR_EmployeeAllowances", "AllowanceID", c => c.String(maxLength: 4));
            AlterColumn("dbo.HR_AttendanceTimings", "companyID", c => c.String(nullable: false, maxLength: 3));
            DropColumn("dbo.HrEmployees", "CompanyKey");
            DropColumn("dbo.HrEmployees", "DeptId");
            DropColumn("dbo.HrEmployees", "TemporaryCityKey");
            DropColumn("dbo.HrEmployees", "PermanentCityIdKey");
            DropColumn("dbo.HR_ShortLeaves", "EmployeeId");
            DropColumn("dbo.HR_SalaryMaster", "DeptId");
            DropColumn("dbo.HR_SalaryMaster", "companyID");
            DropColumn("dbo.HR_SalaryMaster", "EmployeeId");
            DropColumn("dbo.HR_SalaryDetail", "Id");
            DropColumn("dbo.HR_MonthlyAttendance", "EmployeeId");
            DropColumn("dbo.HR_LoanAdvanceApplication", "EmployeeId");
            DropColumn("dbo.HR_LoanAdvance", "EmployeeId");
            DropColumn("dbo.HR_LeaveRequest", "CompanyKey");
            DropColumn("dbo.HR_LeaveRequest", "EmployeeId");
            DropColumn("dbo.HR_HistoryDetails", "EmployeeId");
            DropColumn("dbo.HR_History", "CompanyKey");
            DropColumn("dbo.HR_History", "companyID");
            DropColumn("dbo.HR_History", "EmployeeId");
            DropColumn("dbo.HR_GazzettedDays", "CompanyKey");
            DropColumn("dbo.HR_GazzettedDays", "companyID");
            DropColumn("dbo.HR_EmployeeQualification", "EmployeeId");
            DropColumn("dbo.HR_EmployeeLoanAdvanceBalance", "CompanyKey");
            DropColumn("dbo.HR_EmployeeLoanAdvanceBalance", "companyID");
            DropColumn("dbo.HR_EmployeeLoanAdvanceBalance", "EmployeeId");
            DropColumn("dbo.HR_EmployeeLeaveBalance", "CompanyKey");
            DropColumn("dbo.HR_EmployeeLeaveBalance", "companyID");
            DropColumn("dbo.HR_EmployeeLeaveBalance", "EmployeeId");
            DropColumn("dbo.HR_EmployeeExperience", "EmployeeId");
            DropColumn("dbo.HR_EmployeeAllowances", "EmployeeId");
            DropColumn("dbo.HR_EmployeeAllowances", "id");
            DropColumn("dbo.HR_CINCR", "EmployeeId");
            DropColumn("dbo.HR_AttendanceTimings", "EmployeeId");
            DropColumn("dbo.HR_AttendanceTimings", "CompanyKey");
            DropColumn("dbo.Companies", "Company_Key");
            DropColumn("dbo.Cities", "CityKey");
            DropColumn("dbo.HrDepartments", "DepartmentKey");
            DropTable("dbo.HR_Photo");
            AddPrimaryKey("dbo.HR_SalaryDetail", "EmployeeSalaryMasterId");
            AddPrimaryKey("dbo.HR_EmployeeAllowances", "EmployeeNo");
        }
    }
}
