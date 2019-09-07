namespace Personal.Infraestructura.ContextoDeDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraDeFin = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        Observacion = c.String(),
                        PersonaId = c.Int(nullable: false),
                        ProyectoId = c.Int(nullable: false),
                        DiaDeCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.PersonaId, cascadeDelete: true)
                .ForeignKey("dbo.Proyecto", t => t.ProyectoId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.ProyectoId);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DiaDeCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proyecto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DiaDeCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProyectoPersona",
                c => new
                    {
                        Proyecto_Id = c.Int(nullable: false),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Proyecto_Id, t.Persona_Id })
                .ForeignKey("dbo.Proyecto", t => t.Proyecto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Proyecto_Id)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProyectoPersona", "Persona_Id", "dbo.Persona");
            DropForeignKey("dbo.ProyectoPersona", "Proyecto_Id", "dbo.Proyecto");
            DropForeignKey("dbo.Actividad", "ProyectoId", "dbo.Proyecto");
            DropForeignKey("dbo.Actividad", "PersonaId", "dbo.Persona");
            DropIndex("dbo.ProyectoPersona", new[] { "Persona_Id" });
            DropIndex("dbo.ProyectoPersona", new[] { "Proyecto_Id" });
            DropIndex("dbo.Actividad", new[] { "ProyectoId" });
            DropIndex("dbo.Actividad", new[] { "PersonaId" });
            DropTable("dbo.ProyectoPersona");
            DropTable("dbo.Proyecto");
            DropTable("dbo.Persona");
            DropTable("dbo.Actividad");
        }
    }
}
