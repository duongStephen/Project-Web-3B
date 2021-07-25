namespace ThueTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datatesst123 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhaTroes", "IDQuann", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhaTroes", "IDQuann");
        }
    }
}
