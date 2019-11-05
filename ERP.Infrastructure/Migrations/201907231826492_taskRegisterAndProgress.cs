namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskRegisterAndProgress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HrTaskRegisters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskKey = c.String(nullable: false, maxLength: 9),
                        date = c.DateTime(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2000),
                        AssignedTo = c.Int(nullable: false),
                        AssignedBy = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 2),
                        ExpectedCompletionDate = c.DateTime(nullable: false),
                        CompletionDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        HrTaskRegister_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HrDepartments", t => t.DeptId, cascadeDelete: true)
                .ForeignKey("dbo.HrTaskRegisters", t => t.HrTaskRegister_Id)
                .Index(t => t.DeptId)
                .Index(t => t.HrTaskRegister_Id);
            
            CreateTable(
                "dbo.HrTaskProgresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskProgressKey = c.String(nullable: false, maxLength: 11),
                        DeptId = c.Int(nullable: false),
                        TaskKey = c.String(nullable: false, maxLength: 9),
                        Comments = c.String(nullable: false, maxLength: 2500),
                        isActive = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HrTaskRegisters", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HrTaskProgresses", "DeptId", "dbo.HrTaskRegisters");
            DropForeignKey("dbo.HrTaskRegisters", "HrTaskRegister_Id", "dbo.HrTaskRegisters");
            DropForeignKey("dbo.HrTaskRegisters", "DeptId", "dbo.HrDepartments");
            DropIndex("dbo.HrTaskProgresses", new[] { "DeptId" });
            DropIndex("dbo.HrTaskRegisters", new[] { "HrTaskRegister_Id" });
            DropIndex("dbo.HrTaskRegisters", new[] { "DeptId" });
            DropTable("dbo.HrTaskProgresses");
            DropTable("dbo.HrTaskRegisters");
        }
    }
}
