namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dosyatableupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblIs", "Dosya_DosyaId", "dbo.tblDosya");
            DropForeignKey("dbo.tblDosya", "Is_IsId", "dbo.tblIs");
            DropForeignKey("dbo.tblIs", "Dosya_DosyaId1", "dbo.tblDosya");
            DropIndex("dbo.tblDosya", new[] { "Is_IsId" });
            DropIndex("dbo.tblIs", new[] { "Dosya_DosyaId" });
            DropIndex("dbo.tblIs", new[] { "Dosya_DosyaId1" });
            DropColumn("dbo.tblDosya", "Is_IsId");
            DropColumn("dbo.tblIs", "DosyaId");
            DropColumn("dbo.tblIs", "Dosya_DosyaId");
            DropColumn("dbo.tblIs", "Dosya_DosyaId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblIs", "Dosya_DosyaId1", c => c.Int());
            AddColumn("dbo.tblIs", "Dosya_DosyaId", c => c.Int());
            AddColumn("dbo.tblIs", "DosyaId", c => c.Int(nullable: false));
            AddColumn("dbo.tblDosya", "Is_IsId", c => c.Int());
            CreateIndex("dbo.tblIs", "Dosya_DosyaId1");
            CreateIndex("dbo.tblIs", "Dosya_DosyaId");
            CreateIndex("dbo.tblDosya", "Is_IsId");
            AddForeignKey("dbo.tblIs", "Dosya_DosyaId1", "dbo.tblDosya", "DosyaId");
            AddForeignKey("dbo.tblDosya", "Is_IsId", "dbo.tblIs", "IsId");
            AddForeignKey("dbo.tblIs", "Dosya_DosyaId", "dbo.tblDosya", "DosyaId");
        }
    }
}
