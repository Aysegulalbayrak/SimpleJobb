namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMail", "GondericiId", c => c.Int(nullable: false));
            DropColumn("dbo.tblMail", "AliciMailAdresi");
            DropColumn("dbo.tblMail", "GondericiMailAdresi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblMail", "GondericiMailAdresi", c => c.String(maxLength: 1000));
            AddColumn("dbo.tblMail", "AliciMailAdresi", c => c.String(maxLength: 1000));
            DropColumn("dbo.tblMail", "GondericiId");
        }
    }
}
