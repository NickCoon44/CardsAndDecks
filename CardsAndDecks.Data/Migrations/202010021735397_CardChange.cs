namespace CardsAndDecks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Card", "TemplateName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Card", "TemplateName");
        }
    }
}
