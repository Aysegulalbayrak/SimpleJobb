namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class istable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblIs", "Dosya", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblIs", "Dosya");
        }
    }
}
