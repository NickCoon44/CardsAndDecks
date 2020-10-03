namespace CardsAndDecks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAssignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeckId = c.Int(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Card", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.Deck", t => t.DeckId, cascadeDelete: true)
                .Index(t => t.DeckId)
                .Index(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignment", "DeckId", "dbo.Deck");
            DropForeignKey("dbo.Assignment", "CardId", "dbo.Card");
            DropIndex("dbo.Assignment", new[] { "CardId" });
            DropIndex("dbo.Assignment", new[] { "DeckId" });
            DropTable("dbo.Assignment");
        }
    }
}
