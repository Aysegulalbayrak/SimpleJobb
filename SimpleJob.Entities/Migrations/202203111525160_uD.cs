namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblTakvim", "Baslangic", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblTakvim", "Bitis", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblTakvim", "Bitis");
            DropColumn("dbo.tblTakvim", "Baslangic");
        }
    }
}
