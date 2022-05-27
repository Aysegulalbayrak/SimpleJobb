namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class istable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblIs", "OlusturanUyeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblIs", "OlusturanUyeId", c => c.Int(nullable: false));
        }
    }
}
