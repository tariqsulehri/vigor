namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeptDescriptRequiredRemoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HrDepartments", "DeptDescription", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HrDepartments", "DeptDescription", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
