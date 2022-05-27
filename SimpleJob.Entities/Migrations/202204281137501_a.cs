namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblMail", "Uye_UyeId", c => c.Int());
            AddColumn("dbo.tblMail", "AliciUyeId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblMail", "Uye_UyeId");
            AddForeignKey("dbo.tblMail", "Uye_UyeId", "dbo.tblUye", "UyeId");
        }
    }
}
