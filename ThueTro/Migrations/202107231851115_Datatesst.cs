namespace ThueTro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datatesst : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NhaTroes", "IDQuann");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhaTroes", "IDQuann", c => c.String());
        }
    }
}
