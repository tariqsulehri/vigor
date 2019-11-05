namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HrDepartments", "RefDepartmentID", c => c.String(maxLength: 4));
            AddColumn("dbo.HrDepartments", "DeptDescription", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.HrDepartments", "DeptHead", c => c.String(maxLength: 50));
            AddColumn("dbo.HrDepartments", "DeptEmailAddress", c => c.String(maxLength: 100));
            AddColumn("dbo.HrDepartments", "isActve", c => c.String(maxLength: 1));
            AddColumn("dbo.HrDepartments", "DeptNature", c => c.String(maxLength: 1));
            AddColumn("dbo.HrDepartments", "MarketNature", c => c.String(maxLength: 1));
            AddColumn("dbo.HrDepartments", "ScheduleType", c => c.String(maxLength: 1));
            AddColumn("dbo.HrDepartments", "ContractAbbreviation", c => c.String(maxLength: 2));
            AddColumn("dbo.HrDepartments", "DeptCreatedOn", c => c.DateTime());
            AddColumn("dbo.HrDepartments", "CompanyID", c => c.String(maxLength: 3));
            AddColumn("dbo.HrDepartments", "DeptInActiveSince", c => c.DateTime());
            AddColumn("dbo.HrDepartments", "RequireAllColumns", c => c.String(maxLength: 1));
            AddColumn("dbo.HrDepartments", "SalesCommissionAccount", c => c.Int());
            AddColumn("dbo.HrDepartments", "FCSalesCommissionAccountRef", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.HrDepartments", "FCSalesCommissionAccount", c => c.String());
            AddColumn("dbo.HrDepartments", "BadDebtAccountRef", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.HrDepartments", "BadDebtAccount", c => c.String());
            AddColumn("dbo.HrDepartments", "ClaimAccountRef", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HrDepartments", "ClaimAccount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.HrDepartments", "ShowQtyinBVolume", c => c.String(maxLength: 1));
            AddColumn("dbo.HrDepartments", "StandardUnit", c => c.String(maxLength: 2));
            AddColumn("dbo.HrDepartments", "ValidShipmentDelayDays", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.HrDepartments", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HrDepartments", "Title", c => c.String(nullable: false));
            DropColumn("dbo.HrDepartments", "ValidShipmentDelayDays");
            DropColumn("dbo.HrDepartments", "StandardUnit");
            DropColumn("dbo.HrDepartments", "ShowQtyinBVolume");
            DropColumn("dbo.HrDepartments", "ClaimAccount");
            DropColumn("dbo.HrDepartments", "ClaimAccountRef");
            DropColumn("dbo.HrDepartments", "BadDebtAccount");
            DropColumn("dbo.HrDepartments", "BadDebtAccountRef");
            DropColumn("dbo.HrDepartments", "FCSalesCommissionAccount");
            DropColumn("dbo.HrDepartments", "FCSalesCommissionAccountRef");
            DropColumn("dbo.HrDepartments", "SalesCommissionAccount");
            DropColumn("dbo.HrDepartments", "RequireAllColumns");
            DropColumn("dbo.HrDepartments", "DeptInActiveSince");
            DropColumn("dbo.HrDepartments", "CompanyID");
            DropColumn("dbo.HrDepartments", "DeptCreatedOn");
            DropColumn("dbo.HrDepartments", "ContractAbbreviation");
            DropColumn("dbo.HrDepartments", "ScheduleType");
            DropColumn("dbo.HrDepartments", "MarketNature");
            DropColumn("dbo.HrDepartments", "DeptNature");
            DropColumn("dbo.HrDepartments", "isActve");
            DropColumn("dbo.HrDepartments", "DeptEmailAddress");
            DropColumn("dbo.HrDepartments", "DeptHead");
            DropColumn("dbo.HrDepartments", "DeptDescription");
            DropColumn("dbo.HrDepartments", "RefDepartmentID");
        }
    }
}
