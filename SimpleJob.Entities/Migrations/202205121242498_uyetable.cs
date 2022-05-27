namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uyetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUye", "github", c => c.String(maxLength: 1500));
            AddColumn("dbo.tblUye", "linkedln", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUye", "linkedln");
            DropColumn("dbo.tblUye", "github");
        }
    }
}
