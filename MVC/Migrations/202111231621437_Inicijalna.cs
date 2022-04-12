namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicijalna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "DatumRodjenja", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Korisniks", "DatumRodjenja");
        }
    }
}
