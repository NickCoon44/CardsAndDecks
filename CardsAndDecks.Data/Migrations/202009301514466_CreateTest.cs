namespace CardsAndDecks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TemplateProperty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemplateId = c.Int(nullable: false),
                        PropertyName = c.String(nullable: false),
                        PropertyType = c.Int(nullable: false),
                        CardId = c.Int(),
                        Value = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Card", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Template", t => t.TemplateId, cascadeDelete: true)
                .Index(t => t.TemplateId)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DeckId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deck", t => t.DeckId, cascadeDelete: true)
                .Index(t => t.DeckId);
            
            CreateTable(
                "dbo.Deck",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemplateProperty", "TemplateId", "dbo.Template");
            DropForeignKey("dbo.TemplateProperty", "CardId", "dbo.Card");
            DropForeignKey("dbo.Card", "DeckId", "dbo.Deck");
            DropIndex("dbo.Card", new[] { "DeckId" });
            DropIndex("dbo.TemplateProperty", new[] { "CardId" });
            DropIndex("dbo.TemplateProperty", new[] { "TemplateId" });
            DropTable("dbo.Deck");
            DropTable("dbo.Card");
            DropTable("dbo.TemplateProperty");
        }
    }
}
