namespace ThueTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDBNhaTros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhaTroes", "image2", c => c.String());
            AddColumn("dbo.NhaTroes", "image3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhaTroes", "image3");
            DropColumn("dbo.NhaTroes", "image2");
        }
    }
}
