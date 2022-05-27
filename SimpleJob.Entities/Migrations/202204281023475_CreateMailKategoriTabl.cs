namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMailKategoriTabl : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.tblMail", "KategoriId", c => c.Int(nullable: false));
            AddColumn("dbo.tblMail", "MailKategori_MailKategoriId", c => c.Int());
            CreateIndex("dbo.tblMail", "MailKategori_MailKategoriId");
            AddForeignKey("dbo.tblMail", "MailKategori_MailKategoriId", "dbo.tblMailKategori", "MailKategoriId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMail", "MailKategori_MailKategoriId", "dbo.tblMailKategori");
            DropIndex("dbo.tblMail", new[] { "MailKategori_MailKategoriId" });
            DropColumn("dbo.tblMail", "MailKategori_MailKategoriId");
            DropColumn("dbo.tblMail", "KategoriId");
            DropTable("dbo.tblMailKategori");
        }
    }
}
