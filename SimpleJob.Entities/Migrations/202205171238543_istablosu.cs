namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class istablosu : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tblIs", "IsKategoriId");
            AddForeignKey("dbo.tblIs", "IsKategoriId", "dbo.tblIsKategori", "IsKategoriId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblIs", "IsKategoriId", "dbo.tblIsKategori");
            DropIndex("dbo.tblIs", new[] { "IsKategoriId" });
        }
    }
}
