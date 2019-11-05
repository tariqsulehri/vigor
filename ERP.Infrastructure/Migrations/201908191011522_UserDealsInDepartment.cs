namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDealsInDepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminUserDealsInDepartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        mKey = c.String(nullable: false, maxLength: 6),
                        UserId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HrDepartments", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminUserDealsInDepartments", "UserId", "dbo.Users");
            DropForeignKey("dbo.AdminUserDealsInDepartments", "DeptId", "dbo.HrDepartments");
            DropIndex("dbo.AdminUserDealsInDepartments", new[] { "DeptId" });
            DropIndex("dbo.AdminUserDealsInDepartments", new[] { "UserId" });
            DropTable("dbo.AdminUserDealsInDepartments");
        }
    }
}
