namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableRapor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblRapor", "IsKategoriId", "dbo.tblIsKategori");
            DropIndex("dbo.tblRapor", new[] { "IsKategoriId" });
            DropColumn("dbo.tblRapor", "IsKategoriId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblRapor", "IsKategoriId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblRapor", "IsKategoriId");
            AddForeignKey("dbo.tblRapor", "IsKategoriId", "dbo.tblIsKategori", "IsKategoriId", cascadeDelete: true);
        }
    }
}
