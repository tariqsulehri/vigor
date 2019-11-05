namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yarnHRApprovalupdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.YarnInspections", "ShipmentScheduleId", "dbo.IndDomesticDispatchSchedules");
            DropForeignKey("dbo.YarnInspections", "YarnInsPectionGradeId", "dbo.YarnInspectionGrades");
            DropIndex("dbo.YarnInspections", new[] { "YarnInsPectionGradeId" });
            DropIndex("dbo.YarnInspections", new[] { "ShipmentScheduleId" });
            AlterColumn("dbo.EmailContractApprovals", "FromEmail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.EmailContractApprovals", "ToEmail", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmailContractApprovals", "ToEmail", c => c.String(maxLength: 50));
            AlterColumn("dbo.EmailContractApprovals", "FromEmail", c => c.String(maxLength: 50));
            CreateIndex("dbo.YarnInspections", "ShipmentScheduleId");
            CreateIndex("dbo.YarnInspections", "YarnInsPectionGradeId");
            AddForeignKey("dbo.YarnInspections", "YarnInsPectionGradeId", "dbo.YarnInspectionGrades", "Id", cascadeDelete: true);
            AddForeignKey("dbo.YarnInspections", "ShipmentScheduleId", "dbo.IndDomesticDispatchSchedules", "Id", cascadeDelete: true);
        }
    }
}
