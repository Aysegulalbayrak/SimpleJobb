namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMail", "AliciUyeId", c => c.Int(nullable: false));
            AddColumn("dbo.tblMail", "Uye_UyeId", c => c.Int());
            CreateIndex("dbo.tblMail", "Uye_UyeId");
            AddForeignKey("dbo.tblMail", "Uye_UyeId", "dbo.tblUye", "UyeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMail", "Uye_UyeId", "dbo.tblUye");
            DropIndex("dbo.tblMail", new[] { "Uye_UyeId" });
            DropColumn("dbo.tblMail", "Uye_UyeId");
            DropColumn("dbo.tblMail", "AliciUyeId");
        }
    }
}
