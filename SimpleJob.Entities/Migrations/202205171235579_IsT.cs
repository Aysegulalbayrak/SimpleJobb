namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblIs", "IsKategoriId", "dbo.tblIsKategori");
            DropIndex("dbo.tblIs", new[] { "IsKategoriId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.tblIs", "IsKategoriId");
            AddForeignKey("dbo.tblIs", "IsKategoriId", "dbo.tblIsKategori", "IsKategoriId", cascadeDelete: true);
        }
    }
}
