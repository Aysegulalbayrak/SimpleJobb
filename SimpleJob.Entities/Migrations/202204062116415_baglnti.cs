namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baglnti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblTakvim", "takvimDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblTakvim", "takvimDurumu");
        }
    }
}
