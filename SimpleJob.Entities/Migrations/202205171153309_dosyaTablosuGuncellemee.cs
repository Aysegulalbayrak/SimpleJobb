namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dosyaTablosuGuncellemee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblDosya", "DosyaAdresi", c => c.String(maxLength: 4000));
            AddColumn("dbo.tblIs", "DosyaId", c => c.Int(nullable: false));
            AddColumn("dbo.tblUye", "DosyaId", c => c.Int(nullable: false));
            DropColumn("dbo.tblDosya", "DosyaAdi");
            DropColumn("dbo.tblDosya", "DosyaSlag");
            DropColumn("dbo.tblDosya", "Alt");
            DropColumn("dbo.tblDosya", "Tittle");
            DropColumn("dbo.tblDosya", "DosyaUrl");
            DropColumn("dbo.tblDosya", "DosyaDurumu");
            DropColumn("dbo.tblIs", "dosya");
            DropColumn("dbo.tblUye", "Fotograf");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUye", "Fotograf", c => c.String(maxLength: 200, unicode: false));
            AddColumn("dbo.tblIs", "dosya", c => c.String(maxLength: 4000));
            AddColumn("dbo.tblDosya", "DosyaDurumu", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblDosya", "DosyaUrl", c => c.String(maxLength: 4000));
            AddColumn("dbo.tblDosya", "Tittle", c => c.String(maxLength: 1000));
            AddColumn("dbo.tblDosya", "Alt", c => c.String(maxLength: 1000));
            AddColumn("dbo.tblDosya", "DosyaSlag", c => c.String(maxLength: 2000));
            AddColumn("dbo.tblDosya", "DosyaAdi", c => c.String(maxLength: 100));
            DropColumn("dbo.tblUye", "DosyaId");
            DropColumn("dbo.tblIs", "DosyaId");
            DropColumn("dbo.tblDosya", "DosyaAdresi");
        }
    }
}
