namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uyetel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUye", "TelefonKodu", c => c.String(maxLength: 50));
            AddColumn("dbo.tblUye", "TelefonNo", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUye", "TelefonNo");
            DropColumn("dbo.tblUye", "TelefonKodu");
        }
    }
}
