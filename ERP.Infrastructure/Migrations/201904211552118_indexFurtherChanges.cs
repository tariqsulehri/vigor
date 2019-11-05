namespace ERP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indexFurtherChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerContacts", "ContTypeId", "dbo.ContactTypes");
            DropIndex("dbo.AdminModuleDetails", "IX_ModuleName_AdmModule");
            DropIndex("dbo.AdminModuleDetails", "IX_Key_AdmModule");
            DropIndex("dbo.Users", "IX_UserName_Admin");
            DropIndex("dbo.Areas", "IX_Area_Pcommon");
            DropIndex("dbo.Cities", "IX_city_Pcommon");
            DropIndex("dbo.CoaL5", "IX_coaL5_fin");
            DropIndex("dbo.CoaL4", "IX_coaL4_fin");
            DropIndex("dbo.CoaL3", "IX_coaL3_fin");
            DropIndex("dbo.CoaL2", "IX_coaL2_fin");
            DropIndex("dbo.CoaL1", "IX_coaL1_fin");
            DropIndex("dbo.Certifications", "IX_Certification_Pcommon");
            DropIndex("dbo.ContactTypes", "IX_ContactTYpe_common");
            DropIndex("dbo.Machines", "IX_Machine_Pcommon");
            DropIndex("dbo.Socials", "IX_social_Pcommon");
            DropIndex("dbo.SpecialInstructions", "IX_specialInstruction_Pcommon");
            DropIndex("dbo.States", "IX_state_Pcommon");
            DropIndex("dbo.Countries", "IX_country_Pcommon");
            DropIndex("dbo.Regions", "IX_region_Pcommon");
            DropIndex("dbo.BusinessTypes", "IX_Business_Pcommon");
            DropIndex("dbo.Companies", "IX_company_Pcommon");
            DropIndex("dbo.FinFescalYears", "IX_FescalYear_fin");
            DropIndex("dbo.FinFescalYearDetails", "IX_FescalYearDetail_fin");
            AddColumn("dbo.CustomerContacts", "ContactType_Id", c => c.Int());
            CreateIndex("dbo.CustomerContacts", "ContactType_Id");
            AddForeignKey("dbo.CustomerContacts", "ContactType_Id", "dbo.ContactTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerContacts", "ContactType_Id", "dbo.ContactTypes");
            DropIndex("dbo.CustomerContacts", new[] { "ContactType_Id" });
            DropColumn("dbo.CustomerContacts", "ContactType_Id");
            CreateIndex("dbo.FinFescalYearDetails", "MonthKey", unique: true, name: "IX_FescalYearDetail_fin");
            CreateIndex("dbo.FinFescalYears", "YearKey", unique: true, name: "IX_FescalYear_fin");
            CreateIndex("dbo.Companies", "Name", unique: true, name: "IX_company_Pcommon");
            CreateIndex("dbo.BusinessTypes", "BusinessTitle", unique: true, name: "IX_Business_Pcommon");
            CreateIndex("dbo.Regions", "Title", unique: true, name: "IX_region_Pcommon");
            CreateIndex("dbo.Countries", "Name", unique: true, name: "IX_country_Pcommon");
            CreateIndex("dbo.States", "Name", unique: true, name: "IX_state_Pcommon");
            CreateIndex("dbo.SpecialInstructions", "Name", unique: true, name: "IX_specialInstruction_Pcommon");
            CreateIndex("dbo.Socials", "Detail", unique: true, name: "IX_social_Pcommon");
            CreateIndex("dbo.Machines", "Name", unique: true, name: "IX_Machine_Pcommon");
            CreateIndex("dbo.ContactTypes", "Title", unique: true, name: "IX_ContactTYpe_common");
            CreateIndex("dbo.Certifications", "CertificationName", unique: true, name: "IX_Certification_Pcommon");
            CreateIndex("dbo.CoaL1", "Title", unique: true, name: "IX_coaL1_fin");
            CreateIndex("dbo.CoaL2", "Title", unique: true, name: "IX_coaL2_fin");
            CreateIndex("dbo.CoaL3", "Title", unique: true, name: "IX_coaL3_fin");
            CreateIndex("dbo.CoaL4", "Title", unique: true, name: "IX_coaL4_fin");
            CreateIndex("dbo.CoaL5", "Title", unique: true, name: "IX_coaL5_fin");
            CreateIndex("dbo.Cities", "Name", unique: true, name: "IX_city_Pcommon");
            CreateIndex("dbo.Areas", "Name", unique: true, name: "IX_Area_Pcommon");
            CreateIndex("dbo.Users", "UserName", unique: true, name: "IX_UserName_Admin");
            CreateIndex("dbo.AdminModuleDetails", "Key", unique: true, name: "IX_Key_AdmModule");
            CreateIndex("dbo.AdminModuleDetails", "ModuleName", unique: true, name: "IX_ModuleName_AdmModule");
            AddForeignKey("dbo.CustomerContacts", "ContTypeId", "dbo.ContactTypes", "Id", cascadeDelete: true);
        }
    }
}
