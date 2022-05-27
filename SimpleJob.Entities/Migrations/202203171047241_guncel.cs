namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guncel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblTakvim", "title", c => c.String(maxLength: 100));
            AddColumn("dbo.tblTakvim", "start", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblTakvim", "end", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblTakvim", "color", c => c.String(maxLength: 100));
            AddColumn("dbo.tblTakvim", "textColor", c => c.String(maxLength: 4000));
            DropColumn("dbo.tblTakvim", "Gun");
            DropColumn("dbo.tblTakvim", "Ay");
            DropColumn("dbo.tblTakvim", "Yıl");
            DropColumn("dbo.tblTakvim", "Baslangic");
            DropColumn("dbo.tblTakvim", "Bitis");
            DropColumn("dbo.tblTakvim", "TakvimBaslik");
            DropColumn("dbo.tblTakvim", "TakvimAciklama");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblTakvim", "TakvimAciklama", c => c.String(maxLength: 4000));
            AddColumn("dbo.tblTakvim", "TakvimBaslik", c => c.String(maxLength: 100));
            AddColumn("dbo.tblTakvim", "Bitis", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblTakvim", "Baslangic", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblTakvim", "Yıl", c => c.Int(nullable: false));
            AddColumn("dbo.tblTakvim", "Ay", c => c.Int(nullable: false));
            AddColumn("dbo.tblTakvim", "Gun", c => c.Int(nullable: false));
            DropColumn("dbo.tblTakvim", "textColor");
            DropColumn("dbo.tblTakvim", "color");
            DropColumn("dbo.tblTakvim", "end");
            DropColumn("dbo.tblTakvim", "start");
            DropColumn("dbo.tblTakvim", "title");
        }
    }
}
