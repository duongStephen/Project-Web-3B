namespace ThueTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhaTroes", "ratting", c => c.Int(nullable: false));
            AddColumn("dbo.NhaTroes", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhaTroes", "DateTime");
            DropColumn("dbo.NhaTroes", "ratting");
        }
    }
}
