namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mailbaglanti : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblMail", "Uye_UyeId", "dbo.tblUye");
            DropIndex("dbo.tblMail", new[] { "Uye_UyeId" });
            RenameColumn(table: "dbo.tblMail", name: "Uye_UyeId", newName: "UyeId");
            AlterColumn("dbo.tblMail", "UyeId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblMail", "UyeId");
            AddForeignKey("dbo.tblMail", "UyeId", "dbo.tblUye", "UyeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMail", "UyeId", "dbo.tblUye");
            DropIndex("dbo.tblMail", new[] { "UyeId" });
            AlterColumn("dbo.tblMail", "UyeId", c => c.Int());
            RenameColumn(table: "dbo.tblMail", name: "UyeId", newName: "Uye_UyeId");
            CreateIndex("dbo.tblMail", "Uye_UyeId");
            AddForeignKey("dbo.tblMail", "Uye_UyeId", "dbo.tblUye", "UyeId");
        }
    }
}
