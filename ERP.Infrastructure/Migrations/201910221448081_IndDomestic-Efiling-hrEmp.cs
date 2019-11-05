namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndDomesticEfilinghrEmp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HrEmployees", "dob", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HrEmployees", "NICExpiry", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HrEmployees", "PassportExpiry", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HrEmployees", "JoiningDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HrEmployees", "TerminatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HrEmployees", "SettledOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HrEmployees", "EOBIMemberSince", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.HrEmployees", "OrientationConductedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HrEmployees", "OrientationConductedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HrEmployees", "EOBIMemberSince", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HrEmployees", "SettledOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HrEmployees", "TerminatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HrEmployees", "JoiningDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HrEmployees", "PassportExpiry", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HrEmployees", "NICExpiry", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HrEmployees", "dob", c => c.DateTime(nullable: false));
        }
    }
}
