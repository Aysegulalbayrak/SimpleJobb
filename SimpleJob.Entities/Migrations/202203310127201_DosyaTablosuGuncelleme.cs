namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DosyaTablosuGuncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblDosya", "DosyaDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblDosya", "DosyaDurumu");
        }
    }
}
