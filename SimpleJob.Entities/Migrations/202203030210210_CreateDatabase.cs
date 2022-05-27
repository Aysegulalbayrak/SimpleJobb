namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblDosya",
                c => new
                    {
                        DosyaId = c.Int(nullable: false, identity: true),
                        IsId = c.Int(nullable: false),
                        DosyaAdi = c.String(maxLength: 100),
                        DosyaUzantisi = c.String(maxLength: 100),
                        DosyaYolu = c.String(maxLength: 200),
                        DosyaAciklama = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.DosyaId)
                .ForeignKey("dbo.tblIs", t => t.IsId, cascadeDelete: true)
                .Index(t => t.IsId);
            
            CreateTable(
                "dbo.tblIs",
                c => new
                    {
                        IsId = c.Int(nullable: false, identity: true),
                        IsKategoriId = c.Int(nullable: false),
                        IsBaslik = c.String(maxLength: 100),
                        IsAciklama = c.String(maxLength: 4000),
                        SonTeslimTarihi = c.DateTime(nullable: false, storeType: "date"),
                        IlerlemeDurumu = c.Int(nullable: false),
                        UslenenUyeId = c.Int(nullable: false),
                        OlusturanUyeId = c.Int(nullable: false),
                        IsDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IsId)
                .ForeignKey("dbo.tblIsKategori", t => t.IsKategoriId, cascadeDelete: true)
                .ForeignKey("dbo.tblUye", t => t.OlusturanUyeId, cascadeDelete: true)
                .Index(t => t.IsKategoriId)
                .Index(t => t.OlusturanUyeId);
            
            CreateTable(
                "dbo.tblIsKategori",
                c => new
                    {
                        IsKategoriId = c.Int(nullable: false, identity: true),
                        IsKategoriAdi = c.String(maxLength: 100),
                        IsKategoriDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IsKategoriId);
            
            CreateTable(
                "dbo.tblRapor",
                c => new
                    {
                        RaporId = c.Int(nullable: false, identity: true),
                        IsId = c.Int(nullable: false),
                        UyeId = c.Int(nullable: false),
                        RaporTarihi = c.DateTime(nullable: false, storeType: "date"),
                        RaporAdi = c.String(maxLength: 100),
                        RaporDurumu = c.Boolean(nullable: false),
                        DurumOzeti = c.String(maxLength: 4000),
                        TamamlananYuzde = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaporId)
                .ForeignKey("dbo.tblIs", t => t.IsId, cascadeDelete: true)
                .ForeignKey("dbo.tblUye", t => t.UyeId, cascadeDelete: false)
                .Index(t => t.IsId)
                .Index(t => t.UyeId);
            
            CreateTable(
                "dbo.tblUye",
                c => new
                    {
                        UyeId = c.Int(nullable: false, identity: true),
                        UyeAdi = c.String(maxLength: 100),
                        UyeSoyadi = c.String(maxLength: 100),
                        UyeEmail = c.String(maxLength: 500),
                        UyeKAdi = c.String(maxLength: 500),
                        UyeSifre = c.String(maxLength: 500),
                        UyeDurumu = c.Boolean(nullable: false),
                        UyeUnvanId = c.Int(nullable: false),
                        UyeCinsiyet = c.String(maxLength: 50),
                        UyeIseBaslamaTarihi = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.UyeId)
                .ForeignKey("dbo.tblUnvan", t => t.UyeUnvanId, cascadeDelete: true)
                .Index(t => t.UyeUnvanId);
            
            CreateTable(
                "dbo.tblUnvan",
                c => new
                    {
                        UnvanId = c.Int(nullable: false, identity: true),
                        UnvanAdi = c.String(maxLength: 100),
                        UnvanAciklama = c.String(maxLength: 4000),
                        UnvanDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UnvanId);
            
            CreateTable(
                "dbo.tblMail",
                c => new
                    {
                        MailId = c.Int(nullable: false, identity: true),
                        AliciMailAdresi = c.String(maxLength: 1000),
                        GondericiMailAdresi = c.String(maxLength: 1000),
                        MailBaslik = c.String(maxLength: 200),
                        MailAciklama = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.MailId);
            
            CreateTable(
                "dbo.tblTakvim",
                c => new
                    {
                        TakvimId = c.Int(nullable: false, identity: true),
                        Gun = c.Int(nullable: false),
                        Ay = c.Int(nullable: false),
                        Yıl = c.Int(nullable: false),
                        TakvimBaslik = c.String(maxLength: 100),
                        TakvimAciklama = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.TakvimId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblDosya", "IsId", "dbo.tblIs");
            DropForeignKey("dbo.tblIs", "OlusturanUyeId", "dbo.tblUye");
            DropForeignKey("dbo.tblRapor", "UyeId", "dbo.tblUye");
            DropForeignKey("dbo.tblUye", "UyeUnvanId", "dbo.tblUnvan");
            DropForeignKey("dbo.tblRapor", "IsId", "dbo.tblIs");
            DropForeignKey("dbo.tblIs", "IsKategoriId", "dbo.tblIsKategori");
            DropIndex("dbo.tblUye", new[] { "UyeUnvanId" });
            DropIndex("dbo.tblRapor", new[] { "UyeId" });
            DropIndex("dbo.tblRapor", new[] { "IsId" });
            DropIndex("dbo.tblIs", new[] { "OlusturanUyeId" });
            DropIndex("dbo.tblIs", new[] { "IsKategoriId" });
            DropIndex("dbo.tblDosya", new[] { "IsId" });
            DropTable("dbo.tblTakvim");
            DropTable("dbo.tblMail");
            DropTable("dbo.tblUnvan");
            DropTable("dbo.tblUye");
            DropTable("dbo.tblRapor");
            DropTable("dbo.tblIsKategori");
            DropTable("dbo.tblIs");
            DropTable("dbo.tblDosya");
        }
    }
}
