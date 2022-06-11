namespace SimpleJob.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sp : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
            "dbo.sp_Rapor",
            p => new
            {
                
            },
            body:
                @"SELECT Count(*) From tblIs where IsKategoriId = 7"
        );

        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.sp_Rapor");
        }
    }
}
