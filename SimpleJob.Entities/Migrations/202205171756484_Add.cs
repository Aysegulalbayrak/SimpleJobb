namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUye", "Fotograf", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUye", "Fotograf");
        }
    }
}
