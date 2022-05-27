namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ustelenenuye : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblIs", "UslenenUyeId");
            RenameColumn(table: "dbo.tblIs", name: "OlusturanUyeId", newName: "UslenenUyeId");
            RenameIndex(table: "dbo.tblIs", name: "IX_OlusturanUyeId", newName: "IX_UslenenUyeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.tblIs", name: "IX_UslenenUyeId", newName: "IX_OlusturanUyeId");
            RenameColumn(table: "dbo.tblIs", name: "UslenenUyeId", newName: "OlusturanUyeId");
            AddColumn("dbo.tblIs", "UslenenUyeId", c => c.Int(nullable: false));
        }
    }
}
