namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prva : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UpisGodines", "SmjerId", "dbo.Smjers");
            DropIndex("dbo.UpisGodines", new[] { "SmjerId" });
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.NPPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        AkademskaGodinaId = c.Int(nullable: false),
                        SmjerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AkademskaGodinas", t => t.AkademskaGodinaId)
                .ForeignKey("dbo.Smjers", t => t.SmjerId)
                .Index(t => t.AkademskaGodinaId)
                .Index(t => t.SmjerId);
            
            CreateTable(
                "dbo.Opstinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Opis = c.String(),
                        RegijaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regijas", t => t.RegijaId)
                .Index(t => t.RegijaId);
            
            CreateTable(
                "dbo.Regijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Predajes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        NastavnikId = c.Int(nullable: false),
                        AkademskaGodinaId = c.Int(nullable: false),
                        PredmetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AkademskaGodinas", t => t.AkademskaGodinaId)
                .ForeignKey("dbo.Nastavniks", t => t.NastavnikId)
                .ForeignKey("dbo.Predmets", t => t.PredmetId)
                .Index(t => t.NastavnikId)
                .Index(t => t.AkademskaGodinaId)
                .Index(t => t.PredmetId);
            
            CreateTable(
                "dbo.Predmets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Ects = c.Single(nullable: false),
                        NppId = c.Int(nullable: false),
                        GodinaStudija = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NPPs", t => t.NppId)
                .Index(t => t.NppId);
            
            CreateTable(
                "dbo.SlusaPredmets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        PredajeId = c.Int(nullable: false),
                        UpisGodineId = c.Int(nullable: false),
                        FinalnaOcjena = c.Int(),
                        DatumOcjene = c.DateTime(),
                        Priznato = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Predajes", t => t.PredajeId)
                .ForeignKey("dbo.UpisGodines", t => t.UpisGodineId)
                .Index(t => t.PredajeId)
                .Index(t => t.UpisGodineId);
            
            AddColumn("dbo.Students", "OpstinaRodjenjaId", c => c.Int());
            AddColumn("dbo.Students", "OpstinaPrebivalistaId", c => c.Int());
            AddColumn("dbo.Students", "NppId", c => c.Int());
            AlterColumn("dbo.Korisniks", "DatumRodjenja", c => c.DateTime());
            CreateIndex("dbo.Students", "OpstinaRodjenjaId");
            CreateIndex("dbo.Students", "OpstinaPrebivalistaId");
            CreateIndex("dbo.Students", "NppId");
            AddForeignKey("dbo.Students", "NppId", "dbo.NPPs", "Id");
            AddForeignKey("dbo.Students", "OpstinaPrebivalistaId", "dbo.Opstinas", "Id");
            AddForeignKey("dbo.Students", "OpstinaRodjenjaId", "dbo.Opstinas", "Id");
            DropColumn("dbo.UpisGodines", "SmjerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UpisGodines", "SmjerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SlusaPredmets", "UpisGodineId", "dbo.UpisGodines");
            DropForeignKey("dbo.SlusaPredmets", "PredajeId", "dbo.Predajes");
            DropForeignKey("dbo.Predajes", "PredmetId", "dbo.Predmets");
            DropForeignKey("dbo.Predmets", "NppId", "dbo.NPPs");
            DropForeignKey("dbo.Predajes", "NastavnikId", "dbo.Nastavniks");
            DropForeignKey("dbo.Predajes", "AkademskaGodinaId", "dbo.AkademskaGodinas");
            DropForeignKey("dbo.Students", "OpstinaRodjenjaId", "dbo.Opstinas");
            DropForeignKey("dbo.Students", "OpstinaPrebivalistaId", "dbo.Opstinas");
            DropForeignKey("dbo.Opstinas", "RegijaId", "dbo.Regijas");
            DropForeignKey("dbo.Students", "NppId", "dbo.NPPs");
            DropForeignKey("dbo.NPPs", "SmjerId", "dbo.Smjers");
            DropForeignKey("dbo.NPPs", "AkademskaGodinaId", "dbo.AkademskaGodinas");
            DropForeignKey("dbo.Administrators", "Id", "dbo.Korisniks");
            DropIndex("dbo.SlusaPredmets", new[] { "UpisGodineId" });
            DropIndex("dbo.SlusaPredmets", new[] { "PredajeId" });
            DropIndex("dbo.Predmets", new[] { "NppId" });
            DropIndex("dbo.Predajes", new[] { "PredmetId" });
            DropIndex("dbo.Predajes", new[] { "AkademskaGodinaId" });
            DropIndex("dbo.Predajes", new[] { "NastavnikId" });
            DropIndex("dbo.Opstinas", new[] { "RegijaId" });
            DropIndex("dbo.NPPs", new[] { "SmjerId" });
            DropIndex("dbo.NPPs", new[] { "AkademskaGodinaId" });
            DropIndex("dbo.Students", new[] { "NppId" });
            DropIndex("dbo.Students", new[] { "OpstinaPrebivalistaId" });
            DropIndex("dbo.Students", new[] { "OpstinaRodjenjaId" });
            DropIndex("dbo.Administrators", new[] { "Id" });
            AlterColumn("dbo.Korisniks", "DatumRodjenja", c => c.DateTime(nullable: false));
            DropColumn("dbo.Students", "NppId");
            DropColumn("dbo.Students", "OpstinaPrebivalistaId");
            DropColumn("dbo.Students", "OpstinaRodjenjaId");
            DropTable("dbo.SlusaPredmets");
            DropTable("dbo.Predmets");
            DropTable("dbo.Predajes");
            DropTable("dbo.Regijas");
            DropTable("dbo.Opstinas");
            DropTable("dbo.NPPs");
            DropTable("dbo.Administrators");
            CreateIndex("dbo.UpisGodines", "SmjerId");
            AddForeignKey("dbo.UpisGodines", "SmjerId", "dbo.Smjers", "Id");
        }
    }
}
