namespace Personal.Infraestructura.ContextoDeDatos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Personal.Infraestructura.ContextoDeDatos.PersonalDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Personal.Infraestructura.ContextoDeDatos.PersonalDb";
        }

        protected override void Seed(Personal.Infraestructura.ContextoDeDatos.PersonalDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
