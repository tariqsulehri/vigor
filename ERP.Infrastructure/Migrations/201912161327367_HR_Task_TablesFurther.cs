namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HR_Task_TablesFurther : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FNLAccounts", "PartyId", "dbo.FinParties");
            DropIndex("dbo.FNLAccounts", new[] { "PartyId" });
            RenameColumn(table: "dbo.FNLAccounts", name: "PartyId", newName: "FinParty_Id");
            DropPrimaryKey("dbo.FNLAccounts");
            CreateTable(
                "dbo.GeneralTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralTaskIDKey = c.String(maxLength: 9),
                        TaskDate = c.DateTime(nullable: false),
                        Subject = c.String(maxLength: 100),
                        Description = c.String(maxLength: 2000),
                        TaskProgress = c.String(maxLength: 1000),
                        TaskAssignedById = c.Int(nullable: false),
                        TaskAssignedByDeptID = c.Int(nullable: false),
                        TaskCompletionDate = c.DateTime(),
                        IsApproved = c.String(maxLength: 1),
                        IsCompleted = c.String(maxLength: 1),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HrDepartments", t => t.TaskAssignedByDeptID, cascadeDelete: true)
                .ForeignKey("dbo.HrEmployees", t => t.TaskAssignedById, cascadeDelete: true)
                .Index(t => t.TaskAssignedById)
                .Index(t => t.TaskAssignedByDeptID);
            
            CreateTable(
                "dbo.MinutesOfMeetings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IdKey = c.String(maxLength: 9),
                        TypeId = c.String(maxLength: 2),
                        IDDATE = c.DateTime(),
                        SUBJECT = c.String(maxLength: 500),
                        Agenda = c.String(maxLength: 500),
                        Venue = c.String(maxLength: 100),
                        Minuts = c.String(unicode: false, storeType: "text"),
                        Participants = c.String(maxLength: 1000),
                        ReportedById = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HrDepartments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.HrEmployees", t => t.ReportedById, cascadeDelete: true)
                .ForeignKey("dbo.MeetingLogTypes", t => t.TypeId)
                .Index(t => t.TypeId)
                .Index(t => t.ReportedById)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.MeetingLogTypes",
                c => new
                    {
                        Type = c.String(nullable: false, maxLength: 2),
                        MeetingDesc = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.TaskAttachments_2BDeleted",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskIDKey = c.String(maxLength: 9),
                        FileName = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        HrTaskRegister_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HrTaskRegisters", t => t.HrTaskRegister_Id)
                .Index(t => t.HrTaskRegister_Id);
            
            CreateTable(
                "dbo.ManualActionLogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Department = c.String(maxLength: 50),
                        ActionLog = c.String(maxLength: 1500),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MinutesOfMeetingOfficials",
                c => new
                    {
                        MeetingCode = c.String(nullable: false, maxLength: 9),
                        CompanyOfficial = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.MeetingCode);
            
            AlterColumn("dbo.FNLAccounts", "FNLAccountID", c => c.String(nullable: false, maxLength: 18));
            AlterColumn("dbo.FNLAccounts", "FinParty_Id", c => c.Int());
            AddPrimaryKey("dbo.FNLAccounts", "FNLAccountID");
            CreateIndex("dbo.FNLAccounts", "FinParty_Id");
            AddForeignKey("dbo.FNLAccounts", "FinParty_Id", "dbo.FinParties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FNLAccounts", "FinParty_Id", "dbo.FinParties");
            DropForeignKey("dbo.TaskAttachments_2BDeleted", "HrTaskRegister_Id", "dbo.HrTaskRegisters");
            DropForeignKey("dbo.GeneralTasks", "TaskAssignedById", "dbo.HrEmployees");
            DropForeignKey("dbo.MinutesOfMeetings", "TypeId", "dbo.MeetingLogTypes");
            DropForeignKey("dbo.MinutesOfMeetings", "ReportedById", "dbo.HrEmployees");
            DropForeignKey("dbo.MinutesOfMeetings", "DepartmentId", "dbo.HrDepartments");
            DropForeignKey("dbo.GeneralTasks", "TaskAssignedByDeptID", "dbo.HrDepartments");
            DropIndex("dbo.TaskAttachments_2BDeleted", new[] { "HrTaskRegister_Id" });
            DropIndex("dbo.MinutesOfMeetings", new[] { "DepartmentId" });
            DropIndex("dbo.MinutesOfMeetings", new[] { "ReportedById" });
            DropIndex("dbo.MinutesOfMeetings", new[] { "TypeId" });
            DropIndex("dbo.GeneralTasks", new[] { "TaskAssignedByDeptID" });
            DropIndex("dbo.GeneralTasks", new[] { "TaskAssignedById" });
            DropIndex("dbo.FNLAccounts", new[] { "FinParty_Id" });
            DropPrimaryKey("dbo.FNLAccounts");
            AlterColumn("dbo.FNLAccounts", "FinParty_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.FNLAccounts", "FNLAccountID", c => c.String(nullable: false, maxLength: 10));
            DropTable("dbo.MinutesOfMeetingOfficials");
            DropTable("dbo.ManualActionLogs");
            DropTable("dbo.TaskAttachments_2BDeleted");
            DropTable("dbo.MeetingLogTypes");
            DropTable("dbo.MinutesOfMeetings");
            DropTable("dbo.GeneralTasks");
            AddPrimaryKey("dbo.FNLAccounts", "FNLAccountID");
            RenameColumn(table: "dbo.FNLAccounts", name: "FinParty_Id", newName: "PartyId");
            CreateIndex("dbo.FNLAccounts", "PartyId");
            AddForeignKey("dbo.FNLAccounts", "PartyId", "dbo.FinParties", "Id", cascadeDelete: true);
        }
    }
}
