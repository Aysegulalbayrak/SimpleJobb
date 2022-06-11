namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblMail", "MailKategori_MailKategoriId", "dbo.tblMailKategori");
            DropIndex("dbo.tblMail", new[] { "MailKategori_MailKategoriId" });
            DropColumn("dbo.tblMail", "KategoriId");
            DropColumn("dbo.tblMail", "MailKategori_MailKategoriId");
            DropTable("dbo.tblMailKategori");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tblMailKategori",
                c => new
                    {
                        MailKategoriId = c.Int(nullable: false, identity: true),
                        MailKategoriAdi = c.String(maxLength: 100),
                        MailKategoriDurumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MailKategoriId);
            
            AddColumn("dbo.tblMail", "MailKategori_MailKategoriId", c => c.Int());
            AddColumn("dbo.tblMail", "KategoriId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblMail", "MailKategori_MailKategoriId");
            AddForeignKey("dbo.tblMail", "MailKategori_MailKategoriId", "dbo.tblMailKategori", "MailKategoriId");
        }
    }
}
