namespace MercaditoRecargado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segunda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas");
            DropIndex("dbo.Clientes", new[] { "Persona_PersonaID" });
            RenameColumn(table: "dbo.Clientes", name: "Persona_PersonaID", newName: "PersonaID");
            AlterColumn("dbo.Clientes", "PersonaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientes", "PersonaID");
            AddForeignKey("dbo.Clientes", "PersonaID", "dbo.Personas", "PersonaID", cascadeDelete: true);
            DropColumn("dbo.Clientes", "ClienteDatos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "ClienteDatos", c => c.Int(nullable: false));
            DropForeignKey("dbo.Clientes", "PersonaID", "dbo.Personas");
            DropIndex("dbo.Clientes", new[] { "PersonaID" });
            AlterColumn("dbo.Clientes", "PersonaID", c => c.Int());
            RenameColumn(table: "dbo.Clientes", name: "PersonaID", newName: "Persona_PersonaID");
            CreateIndex("dbo.Clientes", "Persona_PersonaID");
            AddForeignKey("dbo.Clientes", "Persona_PersonaID", "dbo.Personas", "PersonaID");
        }
    }
}
