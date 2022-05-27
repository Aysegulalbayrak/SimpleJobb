namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iliskilerisilme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblIs", "DosyaId", "dbo.tblDosya");
            DropForeignKey("dbo.tblUye", "DosyaId", "dbo.tblDosya");
            DropIndex("dbo.tblIs", new[] { "DosyaId" });
            DropIndex("dbo.tblUye", new[] { "DosyaId" });
            AddColumn("dbo.tblIs", "DosyaAdresi", c => c.String(maxLength: 4000));
            DropColumn("dbo.tblIs", "DosyaId");
            DropColumn("dbo.tblUye", "DosyaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUye", "DosyaId", c => c.Int(nullable: false));
            AddColumn("dbo.tblIs", "DosyaId", c => c.Int(nullable: false));
            DropColumn("dbo.tblIs", "DosyaAdresi");
            CreateIndex("dbo.tblUye", "DosyaId");
            CreateIndex("dbo.tblIs", "DosyaId");
            AddForeignKey("dbo.tblUye", "DosyaId", "dbo.tblDosya", "DosyaId", cascadeDelete: true);
            AddForeignKey("dbo.tblIs", "DosyaId", "dbo.tblDosya", "DosyaId", cascadeDelete: true);
        }
    }
}
