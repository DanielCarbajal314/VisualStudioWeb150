namespace Personal.Infraestructura.ContextoDeDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogDeErrores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogDeExcepcion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Uri = c.String(),
                        Stack = c.String(),
                        Mensaje = c.String(),
                        DiaDeCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogDeExcepcion");
        }
    }
}
